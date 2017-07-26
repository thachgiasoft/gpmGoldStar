@extends('admin.layout.index')
@section('title')| Người dùng | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật
        <small>{!! $user->name !!}</small>
      </h1>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Cập nhật người dùng hệ thống</h3>
            </div>

            @include('admin.layout.thongbao')
            <form role="form" action="" method="post" enctype="multipart/form-data">
              <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                    <div class="form-group">
                      <label for="exampleInputPassword1">Tên người dùng</label>
                      <input class="form-control" placeholder="Nhập tên người quản trị" type="text" name="name" value="{!! old('name',isset($user) ? $user->name : null) !!}">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">E-Mail</label>
                      <input class="form-control" placeholder="Nhập E-Mail người quản trị" type="email" name="email" value="{!! old('email',isset($user) ? $user->email : null) !!}">
                    </div>
                    <div class="form-group">
                      <input type="checkbox" id="changePassword" name ="changePassword">
                      <label>Thay đổi mật khẩu</label>
                      <input type="password" class="form-control password"  placeholder="Nhập mật khẩu củ" name="passwordcu" disabled="">
                    </div>
                    <div class="form-group">
                      <label>Nhập mật khẩu mới</label>
                      <input type="password" class="form-control password"  placeholder="Nhập mật khẩu mới" name="password" disabled="">
                    </div>
                    <div class="form-group">
                      <label>Nhập lại mật khẩu</label>
                      <input type="password" class="form-control password"  placeholder="Nhập lại mật khẩu mới" name="passwordagain" disabled="">
                    </div>
                    
                    <div class="form-group">
                      <label>Level &nbsp;&nbsp;&nbsp;&nbsp;</label>
                      <label class="radio-inline">
                          <input type="radio" name="level" value="0"
                          @if($user->level == 0)
                            checked
                          @endif
                          >Người dùng
                      </label>
                      <label class="radio-inline">
                          <input type="radio" name="level" value="1" 
                          @if($user->level == 1)
                            checked
                          @endif>Admin
                      </label>
                    </div>
                    <div class="form-group">
                      <label>Ảnh đại diện</label>
                      <input type="file" placeholder="Ảnh đại diện" name="hinhanh">
                      <img @if($user->hinhanh !="") src="public/upload/{!! old('hinhanh',isset($user) ? $user->hinhanh : null) !!}" @elseif($user->hinhanh =="") src="public/upload/item.gif"  @endif class="img-circle" alt="User Image" width="100px" height="100px" style="margin-left:200px;  ">
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
@section('script')
  <script>
    $(document).ready(function(){
      $("#changePassword").change(function(){
        if($(this).is(":checked"))
        {
            $(".password").removeAttr('disabled');
        }
        else
        {
            $(".password").attr('disabled','');
        }
      });
    });
  </script>
@endsection