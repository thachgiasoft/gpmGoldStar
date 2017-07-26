<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\TinTucModel;
use App\LoaiTinModel;
use App\NhomLoaiTinModel;
use App\Http\Requests\TinTucRequest;
use DB;

class TinTucController extends Controller
{
    //lấy danh sách tin tức
    public function getDanhSach()
    {
        $tintuc  = TinTucModel::orderBy('id','DESC')->get();
        $loaitin = LoaiTinModel::all();
    	return view('admin.tintuc.danhsach',compact('tintuc','loaitin'));
    }

    //hiển thị giao diện thêm
    public function getThem()
    {
        $loaitin = LoaiTinModel::all();
        $nhomloaitin = NhomLoaiTinModel::all();
        return view('admin.tintuc.them',compact('loaitin','nhomloaitin'));
    }

    //Ajax lấy danh sách loại tin theo thể loại
    public function getDanhSachLoaiTin($IDTheLoai)
    {
        if (isset($IDTheLoai)) 
        {
           $loaitin = DB::table('loaitin')->where('IDNhomLoaiTin',$IDTheLoai)->get();
           foreach ($loaitin as $key)
           {
               echo "
                    <option value=".$key->id.">".$key->TenLoai."</option>
               ";
           }
        }
    }

    // thêm tin tức mới
    public function postThem(TinTucRequest $request)
    {
        $tintuc                  = new TinTucModel;
        $tintuc->TieuDe          = trim($request->TieuDe);
        $tintuc->TieuDeKhongDau = changeTitle( $request->TieuDe);
        $tintuc->IDLoaiTin       = $request->IDLoaiTin;
        $tintuc->TomTat          = $request->TomTat;
        $tintuc->NoiDung         = $request->NoiDung;
        $tintuc->NoiBat          = $request->NoiBat;
        $tintuc->SoLuotXem       = 0;

        if($request->hasFile('HinhAnh'))
        {
            $file =  $request->file('HinhAnh');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
            {
                return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
            }
            $name = $file->getClientOriginalName();
            $HinhAnh = str_random(10)."_".changeTitle($name).'.'.$duoi;
            $file->move("public/upload",$HinhAnh);
            $tintuc->HinhAnh = $HinhAnh;
        }
        else
        {
        	$tintuc->HinhAnh = "";
        }

        if($request->hasFile('FileDinhKem'))
        {
            $file =  $request->file('FileDinhKem');
            $duoi = $file->getClientOriginalExtension();
            if($duoi != 'doc' && $duoi != 'docx' && $duoi != 'pdf')
            {
                return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .doc .docx .pdf']);
            }

            $size = $request->file('FileDinhKem')->getSize();
            // if($size <= 1048576)
            // {
                $name = $file->getClientOriginalName();
                $FileDinhKem = changeTitle($name).'.'.$duoi;
                $file->move("public/upload",trim($FileDinhKem));
                $tintuc->FileDinhKem = trim($FileDinhKem);
            // }
            // else{
            //     return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file < 1MB']);
            // }
        }
        $tintuc->save();
        return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    //lấy thông tin tin tức cần cập nhật
    public function getSua($id)
    {   
        if(isset($id) == TinTucModel::find($id))
        {
            $tintuc = TinTucModel::find($id);
            $loaitin = LoaiTinModel::all();
            $nhomloaitin = NhomLoaiTinModel::all();
            return view('admin.tintuc.sua',compact('tintuc','loaitin','nhomloaitin'));
        }
        return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']); 
    }

    //cập nhật tin tức
    public function postSua(TinTucRequest $request,$id)
    {
        if(isset($id) == TinTucModel::find($id))
        {
            $tintuc                  = TinTucModel::find($id);
            $tintuc->TieuDe          = trim($request->TieuDe);
            $tintuc->TieuDeKhongDau = changeTitle( $request->TieuDe);
            $tintuc->IDLoaiTin       = $request->IDLoaiTin;
            $tintuc->TomTat          = $request->TomTat;
            $tintuc->NoiDung         = $request->NoiDung;
            $tintuc->NoiBat          = $request->NoiBat;
            $tintuc->SoLuotXem       = $tintuc->SoLuotXem;

            if($request->HinhAnh !="")
            {
                if($request->hasFile('HinhAnh'))
                {
                    $file =  $request->file('HinhAnh');
                    $duoi = $file->getClientOriginalExtension();
                    if($duoi != 'jpg' && $duoi != 'png' && $duoi != 'jpeg')
                    {
                        return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .jpg .png .jpeg']);
                    }
                    $name = $file->getClientOriginalName();
                    $HinhAnh = str_random(10)."_".changeTitle($name).'.'.$duoi;
                    if($tintuc->HinhAnh !="")
                    {
                        if(file_exists("public/upload/".$tintuc->HinhAnh))
                        {
                            unlink("public/upload/".$tintuc->HinhAnh);
                        }
                    }
                    
                    $file->move("public/upload",$HinhAnh);
                    $tintuc->HinhAnh = $HinhAnh;
                }
                else
                {
                    $tintuc->HinhAnh = "";
                }
            }
            if($request->FileDinhKem !="")
            {
                if($request->hasFile('FileDinhKem'))
                {
                    $file =  $request->file('FileDinhKem');

                    $duoi = $file->getClientOriginalExtension();
                    if($duoi != 'doc' && $duoi != 'docx' && $duoi != 'pdf')
                    {
                        return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file có đuôi .doc .docx .pdf']);
                    }

                    $size = $request->file('FileDinhKem')->getSize();
                    // if($size <= 1048576)
                    // {
                        $name = $file->getClientOriginalName();
                        $FileDinhKem =  str_random(10)."_".changeTitle($name).'.'.$duoi;
                        if($tintuc->FileDinhKem != "")
                        {
                            if(file_exists("public/upload/".$tintuc->FileDinhKem))
                            {
                                unlink("public/upload/".$tintuc->FileDinhKem);
                            }
                        }
                        
                        $file->move("public/upload",trim($FileDinhKem));
                        $tintuc->FileDinhKem = trim($FileDinhKem);
                    // }
                    // else{
                    //     return redirect()->route('admin.tintuc.getthem')->with(['thongbao_level'=>'danger','thongbao'=>'Bạn chỉ được chọn file < 1MB']);
                    // }
                }
            }
            $tintuc->save();
            return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
    }


    //xóa tin tức
    public function getXoa($id)
    {
        if(isset($id) == TinTucModel::find($id))
        {
            $tintuc = TinTucModel::find($id);
            if($tintuc->HinhAnh !="" )
            {
                if(file_exists("public/upload/".$tintuc->HinhAnh))
                {
                    unlink("public/upload/".$tintuc->HinhAnh);
                }
            }

            if($tintuc->FileDinhKem !="" )
            {
                if(file_exists("public/upload/".$tintuc->FileDinhKem))
                {
                    unlink("public/upload/".$tintuc->FileDinhKem);
                }
            }
            
            $tintuc->delete($id);
            return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']); 
        }
        
    }

    public function postXoaChon(Request $request)
    {
        $data = $request->checkbox_array;
        if(count($data))
        {
            foreach($data as $key => $value)
            {
                $tintuc = TinTucModel::where('id',$value)->first();
                if($tintuc->HinhAnh !="" )
                {
                    if(file_exists("public/upload/".$tintuc->HinhAnh))
                    {
                        unlink("public/upload/".$tintuc->HinhAnh);
                    }
                }
                if($tintuc->FileDinhKem !="" )
                {
                    if(file_exists("public/upload/".$tintuc->FileDinhKem))
                    {
                        unlink("public/upload/".$tintuc->FileDinhKem);
                    }
                }
                $tintuc->delete($value);
            }
            return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa chọn thành công']);
        }
       else 
           return redirect()->route('admin.tintuc.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không có phần tử được chọn để xóa?']);
    }
}
