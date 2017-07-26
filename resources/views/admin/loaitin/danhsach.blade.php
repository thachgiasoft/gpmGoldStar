@extends('admin.layout.index')
@section('title')| Loại tin @endsection
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách
        <small>Loại tin</small>
      </h1>
      <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary" href="#themloaitin" data-toggle="modal" data-target="#themloaitin">
          <i class="glyphicon glyphicon-plus"></i><b style="color: white;">  Thêm mới</b>
        </li>
      </ol>
  </section>
  <section class="content">
    <div class="row">
      <div class="col-xs-12">
        <div class="box">
          <div class="box-header">
            <h3 class="box-title">Danh sách các loại tin</h3>
          </div>
          <div class="box-body">
           @include('admin.layout.thongbao')
            <table id="loaitin" class="table table-bordered table-striped">
              <thead>
              <tr>
                <th>STT</th>
                <th>Tên loại tin</th>
                <th>Tên không giấu</th>
                <th>Thuộc thể loại</th>
                <th>Sửa</th>
                <th>Xóa</th>
              </tr>
              </thead>
              <tbody>
              <?php $i=1; ?>
              @foreach($loaitin as $lt)
              <tr align="center">
                <td>{!! $i++ !!}</td>
                <td>{!! $lt->TenLoai !!}</td>
                <td>{!! $lt->TenKhongGiau !!}</td>
                <td>{!! $lt->nhomloaitin->TenNhom !!}</td>
                <td><i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('admin.loaitin.getsua',$lt->id) !!}"> Sửa</a></td>
                <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.loaitin.getxoa',$lt->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
              @endforeach
              </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
  </section>
</div>
<div class="modal fade" id="themloaitin" tabindex="-1" role="dialog" aria-labelledby="themloaitinLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="themloaitinLabel" align="center">Thêm loại tin</h4>
      </div>
       <form action="{!! route('admin.loaitin.postthem') !!}" class="form-horizontal" method="post" data-toggle="validator" role="form" id="valForm" enctype="multipart/form-data">
       <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
        <div class="modal-body">
          <div class="box-body">

            <div class="form-group">
             <label>Tên loại tin </label>
              <input class="form-control" placeholder="Nhập tên loại tin" type="text" name="TenLoai">
            </div>
            <div class="form-group">
              <label>Thuộc thể loại</label>
                <select class="form-control" name="IDNhomLoaiTin">
                  <option value="">---------------------------------------------------- Chọn thể loại ----------------------------------------------------</option>
                  @foreach($nhomloaitin as $nlt)
                    <option value="{!! $nlt->id !!}">{!! $nlt->TenNhom !!}</option>
                  @endforeach
              </select>
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