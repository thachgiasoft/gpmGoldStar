@extends('admin.layout.index')
@section('title')| Loại tin | Cập nhật @endsection
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Cập nhật
        <small>{!! $loaitin->TenLoai !!}</small>
      </h1>
     <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary">
          <a href="{!! route('admin.loaitin.danhsach') !!}"><i class="glyphicon glyphicon-list" style="color: white;"></i><b style="color: white;"> Danh sách</b></a>
        </li>
      </ol>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Cập nhật</h3>
            </div>
            @include('admin.layout.thongbao')
            <form role="form" action="" method="post" enctype="multipart/form-data">
           <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
              <div class="box-body">
                <div class="form-group">
                 <label>Tên loại tin </label>
                  <input class="form-control" placeholder="Nhập tên loại tin" type="text" name="TenLoai" value="{!! old('TenLoai',isset($loaitin) ? $loaitin->TenLoai : null) !!}">
                </div>
                <div class="form-group">
                    <label>Thuộc nhóm loại tin</label>
                    <select class="form-control" name="IDNhomLoaiTin">
                      @foreach($nhomloaitin as $nlt)
                        <option 
                          @if($loaitin->IDNhomLoaiTin == $nlt->id)
                                {!! "selected" !!}
                          @endif
                        value="{!! $nlt->id !!}">{!! $nlt->TenNhom !!}</option>
                      @endforeach
                    </select>
                  </div>
              </div>
              <div class="box-footer">
                <button type="submit" class="btn btn-primary">Cập nhật</button>
                <button type="reset" class="btn btn-danger">Làm lại</button>
              </div>
            </form>
          </div>
      </div>
    </div>
  </section>
</div>
@endsection