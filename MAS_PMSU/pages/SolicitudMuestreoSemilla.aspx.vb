Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared].Json
Imports DocumentFormat.OpenXml.Office.Word
Imports MySql.Data.MySqlClient

Public Class SolicitudMuestreoSemilla
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String
    Dim validarflag As Integer
    Dim validarflag2 As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then

            Else
                'txtFechaSiembra.Text = DateTime.Now.ToString("yyyy-MM-dd")
                'DivActa.Style.Add("display", "none")
                DivGrid.Style.Add("display", "block")
                llenarcomboDepto()
                llenarcomboCiclo()
                VerificarTextBox()
                Verificar()
                FillComboBoxWithProductorNames()
                llenagrid()
            End If
        End If
    End Sub
    Protected Sub vaciar(sender As Object, e As EventArgs)
        Response.Redirect("SolicitudMuestreoSemilla.aspx")
    End Sub
    Protected Sub BtnNewActa_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(TxtProductor.SelectedValue) Then

        Else

        End If
        'DivActa.Style.Add("display", "block")
        DivGrid.Style.Add("display", "none")
        btnGuardarActa.Visible = True
    End Sub
    Private Sub FillComboBoxWithProductorNames()
        Dim StrCombo As String = "SELECT PROD_NOMBRE FROM registros_bancos_semilla"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TxtProductor.DataSource = DtCombo
        TxtProductor.DataValueField = DtCombo.Columns(0).ToString()
        TxtProductor.DataTextField = DtCombo.Columns(0).ToString
        TxtProductor.DataBind()
        Dim newitem2 As New ListItem(" ", " ")
        TxtProductor.Items.Insert(0, newitem2)
    End Sub
    Private Sub llenarcomboCiclo()
        Dim StrCombo As String = "SELECT * FROM redpash_ciclo"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TxtCiclo.DataSource = DtCombo
        TxtCiclo.DataValueField = DtCombo.Columns(0).ToString()
        TxtCiclo.DataTextField = DtCombo.Columns(1).ToString
        TxtCiclo.DataBind()
        Dim newitem As New ListItem(" ", " ")
        TxtCiclo.Items.Insert(0, newitem)

        DDL_Ciclo.DataSource = DtCombo
        DDL_Ciclo.DataValueField = DtCombo.Columns(0).ToString()
        DDL_Ciclo.DataTextField = DtCombo.Columns(1).ToString
        DDL_Ciclo.DataBind()
        Dim newitem2 As New ListItem(" ", " ")
        DDL_Ciclo.Items.Insert(0, newitem2)
        'VerificarTextBox()
    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT * FROM tb_departamentos"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_departamento_new.DataSource = DtCombo
        gb_departamento_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_departamento_new.DataTextField = DtCombo.Columns(2).ToString
        gb_departamento_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_departamento_new.Items.Insert(0, newitem)

        DDL_Depto.DataSource = DtCombo
        DDL_Depto.DataValueField = DtCombo.Columns(0).ToString()
        DDL_Depto.DataTextField = DtCombo.Columns(2).ToString
        DDL_Depto.DataBind()
        Dim newitem2 As New ListItem(" ", " ")
        DDL_Depto.Items.Insert(0, newitem2)
        'VerificarTextBox()
    End Sub

    Private Function DevolverValorDepart(cadena As String)

        If gb_departamento_new.SelectedItem.Text <> "" Then
            Dim codigoDepartamento As String = ""
            Dim StrCombo As String = "SELECT CODIGO_DEPARTAMENTO FROM tb_departamentos WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoDepartamento = DtCombo.Rows(0)("CODIGO_DEPARTAMENTO").ToString()
            Return codigoDepartamento
        End If

        Return 0
        'VerificarTextBox()
    End Function

    Private Function DevolverValorMuni(cadena As String)
        If gb_municipio_new.SelectedItem.Text <> "" Then
            Dim codigoMunicipio As String = ""
            Dim StrCombo As String = "SELECT CODIGO_MUNICIPIO FROM tb_municipio WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoMunicipio = DtCombo.Rows(0)("CODIGO_MUNICIPIO").ToString()
            Return codigoMunicipio
        End If
        Return 0
        'VerificarTextBox()
    End Function

    Private Function DevolverValorAlde(cadena As String)
        If gb_aldea_new.SelectedItem.Text <> "" Then
            Dim codigoCaserio As String = ""
            Dim StrCombo As String = "SELECT CODIGO_ALDEA FROM tb_aldea WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoCaserio = DtCombo.Rows(0)("CODIGO_ALDEA").ToString()
            Return codigoCaserio
        End If
        Return 0
        'VerificarTextBox()
    End Function
    Private Sub llenarmunicipio()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim departamento As String = DevolverValorDepart(gb_departamento_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_municipio WHERE CODIGO_DEPARTAMENTO = " & departamento & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_municipio_new.DataSource = DtCombo
        gb_municipio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_municipio_new.DataTextField = DtCombo.Columns(3).ToString
        gb_municipio_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_municipio_new.Items.Insert(0, newitem)
        'VerificarTextBox()
        'End If
    End Sub

    Private Sub llenarAldea()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim municipio As String = DevolverValorMuni(gb_municipio_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_aldea WHERE CODIGO_MUNICIPIO = " & municipio & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_aldea_new.DataSource = DtCombo
        gb_aldea_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_aldea_new.DataTextField = DtCombo.Columns(3).ToString
        gb_aldea_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_aldea_new.Items.Insert(0, newitem)
        'VerificarTextBox()
        'End If
    End Sub

    Private Sub llenarCaserio()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim aldea As String = DevolverValorAlde(gb_aldea_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_caserios WHERE CODIGO_ALDEA = " & aldea & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_caserio_new.DataSource = DtCombo
        gb_caserio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_caserio_new.DataTextField = DtCombo.Columns(5).ToString
        gb_caserio_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_caserio_new.Items.Insert(0, newitem)
        'VerificarTextBox()
        'End If
    End Sub
    Protected Sub CmbTipoSemilla_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Obtiene el valor seleccionado en la DropDownList
        Dim selectedValue As String = CmbTipoSemilla.SelectedValue

        ' Si selecciona "Frijol," muestra la TextBox de Variedad; de lo contrario, ocúltala
        If selectedValue = "Frijol" Then
            VariedadFrijol.Visible = True
            VariedadMaiz.Visible = False
        ElseIf selectedValue = "Maiz" Then
            VariedadMaiz.Visible = True
            VariedadFrijol.Visible = False
        Else
            VariedadMaiz.Visible = False
            VariedadFrijol.Visible = False
        End If
        llenagrid()
        VerificarTextBox()
    End Sub

    Protected Sub VerificarTextBox()
        If (TxtCiclo.SelectedItem.Text = " ") Then
            Label7.Text = "*"
            validarflag = 0
        Else
            Label7.Text = ""
            validarflag = 1
        End If

        If (TxtProductor.SelectedItem.Text = " ") Then
            Label8.Text = "*"
            validarflag = 0
        Else
            Label8.Text = ""
            validarflag = 1
        End If

        If (CmbTipoSemilla.SelectedItem.Text = " ") Then
            Label9.Text = "*"
            validarflag = 0
        Else
            Label9.Text = ""
            validarflag = 1
        End If

        If (DDL_VariedadF.SelectedItem.Text = " ") Then
            Label3.Text = "*"
            validarflag = 0
        Else
            Label3.Text = ""
            validarflag = 1
        End If

        If (DDL_VariedadM.SelectedItem.Text = " ") Then
            Label4.Text = "*"
            validarflag = 0
        Else
            Label4.Text = ""
            validarflag = 1
        End If

        If (gb_departamento_new.SelectedItem.Text = " ") Then
            lb_dept_new.Text = "*"
            validarflag = 0
        Else
            lb_dept_new.Text = ""
            validarflag = 1
        End If

        If (gb_municipio_new.SelectedItem.Text = " ") Then
            lb_mun_new.Text = "*"
            validarflag = 0
        Else
            lb_mun_new.Text = ""
            validarflag = 1
        End If

        If (gb_aldea_new.SelectedItem.Text = " ") Then
            lb_aldea_new.Text = "*"
            validarflag = 0
        Else
            lb_aldea_new.Text = ""
            validarflag = 1
        End If

        If (gb_caserio_new.SelectedItem.Text = " ") Then
            lb_caserio_new.Text = "*"
            validarflag = 0
        Else
            lb_caserio_new.Text = ""
            validarflag = 1
        End If

        If (DDL_Categ.SelectedItem.Text = " ") Then
            Label10.Text = "*"
            validarflag = 0
        Else
            Label10.Text = ""
            validarflag = 1
        End If

        If (TxtFechCose.Text = "") Then
            Label5.Text = "*"
            validarflag = 0
        Else
            Label5.Text = ""
            validarflag = 1
        End If

        If (TxtQQCose.Text = "") Then
            Label6.Text = "*"
            validarflag = 0
        Else
            Label6.Text = ""
            validarflag = 1
        End If

        generarlote()

    End Sub
    Protected Sub generarlote()
        ' Verificar si se ha seleccionado algo en TxtCiclo
        If TxtCiclo.SelectedIndex > 0 Then
            ' Verificar si se ha seleccionado algo en gb_departamento_new
            If gb_departamento_new.SelectedIndex > 0 Then
                ' Verificar si se ha seleccionado algo en TxtProductor
                If TxtProductor.SelectedIndex > 0 Then
                    ' Obtener el valor seleccionado en TxtCiclo
                    Dim cicloSeleccionado As String = TxtCiclo.SelectedItem.Text

                    ' Obtener el valor seleccionado en gb_departamento_new
                    Dim departamentoSeleccionado As String = gb_departamento_new.SelectedItem.Text
                    ' Obtener las primeras 3 letras del departamento
                    Dim primeras3LetrasDepartamento As String = departamentoSeleccionado.Substring(0, Math.Min(departamentoSeleccionado.Length, 3))

                    ' Obtener el valor seleccionado en TxtProductor
                    Dim productorSeleccionado As String = TxtProductor.SelectedItem.Text
                    ' Obtener las iniciales del productor
                    Dim inicialesProductor As String = String.Join("", productorSeleccionado.Split().Select(Function(s) s(0)))

                    ' Obtener las últimas dos letras y el último caracter de TxtCiclo
                    Dim ultimasLetrasCiclo As String = cicloSeleccionado.Substring(cicloSeleccionado.Length - 1, 1) & cicloSeleccionado.Substring(cicloSeleccionado.Length - 10, 2)

                    ' Obtener numero de lote
                    Dim nlote As String = "-L-"

                    ' Construir el texto para TxtLoteSemi
                    Dim textoLoteSemi As String = "RP-" & primeras3LetrasDepartamento & "-" & inicialesProductor & nlote & ultimasLetrasCiclo

                    ' Asignar el texto a TxtLoteSemi
                    TxtLoteSemi.Text = textoLoteSemi
                End If
            End If
        End If
    End Sub

    Sub llenagrid()

        Dim cadena As String = "ID, Departamento, Productor, Tipo_cultivo, CATEGORIA, CICLO, VARIEDAD, NOMBRE_LOTE_FINCA, AREA_SEMBRADA_MZ, AREA_SEMBRADA_HA, DATE_FORMAT(FECHA_SIEMBRA, '%d-%m-%Y') AS FECHA_SIEMBRA, ESTIMADO_PRO_QQ_MZ, ESTIMADO_PRO_QQ_HA, Habilitado"
        Dim c1 As String = ""
        Dim c2 As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND Productor = '" & TxtProductor.SelectedItem.Text & "' "
        End If

        If (CmbTipoSemilla.SelectedItem.Text = " ") Then
            c2 = " "
        Else
            c2 = "AND Tipo_cultivo = '" & CmbTipoSemilla.SelectedItem.Text & "' "
        End If

        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Estado = '1' " & c1 & c2 & "ORDER BY Productor,Tipo_cultivo"

    End Sub

    Protected Sub gb_departamento_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_departamento_new.SelectedIndexChanged
        llenarmunicipio()
        VerificarTextBox()
    End Sub

    Protected Sub gb_municipio_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_municipio_new.SelectedIndexChanged
        llenarAldea()
        VerificarTextBox()
    End Sub

    Protected Sub gb_aldea_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_aldea_new.SelectedIndexChanged
        llenarCaserio()
        VerificarTextBox()
    End Sub
    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

            'TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString

            If dt.Rows.Count > 0 Then
                'TxtAreaSembMz.Text = dt.Rows(0)("AREA_TERRENO_SEMBRADA_MZ").ToString
            Else

            End If

        End If
    End Sub
    Protected Sub PageDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos.PageIndex = pageList.SelectedIndex
        llenagrid()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub

    Protected Sub GridDatos_DataBound(sender As Object, e As EventArgs) Handles GridDatos.DataBound
        If (GridDatos.Rows.Count > 0) Then
            ' Recupera la el PagerRow...
            Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
            ' Recupera los controles DropDownList y label...
            Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
            Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("CurrentPageLabel"), Label)
            If Not pageList Is Nothing Then
                ' Se crean los valores del DropDownList tomando el número total de páginas...
                Dim i As Integer
                For i = 0 To GridDatos.PageCount - 1
                    ' Se crea un objeto ListItem para representar la �gina...
                    Dim pageNumber As Integer = i + 1
                    Dim item As ListItem = New ListItem(pageNumber.ToString())
                    If i = GridDatos.PageIndex Then
                        item.Selected = True
                    End If
                    ' Se añade el ListItem a la colección de Items del DropDownList...
                    pageList.Items.Add(item)
                Next i
            End If
            If Not pageLabel Is Nothing Then
                ' Calcula el nº de �gina actual...
                Dim currentPage As Integer = GridDatos.PageIndex + 1
                ' Actualiza el Label control con la �gina actual.
                pageLabel.Text = "Página " & currentPage.ToString() & " de " & GridDatos.PageCount.ToString()
            End If
        End If
    End Sub

    Protected Sub DropDownList7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub btnGuardarActa_Click(sender As Object, e As EventArgs)
        ' Verifica si los elementos no están vacíos
        If validarflag = 0 Then

            validarflag = 0
            Verificar()
            If validarflag = 0 Then
                btnGuardarActa.Visible = False
                BtnImprimir.Visible = True
                BtnNuevo.Visible = True

                'Funcion para guardar en la BD
                GuardarActa()

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
            Else
                Label103.Text = "Debe ingresar toda la informacion primero"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
            End If

        Else
            Label103.Text = "Debe ingresar toda la informacion primero"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub

    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Verificar()
        If validarflag2 = 1 Then
            Dim rptdocument As New ReportDocument
            'nombre de dataset
            Dim ds As New DataSetLotes
            Dim Str As String = "SELECT * FROM solicitud_inscripcion_delotes WHERE nombre_lote = @valor"
            Dim adap As New MySqlDataAdapter(Str, conn)
            adap.SelectCommand.Parameters.AddWithValue("@valor", TxtProductor.Text)
            Dim dt As New DataTable
            adap.Fill(ds, "solicitud_inscripcion_delotes")
            Dim nombre As String

            nombre = "Solicitud Inscripcion de Lote o Campo _" + Today
            rptdocument.Load(Server.MapPath("~/pages/Solicitud Inscripcion de Lote.rpt"))
            rptdocument.SetDataSource(ds)
            Response.Buffer = False
            Response.ClearContent()
            Response.ClearHeaders()
            rptdocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, True, nombre)

            Response.End()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If

    End Sub
    Protected Sub Verificar()
        If (DDL_Ciclo.SelectedItem.Text = " ") Then
            Label11.Text = "*"
            validarflag2 = 0
        Else
            Label11.Text = ""
            validarflag2 = 1
        End If

        If (DDL_Depto.SelectedItem.Text = " ") Then
            Label12.Text = "*"
            validarflag2 = 0
        Else
            Label12.Text = ""
            validarflag2 = 1
        End If

        If (txtFechaSoli.Text = "") Then
            Label13.Text = "*"
            validarflag2 = 0
        Else
            Label13.Text = ""
            validarflag2 = 1
        End If

        If (TxtLugar.Text = "") Then
            Label14.Text = "*"
            validarflag2 = 0
        Else
            Label14.Text = ""
            validarflag2 = 1
        End If

        If (TxtPara.Text = "") Then
            Label15.Text = "*"
            validarflag2 = 0
        Else
            Label15.Text = ""
            validarflag2 = 1
        End If
    End Sub

    Protected Sub GuardarActa()
        'Aqui se guardara la informacion en la base de datos
    End Sub
End Class

