<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs"
    Inherits="MinhPham.Web.BepNhaBan.Header" %>
<link href="/StyleLibrary/RootStyles/Css/HeaderBar_Simple.css" rel="stylesheet"
    type="text/css" />
  <script type="text/javascript">
      $(document).ready(function () {
          var x = querystring('id');
          if (x == "")
              {
              $('a[title^=default]').addClass('active');
          }
          else if (x == "corporate") {
              $('a[title^=corporate]').addClass('active');
          }
          else if (x == "services") {
              $('a[title^=services]').addClass('active');
          }
          else if (x == "contactus") {
              $('a[title^=contactus]').addClass('active');
          }
          else if (x == "recuitment") {
              $('a[title^=recuitment]').addClass('active');
          }
      });
      function querystring(key) {
          var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
          var r = [], m;
          while ((m = re.exec(document.location.search)) != null) r.push(m[1]);
          return r;
      }
  </script>
<div class="header">
    <div class="headerBg fixPNG">
        <div class="headerWidth">
            <div class="headerTop">
                <div class="headerLogo fl fixPNG">
                    <a href="Default.aspx">
                        <img height="115" src="/StyleLibrary/RootStyles/Images/header/logo.png" /></a>

                </div>
                <div class="header-selectors-wrapper">
          <div class="language-selector">
                    <ul class="language-list">
                        <li>
                            <asp:LinkButton ID="lbtvn" runat="server" OnClick="lbtvn_Click"> <img src="/StyleLibrary/RootStyles/Images/commons/vn.png " class="selected" alt="Vietnamese" title="Vietnamese"></asp:LinkButton></li><li> &nbsp;&nbsp;</li>
                        <li>
                            
                              <asp:LinkButton ID="btnen" runat="server" OnClick="lbten_Click"> <img src="/StyleLibrary/RootStyles/Images/commons/us.png " alt="English" title="English"></asp:LinkButton>
                        </li><li> &nbsp;&nbsp;</li>
                        <li>
                                    <asp:LinkButton ID="lbtnjp" runat="server" OnClick="lbtjp_Click">
                            <img src="/StyleLibrary/RootStyles/Images/commons/jp.png" alt="Japan" title="Japan">
</asp:LinkButton>
                        </li>
                    </ul>

                </div>
        
    </div>
            
            <%--      <div class="headerTabMenu fl">
                    <a class="buttonDeal buttonDealactive" href="http://muachung.vn/"><span class="ichome">
                        Trang chủ</span> </a><a class="buttonDeal lastButtonDeal" href="http://muachung.vn/san-pham-du-lich.html">
                            <span class="ictour">Du lịch </span></a>
                    <div class="c">
                    </div>
                </div>
       <div class="headerInfo mLeft10">
                    <div class="bgall">
                        <div class="bleft">
                            <div class="content">
                                <a title="Vào quản lý cá nhân của hanguyen.ba12" class="btProfile" rel="nofollow"
                                    href="http://muachung.vn/ca-nhan/sua-thong-tin.html" style="width: 86px;"><b>hanguyen.ba12</b>
                                </a>
                                <div class="anchor">
                                </div>
                                <div class="c">
                                </div>
                            </div>
                        </div>
                    </div>
               <div class="cusMenu">
                        <a rel="nofollow" href="http://muachung.vn/ca-nhan/theo-doi-don-hang.html?action=list&amp;id=163015">
                            <span class="icOrder">Quản lý đơn hàng</span></a> <a onclick="shop.gold.rechargeStep1();"
                                rel="nofollow" href="javascript:void(0)"><span class="icGold">Nạp tiền</span></a>
                        <a rel="nofollow" href="http://muachung.vn/ca-nhan/lich-su-gold.html"><span class="icVi">
                            Lịch sử ví MuaChung</span></a> <a rel="nofollow" href="http://muachung.vn/ca-nhan/sua-thong-tin.html">
                                <span class="icAccount">Tài khoản</span></a> <a onclick="shop.customer.logout();"
                                    rel="nofollow" href="javascript:void(0)"><span id="noBoder" class="icOut">Thoát</span></a>
                    </div>--%>
            <div class="c">
            </div>
            </div>
            <div class="headerBottom">
                <div class="headerFloat">
                    <table width="980px">
                        <tr>
                            <td style="width: 20%">

                                <div style="background: url('/StyleLibrary/RootStyles/Images/commons/home_2323.png') no-repeat scroll 10px center transparent; cursor: pointer; float: left; font-family: Times New Roman; font-size: 22px; font-weight: bold; height: 48px; line-height: 48px; padding: 0 10px 0 40px;">
                                    <div id="Div1" class="currentBg "><a title="default" href="/Default.aspx">
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                                                      </a></div>
                                </div>
                                <div class="c">
                                </div>
                            </td>
                            <td style="width: 20%">
                                <div style="background: url('/StyleLibrary/RootStyles/Images/commons/menu_corporate.png') no-repeat scroll 10px center transparent; cursor: pointer; float: left; font-family: Times New Roman; font-size: 22px; font-weight: bold; height: 48px; line-height: 48px; padding: 0 10px 0 40px;">
                                    <div id="Div2" class="currentBg "><a title="corporate" href="/Default.aspx?id=corporate&cate=c">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a></div>
                                </div>
                                <div class="c">
                                </div>
                            </td>
                            <td style="width: 20%">
                                <div style="background: url('/StyleLibrary/RootStyles/Images/commons/menu_service.png') no-repeat scroll 10px center transparent; cursor: pointer; float: left; font-family: Times New Roman; font-size: 22px; font-weight: bold; height: 48px; line-height: 48px; padding: 0 10px 0 40px;">
                                    <div id="Div3" class="currentBg "><a title="services" href="/Default.aspx?id=services&cate=c">
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></a></div>
                                </div>
                                <div class="c">
                                </div>
                            </td>
                            <td style="width: 20%">
                                <div style="background: url('/StyleLibrary/RootStyles/Images/commons/menu_contact.png') no-repeat scroll 10px center transparent; cursor: pointer; float: left; font-family: Times New Roman; font-size: 22px; font-weight: bold; height: 48px; line-height: 48px; padding: 0 10px 0 40px;">
                                    <div id="Div4" class="currentBg "><a title="contactus" href="/Default.aspx?id=contactus&cate=c">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></a></div>
                                </div>
                                <div class="c">
                                </div>
                            </td>
                            <td style="width: 20%">
                                <div style="background: url('/StyleLibrary/RootStyles/Images/commons/menu_recruitment.png') no-repeat scroll 10px center transparent; cursor: pointer; float: left; font-family: Times New Roman; font-size: 22px; font-weight: bold; height: 48px; line-height: 48px; padding: 0 10px 0 40px;">
                                    <div id="22" class="currentBg"><a title="recuitment" href="/Default.aspx?id=recuitment&cate=c">
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></a></div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="c">
                </div>
            </div>
        </div>
    </div>
</div>
