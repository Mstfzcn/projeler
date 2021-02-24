<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaidInvoicesExtracts.aspx.cs" Inherits="PaymentSystemWeb.PaidInvoicesExtracts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ödenmiş Faturalar Ekstresi</title>
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

        <table class="table-style">  
            <tr>  
                <td colspan="3" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Ödenmişler Ekstresi"></asp:Label>  
                </td> 
            </tr>  
            <tr>
                <td colspan="3" style="text-align: center; vertical-align: top">
                    <asp:GridView ID="GridViewInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="InvoiceId">
                    <Columns>
                        <asp:BoundField  DataField="InvoiceId" HeaderText="Fatura Numarası" />
                        <asp:BoundField  DataField="SubscriberId" HeaderText="SubscriberId" Visible="False" />
                        <asp:BoundField  DataField="NameSurname" HeaderText="İsim Soyisim" />
                        <asp:BoundField  DataField="SubscriptionId" HeaderText="SubscriptionId" Visible="False" />
                        <asp:BoundField  DataField="SubscriptionType" HeaderText="Abonelik Türü" />
                        <asp:BoundField  DataField="InvoiceAmount" HeaderText="Fatura Tutarı (TL)" />
                        <asp:BoundField  DataField="CutOffDate" HeaderText="Hesap Kesim Tarihi" DataFormatString = "{0:dd/MM/yyyy}" />
                        <asp:BoundField  DataField="FinalPaymentDate" HeaderText="Son Ödeme Tarihi" DataFormatString = "{0:dd/MM/yyyy}" />
                    </Columns>
                </asp:GridView>
                </td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
