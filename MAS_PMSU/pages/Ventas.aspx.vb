Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class Ventas
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then

            Else
                llenarcomboCiclo()
                llenarcomboDepto()
                Dim newitem As New ListItem(" ", " ")
                TxtProductor.Items.Insert(0, newitem)
                llenagrid()
                Div2.Style.Add("display", "none")
                Div1.Style.Add("display", "block")
                TxtProductor.Enabled = False
            End If
        End If


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
    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT * FROM tb_departamentos"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(2).ToString
        TxtDepto.DataBind()
        Dim newitem As New ListItem(" ", " ")
        TxtDepto.Items.Insert(0, newitem)
    End Sub

    Private Sub llenarcomboProductor()
        If TxtDepto.SelectedItem.Text <> " " Then
            Dim StrCombo As String = "SELECT DISTINCT Productor FROM bcs_inscripcion_senasa WHERE Departamento = @nombre ORDER BY Productor ASC"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", TxtDepto.SelectedItem.Text)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)
            TxtProductor.DataSource = DtCombo
            TxtProductor.DataValueField = "Productor"
            TxtProductor.DataTextField = "Productor"
            TxtProductor.DataBind()
            Dim newitem As New ListItem(" ", " ")
            TxtProductor.Items.Insert(0, newitem)
        End If
        If TxtDepto.SelectedItem.Text = " " Then
            TxtProductor.SelectedValue = " "
        End If
    End Sub

    Sub llenagrid()

        'import.Visible = False
        Dim cadena As String = "ID AS ID, Departamento AS Departamento, Productor AS Productor, cultivo AS Cultivo, CICLO AS CICLO, VARIEDAD AS VARIEDAD, CATEGORIA AS CATEGORIA, AREA_HA AS AREA_HA, AREA_MZ AS AREA_MZ, QQ_Produccion_Campo AS QQ_Produccion_Campo, QQ_Oro AS QQ_Oro, QQ_Grano AS QQ_Grano, QQ_Basura AS QQ_Basura, Habilitado AS Habilitado, DATE_FORMAT(Fecha_siembra, '%d-%m-%Y') AS Fecha_siembra, QQ_semilla_entregado AS QQ_semilla_entregado, QQ_consumo_entregado AS QQ_consumo_entregado"

        Dim c1 As String = ""
        Dim c2 As String = ""
        Dim c3 As String = ""
        Dim c4 As String = ""
        Dim c5 As String = ""
        Dim c6 As String = ""
        Dim c7 As String = ""
        Dim c8 As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND  Productor = '" & TxtProductor.SelectedItem.Text & "' "
        End If

        If (DDL_cultivo.SelectedItem.Text = " ") Then
            c2 = " "
        Else
            c2 = "AND Cultivo = '" & DDL_cultivo.SelectedItem.Text & "' "
        End If

        If (TxtCiclo.SelectedItem.Text = " ") Then
            c3 = " "
        Else
            c3 = "AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' "
        End If

        If (TxtDepto.SelectedItem.Text = " ") Then
            c4 = " "
        Else
            c4 = "AND Departamento = '" & TxtDepto.SelectedItem.Text & "' "
        End If
        If (DDL_Categ.SelectedItem.Text = " ") Then
            c5 = " "
        Else
            c5 = "AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' "
        End If

        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM vista_bcs_ventas WHERE Estado = '1' " & c1 & c2 & c3 & c4 & c5 & " ORDER BY Departamento,Productor,CICLO"

    End Sub
    Protected Sub DDL_cultivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_cultivo.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub DDL_Categ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_Categ.SelectedIndexChanged
        llenagrid()
    End Sub
    Protected Sub TxtCiclo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCiclo.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        If TxtDepto.SelectedItem.Text <> " " Then
            llenarcomboProductor()
            llenagrid()
            TxtProductor.Enabled = True
        Else
            TxtProductor.Enabled = False
            llenarcomboProductor()
            llenagrid()
        End If
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

    Protected Sub PageDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
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

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Private Sub llenarVAIDAD_CICLO()

    End Sub

    Protected Sub limpiarFiltros(sender As Object, e As EventArgs)
        Response.Redirect("Ventas.aspx")
    End Sub
    Private Function FileUploadToBytes(fileUpload As FileUpload) As Byte()
        Using stream As System.IO.Stream = fileUpload.PostedFile.InputStream
            Dim length As Integer = fileUpload.PostedFile.ContentLength
            Dim bytes As Byte() = New Byte(length - 1) {}
            stream.Read(bytes, 0, length)
            Return bytes
        End Using
    End Function


    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Dim rptdocument As New ReportDocument
        Dim productor As String = TxtProductor.SelectedItem.Text
        Dim ciclo As String = TxtCiclo.SelectedItem.Text
        'nombre de dataset
        Dim ds As New DataSet1
        Dim Str As String = "Select * FROM vista_inscripcion_senasa_lote WHERE Productor = '" & productor & "' AND CICLO = '" & ciclo & "'"
        Dim adap As New MySqlDataAdapter(Str, conn)
        Dim dt As New DataTable

        ' Nombre de la vista del dataset
        adap.Fill(ds, "vista_inscripcion_senasa_lote")

        Dim nombre As String
        nombre = "Solicitud Inscripcion de Lote o Campo _" + Today
        rptdocument.Load(Server.MapPath("~/pages/CrystalReport3.rpt"))
        rptdocument.SetDataSource(ds)

        ' Usar un HashSet para almacenar municipios únicos
        Dim municipiosUnicos As New HashSet(Of String)()

        For Each row As DataRow In ds.Tables("vista_inscripcion_senasa_lote").Rows
            If Not IsDBNull(row("Municipio")) Then
                municipiosUnicos.Add(row("Municipio").ToString())
            End If
        Next

        ' Convertir el HashSet en una cadena separada por comas
        Dim MunicipiosConcatenados As String = String.Join(", ", municipiosUnicos)

        rptdocument.SetParameterValue("CadenaMunicipios", MunicipiosConcatenados)

        Response.Buffer = False
        Response.ClearContent()
        Response.ClearHeaders()

        rptdocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, True, nombre)

        Response.End()
    End Sub
    '***********************************************************************************************************************************
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim qq_entregado_con, qq_entregado_det As Decimal

        If (e.CommandName = "Ventas") Then

            Div1.Style.Add("display", "none")
            Div2.Style.Add("display", "block")
            Guardar_registro.Visible = True
            llenarcombocompradoresSemilla()
            llenarcombocompradoresGrano()
            'llenarcombocompradores_grano()
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM vista_bcs_detalles WHERE ID = '" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "'"

            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()
            TxtId2.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            If txt_habilitado.Text = "🔒︎" Then
                'Label8.Text = "Para este ciclo ya ha finalizado el tiempo para detallar los valores de ventas, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else
                'divedit.Visible = True
                'divdatos.Visible = False
                'TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
                'TxtNom2.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString
                Text_departamento.Text = dt.Rows(0)("Departamento").ToString()
                Text_municipio.Text = dt.Rows(0)("Municipio").ToString()
                Text_aldea.Text = dt.Rows(0)("Aldea").ToString()
                Text_caserio.Text = dt.Rows(0)("Caserio").ToString()
                Text_codigo_bcs.Text = dt.Rows(0)("Codigo_BCS").ToString()
                Text_nombre_productor.Text = dt.Rows(0)("Productor").ToString()
                Text_categoria.Text = dt.Rows(0)("CATEGORIA").ToString()
                Text_ciclo.Text = dt.Rows(0)("CICLO").ToString()
                Text_variedad.Text = dt.Rows(0)("VARIEDAD").ToString()

                Text_QQ_Produccion.Text = dt.Rows(0)("QQ_Produccion_Campo").ToString()
                Text_QQ_Produccion_ORO.Text = dt.Rows(0)("QQ_ORO").ToString()
                Text_QQ_Produccion_consumo.Text = dt.Rows(0)("QQ_Grano").ToString()
                Text_QQ_Produccion_basura.Text = dt.Rows(0)("QQ_BASURA").ToString()

                'txt_fuente.Text = dt.Rows(0)("QQ_BASURA").ToString()


                If txt_fuente.Text = "Dinamica" Then

                    If String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gvrow.Cells(15).Text).ToString) Then
                        TXT_QQ_ORO_ENTRE.Text = "0"
                    Else
                        TXT_QQ_ORO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(15).Text).ToString
                    End If

                    If String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gvrow.Cells(16).Text).ToString) Then
                        TXT_QQ_CONSUMO_ENTRE.Text = "0"
                    Else
                        TXT_QQ_CONSUMO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(16).Text).ToString
                    End If

                    'txt_semilla_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(8).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(10).Text).ToString
                    'txt_consumo_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(9).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString

                    '    TXT_QQ_ORO_ENTRE.Text = Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_consolidado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_detallado").ToString()) + Convert.ToDecimal((dt.Rows(0)("QQ_consumo_semilla_consolidado").ToString())))
                    '    TXT_QQ_CONSUMO_ENTRE.Text = Convert.ToDecimal((dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString()))

                    '    txt_semilla_por_detallar.Text = Convert.ToDecimal(dt.Rows(0)("QQ_ORO").ToString()) - (Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_consolidado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_detallado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_consumo_semilla_consolidado").ToString())))
                    '    txt_consumo_por_detallar.Text = Convert.ToDecimal(dt.Rows(0)("QQ_CONSUMO").ToString()) - (Convert.ToDecimal((dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString())))
                Else
                    If String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gvrow.Cells(15).Text).ToString) Then
                        TXT_QQ_ORO_ENTRE.Text = "0"
                    Else
                        TXT_QQ_ORO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(15).Text).ToString
                    End If

                    If String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gvrow.Cells(16).Text).ToString) Then
                        TXT_QQ_CONSUMO_ENTRE.Text = "0"
                    Else
                        TXT_QQ_CONSUMO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(16).Text).ToString
                    End If

                    Dim valorCelda11 As String = HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString()
                    Dim valorCelda15 As String = HttpUtility.HtmlDecode(gvrow.Cells(15).Text).ToString()

                    If Not String.IsNullOrWhiteSpace(valorCelda11) AndAlso Not String.IsNullOrWhiteSpace(valorCelda15) Then
                        Dim resultado As Double = Convert.ToDouble(valorCelda11) - Convert.ToDouble(valorCelda15)
                        txt_semilla_por_detallar.Text = resultado.ToString()
                    Else
                        txt_semilla_por_detallar.Text = valorCelda11 ' o cualquier otro valor predeterminado
                    End If

                    Dim valorCelda12 As String = HttpUtility.HtmlDecode(gvrow.Cells(12).Text).ToString()
                    Dim valorCelda16 As String = HttpUtility.HtmlDecode(gvrow.Cells(16).Text).ToString()

                    If Not String.IsNullOrWhiteSpace(valorCelda12) AndAlso Not String.IsNullOrWhiteSpace(valorCelda16) Then
                        Dim resultado As Double = Convert.ToDouble(valorCelda12) - Convert.ToDouble(valorCelda16)
                        txt_consumo_por_detallar.Text = resultado.ToString()
                    Else
                        txt_consumo_por_detallar.Text = valorCelda12 ' o cualquier otro valor predeterminado
                    End If
                End If

                'TXT_QQ_VENTA_GRANO.Text = dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString()

                'TXT_QQ_GRANO_CONSUMO.Text = dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString()

                txt_qq.Text = 0
                txt_precio.Text = 0
                txt_qq_consumo.Text = 0
                txt_precio_consumo.Text = 0
                txt_total_venta.Text = 0
                txt_ingreso_consumo.Text = 0

                TXT_QQ_VENTA_GRANO.Text = 0
                TXT_PRECIO_GRANO.Text = 0
                TXT_QQ_GRANO_CONSUMO.Text = 0
                TXT_PRECIO_GRANO_CONSUMO.Text = 0
                TXT_INGRESO_TOTAL_VENGRANO.Text = 0
                TXT_INGRESO_TOTAL_CONSGRANO.Text = 0

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DetCostos').modal('show'); });", True)
            End If
        End If

        If (e.CommandName = "Eliminar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)
            Dim idSeleccionado As String = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString

            ' Redirigir a la otra página llevando consigo el ID como parámetro en la URL
            Response.Redirect("RegistrosVentas.aspx?id=" & idSeleccionado)

        End If

    End Sub
    Private Sub llenarcombocompradoresSemilla()
        Dim StrCombo As String
        Dim newitem As New ListItem(" ", " ")

        StrCombo = "SELECT * FROM comprador_provi_pash"

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        Dim contador As Integer = DtCombo.Rows.Count

        Dp_comprador.DataSource = DtCombo
        Dp_comprador.DataValueField = DtCombo.Columns(1).ToString()
        Dp_comprador.DataTextField = DtCombo.Columns(1).ToString()
        Dp_comprador.DataBind()
        Dp_comprador.Items.Insert(0, newitem)
        Dim newitem2 As New ListItem("Otro", "Otro")
        Dp_comprador.Items.Insert(contador + 1, newitem2)
    End Sub

    Private Sub llenarcombocompradoresGrano()
        Dim StrCombo As String
        Dim newitem As New ListItem(" ", " ")

        StrCombo = "SELECT * FROM comprador_provi_pash"

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        Dim contador As Integer = DtCombo.Rows.Count

        dp_comprador_grano.DataSource = DtCombo
        dp_comprador_grano.DataValueField = DtCombo.Columns(1).ToString
        dp_comprador_grano.DataTextField = DtCombo.Columns(1).ToString
        dp_comprador_grano.DataBind()
        dp_comprador_grano.Items.Insert(0, newitem)
        Dim newitem2 As New ListItem("Otro", "Otro")
        dp_comprador_grano.Items.Insert(contador + 1, newitem2)
    End Sub

    Private Sub detallellenarcombocompradoresGrano()
        Dim StrCombo As String
        Dim newitem As New ListItem(" ", " ")

        StrCombo = "SELECT * FROM comprador_provi_pash"

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TXT_COMPRADOR_GRANO.Text = DtCombo.Rows(0)(2).ToString
    End Sub

    Private Sub detallellenarcombocompradoresSemilla()
        Dim StrCombo As String
        Dim newitem As New ListItem(" ", " ")

        StrCombo = "SELECT * FROM comprador_provi_pash"

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        txt_detalle_comprador.Text = DtCombo.Rows(0)(2).ToString
    End Sub

    Protected Sub VALIDAR_ENTREGAS()
        Dim QQ_SEMILLA_DETALLAR, QQ_VENTA_SEMILLA, TOTAL_LIMITE, QQ_VENTA_CONSUMO As Decimal
        Dim grano_detallar, venta_qq_grano, consumo_qq_grano, total_qq_grano As Decimal
        Dim validado, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 As Integer

        'semilla
        QQ_SEMILLA_DETALLAR = txt_semilla_por_detallar.Text
        QQ_VENTA_SEMILLA = txt_qq.Text
        QQ_VENTA_CONSUMO = txt_qq_consumo.Text
        TOTAL_LIMITE = QQ_VENTA_SEMILLA + QQ_VENTA_CONSUMO

        'grano
        grano_detallar = txt_consumo_por_detallar.Text
        venta_qq_grano = TXT_QQ_VENTA_GRANO.Text
        consumo_qq_grano = TXT_QQ_GRANO_CONSUMO.Text

        total_qq_grano = venta_qq_grano + consumo_qq_grano

        If TOTAL_LIMITE > QQ_SEMILLA_DETALLAR Then

            LB_VALIDACION_QQ_sEMILLA.Text = "Por favor revisar la informacion a  ingresar, los QQ por entregar es: " & TOTAL_LIMITE & "  y los QQ por detallar semilla es: " & QQ_SEMILLA_DETALLAR & " "
            a1 = 1

        Else

            LB_VALIDACION_QQ_sEMILLA.Text = " ✔ "


            a1 = 0
        End If


        'campos venta semilla

        If txt_qq.Text > 0 Then
            If txt_precio.Text > 0 Then
                lb_precio_semilla_venta.Text = " ✔ "
                a2 = 0
            Else
                a2 = 1
                lb_precio_semilla_venta.Text = " Por favor ingresar el precio"
            End If
        Else
            lb_precio_semilla_venta.Text = " ✔ "
        End If

        If txt_qq.Text > 0 Then
            If Dp_comprador.Text = "Otro" And txt_detalle_comprador.Text = "" Then
                a3 = 1
                Lb_comprador_semilla.Text = "  Por favor ingresar comprador"
                Lb_comprador_semilla_detalle.Text = "  Por favor detallar comprador"
            Else
                a3 = 0
                Lb_comprador_semilla.Text = " ✔ "
                Lb_comprador_semilla_detalle.Text = " ✔ "
            End If

            If Dp_comprador.Text = " Todos" Then
                a4 = 1
                Lb_comprador_semilla.Text = "  Por favor detallar comprador"
            Else
                a4 = 0
                Lb_comprador_semilla.Text = " ✔ "
            End If
        Else
            Lb_comprador_semilla.Text = " ✔ "
            Lb_comprador_semilla_detalle.Text = ""
        End If

        'campos consumo semilla
        If txt_qq_consumo.Text > 0 Then
            If txt_precio_consumo.Text > 0 Then
                lb_precio_consumo_semilla.Text = " ✔ "
            Else
                lb_precio_consumo_semilla.Text = " Por favor ingresar el precio"
                a5 = 1
            End If

        Else
            lb_precio_consumo_semilla.Text = " ✔ "
        End If

        'campos venta grano (consumo)
        If total_qq_grano > grano_detallar Then

            lb_validacion_consumo.Text = "Por favor revisar la informacion a  ingresar, los QQ por entregar es: " & total_qq_grano & "  y los QQ por consumo por detallar es: " & grano_detallar & " "
            a6 = 1

        Else

            lb_validacion_consumo.Text = " ✔"


            a6 = 0
        End If

        If TXT_QQ_VENTA_GRANO.Text > 0 Then

            If dp_comprador_grano.Text = "Otro" And TXT_COMPRADOR_GRANO.Text = "" Then
                a7 = 1
                lb_comprador_detalle_grano.Text = "Por favor detallar comprador"
                lb_comprador_grano.Text = "  Por favor detallar comprador"
            Else
                a7 = 0
                lb_comprador_detalle_grano.Text = " ✔"
                lb_comprador_grano.Text = " ✔"
            End If

            If dp_comprador_grano.Text = " Todos" Then
                a8 = 1
                lb_comprador_grano.Text = "  Por favor ingresar comprador"

            Else
                a8 = 0
                lb_comprador_grano.Text = " ✔"
            End If

        Else

            lb_comprador_grano.Text = " ✔"
            lb_comprador_detalle_grano.Text = ""

        End If

        If TXT_QQ_VENTA_GRANO.Text > 0 Then
            If TXT_PRECIO_GRANO.Text > 0 Then

                a9 = 0
                lb_precio_grano_venta.Text = " ✔"
            Else
                a9 = 1
                lb_precio_grano_venta.Text = " Por favor ingresar el precio"
            End If
        Else
            lb_precio_grano_venta.Text = " ✔"
        End If


        If TXT_QQ_GRANO_CONSUMO.Text > 0 Then
            If TXT_PRECIO_GRANO_CONSUMO.Text > 0 Then

                a10 = 0
                LB_grano_consumo.Text = " ✔"
            Else
                a10 = 1
                LB_grano_consumo.Text = " Por favor ingresar el precio"
            End If

        Else
            LB_grano_consumo.Text = " ✔"
        End If

        validado = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10

        If validado = 0 Then
            Guardar_registro.Visible = True
        Else
            Guardar_registro.Visible = False


        End If

    End Sub

    Protected Sub calcular_venta()
        txt_total_venta.Text = Convert.ToDecimal(txt_precio.Text) * Convert.ToDecimal(txt_qq.Text)

    End Sub
    Protected Sub calcular_venta_consumo()
        txt_ingreso_consumo.Text = Convert.ToDecimal(txt_qq_consumo.Text) * Convert.ToDecimal(txt_precio_consumo.Text)

    End Sub

    Protected Sub calcular_venta_grano()
        TXT_INGRESO_TOTAL_VENGRANO.Text = Convert.ToDecimal(TXT_QQ_VENTA_GRANO.Text) * Convert.ToDecimal(TXT_PRECIO_GRANO.Text)

    End Sub


    Protected Sub calcular_venta_consumo_grano()
        TXT_INGRESO_TOTAL_CONSGRANO.Text = Convert.ToDecimal(TXT_QQ_GRANO_CONSUMO.Text) * Convert.ToDecimal(TXT_PRECIO_GRANO_CONSUMO.Text)

    End Sub

    'Protected Sub validar()
    '    If Dp_comprador.Text = "Otro" And txt_detalle_comprador.Text = "" Then
    '        Guardar_registro.Visible = False
    '
    '    Else
    '        Guardar_registro.Visible = True
    '    End If
    'End Sub



    Protected Sub txt_qq_TextChanged(sender As Object, e As EventArgs) Handles txt_qq.TextChanged
        If txt_qq.Text <> "" Then
            calcular_venta()
            VALIDAR_ENTREGAS()
        Else
            txt_qq.Text = 0
        End If
    End Sub

    Protected Sub txt_precio_TextChanged(sender As Object, e As EventArgs) Handles txt_precio.TextChanged
        If txt_precio.Text <> "" Then
            calcular_venta()
            VALIDAR_ENTREGAS()
        Else
            txt_precio.Text = 0
        End If
    End Sub

    Protected Sub txt_detalle_comprador_TextChanged(sender As Object, e As EventArgs) Handles txt_detalle_comprador.TextChanged
        'validar()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_qq_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_qq_consumo.TextChanged
        If txt_qq_consumo.Text <> "" Then
            calcular_venta_consumo()
            VALIDAR_ENTREGAS()
        Else
            txt_qq_consumo.Text = 0
        End If
    End Sub

    Protected Sub txt_precio_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_precio_consumo.TextChanged
        If txt_precio_consumo.Text <> "" Then
            calcular_venta_consumo()
            VALIDAR_ENTREGAS()
        Else
            txt_precio_consumo.Text = 0
        End If
    End Sub

    Protected Sub Txtproductor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub Cancelar_edit_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Response.Redirect(String.Format("~/pages/Ventas.aspx"))
    End Sub

    'Protected Sub SI_editar_Click(sender As Object, e As EventArgs) Handles SI_editar.Click
    '    Dim conex As New MySqlConnection(conn)
    '
    '    conex.Open()
    '    Dim Sql As String
    '    Dim cmd2 As New MySqlCommand()
    '    Sql = "UPDATE  `bcs_entregas_2022` set QQ_entregado=@QQ_entregado, Precio=@Precio , Total_entrega=@Total_entrega, comprador=@comprador, otro_comprador=@otro_comprador, QQ_entregado_consumo=@QQ_entregado_consumo,  Precio_consumo=@Precio_consumo,  Total_entrega_consumo=@Total_entrega_consumo  WHERE COD_BCS='" + Text_codigo_bcs.Text + "' AND Ciclo='" + Text_ciclo.Text + "' AND  variedad='" + Text_variedad.Text + "'  "
    '
    '    cmd2.Connection = conex
    '    cmd2.CommandText = Sql
    '
    '    cmd2.Parameters.AddWithValue("@QQ_entregado", txt_qq.Text)
    '    cmd2.Parameters.AddWithValue("@Precio", txt_precio.Text)
    '    cmd2.Parameters.AddWithValue("@Total_entrega", txt_total_venta.Text)
    '    cmd2.Parameters.AddWithValue("@comprador", Dp_comprador.Text)
    '    cmd2.Parameters.AddWithValue("@otro_comprador", txt_detalle_comprador.Text)
    '    cmd2.Parameters.AddWithValue("@QQ_entregado_consumo", txt_qq_consumo.Text)
    '    cmd2.Parameters.AddWithValue("@Precio_consumo", txt_precio_consumo.Text)
    '    cmd2.Parameters.AddWithValue("@Total_entrega_consumo", txt_ingreso_consumo.Text)
    '
    '    cmd2.ExecuteNonQuery()
    '    conex.Close()
    '
    '    llenagrid()
    'End Sub

    Protected Sub TXT_QQ_VENTA_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_VENTA_GRANO.TextChanged
        If TXT_QQ_VENTA_GRANO.Text <> "" Then
            VALIDAR_ENTREGAS()
            calcular_venta_grano()
        Else
            TXT_QQ_VENTA_GRANO.Text = 0
        End If
    End Sub

    Protected Sub TXT_QQ_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_GRANO_CONSUMO.TextChanged
        If TXT_QQ_GRANO_CONSUMO.Text <> "" Then
            VALIDAR_ENTREGAS()
            calcular_venta_consumo_grano()
        Else
            TXT_QQ_GRANO_CONSUMO.Text = 0
        End If
    End Sub

    Protected Sub TXT_PRECIO_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO.TextChanged
        If TXT_PRECIO_GRANO.Text <> "" Then
            VALIDAR_ENTREGAS()
            calcular_venta_grano()
        Else
            TXT_PRECIO_GRANO.Text = 0
        End If
    End Sub

    Protected Sub dp_comprador_grano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dp_comprador_grano.SelectedIndexChanged
        Dp_comprador.SelectedValue = dp_comprador_grano.SelectedValue
        If dp_comprador_grano.SelectedItem.Text <> "" Then
            detallellenarcombocompradoresGrano()
            VALIDAR_ENTREGAS()
        End If

        If dp_comprador_grano.SelectedItem.Text = "Otro" Then
            TxtCom_new2.Visible = True
            TXT_COMPRADOR_GRANO.Text = ""
            TXT_COMPRADOR_GRANO.Enabled = True
            Dp_comprador.SelectedValue = dp_comprador_grano.SelectedValue
            TxtCom_new.Text = TxtCom_new2.Text
            txt_detalle_comprador.Text = ""
            TxtCom_new.Visible = True
            txt_detalle_comprador.Text = ""
            txt_detalle_comprador.Enabled = True
            dp_comprador_grano.SelectedValue = Dp_comprador.SelectedValue
            TxtCom_new2.Text = TxtCom_new.Text
            TXT_COMPRADOR_GRANO.Text = ""
            VALIDAR_ENTREGAS()
        Else
            TxtCom_new.Visible = False
            txt_detalle_comprador.Enabled = False
            txt_detalle_comprador.Text = ""
            TxtCom_new2.Visible = False
            TXT_COMPRADOR_GRANO.Enabled = False
            TXT_COMPRADOR_GRANO.Text = ""
            VALIDAR_ENTREGAS()
        End If
    End Sub

    Protected Sub Dp_comprador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dp_comprador.SelectedIndexChanged
        dp_comprador_grano.SelectedValue = Dp_comprador.SelectedValue
        If Dp_comprador.SelectedItem.Text <> "" Then
            detallellenarcombocompradoresSemilla()
            VALIDAR_ENTREGAS()
        End If

        If Dp_comprador.SelectedItem.Text = "Otro" Then
            TxtCom_new2.Visible = True
            TXT_COMPRADOR_GRANO.Text = ""
            TXT_COMPRADOR_GRANO.Enabled = True
            Dp_comprador.SelectedValue = dp_comprador_grano.SelectedValue
            TxtCom_new.Text = TxtCom_new2.Text
            txt_detalle_comprador.Text = ""
            TxtCom_new.Visible = True
            txt_detalle_comprador.Text = ""
            txt_detalle_comprador.Enabled = True
            dp_comprador_grano.SelectedValue = Dp_comprador.SelectedValue
            TxtCom_new2.Text = TxtCom_new.Text
            TXT_COMPRADOR_GRANO.Text = ""
            VALIDAR_ENTREGAS()
        Else
            TxtCom_new.Visible = False
            txt_detalle_comprador.Enabled = False
            txt_detalle_comprador.Text = ""
            TxtCom_new2.Visible = False
            TXT_COMPRADOR_GRANO.Enabled = False
            TXT_COMPRADOR_GRANO.Text = ""
            VALIDAR_ENTREGAS()
        End If

    End Sub

    Protected Sub TXT_COMPRADOR_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_COMPRADOR_GRANO.TextChanged
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub TXT_PRECIO_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO_CONSUMO.TextChanged
        If TXT_PRECIO_GRANO_CONSUMO.Text <> "" Then
            VALIDAR_ENTREGAS()
            calcular_venta_consumo_grano()
        Else
            TXT_PRECIO_GRANO_CONSUMO.Text = 0
        End If
    End Sub

    Protected Sub btn_si_Click(sender As Object, e As EventArgs) Handles btn_si.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()
        Dim total_entregado_semilla As Double
        Dim total_entregado_grano As Double

        total_entregado_semilla = Convert.ToDouble(txt_qq.Text) + Convert.ToDouble(txt_qq_consumo.Text)
        total_entregado_grano = Convert.ToDouble(TXT_QQ_VENTA_GRANO.Text) + Convert.ToDouble(TXT_QQ_GRANO_CONSUMO.Text)

        Sql = "INSERT INTO ventas_pash (departamento, 
        municipio, aldea, cacerio, codigo_bcs, nombre_productor, 
        ciclo, variedad, QQ_produccion, QQ_semilla_certificada_comercial, 
        QQ_consumo_granos_humano_usos, QQ_semilla_entregado, QQ_semilla_detallar, 
        QQ_consumo_entregado, QQ_consumo_detallar, QQ_basura, QQ_semilla_cc_ventas, 
        QQ_semilla_precio_cc_venta, comprador_cc_ventas, detalles_comprador_cc_ventas, 
        ingreso_total_cc_ventas, QQ_semilla_cc_consumo, QQ_semilla_precio_cc_consumo, 
        ingreso_total_cc_consumo, QQ_grano_humano_snc_ventas, QQ_grano_humano_precio_snc_ventas, 
        comprador_snc_ventas, detalles_comprador_snc_ventas, ingreso_total_snc_ventas, QQ_grano_snc_consumo, 
        QQ_grano_precio_snc_consumo, ingreso_total_snc_consumo, estado, id2) values (@departamento, @municipio, @aldea, @cacerio, 
        @codigo_bcs, @nombre_productor, @ciclo, @variedad, @QQ_produccion, @QQ_semilla_certificada_comercial, @QQ_consumo_granos_humano_usos, 
        @QQ_semilla_entregado, @QQ_semilla_detallar, @QQ_consumo_entregado, @QQ_consumo_detallar, @QQ_basura, @QQ_semilla_cc_ventas, @QQ_semilla_precio_cc_venta, 
        @comprador_cc_ventas, @detalles_comprador_cc_ventas, @ingreso_total_cc_ventas, @QQ_semilla_cc_consumo, @QQ_semilla_precio_cc_consumo, @ingreso_total_cc_consumo, 
        @QQ_grano_humano_snc_ventas, @QQ_grano_humano_precio_snc_ventas, @comprador_snc_ventas, @detalles_comprador_snc_ventas, @ingreso_total_snc_ventas, @QQ_grano_snc_consumo, 
        @QQ_grano_precio_snc_consumo, @ingreso_total_snc_consumo, @estado, @id2)"

        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@departamento", Text_departamento.Text)
        cmd2.Parameters.AddWithValue("@municipio", Text_municipio.Text)
        cmd2.Parameters.AddWithValue("@aldea", Text_municipio.Text)
        cmd2.Parameters.AddWithValue("@cacerio", Text_caserio.Text)
        cmd2.Parameters.AddWithValue("@codigo_bcs", Text_codigo_bcs.Text)
        cmd2.Parameters.AddWithValue("@nombre_productor", Text_nombre_productor.Text)
        cmd2.Parameters.AddWithValue("@ciclo", Text_ciclo.Text)
        cmd2.Parameters.AddWithValue("@variedad", Text_variedad.Text)
        cmd2.Parameters.AddWithValue("@QQ_produccion", Text_QQ_Produccion.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_certificada_comercial", Text_QQ_Produccion_ORO.Text)
        cmd2.Parameters.AddWithValue("@QQ_consumo_granos_humano_usos", Text_QQ_Produccion_consumo.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_entregado", total_entregado_semilla)
        cmd2.Parameters.AddWithValue("@QQ_semilla_detallar", txt_semilla_por_detallar.Text)
        cmd2.Parameters.AddWithValue("@QQ_consumo_entregado", total_entregado_grano)
        cmd2.Parameters.AddWithValue("@QQ_consumo_detallar", txt_consumo_por_detallar.Text)
        cmd2.Parameters.AddWithValue("@QQ_basura", Text_QQ_Produccion_basura.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_cc_ventas", txt_qq.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_precio_cc_venta", txt_precio.Text)

        If Dp_comprador.SelectedItem.Text = "Otro" Then
            cmd2.Parameters.AddWithValue("@comprador_cc_ventas", TxtCom_new.Text)
            cmd2.Parameters.AddWithValue("@detalles_comprador_cc_ventas", txt_detalle_comprador.Text)
        Else
            cmd2.Parameters.AddWithValue("@comprador_cc_ventas", Dp_comprador.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@detalles_comprador_cc_ventas", txt_detalle_comprador.Text)
        End If

        cmd2.Parameters.AddWithValue("@ingreso_total_cc_ventas", txt_total_venta.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_cc_consumo", txt_qq_consumo.Text)
        cmd2.Parameters.AddWithValue("@QQ_semilla_precio_cc_consumo", txt_precio_consumo.Text)
        cmd2.Parameters.AddWithValue("@ingreso_total_cc_consumo", txt_ingreso_consumo.Text)
        cmd2.Parameters.AddWithValue("@QQ_grano_humano_snc_ventas", TXT_QQ_VENTA_GRANO.Text)
        cmd2.Parameters.AddWithValue("@QQ_grano_humano_precio_snc_ventas", TXT_PRECIO_GRANO.Text)

        If dp_comprador_grano.SelectedItem.Text = "Otro" Then
            cmd2.Parameters.AddWithValue("@comprador_snc_ventas", TxtCom_new2.Text)
            cmd2.Parameters.AddWithValue("@detalles_comprador_snc_ventas", TXT_COMPRADOR_GRANO.Text)
        Else
            cmd2.Parameters.AddWithValue("@comprador_snc_ventas", dp_comprador_grano.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@detalles_comprador_snc_ventas", TXT_COMPRADOR_GRANO.Text)
        End If

        cmd2.Parameters.AddWithValue("@ingreso_total_snc_ventas", TXT_INGRESO_TOTAL_VENGRANO.Text)
        cmd2.Parameters.AddWithValue("@QQ_grano_snc_consumo", TXT_QQ_GRANO_CONSUMO.Text)
        cmd2.Parameters.AddWithValue("@QQ_grano_precio_snc_consumo", TXT_PRECIO_GRANO_CONSUMO.Text)
        cmd2.Parameters.AddWithValue("@ingreso_total_snc_consumo", TXT_INGRESO_TOTAL_CONSGRANO.Text)
        cmd2.Parameters.AddWithValue("@estado", "1")
        cmd2.Parameters.AddWithValue("@id2", TxtId2.Text)

        'If TXT_PRECIO_GRANO_CONSUMO.Text <= 0 Then
        '    cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", DBNull.Value)
        'Else
        '    cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", TXT_PRECIO_GRANO_CONSUMO.Text)
        'End If

        cmd2.ExecuteNonQuery()
        conex.Close()

        If Dp_comprador.SelectedItem.Text = "Otro" Then
            Dim valor1 As String = TxtCom_new.Text
            Dim valor2 As String = txt_detalle_comprador.Text
            guardar_comprar(valor1, valor2)
        End If

        Response.Redirect(String.Format("~/pages/Ventas.aspx"))

        llenagrid()

        'divedit.Visible = False
        'divdatos.Visible = True

    End Sub
    Protected Sub guardar_comprar(valor1 As String, valor2 As String)
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim cmd2 As New MySqlCommand()
        Dim Sql As String
        Sql = "INSERT INTO comprador_provi_pash (nombre_comprador, detalle_comprador) values (@nombre_comprador, @detalle_comprador)"

        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@nombre_comprador", valor1)
        cmd2.Parameters.AddWithValue("@detalle_comprador", valor2)

        cmd2.ExecuteNonQuery()
        conex.Close()
    End Sub

    Protected Sub txt_detalle_comprador_TextChanged1(sender As Object, e As EventArgs)
        TXT_COMPRADOR_GRANO.Text = txt_detalle_comprador.Text
    End Sub

    Protected Sub TXT_COMPRADOR_GRANO_TextChanged1(sender As Object, e As EventArgs)
        txt_detalle_comprador.Text = TXT_COMPRADOR_GRANO.Text
    End Sub

    Protected Sub TxtCom_new_TextChanged(sender As Object, e As EventArgs)
        TxtCom_new2.Text = TxtCom_new.Text
    End Sub

    Protected Sub TxtCom_new2_TextChanged(sender As Object, e As EventArgs)
        TxtCom_new.Text = TxtCom_new2.Text
    End Sub
End Class