<aside class="main-sidebar">
<!-- sidebar: style can be found in sidebar.less -->
<section class="sidebar">
  <!-- Sidebar user panel -->
  <!-- sidebar menu: : style can be found in sidebar.less -->
  <ul class="sidebar-menu">
    <li class="header">QUẢN TRỊ HỆ THỐNG</li>
    
    <li><a href="{!! URL::route('admin.nhomloaitin.danhsach') !!}"><i class="glyphicon glyphicon-th-large"></i>Quản lý thể loại</a></li>
    <li><a href="{!! URL::route('admin.loaitin.danhsach') !!}"><i class="glyphicon glyphicon-th"></i>Quản lý loại tin</a></li>
    <li><a href="{!! URL::route('admin.tintuc.danhsach') !!}"><i class="glyphicon glyphicon-th-list"></i>Quản lý tin tức</a></li>
    <li class="treeview">
      <a href="#">
        <i class="fa fa-dashboard"></i> <span>Quản lý Silde</span>
        <span class="pull-right-container">
          <i class="fa fa-angle-left pull-right"></i>
        </span>
      </a>
      <ul class="treeview-menu">
        <li><a href="{!! URL::route('admin.slide.danhsach') !!}"><i class="fa fa-circle-o"></i>Quản lý Slide banner</a></li>
        <li><a href="{!! URL::route('admin.slidesinhvien.danhsach') !!}"><i class="fa fa-circle-o"></i>Quản lý Slide sinh viên</a></li>
      </ul>
    </li>
    <li><a href="{!! URL::route('admin.mail.danhsach') !!}"><i class="fa fa-circle-o"></i>Quản lý Mail nhận tin</a></li>
     <li class="treeview">
      <a href="#">
        <i class="fa fa-dashboard"></i> <span>Quản lý giới thiệu</span>
        <span class="pull-right-container">
          <i class="fa fa-angle-left pull-right"></i>
        </span>
      </a>
      <ul class="treeview-menu">
        <li><a href="{!! URL::route('admin.gioithieu.getsuacnnv',1) !!}"><i class="fa fa-circle-o"></i>Chức năng nhiệm vụ</a></li>
        <li><a href="{!! URL::route('admin.gioithieu.getsuacctc',1) !!}"><i class="fa fa-circle-o"></i>Cơ cấu tổ chức</a></li>
        <li><a href="{!! URL::route('admin.gioithieu.getsuanhansu',1) !!}"><i class="fa fa-circle-o"></i>Nhân sự</a></li>
        <li><a href="{!! URL::route('admin.gioithieu.getsualienhe',1) !!}"><i class="fa fa-circle-o"></i>Liên hệ</a></li>
        <li><a href="{!! URL::route('admin.gioithieu.getsuathongtin',1) !!}"><i class="fa fa-circle-o"></i>Thông tin</a></li>
      </ul>
    </li>
    <li><a href="{!! URL::route('admin.anhhoatdong.danhsach') !!}"><i class="glyphicon glyphicon-cog"></i>Hình ảnh hoạt động</a></li>
    <li><a href="{!! URL::route('admin.cauhinh.getsua',1) !!}"><i class="glyphicon glyphicon-cog"></i>Quản lý cấu hình</a></li>
   
    <li><a href="{!! URL::route('admin.nguoidung.danhsach') !!}"><i class="glyphicon glyphicon-user"></i>Quản lý người dùng</a></li>
    <li><a href="{!! URL::route('admin.cauhinh.getbaotri',1) !!}"><i class="glyphicon glyphicon-globe"></i>Bảo trì hệ thống</a></li>
  </ul>
</section>
</aside>