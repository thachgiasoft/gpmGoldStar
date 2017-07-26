@extends('admin.layout.index')
@section('title')| Mail @endsection
@section('content')
<form action="{!! route('admin.mail.postxoachon') !!}" method="POST">
    <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
<div class="content-wrapper">
  <section class="content-header">
      <h1>
        Danh sách Mail đăng ký nhận tin
      </h1>
      <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
          <a onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa chứ?')"><button type="submit" class="btn btn-primary"><i class="fa fa-trash-o" style="color: white;"></i><b style="color: white;"> Xóa chọn</b></button></a>
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
              <table id="tintuc" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th width="10px"><input type="checkbox" onchange="checkAll(this)" /></th>
                  <th>STT</th>
                  <th>Tên E-mail</th>
                  <th>Ngày đăng ký</th>
                  <th>Xóa</th>
                </tr>
                </thead>
                <tbody>
                <?php $i=1; ?>
                @foreach($mail as $item)
                <tr align="center">
                  <td class="text-center"><input type="checkbox" name="checkbox_array[]" value="{!! $item->id !!}"></td>
                  <td>{!! $i++ !!}</td>
                  <td><a href="mailto:{!! $item->Email !!}">{!! $item->Email !!}</a></td>
                  <td>
                  <?php echo $ngay = date('d/m/Y',strtotime($item->created_at)); ?>
                  </td>
                  <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.mail.getxoa',$item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
                @endforeach
                </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</form>
@endsection
@section('script')
<script>
  $(function () {
    $("#tintuc").DataTable();
  });
</script>
@endsection