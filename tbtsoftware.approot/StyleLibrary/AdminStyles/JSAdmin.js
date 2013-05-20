// JScript File
function checkAllGroupItem(groupID, obj) {
    var objValue = obj.value;
    if (!isNaN(groupID)) {
        if (objValue != "0") {
            for (var i = 0; i < aspnetForm.elements.length; i++) {
                if ((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].id == groupID)) {
                    aspnetForm.elements[i].checked = true;
                }
            }
            obj.value = "0";
        } else {
            for (var i = 0; i < aspnetForm.elements.length; i++) {
                if ((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].id == groupID)) {
                    aspnetForm.elements[i].checked = false;
                }
            }
            obj.value = "1";
        }
    }
}

//---------------------------------------------------------------	

function checkDeleteAll(aspnetForm) {
    if (aspnetForm.chb_DeleteAll.checked == true) {
        for (var i = 0; i < aspnetForm.elements.length; i++) {
            if ((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].value == "delete")) {
                aspnetForm.elements[i].checked = true;
            }
        }
    } else {
        for (var i = 0; i < aspnetForm.elements.length; i++) {
            if ((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].value == "delete")) {
                aspnetForm.elements[i].checked = false;
            }
        }
    }
}

//---------------------------------------------------------------

function checkDelete(aspnetForm) {
    var check = false;
    for (var i = 0; i < aspnetForm.elements.length; i++) {
        if ((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].checked == true) && (aspnetForm.elements[i].value == "delete")) {
            check = true;
        }
    }

    if (!check) {
        alert('Bạn phải chọn ít nhất một bản ghi cần xóa');
        return false;
    }
    answer = confirm('Bạn có muốn xóa không?');
    if (!answer) {
        return false;
    }
    return true;
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////