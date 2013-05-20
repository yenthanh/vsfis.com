// JScript File
var highlightbehavior = "TR";
var ns6 = document.getElementById && !document.all;
var ie = document.all;
var pop;

function changeto(e, highlightcolor) {
    source = ie ? event.srcElement : e.target;
    if (source.tagName == "TABLE")
        return;
    while (source.tagName != highlightbehavior && source.tagName != "HTML")
        source = ns6 ? source.parentNode : source.parentElement;
    if (source.style.backgroundColor != highlightcolor && source.id != "ignore") {
        source.style.backgroundColor = highlightcolor;
    }
}

//===============================================

function ValidButtonCheck(field) {
    form = field.form;
    if (field.checked) {
        form.fvotefor.value = field.value;
    } else {
        form.fvotefor.value = '';
        return;
    }

    for (i = 0; i < form.elements.length; i++) {
        if (form.elements[i].type == 'checkbox')
            if (form.name == 'Frm_267525551') {
                if (field.value != '1' && field.value != '2') {
                    if (form.elements[i] != field)
                        if (form.elements[i].checked)
                            form.elements[i].checked = false;
                } else {
                    field.checked = false;
                }
            } else {
                if (form.elements[i] != field)
                    if (form.elements[i].checked)
                        form.elements[i].checked = false;
            }
    }
}

function changeback(e, originalcolor) {
    if (ie && (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "ignore") || source.tagName == "TABLE")
        return;
    else if (ns6 && (contains_ns6(source, e.relatedTarget) || source.id == "ignore"))
        return;
    if (ie && event.toElement != source || ns6 && e.relatedTarget != source)
        source.style.backgroundColor = originalcolor;
}

