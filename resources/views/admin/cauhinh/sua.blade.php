@extends('admin.layout.index')
@section('title')| Cấu hình Website | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật nội dung
        <small>Cấu hình Website</small>
      </h1>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Cập nhật liên hệ Website</h3>
            </div>
            @include('admin.layout.thongbao')
            <form role="form" action="" method="post" enctype="multipart/form-data">
             <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                  
                  <div class="form-group">
                    <label>Title</label>
                    <input type="text" class="form-control" name="Title" value="{!! old('Title',isset($cauhinh) ? $cauhinh->Title : null) !!}">
                  </div>

                   <div class="form-group">
                    <label>Bản quyền</label>
                    <input type="text" class="form-control" name="BanQuyen" value="{!! old('BanQuyen',isset($cauhinh) ? $cauhinh->BanQuyen : null) !!}">
                  </div>

                  <div class="form-group">
                    <label>Link bản quyền</label>
                    <input type="text" class="form-control"  name="LinkBanQuyen" value="{!! old('LinkBanQuyen',isset($cauhinh) ? $cauhinh->LinkBanQuyen : null) !!}">
                  </div>

                  <div class="form-group">
                    <label>Thiết kết</label>
                    <input type="text" class="form-control"  name="ThietKe" value="{!! old('ThietKe',isset($cauhinh) ? $cauhinh->ThietKe : null) !!}">
                  </div>

                  <div class="form-group">
                    <label>Version</label>
                    <input type="text" class="form-control" name="Version" value="{!! old('Version',isset($cauhinh) ? $cauhinh->Version : null) !!}">
                  </div>

                  <div class="form-group">
                    <label>Email liên hệ</label>
                    <input type="text" class="form-control" name="EmailLienHe" value="{!! old('EmailLienHe',isset($cauhinh) ? $cauhinh->EmailLienHe : null) !!}">
                  </div>

                  <div class="form-group">
                    <label>Icon</label>
                    <input type="file"  name="Icon">
                    <img src="public/upload/{!! $cauhinh->Icon  !!}" alt="" width="50px" height="50px">
                  </div>

                  <div class="form-group">
                    <label>Logo</label>
                    <input type="file"  name="Logo">
                    <img src="public/upload/{!! $cauhinh->Logo  !!}" alt="" width="400px" height="100px">
                  </div>

                  <div class="form-group">
                    <label>Banner</label>
                    <input type="file" name="Banner">
                    <img src="public/upload/{!! $cauhinh->Banner  !!}" alt="" width="700px" height="100px">
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