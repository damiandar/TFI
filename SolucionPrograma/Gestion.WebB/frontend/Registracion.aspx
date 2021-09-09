<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Registracion.aspx.vb" Inherits="carrito_Registracion" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div  class="form-horizontal" >
<div class="page registration-page">
<div class="page-title">
    <h1>Registracion</h1>
</div>
<div class="page-body">
    <fieldset class="form-fields">
        <legend>Datos Personales</legend>
                
                <div class="control-group">
                    <label class="control-label">Genero</label>
                    <div class="controls form-inline">
                        <label class="inline radio">
                            <input id="gender-male" name="Gender" type="radio" value="M"> 
                            Masculino
                        </label>
                        <label class="inline radio">
                            <input id="gender-female" name="Gender" type="radio" value="F"> 
                            Femenino
                        </label>
                    </div>
                </div>
                    
            <div class="control-group"><label class="control-label required" for="FirstName">Primer nombre</label>
<div class="controls">

<input data-val="true" data-val-required="Se requiere nombre" id="FirstName" name="FirstName" type="text" value="">
<span class="field-validation-valid" data-valmsg-for="FirstName" data-valmsg-replace="true"></span>
</div>
</div>

            <div class="control-group"><label class="control-label required" for="LastName">Nachname</label>
<div class="controls">
<input data-val="true" data-val-required="Nachname ist erforderlich" id="LastName" name="LastName" type="text" value="">
<span class="field-validation-valid" data-valmsg-for="LastName" data-valmsg-replace="true"></span>
</div>
</div>

<div class="control-group">
    <label class="control-label" for="DateOfBirthDay">Fecha de nacimiento</label>
    <div class="controls">
        <div class="select2-container date-part" id="s2id_autogen1" style="width: 70px">    <a href="#" onclick="return false;" class="select2-choice select2-default">   <span>Tag</span><abbr class="select2-search-choice-close" style="display:none;"></abbr>   <div><b></b></div></a>    <div class="select2-drop select2-offscreen">   <div class="select2-search">       <input type="text" autocomplete="off" class="select2-input">   </div>   <ul class="select2-results">   </ul></div></div><select class="date-part" data-select-min-results-for-search="100" name="DateOfBirthDay" style="width: 70px; display: none;"><option></option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option></select><div class="select2-container date-part" id="s2id_autogen2" style="width: 130px">    <a href="#" onclick="return false;" class="select2-choice select2-default">   <span>Monat</span><abbr class="select2-search-choice-close" style="display:none;"></abbr>   <div><b></b></div></a>    <div class="select2-drop select2-offscreen">   <div class="select2-search">       <input type="text" autocomplete="off" class="select2-input">   </div>   <ul class="select2-results">   </ul></div></div><select class="date-part" data-select-min-results-for-search="100" name="DateOfBirthMonth" style="width: 130px; display: none;"><option></option><option value="1">Januar</option><option value="2">Februar</option><option value="3">März</option><option value="4">April</option><option value="5">Mai</option><option value="6">Juni</option><option value="7">Juli</option><option value="8">August</option><option value="9">September</option><option value="10">Oktober</option><option value="11">November</option><option value="12">Dezember</option></select><div class="select2-container date-part" id="s2id_autogen3" style="width: 90px">    <a href="#" onclick="return false;" class="select2-choice select2-default">   <span>Jahr</span><abbr class="select2-search-choice-close" style="display:none;"></abbr>   <div><b></b></div></a>    <div class="select2-drop select2-offscreen">   <div class="select2-search">       <input type="text" autocomplete="off" class="select2-input">   </div>   <ul class="select2-results">   </ul></div></div><select class="date-part" name="DateOfBirthYear" style="width: 90px; display: none;"><option></option><option value="1906">1906</option><option value="1907">1907</option><option value="1908">1908</option><option value="1909">1909</option><option value="1910">1910</option><option value="1911">1911</option><option value="1912">1912</option><option value="1913">1913</option><option value="1914">1914</option><option value="1915">1915</option><option value="1916">1916</option><option value="1917">1917</option><option value="1918">1918</option><option value="1919">1919</option><option value="1920">1920</option><option value="1921">1921</option><option value="1922">1922</option><option value="1923">1923</option><option value="1924">1924</option><option value="1925">1925</option><option value="1926">1926</option><option value="1927">1927</option><option value="1928">1928</option><option value="1929">1929</option><option value="1930">1930</option><option value="1931">1931</option><option value="1932">1932</option><option value="1933">1933</option><option value="1934">1934</option><option value="1935">1935</option><option value="1936">1936</option><option value="1937">1937</option><option value="1938">1938</option><option value="1939">1939</option><option value="1940">1940</option><option value="1941">1941</option><option value="1942">1942</option><option value="1943">1943</option><option value="1944">1944</option><option value="1945">1945</option><option value="1946">1946</option><option value="1947">1947</option><option value="1948">1948</option><option value="1949">1949</option><option value="1950">1950</option><option value="1951">1951</option><option value="1952">1952</option><option value="1953">1953</option><option value="1954">1954</option><option value="1955">1955</option><option value="1956">1956</option><option value="1957">1957</option><option value="1958">1958</option><option value="1959">1959</option><option value="1960">1960</option><option value="1961">1961</option><option value="1962">1962</option><option value="1963">1963</option><option value="1964">1964</option><option value="1965">1965</option><option value="1966">1966</option><option value="1967">1967</option><option value="1968">1968</option><option value="1969">1969</option><option value="1970">1970</option><option value="1971">1971</option><option value="1972">1972</option><option value="1973">1973</option><option value="1974">1974</option><option value="1975">1975</option><option value="1976">1976</option><option value="1977">1977</option><option value="1978">1978</option><option value="1979">1979</option><option value="1980">1980</option><option value="1981">1981</option><option value="1982">1982</option><option value="1983">1983</option><option value="1984">1984</option><option value="1985">1985</option><option value="1986">1986</option><option value="1987">1987</option><option value="1988">1988</option><option value="1989">1989</option><option value="1990">1990</option><option value="1991">1991</option><option value="1992">1992</option><option value="1993">1993</option><option value="1994">1994</option><option value="1995">1995</option><option value="1996">1996</option><option value="1997">1997</option><option value="1998">1998</option><option value="1999">1999</option><option value="2000">2000</option><option value="2001">2001</option><option value="2002">2002</option><option value="2003">2003</option><option value="2004">2004</option><option value="2005">2005</option><option value="2006">2006</option><option value="2007">2007</option><option value="2008">2008</option><option value="2009">2009</option><option value="2010">2010</option><option value="2011">2011</option><option value="2012">2012</option><option value="2013">2013</option><option value="2014">2014</option><option value="2015">2015</option><option value="2016">2016</option></select>
        <span class="field-validation-valid" data-valmsg-for="DateOfBirthDay" data-valmsg-replace="true"></span>
        <span class="field-validation-valid" data-valmsg-for="DateOfBirthMonth" data-valmsg-replace="true"></span>
        <span class="field-validation-valid" data-valmsg-for="DateOfBirthYear" data-valmsg-replace="true"></span>
    </div>
