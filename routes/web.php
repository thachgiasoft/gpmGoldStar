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

Route::get('goldstar-admin', function () {
    return view('admin.layout.index');
});
Route::group(['prefix'=>'goldstar-admin'],function(){
	Route::group(['prefix'=>'congviennuoc'],function(){
		Route::group(['prefix'=>'ql'],function(){
			Route::get('danh-sach',['as'=>'goldstar-admin.nhomloaitin.danhsach','uses'=>'NguoiDungController@getDanhSach']);
			Route::post('them',['as'=>'goldstar-admin.nhomloaitin.postthem','uses'=>'NguoiDungController@postThem']);
			Route::get('sua/{id}',['as'=>'admin.nhomloaitin.getsua','uses'=>'NguoiDungController@getSua']);
			Route::post('sua/{id}',['as'=>'admin.nhomloaitin.postsua','uses'=>'NguoiDungController@postSua']);
			Route::get('xoa/{id}',['as'=>'admin.nhomloaitin.getxoa','uses'=>'NguoiDungController@getXoa']);
		});



	});

	Route::group(['prefix'=>'cafe'],function(){




	});
	Route::group(['prefix'=>'nhahang'],function(){




	});
	Route::group(['prefix'=>'qlnguoidung'],function(){
		Route::get('danh-sach',['as'=>'goldstar-admin.qlnguoidung.danhsach','uses'=>'NguoiDungController@getDanhSach']);
		Route::post('them',['as'=>'goldstar-admin.qlnguoidung.postthem','uses'=>'NguoiDungController@postThem']);
		Route::get('sua/{id}',['as'=>'goldstar-admin.qlnguoidung.getsua','uses'=>'NguoiDungController@getSua']);
		Route::post('sua/{id}',['as'=>'goldstar-admin.qlnguoidung.postsua','uses'=>'NguoiDungController@postSua']);
		Route::get('xoa/{id}',['as'=>'goldstar-admin.qlnguoidung.getxoa','uses'=>'NguoiDungController@getXoa']);
	});

});
Auth::routes();