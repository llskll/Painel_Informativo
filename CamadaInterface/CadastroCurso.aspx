<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroCurso.aspx.cs" Inherits="CamadaInterface.CadastroCurso" %>
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
            width: 656px;
        }
        .style2
        {
            width: 656px;
            height: 22px;
        }
    .style3
    {
        width: 875px;
        height: 45px;
    }
    </style>







</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
            
        
            <table class="style10" >
                <tr align="center" >
                    <td class="style2" colspan="2" >
                        <h2>Curso</h2>
                     </td>
                </tr>
                <tr  >
                    <td class="style3" >
                        Codigo<br />
                         <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="ButtonConsultar" runat="server" Text="Consultar" 
                            onclick="ButtonConsultar_Click" />
                        <br />
                     </td>
                    <td class="style1" rowspan="3" >
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AllowPaging="True" AutoGenerateSelectButton="True" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="5" 
                            onpageindexchanging="GridView1_PageIndexChanging">
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
                        Carga Horária
                         <br />
                         <asp:TextBox ID="TextBoxCargaHoraria" runat="server"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                     <td>
                         Nome
                         <br />
                        <asp:TextBox ID="TextBoxNome" runat="server" Width="210px"></asp:TextBox>
                         <br />
                     </td>
                </tr>
                <tr>
                     <td colspan="2">                               
                         <br />
                         <asp:Button ID="ButtonCadastrar" runat="server" 
                             onclick="ButtonCadastrar_Click1" Text="Cadastrar" />
                         <asp:Button ID="Button" runat="server" Text="Alterar" onclick="Button_Click" />
                         <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" 
                             onclick="ButtonExcluir_Click" />
                         <br />
                        
                                                
                        
                        <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

           

</asp:Content>
