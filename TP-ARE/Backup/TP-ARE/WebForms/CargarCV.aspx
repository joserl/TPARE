<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CargarCV.aspx.cs" Inherits="TP_ARE.WebForms.CargarCV" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <fieldset><legend>1 - Datos Personales</legend>
    <div class="control-group" > 
         <label class="control-label" >Nombre:</label>
        <div class="controls">
         <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
         <asp:RequiredFieldValidator ID="nombre" runat="server" 
             ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" 
             ForeColor="Red">*</asp:RequiredFieldValidator>
   </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Apellido:</label>
        <div class="controls"><asp:TextBox ID="txtApellido" runat="server" ></asp:TextBox>

        <asp:RequiredFieldValidator ID="apellido" runat="server" 
            ControlToValidate="txtApellido" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

    </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Fecha de nacimiento:</label>
        <div class="controls">
        <asp:DropDownList class="span2" ID="cbDia" runat="server">
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem Value="18">18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>&nbsp;/&nbsp;
<asp:DropDownList class="span2" ID="cbMes" runat="server">
            <asp:ListItem Value="01">01</asp:ListItem>
            <asp:ListItem Value="02">02</asp:ListItem>
            <asp:ListItem Value="03">03</asp:ListItem>
            <asp:ListItem Value="04">04</asp:ListItem>
            <asp:ListItem Value="05">05</asp:ListItem>
            <asp:ListItem Value="06">06</asp:ListItem>
            <asp:ListItem Value="07">07</asp:ListItem>
            <asp:ListItem Value="08">08</asp:ListItem>
            <asp:ListItem Value="09">09</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList> &nbsp;/&nbsp;
