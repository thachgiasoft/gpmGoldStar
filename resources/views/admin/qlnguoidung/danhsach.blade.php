@extends('admin.layout.index')
@section('title')| Tài khoản @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
        <h1>
          Quản lý
          <small>Tài khoản</small>
        </h1>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
        <div class="nav-tabs-custom">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab_1" data-toggle="tab"><i class="glyphicon glyphicon-th-list"></i> Danh sách tài khoản</a></li>
            <li><a href="#tab_2" data-toggle="tab"><i class="glyphicon glyphicon-plus"></i> Thêm tài khoản</a></li>
          </ul>
          <div class="tab-content">
            <div class="tab-pane active" id="tab_1">
              <div class="box-body">
                @include('admin.layout.thongbao')
                <table id="sinhvien" class="table table-bordered table-striped">
                  <thead>
                    <tr>
                      <th>STT</th>
                      <th>Họ & Tên</th>
                      <th>Email</th>
                      <th>Hình ảnh</th>
                      <th>Level</th>
                      <th>Sửa</th>  
                      <th>Xóa</th>
                    </tr>
                  </thead>
                  <?php $i=1; ?>
                  <tbody>
                  @foreach($nguoidung as $item)
                    <tr style="text-align: center;">
                      <td>{!! $i++ !!}</td>
                      <td>{!! $item->name !!}</td>
                     <td><a href="mailto:{!! $item->Email !!}" target="_top">{!! $item->email !!}</a></td>
                       <td> <img @if($item->hinhanh !="") src="public/upload/user/{!! $item->hinhanh !!}" @elseif($item->hinhanh =="") src="public/upload/user/1866.jpg"  @endif class="img-circle" alt="User Image" width="50px" height="50px"></td>
                      <td>
                        @if( $item->level == 1 && $item->id ==1)
                            <b>Super Admin</b>
                        @elseif($item->level == 1)
                            <b>Admin</b>
                        @endif
                      </td>
                      <td>
                        <i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('goldstar-admin.qlnguoidung.getsua',$item->id) !!}"> Sửa</a>
                      </td>
                      <td>
                        <a href="{!! URL::route('goldstar-admin.qlnguoidung.getxoa',$item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"><i class="glyphicon glyphicon-remove"></i> Xóa </a>
                      </td>
                    </tr>
                  @endforeach
                  </tbody>
                  <tfoot>
                    <tr>
                      <th>STT</th>
                      <th>Họ & Tên</th>
                      <th>Email</th>
                      <th>Hình ảnh</th>
                      <th>Level</th>
                      <th>Sửa</th>  
                      <th>Xóa</th>
                    </tr>
                  </tfoot>
                </table>
              </div>
            </div>
            <!-- /.tab-pane 1 -->
            <div class="tab-pane" id="tab_2">
              <form role="form" action="{!! route('goldstar-admin.qlnguoidung.postthem') !!}" method="post" enctype="multipart/form-data">
              <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                    <div class="form-group">
                      <label for="exampleInputPassword1">Tên người quản trị</label>
                      <input class="form-control" placeholder="Nhập tên người quản trị" type="text" name="name">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">E-Mail</label>
                      <input class="form-control" placeholder="Nhập E-Mail người quản trị" type="email" name="email">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Nhập mật khẩu</label>
                      <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Nhập mật khẩu" name="password">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Nhập lại mật khẩu</label>
                      <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Nhập lại mật khẩu" name="passwordagain">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Ảnh đại diện</label>
                      <input type="file"  id="exampleInputPassword1" placeholder="Ảnh đại diện" name="hinhanh">
                    </div>

                </div>
                  <div class="box-footer">
                    <button type="submit" class="btn btn-primary">Thêm</button>
                    <button type="reset" class="btn btn-danger">Làm lại</button>
                  </div>
              </form>
            </div>
            <!-- /.tab-pane 2-->
          </div>
        </div>
      </div>
    </div>
  </section>
</div>

@endsection
@section('script')
<script>
 
  $(function () {
    $("#sinhvien").DataTable();
  });
  $('#datepicker').datepicker({
    weekStart: 1,
    format: "dd/mm/yy",
    autoclose: 1,
    language: "vi"
  });
</script>
@endsection