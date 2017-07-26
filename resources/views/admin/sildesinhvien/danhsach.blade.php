@extends('admin.layout.index')
@section('title')| Silde @endsection
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách Silde Banner
      </h1>
  </section>
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="nav-tabs-custom">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab_1" data-toggle="tab"><i class="glyphicon glyphicon-th-list"></i> Danh sách Silde</a></li>
            <li><a href="#tab_2" data-toggle="tab"><i class="glyphicon glyphicon-plus"></i> Thêm Silde</a></li>
           
          </ul>
          <div class="tab-content">
            <div class="tab-pane active" id="tab_1">
              <div class="box-body">
                @include('admin.layout.thongbao')
                <table id="nguoidung" class="table table-bordered table-striped">
                  <thead>
                    <tr>
                      <th>STT</th>
                      <th>Tên sinh viên</th>
                      <th>Hình</th>
                      <th>Sửa</th>
                      <th>Xóa</th>
                    </tr>
                  </thead>
                  <tbody>
                    <?php 
                      $i=1;
                    ?>
                    @foreach($slide as $item)
                    <tr align="center">
                      <td>{!! $i++ !!}</td>
                      <td>{!! $item->Ten !!}</td>
                      <td><img src="public/upload/{!! $item->Hinh !!}" alt="HTML" width="200px" height="300px"></td>
                      <td><i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('admin.slidesinhvien.getsua', $item->id) !!}"> Sửa</a></td>
                      <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.slidesinhvien.getxoa', $item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
                    </tr>
                    @endforeach
                  </tbody>
                </table>
              </div>
            </div>
            <!-- /.tab-pane 1 -->


            <div class="tab-pane" id="tab_2">
              <form role="form" action="{!! route('admin.slidesinhvien.postthem') !!}" method="post" enctype="multipart/form-data">
              <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                    <div class="form-group">
                      <label>Tên sinh viên</label>
                      <input class="form-control" placeholder="Nhập tên sinh viên" type="text" name="TenHinh">
                    </div>

                    <div class="form-group">
                      <label>Hình ảnh</label>
                      <input type="file" name="Hinh">
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