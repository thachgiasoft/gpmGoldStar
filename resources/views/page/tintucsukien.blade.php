@extends('layout.index')
@section('title')| Tin tức sự kiện @endsection
@section('conten')
<section id="contentSection">
  <div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8">
      <div class="left_content">
        <div class="contact_area">
            @foreach($tintuc as $tt)
            <div class="row-item row">
              <div class="col-md-3">
                <br>
                @if($tt->HinhAnh != "")
                <img width="200px" height="200px" class="img-responsive" src="{!! url('public/upload/'.$tt->HinhAnh) !!}">
                @endif
              </div>
              <div class="col-md-9">
                <a href="{!! url('tintuc/'.$tt->id.'/'.$tt->TieuDeKhongDau) !!}.html">
                  <h3>{!! $tt->TieuDe !!}</h3>
                  <p>{!! $tt->TomTat !!}.</p>
                </a>
              </div>
              <div class="break"></div>
            </div>
            @endforeach
            <!-- Phân trang -->
            <div class="row text-right">
              {!! $tintuc->links() !!}
            </div>
          </div>
        </div>
      </div>
@endsection


            