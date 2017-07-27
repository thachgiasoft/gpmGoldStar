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

Route::group(['prefix'=>'goldstar-admin'],function(){

	Route::group(['prefix'=>'congviennuoc'],function(){
		Route::group(['prefix'=>'ql'],function(){
			Route::get('danh-sach',['as'=>'goldstar-admin.nhomloaitin.danhsach','uses'=>'NhomLoaiTinController@getDanhSach']);
			Route::post('them',['as'=>'goldstar-admin.nhomloaitin.postthem','uses'=>'NhomLoaiTinController@postThem']);
			Route::get('sua/{id}',['as'=>'admin.nhomloaitin.getsua','uses'=>'NhomLoaiTinController@getSua']);
			Route::post('sua/{id}',['as'=>'admin.nhomloaitin.postsua','uses'=>'NhomLoaiTinController@postSua']);
			Route::get('xoa/{id}',['as'=>'admin.nhomloaitin.getxoa','uses'=>'NhomLoaiTinController@getXoa']);
		});



	});

	Route::group(['prefix'=>'cafe'],function(){




	});
	Route::group(['prefix'=>'nhahang'],function(){




	});
});
Auth::routes();