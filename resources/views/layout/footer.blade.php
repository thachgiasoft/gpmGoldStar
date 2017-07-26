<footer id="footer">
    <div class="footer_top">
      <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-4">
          <div class="footer_widget wow fadeInLeftBig">
            <h2>Thông tin</h2>
            {!! $thongtin->ThongTin !!}
          </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4">
          <div class="footer_widget wow fadeInDown">
            <!-- <h2>Liên kết ngoài</h2>
            <ul class="tag_nav">
              <li><a href="#">Trung tâm tin học </a></li>
              <li><a href="#">Trung tâm ngoại ngữ</a></li>
            </ul> -->
          </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4">
          <div class="footer_widget wow fadeInRightBig">
            <h2>Thống kê lượt truy cập</h2>
            
          </div>
        </div>
      </div>
    </div>
    <div class="footer_bottom">

      <p class="copyright" style = "color: white;">Copyright &copy; 2017 <a href="{!! $cauhinh->LinkBanQuyen !!}" target="_blank"><b>{!! $cauhinh->BanQuyen !!}</b></a></p>
      <p class="developer" style = "color: white;">{!! $cauhinh->ThietKe !!}</p>
    </div>
  </footer>