<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\CauHinh;
class CauHinhController extends Controller
{
    public function getGioiThieuCongTy()
    {
    	$cauhinh = CauHinh::where('id',1)->select('GioiThieuCongTy')->first();
    	return view('admin.qlcauhinh.gioithieucongty',compact('cauhinh'));
    }
    public function postGioiThieuCongTy(Request $request)
    {
    	CauHinh::where('id',1)->update([
    		'GioiThieuCongTy' => $request->GioiThieuCongTy,
    	]);
    	return redirect()->route('goldstar-admin.qlcauhinh.gioithieucongty')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }

    public function getGioiThieuCongVienNuoc()
    {
    	$cauhinh = CauHinh::where('id',1)->select('GioiThieuCongVienNuoc')->first();
    	return view('admin.qlcauhinh.congviennuoc',compact('cauhinh'));
    }
    public function postGioiThieuCongVienNuoc(Request $request)
    {
    	CauHinh::where('id',1)->update([
    		'GioiThieuCongVienNuoc' => $request->GioiThieuCongVienNuoc,
    	]);
    	return redirect()->route('goldstar-admin.qlcauhinh.gioithieucongviennuoc')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }

    public function getGioiThieuNhaHangCF()
    {
    	$cauhinh = CauHinh::where('id',1)->select('GioiThieuNhaHangCaFe')->first();
    	return view('admin.qlcauhinh.nhahangcf',compact('cauhinh'));
    }
    public function postGioiThieuNhaHangCF(Request $request)
    {
    	CauHinh::where('id',1)->update([
    		'GioiThieuNhaHangCaFe' => $request->GioiThieuNhaHangCaFe,
    	]);
    	return redirect()->route('goldstar-admin.qlcauhinh.gioithieunhahangcf')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }
}
