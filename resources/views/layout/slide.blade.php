<div class="col-lg-8 col-md-8 col-sm-8">
  <div class="slick_slider">

    @foreach($slide as $item)  
    <div class="single_iteam"> <a href="{!! url('silde/'.$item->id.'/'.$item->Ten) !!}.html"> <img src="public/upload/{!! $item->Hinh !!}" alt=""></a>
      <div class="slider_article">
       <h2><a class="slider_tittle" href="{!! url('silde/'.$item->id.'/'.$item->Ten) !!}.html">{!! $item->Ten !!}</a></h2>
        <p>{!! $item->TomTat !!}</p>
      </div>
    </div>
    @endforeach
  </div>
</div>

<div class="col-lg-4 col-md-4 col-sm-4">
  <div class="latest_post ">
    <h2><span><b>Tin mới</b></span></h2>
    <div class="latest_post_container">
      <div id="prev-button"><i class="fa fa-chevron-up"></i></div>
      <ul class="latest_postnav">
      @foreach($slide as $item)
        <li>
          <div class="media">
            <div class="media-body"> <a href="{!! url('silde/'.$item->id.'/'.$item->Ten) !!}.html" class="catg_title">{!! $item->Ten !!}</a> </div>
          </div>
        </li>
      @endforeach
      </ul>
      <div id="next-button"><i class="fa  fa-chevron-down"></i></div>
    </div>
  </div>
</div>