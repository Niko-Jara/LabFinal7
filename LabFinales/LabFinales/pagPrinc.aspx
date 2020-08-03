<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagPrinc.aspx.cs" Inherits="LabFinales.pagPrinc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .lab {margin-left:100px; margin-top:30px; }

        #cmbpais {
            margin-left:100px; margin-top:30px;
        }
        #Label1 {
            margin-left:70px;
        }
        #txtHabitantes {
            margin-left:59px; margin-top:30px;
        }
        #cmbIdioma {
            margin-left:80px; margin-top:30px;
        }
        #txtPIB {
            margin-left:100px; margin-top:30px;
        }
        #txtSuperficie {
            margin-left:60px; margin-top:30px;
        }
        #Bajo {
            margin-left:100px; margin-top:30px;
        }
        #Medio {
            margin-left:50px; margin-top:30px;
        }
        #Alto {
            margin-left:50px; margin-top:30px;
        }
        #CheckBox1 {
            margin-left:99px; margin-top:30px;
        }
        #Label7 {
            margin-left:75px; margin-top:30px;
        }
        #Label11 {
            margin-left:10px;
        }
        #Registrar {
            margin-left:95px; margin-top:30px; padding:5px;
        }
        #Modificar {
            margin-left:30px; margin-top:30px; padding:5px;
        }
        #Eliminar {
            margin-left:30px; margin-top:30px; padding:5px;
        }

        .radioButtonList { 
            list-style:none; 
            margin-top: 15px; 
            margin-left:170px;
            padding: 0;

        }

       .radioButtonList.horizontal li {
           display: inline;

       }

       .radioButtonList label{
           display:inline;
       }

        #Check {
            margin-top:20px;
            margin-left:70px;
        }
    </style>
</head>
<body style="height: 514px">
    <form id="form1" runat="server">
        <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" id="upd1">
            <ContentTemplate>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Formulario de Fondo Monetario Internacional"></asp:Label>
            
            <br />
            <br />
            
        </div>
        <asp:Label ID="Label2" class="lab" runat="server" Text="Pais"></asp:Label>
        <asp:DropDownList ID="cmbpais" class="txt" runat="server" Height="24px" Width="175px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" class="lab" runat="server" Text="Habitantes"></asp:Label>
        <asp:TextBox ID="txtHabitantes" class="txt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" class="lab" runat="server" Text="Idioma"></asp:Label>
        <asp:DropDownList ID="cmbIdioma" class="txt" runat="server" Height="24px" Width="175px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label5" class="lab" runat="server" Text="PIB"></asp:Label>
        <asp:TextBox ID="txtPIB" class="txt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" class="lab" runat="server" Text="Superficie"></asp:Label>
        <asp:TextBox ID="txtSuperficie" class="txt" runat="server"></asp:TextBox>
        <br />
        <p>
            &nbsp;</p>
        <asp:Label ID="Label7" runat="server" Text="Riesgo de Seguridad"></asp:Label>
        
        <asp:RadioButtonList ID="Radio"  CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Alto" id="ListItem1"  runat="server"/>
            <asp:ListItem Text="Medio" id="ListItem2"  runat="server"/>
            <asp:ListItem Text="Bajo" id="ListItem3"   runat="server"/>
        </asp:RadioButtonList>
        
        <asp:CheckBox ID="Check" text="Sujeto a Prestamo?" runat="server" />
      
        <p>
            <asp:Button ID="Registrar" runat="server" Text="Registar"  OnClick="Registrar_Click"/>
            <asp:Button ID="Modificar" runat="server" Text="Actualizar" OnClick="Modificar_Click" />
            <asp:Button ID="Eliminar" runat="server" Text="Eliminar"  OnClick="Eliminar_Click" />
        </p>
       
        <div>
            <asp:GridView ID="gridPrestamos" runat="server" 
                 AutoGenerateColumns="false"  
                 DataKeyNames="IdPrestamo" 
                 BackColor="White" 
                 BorderColor="#999999" 
                 BorderStyle="None" 
                 BorderWidth="1px" 
                 CellPadding="3" 
                 GridLines="Vertical"                                                                             
                 >
            <Columns>
                 <asp:BoundField DataField="IdPais" HeaderText="Pais" />
                 <asp:BoundField DataField="Habitantes" HeaderText="Habitantes" />
                 <asp:BoundField DataField="Idioma" HeaderText="Idioma" />
                 <asp:BoundField DataField="PIB" HeaderText="PIB" />
                 <asp:BoundField DataField="Superficie" HeaderText="Superficie" />
                 <asp:BoundField DataField="Riesgo" HeaderText="Riesgo" />
                 <asp:TemplateField HeaderText="Prestamo">
                        <ItemTemplate>
                            <%# (Boolean.Parse(Eval("Prestamo").ToString())) ? "SI" : "NO" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
           </asp:GridView>
          </div>
        </ContentTemplate>
       </asp:UpdatePanel>
      </div>
    </form>
</body>
</html>



