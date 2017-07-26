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

// Route::get('/admin', function () {
//     return view('admin.layout.content');
// });

//Nhóm admin
Route::group(['prefix'=>'admin','middleware'=>'PhanQuyen'],function(){
	//nhóm thể loại
	Route::group(['prefix'=>'nhomloaitin'],function(){
		Route::get('danhsach',['as'=>'admin.nhomloaitin.danhsach','uses'=>'NhomLoaiTinController@getDanhSach']);
		Route::post('them',['as'=>'admin.nhomloaitin.postthem','uses'=>'NhomLoaiTinController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.nhomloaitin.getsua','uses'=>'NhomLoaiTinController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.nhomloaitin.postsua','uses'=>'NhomLoaiTinController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.nhomloaitin.getxoa','uses'=>'NhomLoaiTinController@getXoa']);
	});

	Route::group(['prefix'=>'anhhoatdong'],function(){
		Route::get('danhsach',['as'=>'admin.anhhoatdong.danhsach','uses'=>'HinhAnHoatDongController@getDanhSach']);
		Route::post('them',['as'=>'admin.anhhoatdong.postthem','uses'=>'HinhAnHoatDongController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.anhhoatdong.getsua','uses'=>'HinhAnHoatDongController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.anhhoatdong.postsua','uses'=>'HinhAnHoatDongController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.anhhoatdong.getxoa','uses'=>'HinhAnHoatDongController@getXoa']);
	});
	//nhóm loại tin
	Route::group(['prefix'=>'loaitin'],function(){
		Route::get('danhsach',['as'=>'admin.loaitin.danhsach','uses'=>'LoaiTinController@getDanhSach']);
		Route::post('them',['as'=>'admin.loaitin.postthem','uses'=>'LoaiTinController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.loaitin.getsua','uses'=>'LoaiTinController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.loaitin.postsua','uses'=>'LoaiTinController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.loaitin.getxoa','uses'=>'LoaiTinController@getXoa']);
	});

	//nhóm tin tức
	Route::group(['prefix'=>'tintuc'],function(){
		Route::get('danhsach',['as'=>'admin.tintuc.danhsach','uses'=>'TinTucController@getDanhSach']);
		Route::get('them',['as'=>'admin.tintuc.getthem','uses'=>'TinTucController@getThem']);
		Route::post('them',['as'=>'admin.tintuc.postthem','uses'=>'TinTucController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.tintuc.getsua','uses'=>'TinTucController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.tintuc.postsua','uses'=>'TinTucController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.tintuc.getxoa','uses'=>'TinTucController@getXoa']);
		Route::get('ajax/{IDTheLoai}','TinTucController@getDanhSachLoaiTin');
		Route::post('xoachon',['as'=>'admin.tintuc.postxoachon','uses'=>'TinTucController@postXoaChon']);
	});

	//cấu hình
	Route::group(['prefix'=>'cauhinh'],function(){
		Route::get('sua/{id}',['as'=>'admin.cauhinh.getsua','uses'=>'CauHinhController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.cauhinh.postsua','uses'=>'CauHinhController@postSua']);

		Route::get('baotri/{id}',['as'=>'admin.cauhinh.getbaotri','uses'=>'CauHinhController@getBaoTri']);
		Route::post('baotri/{id}',['as'=>'admin.cauhinh.postbaotri','uses'=>'CauHinhController@postBaoTri']);
	});

	//giới thiệu
	Route::group(['prefix'=>'gioithieu'],function(){
		Route::get('suacnnv/{id}',['as'=>'admin.gioithieu.getsuacnnv','uses'=>'GioiThieuController@getSuaCNNV']);
		Route::post('suacnnv/{id}',['as'=>'admin.gioithieu.postsuacnnv','uses'=>'GioiThieuController@postSuaCNNV']);

		Route::get('suacctc/{id}',['as'=>'admin.gioithieu.getsuacctc','uses'=>'GioiThieuController@getSuaCCTC']);
		Route::post('suacctc/{id}',['as'=>'admin.gioithieu.postsuacctc','uses'=>'GioiThieuController@postSuaCCTC']);
	
		Route::get('suanhansu/{id}',['as'=>'admin.gioithieu.getsuanhansu','uses'=>'GioiThieuController@getSuaNhanSu']);
		Route::post('suanhansu/{id}',['as'=>'admin.gioithieu.postsuanhansu','uses'=>'GioiThieuController@postSuaNhanSu']);

		Route::get('sualienhe/{id}',['as'=>'admin.gioithieu.getsualienhe','uses'=>'GioiThieuController@getSuaLienHe']);
		Route::post('sualienhe/{id}',['as'=>'admin.gioithieu.postsualienhe','uses'=>'GioiThieuController@postSuaLienHe']);

		Route::get('suathongtin/{id}',['as'=>'admin.gioithieu.getsuathongtin','uses'=>'GioiThieuController@getSuaThongTin']);
		Route::post('suathongtin/{id}',['as'=>'admin.gioithieu.postsuathongtin','uses'=>'GioiThieuController@postSuaThongTin']);
	});

	//nhóm mail
	Route::group(['prefix'=>'mail'],function(){
		Route::get('danhsach',['as'=>'admin.mail.danhsach','uses'=>'MailController@getDanhSach']);
		Route::get('xoa/{id}',['as'=>'admin.mail.getxoa','uses'=>'MailController@getXoa']);
		Route::post('xoachon',['as'=>'admin.mail.postxoachon','uses'=>'MailController@postXoaChon']);
	});

	//nhóm người dùng
	Route::group(['prefix'=>'nguoidung'],function(){
		Route::get('danhsach',['as'=>'admin.nguoidung.danhsach','uses'=>'NguoiDungController@getDanhSach']);
		Route::post('them',['as'=>'admin.nguoidung.postthem','uses'=>'NguoiDungController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.nguoidung.getsua','uses'=>'NguoiDungController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.nguoidung.postsua','uses'=>'NguoiDungController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.nguoidung.getxoa','uses'=>'NguoiDungController@getXoa']);
	});

	Route::group(['prefix'=>'slide'],function(){
		Route::get('danhsach',['as'=>'admin.slide.danhsach','uses'=>'SildeController@getDanhSach']);
		Route::post('them',['as'=>'admin.slide.postthem','uses'=>'SildeController@postThem']);
		Route::get('sua/{id}',['as'=>'admin.slide.getsua','uses'=>'SildeController@getSua']);
		Route::post('sua/{id}',['as'=>'admin.slide.postsua','uses'=>'SildeController@postSua']);
		Route::get('xoa/{id}',['as'=>'admin.slide.getxoa','uses'=>'SildeController@getXoa']);
	});

	Route::group(['prefix'=>'slidesinhvien'],function(){
		Route::get('danhsach',['as'=>'admin.slidesinhvien.danhsach','uses'=>'SildeController@getDanhSachSinhVien']);
		Route::post('them',['as'=>'admin.slidesinhvien.postthem','uses'=>'SildeController@postThemSinhVien']);
		Route::get('sua/{id}',['as'=>'admin.slidesinhvien.getsua','uses'=>'SildeController@getSuaSinhVien']);
		Route::post('sua/{id}',['as'=>'admin.slidesinhvien.postsua','uses'=>'SildeController@postSuaSinhVien']);
		Route::get('xoa/{id}',['as'=>'admin.slidesinhvien.getxoa','uses'=>'SildeController@getXoaSinhVien']);
	});
});
Route::get('/',['as'=>'trangchu','uses'=>'PageController@getTrangChu']);
Route::get('trangchu.html',['as'=>'trangchu','uses'=>'PageController@getTrangChu']);
Route::get('chucnangnhiemvu.html',['as'=>'trangchu.chucnangnhiemvu','uses'=>'PageController@getChucNangNhiemVu']);
Route::get('cocautochuc.html',['as'=>'trangchu.cocautochuc','uses'=>'PageController@getCoCauToChuc']);
Route::get('nhansu.html',['as'=>'trangchu.nhansu','uses'=>'PageController@getNhanSu']);
Route::post('dangkynhantin',['as'=>'trangchu.dangkynhantin','uses'=>'PageController@postDangKyNhanTin']);
Route::get('tintuc/{id}/{TieuDeKhongGiau}.html',['as'=>'trangchu.tintuc','uses'=>'PageController@getTinTuc']);
Route::get('loaitin/{id}/{TenKhongDau}.html',['as'=>'trangchu.loaitin','uses'=>'PageController@getLoaiTin']);
Route::any('timkiem.html',['as'=>'trangchu.timkiem','uses'=>'PageController@postTimKiem']);
Route::get('silde/{id}/{TieuDe}.html',['as'=>'trangchu.silde','uses'=>'PageController@getSilde']);

Route::get('tintucsukien',['as'=>'trangchu.tintucsukien','uses'=>'PageController@getTinTucSuKien']);
Route::get('tintucsinhvien',['as'=>'trangchu.tintucsinhvien','uses'=>'PageController@getTinTucSinhVien']);
Route::get('hinhanhhoatdong',['as'=>'trangchu.hinhanhhoatdong','uses'=>'PageController@getHinhAnhHoatDong']);


Auth::routes();
Route::get('admin', function () {
    return view('admin.login');
});
Route::get('/home', 'HomeController@index');
Route::get('admin/login/reset', function () {
    return view('admin.reset');
});
Route::post('admin/login/reset','NguoiDungController@postRestPassword');

Route::get('admin/login','NguoiDungController@getDangNhapAdmin');
Route::post('admin/login','NguoiDungController@postDangNhapAdmin');
Route::get('admin/logout','NguoiDungController@getDangXuatAdmin');
