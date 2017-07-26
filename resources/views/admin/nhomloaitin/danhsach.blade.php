@extends('admin.layout.index')
@section('title')| Thể Loại @endsection
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách thể loại
       
      </h1>
      <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary" href="#nhomloaitin" data-toggle="modal" data-target="#nhomloaitin">
          <i class="glyphicon glyphicon-plus"></i><b style="color: white;">  Thêm mới</b>
        </li>
      </ol>
  </section>
  <section class="content">
    <div class="row">
      <div class="col-xs-12">
        <div class="box">
          <div class="box-header">
            <h3 class="box-title">Danh sách</h3>
          </div>
          <div class="box-body">
           @include('admin.layout.thongbao')
            <table id="loaitin" class="table table-bordered table-striped">
              <thead>
              <tr>
                <th>STT</th>
                <th>Tên thể loại</th>
                <th>Tên thể loại không giấu</th>
                <th>Sửa</th>
                <th>Xóa</th>
              </tr>
              </thead>
              <tbody>
              <?php $i=1; ?>
              @foreach($nhomloaitin as $item)
              <tr align="center">
                <td>{!! $i++ !!}</td>
                <td>{!! $item->TenNhom !!}</td>
                <td>{!! $item->TenKhongGiau !!}</td>
                <td><i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('admin.nhomloaitin.getsua',$item->id) !!}"> Sửa</a></td>
                <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.nhomloaitin.getxoa',$item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
              @endforeach
              </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
  </section>
</div>
<div class="modal fade" id="nhomloaitin" tabindex="-1" role="dialog" aria-labelledby="nhomloaitinLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="nhomloaitinLabel" align="center">Thêm Thể Loại</h4>
      </div>
       <form action="{!! route('admin.nhomloaitin.postthem') !!}" class="form-horizontal" method="post" data-toggle="validator" role="form" id="valForm" enctype="multipart/form-data">
       <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
        <div class="modal-body">
          <div class="box-body">

            <div class="form-group">
             <label>Tên thể loại </label>
              <input class="form-control" placeholder="Nhập tên thể loại" type="text" name="TenNhom">
            </div>

          </div>
        </div>
        <div class="modal-footer" style="text-align: center;">
          <button type="submit" class="btn btn-primary">Thêm</button>
          <button type="button" class="btn btn-danger" data-dismiss="modal">Thoát</button>
        </div>
      </form>
    </div>
  </div>
</div>
@endsection
@section('script')
<script>
  $(function () {
    $("#loaitin").DataTable();
  });
</script>
@endsection