function openwindow1(url, width, height) {
    var top = (screen.height - height) / 2;
    var left = (screen.width - width) / 2;

    window.open(url, "", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no,left=" + left + ", top=" + top + ", width=" + width + ", height=" + height);
}

/*Chon ngon ngu cho danh muc tin tuc*/

function changeLanguage(Language_ID, Cat_ID) {

    var objHTTP;
    if (window.XMLHttpRequest) {
        objHTTP = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        objHTTP = new ActiveXObject('Microsoft.XMLHttp');
    }

    if (objHTTP != null) {

        var szURL = "EDITOR_XML_Cat_List.aspx";
        var szHttpMethod = "POST";
        var szRequest = Language_ID + "," + Cat_ID;
        objHTTP.open(szHttpMethod, szURL, false);
        objHTTP.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        objHTTP.send(szRequest);
        var szReply = objHTTP.responseText;
        if (szReply != '') {
            var obj = document.getElementById('pEditorCats');
            if (obj != null) {
                obj.innerHTML = szReply;
            }
        }
        objHTTP = null;
        szRequest = null;
        szReply = null;
    }
    return true;
}

/*Hien thi danh muc tin de chon tin lien quan*/

function changeEditorCatNews(EditorCat_ID) {
    var objHTTP;
    if (window.XMLHttpRequest) {
        objHTTP = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        objHTTP = new ActiveXObject('Microsoft.XMLHttp');
    }

    if (objHTTP != null) {

        var szURL = "EDITOR_XML_Relate_News.aspx";
        var szHttpMethod = "POST";
        var szRequest = EditorCat_ID;
        objHTTP.open(szHttpMethod, szURL, false);
        objHTTP.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        objHTTP.send(szRequest);
        var szReply = objHTTP.responseText;
        //alert(szReply);
        if (szReply != '') {
            var obj = document.getElementById("pEditorCatToRelate");
            obj.innerHTML = szReply;
        }
        objHTTP = null;
        szRequest = null;
        szReply = null;
    }
    return true;
}

/*Them moi tin lien quan*/

function AddNews() {
    var obj = document.getElementById("SRelateNewsSource");
    var obj1 = document.getElementById("SRelateNews");
    var optionCounter;
    var blAdd = true;
    var strText = "";
    var intID = "";
    if (obj != null) {
        for (optionCounter = 0; optionCounter < obj.length; optionCounter++) {
            if (obj.options[optionCounter].selected == true) {

                var NewOption = document.createElement("Option");
                NewOption.text = obj.options[optionCounter].text;
                NewOption.value = obj.options[optionCounter].value;
                obj1.options.add(NewOption);
                obj.remove(optionCounter);
                optionCounter = -1;
            }
        }
    }
}

/*Xoa bo tin lien quan*/

function RemoveNews() {
    var obj = document.getElementById("SRelateNews");
    var obj1 = document.getElementById("SRelateNewsSource");
    var optionCounter;
    var blAdd = true;
    var strText = "";
    var intID = "";
    if (obj != null) {
        for (optionCounter = 0; optionCounter < obj.length; optionCounter++) {
            if (obj.options[optionCounter].selected == true) {
                var NewOption = document.createElement("Option");
                NewOption.text = obj.options[optionCounter].text;
                NewOption.value = obj.options[optionCounter].value;
                obj1.options.add(NewOption);
                obj.remove(optionCounter);
                optionCounter = -1;
            }
        }
    }
}

function ClickFormSearch() {
    var idThis = document.getElementById('idList');
    if (idThis.style.display = 'none') {
        idThis.style.display = 'block';
    } else {
        idThis.style.display = 'none';
    }
}

//===============================================

function gen_Image(w, Thumb_W, Photo) {
    var szHTML, tf, it;
    it = '<img src="' + Photo + '_T.jpg' + '" border="0">';
    szHTML = '';
    szHTML += '<table cellSpacing=0 cellPadding=3 width=1 border=0>';
    szHTML += '<tr><td>';
    szHTML += it;
    szHTML += '</td></tr>';
    szHTML += '</table>';

    return szHTML;
}

//===============================================

function removeLeadImage() {
    divImg.innerHTML = '';
    document.aspnetForm.LeadImage.value = '';
    spanDeleteIcon.innerHTML = '';
}

//===============================================

function do_InsertImgEditor(w, Thumb_W, Photo, imageID) {
    divImg.innerHTML = gen_Image(w, Thumb_W, Photo);
    document.aspnetForm.LeadImage.value = imageID;
    spanDeleteIcon.innerHTML = '<img style="cursor:hand" onclick=\"JavaScript:removeLeadImage()\" src=\"/Images/Admin/delete.gif\" border=\"0\" alt="Xóa ảnh">';
}

//===============================================

function removeLeadImageColor() {
    divImgColor.innerHTML = '';
    document.aspnetForm.LeadImageColor.value = '';
    spanDeleteIconColor.innerHTML = '';
}

//===============================================

function do_InsertImgEditorColor(w, Thumb_W, Photo, imageID) {
    divImgColor.innerHTML = gen_Image(w, Thumb_W, Photo);
    document.aspnetForm.LeadImageColor.value = imageID;
    spanDeleteIconColor.innerHTML = '<img style="cursor:hand" onclick=\"JavaScript:removeLeadImageColor()\" src=\"/Images/Admin/delete.gif\" border=\"0\" alt="Xóa ảnh">';
}

//Lampn Add Vote Question

function Add_New_Answer(element) {
    document.aspnetForm.hiddenNo.value = parseInt(document.aspnetForm.hiddenNo.value) + 1;
    var Editor_Num = document.aspnetForm.hiddenNo.value;
    var obj = document.getElementById(element);
    var objHTTP;
    if (window.XMLHttpRequest) {
        objHTTP = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        objHTTP = new ActiveXObject('Microsoft.XMLHttp');
    }

    if (objHTTP != null) {
        var szURL = "Add_Question_XML.aspx";
        var szHttpMethod = "POST";
        var szRequest = Editor_Num;
        objHTTP.open(szHttpMethod, szURL, false);
        objHTTP.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        objHTTP.send(szRequest);
        var szReply = objHTTP.responseText;
        //alert(szReply);
        //alert(obj);
        if (szReply != '') {
            obj.innerHTML = obj.innerHTML + szReply;
        }
        objHTTP = null;
        szRequest = null;
        szReply = null;
    }
    return true;
}

function Delete_answer_New(sub_Answer) {
    var obj = document.getElementById(sub_Answer);
    alert(obj);
    obj.innerHTML = '';
    obj.outnerHTML = '';
    return true;
}

//function OpenQuestiontbl()
//{
//    if(document.all.tblquestionFaqs.style.display == "none")
//    {
//		document.all.tblquestionFaqs.style.display = "block";
//    }
//    else
//    {        
//        document.getElementById('tblquestionFaqs').style.display = "none";
//	}
//}
//

function Playfile(sfile) {
    document.getElementById('mediaplayer').src.value = sfile;
}

function MChange(Url) {
    document.getElementById('MPlayer').innerHTML = '<embed width="352px" hspace="0" height="355px" align="middle" showdisplay="0" showstatusbar="1" showcontrols="1" autostart="-1" autohref="true" correction="full" wmode="transparent" type="application/x-mplayer2" src="' + Url + '"/>';
}

//dùng cho video xem ngoai trang chu--------------------//

function MVovieOnline(Url) {

    var strDoc;
    strDoc = '<object height="265" type="application/x-mplayer2" align="middle" width="262" id="mediaplayer" codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701" classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6">';
    strDoc += '<param value="' + Url + '" name="URL" />';
    strDoc += '<param value="0" name="fullScreen"/>';
    strDoc += '<param value="-1" name="autoStart"/>';
    strDoc += '<param value="1000" name="loop"/>';
    strDoc += '<param value="50" name="volume"/>';
    strDoc += '<param value="0" name="stretchToFit"/>';
    strDoc += '<param value="0" name="windowlessVideo"/>';
    strDoc += '<param value="-1" name="enabled"/>';
    strDoc += '<param value="-1" name="enableContextMenu"/>';
    strDoc += '<param value="1" name="rate"/>';
    strDoc += '<param value="0" name="balance"/>';
    strDoc += '<param value="-1" name="currentPosition"/>';
    strDoc += '<param value="" name="defaultFrame"/>';
    strDoc += '<param value="1000" name="playCount"/>';
    strDoc += '<param value="0" name="currentMarker"/>';
    strDoc += '<param value="-1" name="invokeURLs"/>';
    strDoc += '<param value="" name="baseURL"/>';
    strDoc += '<param value="0" name="mute"/>';
    strDoc += '<param value="Full" name="uiMode"/>';
    strDoc += '<param value="" name="SAMIStyle"/>';
    strDoc += '<param value="" name="SAMILang"/>';
    strDoc += '<param value="" name="SAMIFilename"/>';
    strDoc += '<param value="" name="captioningID"/>';
    strDoc += '<param value="transparent" name="wmode"/>';
    strDoc += '<param value="always" name="allowscriptaccess">';
    strDoc += '<param value="0" name="enableErrorDialogs"/>';
    strDoc += '<param value="1" name="ShowControls"/>';
    strDoc += '<embed height="265" align="middle" width="262" uiMode="Full"  wmode="transparent" allowscriptaccess="always" enablecontextmenu="-1" enabled="-1" windowlessvideo="fit" stretchtofit="100%" volume="100" autostart="1"  autohref="true" correction="full"  url="none.wmv" src="' + Url + '" /></object>';
    document.getElementById('idTHOnline').innerHTML = strDoc;
}

function PSAChange(Url, ImgDes) {

    document.getElementById('idImgView').innerHTML = '<Img width="420px"  style="border: 1px solid #8A8A8A;" src="' + Url + '"/>';
    document.getElementById('idImgDes').innerHTML = '<p align="justify">' + ImgDes + '</p>';
}

function checkRegMail() {
    if (aspnetForm.ctl00$Left$txtNewsletter.value == '') {
        alert('Nhập địa chỉ Email của bạn');
        aspnetForm.ctl00$Left$txtNewsletter.focus();
        return false;
    }
    return true;
}

/*=======================================================*/

function PopImage(id, cid, proid) {
    window.open("Product_Popup.aspx?proid=" + proid + "&id=" + id + "&cid=" + cid, "image", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=1,height=1,left = 0,top = 0");
}

/*=======================================================*/

function PopImage_1(id, cid, proid) {
    window.open("eProduct_Popup.aspx?proid=" + proid + "&id=" + id + "&cid=" + cid, "image", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=1,height=1,left = 0,top = 0");
}

/*=======================================================*/

function displayStatus(strStatus) {
    window.status = strStatus;
}

/*=======================================================*/

function BlockLeftMenu(tbName, session_com) {
    if (document.getElementById("tbAbout") != null) {
        document.getElementById("tbAbout").style.display = "none";
    }
    if (document.getElementById("tbCIntroduce") != null) {
        document.getElementById("tbCIntroduce").style.display = "none";
    }
    if (document.getElementById("tbNews") != null) {
        document.getElementById("tbNews").style.display = "none";
    }
//    //if(session_com != 3 && session_com != 5 && session_com != 2)
//    if(session_com != 3)
//    {
//       document.getElementById("tbProduct").style.display="none"; 
//    }else if(session_com == 3)
//    {
//        document.getElementById("tbPhonoi").style.display="none";
//    }
    if (document.getElementById(tbName) != null) {
        document.getElementById(tbName).style.display = "block";
    }

}

function BlockAllLeftMenu(session_com) {
    if (document.getElementById("tbAbout") != null) {
        document.getElementById("tbAbout").style.display = "none";
    }
    if (document.getElementById("tbCIntroduce") != null) {
        document.getElementById("tbCIntroduce").style.display = "none";
    }
    if (document.getElementById("tbNews") != null) {
        document.getElementById("tbNews").style.display = "none";
    }
//    //if(session_com != 3 && session_com != 5 && session_com != 2)
//    if(session_com != 3)
//    {
//       document.getElementById("tbProduct").style.display="none"; 
//    }else if(session_com == 3)
//    {
//        document.getElementById("tbPhonoi").style.display="none";        
//    }        
}

/*============================EN===========================*/

function eBlockLeftMenu(tbName, session_com) {
    document.getElementById("etbAbout").style.display = "none";
    document.getElementById("etbCIntroduce").style.display = "none";
    document.getElementById("etbNews").style.display = "none";
    //if(session_com != 3 && session_com != 5 && session_com != 2)
    if (session_com != 15) {
        document.getElementById("etbProduct").style.display = "none";
    } else if (session_com == 15) {
        document.getElementById("etbPhonoi").style.display = "none";
    }
    document.getElementById(tbName).style.display = "block";
}

function eBlockAllLeftMenu(session_com) {
    if (document.getElementById("etbAbout") != null) {
        document.getElementById("etbAbout").style.display = "none";
    }
    if (document.getElementById("etbCIntroduce") != null) {
        document.getElementById("etbCIntroduce").style.display = "none";
    }
    if (document.getElementById("etbNews") != null) {
        document.getElementById("etbNews").style.display = "none";
    }

    //if(session_com != 3 && session_com != 5 && session_com != 2)
    if (session_com != 15) {
        document.getElementById("etbProduct").style.display = "none";
    } else if (session_com == 15) {
        document.getElementById("etbPhonoi").style.display = "none";
    }
}

/*============================EN===========================*/

function PopupVote(strOpen, listid) {
    var obj = document.getElementById(listid);
    var objCheck = true;
    if (obj != null) {
        var ListOption = obj.getElementsByTagName("input");
        for (i = 0; i < ListOption.length; i++) {
            if (ListOption[i].checked == true) {
                objCheck = false;
                window.open(strOpen + '&answerid=' + ListOption[i].value, "Info", "status=1, width=500,height=250,toolbar=no,menubar=no,location=no,top=0,left=0");
            }
        }
        if (!objCheck) {
            window.open(strOpen, "Info", "status=1, width=500,height=250,toolbar=no,menubar=no,location=no,top=0,left=0");
        } else {
            alert("Bạn phải chọn đáp án!");
        }
    } else
        window.open(strOpen, "Info", "status=0, width=500,height=250,toolbar=no,menubar=no,location=no,top=0,left=0");
}

function EmailToFriend(strOpen) {
    window.open(strOpen, "Info", "status=0, width=620,height=420,toolbar=no,menubar=no,location=no, top=0,left=0");
}

function OpenPopupNewsPsa(strOpen) {
    window.open(strOpen, "Info", "status=0, width=660,height=650,toolbar=no,menubar=no,scrollbars=1,resizable=0,location=no,top=0,left=0");
}

function OpenWeather(strOpen) {
    window.open(strOpen, "Info", "status=0, toolbar=0, resizable=0, width=400,height=300,toolbar=no,menubar=no,scrollbars=1,location=no, ,top=0,left=0");
    //window.focus();

}

/*=====================Menu========================*/

function swap(td_name, image) {
    document.getElementById(td_name).style.background = image;
}

function bgoff(td_name, image) {
    document.getElementById(td_name).style.background = image;
}
/*=================================================*/