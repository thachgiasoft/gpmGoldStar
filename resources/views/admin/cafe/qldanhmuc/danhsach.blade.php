@extends('admin.layout.index')
@section('title')| Danh Mục Cafe @endsection
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh Mục
        <small>Cafe</small>
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
            <h3 class="box-title">Danh sách danh mục cafe</h3>
          </div>
          <div class="box-body">
           @include('admin.layout.thongbao')
            <table id="loaitin" class="table table-bordered table-striped">
              <thead>
                <tr>
                  <th>STT</th>
                  <th>Tên danh mục</th>
                  <th>Tên danh mục không dấu</th>
                  <th>Sửa</th>
                  <th>Xóa</th>
                </tr>
              </thead>
              <tbody>
              <?php $i=1; ?>
              @foreach($cafe_danhmuc as $item)
              <tr align="center">
                <td>{!! $i++ !!}</td>
                <td>{!! $item->tendanhmuc !!}</td>
                <td>{!! $item->tendanhmuckhongdau !!}</td>
                <td>
                  <i class="fa fa-pencil fa-fw"></i>
                  <a href="{!! URL::route('goldstar-admin.cafe.qldanhmuc.getsua',$item->id) !!}"> Sửa</a>
                </td>
                <td>
                  <i class="fa fa-trash-o  fa-fw"></i>
                    <a href="{!! URL::route('goldstar-admin.cafe.qldanhmuc.getxoa',$item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a>
                </td>
              @endforeach
              </tr>
              </tbody>
              <tfoot>
                <tr>
                  <th>STT</th>
                  <th>Tên danh mục</th>
                  <th>Tên danh mục không dấu</th>
                  <th>Sửa</th>
                  <th>Xóa</th> 
                </tr>
              </tfoot>
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
        <h4 class="modal-title" id="themloaitinLabel" align="center">Thêm danh mục cafe</h4>
      </div>
       <form action="{!! route('goldstar-admin.cafe.qldanhmuc.postthem') !!}" class="form-horizontal" method="post" data-toggle="validator" role="form" id="valForm" enctype="muitemipart/form-data">
       <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
        <div class="modal-body">
          <div class="box-body">
            <div class="form-group">
             <label>Tên danh mục </label>
              <input class="form-control" placeholder="Vui lòng nhập tên danh mục cafe" type="text" name="tendanhmuc">
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