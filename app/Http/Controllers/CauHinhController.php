<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\CauHinhModel;

class CauHinhController extends Controller
{
	//lấy thông tin
    public function getSua($id)
    {
    	$cauhinh = CauHinhModel::find($id);
    	return view('admin.cauhinh.sua',compact('cauhinh'));
    }

    //cập nhật thông tin cấu hình
    public function postSua(Request $request,$id)
    {
        if(isset($id) == CauHinhModel::find($id))
        {
            $cauhinh               = CauHinhModel::find($id);
            $cauhinh->Title        = trim($request->Title);
            $cauhinh->BanQuyen     = $request->BanQuyen;
            $cauhinh->LinkBanQuyen = $request->LinkBanQuyen;
            $cauhinh->ThietKe      = trim($request->ThietKe);
            $cauhinh->Version      = trim($request->Version);
            $cauhinh->EmailLienHe  = trim($request->EmailLienHe);
       
            if($request->Icon !="")
            {
                if($request->hasFile('Icon'))
                {
                    $file =  $request->file('Icon');

                    $duoi = $file->getClientOriginalExtension();
                    if($duoi != 'ico' && $duoi != 'icon')
                    {
                        return redirect()->route('admin.cauhinh.getsua',$id)->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .ico']);
                    }

                    $size = $request->file('Icon')->getSize();
                   
                    $name = $file->getClientOriginalName();
                    $Icon =  str_random(10)."_".changeTitle($name).'.'.$duoi;
                    
                    if(file_exists("public/upload/".$cauhinh->Icon))
                    {
                        unlink("public/upload/".$cauhinh->Icon);
                    }
                    $file->move("public/upload",trim($Icon));
                    $cauhinh->Icon = trim($Icon);
                }
            }

            if($request->Logo !="")
            {
                if($request->hasFile('Logo'))
                {
                    $file =  $request->file('Logo');

                    $duoi = $file->getClientOriginalExtension();
                    if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                    {
                        return redirect()->route('admin.qlhethong.cauhinh.getsua',$id)->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                    }
                    $size = $request->file('Logo')->getSize();
                   
                    $name = $file->getClientOriginalName();
                    $Logo =  str_random(10)."_".changeTitle($name).'.'.$duoi;
                    
                    if(file_exists("public/upload/".$cauhinh->Logo))
                    {
                        unlink("public/upload/".$cauhinh->Logo);
                    }
                    $file->move("public/upload",trim($Logo));
                    $cauhinh->Logo = trim($Logo);
                }
            }

            if($request->Banner !="")
            {
                if($request->hasFile('Banner'))
                {
                    $file =  $request->file('Banner');

                    $duoi = $file->getClientOriginalExtension();
                    if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                    {
                        return redirect()->route('admin.qlhethong.cauhinh.getsua',$id)->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                    }
                    $size = $request->file('Banner')->getSize();
                   
                    $name = $file->getClientOriginalName();
                    $Banner =  str_random(10)."_".changeTitle($name).'.'.$duoi;
                    
                    if(file_exists("public/upload/".$cauhinh->Banner))
                    {
                        unlink("public/upload/".$cauhinh->Banner);
                    }
                    $file->move("public/upload",trim($Banner));
                    $cauhinh->Banner = trim($Banner);
                }
            }

            $cauhinh->save();
            return redirect()->route('admin.cauhinh.getsua',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.cauhinh.sua')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']); 
    }


    //=================================================
    //bảo trì website
    public function getBaoTri($id)
    {
        $baotri = CauHinhModel::find($id);
        return view('admin.baotri.danhsach',compact('baotri'));
    }
    public function postBaoTri(Request $request,$id)
    {
        $baotri = CauHinhModel::find($id);
        $baotri->BaoTriWebsite = $request->BaoTriWebsite;
        $baotri->save();
        return redirect()->route('admin.cauhinh.getbaotri',$id)->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
    }
}
