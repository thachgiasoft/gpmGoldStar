@extends('admin.layout.index')
@section('title')| Slide hình ảnh @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
        <h1>
          Slide 
          <small>hình ảnh</small>
        </h1>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
        <div class="nav-tabs-custom">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab_1" data-toggle="tab"><i class="glyphicon glyphicon-th-list"></i> Danh sách hình ảnh</a></li>
            <li><a href="#tab_2" data-toggle="tab"><i class="glyphicon glyphicon-plus"></i> Thêm slide hình ảnh</a></li>
          </ul>
          <div class="tab-content">
            <div class="tab-pane active" id="tab_1">
              <div class="box-body">
                @include('admin.layout.thongbao')
                <table id="sinhvien" class="table table-bordered table-striped">
                  <thead>
                    <tr>
                      <th>STT</th>
                      <th>Tiêu đề</th>
                      <th>Link</th>
                      <th>Hình ảnh</th>
                      <th>Sửa</th>  
                      <th>Xóa</th>
                    </tr>
                  </thead>
                  <?php $i=1; ?>
                  <tbody>
                  @foreach($slide as $item)
                    <tr style="text-align: center;">
                      <td>{!! $i++ !!}</td>
                      <td>{!! $item->TieuDe !!}</td>
                     <td><a href="{!! $item->Link !!}" target="_top">{!! $item->Link !!}</a></td>
                       <td> <img @if($item->HinhAnh !="") src="public/upload/slide/{!! $item->HinhAnh !!}" @elseif($item->HinhAnh =="") src="public/upload/slide/1866.jpg"  @endif class="img-circle" alt="GPM" width="50px" height="50px"></td>
                      <td>
                        <i class="fa fa-pencil fa-fw"></i><a href="{!! URL::route('goldstar-admin.qlslide.getsua',$item->id) !!}"> Sửa</a>
                      </td>
                      <td>
                        <a href="{!! URL::route('goldstar-admin.qlslide.getxoa',$item->id) !!}" onclick="return thongbaoxoa('Bạn chắc chắn muốn xóa?')"><i class="glyphicon glyphicon-remove"></i> Xóa </a>
                      </td>
                    </tr>
                  @endforeach
                  </tbody>
                  <tfoot>
                    <tr>
                      <th>STT</th>
                      <th>Tiêu đề</th>
                      <th>Link</th>
                      <th>Hình ảnh</th>
                      <th>Sửa</th>  
                      <th>Xóa</th>
                    </tr>
                  </tfoot>
                </table>
              </div>
            </div>
            <!-- /.tab-pane 1 -->
            <div class="tab-pane" id="tab_2">
              <form role="form" action="{!! route('goldstar-admin.qlslide.postthem') !!}" method="post" enctype="multipart/form-data">
              <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                    <div class="form-group">
                      <label for="exampleInputPassword1">Tiêu đề</label>
                      <input class="form-control" placeholder="Vui lòng nhập Tiêu đề" type="text" name="TieuDe">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Link</label>
                      <input class="form-control" name="Link">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Hình ảnh</label>
                      <input type="file"  id="exampleInputPassword1" name="HinhAnh">
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
</script>
@endsection