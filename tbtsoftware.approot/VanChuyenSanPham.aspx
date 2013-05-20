<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AboutUs.Master" CodeBehind="VanChuyenSanPham.aspx.cs"
         Inherits="MinhPham.Web.BepNhaBan.VanChuyenSanPham" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('a[href^=van-chuyen-san-pham]').addClass('active');
        });
    </script>
    <link rel="stylesheet" type="text/css" media="screen" href="/StyleLibrary/RootStyles/Css/AboutUs.css" />
    <div class="ve-chung-toi" id="TextHTML-Module">
        <div class="title">
            <span>Chính sách vận chuyển & giao hàng</span></div>
        <div class="defaultContent TextHTML-content">
            <p>
                Nhằm tăng thêm quyền lợi, sự thuận tiện và dễ dàng cho quý khách khi mua hàng tại
                bepnhaban.vn. Chúng tôi hỗ trợ giao hàng đến tận tay khách hàng trên toàn quốc.</p>
            <div>
                &nbsp;</div>
            <p>
                <span style="font-size: 16px;"><strong>1. Với địa chỉ nhận hàng ở thị xã Quảng Yên nằm
                                                   trong bán kính &lt; 25 Km từ các cửa hàng của bepnhaban</strong></span></p>
            <div>
                &nbsp;</div>
            <div>
                <ul style="line-height: 1.5;" class="item_list">
                    <li><strong>bepnhaban giao hàng miễn phí với mọi đơn hàng.</strong></li>
                    <li><span style="line-height: 1.5;">Hàng sẽ được giao tới tay quý khách chậm nhất trong
                            ngày quý khách đặt hàng.</span></li>
                </ul>
            </div>
            <p>
                <span style="font-size: 16px;"><strong>2. Với địa chỉ nhận hàng ngoài bán kính 25 Km
                                                   tính từ các cửa hàng của Bếp Nhà Bạn</strong></span></p>
            <div>
                &nbsp;</div>
            <div>
                <ul style="line-height: 1.5;" class="item_list">
                    <li>bepnhaban sẽ sử dụng dịch vụ chuyển phát nhanh để chuyển hàng tới địa chỉ của quý
                        khách.&nbsp;</li>
                    <li>Chi phí vận chuyển được tính theo bảng giá của Công ty chuyển phát</li>
                    <li>Chi phí này sẽ được Bếp Nhà Bạn thông báo và xác nhận với quý khách trước khi quý
                        khách tiến hành thanh toán và Bếp Nhà Bạn tiến hành gửi hàng.</li>
                    <li>Thời gian nhận hàng sẽ từ 1-3 ngày tùy vào khoảng cách vận chuyển.</li>
                </ul>
            </div><br />
            <div>
                <p>
                    Trung thực &ndash; Uy tín là cam kết bán hàng của Bếp Nhà Bạn. Nếu có bất kì vấn đề
                    gì chưa hài lòng, quý khách vui lòng liên hệ với chúng tôi theo thông tin:</p>
            </div>
            <div>
                &nbsp;</div>
            <p>
                <b>Công ty TNHH TM & DV Bếp Nhà Bạn</b></p>
            <p>
                Địa chỉ: 109 Nguyễn Bình - Quảng Yên - Quảng Ninh</p>
            <p>
                Tel: (033) 355-90-96 &ndash;Email: info@bepnhaban.vn</p>
            <p><br />
                Trân trọng cám ơn quý khách.</p>
            <p>
                bepnhaban rất hân hạnh được phục vụ quý khách.</p>
        </div>
        <br />
    </div>
</asp:Content>