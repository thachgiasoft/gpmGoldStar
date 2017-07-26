@extends('admin.layout.index')
@section('content')
<div class="content-wrapper">
    <section class="content-header">
      <h1>
        Danh sách
        <small>Preview</small>
      </h1>
     <ol class="" style="float: right;margin-top: -10px;list-style-type: none;">
        <li class="btn btn-primary">
          <a href="admin/sinhvien/danhsach"><i class="glyphicon glyphicon-floppy-open" style="color: white;"></i><b style="color: white;"> Danh sách</b></a>
        </li>
      </ol>
    </section>
    <!-- Main content -->
    <section class="content">
      <div class="row">
        <!-- left column -->
        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Thêm sinh viên</h3>
            </div>
            <form role="form">
                <div class="box-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                        <input class="form-control" placeholder="Email" type="email">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Password</label>
                      <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                    </div>
                    <div class="form-group">
                      <label>Textarea</label>
                      <textarea class="form-control" rows="3" placeholder="Enter ..."></textarea>
                    </div>
                     <div class="form-group">
                      <label>Date:</label>

                      <div class="input-group date">
                        <div class="input-group-addon">
                          <i class="fa fa-calendar"></i>
                        </div>
                        <input type="text" class="form-control pull-right" id="datepicker">
                      </div>
                      <!-- /.input group -->
                    </div>
                    <div class="form-group">
                      <label>Select</label>
                      <select class="form-control">
                        <option>option 1</option>
                        <option>option 2</option>
                        <option>option 3</option>
                        <option>option 4</option>
                        <option>option 5</option>
                      </select>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputFile">File input</label>
                      <input type="file" id="exampleInputFile">
                    </div>
                    <textarea id="editor1" name="editor1" rows="10" cols="80"></textarea>
                    <div class="checkbox">
                      <label>
                        <input type="checkbox"> Check me out
                      </label>
                    </div>
                  </div>

                  <!-- /.box-body -->

                  <div class="box-footer">
                    <button type="submit" class="btn btn-primary">Thêm</button>
                    <button type="reset" class="btn btn-danger">Làm lại</button>
                  </div>
                </form>
            </div>
        </div>
        </div>
    </section>
</div>
@endsection
@section('script')
<script>
  $(function () {
    // Replace the <textarea id="editor1"> with a CKEditor
    // instance, using default configuration.
    CKEDITOR.replace('editor1');
    //bootstrap WYSIHTML5 - text editor
    $(".textarea").wysihtml5();
  });
</script>
@endsection