<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\NhomLoaiTinModel;
use App\LoaiTinModel;
use App\Http\Requests\NhomloaiTinRequest;
class NhomLoaiTinController extends Controller
{
    public function getDanhSach()
    {
        $nhomloaitin = NhomLoaiTinModel::orderBy('id','DESC')->get();
        return view('admin.nhomloaitin.danhsach',compact('nhomloaitin'));
    }
    public function postThem(NhomloaiTinRequest $request)
    {
        
        $nhomloaitin          = new NhomLoaiTinModel;
        $nhomloaitin->TenNhom = trim($request->TenNhom);
        $nhomloaitin->TenKhongGiau = changeTitle($request->TenNhom);
        $nhomloaitin->save();
        return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Thêm thành công']);
    }

    public function getSua($id)
    {   
        if(isset($id) == NhomLoaiTinModel::find($id))
        {
            $nhomloaitin = NhomLoaiTinModel::find($id);
            return view('admin.nhomloaitin.sua',compact('nhomloaitin'));
        }
        return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
        
    }

    public function postSua(NhomloaiTinRequest $request,$id)
    {
        if(isset($id) == NhomLoaiTinModel::find($id))
        {
            $nhomloaitin          = NhomLoaiTinModel::find($id);
            $nhomloaitin->TenNhom = trim($request->TenNhom);
            $nhomloaitin->TenKhongGiau = changeTitle($request->TenNhom);
            $nhomloaitin->save();
            return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Cập nhật thành công']);
        }
        return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Cập nhật? Vui lòng liên hệ ban quản trị Website?']);
       
    }

    public function getXoa($id)
    {
        if(isset($id) == NhomLoaiTinModel::find($id))
        {
            $loaitin = LoaiTinModel::where('IDNhomLoaiTin',$id)->count();
            if($loaitin == 0)
            {
                NhomLoaiTinModel::where('id',$id)->delete();
                return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
            }
            else
            {
                return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vì đã có loại tin thuộc nhóm này?']);  
            }
            
        }
        return redirect()->route('admin.nhomloaitin.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không thể Xóa? Vui lòng liên hệ ban quản trị Website?']);  
    }
}
