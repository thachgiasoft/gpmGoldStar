@extends('admin.layout.index')
@section('title')| Bảo trì Website | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Bảo trì website
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
                    <label>Trạng thái đăng ký &nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <label class="radio-inline">
                        <input type="radio" name="BaoTriWebsite" value="0" @if($baotri->BaoTriWebsite == 0) {!! "checked" !!} @endif >Bảo trì Website
                    </label>
                    <label class="radio-inline">
                        <input type="radio" name="BaoTriWebsite" value="1" @if($baotri->BaoTriWebsite == 1) {!! "checked" !!} @endif> Hoạt động Website
                    </label>
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