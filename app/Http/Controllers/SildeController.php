<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\SildeModel;
use App\Http\Requests\SlideRequest;

class SildeController extends Controller
{
	//slide banner
    public function getDanhSach()
    {
    	$slide = SildeModel::where('TrangThai',0)->get();
    	return view('admin.silde.danhsach',compact('slide'));
    }
    
    //thêm silde ảnh mới
    public function postThem(SlideRequest $request)
    {
    	$slide = new SildeModel;
    	$slide->Ten = $request->TenHinh;
        $slide->TomTat = $request->TomTat;
    	$slide->NoiDung = $request->NoiDung;
    	$slide->TrangThai = 0;
    	if($request->hasFile('Hinh'))
        {
            $file =  $request->file('Hinh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            
            $file->move("public/upload",trim($hinhanh));
            $slide->Hinh = trim($hinhanh);
        }
        $slide->save();
        return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    //Lấy thông tin silde 
    public function getSua($id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde  = SildeModel::find($id);
            return view('admin.silde.sua',compact('silde'));
        }
        return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }


    public function postSua(Request $request,$id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde = SildeModel::find($id);
            $this->validate($request,[
                'TenHinh' =>'required|min:5',
                'NoiDung' =>'required',
                ],[
                    'TenHinh.required'      => 'Bạn chưa nhập tên hình',
                    'TenHinh.min'           =>'Tên hình ít nhất phải có 5 ký tự',
                    'NoiDung.required'      =>'Bạn chưa nhập Nội dung',
                ]);
       
            $silde->Ten = $request->TenHinh;
            $silde->TomTat = $request->TomTat;
            $silde->NoiDung = $request->NoiDung;

            if($request->hasFile('Hinh'))
            {
                $file =  $request->file('Hinh');
                $duoi = $file->getClientOriginalExtension();
                if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                {
                    return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                }
                $name = $file->getClientOriginalName();
                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
                if($silde->Hinh != "")
                {
                    if(file_exists("public/upload/".$silde->Hinh))
                    {
                        unlink("public/upload/".$silde->Hinh);
                    }
                }
                
                $file->move("public/upload",trim($hinhanh));
                $silde->Hinh = trim($hinhanh);
            }
            $silde->save();
            return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }

    public function getXoa($id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde = SildeModel::find($id);
            if(file_exists("public/upload/".$silde->Hinh))
            {
                unlink("public/upload/".$silde->Hinh);
            }
            $silde->delete($id);
            return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
        }
        return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);     
    }


    //==================================================
    //Slide Sinh viên tiêu biểu
    public function getDanhSachSinhVien()
    {
    	$slide = SildeModel::where('TrangThai',1)->get();
    	return view('admin.sildesinhvien.danhsach',compact('slide'));
    }
    //thêm sildesinh viên ảnh mới
    public function postThemSinhVien(Request $request)
    {
    	$slide = new SildeModel;
    	$slide->Ten = $request->TenHinh;
    	$slide->TrangThai = 1;
        $slide->TomTat = " ";
        $slide->NoiDung = " ";
    	if($request->hasFile('Hinh'))
        {
            $file =  $request->file('Hinh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            
            $file->move("public/upload",trim($hinhanh));
            $slide->Hinh = trim($hinhanh);
        }
        $slide->save();
        return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getSuaSinhVien($id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde  = SildeModel::find($id);
            return view('admin.sildesinhvien.sua',compact('silde'));
        }
        return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }


    public function postSuaSinhVien(Request $request,$id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde = SildeModel::find($id);
            $this->validate($request,[
                'TenHinh' =>'required|min:5',
                ],[
                    'TenHinh.required'      => 'Bạn chưa nhập tên hình',
                    'TenHinh.min'           =>'Tên hình ít nhất phải có 5 ký tự',
                ]);
       
            $silde->Ten = $request->TenHinh;
            $silde->TomTat = " ";
            $silde->NoiDung = " ";

            if($request->hasFile('Hinh'))
            {
                $file =  $request->file('Hinh');
                $duoi = $file->getClientOriginalExtension();
                if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                {
                    return redirect()->route('admin.slide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                }
                $name = $file->getClientOriginalName();
                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
                if($silde->Hinh != "")
                {
                    if(file_exists("public/upload/".$silde->Hinh))
                    {
                        unlink("public/upload/".$silde->Hinh);
                    }
                }
                
                $file->move("public/upload",trim($hinhanh));
                $silde->Hinh = trim($hinhanh);
            }
            $silde->save();
            return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
    }

    public function getXoaSinhVien($id)
    {
        if(isset($id) == SildeModel::find($id))
        {
            $silde = SildeModel::find($id);
            if(file_exists("public/upload/".$silde->Hinh))
            {
                unlink("public/upload/".$silde->Hinh);
            }
            $silde->delete($id);
            return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
        }
        return redirect()->route('admin.slidesinhvien.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);     
    }

}
