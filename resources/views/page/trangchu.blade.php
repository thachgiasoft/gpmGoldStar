@extends('layout.index')
@section('conten')
<section id="contentSection">
  <div class="row">
    <div class="col-lg-8 col-md-8 col-sm-8">
      <div class="left_content">
        <div class="single_post_content">
          <div class = "chenchu">
          <div class = "logoAGU"><img src = "public/images/logo.png" ></div>
          <div class = "chu000">
            <a>Tin tức - sự kiện</a>
          </div>
          </div>
          <?php 
                $tintuc = DB::table('tintuc')->select('id','TieuDe','TieuDeKhongDau','TomTat','NoiDung','HinhAnh','NoiBat','SoLuotXem','FileDinhKem','IDLoaiTin','created_at')->where('NoiBat',1)->orderBy('created_at','DESC')->take(6)->get();
                $tin1 = $tintuc->shift();
          ?>
          <div class="single_post_content_left">
            <ul class="business_catgnav  wow fadeInDown">
              <li>
                <figure class="bsbig_fig">
                @if($tin1->HinhAnh != "")
                <img alt="{!! $tin1->TieuDe !!}" src="public/upload/{!! $tin1->HinhAnh !!}" height="180px" > 
                @endif
                <span class="overlay"></span>
                  <figcaption> <a href="{!! url('tintuc/'.$tin1->id.'/'.$tin1->TieuDeKhongDau) !!}">
                  {!! $tin1->TieuDe !!}</a> </figcaption>
                  <p>{!! $tin1->TomTat !!}</p>
                </figure>
                <p><a href="{!! URL::route('trangchu.tintucsukien') !!}" style="float: right;"> Xem thêm<span class="glyphicon glyphicon-chevron-right"></span></a></p>
              </li>
            </ul>
          </div>
          <div class="single_post_content_right">
            <ul class="spost_nav">
            @foreach($tintuc as $item)
              <li>
                <div class="media wow fadeInDown">
                  <div class="media-body"> <a href="{!! url('tintuc/'.$item->id.'/'.$item->TieuDeKhongDau) !!}.html" class="catg_title">{!! $item->TieuDe !!}</a> </div>
                </div>
              </li>
              @endforeach
              
            </ul>
          </div>
        </div>
        <div class="single_post_content">
          <div class = "chenchu">
          <div class = "logoAGU"><img src = "public/images/logo.png" ></div>
          <div class = "chu000">
            <a>Sinh viên</a>
          </div>
          </div>

          <?php 
             $tintuc_sv = DB::table('tintuc')
            ->join('loaitin', 'loaitin.id', '=', 'tintuc.IDLoaiTin')
            ->where('NoiBat',1)
            ->where('loaitin.id','=',3)
            //->where('loaitin.IDNhomLoaiTin','=',2)
            ->orderBy('created_at','DESC')
            ->select('tintuc.*')
            ->take(6)
            ->get();
            $tinsv = $tintuc_sv->shift();
          ?>
          <div class="single_post_content_left">
            <ul class="business_catgnav  wow fadeInDown">
              <li>
                <figure class="bsbig_fig"><img alt="" src="public/upload/{!! $tinsv->HinhAnh !!}" height="180px" > <span class="overlay"></span>
                  <figcaption> <a href="{!! url('tintuc/'.$tinsv->id.'/'.$tinsv->TieuDeKhongDau) !!}.html">{!! $tinsv->TieuDe !!}</a> </figcaption>
                  <p>{!! $tinsv->TomTat !!}</p>
                </figure>
                <p><a href="{!! URL::route('trangchu.tintucsinhvien') !!}" style="float: right;"> Xem thêm<span class="glyphicon glyphicon-chevron-right"></span></a></p>
              </li>
            </ul>
          </div>
          <div class="single_post_content_right">
            <ul class="spost_nav">
            @foreach($tintuc_sv as $item_sv)
              <li>
                <div class="media wow fadeInDown">
                  <div class="media-body"> <a href="{!! url('tintuc/'.$item_sv->id.'/'.$item_sv->TieuDeKhongDau) !!}.html" class="catg_title">{!! $item_sv->TieuDe !!}</a> </div>
                </div>
              </li>
             @endforeach

            </ul>
          </div>
        </div>
        @include('layout.dangkynhantin')
      </div>
    </div>
@endsection