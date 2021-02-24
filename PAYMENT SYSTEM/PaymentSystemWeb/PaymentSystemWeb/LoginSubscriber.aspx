<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSubscriber.aspx.cs" Inherits="PaymentSystemWeb.LoginSubscriber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abone Giriş</title>
    <style type="text/css">  
        .table-style {  
            width: 60%;  
            margin:auto;
            padding:20px;
        }  
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table-style">  
            <tr>  
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Abone Giriş"></asp:Label>  
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
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Button ID="LoginButton" runat="server" BorderStyle="Solid" Font-Size="X-Large" Text="Giriş" OnClick="LoginButton_Click" />  
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
