<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchSubscription.aspx.cs" Inherits="PaymentSystemWeb.SearchSubscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abone Sorgula</title>
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
                <td colspan="3" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Abone Sorgula"></asp:Label>  
                </td> 
            </tr>  
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="T.C. Kimlik/Vergi Numarası"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="IdentificationTaxNumberTextBox" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
                <td style="text-align: left; vertical-align: top">  
                    <asp:Button ID="SearchButton" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Sorgula" OnClick="SearchButton_Click"/>  
                </td> 
            </tr>   
            <tr> 
                <td colspan="3" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="LabelWarning" runat="server" Font-Size="X-Large"></asp:Label>  
                </td>   
            </tr>  
            <tr>
                <td colspan="3" style="text-align: center; vertical-align: top">
                    <asp:GridView ID="GridViewSubscriber" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField  DataField="SubscriberId" HeaderText="SubscriberId" Visible="False" />
                        <asp:BoundField  DataField="Name" HeaderText="İsim" />
                        <asp:BoundField  DataField="Surname" HeaderText="Soyisim" />
                        <asp:BoundField  DataField="SubscriberTypeId" HeaderText="SubscriberTypeId" Visible="False" />
                        <asp:BoundField  DataField="SubscriberTypeName" HeaderText="Müşteri Türü" />
                        <asp:BoundField  DataField="IdentificationTaxNumber" HeaderText="T.C. Kimlik/Vergi Numarası" />
                        <asp:BoundField  DataField="SubscriptionId" HeaderText="SubscriptionId" Visible="False" />
                        <asp:BoundField  DataField="SubscriptionType" HeaderText="Abonelik Türü" />
                        <asp:CheckBoxField  DataField="Active" HeaderText="Aktif" />
                        <asp:BoundField  DataField="InsertUser" HeaderText="Kaydeden Kullanıcı" />
                        <asp:BoundField  DataField="InsertDate" HeaderText="Kayıt Tarihi" />
                        <asp:BoundField  DataField="UpdateUser" HeaderText="Güncelleyen Kullanıcı" />
                        <asp:BoundField  DataField="UpdateDate" HeaderText="Güncelleme Tarihi" />
                    </Columns>
                </asp:GridView>
                </td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
