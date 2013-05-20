// stardevelop.com Live Help International Copyright 2003-2010
// Live Help JavaScript v3.90.4 - Uncompressed
// Requirement: jQuery 1.40.1

// Load Web Settings w/ AJAX
var chatWidth = '625';
var chatHeight = '435';
var hAlign = 'right';
var vAlign = 'center';
var currentStatus = '';
var offlineRedirect = '';
var locale = 'en';
// Default Language
var OfflineEmail = 1;
var visitorRefresh = 15 * 1000;
var initiateOpen = 0;
var initiateAuto = 0;

// Local Variables
var LiveHelpWindow;
var department = '';
var server = '';
var template = '';

// Popup Window
var posLeft = (screen.width - chatWidth) / 2;
var posTop = (screen.height - chatHeight) / 2;
var size = 'height=' + chatHeight + ',width=' + chatWidth + ',top=' + posTop + ',left=' + posLeft + ',resizable=1,toolbar=0,menubar=0';

// Initiate Chat
var InitiateChatTimer;
var trackingInitalized = 0;
var initiateStatus = '';
var topMargin = 10;
var leftMargin = 10;
var layerHeight = 229;
var layerWidth = 323;
var browserWidth = 0;
var browserHeight = 0;

// Visitor Tracking
var TrackingTimer;
var timeStart = currentTime();
var timeElapsed;

var countTracker = 0;

// jQuery Document Ready
$(document).ready(function() {

    // AJAX Configuration
    $.ajaxSetup({
        cache: false
    });

    // Load Settings via. AJAX
    var time = currentTime();
    var source = $("script[src*='modules/livehelp/plugins/whmcs/jquery.livehelp.js']").attr('src');
    var match = source.split('jquery.livehelp.js');
    if (match != null) {
        server = match[0];
    }

    var initiateChatHtml = '<!-- stardevelop.com Live Help International Copyright - All Rights Reserved //--> \
<!--  BEGIN stardevelop.com Live Help Messenger Code - Copyright - NOT PERMITTED TO MODIFY IMAGE MAP/CODE/LINKS //--> \
<div id="initiateChatLiveHelp" align="left" style="position:absolute; left:10px; top:10px; visibility:hidden; z-index:5000;"> \
  <map name="LiveHelpInitiateChatMap" id="LiveHelpInitiateChatMap"> \
    <area shape="rect" coords="50,210,212,223" href="http://livehelp.stardevelop.com" target="_blank" alt="stardevelop.com Live Help"/> \
    <area shape="rect" coords="113,183,197,206" href="#" onclick="openLiveHelp();updateInitiateStatus(\'Accepted\');return false;" alt="Accept"/> \
    <area shape="rect" coords="206,183,285,206" href="#" onclick="updateInitiateStatus(\'Declined\');return false;" alt="Decline"/> \
    <area shape="rect" coords="263,86,301,104" href="#" onclick="updateInitiateStatus(\'Declined\');return false;" alt="Close"/> \
  </map> \
  <div id="InitiateText" align="center" style="position:relative; left:40px; top:145px; width:256px; height:35px; z-index:5001; text-align:center; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; font-weight: bold;">Do you have any questions that I can help you with?</div> \
  <img src="' + server + '../../locale/en/images/InitateChat.gif" alt="stardevelop.com Live Help" width="323" height="229" border="0" usemap="#LiveHelpInitiateChatMap"/></div> \
<!--  END stardevelop.com Live Help Messenger Code - Copyright - NOT PERMITTED TO MODIFY IMAGE MAP/CODE/LINKS //-->';

    $('body').append(initiateChatHtml);

    $.ajax({
        url: server + '../../include/settings.php?DEPARTMENT' + department,
        dataType: 'script',
        error: function() {
            // AJAX Error
        },
        success: function() {
            // Settings Updated
            updateImageTitle();
            jQuery(document).trigger('LiveHelp.SettingsUpdated');
        }
    });

    // Setup Initiate Chat / Animation
    $(window).bind("resize", resetPosition);

    // Events
    $('.LiveHelpButton').click(function() {
        openLiveHelp($(this));
        return false;
    });

    $('.LiveHelpCallButton').click(function() {
        openLiveHelp($(this), '', 'call.php');
        return false;
    });

    // Visitor Tracking
    visitorTracking();
});

