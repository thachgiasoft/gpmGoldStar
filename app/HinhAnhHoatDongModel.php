<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class HinhAnhHoatDongModel extends Model
{
   	protected $table = "hinhanhhoatdong";
    protected $fillable=['TenAnh','HinhAnh'];
}
