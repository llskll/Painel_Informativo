<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grid_View.Default" %>
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
        .style2
        {
            width: 556px;
        }
        .style3
        {
        }
        .style11
        {
        }
        .style12
        {
            width: 533px;
        }
        .style13
        {
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <table class="style2">
<tr align="center">
    <td class="style12"><h2>Painel</h2>
    </td>
</tr>
<tr>
    <td class="style13">Data<br />
        <asp:DropDownList ID="DropDownDsemana" runat="server" Height="22px" 
            Width="166px">
            <asp:ListItem>Segunda-Feira</asp:ListItem>
            <asp:ListItem>Terca-Feira</asp:ListItem>
            <asp:ListItem>Quarta-Feira</asp:ListItem>
            <asp:ListItem>Quinta-Feira</asp:ListItem>
            <asp:ListItem>Sexta-Feira</asp:ListItem>
            <asp:ListItem>Sabado</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style13">Código<br />
    <asp:TextBox ID="TextBoxCodigo" runat="server" Width="168px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="style13">&nbsp;Turno<br />
        <asp:DropDownList ID="DropDownTurno" runat="server" Height="22px" Width="168px">
            <asp:ListItem>Manha</asp:ListItem>
            <asp:ListItem>Tarde</asp:ListItem>
            <asp:ListItem>Noite</asp:ListItem>
        </asp:DropDownList>
    &nbsp;</td>
</tr>
<tr>
    <td class="style11">Disciplina<br />
        <asp:DropDownList ID="DropDownDisciplina" runat="server" 
    DataSourceID="SqlDataSource1" DataTextField="nomeDisciplina" 
    DataValueField="idDisc" Height="22px" Width="168px" 
              >
</asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style11">Turma<br />
        <asp:DropDownList ID="DropDownTurma" runat="server" 
        DataSourceID="SqlDataSource2" DataTextField="codigo" 
        DataValueField="idturma" Height="22px" Width="168px">
</asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style11">Curso<br />
    <asp:DropDownList ID="DropDownCurso" runat="server" 
        DataSourceID="SqlDataSource3" DataTextField="nome" 
        DataValueField="idCurso">
        <asp:ListItem>asdasd</asp:ListItem>
</asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style11">Professor<br />
        <asp:DropDownList ID="DropDownProfessor" runat="server" 
        DataSourceID="SqlDataSource4" DataTextField="nome" 
        DataValueField="matricula" Height="22px" Width="168px">
</asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style11">Sala<br />
        <asp:DropDownList ID="DropDownSala" runat="server" 
        DataSourceID="SqlDataSource5" DataTextField="nome" DataValueField="idSala" 
            Height="22px" Width="168px">
</asp:DropDownList>
    </td>
</tr>
<tr>
    <td class="style11">
    <asp:Button ID="btAddRecord" runat="server" OnClick="btAddRecord_Click" 
            Text="Cadastrar" />
    </td>
</tr>
<tr>
    <td class="style11">
        <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
    </td>
</tr>
<tr align="center">
    <td class="style3">
    

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="cod" 
                    ForeColor="#333333" GridLines="Horizontal" Height="16px" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting1" PageSize="5" style="margin-right: 2px" 
                    Width="246px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="cod" HeaderText="Codigo" />
                        <asp:BoundField DataField="idSal" HeaderText="Sala" />
                        <asp:BoundField DataField="idTur" HeaderText="Turma" />
                        <asp:BoundField DataField="idCur" HeaderText="Curso" />
                        <asp:BoundField DataField="idDisc" HeaderText="Disciplina" />
                        <asp:BoundField DataField="idFun" HeaderText="Professor" />
                        <asp:TemplateField HeaderText="Excluir" ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Height="16px" ImageUrl="~/imagens2/excluir.gif" 
                                    onclick="ImageButton1_Click" Text="Delete" Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <sortedascendingcellstyle backcolor="#F5F7FB" />
                    <sortedascendingheaderstyle backcolor="#6D95E1" />
                    <sorteddescendingcellstyle backcolor="#E9EBEF" />
                    <sorteddescendingheaderstyle backcolor="#4870BE" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>





    </td>
</tr>
</table>
    




</p>
<p>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
    
        
        
              
              SelectCommand="select disciplina.idDisc, disciplina.nomeDisciplina from disciplina order by disciplina.idDisc asc">
</asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
        SelectCommand="SELECT [codigo],idturma FROM [turma] ORDER BY [codigo]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
        SelectCommand="SELECT [nome],idCurso FROM [curso] ORDER BY [nome]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
        
        SelectCommand="SELECT [nome], [matricula] FROM [funcionario] WHERE ([cargo] = @cargo)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="Professor" Name="cargo" 
                QueryStringField="Professor" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SYSOConnectionString4 %>" 
        SelectCommand="SELECT [nome],idSala FROM [sala] ORDER BY [nome]">
    </asp:SqlDataSource>
</p>
    




</asp:Content>