<asp:DropDownList class="span2" ID="cbAno" runat="server">
            <asp:ListItem>1930</asp:ListItem>
            <asp:ListItem>1931</asp:ListItem>
            <asp:ListItem>1932</asp:ListItem>
            <asp:ListItem>1933</asp:ListItem>
            <asp:ListItem>1934</asp:ListItem>
            <asp:ListItem>1935</asp:ListItem>
            <asp:ListItem>1936</asp:ListItem>
            <asp:ListItem>1937</asp:ListItem>
            <asp:ListItem>1938</asp:ListItem>
            <asp:ListItem>1939</asp:ListItem>
            <asp:ListItem>1940</asp:ListItem>
            <asp:ListItem>1941</asp:ListItem>
            <asp:ListItem>1942</asp:ListItem>
            <asp:ListItem>1943</asp:ListItem>
            <asp:ListItem>1944</asp:ListItem>
            <asp:ListItem>1945</asp:ListItem>
            <asp:ListItem>1946</asp:ListItem>
            <asp:ListItem>1947</asp:ListItem>
            <asp:ListItem>1948</asp:ListItem>
            <asp:ListItem>1949</asp:ListItem>
            <asp:ListItem>1950</asp:ListItem>
            <asp:ListItem>1951</asp:ListItem>
            <asp:ListItem>1952</asp:ListItem>
            <asp:ListItem>1953</asp:ListItem>
            <asp:ListItem>1954</asp:ListItem>
            <asp:ListItem>1955</asp:ListItem>
            <asp:ListItem>1956</asp:ListItem>
            <asp:ListItem>1957</asp:ListItem>
            <asp:ListItem>1958</asp:ListItem>
            <asp:ListItem>1959</asp:ListItem>
            <asp:ListItem>1960</asp:ListItem>
            <asp:ListItem>1961</asp:ListItem>
            <asp:ListItem>1962</asp:ListItem>
            <asp:ListItem>1963</asp:ListItem>
            <asp:ListItem>1964</asp:ListItem>
            <asp:ListItem>1965</asp:ListItem>
            <asp:ListItem>1966</asp:ListItem>
            <asp:ListItem>1967</asp:ListItem>
            <asp:ListItem>1968</asp:ListItem>
            <asp:ListItem>1969</asp:ListItem>
            <asp:ListItem>1970</asp:ListItem>
            <asp:ListItem>1971</asp:ListItem>
            <asp:ListItem>1972</asp:ListItem>
            <asp:ListItem>1973</asp:ListItem>
            <asp:ListItem>1974</asp:ListItem>
            <asp:ListItem>1975</asp:ListItem>
            <asp:ListItem>1976</asp:ListItem>
            <asp:ListItem>1977</asp:ListItem>
            <asp:ListItem>1978</asp:ListItem>
            <asp:ListItem>1979</asp:ListItem>
            <asp:ListItem>1980</asp:ListItem>
            <asp:ListItem>1981</asp:ListItem>
            <asp:ListItem>1982</asp:ListItem>
            <asp:ListItem>1983</asp:ListItem>
            <asp:ListItem>1984</asp:ListItem>
            <asp:ListItem>1985</asp:ListItem>
            <asp:ListItem>1986</asp:ListItem>
            <asp:ListItem>1987</asp:ListItem>
            <asp:ListItem>1988</asp:ListItem>
            <asp:ListItem>1989</asp:ListItem>
            <asp:ListItem>1990</asp:ListItem>
            <asp:ListItem>1991</asp:ListItem>
            <asp:ListItem>1992</asp:ListItem>
            <asp:ListItem>1993</asp:ListItem>
            <asp:ListItem>1994</asp:ListItem>
            <asp:ListItem>1995</asp:ListItem>
            <asp:ListItem>1996</asp:ListItem>
            <asp:ListItem>1997</asp:ListItem>
            <asp:ListItem>1998</asp:ListItem>
            <asp:ListItem>1999</asp:ListItem>
            <asp:ListItem>2000</asp:ListItem>
            <asp:ListItem>2001</asp:ListItem>
            <asp:ListItem>2002</asp:ListItem>
            <asp:ListItem>2003</asp:ListItem>
            <asp:ListItem>2004</asp:ListItem>
            <asp:ListItem>2005</asp:ListItem>
            <asp:ListItem>2006</asp:ListItem>
            <asp:ListItem>2007</asp:ListItem>
            <asp:ListItem>2008</asp:ListItem>
            <asp:ListItem>2009</asp:ListItem>
            <asp:ListItem>2010</asp:ListItem>
            <asp:ListItem>2011</asp:ListItem>
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2013</asp:ListItem>
        </asp:DropDownList></div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Tipo documento:</label>
        <div class="controls">
        <asp:DropDownList ID="cbTipoDoc" runat="server" AppendDataBoundItems="True">
        </asp:DropDownList>

    </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Número documento:</label>
        <div class="controls"><asp:TextBox ID="txtNumeroDoc" runat="server"></asp:TextBox>
 </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Sexo:</label>
        <div class="controls">
        <label class="radio inline">
        <asp:RadioButton ID="optMasculino" runat="server" TextAlign="Left" 
            GroupName="GrupoOp" Checked="True" />Masculino
              </label>    
        <label class="radio inline">     
        <asp:RadioButton ID="optFemenino" runat="server" TextAlign="Left" 
             GroupName="GrupoOp" />Femenino
             </label>
    </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Email:</label>
        <div class="controls">
        <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>

        <asp:RegularExpressionValidator ID="email" runat="server" 
            ControlToValidate="txtEmail" ErrorMessage="Ingrese un E-mail valido" 
            ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

    </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Telefono fijo:</label>
        <div class="controls">
        <asp:TextBox ID="txtTelFijo" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator ID="telefono" runat="server" 
            ControlToValidate="txtTelFijo" ErrorMessage="RegularExpressionValidator" 
            ForeColor="Red" ValidationExpression="^[0-9]*$ ">*</asp:RegularExpressionValidator>

</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Calle:</label>
        <div class="controls">
        <asp:TextBox ID="txtCalle" runat="server" ></asp:TextBox>

    &nbsp;<asp:RequiredFieldValidator ID="calle" runat="server" ErrorMessage="*" 
            ForeColor="Red" ControlToValidate="txtCalle"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Nro:</label>
        <div class="controls">
    <asp:TextBox ID="txtNro" runat="server" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="numero" runat="server" 
            ControlToValidate="txtNro" ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
   </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >País:</label>
        <div class="controls">
    <asp:DropDownList ID="cbPais" runat="server"
        onselectedindexchanged="cbPais_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>0</asp:ListItem>
    </asp:DropDownList>
