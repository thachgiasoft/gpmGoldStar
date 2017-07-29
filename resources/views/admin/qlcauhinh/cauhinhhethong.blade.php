@extends('admin.layout.index')
@section('title')| Cấu hình hệ thống @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cấu hình hệ thống
      </h1>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Cập nhật</h3>
            </div>
            @include('admin.layout.thongbao')
            <form role="form" action="" method="post" enctype="multipart/form-data">
             <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                  <div class="form-group">
                    <label for="exampleInputPassword1">Title</label>
                    <input type="text" class="form-control" name="Title" value="{!! old('Title',isset($cauhinh) ? $cauhinh->Title : null) !!}">
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Email</label>
                    <input type="email" class="form-control" name="Email" value="{!! old('Email',isset($cauhinh) ? $cauhinh->Email : null) !!}">
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Điện thoại</label>
                    <input type="text" class="form-control" name="DienThoai" value="{!! old('DienThoai',isset($cauhinh) ? $cauhinh->DienThoai : null) !!}">
                  </div>
                  <div class="form-group">
                   <label>Liên hệ</label>
                   <textarea id="demo" class=" form-control ckeditor" name="ThongTin" rows="10">{!! $cauhinh->ThongTin !!}</textarea>
                  </div>
                  <div class="form-group">
                    <label >Trạng thái hoạt động</label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="radio" name="TrangThai" value="1" @if($cauhinh->TrangThai == 1) {!! "checked" !!} @endif> Hoạt động Hệ thống&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="radio" name="TrangThai" value="1" @if($cauhinh->TrangThai == 0) {!! "checked" !!} @endif> Bảo trì Hệ thống
                    </label>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Icon</label>
                    <input type="file"  name="Icon">
                    <img src="public/upload/user/{!! $cauhinh->Icon  !!}" alt="" width="50px" height="50px">
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Logo</label>
                    <input type="file"  name="Logo">
                    <img src="public/upload/user/{!! $cauhinh->Logo  !!}" alt="" width="400px" height="100px">
                  </div>
                </div>
                  <div class="box-footer">
                    <button type="submit" class="btn btn-primary">Cập nhật</button>
                    <button type="reset" class="btn btn-danger">Làm lại</button>
                  </div>
                </form>
            </div>
        </div>
        </div>
    </section>
</div>
@endsection