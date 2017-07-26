<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class MailModel extends Model
{
    protected $table = "mail";
    protected $fillable=['Email'];
}
