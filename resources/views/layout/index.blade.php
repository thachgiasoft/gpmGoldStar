<!DOCTYPE html>
<html>
<head>
<title>Phòng Công Tác Sinh Viên</title>
<meta charset="utf-8">
<?php $thongtin = DB::table('gioithieu')->where('id',1)->first(); ?>
<?php $cauhinh = DB::table('cauhinh')->where('id',1)->first(); ?>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<base href="{{asset('')}}">
<link rel="stylesheet" type="text/css" href="public/assets/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/font-awesome.min.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/animate.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/font.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/li-scroller.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/slick.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/jquery.fancybox.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/theme.css">
<link rel="stylesheet" type="text/css" href="public/assets/css/style.css">
<link href = "public/images/logo.png" rel = "shortcut icon" type = "image/x-icon" />
<!--[if lt IE 9]>
<script src="public/assets/js/html5shiv.min.js"></script>
<script src="public/assets/js/respond.min.js"></script>
<![endif]-->
</head>
<?php  if($cauhinh->BaoTriWebsite == 0) 
    echo "<script>alert('Hệ thống đang upload dữ liệu. Vui lòng truy cập sau ít phút?');</script>";
    else
    {
?>
<body>
<div id="preloader">
  <div id="status">&nbsp;</div>
</div>
  @include('layout.head')
<a class="scrollToTop" href="#" style="margin-right: -60px;"><i class="fa fa-angle-up"></i></a>
<div class="container" style="margin-top: 25px;">
  <header id="header">
    <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12">
        <div class="header_bottom">
          <a href="{!! URL::route('trangchu') !!}"><img src="public/images/Banner.jpg" alt=""></a>
        </div>
      </div>
    </div>
  </header>
  <section id="navArea">
    <nav class="navbar navbar-inverse " role="navigation">
      <div class="navbar-header">
        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
      </div>
      <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav  navbar-nav main_nav">
          <li class="active"><a href="{!! URL::route('trangchu') !!}"><span class="fa fa-home desktop-home"></span><span class="mobile-show">Home</span></a></li>
         <!--  <li><a href="{!! URL::route('trangchu') !!}">Trang chủ</a></li> -->
          <li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Giới thiệu</a>
            <ul class="dropdown-menu" role="menu">
              <li><a href="{!! URL::route('trangchu.chucnangnhiemvu') !!}">Chức năng nhiệm vụ</a></li>
              <li><a href="{!! URL::route('trangchu.cocautochuc') !!}">Cơ cấu tổ chức</a></li>
              <li><a href="{!! URL::route('trangchu.nhansu') !!}">Nhân sự</a></li>
            </ul>
          </li>
<?php  $menu_level_1 = DB::table('nhomloaitin')->select()->get(); ?>
      @foreach($menu_level_1 as $item_level_1)
        <li class="dropdown"> <a href="{!! url('loaitin/'.$item_level_1->id.'/'.$item_level_1->TenKhongGiau) !!}.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">{!! $item_level_1->TenNhom !!}</a>
            <ul class="dropdown-menu" role="menu">
  <?php $menu_level_2 = DB::table('loaitin')->where('IDNhomLoaiTin',$item_level_1->id)->get(); ?>
          @foreach($menu_level_2 as $item_level_2)
              <li><a href="{!! url('loaitin/'.$item_level_2->id.'/'.$item_level_2->TenKhongGiau) !!}.html">{!! $item_level_2->TenLoai !!}</a></li>
          @endforeach
            </ul>
          </li>
       @endforeach


          <!-- <li><a href="#">CĐ - CS</a></li>
          <li><a href="#">Sinh viên</a></li>
          <li><a href="#">HT - VB</a></li> -->
          <li><a href="http://sao.agu.edu.vn/survey/login.php" target="_blank">Báo cáo TT</a></li>
          <li><a href="{!! URL::route('trangchu.hinhanhhoatdong') !!}">Hình ảnh Hoạt Động</a></li>
          <form  action="{!! route('trangchu.timkiem') !!}" method="post" class="navbar-form navbar-left" role="search">
          <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
              <div style="margin-top: 8px;">
                <div class="form-group">
                  <input style = "border: none;" type="text" name="TuKhoa" class="form-control" placeholder="Tìm kiếm nội dung" >
                </div>
                <button type="submit" class="btn btn-default" style="margin: auto; border: none; border-radius: 5px 5px 5px 5px;">Tìm</button>
              </div>
          </form>
        </ul>
      </div>
    </nav>
  </section>
  
  <section id="sliderSection">
  @include('layout.thongbao')
    <div class="row">
      @include('layout.slide')
    </div>
  </section>

  @yield('conten')
  
  @include('layout.right')
  </section>
  @include('layout.footer')
</div>
<script src="public/assets/js/jquery.min.js"></script> 
<script src="public/assets/js/wow.min.js"></script> 
<script src="public/assets/js/bootstrap.min.js"></script> 
<script src="public/assets/js/slick.min.js"></script> 
<script src="public/assets/js/jquery.li-scroller.1.0.js"></script> 
<script src="public/assets/js/jquery.newsTicker.min.js"></script> 
<script src="public/assets/js/jquery.fancybox.pack.js"></script> 
<script src="public/assets/js/custom.js"></script>
</body>
<?php } ?>
</html>