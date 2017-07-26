@extends('admin.layout.index')
@section('title')| Tin tức @endsection
@section('content')
<form action="{!! route('admin.tintuc.postxoachon') !!}" method="POST">
    <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
<div class="content-wrapper">
  <section class="content-header">
      <h1>
      
        Danh sách
        <small>Tin tức</small>
      </h1>
      <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <a onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa chứ?')"><button type="submit" class="btn btn-primary"><i class="fa fa-trash-o" style="color: white;"></i><b style="color: white;"> Xóa chọn</b></button></a>
        <li class="btn btn-primary">
          <a href="{!! route('admin.tintuc.getthem') !!}"><i class="glyphicon glyphicon-plus" style="color: white;"></i><b style="color: white;"> Thêm mới</b></a>
        </li>
      </ol>
  </section>
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Danh sách các biểu mẫu</h3>
            </div>
            <div class="box-body">
             @include('admin.layout.thongbao')
              <table id="tintuc" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th><input type="checkbox" onchange="checkAll(this)" /></th>
                  <th>STT</th>
                  <th style="width: 150px;">Tiêu đề</th>
                  <th style="width: 250px;">Tóm tắt</th>
                  <th>Nổi bật</th>
                  <th>Đính kèm</th>
                  <th>Số lượt xem</th>
                  <th>Thuộc loại tin</th>
                  <th>Sửa</th>
                  <th>Xóa</th>
                </tr>
                </thead>
                <tbody>
                <?php $i=1; ?>
                @foreach($tintuc as $tt)
                <tr>
                  <td class="text-center"><input type="checkbox" name="checkbox_array[]" value="{!! $tt->id !!}"></td>
                  <td>{!! $i++ !!}</td>
                  <td>{!! $tt->TieuDe !!} <p><img @if($tt->HinhAnh !="") src="public/upload/{!! $tt->HinhAnh !!}"  @endif  width="150px" height="150px"> </p></td>
                  <td>{!! $tt->TomTat !!}</td>
                  <td>
                      @if($tt->NoiBat == 1)
                        Có
                      @else
                        Không
                      @endif
                  </td>
                  <td>
                    @if($tt->FileDinhKem != "")
                    <a href="public/upload/{!! $tt->FileDinhKem !!}"  target="_blank"><i class="glyphicon glyphicon-paperclip"></i></a>
                    @endif
                  </td>
                  <td>{!! $tt->SoLuotXem !!}</td>
                  <td>{!! $tt->loaitin->TenLoai !!}</td>
                  <td><i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('admin.tintuc.getsua',$tt->id) !!}"> Sửa</a></td>
                  <td><i class="fa fa-trash-o  fa-fw"></i><a href="{!! URL::route('admin.tintuc.getxoa',$tt->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"> Xóa</a></td>
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