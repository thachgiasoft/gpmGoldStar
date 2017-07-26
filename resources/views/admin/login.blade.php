<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AGU | Log in</title>
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!--Tránh nhầm đường dẫn css-->
  <base href="{{asset('')}}">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="public/admin_asset/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="public/admin_asset/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="public/admin_asset/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="public/admin_asset/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="public/admin_asset/css/skins/_all-skins.min.css">
  <link rel="stylesheet" href="public/admin_asset/plugins/datatables/dataTables.bootstrap.css">
  <!-- bootstrap wysihtml5 - text editor -->
  <link rel="stylesheet" href="public/admin_asset/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">

  <link rel="stylesheet" href="public/admin_asset/plugins/datatables/dataTables.bootstrap.css">
  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-box-body">
    <p class="login-box-msg"><b>Đăng nhập hệ thống</b></p>
     @if(count($errors)> 0)
      <div class="alert alert-danger">
        @foreach($errors->all() as $err)
          {{$err}} <br>
        @endforeach
      </div>
    @endif

    @if(session('thongbao'))
      <div class="alert alert-danger"">
        {{session('thongbao')}}
      </div>
    @endif
    <form action="admin/login" method="post">
    <input type="hidden" name="_token" value="{{csrf_token()}}" />
      <div class="form-group has-feedback">
        <input type="email" class="form-control" name="email" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" class="form-control" name="password" placeholder="Mật khẩu">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
          <button type="submit" class="btn btn-primary btn-block btn-flat" style="float: right;">Đăng nhập</button>
      </div>
    </form>

    <div class="social-auth-links text-center">
      <p>- Hoặc -</p>
        <a href="{{ url('/password/reset') }}">Quên mật khẩu</a><br>
    </div>
  </div>
  <!-- /.login-box-body -->
</div>
<!-- jQuery 2.2.3 -->
<script src="public/admin_asset/plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="public/admin_asset/js/bootstrap.min.js"></script>
<!-- SlimScroll -->
<script src="public/admin_asset/plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="public/admin_asset/plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="public/admin_asset/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="public/admin_asset/js/demo.js"></script>

</body>
</html>
