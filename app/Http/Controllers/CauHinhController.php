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

    public function getCauHinhHeThong()
    {
        $cauhinh = CauHinh::where('id',1)->first();
        return view('admin.qlcauhinh.cauhinhhethong',compact('cauhinh'));
    }
    public function postCauHinhHeThong(Request $request)
    {

        if($request->hasFile('Icon'))
        {
            $file =  $request->file('Icon');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('goldstar-admin.qlcauhinh.cauhinhhethong')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $Icon = str_random(10)."_".changeTitle($name).'.'.$duoi;
            while (file_exists("public/upload/user/".$Icon)) {
                $Icon = str_random(10)."_".changeTitle($name).'.'.$duoi;
            }
            $file->move("public/upload/user",trim($Icon));

        }
        if($request->hasFile('Logo'))
        {
            $file =  $request->file('Logo');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('goldstar-admin.qlcauhinh.cauhinhhethong')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name    = $file->getClientOriginalName();
            $Logo = str_random(10)."_".changeTitle($name).'.'.$duoi;
            while (file_exists("public/upload/user/".$Logo)) {
                $Logo = str_random(10)."_".changeTitle($name).'.'.$duoi;
            }
            $file->move("public/upload/user",trim($Logo));
        }
        CauHinh::where('id',1)->update([
            'ThongTin'  => $request->ThongTin,
            'Title'     => $request->Title,
            'Email'     => $request->Email,
            'DienThoai' => $request->DienThoai,
            'TrangThai' => $request->TrangThai,
            'Logo'      => $Logo,
            'Icon'      => $Icon,
        ]);
        return redirect()->route('goldstar-admin.qlcauhinh.cauhinhhethong')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }
}
