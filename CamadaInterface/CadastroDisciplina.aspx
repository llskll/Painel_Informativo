<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroDisciplina.aspx.cs" Inherits="CamadaInterface.CadastroDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="SYSO - Painel Informativo" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="SYSO - Painel Informativo" />
    <link href="templatemo_style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function clearText(field) {
            if (field.defaultValue == field.value) field.value = '';
            else if (field.value == '') field.value = field.defaultValue;
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 610px;
        }
    .style2
    {
        width: 875px;
        height: 24px;
    }
    .style3
    {
        width: 875px;
        height: 46px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="style10" >
                <tr align="center" >
                    <td class="style2" colspan="2" >
                        <h2>Disciplina</h2></td>
                </tr>
                <tr align="left" >
                    <td class="style3" >
                        Codigo<br />
                        <asp:TextBox ID="TextBoxCodigo" runat="server" Width="74px"></asp:TextBox>
                    &nbsp;<asp:Button ID="ButtonConsultar" runat="server" Text="Consultar" 
                            onclick="ButtonConsultar_Click" />
                        <br />
                    </td>
                    <td class="style1" rowspan="4" >
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AllowPaging="True" AutoGenerateSelectButton="True" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="5" 
                            onpageindexchanging="GridView1_PageIndexChanging1">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td>
                        Nome<br />
                        <asp:TextBox ID="TextBoxNomeDisciplina" runat="server" Width="161px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Carga Horaria<br />
                        <asp:TextBox ID="TextBoxCargaHoraria" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quantidade de Aulas<br />
                        <asp:TextBox ID="TextBoxQntDeAulas" runat="server" Width="159px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Curso
                        <br />
                        <asp:DropDownList ID="DropDownListCurso" runat="server" 
                            DataSourceID="SqlDataSource1" DataTextField="nome" DataValueField="idCurso">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
                            SelectCommand="SELECT [nome], [idCurso] FROM [curso]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                     <td colspan="2">
                         <br />
                        <asp:Button ID="ButtonIncluird" runat="server" Text="Cadastrar" 
                            onclick="ButtonIncluird_Click" />
                         &nbsp;<asp:Button ID="ButtonAlterar" runat="server" Text="Alterar" 
                             Width="56px" onclick="ButtonAlterar_Click" />
                         &nbsp;<asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" 
                             onclick="ButtonExcluir_Click" />
                        <br />
                        <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

</asp:Content>
