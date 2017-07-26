@extends('admin.layout.index')
@section('title')| Silde sinh viên tiêu biểu | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật sinh viên tiêu biểu
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
                      <label>Tên sinh viên</label>
                      <input class="form-control" value="{!! $silde->Ten !!}" type="text" name="TenHinh">
                    </div>

                    <div class="form-group">
                      <label>Hình ảnh</label>
                      <input type="file" name="Hinh">
                      <img src="public/upload/{!! $silde->Hinh !!}" alt="HTML" width="300px"
                      height="400px">
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