<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Slide extends Model
{
    protected $table = "tbl_slide";
    protected $fillable=['TieuDe','Link','HinhAnh'];
}
