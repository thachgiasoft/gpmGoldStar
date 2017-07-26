<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\TinTucModel;
use App\LoaiTinModel;
use App\CauHinhModel;
use Illuminate\Contracts\Auth\Authenticable;
use Illuminate\Auth\Authenticable as AuthenticableTrait;
use Illuminate\Support\Facades\Auth;
use App\MailModel;
use Hash;
use DB;
use App\SildeModel;
use App\HinhAnhHoatDongModel;

class PageController extends Controller
{
    function __construct()
    {
        $slide = SildeModel::orderBy('created_at','DESC')->where('TrangThai',0)->take(10)->get();
        view()->share('slide',$slide);

        $slidesinhvien = SildeModel::orderBy('created_at','DESC')->where('TrangThai',1)->paginate(10);
        view()->share('slidesinhvien',$slidesinhvien);
        
    }
    
    function getTrangChu()
    {
        return view('page.trangchu');
    }

    function postDangKyNhanTin(Request $request)
    {
        $this->validate($request,[
            'Email'  =>'required|unique:mail,Email',
            ],[
                'Email.required' =>'Bạn chưa nhập E-mail',
                'Email.unique'=>'E=Mail đã tồn tại'
            ]);
        $mail = new MailModel;
        $mail->Email = $request->Email;
        $mail->save();
        return redirect()->route('trangchu')->with(['thongbao_level'=>'success','thongbao'=>'Bạn đã đăng ký nhận tin thành công. ']); 
    }

    function getChucNangNhiemVu()
    {
        return view('page.chucnangnhiemvu');
    }
    function getCoCauToChuc()
    {
        return view('page.cocautochuc');
    }

    function getNhanSu()
    {
        return view('page.nhansu');
    }
    function getLoaiTin($id)
    {
        $loaitin = LoaiTinModel::find($id);
        $tintuc  = TinTucModel::orderBy('created_at','DESC')->where('IDLoaiTin',$id)->paginate(5);
        return view('page.loaitin',compact('loaitin','tintuc'));
    }

    function getTinTuc($id)
    {
        $tintuc      = TinTucModel::find($id);
        $tintuc->SoLuotXem = $tintuc->SoLuotXem +1;
        TinTucModel::where('id',$id)->update(['SoLuotXem'=>$tintuc->SoLuotXem]);
        $tinlienquan = TinTucModel::orderBy('created_at','DESC')->where('IDLoaiTin',$tintuc->IDLoaiTin)->take(3)->get();
        return view('page.chitiet',compact('tintuc','tinlienquan'));
    }

    
    function postTimKiem(Request $request)
    {
        $tukhoa = $request->TuKhoa;
        $tintuc = TinTucModel::orderBy('created_at','DESC')->where('TieuDe','like',"%$tukhoa%")->orWhere('TomTat','like',"%$tukhoa%")->paginate(5);
       
        $tintuc = $tintuc->appends( array (
                    'TuKhoa' => $tukhoa
                ));
         
        return view('page.timkiem',compact('tukhoa','tintuc'));
    }

    function getSilde($id)
    {
        $silde      = SildeModel::find($id);
        return view('page.silde',compact('silde'));
    }

    function getTinTucSuKien()
    {
        //$tintuc  = TinTucModel::orderBy('created_at','DESC')->paginate(10);
        $tintuc = DB::table('tintuc')
            ->join('loaitin', 'loaitin.id', '=', 'tintuc.IDLoaiTin')
            ->where('NoiBat',1)
            //->where('loaitin.id','=',3)
            ->where('loaitin.IDNhomLoaiTin','=',3)
            ->orderBy('created_at','DESC')
            ->select('tintuc.*')
            ->paginate(10);
        return view('page.tintucsukien',compact('tintuc'));
    }

    function getTinTucSinhVien()
    {
        $tintuc = DB::table('tintuc')
            ->join('loaitin', 'loaitin.id', '=', 'tintuc.IDLoaiTin')
            ->where('NoiBat',1)
            //->where('loaitin.id','=',2)
            ->where('loaitin.IDNhomLoaiTin','=',2)
            ->orderBy('created_at','DESC')
            ->select('tintuc.*')
            ->paginate(10);
            
        $tintuc  = TinTucModel::orderBy('created_at','DESC')->paginate(10);
        return view('page.tintucsinhvien',compact('tintuc'));
    }

    function getHinhAnhHoatDong()
    {
        $hinhanh = HinhAnhHoatDongModel::orderBy('created_at','DESC')->paginate(12);
        return view('page.hinhanhhoatdong',compact('hinhanh'));
    }
}
