@extends('admin.layout.index')
@section('title')| Người dùng @endsection
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách người dùng
      </h1>
  </section>
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="nav-tabs-custom">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab_1" data-toggle="tab"><i class="glyphicon glyphicon-th-list"></i> Danh sách người dùng</a></li>
            <li><a href="#tab_2" data-toggle="tab"><i class="glyphicon glyphicon-plus"></i> Thêm người dùng</a></li>
           
          </ul>
          <div class="tab-content">
            <div class="tab-pane active" id="tab_1">
              <div class="box-body">
                @include('admin.layout.thongbao')
                <table id="nguoidung" class="table table-bordered table-striped">
                  <thead>
                    <tr>
                      <th>STT</th>
                      <th>Họ tên</th>
                      <th>E-Mail</th>
                      <th>Level</th>
                      <th>Sửa</th>
                      <th>Xóa</th>
                    </tr>
                  </thead>
                  <tbody>
                    <?php 
                      $i=1;
                    ?>
                    @foreach($nguoidung as $item)
                    <tr align="center">
                      <td>{!! $i++ !!}</td>
                      <td>{!! $item->name !!}</td>
                      <td>{!! $item->email !!}</td>
                      <td>
                        @if($item->level == 1)
                          {!! "Admin" !!}
                        @elseif($item->level == 0)
                          {!! "Người dùng" !!}
                        @endif
                      </td>
                      <td><i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('admin.nguoidung.getsua', $item->id) !!}"> Sửa</a></td>
                      <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.nguoidung.getxoa', $item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
                    </tr>
                    @endforeach
                  </tbody>
                </table>
              </div>
            </div>
            <!-- /.tab-pane 1 -->


            <div class="tab-pane" id="tab_2">
              <form role="form" action="{!! route('admin.nguoidung.postthem') !!}" method="post" enctype="multipart/form-data">
              <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                    <div class="form-group">
                      <label>Tên người quản trị</label>
                      <input class="form-control" placeholder="Nhập tên người dùng" type="text" name="name">
                    </div>
                    <div class="form-group">
                      <label >E-Mail</label>
                      <input class="form-control" placeholder="Nhập E-Mail người dùng" type="email" name="email">
                    </div>
                    <div class="form-group">
                      <label>Nhập mật khẩu</label>
                      <input type="password" class="form-control"  placeholder="Nhập mật khẩu" name="password">
                    </div>
                    <div class="form-group">
                      <label>Nhập lại mật khẩu</label>
                      <input type="password" class="form-control" placeholder="Nhập lại mật khẩu" name="passwordagain">
                    </div>
                    
                    <div class="form-group">
                      <label>Level &nbsp;&nbsp;&nbsp;&nbsp;</label>
                      <label class="radio-inline">
                          <input type="radio" name="level" value="0" checked="">Người dùng
                      </label>
                      <label class="radio-inline">
                          <input type="radio" name="level" value="1">Admin
                      </label>
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
    $("#nguoidung").DataTable();
  });
</script>
@endsection