</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Provincia:</label>
        <div class="controls"><asp:DropDownList ID="cbProvincia" runat="server"
        AutoPostBack="True" Enabled="False" 
        onselectedindexchanged="cbProvincia_SelectedIndexChanged">
    </asp:DropDownList>
</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Ciudad:</label>
        <div class="controls">
    <asp:DropDownList ID="cbCiudad" runat="server" Enabled="False">
    </asp:DropDownList>
</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Estado civil:</label>
        <div class="controls">   
    <asp:DropDownList ID="cbEstadoCivil" runat="server" >
    </asp:DropDownList>
</div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Disponibilidad:</label>
        <div class="controls">
        <asp:DropDownList ID="cbDisponibilidad" runat="server" >
        </asp:DropDownList>
   </div>
    </div>
    </fieldset>
        <fieldset><legend>2 - Conocimientos</legend>

 <div class="control-group" > 
         <label class="control-label" >Título:</label>
        <div class="controls">
    <asp:DropDownList ID="cbTitulo" runat="server" >
    </asp:DropDownList>
 </div></div>
<div class="control-group" > 
         <label class="control-label" >Lenguajes de programación:</label>
        <div class="controls">
     <asp:DropDownList ID="cbLenguaje" runat="server"> </asp:DropDownList>
    &nbsp;Nivel&nbsp;
     <asp:DropDownList ID="cbNivelLenguaje" runat="server">
     </asp:DropDownList>
    <asp:Button ID="btnAgregarLenguaje" class="btn" runat="server" Text="Agregar" 
         onclick="btnAgregarLenguaje_Click" CausesValidation="False" />
         </div></div>

         <div class="control-group" > 
         <div class="controls">
    <asp:GridView ID="gvLenguajes" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="idLenguaje" 
         onselectedindexchanged="gvLenguajes_SelectedIndexChanged" 
                 CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField HeaderText="Lenguaje" DataField="nombre" />
            <asp:BoundField HeaderText="Conocimiento" DataField="nivel" />
            <asp:BoundField DataField="idLengujae" HeaderText="idLenguaje" 
                Visible="False" />
            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Motores de base de datos:</label>
        <div class="controls">
        <asp:DropDownList ID="cbMotor" runat="server" >
    </asp:DropDownList>
    &nbsp;Nivel&nbsp;
    <asp:DropDownList ID="cbNivelMotor" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnAgregarMotores" class="btn" runat="server" Text="Agregar" 
        onclick="btnAgregarMotores_Click" CausesValidation="False" />

         </div></div> 
<div class="control-group" > 
              <div class="controls">
    <asp:GridView ID="gvMotores" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idMotor" onselectedindexchanged="gvMotores_SelectedIndexChanged" 
                      CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField HeaderText="Motor de BD" DataField="nombre" />
            <asp:BoundField HeaderText="Conocimiento" DataField="nivel" />
            <asp:BoundField DataField="idMotor" HeaderText="idMotorBD" Visible="False" />
            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
 </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Sistemas operativos:</label>
        <div class="controls">
    <asp:DropDownList ID="cbSOP" runat="server" >
    </asp:DropDownList>
    &nbsp;Nivel&nbsp;
    <asp:DropDownList ID="cbNivelSOP" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnAgregarSOP" class="btn" runat="server" Text="Agregar" 
        onclick="btnAgregarSOP_Click" CausesValidation="False" />
         </div></div>
    
 
<div class="control-group" >         
        <div class="controls">
    <asp:GridView ID="gvSOP" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idSisOP" onselectedindexchanged="gvSOP_SelectedIndexChanged" 
                CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField HeaderText="Sistema Operativo" DataField="nombre" />
            <asp:BoundField HeaderText="Conocimiento" DataField="nivel" />
            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
            <asp:BoundField DataField="idSisOP" Visible="False" />
        </Columns>
    </asp:GridView>
 </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Software:</label>
        <div class="controls">
    <asp:DropDownList ID="cbSW" runat="server" >
    </asp:DropDownList>
    &nbsp;Nivel&nbsp;
    <asp:DropDownList ID="cbNivelSW" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnAgregarSW" class="btn" runat="server" Text="Agregar" 
        onclick="btnAgregarSW_Click" CausesValidation="False" />
     </div></div>
    
 
