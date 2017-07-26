<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateHinhanhhoatdongTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('hinhanhhoatdong', function (Blueprint $table) {
            $table->increments('id');
            $table->string('TenAnh')->nullable();
            $table->string('HinhAnh')->nullable();
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
        Schema::dropIfExists('hinhanhhoatdong');
    }
}
