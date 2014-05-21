<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span style ="font-family:Arial">Select Customer : </span>
<asp:DropDownList ID="ddlContinents" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="customer_SelectedIndexChanged">
<asp:ListItem Text = "--Select Customer--" Value = ""></asp:ListItem>
</asp:DropDownList>
 
<br /><br />
<span style ="font-family:Arial">Select Country : </span>
<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack = "true"
Enabled = "false"  OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
<asp:ListItem Text = "--Select Invoice--" Value = ""></asp:ListItem>
</asp:DropDownList>
 
 
<br /><br />
<asp:Label ID="lblResults" runat="server" Text="" Font-Names = "Arial" />
        <br /><br />
        <asp:GridView ID="GridView1" runat="server" Font-Names = "Arial"></asp:GridView>
        <br /><br />
<asp:Label ID="lblFooter" runat="server" Text="" Font-Names = "Arial" />
    </div>
        
    </form>
</body>
</html>
