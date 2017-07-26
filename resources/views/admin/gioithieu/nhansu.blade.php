@extends('admin.layout.index')
@section('title')| Chức năng nhân sự | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật chức năng nhân sự
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
                   <label>Thông tin nhân sự</label>
                   <textarea id="demo" class=" form-control ckeditor" name="NhanSu" rows="10">{!! $nhansu->NhanSu !!}</textarea>
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