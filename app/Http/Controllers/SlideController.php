<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Slide;
class SlideController extends Controller
{
    public function getDanhSach()
    {
    	$slide = Slide::all();
    	return view('admin.qlslide.danhsach',compact('slide'));
    }
    public function postThem(Request $request)
    {
    	// if($request->hasFile('hinhanh'))
     //    {
     //        $file =  $request->file('hinhanh');
     //        $duoi = $file->getClientOriginalExtension();
     //        $duoi1 = changeTitle($duoi);
     //        if($duoi1 != 'jpg' && $duoi1 != 'png' && $duoi1 != 'jpeg')
     //        {
     //            return redirect()->route('goldstar-admin.qlslide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
     //        }
     //        // $name    = $file->getClientOriginalName();
     //        // $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
     //        // while (file_exists("public/upload/user/".$hinhanh)) {
     //        //     $hinhanh = str_random(10)."_".changeTitle($name).'.'.$duoi;
     //        // }
     //        // $file->move("public/upload/user",trim($hinhanh));
     //        // $user->hinhanh = trim($hinhanh);
     //    }
    	// if($request->hasFile('HinhAnh'))
     //   	{
     //   		$file =  $request->file('HinhAnh');
     //        $duoi = $file->getClientOriginalExtension();
     //        $duoi1 = changeTitle($duoi);
     //        if($duoi1 != 'jpg' && $duoi1 != 'png' && $duoi1 != 'jpeg' && $duoi1 !='bmp' && $duoi1 !='gif')
     //        {
     //            return redirect()->route('goldstar-admin.qlslide.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Vui lòng chọn file .jpg .png .jpeg .bmp .gif']);
     //        }
     //   	}
       
       	var_dump($request->hasFile('HinhAnh'));
    	// $slide = new Slide;
    	// $slide->TieuDe  = $request->TieuDe;
    	// $slide->Link    = $request->Link;
    	// if($request->hasFile('HinhAnh'))
     //    {
     //        $file =  $request->file('HinhAnh');
     //        $duoi = $file->getClientOriginalExtension();
     //        $name    = $file->getClientOriginalName();
     //        $HinhAnh = str_random(10)."_".changeTitle($name).'.'.$duoi;
     //        while (file_exists("public/upload/slide/".$HinhAnh)) 
     //        {
     //            $HinhAnh = str_random(10)."_".changeTitle($name).'.'.$duoi;
     //        }
     //        $file->move("public/upload/slide",trim($HinhAnh));
     //        $slide->HinhAnh = trim($HinhAnh);
     //    }
    	//$slide->save();
    	//return redirect()->route('goldstar-admin.qlslide.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getXoa($id)
    {

    }
}
