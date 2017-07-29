<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class TblCauhinhTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('tbl_cauhinh', function (Blueprint $table) {
            $table->increments('id');
            $table->LongText('GioiThieuCongTy')->nullable();
            $table->LongText('GioiThieuNhaHangCaFe')->nullable();
            $table->LongText('GioiThieuCongVienNuoc')->nullable();
            $table->string('Icon')->nullable();
            $table->string('DienThoai')->nullable();
            $table->string('Title')->nullable();
            $table->string('Logo')->nullable();
            $table->LongText('ThongTin')->nullable();
            $table->string('Email')->nullable();
            $table->integer('TrangThai')->default(0);// 1 bảo trì website
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
        Schema::dropIfExists('tbl_cauhinh');
    }
}
