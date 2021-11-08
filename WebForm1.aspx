<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" EnableEventValidation = "false" Inherits="EjemploCRUDGridViewInLine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="id,IdRegion" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" Width="100%" OnRowDataBound="GridView1_RowDataBound" ForeColor="#333333" GridLines="None" OnPageIndexChanged="GridView1_PageIndexChanged" OnRowCreated="GridView1_RowCreated">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:TemplateField HeaderText="Región">
                        <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList_region" runat="server"
                            DataSourceID="SqlDataSource_region" DataTextField="region" DataValueField="Id">
                        </asp:DropDownList>
                    </EditItemTemplate>
                         <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Label"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT p.id, p.Descripcion, p.IdRegion, r.Region FROM Pais AS p LEFT OUTER JOIN Catalogo_Region AS r ON p.IdRegion = r.Id"></asp:SqlDataSource>
            <asp:Button ID="Button_verultimoId" runat="server" OnClick="Button_verultimoId_Click" Text="VER ÚLTIMO ID" />
            <asp:SqlDataSource ID="SqlDataSource_region" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Region] FROM [Catalogo_Region]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
