<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class NhomLoaiTinModel extends Model
{
    protected $table = "nhomloaitin";
    protected $fillable=['TenNhom','TenKhongGiau'];
}
