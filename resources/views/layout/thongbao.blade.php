@if(count($errors)> 0)
  <div class="alert alert-danger">
    @foreach($errors->all() as $err)
      {!! $err !!} <br>
    @endforeach
  </div>
@endif

@if(Session::has('thongbao'))
  <div class="alert alert-{!! Session::get('thongbao_level') !!}">
    {!! Session::get('thongbao') !!}
  </div>
@endif