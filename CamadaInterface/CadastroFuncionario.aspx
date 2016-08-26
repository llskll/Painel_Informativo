<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroFuncionario.aspx.cs" Inherits="CamadaInterface.CadastroProfessor" %>
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
            width: 710px;
        }
    .style2
    {
        width: 875px;
        height: 24px;
    }
    .style3
    {
        width: 875px;
        height: 49px;
    }
    .style4
    {
        width: 875px;
        height: 42px;
    }
    .style5
    {
        width: 875px;
        height: 41px;
    }
    .style6
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
                        <h2>Funcionário</h2></td>
                </tr>
                <tr align="left" >
                    <td class="style3" >
                        Matricula<br />
                        <asp:TextBox 
                            ID="TextBoxMatricula" runat="server" Width="95px" style="margin-bottom: 0px"></asp:TextBox>
                    &nbsp;<asp:Button ID="ButtonConsultar" runat="server" Text="Consultar" 
                            onclick="ButtonConsultar_Click" />
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
                        
                <tr align="left" >
                    <td class="style4" >
                        Nome<br />
                        <asp:TextBox ID="TextBoxNomeFuncionario" runat="server" Width="182px"></asp:TextBox>
                    </td>
                </tr>
                        
                <tr align="left" >
                    <td class="style5" >
                        Cargo
                        <br />
                        <asp:DropDownList ID="DropDownListCargo" runat="server" Height="22px" 
                            Width="101px">
                            <asp:ListItem>Professor</asp:ListItem>
                            <asp:ListItem>Pedagoga</asp:ListItem>
                            <asp:ListItem>Inspetor</asp:ListItem>
                            <asp:ListItem>Secretaria</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                        
                <tr align="left" >
                    <td class="style6" >
                        Turno<br />
                        <asp:DropDownList ID="DropDownListTurno" runat="server" Height="22px" 
                            Width="101px">
                            <asp:ListItem>Manha</asp:ListItem>
                            <asp:ListItem>Tarde</asp:ListItem>
                            <asp:ListItem>Noite</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                        
                <tr>
                    <td>
                        Telefone
                        <br />
                        <asp:TextBox ID="TextBoxTelefone" runat="server" style="margin-bottom: 0px" 
                            Width="182px"></asp:TextBox>
                        <br />
                    </td>   
                    <td>
                        &nbsp;</td>   
                </tr>
                        
                <tr>
                    <td>
                        Email<br />
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="180px"></asp:TextBox>
                    </td>   
                    <td>
                        &nbsp;</td>   
                </tr>
                        
                <tr>
                    <td>
                        Endereço<br />
                        <asp:TextBox ID="TextBoxEndereco" runat="server" Width="219px"></asp:TextBox>
                    </td>   
                    <td>
                        &nbsp;</td>   
                </tr>
                        
                <tr>
                    <td>
                        RG<br />
                        <asp:TextBox ID="TextBoxRG" runat="server" Width="178px"></asp:TextBox>
                    </td>   
                    <td>
                        &nbsp;</td>   
                </tr>
                        
                <tr>
                    <td>
                        CPF<br />
                        <asp:TextBox ID="TextBoxCPF" runat="server" Width="178px"></asp:TextBox>
                    </td>   
                    <td>
                        &nbsp;</td>   
                </tr>
                        
                <tr>
                    <td colspan="2">
                        Sexo<br />
                        <asp:DropDownList ID="DropDownListSexo" runat="server" Height="22px" 
                            Width="101px">
                            <asp:ListItem>Masculino</asp:ListItem>
                            <asp:ListItem>Feminino</asp:ListItem>
                        </asp:DropDownList>
                    </td>   
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:Button ID="ButtonIncluir" runat="server" Text="Cadastrar" 
                            onclick="ButtonIncluir_Click" Width="79px" />
                        
                        &nbsp;<asp:Button ID="ButtonAlterar" runat="server" Text="Alterar" 
                            onclick="ButtonAlterar_Click" style="height: 26px" />
                        &nbsp;<asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" 
                            onclick="ButtonExcluir_Click" />
                        <br />
                        
                        <asp:Label ID="LabelMsg" runat="server" EnableTheming="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

</asp:Content>
