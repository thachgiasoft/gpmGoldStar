@extends('layout.index')
@section('conten')
<section id="contentSection">
    <div class="row">
      <div class="col-lg-8 col-md-8 col-sm-8">
        <div class="left_content">
          <div class="single_page">
          <h1>Chức năng nhiệm vụ</h1>
          <div class="single_page_content">
              <?php $thongtin = DB::table('gioithieu')->where('id',1)->first(); ?>
                <p style="text-align: justify;">{!! $thongtin->ChucNangNhiemVu !!}</p>
           </div>
          </div>
      </div>
    </div>
@endsection