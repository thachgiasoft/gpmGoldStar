<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\MailModel;
class MailController extends Controller
{
    public function getDanhSach()
    {
    	$mail = MailModel::all();
    	return view('admin.mail.danhsach',compact('mail'));
    }

    public function getXoa($id)
    {
    	$mail = MailModel::find($id);
    	$mail->delete();
    	return redirect()->route('admin.mail.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa thành công']);
    }

    public function postXoaChon(Request $request)
    {
    	$data = $request->checkbox_array;
        if(count($data))
        {
            foreach($data as $key => $value)
            {
                MailModel::find($value)->delete();
            }
            return redirect()->route('admin.mail.danhsach')->with(['thongbao_level'=>'success','thongbao'=>'Xóa chọn thành công']);
        }
       else 
           return redirect()->route('admin.mail.danhsach')->with(['thongbao_level'=>'danger','thongbao'=>'Không có phần tử được chọn để xóa?']);
    }
}
