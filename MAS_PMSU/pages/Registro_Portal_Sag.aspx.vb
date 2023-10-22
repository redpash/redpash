Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class Registro_Portal_Sag
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
            Dim StrCombo As String = "SELECT DISTINCT nombre_productor FROM solicitud_inscripcion_delotes WHERE departamento = @nombre ORDER BY nombre_productor ASC"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", TxtDepto.SelectedItem.Text)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)
            TxtProductor.DataSource = DtCombo
            TxtProductor.DataValueField = "nombre_productor"
            TxtProductor.DataTextField = "nombre_productor"
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

        If TxtCiclo.SelectedItem.Text = " " Then
            Me.SqlDataSource1.SelectCommand = "SELECT * FROM bcs_inscripcion_senasa where Estado = '1' ORDER BY Departamento,Productor,CICLO "
        Else

            If (TxtDepto.SelectedItem.Text = " ") Then
                Me.SqlDataSource1.SelectCommand = " SELECT * FROM bcs_inscripcion_senasa where CICLO='" & TxtCiclo.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
            Else

                If (TxtProductor.SelectedItem.Text = " ") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT * FROM bcs_inscripcion_senasa where CICLO='" & TxtCiclo.SelectedItem.Text & "' AND Departamento='" & TxtDepto.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                Else

                    BAgregar.Visible = True

                    Me.SqlDataSource1.SelectCommand = "SELECT * FROM bcs_inscripcion_senasa where CICLO='" & TxtCiclo.SelectedItem.Text & "' AND Departamento='" & TxtDepto.SelectedItem.Text & "' AND Productor = '" & TxtProductor.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "

                End If
            End If

        End If

        GridDatos.DataBind()

    End Sub

    Protected Sub TxtCiclo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCiclo.SelectedIndexChanged
        '    'llenarcomboDepto()
        '    'llenarcomboProductor()
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

            DDL_Tipo.SelectedIndex = 0

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()
            obtener_numero_lote(HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString)

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo de edición, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else

                TxtNom.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString
                TxtCicloD.Text = dt.Rows(0)("CICLO").ToString()
                Dim vv As String = dt.Rows(0)("Tipo_cultivo").ToString()

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
                Else
                    DDL_Tipo.SelectedIndex = 2
                    TxtVariedad.Items.Insert(0, "Dicta Maya")
                    TxtVariedad.Items.Insert(1, "Dicta Victoria")
                    TxtVariedad.Items.Insert(2, "Otra especificar")
                End If

                TxtVariedad.Text = dt.Rows(0)("VARIEDAD").ToString()
                TxtCategoria.Text = dt.Rows(0)("CATEGORIA").ToString()

                TxT_AreaMZ.Text = dt.Rows(0)("AREA_SEMBRADA_MZ").ToString()
                Txt_AreaHa.Text = dt.Rows(0)("AREA_SEMBRADA_HA").ToString()
                TxtFechaSiembra.Text = DirectCast(dt.Rows(0)("FECHA_SIEMBRA"), DateTime).ToString("yyyy-MM-dd")

                TxtRegistradaQQ.Text = dt.Rows(0)("REQUERIEMIENTO_REGISTRADA_QQ").ToString()
                TxtCantLotes.Text = dt.Rows(0)("CANTIDAD_LOTES_SEMBRAR").ToString()
                Dim v As String = dt.Rows(0)("NOMBRE_LOTE_FINCA").ToString()
                Dim v2 As New ListItem(v, v)
                DDL_Nlote.Items.Insert(0, v2)
                TxtProduccionQQMZ.Text = dt.Rows(0)("ESTIMADO_PRO_QQ_MZ").ToString()
                TxtProduccionQQHA.Text = dt.Rows(0)("ESTIMADO_PRO_QQ_HA").ToString()
                TxtSemillaQQ.Text = dt.Rows(0)("ESTIMADO_PRODUCIR_QQ").ToString()
                TxtEstimadoProducir.Text = dt.Rows(0)("ESTIMADO_PRODUCIR_QQHA").ToString()


                'fecha2 = dt.Rows(0)("FECHA_SIEMBRA").ToString()
                'TxtDia.SelectedValue = fecha2.Day
                'TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                'TxtAno.SelectedValue = fecha2.Year



                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip').modal('show'); });", True)
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


            div_nuevo_prod.Visible = True
            panelmasiso.Visible = False

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo para eliminar, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else


                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip1').modal('show'); });", True)
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

    Private Sub exportar()

        Dim query As String = ""

        If TxtCiclo.SelectedValue = "Todos" Then
            query = "SELECT * FROM `bcs_inscripcion_senasa` where Estado = '1' ORDER BY Departamento,Productor,CICLO "
        Else
            If (TxtDepto.SelectedValue = " Todos") Then
                query = "SELECT * FROM `bcs_inscripcion_senasa` WHERE CICLO='" & TxtCiclo.SelectedValue & "'  AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
            Else
                query = "SELECT * FROM `bcs_inscripcion_senasa` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
            End If
        End If

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
                            Response.AddHeader("content-disposition", "attachment;filename=PLAN PRODUCCIÓN DE SEMILLA DE FRIJOL  " & Today & ".xlsx")
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

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub

    Private Sub llenarVAIDAD_CICLO()

    End Sub

    Protected Sub obtener_numero_lote(cadena As String)

        Dim StrCombo As String = "SELECT nombre_lote FROM solicitud_inscripcion_delotes WHERE nombre_productor = '" & cadena & "'"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        DDL_Nlote.DataSource = DtCombo
        DDL_Nlote.DataValueField = "nombre_lote"
        DDL_Nlote.DataTextField = "nombre_lote"
        DDL_Nlote.DataBind()
        Dim newitem As New ListItem(" ", " ")
        DDL_Nlote.Items.Insert(0, newitem)
    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        If TxtCiclo.SelectedItem.Text <> " " Then

            TxtID.Text = ""

            ' Dim fecha2 As Date

            TxtNom.Text = TxtProductor.SelectedItem.Text
            TxtCicloD.Text = TxtCiclo.SelectedItem.Text
            TxtVariedad.SelectedIndex = 0
            TxtCategoria.SelectedIndex = 0
            obtener_numero_lote(TxtProductor.SelectedItem.Text)

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

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim fecha As Date
        If Date.TryParse(TxtFechaSiembra.Text, fecha) Then
            fecha.ToString("dd-MM-yyyy")
        End If
        Dim conex As New MySqlConnection(conn)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtID.Text = "") Then
            Sql = "INSERT INTO bcs_inscripcion_senasa (Productor, CICLO, Departamento, VARIEDAD, CATEGORIA, AREA_SEMBRADA_MZ, AREA_SEMBRADA_HA, FECHA_SIEMBRA, REQUERIEMIENTO_REGISTRADA_QQ, CANTIDAD_LOTES_SEMBRAR, NOMBRE_LOTE_FINCA, ESTIMADO_PRO_QQ_MZ, ESTIMADO_PRO_QQ_HA, ESTIMADO_PRODUCIR_QQ, ESTIMADO_PRODUCIR_QQHA, Estado, Tipo_cultivo)
            VALUES(@Productor, @CICLO, @Departamento, @VARIEDAD, @CATEGORIA, @AREA_SEMBRADA_MZ, @AREA_SEMBRADA_HA, @FECHA_SIEMBRA, @REQUERIEMIENTO_REGISTRADA_QQ, @CANTIDAD_LOTES_SEMBRAR, @NOMBRE_LOTE_FINCA, @ESTIMADO_PRO_QQ_MZ, @ESTIMADO_PRO_QQ_HA, @ESTIMADO_PRODUCIR_QQ, @ESTIMADO_PRODUCIR_QQHA, @Estado, @Tipo_cultivo)"

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@Productor", TxtProductor.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@CICLO", TxtCiclo.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Departamento", TxtDepto.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Tipo_cultivo", DDL_Tipo.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@VARIEDAD", TxtVariedad.SelectedItem.Text)    'REVISADO
            cmd2.Parameters.AddWithValue("@CATEGORIA", TxtCategoria.SelectedItem.Text)

            cmd2.Parameters.AddWithValue("@AREA_SEMBRADA_MZ", Convert.ToDouble(TxT_AreaMZ.Text))
            cmd2.Parameters.AddWithValue("@AREA_SEMBRADA_HA", Convert.ToDouble(Txt_AreaHa.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
            cmd2.Parameters.AddWithValue("@FECHA_SIEMBRA", fecha)


            cmd2.Parameters.AddWithValue("@REQUERIEMIENTO_REGISTRADA_QQ", Convert.ToDouble(TxtRegistradaQQ.Text))
            cmd2.Parameters.AddWithValue("@CANTIDAD_LOTES_SEMBRAR", Convert.ToInt64(TxtCantLotes.Text))
            cmd2.Parameters.AddWithValue("@NOMBRE_LOTE_FINCA", DDL_Nlote.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_MZ", Convert.ToDouble(TxtProduccionQQMZ.Text))
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_HA", Convert.ToDouble(TxtProduccionQQHA.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQ", Convert.ToDouble(TxtSemillaQQ.Text))
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQHA", Convert.ToDouble(TxtEstimadoProducir.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
            cmd2.Parameters.AddWithValue("@Estado", "1")
            'cmd2.Parameters.AddWithValue("@FECHA_SEMBRARA", Convert.ToDateTime(fecha))

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "La inscripcion del lote ha sido agregada"
        Else

            Try
                Sql = "UPDATE bcs_inscripcion_senasa SET
                    Productor = @Productor,
                    CICLO = @CICLO,
                    VARIEDAD = @VARIEDAD,
                    CATEGORIA = @CATEGORIA,
                    AREA_SEMBRADA_MZ = @AREA_SEMBRADA_MZ,
                    AREA_SEMBRADA_HA = @AREA_SEMBRADA_HA,
                    FECHA_SIEMBRA = @FECHA_SIEMBRA,
                    REQUERIEMIENTO_REGISTRADA_QQ = @REQUERIEMIENTO_REGISTRADA_QQ,
                    CANTIDAD_LOTES_SEMBRAR = @CANTIDAD_LOTES_SEMBRAR,
                    NOMBRE_LOTE_FINCA = @NOMBRE_LOTE_FINCA,
                    ESTIMADO_PRO_QQ_MZ = @ESTIMADO_PRO_QQ_MZ,
                    ESTIMADO_PRO_QQ_HA = @ESTIMADO_PRO_QQ_HA,
                    ESTIMADO_PRODUCIR_QQ = @ESTIMADO_PRODUCIR_QQ,
                    ESTIMADO_PRODUCIR_QQHA = @ESTIMADO_PRODUCIR_QQHA,
                    Estado = @Estado,
                    Tipo_cultivo = @Tipo_cultivo
                WHERE ID=" & TxtID.Text & " "
                cmd2.Connection = conex
                cmd2.CommandText = Sql

                cmd2.Parameters.AddWithValue("@Productor", TxtNom.Text)
                cmd2.Parameters.AddWithValue("@CICLO", TxtCicloD.Text)
                cmd2.Parameters.AddWithValue("@Tipo_cultivo", DDL_Tipo.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@VARIEDAD", TxtVariedad.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@CATEGORIA", TxtCategoria.SelectedItem.Text)

                cmd2.Parameters.AddWithValue("@AREA_SEMBRADA_MZ", Convert.ToDouble(TxT_AreaMZ.Text))
                cmd2.Parameters.AddWithValue("@AREA_SEMBRADA_HA", Convert.ToDouble(Txt_AreaHa.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
                cmd2.Parameters.AddWithValue("@FECHA_SIEMBRA", fecha)


                cmd2.Parameters.AddWithValue("@REQUERIEMIENTO_REGISTRADA_QQ", Convert.ToDouble(TxtRegistradaQQ.Text))
                cmd2.Parameters.AddWithValue("@CANTIDAD_LOTES_SEMBRAR", Convert.ToInt64(TxtCantLotes.Text))
                cmd2.Parameters.AddWithValue("@NOMBRE_LOTE_FINCA", DDL_Nlote.SelectedItem.Text)
                cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_MZ", Convert.ToDouble(TxtProduccionQQMZ.Text))
                cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_HA", Convert.ToDouble(TxtProduccionQQHA.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
                cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQ", Convert.ToDouble(TxtSemillaQQ.Text))
                cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQHA", Convert.ToDouble(TxtEstimadoProducir.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
                cmd2.Parameters.AddWithValue("@Estado", "1")
                cmd2.ExecuteNonQuery()
                conex.Close()


                Label1.Text = "La inscripcion del lote ha sido actualizada"
            Catch ex As Exception
                MsgBox(ex)
            End Try
            limpiar()



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

    Public Sub limpiar()
        TxT_AreaMZ.Text = ""
        TxtRegistradaQQ.Text = ""
        TxtCantLotes.Text = ""
        'txtNombreFinca.Text = ""
        TxtProduccionQQMZ.Text = ""
        TxtSemillaQQ.Text = ""

    End Sub
    Protected Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        Try
            Dim connectionString As String = conn
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Leer archivos como bytes

                Dim bytesFicha As Byte() = FileUploadToBytes(FileUploadFicha)
                Dim bytesPagoTGR As Byte() = FileUploadToBytes(FileUploadPagoTGR)
                Dim bytesEtiqueta As Byte() = FileUploadToBytes(FileUploadEtiquetaSemilla)



                ' Actualizar bytes en la base de datos
                Dim query As String = "UPDATE bcs_inscripcion_senasa SET TIPO_SEMILLA= @TIPO_SEMILLA, IMAGEN_FICHA=@ImagenFicha, IMAGEN_PAGO_TGR=@ImagenPagoTGR, IMAGEN_ETIQUETA_SEMILLA=@ImagenEtiquetaSemilla WHERE ID=" & TxtID.Text & " "
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@TIPO_SEMILLA", CmbTipoSemilla.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@ImagenFicha", bytesFicha)
                    cmd.Parameters.AddWithValue("@ImagenPagoTGR", bytesPagoTGR)
                    cmd.Parameters.AddWithValue("@ImagenEtiquetaSemilla", bytesEtiqueta)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Response.Redirect(String.Format("~/pages/Registro_Portal_Sag.aspx"))
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
        'nombre de dataset
        Dim ds As New DataSet1
        Dim Str As String = "SELECT * FROM vista_inscripcion_senasa_lote WHERE Productor = 'Jairon Matute Reyes' AND CICLO = '2023-Ciclo A'"
        Dim adap As New MySqlDataAdapter(Str, conn)
        'adap.SelectCommand.Parameters.AddWithValue("@valor", TxtLote.Text)
        Dim dt As New DataTable


        'nombre de la vista del data set

        adap.Fill(ds, "vista_inscripcion_senasa_lote")




        Dim nombre As String

        nombre = "Solicitud Inscripcion de Lote o Campo _" + Today

        rptdocument.Load(Server.MapPath("~/pages/CrystalReport3.rpt"))

        rptdocument.SetDataSource(ds)
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
End Class