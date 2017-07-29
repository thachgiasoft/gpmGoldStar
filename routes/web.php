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
		//quản lý danh mục
		Route::group(['prefix'=>'qldanhmuc'],function(){
			Route::get('danh-sach',['as'=>'goldstar-admin.cafe.qldanhmuc.danhsach','uses'=>'cafe_DanhMucController@getDanhSach']);
			Route::post('them',['as'=>'goldstar-admin.cafe.qldanhmuc.postthem','uses'=>'cafe_DanhMucController@postThem']);
			Route::get('sua/{id}',['as'=>'goldstar-admin.cafe.qldanhmuc.getsua','uses'=>'cafe_DanhMucController@getSua']);
			Route::post('sua/{id}',['as'=>'goldstar-admin.cafe.qldanhmuc.postsua','uses'=>'cafe_DanhMucController@postSua']);
			Route::get('xoa/{id}',['as'=>'goldstar-admin.cafe.qldanhmuc.getxoa','uses'=>'cafe_DanhMucController@getXoa']);
		});

		Route::group(['prefix'=>'qlsanpham'],function(){
			Route::get('danh-sach',['as'=>'goldstar-admin.cafe.qlsanpham.danhsach','uses'=>'cafe_DanhMucController@getDanhSach']);
			Route::post('them',['as'=>'goldstar-admin.cafe.qlsanpham.postthem','uses'=>'cafe_DanhMucController@postThem']);
			Route::get('sua/{id}',['as'=>'goldstar-admin.cafe.qlsanpham.getsua','uses'=>'cafe_DanhMucController@getSua']);
			Route::post('sua/{id}',['as'=>'goldstar-admin.cafe.qlsanpham.postsua','uses'=>'cafe_DanhMucController@postSua']);
			Route::get('xoa/{id}',['as'=>'goldstar-admin.cafe.qlsanpham.getxoa','uses'=>'cafe_DanhMucController@getXoa']);
		});


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
	Route::group(['prefix'=>'qlslide'],function(){
		Route::get('danh-sach',['as'=>'goldstar-admin.qlslide.danhsach','uses'=>'SlideController@getDanhSach']);
		Route::post('them',['as'=>'goldstar-admin.qlslide.postthem','uses'=>'SlideController@postThem']);
		Route::get('sua/{id}',['as'=>'goldstar-admin.qlslide.getsua','uses'=>'SlideController@getSua']);
		Route::post('sua/{id}',['as'=>'goldstar-admin.qlslide.postsua','uses'=>'SlideController@postSua']);
		Route::get('xoa/{id}',['as'=>'goldstar-admin.qlslide.getxoa','uses'=>'SlideController@getXoa']);
	});
	Route::group(['prefix'=>'qlcauhinh'],function(){
		Route::get('gioi-thieu-cong-ty',['as'=>'goldstar-admin.qlcauhinh.gioithieucongty','uses'=>'CauHinhController@getGioiThieuCongTy']);
		Route::post('gioi-thieu-cong-ty',['as'=>'goldstar-admin.qlcauhinh.postgioithieucongty','uses'=>'CauHinhController@postGioiThieuCongTy']);
		
		Route::get('gioi-thieu-cong-vien-nuoc',['as'=>'goldstar-admin.qlcauhinh.gioithieucongviennuoc','uses'=>'CauHinhController@getGioiThieuCongVienNuoc']);
		Route::post('gioi-thieu-cong-vien-nuoc',['as'=>'goldstar-admin.qlcauhinh.postgioithieucongviennuoc','uses'=>'CauHinhController@postGioiThieuCongVienNuoc']);

		Route::get('gioi-thieu-nha-hang-cafe',['as'=>'goldstar-admin.qlcauhinh.gioithieunhahangcf','uses'=>'CauHinhController@getGioiThieuNhaHangCF']);
		Route::post('gioi-thieu-nha-hang-cafe',['as'=>'goldstar-admin.qlcauhinh.postgioithieunhahangcf','uses'=>'CauHinhController@postGioiThieuNhaHangCF']);

		Route::get('cau-hinh-he-thong',['as'=>'goldstar-admin.qlcauhinh.cauhinhhethong','uses'=>'CauHinhController@getCauHinhHeThong']);
		Route::post('cau-hinh-he-thong',['as'=>'goldstar-admin.qlcauhinh.postcauhinhhethong','uses'=>'CauHinhController@postCauHinhHeThong']);
	});

});
Auth::routes();