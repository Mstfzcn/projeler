<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubscriberPayBill.aspx.cs" Inherits="PaymentSystemWeb.SubscriberPayBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abone Fatura Öde</title>
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
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Ödenmemiş Fatura Seç/Öde"></asp:Label>  
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
                <td style="text-align: left; vertical-align: top">  
                    <asp:Button ID="PayButton" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Öde" OnClick="PayButton_Click"/>  
                </td> 
            </tr>   
            <tr> 
                <td colspan="3" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="LabelWarning" runat="server" Font-Size="X-Large"></asp:Label>  
                </td>   
            </tr>  
            <tr>
                <td colspan="3" style="text-align: center; vertical-align: top">
                    <asp:GridView ID="GridViewInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="InvoiceId">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
