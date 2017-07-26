<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateGioithieuTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('gioithieu', function (Blueprint $table) {
            $table->increments('id');
            $table->longText('ChucNangNhiemVu')->nullable();
            $table->longText('CoCauToChuc')->nullable();
            $table->longText('NhanSu')->nullable();
            $table->longText('LienHe')->nullable();
            $table->longText('ThongTin')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('gioithieu');
    }
}
