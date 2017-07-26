<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- CSRF Token -->
    <meta name="csrf-token" content="{{ csrf_token() }}">
    <title>Khôi phục tài khoản</title>
    <base href="{{asset('')}}">
    <!-- Styles -->
    <link href="public/admin_asset/css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="public/admin_asset/bower_components/metisMenu/dist/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="public/admin_asset/css/sb-admin-2.css" rel="stylesheet">
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
    <!-- Custom Fonts -->
    <link href="public/admin_asset/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- Scripts -->
    <script>
        window.Laravel = <?php echo json_encode([
            'csrfToken' => csrf_token(),
        ]); ?>
    </script>
</head>
<body class="hold-transition login-page">
  <div class="login-box">
    <div id="app">
        @yield('content')
    </div>
    <!-- Scripts -->
    <script src="public/js/app.js"></script>
  </div>
</body>
</html>
