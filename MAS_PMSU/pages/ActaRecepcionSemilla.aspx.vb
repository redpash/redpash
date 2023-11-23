Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports ClosedXML.Excel
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
        Dim StrCombo As String = "SELECT PROD_NOMBRE FROM registros_bancos_semilla  ORDER BY PROD_NOMBRE ASC"
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

        Dim cadena As String = "ID, txt_nombre_prod_new, DDL_cultivo, TxtCeduIden, DATE_FORMAT(txtFechaSiembra, '%d-%m-%Y') AS txtFechaSiembra"
        Dim c1 As String = ""
        Dim c2 As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND txt_nombre_prod_new = '" & TxtProductor.SelectedItem.Text & "' "
        End If

        If (DDL_SelCult.SelectedItem.Text = " ") Then
            c2 = " "
        Else
            c2 = "AND DDL_cultivo = '" & DDL_SelCult.SelectedItem.Text & "' "
        End If

        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM acta_recepcion_semilla where Estado = '1' " & c1 & c2 & "ORDER BY txt_nombre_prod_new,DDL_cultivo"

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
    Protected Function SeleccionarItemEnDropDownList(ByVal Prodname As DropDownList, ByVal DtCombo As String)
        If DtCombo = "Frijol" Or DtCombo = "Maiz" Then
            For Each item As ListItem In Prodname.Items
                If item.Text = DtCombo Then
                    Prodname.SelectedValue = item.Value
                    DDL_cultivo_SelectedIndexChanged()
                    Return True ' Se encontró una coincidencia, devolver verdadero
                End If
            Next
        Else
            For Each item As ListItem In Prodname.Items
                If item.Text = DtCombo Then
                    Prodname.SelectedValue = item.Value
                    Verificarvariedades()
                    Return True ' Se encontró una coincidencia, devolver verdadero
                End If
            Next
        End If
        ' No se encontró ninguna coincidencia
        Return 0
    End Function
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then
            btnGuardarActa.Text = "Editar"

            If String.IsNullOrEmpty(TxtProductor.SelectedValue) Then
                txt_nombre_prod_new.Text = ""
            Else
                txt_nombre_prod_new.Text = TxtProductor.SelectedValue
            End If

            DivActa.Style.Add("display", "block")
            DivGrid.Style.Add("display", "none")
            btnGuardarActa.Visible = True

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `acta_recepcion_semilla` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString

            If dt.Rows.Count > 0 Then
                'TxtAreaSembMz.Text = dt.Rows(0)("AREA_TERRENO_SEMBRADA_MZ").ToString
                txtFechaSiembra.Text = DirectCast(dt.Rows(0)("txtFechaSiembra"), Date).ToString("yyyy-MM-dd")
                txt_nombre_prod_new.Text = dt.Rows(0)("txt_nombre_prod_new").ToString
                TxtCeduIden.Text = dt.Rows(0)("TxtCeduIden").ToString

                SeleccionarItemEnDropDownList(DDL_cultivo, dt.Rows(0)("DDL_cultivo").ToString)

                SeleccionarItemEnDropDownList(DDL_Amadeus, dt.Rows(0)("DDL_Amadeus").ToString)
                SeleccionarItemEnDropDownList(DDL_Amadeus_Certificado, dt.Rows(0)("DDL_Amadeus_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Amadeus_Comercial, dt.Rows(0)("DDL_Amadeus_Comercial").ToString)
                txtAmadeusHumedad.Text = dt.Rows(0)("txtAmadeusHumedad").ToString
                txtBultosAmadeus.Text = dt.Rows(0)("txtBultosAmadeus").ToString
                txtPesoPrimAmadeus.Text = dt.Rows(0)("txtPesoPrimAmadeus").ToString
                txtPesoBrutAmadeus.Text = dt.Rows(0)("txtPesoBrutAmadeus").ToString

                SeleccionarItemEnDropDownList(DDL_Carrizalito, dt.Rows(0)("DDL_Carrizalito").ToString)
                SeleccionarItemEnDropDownList(DDL_Carrizalito_Certificado, dt.Rows(0)("DDL_Carrizalito_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Carrizalito_Comercial, dt.Rows(0)("DDL_Carrizalito_Comercial").ToString)
                txtCarrizalitoHumedad.Text = dt.Rows(0)("txtCarrizalitoHumedad").ToString
                txtBultosCarrizalito.Text = dt.Rows(0)("txtBultosCarrizalito").ToString
                txtPesoPrimCarrizalito.Text = dt.Rows(0)("txtPesoPrimCarrizalito").ToString
                txtPesoBrutCarrizalito.Text = dt.Rows(0)("txtPesoBrutCarrizalito").ToString

                SeleccionarItemEnDropDownList(DDL_Deorho, dt.Rows(0)("DDL_Deorho").ToString)
                SeleccionarItemEnDropDownList(DDL_Deorho_Certificado, dt.Rows(0)("DDL_Deorho_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Deorho_Comercial, dt.Rows(0)("DDL_Deorho_Comercial").ToString)
                txtDeorhoHumedad.Text = dt.Rows(0)("txtDeorhoHumedad").ToString
                txtBultosDeorho.Text = dt.Rows(0)("txtBultosDeorho").ToString
                txtPesoPrimDeorho.Text = dt.Rows(0)("txtPesoPrimDeorho").ToString
                txtPesoBrutDeorho.Text = dt.Rows(0)("txtPesoBrutDeorho").ToString

                SeleccionarItemEnDropDownList(DDL_Azabache, dt.Rows(0)("DDL_Azabache").ToString)
                SeleccionarItemEnDropDownList(DDL_Azabache_Certificado, dt.Rows(0)("DDL_Azabache_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Azabache_Comercial, dt.Rows(0)("DDL_Azabache_Comercial").ToString)
                txtAzabacheHumedad.Text = dt.Rows(0)("txtAzabacheHumedad").ToString
                txtBultosAzabache.Text = dt.Rows(0)("txtBultosAzabache").ToString
                txtPesoPrimAzabache.Text = dt.Rows(0)("txtPesoPrimAzabache").ToString
                txtPesoBrutAzabache.Text = dt.Rows(0)("txtPesoBrutAzabache").ToString

                SeleccionarItemEnDropDownList(DDL_ParaisitoMejoradoPM2, dt.Rows(0)("DDL_ParaisitoMejoradoPM2").ToString)
                SeleccionarItemEnDropDownList(DDL_ParaisitoMejoradoPM2_Certificado, dt.Rows(0)("DDL_ParaisitoMejoradoPM2_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_ParaisitoMejoradoPM2_Comercial, dt.Rows(0)("DDL_ParaisitoMejoradoPM2_Comercial").ToString)
                txtParaisitoMejoradoPM2Humedad.Text = dt.Rows(0)("txtParaisitoMejoradoPM2Humedad").ToString
                txtBultosParaisitoMejoradoPM2.Text = dt.Rows(0)("txtBultosParaisitoMejoradoPM2").ToString
                txtPesoPrimParaisitoMejoradoPM2.Text = dt.Rows(0)("txtPesoPrimParaisitoMejoradoPM2").ToString
                txtPesoBrutParaisitoMejoradoPM2.Text = dt.Rows(0)("txtPesoBrutParaisitoMejoradoPM2").ToString

                SeleccionarItemEnDropDownList(DDL_Hondurasnutritivo, dt.Rows(0)("DDL_Hondurasnutritivo").ToString)
                SeleccionarItemEnDropDownList(DDL_Hondurasnutritivo_Certificado, dt.Rows(0)("DDL_Hondurasnutritivo_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Hondurasnutritivo_Comercial, dt.Rows(0)("DDL_Hondurasnutritivo_Comercial").ToString)
                txtHondurasnutritivoHumedad.Text = dt.Rows(0)("txtHondurasnutritivoHumedad").ToString
                txtBultosHondurasnutritivo.Text = dt.Rows(0)("txtBultosHondurasnutritivo").ToString
                txtPesoPrimHondurasnutritivo.Text = dt.Rows(0)("txtPesoPrimHondurasnutritivo").ToString
                txtPesoBrutHondurasnutritivo.Text = dt.Rows(0)("txtPesoBrutHondurasnutritivo").ToString

                SeleccionarItemEnDropDownList(DDL_IntaCardenas, dt.Rows(0)("DDL_IntaCardenas").ToString)
                SeleccionarItemEnDropDownList(DDL_IntaCardenas_Certificado, dt.Rows(0)("DDL_IntaCardenas_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_IntaCardenas_Comercial, dt.Rows(0)("DDL_IntaCardenas_Comercial").ToString)
                txtIntaCardenasHumedad.Text = dt.Rows(0)("txtIntaCardenasHumedad").ToString
                txtBultosIntaCardenas.Text = dt.Rows(0)("txtBultosIntaCardenas").ToString
                txtPesoPrimIntaCardenas.Text = dt.Rows(0)("txtPesoPrimIntaCardenas").ToString
                txtPesoBrutIntaCardenas.Text = dt.Rows(0)("txtPesoBrutIntaCardenas").ToString

                SeleccionarItemEnDropDownList(DDL_Lencaprecoz, dt.Rows(0)("DDL_Lencaprecoz").ToString)
                SeleccionarItemEnDropDownList(DDL_Lencaprecoz_Certificado, dt.Rows(0)("DDL_Lencaprecoz_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Lencaprecoz_Comercial, dt.Rows(0)("DDL_Lencaprecoz_Comercial").ToString)
                txtLencaprecozHumedad.Text = dt.Rows(0)("txtLencaprecozHumedad").ToString
                txtBultosLencaprecoz.Text = dt.Rows(0)("txtBultosLencaprecoz").ToString
                txtPesoPrimLencaprecoz.Text = dt.Rows(0)("txtPesoPrimLencaprecoz").ToString
                txtPesoBrutLencaprecoz.Text = dt.Rows(0)("txtPesoBrutLencaprecoz").ToString

                SeleccionarItemEnDropDownList(DDL_Rojochorti, dt.Rows(0)("DDL_Rojochorti").ToString)
                SeleccionarItemEnDropDownList(DDL_Rojochorti_Certificado, dt.Rows(0)("DDL_Rojochorti_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Rojochorti_Comercial, dt.Rows(0)("DDL_Rojochorti_Comercial").ToString)
                txtRojochortiHumedad.Text = dt.Rows(0)("txtRojochortiHumedad").ToString
                txtBultosRojochorti.Text = dt.Rows(0)("txtBultosRojochorti").ToString
                txtPesoPrimRojochorti.Text = dt.Rows(0)("txtPesoPrimRojochorti").ToString
                txtPesoBrutRojochorti.Text = dt.Rows(0)("txtPesoBrutRojochorti").ToString

                SeleccionarItemEnDropDownList(DDL_Tolupanrojo, dt.Rows(0)("DDL_Tolupanrojo").ToString)
                SeleccionarItemEnDropDownList(DDL_Tolupanrojo_Certificado, dt.Rows(0)("DDL_Tolupanrojo_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_Tolupanrojo_Comercial, dt.Rows(0)("DDL_Tolupanrojo_Comercial").ToString)
                txtTolupanrojoHumedad.Text = dt.Rows(0)("txtTolupanrojoHumedad").ToString
                txtBultosTolupanrojo.Text = dt.Rows(0)("txtBultosTolupanrojo").ToString
                txtPesoPrimTolupanrojo.Text = dt.Rows(0)("txtPesoPrimTolupanrojo").ToString
                txtPesoBrutTolupanrojo.Text = dt.Rows(0)("txtPesoBrutTolupanrojo").ToString

                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                If Not String.IsNullOrWhiteSpace(dt.Rows(0)("txtOtravariedad").ToString) Then
                    Dim si As String = "Si"
                    For Each item As ListItem In DDL_Otravariedad.Items
                        If item.Text = si Then
                            DDL_Otravariedad.SelectedValue = item.Value
                            Verificarvariedades()
                        End If
                    Next
                Else
                    Dim no As String = "No"
                    For Each item As ListItem In DDL_Otravariedad.Items
                        If item.Text = no Then
                            DDL_Otravariedad.SelectedValue = item.Value
                            Verificarvariedades()
                        End If
                    Next
                End If
                txtOtravariedad.Text = dt.Rows(0)("txtOtravariedad").ToString
                DDL_Otravariedad_Certificado.SelectedItem.Text = dt.Rows(0)("DDL_Otravariedad_Certificado").ToString
                DDL_Otravariedad_Comercial.Text = dt.Rows(0)("DDL_Otravariedad_Comercial").ToString
                txtOtravariedadHumedad.Text = dt.Rows(0)("txtOtravariedadHumedad").ToString
                txtBultosOtravariedad.Text = dt.Rows(0)("txtBultosOtravariedad").ToString
                txtPesoPrimOtravariedad.Text = dt.Rows(0)("txtPesoPrimOtravariedad").ToString
                txtPesoBrutOtravariedad.Text = dt.Rows(0)("txtPesoBrutOtravariedad").ToString
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                SeleccionarItemEnDropDownList(DDL_DictaMaya, dt.Rows(0)("DDL_DictaMaya").ToString)
                SeleccionarItemEnDropDownList(DDL_DictaMaya_Certificado, dt.Rows(0)("DDL_DictaMaya_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_DictaMaya_Comercial, dt.Rows(0)("DDL_DictaMaya_Comercial").ToString)
                txtDictaMayaHumedad.Text = dt.Rows(0)("txtDictaMayaHumedad").ToString
                txtBultosDictaMaya.Text = dt.Rows(0)("txtBultosDictaMaya").ToString
                txtPesoPrimDictaMaya.Text = dt.Rows(0)("txtPesoPrimDictaMaya").ToString
                txtPesoBrutDictaMaya.Text = dt.Rows(0)("txtPesoBrutDictaMaya").ToString

                SeleccionarItemEnDropDownList(DDL_DictaVictoria, dt.Rows(0)("DDL_DictaVictoria").ToString)
                SeleccionarItemEnDropDownList(DDL_DictaVictoria_Certificado, dt.Rows(0)("DDL_DictaVictoria_Certificado").ToString)
                SeleccionarItemEnDropDownList(DDL_DictaVictoria_Comercial, dt.Rows(0)("DDL_DictaVictoria_Comercial").ToString)
                txtDictaVictoriaHumedad.Text = dt.Rows(0)("txtDictaVictoriaHumedad").ToString
                txtBultosDictaVictoria.Text = dt.Rows(0)("txtBultosDictaVictoria").ToString
                txtPesoPrimDictaVictoria.Text = dt.Rows(0)("txtPesoPrimDictaVictoria").ToString
                txtPesoBrutDictaVictoria.Text = dt.Rows(0)("txtPesoBrutDictaVictoria").ToString

                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                If Not String.IsNullOrWhiteSpace(dt.Rows(0)("txtOtravariedadM").ToString) Then
                    Dim si As String = "Si"
                    For Each item As ListItem In DDL_OtravariedadM.Items
                        If item.Text = si Then
                            DDL_OtravariedadM.SelectedValue = item.Value
                            Verificarvariedades()
                        End If
                    Next
                Else
                    Dim si As String = "No"
                    For Each item As ListItem In DDL_OtravariedadM.Items
                        If item.Text = si Then
                            DDL_OtravariedadM.SelectedValue = item.Value
                            Verificarvariedades()
                        End If
                    Next
                End If
                txtOtravariedadM.Text = dt.Rows(0)("txtOtravariedadM").ToString
                DDL_OtravariedadM_Certificado.SelectedItem.Text = dt.Rows(0)("DDL_OtravariedadM_Certificado").ToString
                DDL_OtravariedadM_Comercial.Text = dt.Rows(0)("DDL_OtravariedadM_Comercial").ToString
                txtOtravariedadMHumedad.Text = dt.Rows(0)("txtOtravariedadMHumedad").ToString
                txtBultosOtravariedadM.Text = dt.Rows(0)("txtBultosOtravariedadM").ToString
                txtPesoPrimOtravariedadM.Text = dt.Rows(0)("txtPesoPrimOtravariedadM").ToString
                txtPesoBrutOtravariedadM.Text = dt.Rows(0)("txtPesoBrutOtravariedadM").ToString
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                '-----------------------------------------------------------------------
                Verificar()
                Label103.Text = "El Acta de Recepcion de semilla ha sido editada con exito"
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
                    ' Se crea un objeto ListItem para representar la  gina...
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
                ' Calcula el nº de  gina actual...
                Dim currentPage As Integer = GridDatos.PageIndex + 1
                ' Actualiza el Label control con la  gina actual.
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
        txt_nombre_prod_new.Text = DropDownList7.SelectedValue
        TxtProductor.SelectedValue = DropDownList7.SelectedValue
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

        DDL_SelCult.SelectedValue = DDL_cultivo.SelectedValue
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
                BtnImprimir.Visible = False
                BtnNuevo.Visible = True

                'Funcion para guardar en la BD
                GuardarActa()

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
        Dim conex As New MySqlConnection(conn)
        Dim fecha As Date

        If Date.TryParse(txtFechaSiembra.Text, fecha) Then
            fecha.ToString("dd-MM-yyyy")
        End If

        conex.Open()

        Dim cmd2 As New MySqlCommand()

        If btnGuardarActa.Text = "Guardar" Then
            Dim Sql As String
            Sql = "INSERT INTO acta_recepcion_semilla (txtFechaSiembra, txt_nombre_prod_new, TxtCeduIden, DDL_cultivo, 
               DDL_Amadeus, DDL_Amadeus_Certificado, DDL_Amadeus_Comercial, txtAmadeusHumedad, txtBultosAmadeus, txtPesoPrimAmadeus, txtPesoBrutAmadeus, 
               DDL_Carrizalito, DDL_Carrizalito_Certificado, DDL_Carrizalito_Comercial, txtCarrizalitoHumedad, txtBultosCarrizalito, txtPesoPrimCarrizalito, txtPesoBrutCarrizalito, 
               DDL_Deorho, DDL_Deorho_Certificado, DDL_Deorho_Comercial, txtDeorhoHumedad, txtBultosDeorho, txtPesoPrimDeorho, txtPesoBrutDeorho, 
               DDL_Azabache, DDL_Azabache_Certificado, DDL_Azabache_Comercial, txtAzabacheHumedad, txtBultosAzabache, txtPesoPrimAzabache, txtPesoBrutAzabache, 
               DDL_ParaisitoMejoradoPM2, DDL_ParaisitoMejoradoPM2_Certificado, DDL_ParaisitoMejoradoPM2_Comercial, txtParaisitoMejoradoPM2Humedad, txtBultosParaisitoMejoradoPM2, txtPesoPrimParaisitoMejoradoPM2, txtPesoBrutParaisitoMejoradoPM2, 
               DDL_Hondurasnutritivo, DDL_Hondurasnutritivo_Certificado, DDL_Hondurasnutritivo_Comercial, txtHondurasnutritivoHumedad, txtBultosHondurasnutritivo, txtPesoPrimHondurasnutritivo, txtPesoBrutHondurasnutritivo, 
               DDL_IntaCardenas, DDL_IntaCardenas_Certificado, DDL_IntaCardenas_Comercial, txtIntaCardenasHumedad, txtBultosIntaCardenas, txtPesoPrimIntaCardenas, txtPesoBrutIntaCardenas, 
               DDL_Lencaprecoz, DDL_Lencaprecoz_Certificado, DDL_Lencaprecoz_Comercial, txtLencaprecozHumedad, txtBultosLencaprecoz, txtPesoPrimLencaprecoz, txtPesoBrutLencaprecoz, 
               DDL_Rojochorti, DDL_Rojochorti_Certificado, DDL_Rojochorti_Comercial, txtRojochortiHumedad, txtBultosRojochorti, txtPesoPrimRojochorti, txtPesoBrutRojochorti, 
               DDL_Tolupanrojo, DDL_Tolupanrojo_Certificado, DDL_Tolupanrojo_Comercial, txtTolupanrojoHumedad, txtBultosTolupanrojo, txtPesoPrimTolupanrojo, txtPesoBrutTolupanrojo, 
               txtOtravariedad, DDL_Otravariedad_Certificado, DDL_Otravariedad_Comercial, txtOtravariedadHumedad, txtBultosOtravariedad, txtPesoPrimOtravariedad, txtPesoBrutOtravariedad, 
               DDL_DictaMaya, DDL_DictaMaya_Certificado, DDL_DictaMaya_Comercial, txtDictaMayaHumedad, txtBultosDictaMaya, txtPesoPrimDictaMaya, txtPesoBrutDictaMaya, 
               DDL_DictaVictoria, DDL_DictaVictoria_Certificado, DDL_DictaVictoria_Comercial, txtDictaVictoriaHumedad, txtBultosDictaVictoria, txtPesoPrimDictaVictoria, txtPesoBrutDictaVictoria, 
               txtOtravariedadM, DDL_OtravariedadM_Certificado, DDL_OtravariedadM_Comercial, txtOtravariedadMHumedad, txtBultosOtravariedadM, txtPesoPrimOtravariedadM, txtPesoBrutOtravariedadM, estado) VALUES (@txtFechaSiembra, @txt_nombre_prod_new, @TxtCeduIden, @DDL_cultivo, 
               @DDL_Amadeus, @DDL_Amadeus_Certificado, @DDL_Amadeus_Comercial, @txtAmadeusHumedad, @txtBultosAmadeus, @txtPesoPrimAmadeus, @txtPesoBrutAmadeus, 
               @DDL_Carrizalito, @DDL_Carrizalito_Certificado, @DDL_Carrizalito_Comercial, @txtCarrizalitoHumedad, @txtBultosCarrizalito, @txtPesoPrimCarrizalito, @txtPesoBrutCarrizalito, 
               @DDL_Deorho, @DDL_Deorho_Certificado, @DDL_Deorho_Comercial, @txtDeorhoHumedad, @txtBultosDeorho, @txtPesoPrimDeorho, @txtPesoBrutDeorho, 
               @DDL_Azabache, @DDL_Azabache_Certificado, @DDL_Azabache_Comercial, @txtAzabacheHumedad, @txtBultosAzabache, @txtPesoPrimAzabache, @txtPesoBrutAzabache, 
               @DDL_ParaisitoMejoradoPM2, @DDL_ParaisitoMejoradoPM2_Certificado, @DDL_ParaisitoMejoradoPM2_Comercial, @txtParaisitoMejoradoPM2Humedad, @txtBultosParaisitoMejoradoPM2, @txtPesoPrimParaisitoMejoradoPM2, @txtPesoBrutParaisitoMejoradoPM2, 
               @DDL_Hondurasnutritivo, @DDL_Hondurasnutritivo_Certificado, @DDL_Hondurasnutritivo_Comercial, @txtHondurasnutritivoHumedad, @txtBultosHondurasnutritivo, @txtPesoPrimHondurasnutritivo, @txtPesoBrutHondurasnutritivo, 
               @DDL_IntaCardenas, @DDL_IntaCardenas_Certificado, @DDL_IntaCardenas_Comercial, @txtIntaCardenasHumedad, @txtBultosIntaCardenas, @txtPesoPrimIntaCardenas, @txtPesoBrutIntaCardenas, 
               @DDL_Lencaprecoz, @DDL_Lencaprecoz_Certificado, @DDL_Lencaprecoz_Comercial, @txtLencaprecozHumedad, @txtBultosLencaprecoz, @txtPesoPrimLencaprecoz, @txtPesoBrutLencaprecoz, 
               @DDL_Rojochorti, @DDL_Rojochorti_Certificado, @DDL_Rojochorti_Comercial, @txtRojochortiHumedad, @txtBultosRojochorti, @txtPesoPrimRojochorti, @txtPesoBrutRojochorti, 
               @DDL_Tolupanrojo, @DDL_Tolupanrojo_Certificado, @DDL_Tolupanrojo_Comercial, @txtTolupanrojoHumedad, @txtBultosTolupanrojo, @txtPesoPrimTolupanrojo, @txtPesoBrutTolupanrojo, 
               @txtOtravariedad, @DDL_Otravariedad_Certificado, @DDL_Otravariedad_Comercial, @txtOtravariedadHumedad, @txtBultosOtravariedad, @txtPesoPrimOtravariedad, @txtPesoBrutOtravariedad, 
               @DDL_DictaMaya, @DDL_DictaMaya_Certificado, @DDL_DictaMaya_Comercial, @txtDictaMayaHumedad, @txtBultosDictaMaya, @txtPesoPrimDictaMaya, @txtPesoBrutDictaMaya, 
               @DDL_DictaVictoria, @DDL_DictaVictoria_Certificado, @DDL_DictaVictoria_Comercial, @txtDictaVictoriaHumedad, @txtBultosDictaVictoria, @txtPesoPrimDictaVictoria, @txtPesoBrutDictaVictoria, 
               @txtOtravariedadM, @DDL_OtravariedadM_Certificado, @DDL_OtravariedadM_Comercial, @txtOtravariedadMHumedad, @txtBultosOtravariedadM, @txtPesoPrimOtravariedadM, @txtPesoBrutOtravariedadM, @estado)"

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@txtFechaSiembra", fecha)
            cmd2.Parameters.AddWithValue("@txt_nombre_prod_new", txt_nombre_prod_new.Text)
            cmd2.Parameters.AddWithValue("@TxtCeduIden", TxtCeduIden.Text)
            cmd2.Parameters.AddWithValue("@DDL_cultivo", DDL_cultivo.Text)
            cmd2.Parameters.AddWithValue("@estado", "1")
            If DDL_SelCult.SelectedItem.Text = "Frijol" Then

                If DDL_Amadeus.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DDL_Amadeus_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DDL_Amadeus_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", Convert.ToDouble(txtAmadeusHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosAmadeus", Convert.ToInt64(txtBultosAmadeus.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", Convert.ToDouble(txtPesoPrimAmadeus.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", Convert.ToDouble(txtPesoBrutAmadeus.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosAmadeus", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", DBNull.Value)
                End If

                If DDL_Carrizalito.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DDL_Carrizalito_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DDL_Carrizalito_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", Convert.ToDouble(txtCarrizalitoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", Convert.ToInt64(txtBultosCarrizalito.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", Convert.ToDouble(txtPesoPrimCarrizalito.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", Convert.ToDouble(txtPesoBrutCarrizalito.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", DBNull.Value)
                End If

                If DDL_Deorho.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DDL_Deorho_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DDL_Deorho_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", Convert.ToDouble(txtDeorhoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDeorho", Convert.ToInt64(txtBultosDeorho.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", Convert.ToDouble(txtPesoPrimDeorho.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", Convert.ToDouble(txtPesoBrutDeorho.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDeorho", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", DBNull.Value)
                End If

                If DDL_Azabache.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DDL_Azabache_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DDL_Azabache_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", Convert.ToDouble(txtAzabacheHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosAzabache", Convert.ToInt64(txtBultosAzabache.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", Convert.ToDouble(txtPesoPrimAzabache.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", Convert.ToDouble(txtPesoBrutAzabache.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosAzabache", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", DBNull.Value)
                End If

                If DDL_ParaisitoMejoradoPM2.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DDL_ParaisitoMejoradoPM2_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DDL_ParaisitoMejoradoPM2_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", Convert.ToDouble(txtParaisitoMejoradoPM2Humedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", Convert.ToInt64(txtBultosParaisitoMejoradoPM2.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", Convert.ToDouble(txtPesoPrimParaisitoMejoradoPM2.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", Convert.ToDouble(txtPesoBrutParaisitoMejoradoPM2.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", DBNull.Value)
                End If

                If DDL_Hondurasnutritivo.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DDL_Hondurasnutritivo_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DDL_Hondurasnutritivo_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", Convert.ToDouble(txtHondurasnutritivoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", Convert.ToInt64(txtBultosHondurasnutritivo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", Convert.ToDouble(txtPesoPrimHondurasnutritivo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", Convert.ToDouble(txtPesoBrutHondurasnutritivo.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", DBNull.Value)
                End If

                If DDL_IntaCardenas.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DDL_IntaCardenas_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DDL_IntaCardenas_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", Convert.ToDouble(txtIntaCardenasHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", Convert.ToInt64(txtBultosIntaCardenas.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", Convert.ToDouble(txtPesoPrimIntaCardenas.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", Convert.ToDouble(txtPesoBrutIntaCardenas.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", DBNull.Value)
                End If

                If DDL_Lencaprecoz.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DDL_Lencaprecoz_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DDL_Lencaprecoz_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", Convert.ToDouble(txtLencaprecozHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", Convert.ToInt64(txtBultosLencaprecoz.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", Convert.ToDouble(txtPesoPrimLencaprecoz.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", Convert.ToDouble(txtPesoBrutLencaprecoz.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", DBNull.Value)
                End If

                If DDL_Rojochorti.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DDL_Rojochorti_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DDL_Rojochorti_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", Convert.ToDouble(txtRojochortiHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosRojochorti", Convert.ToInt64(txtBultosRojochorti.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", Convert.ToDouble(txtPesoPrimRojochorti.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", Convert.ToDouble(txtPesoBrutRojochorti.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosRojochorti", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", DBNull.Value)
                End If

                If DDL_Tolupanrojo.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DDL_Tolupanrojo_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DDL_Tolupanrojo_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", Convert.ToDouble(txtTolupanrojoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", Convert.ToInt64(txtBultosTolupanrojo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", Convert.ToDouble(txtPesoPrimTolupanrojo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", Convert.ToDouble(txtPesoBrutTolupanrojo.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", DBNull.Value)
                End If

                If DDL_Otravariedad.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@txtOtravariedad", txtOtravariedad.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DDL_Otravariedad_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DDL_Otravariedad_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", Convert.ToDouble(txtOtravariedadHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", Convert.ToInt64(txtBultosOtravariedad.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", Convert.ToDouble(txtPesoPrimOtravariedad.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", Convert.ToDouble(txtPesoBrutOtravariedad.Text))
                Else
                    cmd2.Parameters.AddWithValue("@txtOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", DBNull.Value)
                End If
                cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", DBNull.Value)

                cmd2.ExecuteNonQuery()
                conex.Close()

                'Response.Redirect(String.Format("~/pages/ActaRecepcionSemilla.aspx"))

                llenagrid()
            End If

            If DDL_SelCult.SelectedItem.Text = "Maiz" Then
                If DDL_DictaMaya.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DDL_DictaMaya_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DDL_DictaMaya_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", Convert.ToDouble(txtDictaMayaHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", Convert.ToInt64(txtBultosDictaMaya.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", Convert.ToDouble(txtPesoPrimDictaMaya.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", Convert.ToDouble(txtPesoBrutDictaMaya.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", DBNull.Value)
                End If

                If DDL_DictaVictoria.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DDL_DictaVictoria_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DDL_DictaVictoria_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", Convert.ToDouble(txtDictaVictoriaHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", Convert.ToInt64(txtBultosDictaVictoria.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", Convert.ToDouble(txtPesoPrimDictaVictoria.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", Convert.ToDouble(txtPesoBrutDictaVictoria.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", DBNull.Value)
                End If

                If DDL_OtravariedadM.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@txtOtravariedadM", txtOtravariedadM.Text)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DDL_OtravariedadM_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DDL_OtravariedadM_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", Convert.ToDouble(txtOtravariedadMHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", Convert.ToInt64(txtBultosOtravariedadM.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", Convert.ToDouble(txtPesoPrimOtravariedadM.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", Convert.ToDouble(txtPesoBrutOtravariedadM.Text))
                Else
                    cmd2.Parameters.AddWithValue("@txtOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", DBNull.Value)
                End If
                cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", DBNull.Value)

                cmd2.ExecuteNonQuery()
                conex.Close()

                'Response.Redirect(String.Format("~/pages/ActaRecepcionSemilla.aspx"))

                llenagrid()
            End If


            Label103.Text = "El Acta de Recepcion de semilla ha sido almacenada con exito"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If

        If btnGuardarActa.Text = "Editar" Then
            Dim ID As String = TxtID.Text
            Dim Sql2 As String
            Sql2 = "UPDATE acta_recepcion_semilla SET 
                        txtFechaSiembra = @txtFechaSiembra, 
                        txt_nombre_prod_new = @txt_nombre_prod_new, 
                        TxtCeduIden = @TxtCeduIden, 
                        DDL_cultivo = @DDL_cultivo, 
                        DDL_Amadeus = @DDL_Amadeus, 
                        DDL_Amadeus_Certificado = @DDL_Amadeus_Certificado, 
                        DDL_Amadeus_Comercial = @DDL_Amadeus_Comercial, 
                        txtAmadeusHumedad = @txtAmadeusHumedad, 
                        txtBultosAmadeus = @txtBultosAmadeus, 
                        txtPesoPrimAmadeus = @txtPesoPrimAmadeus, 
                        txtPesoBrutAmadeus = @txtPesoBrutAmadeus, 
                        DDL_Carrizalito = @DDL_Carrizalito, 
                        DDL_Carrizalito_Certificado = @DDL_Carrizalito_Certificado, 
                        DDL_Carrizalito_Comercial = @DDL_Carrizalito_Comercial, 
                        txtCarrizalitoHumedad = @txtCarrizalitoHumedad, 
                        txtBultosCarrizalito = @txtBultosCarrizalito, 
                        txtPesoPrimCarrizalito = @txtPesoPrimCarrizalito, 
                        txtPesoBrutCarrizalito = @txtPesoBrutCarrizalito, 
                        DDL_Deorho = @DDL_Deorho, 
                        DDL_Deorho_Certificado = @DDL_Deorho_Certificado, 
                        DDL_Deorho_Comercial = @DDL_Deorho_Comercial, 
                        txtDeorhoHumedad = @txtDeorhoHumedad, 
                        txtBultosDeorho = @txtBultosDeorho, 
                        txtPesoPrimDeorho = @txtPesoPrimDeorho, 
                        txtPesoBrutDeorho = @txtPesoBrutDeorho, 
                        DDL_Azabache = @DDL_Azabache, 
                        DDL_Azabache_Certificado = @DDL_Azabache_Certificado, 
                        DDL_Azabache_Comercial = @DDL_Azabache_Comercial, 
                        txtAzabacheHumedad = @txtAzabacheHumedad, 
                        txtBultosAzabache = @txtBultosAzabache, 
                        txtPesoPrimAzabache = @txtPesoPrimAzabache, 
                        txtPesoBrutAzabache = @txtPesoBrutAzabache, 
                        DDL_ParaisitoMejoradoPM2 = @DDL_ParaisitoMejoradoPM2, 
                        DDL_ParaisitoMejoradoPM2_Certificado = @DDL_ParaisitoMejoradoPM2_Certificado, 
                        DDL_ParaisitoMejoradoPM2_Comercial = @DDL_ParaisitoMejoradoPM2_Comercial, 
                        txtParaisitoMejoradoPM2Humedad = @txtParaisitoMejoradoPM2Humedad, 
                        txtBultosParaisitoMejoradoPM2 = @txtBultosParaisitoMejoradoPM2, 
                        txtPesoPrimParaisitoMejoradoPM2 = @txtPesoPrimParaisitoMejoradoPM2, 
                        txtPesoBrutParaisitoMejoradoPM2 = @txtPesoBrutParaisitoMejoradoPM2, 
                        DDL_Hondurasnutritivo = @DDL_Hondurasnutritivo, 
                        DDL_Hondurasnutritivo_Certificado = @DDL_Hondurasnutritivo_Certificado, 
                        DDL_Hondurasnutritivo_Comercial = @DDL_Hondurasnutritivo_Comercial, 
                        txtHondurasnutritivoHumedad = @txtHondurasnutritivoHumedad, 
                        txtBultosHondurasnutritivo = @txtBultosHondurasnutritivo, 
                        txtPesoPrimHondurasnutritivo = @txtPesoPrimHondurasnutritivo, 
                        txtPesoBrutHondurasnutritivo = @txtPesoBrutHondurasnutritivo, 
                        DDL_IntaCardenas = @DDL_IntaCardenas, 
                        DDL_IntaCardenas_Certificado = @DDL_IntaCardenas_Certificado, 
                        DDL_IntaCardenas_Comercial = @DDL_IntaCardenas_Comercial, 
                        txtIntaCardenasHumedad = @txtIntaCardenasHumedad, 
                        txtBultosIntaCardenas = @txtBultosIntaCardenas, 
                        txtPesoPrimIntaCardenas = @txtPesoPrimIntaCardenas, 
                        txtPesoBrutIntaCardenas = @txtPesoBrutIntaCardenas, 
                        DDL_Lencaprecoz = @DDL_Lencaprecoz, 
                        DDL_Lencaprecoz_Certificado = @DDL_Lencaprecoz_Certificado, 
                        DDL_Lencaprecoz_Comercial = @DDL_Lencaprecoz_Comercial, 
                        txtLencaprecozHumedad = @txtLencaprecozHumedad, 
                        txtBultosLencaprecoz = @txtBultosLencaprecoz, 
                        txtPesoPrimLencaprecoz = @txtPesoPrimLencaprecoz, 
                        txtPesoBrutLencaprecoz = @txtPesoBrutLencaprecoz, 
                        DDL_Rojochorti = @DDL_Rojochorti, 
                        DDL_Rojochorti_Certificado = @DDL_Rojochorti_Certificado, 
                        DDL_Rojochorti_Comercial = @DDL_Rojochorti_Comercial, 
                        txtRojochortiHumedad = @txtRojochortiHumedad, 
                        txtBultosRojochorti = @txtBultosRojochorti, 
                        txtPesoPrimRojochorti = @txtPesoPrimRojochorti, 
                        txtPesoBrutRojochorti = @txtPesoBrutRojochorti, 
                        DDL_Tolupanrojo = @DDL_Tolupanrojo, 
                        DDL_Tolupanrojo_Certificado = @DDL_Tolupanrojo_Certificado, 
                        DDL_Tolupanrojo_Comercial = @DDL_Tolupanrojo_Comercial, 
                        txtTolupanrojoHumedad = @txtTolupanrojoHumedad, 
                        txtBultosTolupanrojo = @txtBultosTolupanrojo, 
                        txtPesoPrimTolupanrojo = @txtPesoPrimTolupanrojo, 
                        txtPesoBrutTolupanrojo = @txtPesoBrutTolupanrojo, 
                        txtOtravariedad = @txtOtravariedad, 
                        DDL_Otravariedad_Certificado = @DDL_Otravariedad_Certificado, 
                        DDL_Otravariedad_Comercial = @DDL_Otravariedad_Comercial, 
                        txtOtravariedadHumedad = @txtOtravariedadHumedad, 
                        txtBultosOtravariedad = @txtBultosOtravariedad, 
                        txtPesoPrimOtravariedad = @txtPesoPrimOtravariedad, 
                        txtPesoBrutOtravariedad = @txtPesoBrutOtravariedad, 
                        DDL_DictaMaya = @DDL_DictaMaya, 
                        DDL_DictaMaya_Certificado = @DDL_DictaMaya_Certificado, 
                        DDL_DictaMaya_Comercial = @DDL_DictaMaya_Comercial, 
                        txtDictaMayaHumedad = @txtDictaMayaHumedad, 
                        txtBultosDictaMaya = @txtBultosDictaMaya, 
                        txtPesoPrimDictaMaya = @txtPesoPrimDictaMaya, 
                        txtPesoBrutDictaMaya = @txtPesoBrutDictaMaya, 
                        DDL_DictaVictoria = @DDL_DictaVictoria, 
                        DDL_DictaVictoria_Certificado = @DDL_DictaVictoria_Certificado, 
                        DDL_DictaVictoria_Comercial = @DDL_DictaVictoria_Comercial, 
                        txtDictaVictoriaHumedad = @txtDictaVictoriaHumedad, 
                        txtBultosDictaVictoria = @txtBultosDictaVictoria, 
                        txtPesoPrimDictaVictoria = @txtPesoPrimDictaVictoria, 
                        txtPesoBrutDictaVictoria = @txtPesoBrutDictaVictoria, 
                        txtOtravariedadM = @txtOtravariedadM, 
                        DDL_OtravariedadM_Certificado = @DDL_OtravariedadM_Certificado, 
                        DDL_OtravariedadM_Comercial = @DDL_OtravariedadM_Comercial, 
                        txtOtravariedadMHumedad = @txtOtravariedadMHumedad, 
                        txtBultosOtravariedadM = @txtBultosOtravariedadM, 
                        txtPesoPrimOtravariedadM = @txtPesoPrimOtravariedadM, 
                        txtPesoBrutOtravariedadM = @txtPesoBrutOtravariedadM 
                   WHERE id = " & ID & ""

            cmd2.Connection = conex
            cmd2.CommandText = Sql2

            cmd2.Parameters.AddWithValue("@txtFechaSiembra", fecha)
            cmd2.Parameters.AddWithValue("@txt_nombre_prod_new", txt_nombre_prod_new.Text)
            cmd2.Parameters.AddWithValue("@TxtCeduIden", TxtCeduIden.Text)
            cmd2.Parameters.AddWithValue("@DDL_cultivo", DDL_cultivo.Text)

            If DDL_SelCult.SelectedItem.Text = "Frijol" Then
                If DDL_Amadeus.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DDL_Amadeus_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DDL_Amadeus_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", Convert.ToDouble(txtAmadeusHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosAmadeus", Convert.ToInt64(txtBultosAmadeus.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", Convert.ToDouble(txtPesoPrimAmadeus.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", Convert.ToDouble(txtPesoBrutAmadeus.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosAmadeus", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", DBNull.Value)
                End If

                If DDL_Carrizalito.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DDL_Carrizalito_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DDL_Carrizalito_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", Convert.ToDouble(txtCarrizalitoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", Convert.ToInt64(txtBultosCarrizalito.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", Convert.ToDouble(txtPesoPrimCarrizalito.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", Convert.ToDouble(txtPesoBrutCarrizalito.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", DBNull.Value)
                End If

                If DDL_Deorho.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DDL_Deorho_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DDL_Deorho_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", Convert.ToDouble(txtDeorhoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDeorho", Convert.ToInt64(txtBultosDeorho.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", Convert.ToDouble(txtPesoPrimDeorho.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", Convert.ToDouble(txtPesoBrutDeorho.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDeorho", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", DBNull.Value)
                End If

                If DDL_Azabache.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DDL_Azabache_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DDL_Azabache_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", Convert.ToDouble(txtAzabacheHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosAzabache", Convert.ToInt64(txtBultosAzabache.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", Convert.ToDouble(txtPesoPrimAzabache.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", Convert.ToDouble(txtPesoBrutAzabache.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosAzabache", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", DBNull.Value)
                End If

                If DDL_ParaisitoMejoradoPM2.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DDL_ParaisitoMejoradoPM2_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DDL_ParaisitoMejoradoPM2_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", Convert.ToDouble(txtParaisitoMejoradoPM2Humedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", Convert.ToInt64(txtBultosParaisitoMejoradoPM2.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", Convert.ToDouble(txtPesoPrimParaisitoMejoradoPM2.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", Convert.ToDouble(txtPesoBrutParaisitoMejoradoPM2.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", DBNull.Value)
                End If

                If DDL_Hondurasnutritivo.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DDL_Hondurasnutritivo_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DDL_Hondurasnutritivo_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", Convert.ToDouble(txtHondurasnutritivoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", Convert.ToInt64(txtBultosHondurasnutritivo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", Convert.ToDouble(txtPesoPrimHondurasnutritivo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", Convert.ToDouble(txtPesoBrutHondurasnutritivo.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", DBNull.Value)
                End If

                If DDL_IntaCardenas.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DDL_IntaCardenas_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DDL_IntaCardenas_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", Convert.ToDouble(txtIntaCardenasHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", Convert.ToInt64(txtBultosIntaCardenas.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", Convert.ToDouble(txtPesoPrimIntaCardenas.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", Convert.ToDouble(txtPesoBrutIntaCardenas.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", DBNull.Value)
                End If

                If DDL_Lencaprecoz.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DDL_Lencaprecoz_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DDL_Lencaprecoz_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", Convert.ToDouble(txtLencaprecozHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", Convert.ToInt64(txtBultosLencaprecoz.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", Convert.ToDouble(txtPesoPrimLencaprecoz.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", Convert.ToDouble(txtPesoBrutLencaprecoz.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", DBNull.Value)
                End If

                If DDL_Rojochorti.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DDL_Rojochorti_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DDL_Rojochorti_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", Convert.ToDouble(txtRojochortiHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosRojochorti", Convert.ToInt64(txtBultosRojochorti.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", Convert.ToDouble(txtPesoPrimRojochorti.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", Convert.ToDouble(txtPesoBrutRojochorti.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosRojochorti", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", DBNull.Value)
                End If

                If DDL_Tolupanrojo.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DDL_Tolupanrojo_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DDL_Tolupanrojo_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", Convert.ToDouble(txtTolupanrojoHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", Convert.ToInt64(txtBultosTolupanrojo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", Convert.ToDouble(txtPesoPrimTolupanrojo.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", Convert.ToDouble(txtPesoBrutTolupanrojo.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", DBNull.Value)
                End If

                If DDL_Otravariedad.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@txtOtravariedad", txtOtravariedad.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DDL_Otravariedad_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DDL_Otravariedad_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", Convert.ToDouble(txtOtravariedadHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", Convert.ToInt64(txtBultosOtravariedad.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", Convert.ToDouble(txtPesoPrimOtravariedad.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", Convert.ToDouble(txtPesoBrutOtravariedad.Text))
                Else
                    cmd2.Parameters.AddWithValue("@txtOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", DBNull.Value)
                End If

                cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", DBNull.Value)

                cmd2.ExecuteNonQuery()
                conex.Close()

                'Response.Redirect(String.Format("~/pages/ActaRecepcionSemilla.aspx"))

                llenagrid()

            End If

            If DDL_SelCult.SelectedItem.Text = "Maiz" Then
                If DDL_DictaMaya.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DDL_DictaMaya_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DDL_DictaMaya_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", Convert.ToDouble(txtDictaMayaHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", Convert.ToInt64(txtBultosDictaMaya.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", Convert.ToDouble(txtPesoPrimDictaMaya.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", Convert.ToDouble(txtPesoBrutDictaMaya.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya", DDL_DictaMaya.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_DictaMaya_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDictaMayaHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDictaMaya", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaMaya", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaMaya", DBNull.Value)
                End If

                If DDL_DictaVictoria.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DDL_DictaVictoria_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DDL_DictaVictoria_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", Convert.ToDouble(txtDictaVictoriaHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", Convert.ToInt64(txtBultosDictaVictoria.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", Convert.ToDouble(txtPesoPrimDictaVictoria.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", Convert.ToDouble(txtPesoBrutDictaVictoria.Text))
                Else
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria", DDL_DictaVictoria.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_DictaVictoria_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtDictaVictoriaHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosDictaVictoria", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimDictaVictoria", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutDictaVictoria", DBNull.Value)
                End If

                If DDL_OtravariedadM.SelectedItem.Text = "Si" Then
                    cmd2.Parameters.AddWithValue("@txtOtravariedadM", txtOtravariedadM.Text)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DDL_OtravariedadM_Certificado.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DDL_OtravariedadM_Comercial.SelectedItem.Text)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", Convert.ToDouble(txtOtravariedadMHumedad.Text))
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", Convert.ToInt64(txtBultosOtravariedadM.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", Convert.ToDouble(txtPesoPrimOtravariedadM.Text))
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", Convert.ToDouble(txtPesoBrutOtravariedadM.Text))
                Else
                    cmd2.Parameters.AddWithValue("@txtOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Certificado", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@DDL_OtravariedadM_Comercial", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtOtravariedadMHumedad", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtBultosOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedadM", DBNull.Value)
                    cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedadM", DBNull.Value)
                End If

                cmd2.Parameters.AddWithValue("@DDL_Amadeus", DDL_Amadeus.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Amadeus_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Amadeus_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtAmadeusHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutAmadeus", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito", DDL_Carrizalito.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Carrizalito_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtCarrizalitoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutCarrizalito", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Deorho", DDL_Deorho.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Deorho_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Deorho_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtDeorhoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutDeorho", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Azabache", DDL_Azabache.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Azabache_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Azabache_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtAzabacheHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutAzabache", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2", DDL_ParaisitoMejoradoPM2.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_ParaisitoMejoradoPM2_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtParaisitoMejoradoPM2Humedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutParaisitoMejoradoPM2", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo", DDL_Hondurasnutritivo.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Hondurasnutritivo_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtHondurasnutritivoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutHondurasnutritivo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas", DDL_IntaCardenas.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_IntaCardenas_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtIntaCardenasHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutIntaCardenas", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz", DDL_Lencaprecoz.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Lencaprecoz_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtLencaprecozHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutLencaprecoz", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti", DDL_Rojochorti.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Rojochorti_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtRojochortiHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutRojochorti", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo", DDL_Tolupanrojo.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Tolupanrojo_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtTolupanrojoHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutTolupanrojo", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Certificado", DBNull.Value)
                cmd2.Parameters.AddWithValue("@DDL_Otravariedad_Comercial", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtOtravariedadHumedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtBultosOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoPrimOtravariedad", DBNull.Value)
                cmd2.Parameters.AddWithValue("@txtPesoBrutOtravariedad", DBNull.Value)

                cmd2.ExecuteNonQuery()
                conex.Close()

                'Response.Redirect(String.Format("~/pages/ActaRecepcionSemilla.aspx"))

                llenagrid()
            End If

            Label103.Text = "El Acta de Recepcion de semilla ha sido editada con exito"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub
    Private Sub exportar()

        Dim cadena As String = "txtFechaSiembra, txt_nombre_prod_new, TxtCeduIden, DDL_cultivo, 
               DDL_Amadeus, DDL_Amadeus_Certificado, DDL_Amadeus_Comercial, txtAmadeusHumedad, txtBultosAmadeus, txtPesoPrimAmadeus, txtPesoBrutAmadeus, 
               DDL_Carrizalito, DDL_Carrizalito_Certificado, DDL_Carrizalito_Comercial, txtCarrizalitoHumedad, txtBultosCarrizalito, txtPesoPrimCarrizalito, txtPesoBrutCarrizalito, 
               DDL_Deorho, DDL_Deorho_Certificado, DDL_Deorho_Comercial, txtDeorhoHumedad, txtBultosDeorho, txtPesoPrimDeorho, txtPesoBrutDeorho, 
               DDL_Azabache, DDL_Azabache_Certificado, DDL_Azabache_Comercial, txtAzabacheHumedad, txtBultosAzabache, txtPesoPrimAzabache, txtPesoBrutAzabache, 
               DDL_ParaisitoMejoradoPM2, DDL_ParaisitoMejoradoPM2_Certificado, DDL_ParaisitoMejoradoPM2_Comercial, txtParaisitoMejoradoPM2Humedad, txtBultosParaisitoMejoradoPM2, txtPesoPrimParaisitoMejoradoPM2, txtPesoBrutParaisitoMejoradoPM2, 
               DDL_Hondurasnutritivo, DDL_Hondurasnutritivo_Certificado, DDL_Hondurasnutritivo_Comercial, txtHondurasnutritivoHumedad, txtBultosHondurasnutritivo, txtPesoPrimHondurasnutritivo, txtPesoBrutHondurasnutritivo, 
               DDL_IntaCardenas, DDL_IntaCardenas_Certificado, DDL_IntaCardenas_Comercial, txtIntaCardenasHumedad, txtBultosIntaCardenas, txtPesoPrimIntaCardenas, txtPesoBrutIntaCardenas, 
               DDL_Lencaprecoz, DDL_Lencaprecoz_Certificado, DDL_Lencaprecoz_Comercial, txtLencaprecozHumedad, txtBultosLencaprecoz, txtPesoPrimLencaprecoz, txtPesoBrutLencaprecoz, 
               DDL_Rojochorti, DDL_Rojochorti_Certificado, DDL_Rojochorti_Comercial, txtRojochortiHumedad, txtBultosRojochorti, txtPesoPrimRojochorti, txtPesoBrutRojochorti, 
               DDL_Tolupanrojo, DDL_Tolupanrojo_Certificado, DDL_Tolupanrojo_Comercial, txtTolupanrojoHumedad, txtBultosTolupanrojo, txtPesoPrimTolupanrojo, txtPesoBrutTolupanrojo, 
               txtOtravariedad, DDL_Otravariedad_Certificado, DDL_Otravariedad_Comercial, txtOtravariedadHumedad, txtBultosOtravariedad, txtPesoPrimOtravariedad, txtPesoBrutOtravariedad, 
               DDL_DictaMaya, DDL_DictaMaya_Certificado, DDL_DictaMaya_Comercial, txtDictaMayaHumedad, txtBultosDictaMaya, txtPesoPrimDictaMaya, txtPesoBrutDictaMaya, 
               DDL_DictaVictoria, DDL_DictaVictoria_Certificado, DDL_DictaVictoria_Comercial, txtDictaVictoriaHumedad, txtBultosDictaVictoria, txtPesoPrimDictaVictoria, txtPesoBrutDictaVictoria, 
               txtOtravariedadM, DDL_OtravariedadM_Certificado, DDL_OtravariedadM_Comercial, txtOtravariedadMHumedad, txtBultosOtravariedadM, txtPesoPrimOtravariedadM, txtPesoBrutOtravariedadM, estado"
        Dim c1 As String = ""
        Dim c2 As String = ""
        Dim query As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND txt_nombre_prod_new = '" & TxtProductor.SelectedItem.Text & "' "
        End If

        If (DDL_SelCult.SelectedItem.Text = " ") Then
            c2 = " "
        Else
            c2 = "AND DDL_cultivo = '" & DDL_SelCult.SelectedItem.Text & "' "
        End If

        query = "SELECT " & cadena & " FROM acta_recepcion_semilla where Estado = '1' " & c1 & c2 & "ORDER BY txt_nombre_prod_new,DDL_cultivo"

        Using con As New MySqlConnection(conn)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "bcs_inscripcion_senasa"

                        Using wb As New XLWorkbook()
                            For Each dt As DataTable In ds.Tables
                                ' Add DataTable as Worksheet.
                                Dim ws As IXLWorksheet = wb.Worksheets.Add(dt)

                                ' Set auto width for all columns based on content.
                                ws.Columns().AdjustToContents()
                            Next

                            ' Export the Excel file.
                            Response.Clear()
                            Response.Buffer = True
                            Response.Charset = ""
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Response.AddHeader("content-disposition", "attachment;filename=Acta de Recepcion de Semilla  " & Today & " " & TxtProductor.SelectedItem.Text & " " & DDL_SelCult.SelectedItem.Text & ".xlsx")
                            Using MyMemoryStream As New MemoryStream()
                                wb.SaveAs(MyMemoryStream)
                                MyMemoryStream.WriteTo(Response.OutputStream)
                                Response.Flush()
                                Response.End()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub


End Class