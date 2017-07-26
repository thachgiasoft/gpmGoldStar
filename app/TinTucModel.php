<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class TinTucModel extends Model
{
    protected $table = "tintuc";
    protected $fillable=['TieuDe','TieuDeKhongDau','TomTat','NoiDung','HinhAnh','NoiBat','SoLuotXem','FileDinhKem','IDLoaiTin'];
    public function loaitin()
    {
        return $this->belongsTo('App\LoaiTinModel','IDLoaiTin','id'); 
    }
}
