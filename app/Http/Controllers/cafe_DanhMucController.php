<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\cafe_DanhMuc;
use App\Http\Requests\cafe_DanhMucRequest;
class cafe_DanhMucController extends Controller
{
    public function getDanhSach()
    {
    	$cafe_danhmuc = cafe_DanhMuc::all();
    	return view('admin.cafe.qldanhmuc.danhsach',compact('cafe_danhmuc'));
    }
    public function postThem(cafe_DanhMucRequest $request)
    {
    	$cafe_danhmuc = new cafe_DanhMuc;
    	$cafe_danhmuc->tendanhmuc         = $request->tendanhmuc;
    	$cafe_danhmuc->tendanhmuckhongdau = changeTitle($request->tendanhmuc);
    	$cafe_danhmuc->save();
    	return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }
    public function getXoa($id)
    {
    	if(isset($id) == cafe_DanhMuc::find($id))
    	{
    		// kiểm tra có nước thuộc lại này không
    		$cafe_danhmuc = cafe_DanhMuc::find($id);
    		$cafe_danhmuc->delete();
    		return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
    	}
    	return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Xóa không thành công?']);
    }

    public function getSua($id)
    {
    	if(isset($id) == cafe_DanhMuc::find($id))
    	{
    		$cafe_danhmuc = cafe_DanhMuc::find($id);
    		return view('admin.cafe.qldanhmuc.sua',compact('cafe_danhmuc'));
    	}	
    	return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Cập nhật không thành công?']);
    }
    public function postSua(cafe_DanhMucRequest $request,$id)
    {
    	if(isset($id) == cafe_DanhMuc::find($id))
    	{
    		$cafe_danhmuc = cafe_DanhMuc::find($id);
    		$cafe_danhmuc->tendanhmuc         = $request->tendanhmuc;
	    	$cafe_danhmuc->tendanhmuckhongdau = changeTitle($request->tendanhmuc);
	    	$cafe_danhmuc->save();
	    	return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    	}
    	return redirect()->route('goldstar-admin.cafe.qldanhmuc.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Cập nhật không thành công?']);
    }
}
