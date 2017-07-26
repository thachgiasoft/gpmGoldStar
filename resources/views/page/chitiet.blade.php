@extends('layout.index')
@section('conten')
<section id="contentSection">
    <div class="row">
      <div class="col-lg-8 col-md-8 col-sm-8">
        <div class="left_content">
          <div class="single_page">
            <h1>{!! $tintuc->TieuDe !!}</h1>
          <div class="post_commentbox"><span><i class="fa fa-calendar"></i>
            {!! $tintuc->updated_at  !!} (Lượt xem: {!! $tintuc->SoLuotXem !!})</span>
          
              <a href="{!! Share::load(Request::url(),$tintuc->TieuDe)->facebook() !!}" target="_blank"><i class="fa fa-facebook" target="_blank"></i>Chia sẻ</a>
           
            </div>
          <div class="single_page_content">
            <p ><span style="font-size:14px">
            {!! $tintuc->NoiDung !!}
            </span>
            @if($tintuc->FileDinhKem != "")
              <h4>Xem đính kèm: <a href="public/upload/{!! $tintuc->FileDinhKem !!}" >{!! $tintuc->FileDinhKem !!}</a></h4>
            @endif
          </p>
         </div>
          <div class="related_post" >
            <h2>Tin liên quan</h2>
            @foreach($tinlienquan as $item)
            <ul class="spost_nav wow fadeInDown animated">
              <li>
                <div class="media">
                  <img src="public/upload/{!! $item->HinhAnh !!}" alt="Không có ảnh " width="100px" height="80px">
                  <div class="media-body">
                    <a class="catg_title" href="{!! url('tintuc/'.$item->id.'/'.$item->TieuDeKhongDau) !!}.html">{!! $item->TomTat !!}</a> 
                  </div>
                </div>
              </li>
            </ul>
            @endforeach
          </div>
        </div>
          @include('layout.dangkynhantin')
         
        </div>
      </div>
@endsection