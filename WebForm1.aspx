<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EjemploCRUDGridViewInLine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="id, IdRegion" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" Width="502px" OnRowDataBound="GridView1_RowDataBound">
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
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT p.id, p.Descripcion, p.IdRegion, r.Region FROM Pais AS p LEFT OUTER JOIN Catalogo_Region AS r ON p.IdRegion = r.Id"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_region" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Region] FROM [Catalogo_Region]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
