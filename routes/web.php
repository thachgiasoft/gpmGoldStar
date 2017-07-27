<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| This file is where you may define all of the routes that are handled
| by your application. Just tell Laravel the URIs it should respond
| to using a Closure or controller method. Build something great!
|
*/

//Nhóm admin
Route::group(['prefix'=>'goldstar-admin'],function(){
	//nhóm thể loại
	Route::group(['prefix'=>'nhomloaitin'],function(){
		Route::get('danhsach',['as'=>'goldstar-admin.nhomloaitin.danhsach','uses'=>'NhomLoaiTinController@getDanhSach']);
		Route::post('them',['as'=>'goldstar-admin.nhomloaitin.postthem','uses'=>'NhomLoaiTinController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.nhomloaitin.getsua','uses'=>'NhomLoaiTinController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.nhomloaitin.postsua','uses'=>'NhomLoaiTinController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.nhomloaitin.getxoa','uses'=>'NhomLoaiTinController@getXoa']);
	});

});
Auth::routes();