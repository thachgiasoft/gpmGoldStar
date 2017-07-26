<?php

namespace App\Http\Controllers;
use Illuminate\Contracts\Auth\Authenticable;
use Illuminate\Auth\Authenticable as AuthenticableTrait;
use Illuminate\Support\Facades\Auth;
use Illuminate\Http\Request;
use App\User;
use App\Http\Requests\NguoiDungRequest;
use Hash;

class NguoiDungController extends Controller
{
    //lấy danh sách người dùng
    public function getDanhSach()
    {
        $nguoidung = User::orderBy('id','DESC')->get();
    	return view('admin.nguoidung.danhsach',compact('nguoidung'));
    }

    //Thêm danh sách người dùng
    public function postThem(NguoiDungRequest $request)
    {
        $user           = new User;
        $user->name     = ucwords(trim($request->name));
        $user->email    = trim($request->email);
        $user->password = bcrypt(trim($request->password));
        $user->remember_token = $request->_token;
        $user->level    = $request->level;
        if($request->hasFile('hinhanh'))
        {
            $file =  $request->file('hinhanh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            
            $file->move("public/upload",trim($hinhanh));
            $user->hinhanh = trim($hinhanh);
        }
        $user->save();
        return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    //Lấy thông tin người dùng để sửa
    public function getSua($id)
    {
        if(isset($id) == User::find($id))
        {
            $user          = User::find($id);
            return view('admin.nguoidung.sua',compact('user'));
        }
        return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }

    //Cập nhật người dùng
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
                if(Hash::check($request->passwordcu,$user->password))
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
                }else
                {
                    return redirect()->route('admin.nguoidung.getsua',$id)->with(['thongbao_level'=>'danger','thongbao'=>'Mật khẩu củ nhập lại không chính xác? ']); 
                }
            }   

            if($request->hasFile('hinhanh'))
            {
                $file =  $request->file('hinhanh');
                $duoi = $file->getClientOriginalExtension();
                if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                {
                    return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                }
                $name = $file->getClientOriginalName();

                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
               
                if($user->hinhanh != "")
                {
                    if(file_exists("public/upload/".$user->hinhanh))
                    {
                        unlink("public/upload/".$user->hinhanh);
                    }
                }
                
                $file->move("public/upload",trim($hinhanh));
                $user->hinhanh = trim($hinhanh);
            }
            $user->save();
            return redirect()->route('admin.nguoidung.getsua',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }


    //Xóa người dùng
    public function getXoa($id)
    {
        if(isset($id) == User::find($id))
        {
            $user = User::find($id);
            if($user->hinhanh != "")
            {
                if(file_exists("public/upload/".$user->hinhanh))
                {
                    unlink("public/upload/".$user->hinhanh);
                }
            }
            $user->delete($id);
            return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
        }
        return redirect()->route('admin.nguoidung.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);     
    }
    
    //Đăng nhập
    public function getDangNhapAdmin()
    {
        return view('admin.login');
    }

    //kiểm tra đăng nhập
    public function postDangNhapAdmin(Request $request)
    {
        $this->validate($request,[
            'email'    =>'required',
            'password'=>'required'
            ],[
            'email.required'   =>'Bạn chưa nhập email',
            'password.required'=>'Bạn chưa nhập Mật khẩu',
            ]);
       if(Auth::attempt(['email'=>trim($request->email),'password'=>trim($request->password)]))
       {
            return redirect()->route('admin.tintuc.danhsach');
       }
       else
       {
            return redirect('admin/login')->with('thongbao','Đăng nhập thất bại');
       }
    }

    //đăng xuất
    public function getDangXuatAdmin()
    {
        Auth::logout();
        return redirect('admin/login');
    }
}
