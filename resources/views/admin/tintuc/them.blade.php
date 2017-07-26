@extends('admin.layout.index')
@section('title')| Tin tức | Thêm @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Thêm mới tin tức
      </h1>
     <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary">
          <a href="{!! route('admin.tintuc.danhsach') !!}"><i class="glyphicon glyphicon-list" style="color: white;"></i><b style="color: white;"> Danh sách</b></a>
        </li>
      </ol>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Nhập nội dung cần thêm</h3>
            </div>
            @include('admin.layout.thongbao')
            <form role="form" action="{!! route('admin.tintuc.postthem') !!}" method="post" enctype="multipart/form-data">
             <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
                <div class="box-body">
                  <div class="form-group">
                   <label>Tiêu đề</label>
                    <input class="form-control" placeholder="Nhập tiêu đề" type="text" name="TieuDe">
                  </div>

                   <div class="form-group">
                   <label>Thể loại</label>
                    <select class="form-control" name="IDTheLoai" id="IDTheLoai">
                      <option>---------------------- Chọn thể loại ------------------------</option>
                      @foreach($nhomloaitin as $lt)
                        <option value="{!! $lt->id !!}">{!! $lt->TenNhom !!}</option>
                      @endforeach
                    </select>
                  </div>

                  <div class="form-group">
                   <label>Loại tin</label>
                    <select class="form-control" name="IDLoaiTin" id="DanhSach">
                      @foreach($loaitin as $lt)
                        <option value="{!! $lt->id !!}">{!! $lt->TenLoai !!}</option>
                      @endforeach
                    </select>
                  </div>

                  <div class="form-group">
                   <label>Tóm tắt</label>
                    <textarea id="demo" class=" form-control ckeditor" name="TomTat" rows="3"></textarea>
                  </div>

                  <div class="form-group">
                   <label>Nội dung</label>
                    <textarea id="demo" class="form-control ckeditor" name="NoiDung" rows="5"></textarea>
                  </div>
                  
                  <div class="form-group">
                    <label for="exampleInputPassword1">Hình ảnh</label>
                    <input type="file"  name="HinhAnh">
                  </div>

                  <div class="form-group">
                    <label for="exampleInputPassword1">File đính kèm</label>
                    <input type="file"  name="FileDinhKem">
                  </div>

                  <div class="form-group">
                    <label>Nổi bật &nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <label class="radio-inline">
                        <input type="radio" name="NoiBat" value="0" placeholder="" checked="">Không
                    </label>
                    <label class="radio-inline">
                        <input type="radio" name="NoiBat" value="1" placeholder="">Có
                    </label>
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
  </section>
</div>
@endsection
@section('script')
<script>
  $(document).ready(function(){
      $("#IDTheLoai").change(function(){
        var IDTheLoai = $(this).val();
        //alert(IDTheLoai);
         $.get("admin/tintuc/ajax/"+IDTheLoai,function(data){
          //alert(data);
            $("#DanhSach").html(data);
         });
       });
    });
</script>
@endsection