</div>

<div class="control-group"><label class="control-label required" for="Email">E-Mail</label>
    <div class="controls">
        <input data-val="true" data-val-email="Falsche E-Mail" data-val-required="E-Mail wird benötigt." id="Email" name="Email" type="text" value="">
    </div>
</div>

<div class="control-group">
    <label class="control-label required" for="Username">Benutzername</label>
        <div class="controls">
            <div class="input-append">
                <input class="text-box single-line" id="Username" name="Username" type="text" value="">
                    <script type="text/javascript">
                                    $(function () {
                                        $('#Username').closest(".input-append").after('<figure id="cua-loader" class="ajax-loader-small hide" style="margin-left: 4px"></figure>');
                                        $('#Username').bind({
                                            change: function () {
                                                $('#username-availabilty').text('');
                                                $('#check-availability-button')
            .removeClass("btn-success btn-warning")
            .find(">i")
            .removeClass("fa-check fa-exclamation-circle")
            .addClass("fa-question-circle");
                                            }
                                        });
                                        $('#check-availability-button').click(function () {
                                            var btn = $('#check-availability-button');
                                            $('#username-availabilty').text('');
                                            if ($("#Username").val().length > 0) {
                                                $('#cua-loader').removeClass("hide");
                                                btn.attr('disabled', 'disabled');
                                                $.ajax({
                                                    cache: false,
                                                    type: 'POST',
                                                    url: '/frontend/Customer/CheckUsernameAvailability',
                                                    data: $('#Username').serialize(),
                                                    dataType: 'json',
                                                    success: function (data) {
                                                        btn.removeAttr('disabled');
                                                        btn
                    .removeClass("btn-success btn-warning")
                    .addClass(data.Available ? "btn-success" : "btn-warning")
                    .find(">i")
                    .removeClass("fa-check fa-question-circle fa-exclamation-circle")
                    .addClass(data.Available ? "fa-check" : "fa-exclamation-circle");

                                                        displayNotification(data.Text, data.Available ? "success" : "error");
                                                    },
                                                    complete: function () {
                                                        btn.removeAttr('disabled');
                                                        $('#cua-loader').addClass("hide");
                                                    }
                                                });
                                            } else {
                                                $('#username-availabilty').attr('class', 'not-available-status');
                                                $('#username-availabilty').text('*');
                                            }
                                            return false;
                                        });
                                    });
