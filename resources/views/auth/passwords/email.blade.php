@extends('layouts.app')

<!-- Main Content -->
@section('content')
<div class="login-box-body">
   <p class="login-box-msg"><b>Khôi phục mật khẩu</b></p>           
    @if (session('status'))
        <div class="alert alert-success">
            {{ session('status') }}
        </div>
    @endif
    <form class="form-horizontal" role="form" method="POST" action="{{ url('/password/email') }}">
        {{ csrf_field() }}

        <div class="form-group{{ $errors->has('email') ? ' has-error' : '' }}">
            <div class="form-group has-feedback">
                <input  id="email" type="email" class="form-control" value="{{ old('email') }}" name="email" placeholder="Nhập email khôi phục" style="width: 340px; margin-left:20px ">
                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
            </div>
            @if ($errors->has('email'))
                <span class="help-block">
                    <strong>{{ $errors->first('email') }}</strong>
                </span>
            @endif
        </div>
        <div class="social-auth-links text-center">
            <button type="submit" class="btn btn-primary">
                Khôi phục mật khẩu
            </button>
          <p>- Hoặc -</p>
            <a href="admin/login" title="Quên mật khẩu">Quay lại đăng nhập</a>
        </div>
    </form>
</div>
@endsection