<div class="control-group" > 
           <div class="controls">
    <asp:GridView ID="gvSoftware" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="idSoftware" 
            onselectedindexchanged="gvSoftware_SelectedIndexChanged" 
                   CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField HeaderText="Software" DataField="nombre" />
            <asp:BoundField HeaderText="Conocimiento" DataField="nivel" />
            <asp:BoundField DataField="idSoftware" HeaderText="idSoftware" 
                Visible="False" />
            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
        
   </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Conocimiento en:</label>
        <div class="controls">
            <label class="checkbox inline"><asp:CheckBox ID="cbxHerraOffice" runat="server"/>Herramientas office</label>
        <label class="checkbox inline"><asp:CheckBox ID="cbxSofModelado" runat="server" />Software de modelado</label>
           <label class="checkbox inline"> <asp:CheckBox ID="cbxRedes" runat="server" oncheckedchanged="CheckBox2_CheckedChanged"  />Redes</label>
<label class="checkbox inline"><asp:CheckBox ID="cbxBaseDatos" runat="server" />Base de datos</label>
  </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Idioma:</label>
        <div class="controls controls-row">
       <asp:DropDownList ID="cbIdioma" runat="server" >
       </asp:DropDownList>
    &nbsp;  &nbsp;Lee:
      <asp:DropDownList  ID="cbLee" runat="server">
    </asp:DropDownList>
    </div></div>
    
 
<div class="control-group" > 
         <label class="control-label" >Escribe:</label>
        <div class="controls controls-row">
    <asp:DropDownList ID="cbEscribe" runat="server">
    </asp:DropDownList>
      &nbsp;  &nbsp; Habla:
    <asp:DropDownList ID="cbHabla" runat="server">
    </asp:DropDownList>
        <asp:Button ID="btnAgregarIdioma" class="btn" runat="server" Text="Agregar" 
            CausesValidation="False" onclick="btnAgregarIdioma_Click" />
    </div></div>
    
 
<div class="control-group" > 
<div class="controls">
    <asp:GridView ID="gvIdioma"
            runat="server" AutoGenerateColumns="False" CellPadding="0" DataKeyNames="idIdioma" 
            onselectedindexchanged="gvIdioma_SelectedIndexChanged" 
        CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:BoundField HeaderText="Idioma" DataField="nombre" />
                <asp:BoundField HeaderText="Escrito" DataField="nivelEscribe" />
                <asp:BoundField HeaderText="Lee" DataField="nivelLee" />
                <asp:BoundField HeaderText="Habla" DataField="nivelHabla" />
                <asp:BoundField DataField="idIdioma" Visible="False" />
                <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BorderStyle="None" BorderWidth="0px" />
        </asp:GridView>
</div></div>
  </fieldset>
        <fieldset><legend>3 - Experiencia laboral</legend>
 <div class="control-group" > 
         <label class="control-label" >Empresa:</label>
        <div class="controls">
         <asp:TextBox ID="txtNombreEmpresa" runat="server" 
                 ></asp:TextBox>
     
     </div></div>
     <div class="control-group" > 
         <label class="control-label" >Rama o actividad:</label>
        <div class="controls">
        <asp:DropDownList ID="cbActivdad" runat="server" >
    </asp:DropDownList>
 </div></div>
     <div class="control-group" > 
         <label class="control-label" >Tipo de puesto o jerarquía:</label>
        <div class="controls">
    <asp:DropDownList ID="cbJerarquia" runat="server">
    </asp:DropDownList>
 </div></div>
     <div class="control-group" > 
         <label class="control-label" >Area:</label>
        <div class="controls">
    <asp:DropDownList ID="cbArea" runat="server" >
    </asp:DropDownList>
 </div></div>
     <div class="control-group" > 
         <label class="control-label" >Tiempo:</label>
        <div class="controls">
         <asp:DropDownList ID="cbTiempo" runat="server">
         </asp:DropDownList>
     
</div></div>
     <div class="control-group" > 
        <div class="controls">
     <asp:Button ID="btnGuardadCurriculum" class="btn btn-primary" runat="server" Text="Guardar Curriculum" 
         onclick="Button1_Click" CausesValidation="False" 
          />
</div></div>
    </fieldset></asp:Content>
