<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\GioiThieuModel;
class GioiThieuController extends Controller
{

	//lấy thông tin chức năng và nhiệm vụ
    public function getSuaCNNV($id)
    {
    	$chucnangnhiemvu = GioiThieuModel::find($id);
    	return view('admin.gioithieu.chucnangnhiemvu',compact('chucnangnhiemvu'));
    }

    //cập nhật thông tin chức năng và nhiệm vụ
    public function postSuaCNNV(Request $request,$id)
    {
    	$chucnangnhiemvu = GioiThieuModel::find($id);
    	$chucnangnhiemvu->ChucNangNhiemVu = $request->ChucNangNhiemVu;
    	$chucnangnhiemvu->save();
    	return redirect()->route('admin.gioithieu.getsuacnnv',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }

    //====================================================================
    //cơ cấu tổ chức
    public function getSuaCCTC($id)
    {
    	$cocautochuc = GioiThieuModel::find($id);
    	return view('admin.gioithieu.cocautochuc',compact('cocautochuc'));
    }

    public function postSuaCCTC(Request $request,$id)
    {
    	$cocautochuc = GioiThieuModel::find($id);
    	$cocautochuc->CoCauToChuc = $request->CoCauToChuc;
    	$cocautochuc->save();
    	return redirect()->route('admin.gioithieu.getsuacctc',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }


    //=======================================================================
    //nhân sự
    public function getSuaNhanSu($id)
    {
    	$nhansu = GioiThieuModel::find($id);
    	return view('admin.gioithieu.nhansu',compact('nhansu'));
    }

    public function postSuaNhanSu(Request $request,$id)
    {
    	$nhansu = GioiThieuModel::find($id);
    	$nhansu->NhanSu = $request->NhanSu;
    	$nhansu->save();
    	return redirect()->route('admin.gioithieu.getsuanhansu',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }

    //=======================================================================
    //liên hệ
    public function getSuaLienHe($id)
    {
    	$lienhe = GioiThieuModel::find($id);
    	return view('admin.gioithieu.lienhe',compact('lienhe'));
    }

    public function postSuaLienHe(Request $request,$id)
    {
    	$lienhe = GioiThieuModel::find($id);
    	$lienhe->LienHe = $request->LienHe;
    	$lienhe->save();
    	return redirect()->route('admin.gioithieu.getsualienhe',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }

    //=======================================================================
    //thông tin cập nhật
    public function getSuaThongTin($id)
    {
    	$thongtin = GioiThieuModel::find($id);
    	return view('admin.gioithieu.thongtin',compact('thongtin'));
    }

    public function postSuaThongTin(Request $request,$id)
    {
    	$thongtin = GioiThieuModel::find($id);
    	$thongtin->ThongTin = $request->ThongTin;
    	$thongtin->save();
    	return redirect()->route('admin.gioithieu.getsuathongtin',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }
}
