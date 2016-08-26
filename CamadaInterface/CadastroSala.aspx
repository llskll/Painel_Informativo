<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroSala.aspx.cs" Inherits="CamadaInterface.CadastroSala" %>
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
            width: 636px;
        }

        .style2
        {
            width: 636px;
        }
        .style3
        {
            width: 638px;
        }
    .style4
    {
        width: 875px;
        height: 24px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table class="style10" >
                <tr align="center" >
                    <td class="style4" colspan="2" >
                        <h2>Sala</h2>
                     </td>
                </tr>
                <tr align="left" >
                    <td class="style2" >
                        Codigo<br />
                        <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="Button2" runat="server" Text="Consultar" 
                            onclick="Button2_Click" />
                        <br />
                    </td>
                    <td class="style3" rowspan="3" >
                        <br />
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AutoGenerateSelectButton="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" AllowPaging="True" 
                            PageSize="5">
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
                <tr align="left" >
                    <td class="style2" >
                        Nome<br />
                        <asp:TextBox ID="TextBoxNomeSala" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>

                        <br />

                        <asp:Button ID="ButtonIncluirsala" runat="server" Text="Cadastrar" 
                            onclick="ButtonIncluirsala_Click" />
                        &nbsp;<asp:Button ID="ButtonAlterar" runat="server" Text="Alterar" 
                            onclick="ButtonAlterar_Click" />
                        &nbsp;<asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" 
                            onclick="ButtonExcluir_Click" />
                        <br />
                        <asp:Label ID="LabelMsg" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
    
</asp:Content>