// Initiate Chat

function updatePosition(objID) {

    var offset = $('#' + objID).offset();
    var currentY = parseInt(offset.top);
    var currentX = parseInt(offset.left);
    var scrollTop = $(window).scrollTop();
    var scrollLeft = $(window).scrollLeft();

    var newTargetY = scrollTop + topMargin;
    var newTargetX = scrollLeft + leftMargin;
    if (currentY != newTargetY || currentX != newTargetX) {
        if (this.targetY != newTargetY || this.targetX != newTargetX) {

            this.targetY = newTargetY;
            this.targetX = newTargetX;

            var now = new Date();
            Y = this.targetY - currentY;
            X = this.targetX - currentX;

            C = Math.PI / 2400;
            D = now.getTime();
            if (Math.abs(Y) > browserHeight) {
                E = Y > 0 ? this.targetY - browserHeight : this.targetY + browserHeight;
                Y = Y > 0 ? browserHeight : -browserHeight;
            } else {
                E = currentY;
            }
            if (Math.abs(X) > browserWidth) {
                F = X > 0 ? this.targetX - browserWidth : this.targetX + browserWidth;
                X = X > 0 ? browserWidth : -browserWidth;
            } else {
                F = currentX;
            }
        }

        // Update Positions
        var now = new Date();
        var newY = Y * Math.sin(C * (now.getTime() - D)) + E;
        var newX = X * Math.sin(C * (now.getTime() - D)) + F;
        newY = Math.round(newY);
        newX = Math.round(newX);

        // TODO: jQuery Animation
        if ((Y > 0 && newY > currentY) || (Y < 0 && newY < currentY)) {
            $('#' + objID).css('top', newY + 'px');
        }
        if ((X > 0 && newX > currentX) || (X < 0 && newX < currentX)) {
            $('#' + objID).css('left', newX + 'px');
        }
    }
}

function resetPosition() {

    var width = 0;
    var height = 0;
    var d = document.documentElement;
    width = self.innerWidth || (d && d.clientWidth) || document.body.clientWidth;
    height = self.innerHeight || (d && d.clientHeight) || document.body.clientHeight;
    browserWidth = width;
    browserHeight = height;

    if (hAlign == 'right') {
        leftMargin = width - layerWidth - 30;
    } else if (hAlign == 'middle') {
        leftMargin = Math.round((width - 20) / 2) - Math.round(layerWidth / 2);
    }
    if (vAlign == 'bottom') {
        topMargin = height - layerHeight - 55;
    } else if (vAlign == 'center') {
        topMargin = Math.round((height - 20) / 2) - Math.round(layerHeight / 2);
    }

}

function visitorTracking() {

    var time = currentTime();
    var source = $("script[src*='modules/livehelp/plugins/whmcs/jquery.livehelp.js']").attr('src');
    var match = source.split('jquery.livehelp.js');
    if (match != null) {
        server = match[0];
    }

    var title = document.title.substring(0, 150);
    var localtime = getTimezone();
    var referrer;
    if (document.referrer.indexOf(document.location.hostname) >= 0) {
        referrer = '';
    } else {
        referrer = document.referrer;
    }

    // Visitor Tracking URL and POST Data
    var trackingURL = server + 'status.php';
    var trackingData = '?JS=1&DEPARTMENT=' + department + '&INITIATE=' + initiateStatus;
    if (trackingInitalized == 0) {
        trackingData = '?JS=1&TITLE=' + encodeURI(escape(title)) + '&URL=' + encodeURI(escape(document.location)) + '&REFERRER=' + encodeURI(escape(referrer)) + '&DEPARTMENT=' + department + '&INITIATE=' + initiateStatus + '&WIDTH=' + screen.width + '&HEIGHT=' + screen.height + '&TIME=' + time;
        trackingInitalized = 1;
    }

    // AJAX Visitor Tracking
    $.ajax({
        url: trackingURL + trackingData,
        dataType: 'script',
        error: function() {
            // AJAX Error
        },
        success: function() {
            if (trackingInitalized == 0) {
                trackingInitalized = 1;
            }
        }
    });

    timeElapsed = time - timeStart;
    if (timeElapsed < 90 * 60 * 1000) {
        window.clearTimeout(TrackingTimer);
        TrackingTimer = window.setTimeout('visitorTracking();', visitorRefresh);
    }

}

