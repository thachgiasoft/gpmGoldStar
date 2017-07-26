<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\HinhAnhHoatDongModel;
use DB;

class HinhAnHoatDongController extends Controller
{
    public function getDanhSach()
    {
    	$hinhanh = HinhAnhHoatDongModel::orderBy('id','DESC')->get();
    	return view('admin.hinhanh.danhsach',compact('hinhanh'));
    }

    public function postThem(Request $request)
    {
    	$this->validate($request,[
                'TenAnh'=>'required',
                ],[
                    'TenAnh.required'=> 'Bạn chưa nhập tên ảnh',
                ]);
    	$hinhanhhoatdong = new HinhAnhHoatDongModel;
    	$hinhanhhoatdong->TenAnh = $request->TenAnh;
    	if($request->hasFile('hinhanh'))
        {
            $file =  $request->file('hinhanh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('admin.anhhoatdong.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name = $file->getClientOriginalName();
            $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            $file->move("public/upload",trim($hinhanh));
            $hinhanhhoatdong->HinhAnh = trim($hinhanh);
        }
        $hinhanhhoatdong->save();
        return redirect()->route('admin.anhhoatdong.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getSua($id)
    {
    	$hinhanh = HinhAnhHoatDongModel::find($id);
    	return view('admin.hinhanh.sua',compact('hinhanh'));
    }

    public function postSua(Request $request,$id)
    {
    	$hinhanhhoatdong = HinhAnhHoatDongModel::find($id);
       	$this->validate($request,[
                	'TenAnh'=>'required',
                ],[
                    'TenAnh.required'=> 'Bạn chưa nhập tên ảnh',
                ]);
         	$hinhanhhoatdong->TenAnh = $request->TenAnh;
            if($request->hasFile('hinhanh'))
            {
                $file =  $request->file('hinhanh');
                $duoi = $file->getClientOriginalExtension();
                if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                {
                    return redirect()->route('admin.anhhoatdong.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                }
                $name = $file->getClientOriginalName();

                $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
               
                if($hinhanhhoatdong->HinhAnh != "")
                {
                    if(file_exists("public/upload/".$hinhanhhoatdong->HinhAnh))
                    {
                        unlink("public/upload/".$hinhanhhoatdong->HinhAnh);
                    }
                }
                
                $file->move("public/upload",trim($hinhanh));
                $hinhanhhoatdong->HinhAnh = trim($hinhanh);
            }
            $hinhanhhoatdong->save();
            return redirect()->route('admin.anhhoatdong.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }
    public function getXoa($id)
    {
    	$hinhanh = HinhAnhHoatDongModel::find($id);
        if($hinhanh->HinhAnh != "")
        {
            if(file_exists("public/upload/".$hinhanh->HinhAnh))
            {
                unlink("public/upload/".$hinhanh->HinhAnh);
            }
        }
        $hinhanh->delete($id);
        return redirect()->route('admin.anhhoatdong.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
    }
}
