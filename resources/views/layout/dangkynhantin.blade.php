<div class="single_post_content">
  <h3><img src ="public/images/right_arrow.jpg" style ="width: 32px; height: 32px;"/>&nbsp;&nbsp;Đăng ký nhận tin</h3>
  <div class="line"></div>
  <h4>Nhập địa chỉ email của bạn để nhận thông báo<img style ="width: 42px; height: 20px;" src = "public/images/arrow_down.gif "/></h4>
  <form action="{!! route('trangchu.dangkynhantin') !!}" method="post" class="navbar-form navbar-left" role="search">
     <input type="hidden" name="_token" value="{!! csrf_token() !!}" />
    <div class="form-group">
      <input style = "width: 400px;" type="email" name="Email" class="form-control" placeholder="Nhập email...">
    </div>
    &nbsp;
    <button name ="btn-DangKy" type="submit" class="btn btn-default" style="color: #000; margin: auto; border-radius: 5px 5px 5px 5px;">Đăng ký</button>
  </form>
  <div class = "MXH">
    <img style ="width: 30px; height: 30px;" src = "public/images/fb.png "/>
    <img style ="width: 30px; height: 30px;" src = "public/images/g+.png "/>
    <img style ="width: 30px; height: 30px;" src = "public/images/twitter.png "/>
  </div>
</div>