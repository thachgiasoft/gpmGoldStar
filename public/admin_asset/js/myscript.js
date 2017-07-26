$("div.callout").delay(3000).slideUp(); //ẩn thông báo 3s

//xác nhận xóa
function thongbaoxoa(msg){
	if(window.confirm(msg))
	{
		return true;
	}
	return false;
}

//thông báo
function thongbao(msg){
	if(window.confirm(msg))
	{
		return true;
	}
	return false;
}

//check tất cả theo dòng
function checkAll()
{
     var checkboxes = document.getElementsByTagName('input'), val = null;    
     for (var i = 0; i < checkboxes.length; i++)
     {
         if (checkboxes[i].type == 'checkbox')
         {
             if (val === null) val = checkboxes[i].checked;
             checkboxes[i].checked = val;
         }
     }
}