</script>
                <button type="button" id="check-availability-button" class="btn check-username-availability-button tooltip-toggle" data-original-title="Prüfe Verfügbarkeit">
                <i class="fa fa-question-circle"></i>
                </button>
            </div>
    <figure id="cua-loader" class="ajax-loader-small hide" style="margin-left: 4px"></figure>
    <span class="field-validation-valid" data-valmsg-for="Username" data-valmsg-replace="true"></span>
    </div>
</div>
                
</fieldset>

<fieldset class="form-fields">
            <legend>Detalles de la compañía</legend>
                    
<div class="control-group"><label class="control-label" for="Company">Nombre de compañía</label>
    <div class="controls">
        <input id="Company" name="Company" placeholder="Optional" type="text" value="">
    </div>
</div>
<div class="control-group">
    <label class="control-label" for="VatNumber">CUIT</label>
    <div class="controls">
        <input id="VatNumber" name="VatNumber" placeholder="Optional" type="text" value="">&nbsp;&nbsp;&nbsp;
    </div>
</div>
                    
</fieldset>

<fieldset class="form-fields">
            <legend>Optionen</legend>
            <div class="control-group"><div class="controls">
<label class="checkbox">

<input class="check-box" data-val="true" data-val-required="'Newsletter' darf keinen Null-Wert aufweisen." id="Newsletter" name="Newsletter" type="checkbox" value="true"><input name="Newsletter" type="hidden" value="false"> Newsletter abonnieren (Abmeldung jederzeit möglich)</label>
<span class="field-validation-valid" data-valmsg-for="Newsletter" data-valmsg-replace="true"></span>
</div>
</div>

        </fieldset>

<fieldset class="form-fields">
<legend>Otro</legend>
                    
<div class="control-group">
                    <label class="control-label" for="TimeZoneId">Zeitzone</label>
                    <div class="controls">
                        <div class="select2-container" id="s2id_TimeZoneId" style="width: 433px">    <a href="#" onclick="return false;" class="select2-choice">   <span>(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</span><abbr class="select2-search-choice-close" style="display:none;"></abbr>   <div><b></b></div></a>    <div class="select2-drop select2-offscreen">   <div class="select2-search">       <input type="text" autocomplete="off" class="select2-input">   </div>   <ul class="select2-results">   </ul></div></div>
                        <select id="TimeZoneId" name="TimeZoneId" style="display: none;">
                                
                        <option value="Dateline Standard Time">(UTC-12:00) International Date Line West</option>
                        <option value="Argentina Standard Time">(UTC-03:00) Buenos Aires</option>
</select>
                        <span class="field-validation-valid" data-valmsg-for="TimeZoneId" data-valmsg-replace="true"></span>
                    </div>
                </div>
                                        
</fieldset>

<fieldset class="form-fields">
        <legend>Contraseña</legend>
                
<div class="control-group"><label class="control-label required" for="Password">Contraseña</label>
    <div class="controls">
        <input data-val="true" data-val-length="Das Passwort muss mindestens 6 Zeichen lang sein." data-val-length-max="999" data-val-length-min="6" data-val-required="Das Passwort ist erforderlich" id="Password" name="Password" type="password">
    </div>
</div>
    
<div class="control-group"><label class="control-label required" for="ConfirmPassword">Confirmación de la contraseña</label>
    <div class="controls">
        <input data-val="true" data-val-equalto="Passwort und Bestätigung stimmen nicht überein." data-val-equalto-other="*.Password" data-val-required="Passwort wird benötigt" id="ConfirmPassword" name="ConfirmPassword" type="password">
    </div>
</div>
</fieldset>

<div class="control-group buttons">
    <div class="controls"><button type="submit" class="btn btn-primary" name="register-button">Registro</button></div>
</div>

</div>
</div>
</div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>--%>

