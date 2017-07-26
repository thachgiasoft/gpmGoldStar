@extends('layout.index')
@section('conten')
<section id="contentSection">
    <div class="row">
      <div class="col-lg-8 col-md-8 col-sm-8">
        <div class="left_content">
          <div class="single_page">
            <h1>{!! $silde->Ten !!}</h1>
          <div class="single_page_content">
            @if($silde->Hinh != "")
            <img src="public/upload/{!! $silde->Hinh !!}" alt="">
            @endif
            <p ><span style="font-size:14px">
            {!! $silde->NoiDung !!}
            </span>
            
            </p>
          </div>
        </div>
          @include('layout.dangkynhantin')
        </div>
      </div>
@endsection