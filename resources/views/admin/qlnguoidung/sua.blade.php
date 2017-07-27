@extends('admin.layout.index')
@section('title')| Tài khoản | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật tài khoản
        <small>{!! $user->name !!}</small>
      </h1>
     <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary">
          <a href="{!! route('goldstar-admin.qlnguoidung.danhsach') !!}"><i class="glyphicon glyphicon-list" style="color: white;"></i><b style="color: white;"> Danh sách</b></a>
        </li>
      </ol>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Cập nhật tài khoản</h3>
            </div>
            @include('admin.layout.thongbao')
            <form role="form" action="" method="post" enctype="multipart/form-data">
             <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                 <div class="form-group">
                      <label for="exampleInputPassword1">Tên người quản trị</label>
                      <input class="form-control" placeholder="Nhập tên người quản trị" type="text" name="name" value="{!! old('name',isset($user) ? $user->name : null) !!}">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">E-Mail</label>
                      <input class="form-control" placeholder="Nhập E-Mail người quản trị" type="email" name="email" value="{!! old('email',isset($user) ? $user->email : null) !!}" >
                    </div>
                    <div class="form-group">
                      <input type="checkbox" id="changePassword" name ="changePassword">
                      <label for="exampleInputPassword1">Thay đổi mật khẩu</label>
                      <input type="password" class="form-control password" id="exampleInputPassword1" placeholder="Nhập mật khẩu mới" name="password" disabled="">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Nhập lại mật khẩu</label>
                      <input type="password" class="form-control password" id="exampleInputPassword1" placeholder="Nhập lại mật khẩu mới" name="passwordagain" disabled="">
                    </div>
                    
                    <div class="form-group">
                      <label for="exampleInputPassword1">Ảnh đại diện</label>
                      <input type="file"  id="exampleInputPassword1" placeholder="Ảnh đại diện" name="hinhanh">
                      <img @if($user->hinhanh !="") src="public/upload/user/{!! old('hinhanh',isset($user) ? $user->hinhanh : null) !!}" @elseif($user->hinhanh =="") src="public/upload/user/1866.jpg"  @endif class="img-circle" alt="User Image" width="100px" height="100px" style="margin-left:200px;  ">
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