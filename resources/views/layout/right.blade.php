<div class="col-lg-4 col-md-4 col-sm-4">
        <aside class="right_content">
          <div class="single_sidebar wow fadeInDown">
            <h2><a href = "https://www.facebook.com/osa.hcmus/?ref=ts&fref=ts" style = "color: #fff;" target="_blank"><span class="fa fa-facebook-square">&nbsp;&nbsp;Facebook</span></a></h2>
            <ul>
              <a href = "https://www.facebook.com/osa.hcmus/?ref=ts&fref=ts" target="_blank"><img src = "public/images/face.png" style="width: 100%; height: 100%;"/></a>
            </ul>
          </div>

          <div class="single_sidebar wow fadeInDown">
            <h2><span>Sinh viên tiêu biểu</span></h2>
            <div class="slick_slider">
              @foreach($slidesinhvien as $item)  
              <div class="single_iteam"> 
                  <img src="public/upload/{!! $item->Hinh !!}" alt="HTML">
              </div>
              @endforeach
            </div>
          </div>
          
         
        </aside>
      </div>
     <!--  <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="latest_post ">
          <h2><span><b>Nộp đơn trực tuyến</b></span></h2>
          <div class="latest_post_container">
              <div class="form-group">
              <label>Mã số sinh viên</label>
              <input class="form-control" placeholder="Nhập mã số sinh viên..." type="text" name="MSSV">
              <label>Password</label>
              <input class="form-control" placeholder="Nhập mật khẩu..." type="password" name="password">
            </div>
          </div>
        </div>
      </div> -->
    </div>