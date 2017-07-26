<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Trang quản trị @yield('title')</title>
  <!-- Tell the browser to be responsive to screen width -->
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
<!-- ADD THE CLASS fixed TO GET A FIXED HEADER AND SIDEBAR LAYOUT -->
<!-- the fixed layout is not compatible with sidebar-mini -->
<body class="hold-transition skin-blue fixed sidebar-mini">
<!-- Site wrapper -->
<div class="wrapper">

  <header class="main-header">
    @include('admin.layout.header')
  </header>
  <!-- =============================================== -->
  <!-- Left side column. contains the sidebar -->
  @include('admin.layout.menu')
  <!-- =============================================== -->
  <!-- Content Wrapper. Contains page content -->
  @yield('content')
  <!-- /.content-wrapper -->
  @include('admin.layout.footer')

  <div class="control-sidebar-bg"></div>
</div>
<!-- ./wrapper -->

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
<!-- DataTables -->
<script src="public/admin_asset/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="public/admin_asset/plugins/datatables/dataTables.bootstrap.min.js"></script>
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>

<!--My Script-->
<script src="{!! url('public/admin_asset/js/myscript.js') !!}"></script>
<script type="text/javascript" language="javascript" src="{!! url('public/admin_asset/ckeditor/ckeditor.js') !!}" ></script>
@yield('script')

</body>
</html>
