<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="add.aspx.vb" Inherits="repeater.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table       >
            
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
             
            <td>
                <asp:Label ID="PostId" runat="server" Text='<%# Eval("PostId") %>' Visible="false" />
                <asp:Label ID="lblPostEmail" runat="server" Text='<%# Eval("Email") %>' />
                <asp:TextBox ID="txtPostEmail" runat="server" Width="120" Text='<%# Eval("Email") %>' Visible="false" />
                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("Id") %>' />
            </td>
            <td>
               <asp:button ID="btnEdit" Text="Edit" runat="server"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PostId") %>' />
               <asp:button ID="btnUpdate" Text="Update" runat="server" Visible="false"    CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PostId") %>' />
               <asp:button ID="btnDelete" Text="Delete" runat="server" CommandName="delete"  OnClientClick="return confirm('Do you want to delete this row?');" />
                
            </td>
        </tr>
    </ItemTemplate>
        
         
    </asp:Repeater>
    <table   cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">
                Email id:
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtEmail" runat="server" Width="140" />
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" Text="Add"  />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
