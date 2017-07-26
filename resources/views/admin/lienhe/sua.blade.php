@extends('admin.layout.index')
@section('title')| Liên hệ | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật nội dung
        <small>Liên hệ</small>
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
                   <label>Tiêu đề</label>
                   <textarea id="demo" class=" form-control ckeditor" name="NoiDungLienHe" rows="10">{!! $lienhe->NoiDungLienHe !!}</textarea>
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