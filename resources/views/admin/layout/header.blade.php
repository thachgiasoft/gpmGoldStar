<a href="{!! URL::route('admin.tintuc.danhsach') !!}" class="logo">
  <span class="logo-lg">Admin - AGU</span>
</a>
<!-- Header Navbar: style can be found in header.less -->
<nav class="navbar navbar-static-top">
  <!-- Sidebar toggle button-->
  <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
     <span class="sr-only">Toggle navigation</span>
  </a>

  <div class="navbar-custom-menu">
    <ul class="nav navbar-nav">
      <!-- User Account: style can be found in dropdown.less -->
      <li class="dropdown user user-menu">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
          <img  @if(Auth::user()->hinhanh !="") src="public/upload/{!! Auth::user()->hinhanh !!}" @elseif(Auth::user()->hinhanh =="") src="public/upload/item.gif"  @endif class="user-image" alt="User Image" class="user-image" alt="User Image">
          <span class="hidden-xs">{!! Auth::user()->name !!}</span>
        </a>
        <ul class="dropdown-menu">
          <!-- User image -->
          <li class="user-header">
            <img @if(Auth::user()->hinhanh !="") src="public/upload/{!! Auth::user()->hinhanh !!}" @elseif(Auth::user()->hinhanh =="") src="public/upload/item.gif"  @endif  class="img-circle" alt="User Image">
            <p>
              Xin chào: {!! Auth::user()->name !!}
              <small>Tham gia - {!! Auth::user()->created_at  !!}</small>
            </p>
          </li>
          <!-- Menu Footer-->
          <li class="user-footer">
            <div class="pull-left">
              <a href="{!! route('admin.nguoidung.getsua',Auth::user()->id) !!}" class="btn btn-default btn-flat">Thay đổi thông tin</a>
            </div>
            <div class="pull-right">
              <a href="admin/logout" class="btn btn-default btn-flat">Đăng xuất</a>
            </div>
          </li>
        </ul>
      </li>
    </ul>
  </div>
</nav>