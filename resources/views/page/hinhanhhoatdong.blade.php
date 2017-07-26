@extends('layout.index')
@section('title')| Tin tức sự kiện @endsection
@section('conten')
<section id="contentSection">
  <div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8">
      <div class="left_content">
        <div class="contact_area">
            <div class="single_post_content">
            <h2><span>Hình ảnh hoạt động</span></h2>
            <ul class="photograph_nav  wow fadeInDown">
            @foreach($hinhanh as $item)
              <li>
                <div class="photo_grid">
                  <figure class="effect-layla"> <a class="fancybox-buttons" data-fancybox-group="button" href="public/upload/{!! $item->HinhAnh !!}" title="{!! $item->TenAnh !!}"> <img src="public/upload/{!! $item->HinhAnh !!}" alt=""/></a> </figure>
                </div>
              </li>
            @endforeach
            </ul>
          </div>
          </div>
        </div>
      </div>
@endsection


            