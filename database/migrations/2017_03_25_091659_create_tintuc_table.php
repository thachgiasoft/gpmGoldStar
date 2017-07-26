<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateTintucTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('tintuc', function (Blueprint $table) {
            $table->increments('id');
            $table->string('TieuDe');
            $table->string('TieuDeKhongDau')->nullable();
            $table->text('TomTat')->nullable();
            $table->longText('NoiDung')->nullable();
            $table->string('HinhAnh')->nullable();
            $table->integer('NoiBat')->default(0);
            $table->integer('SoLuotXem')->default(0);
            $table->string('FileDinhKem')->nullable();
            $table->integer('IDLoaiTin')->unsigned();
            $table->foreign('IDLoaiTin')->references('id')->on('loaitin');
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
        Schema::dropIfExists('tintuc');
    }
}
