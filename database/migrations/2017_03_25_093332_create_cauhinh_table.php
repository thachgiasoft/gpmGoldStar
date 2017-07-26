<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateCauhinhTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('cauhinh', function (Blueprint $table) {
            $table->increments('id');
            $table->string('Icon')->nullable();
            $table->string('Title')->nullable();
            $table->string('Logo')->nullable();
            $table->string('Banner')->nullable();
           // $table->longText('ThongTin')->nullable();
            $table->string('BanQuyen')->nullable();
            $table->string('LinkBanQuyen')->nullable();
            $table->string('ThietKe')->nullable();
            $table->string('Version')->nullable();
            $table->string('EmailLienHe')->nullable();
            $table->integer('BaoTriWebsite')->default(0);// 1 bảo trì website, 0 là hoạt động
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
        Schema::dropIfExists('cauhinh');
    }
}
