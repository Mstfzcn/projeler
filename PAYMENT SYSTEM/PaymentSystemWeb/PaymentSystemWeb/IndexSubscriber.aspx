﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexSubscriber.aspx.cs" Inherits="PaymentSystemWeb.IndexSubscriber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abone - Ana Sayfa</title>
    <style type="text/css">  
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
                            <asp:MenuItem Text="Fatura Seç/Öde" Value="PayBill.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Ödenmişler Ekstresi" Value="PaidInvoicesExtracts.aspx"></asp:MenuItem>
                        </Items>
                        <StaticMenuItemStyle BorderColor="Blue" BorderStyle="Solid" HorizontalPadding="10px" Font-Size="X-Large" Font-Bold="False" VerticalPadding="10px"/>
                    </asp:Menu>
                </td>
                <td style="text-align: left; vertical-align: top">  
                    <asp:Button ID="ButtonLogOut" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Çıkış" OnClick="ButtonLogOut_Click"/>  
                </td> 
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>

