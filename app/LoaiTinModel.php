<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class LoaiTinModel extends Model
{
    protected $table = "loaitin";
    protected $fillable=['TenLoai','TenKhongGiau','IDNhomLoaiTin'];
    public function nhomloaitin()
    {
        return $this->belongsTo('App\NhomLoaiTinModel','IDNhomLoaiTin','id'); 
    }
}
