<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class CauHinhModel extends Model
{
    protected $table = "cauhinh";
    protected $fillable=['Icon','Title','Logo','Banner','BanQuyen','LinkBanQuyen','ThietKe','Version','EmailLienHe','BaoTriWebsite'];
}
