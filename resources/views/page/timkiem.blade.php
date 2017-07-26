@extends('layout.index')
@section('conten')
<section id="contentSection">
  <div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8">
      <?php
        function doimau($str,$tukhoa)
        {
            return str_replace($tukhoa, "<span style='color:blue;font-style:italic;'>$tukhoa</span" , $str);
        }
      ?>
      <div class="left_content">
        <div class="contact_area">
          <h3>Tìm kiếm: <small> {!! $tukhoa !!}</small></h3>
            @if($tintuc->count() >0)
              @foreach($tintuc as $tt)
              <div class="row-item row">
                <div class="col-md-3">
                  <br>
                  @if($tt->HinhAnh != "")
                  <img width="200px" height="200px" class="img-responsive" src="{!! url('public/upload/'.$tt->HinhAnh) !!}" alt="HTML">
                  @endif
                </div>
                <div class="col-md-9">
                <a href="{!! url('tintuc/'.$tt->id.'/'.$tt->TieuDeKhongDau) !!}.html">
                    <h3>{!! doimau($tt->TieuDe,$tukhoa) !!}</h3>
                    <p>{!! doimau($tt->TomTat,$tukhoa) !!}.</p>
                </a>
                </div>
                <div class="break"></div>
              </div>
              @endforeach
            @else
              <div class="row text-center ">
                  <h3>Không có kết quả nào được tìm thấy!</h3>
              </div>
            @endif
            <!-- Phân trang -->
            <div class="row text-right">
              {!! $tintuc->links() !!}
            </div>
          </div>
        </div>
      </div>
@endsection