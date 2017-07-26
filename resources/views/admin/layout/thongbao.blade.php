@if(count($errors)> 0)
  <div class="callout callout-danger">
    @foreach($errors->all() as $err)
      {!! $err !!} <br>
    @endforeach
  </div>
@endif

@if(Session::has('thongbao'))
  <div class="callout callout-{!! Session::get('thongbao_level') !!}">
    {!! Session::get('thongbao') !!}
  </div>
@endif