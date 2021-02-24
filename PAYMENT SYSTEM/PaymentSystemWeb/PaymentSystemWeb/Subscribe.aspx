<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Subscribe.aspx.cs" Inherits="PaymentSystemWeb.Subscribe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abone Yap</title>
    <style type="text/css">  
        .table-style {  
            width: 60%;  
            margin:auto;
            padding:20px;
        }  
        .menu-table-style {  
            width: 100%;  
            margin:auto;
            padding:20px;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="menu-table-style">  
            <tr>
                <td>
                    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick">
                        <Items>
                            <asp:MenuItem Text="Abone Yap" Value="Subscribe.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Aboneliği Kapat" Value="CloseSubscription.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Aboneliği Sorgula" Value="SearchSubscription.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Abone Ödenmemiş Fatura Seç/Öde" Value="SubscriberPayBill.aspx"></asp:MenuItem>
                        </Items>
                        <StaticMenuItemStyle BorderColor="Blue" BorderStyle="Solid" HorizontalPadding="10px" Font-Size="X-Large" Font-Bold="False" VerticalPadding="10px"/>
                    </asp:Menu>
                </td>
                <td style="text-align: left; vertical-align: top">  
                    <asp:Button ID="ButtonLogOut" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Çıkış" OnClick="ButtonLogOut_Click"/>  
                </td> 
            </tr>
        </table> 

        <table class="table-style">  
            <tr>  
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Abone Yap"></asp:Label>  
                </td> 
            </tr>  
            <tr>   
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:RadioButtonList ID="RadioButtonListCustomer" runat="server" Font-Size="X-Large" RepeatDirection="Horizontal" align="center" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListCustomer_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>  
            </tr> 
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="T.C. Kimlik Numarası"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="IdentificationTaxNumberTextBox" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>   
                <td style="text-align: right">  
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Şifre"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="PasswordTextBox" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
            </tr> 
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="İsim"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="NameTextBox" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label5" runat="server" Font-Size="X-Large" Text="Soyisim"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="SurnameTextBox" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
            </tr>   
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label6" runat="server" Font-Size="X-Large" Text="Abonelik Türü"></asp:Label>  
                </td>  
                <td style="text-align: left"> 
                    <asp:DropDownList ID="DropDownListSubscriptionType" runat="server" Font-Size="X-Large" Width="227px"></asp:DropDownList>
                </td>  
            </tr>   
            <tr>   
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Button ID="SaveButton" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Kaydet" OnClick="SaveButton_Click"/>  
                </td>  
            </tr>  
            <tr> 
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="LabelWarning" runat="server" Font-Size="X-Large"></asp:Label>  
                </td>   
            </tr>  
        </table> 
    </div>
    </form>
</body>
</html>
