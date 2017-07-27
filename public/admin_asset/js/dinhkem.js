function dinhkem(){
	$("#dinhkem").change(function(){
		var formData = new FormData($("#quatrinhcongtac")[0]);
		$.ajax({
	        url: "post.uploads.php", type: "POST",
	        data: formData, async: false,
	        success: function(datas) {
	            if(datas=='Failed'){
	                alert('Lỗi không thể Upload hình ảnh.');
	            } else {
	                $("#list_files").prepend(datas);xoadinhkem();
	            }
	        },
	        cache: false, contentType: false, processData: false
	    }).fail(function() {
	        alert('Lỗi không thể Upload hình ảnh.');
	    });
	});
}

function xoadinhkem(){
	$(".xoadinhkem").click(function(){
		var _link = $(this).attr("href");
		var _this = $(this);
		$.get(_link, function(data){
			if(data == 'NO'){
				alert('Không thể xóa');
			} else {
				_this.parents(".row").fadeOut();
			}
		});
	});
}