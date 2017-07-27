<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class cafe_DanhMuc extends Model
{
    protected $table = "cafe_danhmuc";
    protected $fillable=['tendanhmuc','tendanhmuckhongdau'];
}
