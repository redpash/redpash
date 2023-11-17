Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared].Json
Imports DocumentFormat.OpenXml.Office.Word
Imports MySql.Data.MySqlClient

Public Class ActaRecepcionSemilla
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String
    Dim validarflag As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then

            Else
                txtFechaSiembra.Text = DateTime.Now.ToString("yyyy-MM-dd")
                DivActa.Style.Add("display", "none")
                DivGrid.Style.Add("display", "block")
                FillComboBoxWithProductorNames()
                Verificarvariedades()
                DDL_cultivo_SelectedIndexChanged()
                llenagrid()
            End If
        End If
    End Sub
    Protected Sub vaciar(sender As Object, e As EventArgs)
        Response.Redirect("ActaRecepcionSemilla.aspx")
    End Sub
    Protected Sub BtnNewActa_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(TxtProductor.SelectedValue) Then
            txt_nombre_prod_new.Text = ""
        Else
            txt_nombre_prod_new.Text = TxtProductor.SelectedValue
        End If
        DivActa.Style.Add("display", "block")
        DivGrid.Style.Add("display", "none")
        btnGuardarActa.Visible = True
    End Sub
    Private Sub FillComboBoxWithProductorNames()
        Dim StrCombo As String = "SELECT PROD_NOMBRE FROM registros_bancos_semilla"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        DropDownList7.DataSource = DtCombo
        DropDownList7.DataValueField = DtCombo.Columns(0).ToString()
        DropDownList7.DataTextField = DtCombo.Columns(0).ToString
        DropDownList7.DataBind()
        Dim newitem As New ListItem(" ", " ")
        DropDownList7.Items.Insert(0, newitem)

        TxtProductor.DataSource = DtCombo
        TxtProductor.DataValueField = DtCombo.Columns(0).ToString()
        TxtProductor.DataTextField = DtCombo.Columns(0).ToString
        TxtProductor.DataBind()
        Dim newitem2 As New ListItem(" ", " ")
        TxtProductor.Items.Insert(0, newitem2)
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

        If (DDL_SelCult.SelectedItem.Text = " ") Then
            c2 = " "
        Else
            c2 = "AND Tipo_cultivo = '" & DDL_SelCult.SelectedItem.Text & "' "
        End If

        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Estado = '1' " & c1 & c2 & "ORDER BY Productor,Tipo_cultivo"

    End Sub
    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
    End Sub
    Protected Sub DDL_SelCult_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_SelCult.SelectedIndexChanged
        llenagrid()
    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then
            btnGuardarActa.Text = "Editar"
            BtnImprimir.Visible = True
            BtnNuevo.Visible = True
            Label103.Text = "El Acta de Recepcion de semilla ha sido editada con exito"
            If String.IsNullOrEmpty(TxtProductor.SelectedValue) Then
                txt_nombre_prod_new.Text = ""
            Else
                txt_nombre_prod_new.Text = TxtProductor.SelectedValue
            End If
            DivActa.Style.Add("display", "block")
            DivGrid.Style.Add("display", "none")
            btnGuardarActa.Visible = True

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


    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Dim rptdocument As New ReportDocument
        'nombre de dataset
        Dim ds As New DataSetLotes
        Dim Str As String = "SELECT * FROM solicitud_inscripcion_delotes WHERE nombre_lote = @valor"
        Dim adap As New MySqlDataAdapter(Str, conn)
        adap.SelectCommand.Parameters.AddWithValue("@valor", DropDownList7.Text)
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
    End Sub
    Protected Sub DropDownList7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedValue As String = DropDownList7.SelectedValue
        txt_nombre_prod_new.Text = selectedValue
    End Sub
    Protected Sub Verificarvariedades()
        If DDL_Amadeus.SelectedValue = "Si" Then
            div1.Style.Add("display", "block")
        Else
            div1.Style.Add("display", "none")
        End If

        If DDL_Carrizalito.SelectedValue = "Si" Then
            div2.Style.Add("display", "block")
        Else
            div2.Style.Add("display", "none")
        End If

        If DDL_Deorho.SelectedValue = "Si" Then
            div3.Style.Add("display", "block")
        Else
            div3.Style.Add("display", "none")
        End If

        If DDL_Azabache.SelectedValue = "Si" Then
            div4.Style.Add("display", "block")
        Else
            div4.Style.Add("display", "none")
        End If

        If DDL_ParaisitoMejoradoPM2.SelectedValue = "Si" Then
            div5.Style.Add("display", "block")
        Else
            div5.Style.Add("display", "none")
        End If

        If DDL_Hondurasnutritivo.SelectedValue = "Si" Then
            div6.Style.Add("display", "block")
        Else
            div6.Style.Add("display", "none")
        End If

        If DDL_IntaCardenas.SelectedValue = "Si" Then
            div7.Style.Add("display", "block")
        Else
            div7.Style.Add("display", "none")
        End If

        If DDL_Lencaprecoz.SelectedValue = "Si" Then
            div8.Style.Add("display", "block")
        Else
            div8.Style.Add("display", "none")
        End If

        If DDL_Rojochorti.SelectedValue = "Si" Then
            div9.Style.Add("display", "block")
        Else
            div9.Style.Add("display", "none")
        End If

        If DDL_Tolupanrojo.SelectedValue = "Si" Then
            div10.Style.Add("display", "block")
        Else
            div10.Style.Add("display", "none")
        End If

        If DDL_Otravariedad.SelectedValue = "Si" Then
            div11.Style.Add("display", "block")
            DivVariedadNombre.Style.Add("display", "block")
        Else
            div11.Style.Add("display", "none")
            DivVariedadNombre.Style.Add("display", "none")
        End If
        '*************************************************************
        If DDL_DictaMaya.SelectedValue = "Si" Then
            div12.Style.Add("display", "block")
        Else
            div12.Style.Add("display", "none")
        End If

        If DDL_DictaVictoria.SelectedValue = "Si" Then
            div13.Style.Add("display", "block")
        Else
            div13.Style.Add("display", "none")
        End If

        If DDL_OtravariedadM.SelectedValue = "Si" Then
            div15.Style.Add("display", "block")
            DivVariedaNombreM.Style.Add("display", "block")
        Else
            div15.Style.Add("display", "none")
            DivVariedaNombreM.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DDL_cultivo_SelectedIndexChanged()
        If DDL_cultivo.SelectedValue = "Frijol" Then
            DivVariedadFrijol.Style.Add("display", "block")
            DivVariedadesMaiz.Style.Add("display", "none")
        ElseIf DDL_cultivo.SelectedValue = "Maiz" Then
            DivVariedadFrijol.Style.Add("display", "none")
            DivVariedadesMaiz.Style.Add("display", "block")
        Else
            DivVariedadFrijol.Style.Add("display", "none")
            DivVariedadesMaiz.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub btnGuardarActa_Click(sender As Object, e As EventArgs)
        ' Verifica si los elementos no están vacíos
        If Not String.IsNullOrWhiteSpace(txtFechaSiembra.Text) AndAlso
           Not String.IsNullOrWhiteSpace(txt_nombre_prod_new.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TxtCeduIden.Text) AndAlso
           Not String.IsNullOrWhiteSpace(DDL_cultivo.SelectedValue) Then

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
            ' Si algún elemento está vacío, muestra mensajes en las Label correspondientes
            If String.IsNullOrWhiteSpace(txtFechaSiembra.Text) Then
                Label14.Text = "Fecha de recepción es obligatoria"
            Else
                Label14.Text = ""
            End If

            If String.IsNullOrWhiteSpace(txt_nombre_prod_new.Text) Then
                lb_nombre_new.Text = "Nombre del productor es obligatorio"
            Else
                lb_nombre_new.Text = ""
            End If

            If String.IsNullOrWhiteSpace(TxtCeduIden.Text) Then
                Label1.Text = "Cédula de Identidad es obligatoria"
            Else
                Label1.Text = ""
            End If

            If String.IsNullOrWhiteSpace(DDL_cultivo.SelectedValue) Then
                Label104.Text = "Tipo de cultivo es obligatorio"
            Else
                Label104.Text = ""
            End If
            Label103.Text = "Debe ingresar toda la informacion primero"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub

    Protected Sub VerificarSiAmadeusEsSi()
        ' Verifica si la selección en DDL_Amadeus es "Si"
        If DDL_Amadeus.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Amadeus_Certificado.SelectedValue) Then
                Label5.Text = "Ingrese información"
                validarflag = 1
            Else
                Label5.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Amadeus_Comercial.SelectedValue) Then
                Label6.Text = "Ingrese información"
                validarflag = 1
            Else
                Label6.Text = ""
            End If

            If String.IsNullOrEmpty(txtAmadeusHumedad.Text) Then
                Label2.Text = "Ingrese información"
                validarflag = 1
            Else
                Label2.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosAmadeus.Text) Then
                Label45.Text = "Ingrese información"
                validarflag = 1
            Else
                Label45.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimAmadeus.Text) Then
                Label46.Text = "Ingrese información"
                validarflag = 1
            Else
                Label46.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutAmadeus.Text) Then
                Label47.Text = "Ingrese información"
                validarflag = 1
            Else
                Label47.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiCarrizalitoEsSi()
        ' Verifica si la selección en DDL_Carrizalito es "Si"
        If DDL_Carrizalito.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Carrizalito_Certificado.SelectedValue) Then
                Label7.Text = "Ingrese información"
                validarflag = 1
            Else
                Label7.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Carrizalito_Comercial.SelectedValue) Then
                Label8.Text = "Ingrese información"
                validarflag = 1
            Else
                Label8.Text = ""
            End If

            If String.IsNullOrEmpty(txtCarrizalitoHumedad.Text) Then
                Label9.Text = "Ingrese información"
                validarflag = 1
            Else
                Label9.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosCarrizalito.Text) Then
                Label10.Text = "Ingrese información"
                validarflag = 1
            Else
                Label10.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimCarrizalito.Text) Then
                Label11.Text = "Ingrese información"
                validarflag = 1
            Else
                Label11.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutCarrizalito.Text) Then
                Label12.Text = "Ingrese información"
                validarflag = 1
            Else
                Label12.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiDeorhoEsSi()
        ' Verifica si la selección en DDL_Deorho es "Si"
        If DDL_Deorho.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Deorho_Certificado.SelectedValue) Then
                Label15.Text = "Ingrese información"
                validarflag = 1
            Else
                Label15.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Deorho_Comercial.SelectedValue) Then
                Label16.Text = "Ingrese información"
                validarflag = 1
            Else
                Label16.Text = ""
            End If

            If String.IsNullOrEmpty(txtDeorhoHumedad.Text) Then
                Label17.Text = "Ingrese información"
                validarflag = 1
            Else
                Label17.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosDeorho.Text) Then
                Label19.Text = "Ingrese información"
                validarflag = 1
            Else
                Label19.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimDeorho.Text) Then
                Label20.Text = "Ingrese información"
                validarflag = 1
            Else
                Label20.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutDeorho.Text) Then
                Label21.Text = "Ingrese información"
                validarflag = 1
            Else
                Label21.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiAzabacheEsSi()
        ' Verifica si la selección en DDL_Azabache es "Si"
        If DDL_Azabache.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Azabache_Certificado.SelectedValue) Then
                Label24.Text = "Ingrese información"
                validarflag = 1
            Else
                Label24.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Azabache_Comercial.SelectedValue) Then
                Label25.Text = "Ingrese información"
                validarflag = 1
            Else
                Label25.Text = ""
            End If

            If String.IsNullOrEmpty(txtAzabacheHumedad.Text) Then
                Label26.Text = "Ingrese información"
                validarflag = 1
            Else
                Label26.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosAzabache.Text) Then
                Label27.Text = "Ingrese información"
                validarflag = 1
            Else
                Label27.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimAzabache.Text) Then
                Label28.Text = "Ingrese información"
                validarflag = 1
            Else
                Label28.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutAzabache.Text) Then
                Label29.Text = "Ingrese información"
                validarflag = 1
            Else
                Label29.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiParaisitoMejoradoPM2EsSi()
        ' Verifica si la selección en DDL_ParaisitoMejoradoPM2 es "Si"
        If DDL_ParaisitoMejoradoPM2.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_ParaisitoMejoradoPM2_Certificado.SelectedValue) Then
                Label31.Text = "Ingrese información"
                validarflag = 1
            Else
                Label31.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_ParaisitoMejoradoPM2_Comercial.SelectedValue) Then
                Label32.Text = "Ingrese información"
                validarflag = 1
            Else
                Label32.Text = ""
            End If

            If String.IsNullOrEmpty(txtParaisitoMejoradoPM2Humedad.Text) Then
                Label33.Text = "Ingrese información"
                validarflag = 1
            Else
                Label33.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosParaisitoMejoradoPM2.Text) Then
                Label34.Text = "Ingrese información"
                validarflag = 1
            Else
                Label34.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimParaisitoMejoradoPM2.Text) Then
                Label35.Text = "Ingrese información"
                validarflag = 1
            Else
                Label35.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutParaisitoMejoradoPM2.Text) Then
                Label36.Text = "Ingrese información"
                validarflag = 1
            Else
                Label36.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiHondurasNutritivoEsSi()
        ' Verifica si la selección en DDL_Hondurasnutritivo es "Si"
        If DDL_Hondurasnutritivo.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Hondurasnutritivo_Certificado.SelectedValue) Then
                Label38.Text = "Ingrese información"
                validarflag = 1
            Else
                Label38.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Hondurasnutritivo_Comercial.SelectedValue) Then
                Label39.Text = "Ingrese información"
                validarflag = 1
            Else
                Label39.Text = ""
            End If

            If String.IsNullOrEmpty(txtHondurasnutritivoHumedad.Text) Then
                Label40.Text = "Ingrese información"
                validarflag = 1
            Else
                Label40.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosHondurasnutritivo.Text) Then
                Label41.Text = "Ingrese información"
                validarflag = 1
            Else
                Label41.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimHondurasnutritivo.Text) Then
                Label42.Text = "Ingrese información"
                validarflag = 1
            Else
                Label42.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutHondurasnutritivo.Text) Then
                Label43.Text = "Ingrese información"
                validarflag = 1
            Else
                Label43.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiIntaCardenasEsSi()
        ' Verifica si la selección en DDL_IntaCardenas es "Si"
        If DDL_IntaCardenas.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_IntaCardenas_Certificado.SelectedValue) Then
                Label48.Text = "Ingrese información"
                validarflag = 1
            Else
                Label48.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_IntaCardenas_Comercial.SelectedValue) Then
                Label49.Text = "Ingrese información"
                validarflag = 1
            Else
                Label49.Text = ""
            End If

            If String.IsNullOrEmpty(txtIntaCardenasHumedad.Text) Then
                Label50.Text = "Ingrese información"
                validarflag = 1
            Else
                Label50.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosIntaCardenas.Text) Then
                Label51.Text = "Ingrese información"
                validarflag = 1
            Else
                Label51.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimIntaCardenas.Text) Then
                Label52.Text = "Ingrese información"
                validarflag = 1
            Else
                Label52.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutIntaCardenas.Text) Then
                Label53.Text = "Ingrese información"
                validarflag = 1
            Else
                Label53.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiLencaPrecozEsSi()
        ' Verifica si la selección en DDL_Lencaprecoz es "Si"
        If DDL_Lencaprecoz.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Lencaprecoz_Certificado.SelectedValue) Then
                Label55.Text = "Ingrese información"
                validarflag = 1
            Else
                Label55.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Lencaprecoz_Comercial.SelectedValue) Then
                Label56.Text = "Ingrese información"
                validarflag = 1
            Else
                Label56.Text = ""
            End If

            If String.IsNullOrEmpty(txtLencaprecozHumedad.Text) Then
                Label57.Text = "Ingrese información"
                validarflag = 1
            Else
                Label57.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosLencaprecoz.Text) Then
                Label58.Text = "Ingrese información"
                validarflag = 1
            Else
                Label58.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimLencaprecoz.Text) Then
                Label59.Text = "Ingrese información"
                validarflag = 1
            Else
                Label59.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutLencaprecoz.Text) Then
                Label60.Text = "Ingrese información"
                validarflag = 1
            Else
                Label60.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiRojoChortiEsSi()
        ' Verifica si la selección en DDL_Rojochorti es "Si"
        If DDL_Rojochorti.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Rojochorti_Certificado.SelectedValue) Then
                Label62.Text = "Ingrese información"
                validarflag = 1
            Else
                Label62.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Rojochorti_Comercial.SelectedValue) Then
                Label63.Text = "Ingrese información"
                validarflag = 1
            Else
                Label63.Text = ""
            End If

            If String.IsNullOrEmpty(txtRojochortiHumedad.Text) Then
                Label64.Text = "Ingrese información"
                validarflag = 1
            Else
                Label64.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosRojochorti.Text) Then
                Label65.Text = "Ingrese información"
                validarflag = 1
            Else
                Label65.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimRojochorti.Text) Then
                Label66.Text = "Ingrese información"
                validarflag = 1
            Else
                Label66.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutRojochorti.Text) Then
                Label67.Text = "Ingrese información"
                validarflag = 1
            Else
                Label67.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiTolupanRojoEsSi()
        ' Verifica si la selección en DDL_Tolupanrojo es "Si"
        If DDL_Tolupanrojo.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Tolupanrojo_Certificado.SelectedValue) Then
                Label69.Text = "Ingrese información"
                validarflag = 1
            Else
                Label69.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Tolupanrojo_Comercial.SelectedValue) Then
                Label70.Text = "Ingrese información"
                validarflag = 1
            Else
                Label70.Text = ""
            End If

            If String.IsNullOrEmpty(txtTolupanrojoHumedad.Text) Then
                Label71.Text = "Ingrese información"
                validarflag = 1
            Else
                Label71.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosTolupanrojo.Text) Then
                Label72.Text = "Ingrese información"
                validarflag = 1
            Else
                Label72.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimTolupanrojo.Text) Then
                Label73.Text = "Ingrese información"
                validarflag = 1
            Else
                Label73.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutTolupanrojo.Text) Then
                Label74.Text = "Ingrese información"
                validarflag = 1
            Else
                Label74.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiOtraVariedadEsSi()
        ' Verifica si la selección en DDL_Otravariedad es "Si"
        If DDL_Otravariedad.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_Otravariedad_Certificado.SelectedValue) Then
                Label76.Text = "Ingrese información"
                validarflag = 1
            Else
                Label76.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_Otravariedad_Comercial.SelectedValue) Then
                Label77.Text = "Ingrese información"
                validarflag = 1
            Else
                Label77.Text = ""
            End If

            If String.IsNullOrEmpty(txtOtravariedadHumedad.Text) Then
                Label78.Text = "Ingrese información"
                validarflag = 1
            Else
                Label78.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosOtravariedad.Text) Then
                Label79.Text = "Ingrese información"
                validarflag = 1
            Else
                Label79.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimOtravariedad.Text) Then
                Label80.Text = "Ingrese información"
                validarflag = 1
            Else
                Label80.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutOtravariedad.Text) Then
                Label81.Text = "Ingrese información"
                validarflag = 1
            Else
                Label81.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiDictaMayaEsSi()
        ' Verifica si la selección en DDL_DictaMaya es "Si"
        If DDL_DictaMaya.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_DictaMaya_Certificado.SelectedValue) Then
                Label83.Text = "Ingrese información"
                validarflag = 1
            Else
                Label83.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_DictaMaya_Comercial.SelectedValue) Then
                Label84.Text = "Ingrese información"
                validarflag = 1
            Else
                Label84.Text = ""
            End If

            If String.IsNullOrEmpty(txtDictaMayaHumedad.Text) Then
                Label85.Text = "Ingrese información"
                validarflag = 1
            Else
                Label85.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosDictaMaya.Text) Then
                Label86.Text = "Ingrese información"
                validarflag = 1
            Else
                Label86.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimDictaMaya.Text) Then
                Label87.Text = "Ingrese información"
                validarflag = 1
            Else
                Label87.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutDictaMaya.Text) Then
                Label88.Text = "Ingrese información"
                validarflag = 1
            Else
                Label88.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiDictaVictoriaEsSi()
        ' Verifica si la selección en DDL_DictaVictoria es "Si"
        If DDL_DictaVictoria.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_DictaVictoria_Certificado.SelectedValue) Then
                Label90.Text = "Ingrese información"
                validarflag = 1
            Else
                Label90.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_DictaVictoria_Comercial.SelectedValue) Then
                Label91.Text = "Ingrese información"
                validarflag = 1
            Else
                Label91.Text = ""
            End If

            If String.IsNullOrEmpty(txtDictaVictoriaHumedad.Text) Then
                Label92.Text = "Ingrese información"
                validarflag = 1
            Else
                Label92.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosDictaVictoria.Text) Then
                Label93.Text = "Ingrese información"
                validarflag = 1
            Else
                Label93.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimDictaVictoria.Text) Then
                Label94.Text = "Ingrese información"
                validarflag = 1
            Else
                Label94.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutDictaVictoria.Text) Then
                Label95.Text = "Ingrese información"
                validarflag = 1
            Else
                Label95.Text = ""
            End If
        End If
    End Sub
    Protected Sub VerificarSiOtraVariedadMEsSi()
        ' Verifica si la selección en DDL_OtravariedadM es "Si"
        If DDL_OtravariedadM.SelectedValue = "Si" Then
            ' Verifica que los controles no estén vacíos
            If String.IsNullOrEmpty(DDL_OtravariedadM_Certificado.SelectedValue) Then
                Label97.Text = "Ingrese información"
                validarflag = 1
            Else
                Label97.Text = ""
            End If

            If String.IsNullOrEmpty(DDL_OtravariedadM_Comercial.SelectedValue) Then
                Label98.Text = "Ingrese información"
                validarflag = 1
            Else
                Label98.Text = ""
            End If

            If String.IsNullOrEmpty(txtOtravariedadMHumedad.Text) Then
                Label99.Text = "Ingrese información"
                validarflag = 1
            Else
                Label99.Text = ""
            End If

            If String.IsNullOrEmpty(txtBultosOtravariedadM.Text) Then
                Label100.Text = "Ingrese información"
                validarflag = 1
            Else
                Label100.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoPrimOtravariedadM.Text) Then
                Label101.Text = "Ingrese información"
                validarflag = 1
            Else
                Label101.Text = ""
            End If

            If String.IsNullOrEmpty(txtPesoBrutOtravariedadM.Text) Then
                Label102.Text = "Ingrese información"
                validarflag = 1
            Else
                Label102.Text = ""
            End If
        End If
    End Sub

    Protected Sub Verificar()
        VerificarSiAmadeusEsSi()
        VerificarSiCarrizalitoEsSi()
        VerificarSiDeorhoEsSi()
        VerificarSiAzabacheEsSi()
        VerificarSiParaisitoMejoradoPM2EsSi()
        VerificarSiHondurasNutritivoEsSi()
        VerificarSiIntaCardenasEsSi()
        VerificarSiLencaPrecozEsSi()
        VerificarSiRojoChortiEsSi()
        VerificarSiTolupanRojoEsSi()
        VerificarSiOtraVariedadEsSi()
        VerificarSiDictaMayaEsSi()
        VerificarSiDictaVictoriaEsSi()
        VerificarSiOtraVariedadMEsSi()
    End Sub

    Protected Sub GuardarActa()
        'Aqui se guardara la informacion en la base de datos
        Dim cadena As String = ""

        If btnGuardarActa.Text = "Guardar" Then
            cadena = "INSERT "
        Else
            cadena = "UPDATE "
        End If



    End Sub
End Class

