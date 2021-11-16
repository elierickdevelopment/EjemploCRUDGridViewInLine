<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" EnableEventValidation="false" Inherits="EjemploCRUDGridViewInLine.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/javascript">
            function SetIdCiudad(ddl) {
                //ddl.value
                alert('Selected Value = ' + ddl.value);
                document.getElementById('HiddenField_idCiudad').value = ddl.value;
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField_idCiudad" runat="server" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource_grid"  AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                        <asp:TemplateField HeaderText="Ciudad">
                        <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList_Ciudad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Ciudad_SelectedIndexChanged"
                            DataSourceID="SqlDataSource_Ciudad" DataTextField="Descripcion" DataValueField="Id" onChange="SetIdCiudad(this);">
                        </asp:DropDownList>
                    </EditItemTemplate>
                         <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Comuna">
                        <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList_Comuna" runat="server" DataTextField="Descripcion" DataValueField="IdComuna">
                        </asp:DropDownList>
                    </EditItemTemplate>
                         <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource_grid" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT co.Id as IdComuna, co.Descripcion , ci.Descripcion as Ciudad FROM Comuna co, Ciudad  ci where co.IdCiudad = ci.Id"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_Ciudad" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Descripcion] FROM [Ciudad]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_Comuna" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Descripcion] FROM [Ciudad]"></asp:SqlDataSource>
        </div>
                
    </form>
</body>
</html>
