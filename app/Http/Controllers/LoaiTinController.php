<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\LoaiTinModel;
use App\NhomLoaiTinModel;
use App\Http\Requests\loaiTinRequest;
use App\Http\Requests\NhomloaiTinRequest;
use App\TinTucModel;

class LoaiTinController extends Controller
{
     public function getDanhSach()
    {
        $loaitin     = LoaiTinModel::orderBy('id','DESC')->get();
        $nhomloaitin = NhomLoaiTinModel::all();
    	return view('admin.loaitin.danhsach',compact('loaitin','nhomloaitin'));
    }
    
    public function postThem(loaiTinRequest $request)
    {
        
        $loaitin                = new LoaiTinModel;
        $loaitin->TenLoai    = trim($request->TenLoai);
        $loaitin->TenKhongGiau  = changeTitle(trim($request->TenLoai));
        $loaitin->IDNhomLoaiTin = $request->IDNhomLoaiTin;
        $loaitin->save();
        return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getSua($id)
    {   
        if(isset($id) == LoaiTinModel::find($id))
        {
            $loaitin     = LoaiTinModel::find($id);
            $nhomloaitin = NhomLoaiTinModel::all();
            return view('admin.loaitin.sua',compact('loaitin','nhomloaitin'));
        }
        return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
        
    }

    public function postSua(loaiTinRequest $request,$id)
    {
        if(isset($id) == LoaiTinModel::find($id))
        {
            $loaitin                = LoaiTinModel::find($id);
            $loaitin->TenLoai       = trim($request->TenLoai);
            $loaitin->TenKhongGiau  = changeTitle(trim($request->TenLoai));
            $loaitin->IDNhomLoaiTin = $request->IDNhomLoaiTin;
            $loaitin->save();
            return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
       
    }

    public function getXoa($id)
    {
        if(isset($id) == LoaiTinModel::find($id))
        {
            $tintuc = TinTucModel::where('IDLoaiTin',$id)->count();
            if($tintuc == 0)
            {
                LoaiTinModel::where('id',$id)->delete();
                return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
            }
            else
            {
                return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vì có tin tức thuộc loại tin này ?']); 
            }
            
        }
        return redirect()->route('admin.loaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);  
    }
}
