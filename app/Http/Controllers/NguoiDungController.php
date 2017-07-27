<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\User;
use App\Http\Requests\NguoiDungRequest;
use DB;
use Hash;

class NguoiDungController extends Controller
{
    public function getDanhSach()
    {
        $nguoidung = User::orderBy('id','DESC')->get();
    	return view('admin.qlnguoidung.danhsach',compact('nguoidung'));
    }
    public function postThem(NguoiDungRequest $request)
    {
        $user           = new User;
        $user->name     = ucwords(trim($request->name));
        $user->level     = 1;
        $user->email    = trim($request->email);
        $user->password = Hash::make(trim($request->password));
        $user->remember_token = $request->_token;
        if($request->hasFile('hinhanh'))
        {
            $file =  $request->file('hinhanh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            while (file_exists("public/upload/user/".$hinhanh)) {
                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            }
            $file->move("public/upload/user",trim($hinhanh));
            $user->hinhanh = trim($hinhanh);
        }
        $user->save();
        return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getSua($id)
    {
        if(isset($id) == User::find($id))
        {
            $user = User::find($id);
            return view('admin.qlnguoidung.sua',compact('user'));
        }
        return redirect()->route('admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }
    public function postSua(Request $request,$id)
    {
        if(isset($id) == User::find($id))
        {
            $user = User::find($id);
            $this->validate($request,[
                'name'=>'required|min:5',
                'email'=>'required|email|unique:users,email,'.$id,
                ],[
                    'name.required'=> 'Bạn chưa nhập tên người dùng',
                    'name.min'     =>'Tên người dùng ít nhất phải có 5 ký tự',
                    'email.required'=>'E-Mail không được trống',
                    'email.unique'  =>'E-Mail đã tồn tại',
                ]);
       
            $user->name = ucwords(trim($request->name));
            $user->email =trim($request->email);
            if($request->changePassword == "on")
            {
                $this->validate($request,[
                'password'      => 'required',
                'passwordagain' => 'required|same:password'
                ],[
                    'password.required'     =>'Bạn chưa nhập Mật khẩu',
                    'passwordagain.required'=>'Bạn chưa nhập lại mật khẩu',
                    'passwordagain.same'    =>'Mật khẩu nhập lại chưa khớp'
                ]);
                $user->password = bcrypt(trim($request->password));
                $user->remember_token = $request->_token;
            }   

            if($request->hasFile('hinhanh'))
            {
                $file =  $request->file('hinhanh');
                $duoi = $file->getClientOriginalExtension();
                if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                {
                    return redirect()->route('goldstar-admin.qlnguoidung.getsua',$id)->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                }
                $name = $file->getClientOriginalName();

                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
                while (file_exists("public/upload/user/".$hinhanh)) {
                    $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
                }
                if($user->hinhanh != "")
                {
                    if(file_exists("public/upload/user/".$user->hinhanh))
                    {
                        unlink("public/upload/user/".$user->hinhanh);
                    }
                }
                
                $file->move("public/upload/user",trim($hinhanh));
                $user->hinhanh = trim($hinhanh);
            }
            $user->save();
            return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }
    public function getXoa($id)
    {
        if(isset($id) == User::find($id))
        {
            $user = User::find($id);
            if($user->hinhanh != "")
            {
	            if(file_exists("public/upload/user/".$user->hinhanh))
	            {
	                unlink("public/upload/user/".$user->hinhanh);
	            }
	        }
            $user->delete($id);
            return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
        }
        return redirect()->route('goldstar-admin.qlnguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);     
    }
}
