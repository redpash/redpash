﻿Imports System.IO
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
                llenagrid()
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

        Dim cadena As String = "ID, Departamento, Productor, Tipo_cultivo, CATEGORIA, CICLO, VARIEDAD, NOMBRE_LOTE_FINCA, AREA_SEMBRADA_MZ, AREA_SEMBRADA_HA, DATE_FORMAT(FECHA_SIEMBRA, '%d-%m-%Y') AS FECHA_SIEMBRA, ESTIMADO_PRO_QQ_MZ, ESTIMADO_PRO_QQ_HA, Habilitado"

        If (DDL_cultivo.SelectedItem.Text = " ") Then
            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Estado = '1' ORDER BY Departamento,Productor,CICLO "
        Else
            If (DDL_Categ.SelectedItem.Text = " ") Then
                Me.SqlDataSource1.SelectCommand = " SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
            Else
                If (TxtCiclo.SelectedItem.Text = " ") Then
                    Me.SqlDataSource1.SelectCommand = " SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                Else
                    If (TxtDepto.SelectedItem.Text = " ") Then
                        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                    Else
                        If (TxtProductor.SelectedItem.Text = " ") Then
                            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Departamento= '" & TxtDepto.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                        Else
                            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Departamento= '" & TxtDepto.SelectedItem.Text & "' AND Productor = '" & TxtProductor.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                        End If
                    End If
                End If
            End If
        End If

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
        llenarcomboProductor()
        llenagrid()
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
        Response.Redirect("ProduccionCostes.aspx")
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
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT COSTOS_INSUMOS, COSTOS_INSCRIPCION, COSTOS_MANO, COSTOS_OTROS, COSTOS_ACONDICIONAMIENTO_SEMILLA, COSTOS_EQUIPO,COSTO_TOTAL, Habilitado, check_costo FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

        End If
    End Sub

    Private Sub llenarcombocompradores()
        Dim StrCombo As String

        'If TxtCiclo.SelectedValue = "Todos" Then
        '    StrCombo = "SELECT 'Todos' as Departamento "
        'Else
        StrCombo = "SELECT ' Todos' as Nombre UNION SELECT DISTINCT Nombre FROM `compradores` "
        'End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Dp_comprador.DataSource = DtCombo
        Dp_comprador.DataValueField = DtCombo.Columns(0).ToString()
        Dp_comprador.DataTextField = DtCombo.Columns(0).ToString()
        Dp_comprador.DataBind()
    End Sub

    Protected Sub VALIDAR_ENTREGAS()
        Dim QQ_SEMILLA_ENTREGADO, QQ_VENTA_SEMILLA, QQ_ORO_PROD, TOTAL_LIMITE As Decimal
        Dim entregado_grano, produccion_consumo, venta_qq_grano, consumo_qq_grano, total_qq_grano As Decimal
        Dim validado, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 As Integer

        'semilla
        QQ_ORO_PROD = Text_QQ_Produccion_ORO.Text
        QQ_SEMILLA_ENTREGADO = TXT_QQ_ORO_ENTRE.Text
        QQ_VENTA_SEMILLA = txt_qq.Text
        QQ_VENTA_CONSUMO = txt_qq_consumo.Text
        TOTAL_LIMITE = QQ_SEMILLA_ENTREGADO + QQ_VENTA_SEMILLA + QQ_VENTA_CONSUMO

        'grano
        produccion_consumo = Text_QQ_Produccion_consumo.Text
        entregado_grano = TXT_QQ_CONSUMO_ENTRE.Text
        venta_qq_grano = TXT_QQ_VENTA_GRANO.Text
        consumo_qq_grano = TXT_QQ_GRANO_CONSUMO.Text

        total_qq_grano = entregado_grano + venta_qq_grano + consumo_qq_grano

        If TOTAL_LIMITE > QQ_ORO_PROD Then

            LB_VALIDACION_QQ_sEMILLA.Text = "Por favor revisar la informacion a  ingresar, el resultado de  QQ a entregar + QQ entregado es:  " & TOTAL_LIMITE & "  y la producción de QQ  semilla es: " & QQ_ORO_PROD & " "
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
        If total_qq_grano > produccion_consumo Then

            lb_validacion_consumo.Text = "Por favor revisar la informacion a  ingresar, el resultado de  QQ a entregar + QQ entregado es:  " & total_qq_grano & "  y la producción de QQ  semilla es: " & produccion_consumo & " "
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

    Protected Sub validar()
        If Dp_comprador.Text = "Otro" And txt_detalle_comprador.Text = "" Then
            Guardar_registro.Visible = False

        Else
            Guardar_registro.Visible = True
        End If
    End Sub

    Protected Sub Dp_comprador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dp_comprador.SelectedIndexChanged
        If Dp_comprador.Text = "Otro" Then
            txt_detalle_comprador.ReadOnly = False
            validar()
        Else
            txt_detalle_comprador.ReadOnly = True
            txt_detalle_comprador.Text = ""
            validar()
        End If
        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub txt_qq_TextChanged(sender As Object, e As EventArgs) Handles txt_qq.TextChanged
        calcular_venta()



        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub txt_precio_TextChanged(sender As Object, e As EventArgs) Handles txt_precio.TextChanged
        calcular_venta()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_detalle_comprador_TextChanged(sender As Object, e As EventArgs) Handles txt_detalle_comprador.TextChanged
        validar()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_qq_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_qq_consumo.TextChanged
        calcular_venta_consumo()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_precio_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_precio_consumo.TextChanged
        calcular_venta_consumo()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub Txtproductor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub Cancelar_edit_Click(sender As Object, e As EventArgs) Handles Cancelar_edit.Click
        Response.Redirect(String.Format("~/pages/msu_entregas_consolidado.aspx"))

    End Sub

    Protected Sub SI_editar_Click(sender As Object, e As EventArgs) Handles SI_editar.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()
        Sql = "UPDATE  `bcs_entregas_2022` set QQ_entregado=@QQ_entregado, Precio=@Precio , Total_entrega=@Total_entrega, comprador=@comprador, otro_comprador=@otro_comprador, QQ_entregado_consumo=@QQ_entregado_consumo,  Precio_consumo=@Precio_consumo,  Total_entrega_consumo=@Total_entrega_consumo  WHERE COD_BCS='" + Text_codigo_bcs.Text + "' AND Ciclo='" + Text_ciclo.Text + "' AND  variedad='" + Text_variedad.Text + "'  "

        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@QQ_entregado", txt_qq.Text)
        cmd2.Parameters.AddWithValue("@Precio", txt_precio.Text)
        cmd2.Parameters.AddWithValue("@Total_entrega", txt_total_venta.Text)
        cmd2.Parameters.AddWithValue("@comprador", Dp_comprador.Text)
        cmd2.Parameters.AddWithValue("@otro_comprador", txt_detalle_comprador.Text)
        cmd2.Parameters.AddWithValue("@QQ_entregado_consumo", txt_qq_consumo.Text)
        cmd2.Parameters.AddWithValue("@Precio_consumo", txt_precio_consumo.Text)
        cmd2.Parameters.AddWithValue("@Total_entrega_consumo", txt_ingreso_consumo.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()

        llenagrid()
    End Sub

    Protected Sub TXT_QQ_VENTA_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_VENTA_GRANO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_grano()
    End Sub

    Protected Sub TXT_QQ_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_GRANO_CONSUMO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_consumo_grano()
    End Sub

    Protected Sub TXT_PRECIO_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_grano()
    End Sub

    Protected Sub dp_comprador_grano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dp_comprador_grano.SelectedIndexChanged


        If dp_comprador_grano.Text = "Otro" Then
            TXT_COMPRADOR_GRANO.ReadOnly = False
            validar()
        Else
            TXT_COMPRADOR_GRANO.ReadOnly = True
            TXT_COMPRADOR_GRANO.Text = ""
            validar()
        End If


        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub TXT_COMPRADOR_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_COMPRADOR_GRANO.TextChanged
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub TXT_PRECIO_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO_CONSUMO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_consumo_grano()
    End Sub

    Protected Sub btn_si_Click(sender As Object, e As EventArgs) Handles btn_si.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        Sql = "INSERT INTO  bcs_entregas_new (Observacion, Usuario, ID2, COD_BCS, Ciclo, Variedad, Categoria, Tipo_venta, QQ_SEMILLA_VENTA, PRECIO_QQ_SEMILLA_VENTA, COMPRADOR_SEMILLA, DETALLE_COMPRADOR_SEMILLA, QQ_SEMILLA_CONSUMO, PRECIO_QQ_SEMILLA_CONSUMO, QQ_GRANO_VENTA, PRECIO_QQ_GRANO_VENTA, COMPRADOR_GRANO, DETALLE_COMPRADOR_GRANO, QQ_GRANO_CONSUMO, PRECIO_QQ_GRANO_CONSUMO) values(@Observacion,@Usuario, @ID2, @COD_BCS, @Ciclo, @Variedad, @Categoria, @Tipo_venta, @QQ_SEMILLA_VENTA, @PRECIO_QQ_SEMILLA_VENTA, @COMPRADOR_SEMILLA, @DETALLE_COMPRADOR_SEMILLA, @QQ_SEMILLA_CONSUMO, @PRECIO_QQ_SEMILLA_CONSUMO, @QQ_GRANO_VENTA, @PRECIO_QQ_GRANO_VENTA, @COMPRADOR_GRANO, @DETALLE_COMPRADOR_GRANO, @QQ_GRANO_CONSUMO, @PRECIO_QQ_GRANO_CONSUMO) "

        cmd2.Connection = conex
        cmd2.CommandText = Sql
        cmd2.Parameters.AddWithValue("@Observacion", txt_observacion.Text)
        cmd2.Parameters.AddWithValue("@Usuario", User.Identity.Name)
        'cmd2.Parameters.AddWithValue("@ID2", TxtID.Text)
        cmd2.Parameters.AddWithValue("@COD_BCS", Text_codigo_bcs.Text)
        cmd2.Parameters.AddWithValue("@Ciclo", Text_ciclo.Text)
        cmd2.Parameters.AddWithValue("@Variedad", Text_variedad.Text)
        cmd2.Parameters.AddWithValue("@Categoria", Text_categoria.Text)
        cmd2.Parameters.AddWithValue("@Tipo_venta", "Modulo consolidado")

        If txt_qq.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_VENTA", txt_qq.Text)
        End If

        If txt_precio.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_VENTA", txt_precio.Text)
        End If

        If Dp_comprador.Text = " Todos" Then
            cmd2.Parameters.AddWithValue("@COMPRADOR_SEMILLA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@COMPRADOR_SEMILLA", Dp_comprador.SelectedValue)
        End If

        If txt_detalle_comprador.Text = "" Then
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_SEMILLA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_SEMILLA", txt_detalle_comprador.Text)
        End If

        If txt_qq_consumo.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_CONSUMO", txt_qq_consumo.Text)
        End If

        If txt_qq_consumo.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_CONSUMO", txt_precio_consumo.Text)
        End If

        If TXT_QQ_VENTA_GRANO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_GRANO_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_GRANO_VENTA", TXT_QQ_VENTA_GRANO.Text)
        End If

        If TXT_QQ_VENTA_GRANO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_VENTA", TXT_PRECIO_GRANO.Text)
        End If

        If dp_comprador_grano.Text = " Todos" Then
            cmd2.Parameters.AddWithValue("@COMPRADOR_GRANO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@COMPRADOR_GRANO", dp_comprador_grano.SelectedValue)
        End If

        If TXT_COMPRADOR_GRANO.Text = "" Then
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_GRANO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_GRANO", TXT_COMPRADOR_GRANO.Text)
        End If

        If TXT_QQ_GRANO_CONSUMO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_GRANO_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_GRANO_CONSUMO", TXT_QQ_GRANO_CONSUMO.Text)
        End If

        If TXT_PRECIO_GRANO_CONSUMO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", TXT_PRECIO_GRANO_CONSUMO.Text)
        End If

        cmd2.ExecuteNonQuery()
        conex.Close()

        Response.Redirect(String.Format("~/pages/msu_entregas_consolidado.aspx"))

        llenagrid()

        'divedit.Visible = False
        'divdatos.Visible = True
    End Sub
End Class