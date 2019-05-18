<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <asp:Label Text="" ID="Label1" runat="server" />
        <table>
            <tbody>
                <tr>
                    <td>
                        <asp:Label Text="Destination path" ID="Label2" runat="server" />

                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbPath" Text="Northwind" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Database name" ID="Label3" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tbDataBaseName" Text="Northwind" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Connection string" ID="Label4" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbConnectionString" Text="NorthwindConnectionString" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Export SQL tables to XML" ID="Button3" OnClick="Button1_Click" runat="server" /></td>
                </tr>

            </tbody>
        </table>
        <br />      
        <br />      
        <br />      
        <table>
            <tbody>
                <tr>
                    <td>
                        <asp:Label Text="Table name" ID="Label5" runat="server" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="tbTableNameImport" Text="Customers" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Import SQL table to Grid" ID="Button2" OnClick="Button2_Click" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>



        <hr />
        <asp:GridView runat="server" ID="GridView1" Visible="false"></asp:GridView>
    </form>
</body>
</html>
