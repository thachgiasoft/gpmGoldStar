@extends('admin.layout.index')
@section('content')
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách
        <small>Sinh viên</small>
      </h1>
      <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary">
          <a href="admin/sinhvien/them"><i class="glyphicon glyphicon-plus" style="color: white;"></i><b style="color: white;"> Thêm mới</b></a>
        </li>
        <li class="btn btn-primary">
          <a href="#"><i class="glyphicon glyphicon-floppy-open" style="color: white;"></i><b style="color: white;"> Import File</b></a>
        </li>
        <li class="btn btn-primary">
          <a href="#"><i class="glyphicon glyphicon-floppy-save" style="color: white;"></i><b style="color: white;"> Export File</b></a>
        </li>
      </ol>
  </section>
    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Danh sách sinh viên</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>STT</th>
                  <th>Browser</th>
                  <th>Platform(s)</th>
                  <th>Sửa</th>
                  <th>Xóa</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                  <td>Trident</td>
                  <td>Internet
                    Explorer 4.0
                  </td>
                  <td>Win 95+</td>
                  <td><i class="fa fa-pencil fa-fw"></i><a href="admin/sinhvien/sua"> Sửa</a></td>
                  <td><i class="fa fa-trash-o  fa-fw"></i><a href="#"> Xóa</a></td>
                </tr>
                </tbody>
                <tfoot>
                <tr>
                  <th>STT</th>
                  <th>Browser</th>
                  <th>Platform(s)</th>
                  <th>Engine version</th>
                  <th>CSS grade</th>
                </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
  </div>
@endsection
@section('script')

<script>
  $(function () {
    $("#example1").DataTable();
    $('#example2').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false
    });
  });
</script>
@endsection