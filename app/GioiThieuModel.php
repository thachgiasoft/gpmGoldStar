<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class GioiThieuModel extends Model
{
    protected $table = "gioithieu";
    protected $fillable=['ChucNangNhiemVu','CoCauToChuc','NhanSu','LienHe','ThongTin'];
}
