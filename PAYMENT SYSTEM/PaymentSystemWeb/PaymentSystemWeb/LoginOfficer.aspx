<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginOfficer.aspx.cs" Inherits="PaymentSystemWeb.LoginOfficer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gişe Giriş</title>
    <style type="text/css">  
        .table-style {  
            width: 50%;  
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
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Gişe Giriş"></asp:Label>  
                </td> 
            </tr>  
            <tr>  
                <td style="text-align: right">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Kullanıcı Kodu"></asp:Label>  
                </td>  
                <td style="text-align: left">  
                    <asp:TextBox ID="UserCodeTextBox" runat="server" Font-Size="X-Large"></asp:TextBox>  
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