function getTimezone() {
    var datetime = new Date();
    if (datetime) {
        return datetime.getTimezoneOffset();
    } else {
        return '';
    }
}

function currentTime() {
    var date = new Date();
    return date.getTime();
}

// Initiate Chat

function displayInitiateChat() {

    if (initiateOpen == 0) {
        resetPosition();
        InitiateChatTimer = window.setInterval('updatePosition("initiateChatLiveHelp");', 10);
        $('#initiateChatLiveHelp').css('visibility', 'visible');
        updateInitiateStatus('Opened');
        initiateOpen = 1;
        initiateLoaded = 0;
        initiateAuto = 0;
    }

}

function updateInitiateStatus(status) {

    // Update Initiate Chat Status
    initiateStatus = status;
    visitorTracking();
    if (status == 'Accepted' || status == 'Declined') {
        $('#initiateChatLiveHelp').css('visibility', 'hidden');
    }
}

// Change Status Image

function changeStatus(status) {

    if (currentStatus != '' && currentStatus != status) {

        // Update Status
        currentStatus = status;

        $('.LiveHelpStatus').each(function() {
            var statusURL = $(this).attr('src');

            // Process Query String
            var regEx = /^[^?#]+\?([^#]+)/i;
            var match = regEx.exec(statusURL);
            if (match != null) {
                query = '?' + match[1] + '&_=' + currentTime();
            } else {
                query = '?_=' + currentTime();
            }

            // Update Status Image
            $(this).attr('src', server + '../../include/status.php' + query);

            // Title / Alt Attributes
            updateImageTitle();

        });

    }
}

function updateImageTitle() {

    $('.LiveHelpStatus').each(function() {

        // Title / Alt Attributes
        var status = currentStatus;
        if (status == 'BRB') {
            status = 'Be Right Back';
        }
        ;
        $(this).attr('title', 'Live Help - ' + status);
        $(this).attr('alt', 'Live Help - ' + status);

    });

}

// Offline Email Redirection
if (offlineRedirect != '') {
    if (/^(?:^[\-!#$%&'*+\\.\/0-9=?A-Z^_`a-z{|}~]+@[\-!#$%&'*+\\\/0-9=?A-Z^_`a-z{|}~]+\.[\-!#$%&'*+\\.\/0-9=?A-Z^_`a-z{|}~]+$)$/i.test(offlineRedirect)) {
        offlineRedirect = 'mailto:' + offlineRedirect;
    }
    OfflineEmail = 0;
}

// Get URL Parameter

function getParameterByName(url, name) {
    name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
    var ex = '[\\?&]' + name + '=([^&#]*)';
    var regex = new RegExp(ex);
    var results = regex.exec(url);
    if (results == null) {
        return '';
    } else {
        return decodeURIComponent(results[1].replace(/\+/g, ' '));
    }
}

// Live Help Popup Window

function openLiveHelp(obj, department, location) {

    // TODO Window Name Invalid in IE6 When Domain Included
    var windowName = 'LiveHelp'; // + document.location.hostname;

    if (typeof obj != 'undefined') {
        var css = obj.attr('class');
        var template = css.split(' ')[1];

        var src = obj.children('img.LiveHelpStatus').attr('src');
        var department = getParameterByName(src, 'DEPARTMENT');

    } else {
        var template = this.template;
    }

    if (OfflineEmail == 0 && currentStatus != 'Online') {
        if (offlineRedirect != '') {
            document.location = offlineRedirect;
        }
        return false;
    } else {

        if (typeof location == 'undefined' || location == '') {
            var location = 'index.php';
        }
        if (typeof department == 'undefined' || department == '') {
            var department = '';
        } else {
            department = '&DEPARTMENT=' + department;
        }
        if (typeof template == 'undefined' || template == '') {
            var template = '';
        } else {
            template = '&TEMPLATE=' + template;
        }

        // TODO: Remove All # invalid characters
        LiveHelpWindow = window.open(server + '../../' + location + '?LANGUAGE=' + locale + department + template, windowName, size);

    }

    if (LiveHelpWindow) {
        LiveHelpWindow.opener = self;
    }
}