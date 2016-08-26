<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroTurma.aspx.cs" Inherits="CamadaInterface.CadastroTurma" %>
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
            width: 592px;
        }
        .style2
        {
            height: 22px;
            width: 592px;
        }
        .style5
        {
            width: 592px;
            height: 29px;
        }
        .style6
        {
            width: 592px;
            }
        .style7
        {
            width: 592px;
            height: 25px;
        }
        .style8
        {
            width: 592px;
            height: 91px;
        }
    .style9
    {
        width: 875px;
        height: 54px;
    }
    .style10
    {
        width: 548px;
        height: 121px;
    }
    .style11
    {
        width: 875px;
        height: 21px;
    }
    .style12
    {
        width: 875px;
        height: 60px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="style10" >
                <tr align="center" >
                    <td class="style2" colspan="2" >
                        <h2>Turma</h2>
                    </td>
                    
                </tr>

                <tr align="left" >
                    <td class="style6" >
                        Codigo<br />
<asp:TextBox ID="TextBoxCodigo" runat="server" Width="95px" Height="22px"></asp:TextBox>
                    &nbsp;<asp:Button ID="ButtonConsultar" runat="server" 
                            onclick="ButtonConsultar_Click" Text="Consultar" />
                        <br />
                    </td>
                    <td class="style6" rowspan="3" >
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" 
                            ForeColor="#333333" GridLines="None"  
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            onselectedindexchanged="GridView1_SelectedIndexChanged1" 
                            AutoGenerateSelectButton="True" PageSize="5" Width="187px" >
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
                       <td class="style5"> Quantidade de Alunos<br />
                            <asp:TextBox ID="TextBoxQuantAlunos" runat="server" Width="97px" Height="22px"></asp:TextBox>
                       </td>
                </tr> 
                
                <tr>  
                        <td class="style7">Turno<br />
                            <asp:DropDownList ID="DropDownListTurno" runat="server" Height="22px" 
                                Width="99px">
                                <asp:ListItem>Manha</asp:ListItem>
                                <asp:ListItem>Tarde</asp:ListItem>
                                <asp:ListItem>Noite</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                </tr>
                <tr>
                        <td class="style8" colspan="2">
                        Curso<br />
                            <asp:DropDownList ID="DropDownListCurso" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="nome" 
                                DataValueField="idCurso">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
                                SelectCommand="SELECT [nome], [idCurso] FROM [curso]"></asp:SqlDataSource>
                            <br />
                       


                        </td>
                </tr>
                <tr>
                        <td class="style9" colspan="2">
                        Data de Inicio<br />
                        <asp:TextBox ID="TextBoxDataInicio" runat="server" Height="22px" Width="174px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                        <td class="style11" colspan="2">Data do Fim<br />
                        <asp:TextBox ID="TextBoxDataFim" runat="server" Height="22px" Width="173px"></asp:TextBox>
                        </td>
                </tr>

                <tr>
                        <td class="style11" colspan="2">Dias da Semana<br />
                            <asp:DropDownList ID="DropDownListDiaDaSemana" runat="server" Height="22px" 
                                Width="177px">
                                <asp:ListItem>Segunda à sexta</asp:ListItem>
                                <asp:ListItem>Segunda à sabado</asp:ListItem>
                                <asp:ListItem>Segunda, quarta e sexta</asp:ListItem>
                                <asp:ListItem>Terça, quinta e sabado</asp:ListItem>
                                <asp:ListItem>Terças e quintas</asp:ListItem>
                                <asp:ListItem>Sabados</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                        <td class="style12" colspan="2">
                            <br />
                            <asp:Button ID="ButtonIncluirturma" runat="server" Text="Cadastrar" 
                            onclick="ButtonIncluirturma_Click" Width="80px" style="height: 26px" />
                        
                            &nbsp;<asp:Button ID="ButtonAlterar" runat="server" onclick="ButtonAlterar_Click" 
                                Text="Alterar" />
                            &nbsp;<asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" 
                                onclick="ButtonExcluir_Click" style="height: 26px" />
                        
                            <br />
                        
                        <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                </tr>
            </table>


    

</asp:Content>
