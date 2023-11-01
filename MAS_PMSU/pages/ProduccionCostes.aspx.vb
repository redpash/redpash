Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class ProduccionCostes
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
                div_nuevo_prod.Visible = False
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
        BAgregar.Visible = False
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

    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
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

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo de edición, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else
                limpiarProduccion()
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ModalProduccion').modal('show'); });", True)
            End If
        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

            Dim chkBox As CheckBox = TryCast(gvrow.FindControl("CheckBox1"), CheckBox)
            'div_nuevo_prod.Visible = True
            'panelmasiso.Visible = False
            If chkBox IsNot Nothing AndAlso chkBox.Checked Then
                ' Casilla marcada, abrir ModalCostos2
                lblmodalcostos.Visible = True
                divmodalcostos.Visible = False
                TxtInsumo.Text = "0"
                TxtManoObra.Text = "0"
                TxtEquiMaqui.Text = "0"
                TxtInscri.Text = "0"
                TxtAcondiSemilla.Text = "0"
                TxtOtros.Text = "0"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ModalCostos').modal('show'); });", True)
            Else
                ' Casilla no marcada, abrir ModalCostos
                lblmodalcostos.Visible = False
                divmodalcostos.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ModalCostos').modal('show'); });", True)
            End If
            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo para eliminar, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else

                limpiarCosto()
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ModalCostos').modal('show'); });", True)
            End If
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

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        'limpiar()
        If TxtCiclo.SelectedItem.Text <> " " Then

            TxtID.Text = ""

            ' Dim fecha2 As Date

            'fecha2 = Now
            'TxtDia.SelectedValue = fecha2.Day
            'TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
            'TxtAno.SelectedValue = fecha2.Year


            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip').modal('show'); });", True)
        Else

            Label3.Text = "Para este ciclo ya ha finalizado el tiempo para agregar registros, por favor si desea agregar el registro realizar la solicitud mediante correo electronico"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)

        End If

    End Sub

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardProd.Click
        Dim fecha As Date
        If Date.TryParse(txt_fecha_sembro.Text, fecha) Then
            fecha.ToString("dd-MM-yyyy")
        End If
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtID.Text <> "") Then
            Sql = " UPDATE bcs_inscripcion_senasa SET
                    AREA_TERRENO_SEMBRADA_MZ = @AREA_TERRENO_SEMBRADA_MZ,
                    AREA_TERRENO_SEMBRADA_HA = @AREA_TERRENO_SEMBRADA_HA,
                    FECHA_SEMBRO = @FECHA_SEMBRO,
                    TUVO_PERDIDA = @TUVO_PERDIDA,
                    AREA_TERRENO_PERDIDA_MZ = @AREA_TERRENO_PERDIDA_MZ,
                    AREA_TERRENO_PERDIDA_HA = @AREA_TERRENO_PERDIDA_HA,
                    FACT_PERD_PLA_ENFER = @FACT_PERD_PLA_ENFER,
                    FACT_PERD_SEQ_LLUV = @FACT_PERD_SEQ_LLUV,
                    FACT_PERD_EXC_LLUV = @FACT_PERD_EXC_LLUV,
                    FACT_PERD_BAJA_GERMI = @FACT_PERD_BAJA_GERMI,
                    FACT_PERD_MAL_MANE_CULTI = @FACT_PERD_MAL_MANE_CULTI,
                    FACT_PERD_OTROS_FACT = @FACT_PERD_OTROS_FACT,
                    QQ_PRODU_CAMPO = @QQ_PRODU_CAMPO,
                    RESULT_CENTRO_PROCES = @RESULT_CENTRO_PROCES,
                    CANTIDAD_QQ_SEMI = @CANTIDAD_QQ_SEMI,
                    CANTIDAD_QQ_GRANO = @CANTIDAD_QQ_GRANO,
                    CANTIDAD_QQ_BASURA = @CANTIDAD_QQ_BASURA
                  WHERE ID = " & TxtID.Text & ""

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@AREA_TERRENO_SEMBRADA_MZ", Convert.ToDouble(TxtAreaSembMz.Text))
            cmd2.Parameters.AddWithValue("@AREA_TERRENO_SEMBRADA_HA", Convert.ToDouble(TxtAreaSembHa.Text))
            cmd2.Parameters.AddWithValue("@FECHA_SEMBRO", fecha)

            cmd2.Parameters.AddWithValue("@TUVO_PERDIDA", DDL_perdidas.SelectedItem.Text)
            If DDL_perdidas.SelectedItem.Text = "Si" Then
                cmd2.Parameters.AddWithValue("@AREA_TERRENO_PERDIDA_MZ", Convert.ToDouble(TxtAreaPerdMz.Text))
                cmd2.Parameters.AddWithValue("@AREA_TERRENO_PERDIDA_HA", Convert.ToDouble(TxtAreaPerdHa.Text))
                cmd2.Parameters.AddWithValue("@FACT_PERD_PLA_ENFER", DropDownList_plaga_enfer.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@FACT_PERD_SEQ_LLUV", DropDownList_sequia_lluvia.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@FACT_PERD_EXC_LLUV", DropDownList_exce_lluvia.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@FACT_PERD_BAJA_GERMI", DropDownList_baja_germi.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@FACT_PERD_MAL_MANE_CULTI", DropDownList_mal_culti.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@FACT_PERD_OTROS_FACT", DropDownList_otros.SelectedItem.Text)
            Else
                cmd2.Parameters.AddWithValue("@AREA_TERRENO_PERDIDA_MZ", Convert.ToDouble("0.00"))
                cmd2.Parameters.AddWithValue("@AREA_TERRENO_PERDIDA_HA", Convert.ToDouble("0.00"))
                cmd2.Parameters.AddWithValue("@FACT_PERD_PLA_ENFER", "No")
                cmd2.Parameters.AddWithValue("@FACT_PERD_SEQ_LLUV", "No")
                cmd2.Parameters.AddWithValue("@FACT_PERD_EXC_LLUV", "No")
                cmd2.Parameters.AddWithValue("@FACT_PERD_BAJA_GERMI", "No")
                cmd2.Parameters.AddWithValue("@FACT_PERD_MAL_MANE_CULTI", "No")
                cmd2.Parameters.AddWithValue("@FACT_PERD_OTROS_FACT", "No")
            End If

            cmd2.Parameters.AddWithValue("@QQ_PRODU_CAMPO", Convert.ToDouble(TxtQQProd.Text))
            cmd2.Parameters.AddWithValue("@RESULT_CENTRO_PROCES", DDL_Procesamiento.SelectedItem.Text)
            If DDL_Procesamiento.SelectedItem.Text = "Si" Then
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_SEMI", Convert.ToDouble(TxtSemilla.Text))
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_GRANO", Convert.ToDouble(TxtGrano.Text))
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_BASURA", Convert.ToDouble(TxtBasura.Text))
            Else
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_SEMI", Convert.ToDouble("0.00"))
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_GRANO", Convert.ToDouble("0.00"))
                cmd2.Parameters.AddWithValue("@CANTIDAD_QQ_BASURA", Convert.ToDouble("0.00"))
            End If
            cmd2.ExecuteNonQuery()
                conex.Close()

            Label1.Text = "La producción se ha agreado exitosamente"



        End If

            llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = "UPDATE bcs_inscripcion_senasa SET Estado=0  WHERE ID=" & TxtID.Text & " "

        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "El registro ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

    Public Sub limpiarProduccion()
        TxtAreaSembMz.Text = ""
        TxtAreaSembHa.Text = ""
        txt_fecha_sembro.Text = ""
        DDL_perdidas.SelectedIndex = 0
        TxtAreaPerdMz.Text = ""
        TxtAreaPerdHa.Text = ""
        DropDownList_plaga_enfer.SelectedIndex = 0
        DropDownList_sequia_lluvia.SelectedIndex = 0
        DropDownList_exce_lluvia.SelectedIndex = 0
        DropDownList_baja_germi.SelectedIndex = 0
        DropDownList_mal_culti.SelectedIndex = 0
        DropDownList_otros.SelectedIndex = 0
        TxtQQProd.Text = ""
        DDL_Procesamiento.SelectedIndex = 0
        TxtSemilla.Text = ""
        TxtGrano.Text = ""
        TxtBasura.Text = ""
    End Sub

    Public Sub limpiarCosto()
        TxtInsumo.Text = ""
        TxtInscri.Text = ""
        TxtManoObra.Text = ""
        TxtOtros.Text = ""
        TxtAcondiSemilla.Text = ""
        TxtEquiMaqui.Text = ""
        TxtTotal.Text = ""
    End Sub
    Protected Sub BtnCosto_Click(sender As Object, e As EventArgs) Handles BtnGuardCost.Click
        Try
            Dim connectionString As String = conn
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "UPDATE bcs_inscripcion_senasa SET 
                COSTOS_INSUMOS = @COSTOS_INSUMOS,
                COSTOS_MANO = @COSTOS_MANO,
                COSTOS_EQUIPO = @COSTOS_EQUIPO,
                COSTOS_OTROS = @COSTOS_OTROS,
                COSTOS_INSCRIPCION = @COSTOS_INSCRIPCION,
                COSTOS_ACONDICIONAMIENTO_SEMILLA = @COSTOS_ACONDICIONAMIENTO_SEMILLA,
                COSTO_TOTAL = @COSTO_TOTAL  WHERE ID=" & TxtID.Text & " "

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@COSTOS_INSUMOS", Convert.ToDouble(TxtInsumo.Text))
                    cmd.Parameters.AddWithValue("@COSTOS_MANO", Convert.ToDouble(TxtManoObra.Text))
                    cmd.Parameters.AddWithValue("@COSTOS_EQUIPO", Convert.ToDouble(TxtEquiMaqui.Text))
                    cmd.Parameters.AddWithValue("@COSTOS_OTROS", Convert.ToDouble(TxtOtros.Text))
                    cmd.Parameters.AddWithValue("@COSTOS_INSCRIPCION", Convert.ToDouble(TxtInscri.Text))
                    cmd.Parameters.AddWithValue("@COSTOS_ACONDICIONAMIENTO_SEMILLA", Convert.ToDouble(TxtAcondiSemilla.Text))
                    cmd.Parameters.AddWithValue("@COSTO_TOTAL", Convert.ToDouble(TxtTotal.Text))
                    cmd.ExecuteNonQuery()
                    Label1.Text = "Los costo se ha almacenado exitosamente"
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub

    Private Function FileUploadToBytes(fileUpload As FileUpload) As Byte()
        Using stream As System.IO.Stream = fileUpload.PostedFile.InputStream
            Dim length As Integer = fileUpload.PostedFile.ContentLength
            Dim bytes As Byte() = New Byte(length - 1) {}
            stream.Read(bytes, 0, length)
            Return bytes
        End Using
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect(String.Format("~/pages/Registro_Portal_Sag.aspx"))

    End Sub

    Protected Sub TxtProduccionQQMZ_TextChanged(sender As Object, e As EventArgs)
        If TxtProduccionQQMZ.Text <> "" Then
            TxtProduccionQQHA.Text = Convert.ToString(Convert.ToDouble(TxtProduccionQQMZ.Text) / 0.7)
        Else
            TxtProduccionQQHA.Text = ""
        End If
    End Sub

    Protected Sub TxtSemillaQQ_TextChanged(sender As Object, e As EventArgs)
        If TxtSemillaQQ.Text <> "" Then
            TxtEstimadoProducir.Text = Convert.ToString(Convert.ToDouble(TxtSemillaQQ.Text) * 0.7)
        Else
            TxtEstimadoProducir.Text = ""
        End If
    End Sub

    Protected Sub TxT_AreaMZ_TextChanged(sender As Object, e As EventArgs)
        If TxT_AreaMZ.Text <> "" Then
            Txt_AreaHa.Text = Convert.ToString(Convert.ToDouble(TxT_AreaMZ.Text) * 0.7)
        Else
            Txt_AreaHa.Text = ""
        End If
    End Sub

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



    Protected Sub DDL_Tipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim vv As String = DDL_Tipo.SelectedItem.Text

        TxtVariedad.Items.Clear()
        If vv = "Frijol" Then
            DDL_Tipo.SelectedIndex = 1
            TxtVariedad.Items.Insert(0, "Amadeus-77")
            TxtVariedad.Items.Insert(1, "Carrizalito")
            TxtVariedad.Items.Insert(2, "Deorho")
            TxtVariedad.Items.Insert(3, "Azabache")
            TxtVariedad.Items.Insert(4, "Paraisito mejorado PM-2")
            TxtVariedad.Items.Insert(5, "Honduras nutritivo")
            TxtVariedad.Items.Insert(6, "Inta Cárdenas")
            TxtVariedad.Items.Insert(7, "Lenca precoz")
            TxtVariedad.Items.Insert(8, "Rojo chortí")
            TxtVariedad.Items.Insert(9, "Tolupan rojo")
            TxtVariedad.Items.Insert(10, "Otra especificar")
            provi = TxtVariedad.SelectedItem.Text
        ElseIf vv = "Maiz" Then
            DDL_Tipo.SelectedIndex = 2
            TxtVariedad.Items.Insert(0, "Dicta Maya")
            TxtVariedad.Items.Insert(1, "Dicta Victoria")
            TxtVariedad.Items.Insert(2, "Otra especificar")
            provi = TxtVariedad.SelectedItem.Text
        Else
            DDL_Tipo.SelectedIndex = 0
        End If
    End Sub

    Protected Sub TxtAreaSembMz_TextChanged(sender As Object, e As EventArgs) Handles TxtAreaSembMz.TextChanged
        If TxtAreaSembMz.Text <> "" Then
            TxtAreaSembHa.Text = Convert.ToString(Convert.ToDouble(TxtAreaSembMz.Text) * 0.7)
        Else
            TxtAreaSembHa.Text = ""
        End If
    End Sub

    Protected Sub TxtAreaPerdMz_TextChanged(sender As Object, e As EventArgs) Handles TxtAreaPerdMz.TextChanged
        If TxtAreaPerdMz.Text <> "" Then
            TxtAreaPerdHa.Text = Convert.ToString(Convert.ToDouble(TxtAreaSembMz.Text) * 0.7)
        Else
            TxtAreaPerdHa.Text = ""
        End If
    End Sub
End Class