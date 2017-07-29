<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class CauHinh extends Model
{
    protected $table = "tbl_cauhinh";
    protected $fillable=['GioiThieuCongTy','GioiThieuNhaHangCaFe','GioiThieuCongVienNuoc','Icon'.'Title','Logo','ThongTin','Email','TrangThai'];
}
