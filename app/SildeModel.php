<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class SildeModel extends Model
{
    protected $table = "slide";
    protected $fillable=['Ten','Hinh','NoiDung','TrangThai'];
}
