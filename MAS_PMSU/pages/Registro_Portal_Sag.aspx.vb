Imports System.Data.SqlClient
Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class Registro_Portal_Sag
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim nombreproductor As String
    Dim validarflag As Integer
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
                verificar()
                div_nuevo_prod.Visible = False
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
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub

    Private Sub exportar()

        Dim query As String = ""
        Dim cadena As String = "Productor, CICLO, Departamento, VARIEDAD, CATEGORIA, AREA_SEMBRADA_MZ, AREA_SEMBRADA_HA, FECHA_SIEMBRA, REQUERIEMIENTO_REGISTRADA_QQ, CANTIDAD_LOTES_SEMBRAR, NOMBRE_LOTE_FINCA, ESTIMADO_PRO_QQ_MZ, ESTIMADO_PRO_QQ_HA, ESTIMADO_PRODUCIR_QQ, ESTIMADO_PRODUCIR_QQHA, Estado, Tipo_cultivo, Habilitado"
        Dim c1 As String = ""
        Dim c3 As String = ""
        Dim c4 As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND Productor = '" & TxtProductor.SelectedItem.Text & "' "
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

        query = "SELECT " & cadena & " FROM bcs_inscripcion_senasa WHERE Estado = '1' " & c1 & c3 & c4 & " ORDER BY Departamento,Productor,CICLO"

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
                            Response.AddHeader("content-disposition", "attachment;filename=PLAN PRODUCCIÓN DE SEMILLA DE FRIJOL  " & Today & " " & TxtProductor.SelectedItem.Text & " " & TxtCiclo.SelectedItem.Text & ".xlsx")
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

    Sub llenagrid()
        BAgregar.Visible = False
        'import.Visible = False

        Dim cadena As String = "*"
        Dim c1 As String = ""
        Dim c3 As String = ""
        Dim c4 As String = ""

        If (TxtProductor.SelectedItem.Text = " ") Then
            c1 = " "
        Else
            c1 = "AND Productor = '" & TxtProductor.SelectedItem.Text & "' "
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

        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa WHERE Estado = '1' " & c1 & c3 & c4 & " ORDER BY Departamento,Productor,CICLO"


        If TxtCiclo.SelectedItem.Text = " " Then
            Button2.Visible = False
        Else

            If (TxtDepto.SelectedItem.Text = " ") Then
                Button2.Visible = False
            Else

                If (TxtProductor.SelectedItem.Text = " ") Then
                    Button2.Visible = False
                Else

                    BAgregar.Visible = False
                    Button2.Visible = True

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

    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()

    End Sub

    Protected Sub verificar()
        If DDL_Nlote.SelectedItem IsNot Nothing Then
            If Not String.IsNullOrEmpty(DDL_Nlote.SelectedItem.Text) Then
                lbDDL_Nlote.Text = ""
                validarflag += 1

            Else
                lbDDL_Nlote.Text = "*"
                validarflag = 0
            End If
        End If
        If (TxT_AreaMZ.Text = "") Then
            lbAreaMZ.Text = "*"
            validarflag = 0
        Else
            lbAreaMZ.Text = ""
            validarflag += 1
        End If

        If (TxtRegistradaQQ.Text = "") Then
            lbRegistradaQQ.Text = "*"
            validarflag = 0
        Else
            lbRegistradaQQ.Text = ""
            validarflag += 1
        End If

        If (TxtProduccionQQMZ.Text = "") Then
            lbProduccionQQMZ.Text = "*"
            validarflag = 0
        Else
            lbProduccionQQMZ.Text = ""
            validarflag += 1
        End If

        If (TxtSemillaQQ.Text = "") Then
            lbSemillaQQ.Text = "*"
            validarflag = 0
        Else
            lbSemillaQQ.Text = ""
            validarflag += 1
        End If

    End Sub

    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then
            limpiar()
            verificar()


            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

            Txtnombreproductor.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString

            DDL_Tipo.SelectedIndex = 0

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo de edición, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else
                limpiar()
                TxtNom.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString
                TxtCicloD.Text = dt.Rows(0)("CICLO").ToString()
                obtener_numero_lote(HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString)
                Dim vv As String = dt.Rows(0)("Tipo_cultivo").ToString()

                TxtVariedad.Items.Clear()
                If vv = "Frijol" Then
                    DDL_Tipo.SelectedIndex = 1
                    TxtVariedad.Items.Insert(0, "")
                    TxtVariedad.Items.Insert(1, "Amadeus-77")
                    TxtVariedad.Items.Insert(2, "Carrizalito")
                    TxtVariedad.Items.Insert(3, "Deorho")
                    TxtVariedad.Items.Insert(4, "Azabache")
                    TxtVariedad.Items.Insert(5, "Paraisito mejorado PM-2")
                    TxtVariedad.Items.Insert(6, "Honduras nutritivo")
                    TxtVariedad.Items.Insert(7, "Inta Cárdenas")
                    TxtVariedad.Items.Insert(8, "Lenca precoz")
                    TxtVariedad.Items.Insert(9, "Rojo chortí")
                    TxtVariedad.Items.Insert(10, "Tolupan rojo")
                Else
                    DDL_Tipo.SelectedIndex = 2
                    TxtVariedad.Items.Insert(0, "")
                    TxtVariedad.Items.Insert(1, "Dicta Maya")
                    TxtVariedad.Items.Insert(2, "Dicta Victoria")
                    TxtVariedad.Items.Insert(3, "Otra especificar")
                End If

                TxtVariedad.Text = dt.Rows(0)("VARIEDAD").ToString()
                TxtCategoria.Text = dt.Rows(0)("CATEGORIA").ToString()

                TxT_AreaMZ.Text = dt.Rows(0)("AREA_SEMBRADA_MZ").ToString()
                Txt_AreaHa.Text = dt.Rows(0)("AREA_SEMBRADA_HA").ToString()
                TxtFechaSiembra.Text = DirectCast(dt.Rows(0)("FECHA_SIEMBRA"), DateTime).ToString("yyyy-MM-dd")

                TxtRegistradaQQ.Text = dt.Rows(0)("REQUERIEMIENTO_REGISTRADA_QQ").ToString()
                TxtCantLotes.Text = dt.Rows(0)("CANTIDAD_LOTES_SEMBRAR").ToString()
                SeleccionarItemEnDropDownList(DDL_Nlote, dt.Rows(0)("NOMBRE_LOTE_FINCA").ToString())
                TxtProduccionQQMZ.Text = dt.Rows(0)("ESTIMADO_PRO_QQ_MZ").ToString()
                TxtProduccionQQHA.Text = dt.Rows(0)("ESTIMADO_PRO_QQ_HA").ToString()
                TxtSemillaQQ.Text = dt.Rows(0)("ESTIMADO_PRODUCIR_QQ").ToString()
                TxtEstimadoProducir.Text = dt.Rows(0)("ESTIMADO_PRODUCIR_QQHA").ToString()

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip').modal('show'); });", True)
                verificar()
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
    Protected Sub GridDatos_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Obtén los datos de la fila actual
            Dim estimadoProduccion As String = DataBinder.Eval(e.Row.DataItem, "ESTIMADO_PRODUCIR_QQ").ToString()
            Dim tipoSemilla As String = DataBinder.Eval(e.Row.DataItem, "TIPO_SEMILLA").ToString()

            ' Encuentra los botones en la fila por índice
            Dim btnEditar As Button = DirectCast(e.Row.Cells(6).Controls(0), Button) ' Ajusta el índice según la posición de tu botón en la fila
            Dim btnEliminar As Button = DirectCast(e.Row.Cells(7).Controls(0), Button) ' Ajusta el índice según la posición de tu botón en la fila

            ' Modifica el texto y el color de los botones según la lógica que desees
            If Not String.IsNullOrEmpty(estimadoProduccion) Then
                btnEditar.Text = "Editar Plan"
                btnEditar.CssClass = "btn btn-info"
                btnEditar.ControlStyle.CssClass = "btn btn-info"
            Else
                btnEditar.Text = "Agregar Plan"
                btnEditar.CssClass = "btn btn-success"
                btnEditar.ControlStyle.CssClass = "btn btn-success"
            End If

            If Not String.IsNullOrEmpty(tipoSemilla) Then
                btnEliminar.Text = "Editar Archivos"
                btnEliminar.CssClass = "btn btn-info"
                btnEliminar.ControlStyle.CssClass = "btn btn-info"
            Else
                btnEliminar.Text = "Agregar Archivos"
                btnEliminar.CssClass = "btn btn-success"
                btnEliminar.ControlStyle.CssClass = "btn btn-success"
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
    Protected Function SeleccionarItemEnDropDownList(ByVal Prodname As DropDownList, ByVal DtCombo As String)
        For Each item As ListItem In Prodname.Items
            If item.Text = DtCombo Then
                Prodname.SelectedValue = item.Value
                Return True ' Se encontró una coincidencia, devolver verdadero
            End If
        Next
        ' No se encontró ninguna coincidencia
        Return 0
    End Function
    Protected Sub obtener_numero_lote(cadena As String)
        DDL_Nlote.Items.Clear()
        Dim StrCombo As String = "SELECT nombre_lote FROM solicitud_inscripcion_delotes WHERE nombre_productor = '" & cadena & "'"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        If DtCombo.Rows.Count > 0 Then
            DDL_Nlote.DataSource = DtCombo
            DDL_Nlote.DataValueField = "nombre_lote"
            DDL_Nlote.DataTextField = "nombre_lote"
            DDL_Nlote.DataBind()
            Dim newitem As New ListItem("", "")
            DDL_Nlote.Items.Insert(0, newitem)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal3').modal('show'); });", True)
        End If

    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        limpiar()
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
        validarflag = 0
        verificar()

        If validarflag = 5 Then
            Dim fecha As Date
            If Date.TryParse(TxtFechaSiembra.Text, fecha) Then
                fecha.ToString("dd-MM-yyyy")
            End If
            Dim conex As New MySqlConnection(conn)

            conex.Open()
            Dim Sql As String
            Dim cmd2 As New MySqlCommand()

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
            cmd2.Parameters.AddWithValue("@CANTIDAD_LOTES_SEMBRAR", 1)
            cmd2.Parameters.AddWithValue("@NOMBRE_LOTE_FINCA", DDL_Nlote.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_MZ", Convert.ToDouble(TxtProduccionQQMZ.Text))
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRO_QQ_HA", Convert.ToDouble(TxtProduccionQQHA.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQ", Convert.ToDouble(TxtSemillaQQ.Text))
            cmd2.Parameters.AddWithValue("@ESTIMADO_PRODUCIR_QQHA", Convert.ToDouble(TxtEstimadoProducir.Text)) 'CAMBIAR LA VARIABLE POR LA QUE ES
            cmd2.Parameters.AddWithValue("@Estado", "1")

            cmd2.ExecuteNonQuery()
            conex.Close()


            Label1.Text = "La inscripcion del lote ha sido actualizada"
            limpiar()
            llenagrid()

            BConfirm.Visible = True
            BBorrarsi.Visible = False
            BBorrarno.Visible = False

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        Else
            Label1.Text = "Por favor llenar todos los campos"
            BConfirm.Visible = True
            BBorrarsi.Visible = False
            BBorrarno.Visible = False

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If



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
        TxtNom.Text = ""
        TxtCicloD.Text = ""
        DDL_Tipo.SelectedIndex = 0
        Dim vv As String = DDL_Tipo.SelectedItem.Text

        TxtVariedad.Items.Clear()
        If vv = "Frijol" Then
            DDL_Tipo.SelectedIndex = 1
            TxtVariedad.Items.Insert(0, "")
            TxtVariedad.Items.Insert(1, "Amadeus-77")
            TxtVariedad.Items.Insert(2, "Carrizalito")
            TxtVariedad.Items.Insert(3, "Deorho")
            TxtVariedad.Items.Insert(4, "Azabache")
            TxtVariedad.Items.Insert(5, "Paraisito mejorado PM-2")
            TxtVariedad.Items.Insert(6, "Honduras nutritivo")
            TxtVariedad.Items.Insert(7, "Inta Cárdenas")
            TxtVariedad.Items.Insert(8, "Lenca precoz")
            TxtVariedad.Items.Insert(9, "Rojo chortí")
            TxtVariedad.Items.Insert(10, "Tolupan rojo")
            TxtVariedad.Items.Insert(11, "Otra especificar")
        ElseIf vv = "Maiz" Then
            DDL_Tipo.SelectedIndex = 2
            TxtVariedad.Items.Insert(0, "")
            TxtVariedad.Items.Insert(1, "Dicta Maya")
            TxtVariedad.Items.Insert(2, "Dicta Victoria")
            TxtVariedad.Items.Insert(3, "Otra especificar")
        Else
            TxtVariedad.Items.Insert(0, "")
        End If
        TxtCategoria.SelectedIndex = 0

        TxT_AreaMZ.Text = ""
        Txt_AreaHa.Text = ""
        TxtFechaSiembra.Text = ""

        TxtRegistradaQQ.Text = ""
        TxtCantLotes.Text = "1"
        DDL_Nlote.Items.Clear()
        TxtProduccionQQMZ.Text = ""
        TxtProduccionQQHA.Text = ""
        TxtSemillaQQ.Text = ""
        TxtEstimadoProducir.Text = ""

    End Sub

    Protected Sub limpiarFiltros(sender As Object, e As EventArgs)
        Response.Redirect("Registro_Portal_Sag.aspx")
    End Sub

    Protected Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click

        If ValidarFormulario() Then

            Dim connectionString As String = conn
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
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

            Label12.Visible = False
            Label13.Visible = True
            BtnUpload.Visible = False
        Else
            Label12.Visible = True
            Label13.Visible = False
            BtnUpload.Visible = True
        End If

    End Sub

    Protected Function ValidarFormulario() As Boolean
        If String.IsNullOrEmpty(CmbTipoSemilla.SelectedItem.Text) Then
            Return False
        End If
        If Not FileUploadFicha.HasFile Then
            Return False
        End If
        If Not FileUploadPagoTGR.HasFile Then
            Return False
        End If
        If Not FileUploadEtiquetaSemilla.HasFile Then
            Return False
        End If
        Return True
    End Function

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
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Response.Redirect(String.Format("~/pages/SolicitudInscripcionDeLotes.aspx?id=" & Txtnombreproductor.Text))
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Response.Redirect(String.Format("~/pages/Registro_Portal_Sag.aspx"))

    End Sub

    Protected Sub TxtProduccionQQMZ_TextChanged(sender As Object, e As EventArgs)
        If TxtProduccionQQMZ.Text <> "" Then
            TxtProduccionQQHA.Text = Convert.ToString(Convert.ToDouble(TxtProduccionQQMZ.Text) * 0.7)
        Else
            TxtProduccionQQHA.Text = ""
        End If
        verificar()
    End Sub

    Protected Sub TxtSemillaQQ_TextChanged(sender As Object, e As EventArgs)
        If TxtSemillaQQ.Text <> "" Then
            TxtEstimadoProducir.Text = Convert.ToString(Convert.ToDouble(TxtSemillaQQ.Text) * 0.7)
        Else
            TxtEstimadoProducir.Text = ""
        End If
        verificar()
    End Sub

    Protected Sub TxT_AreaMZ_TextChanged(sender As Object, e As EventArgs)
        If TxT_AreaMZ.Text <> "" Then
            Txt_AreaHa.Text = Convert.ToString(Convert.ToDouble(TxT_AreaMZ.Text) * 0.7)
        Else
            Txt_AreaHa.Text = ""
        End If
        verificar()
    End Sub

    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Dim rptdocument As New ReportDocument
        Dim productor As String = TxtProductor.SelectedItem.Text
        Dim ciclo As String = TxtCiclo.SelectedItem.Text
        'nombre de dataset
        Dim ds As New DataSet1
        Dim Str As String = "SELECT * FROM vista_inscripcion_senasa_lote WHERE Productor = '" & productor & "' AND CICLO = '" & ciclo & "'"
        Dim adap As New MySqlDataAdapter(Str, conn)
        Dim dt As New DataTable

        ' Nombre de la vista del dataset
        adap.Fill(ds, "vista_inscripcion_senasa_lote")

        Dim nombre As String
        nombre = "Orden de Compra de Semilla Registrada _" + Today
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
            TxtVariedad.Items.Insert(0, "")
            TxtVariedad.Items.Insert(1, "Amadeus-77")
            TxtVariedad.Items.Insert(2, "Carrizalito")
            TxtVariedad.Items.Insert(3, "Deorho")
            TxtVariedad.Items.Insert(4, "Azabache")
            TxtVariedad.Items.Insert(5, "Paraisito mejorado PM-2")
            TxtVariedad.Items.Insert(6, "Honduras nutritivo")
            TxtVariedad.Items.Insert(7, "Inta Cárdenas")
            TxtVariedad.Items.Insert(8, "Lenca precoz")
            TxtVariedad.Items.Insert(9, "Rojo chortí")
            TxtVariedad.Items.Insert(10, "Tolupan rojo")
            TxtVariedad.Items.Insert(11, "Otra especificar")
            provi = TxtVariedad.SelectedItem.Text
        ElseIf vv = "Maiz" Then
            DDL_Tipo.SelectedIndex = 2
            TxtVariedad.Items.Insert(0, "")
            TxtVariedad.Items.Insert(1, "Dicta Maya")
            TxtVariedad.Items.Insert(2, "Dicta Victoria")
            TxtVariedad.Items.Insert(3, "Otra especificar")
            provi = TxtVariedad.SelectedItem.Text
        Else
            DDL_Tipo.SelectedIndex = 0
        End If
    End Sub

    Protected Sub DDL_Nlote_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DDL_Nlote.SelectedItem.Text <> "" Then
            Dim StrCombo As String = "SELECT produccion_est_hectareas, superficie_mz, produccion_est_manzanas, superficie_hectarea FROM solicitud_inscripcion_delotes WHERE nombre_lote = '" & DDL_Nlote.SelectedItem.Text & "'"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            TxtProduccionQQHA.Text = DtCombo.Rows(0)("produccion_est_hectareas").ToString
            TxtProduccionQQMZ.Text = DtCombo.Rows(0)("produccion_est_manzanas").ToString
            TxT_AreaMZ.Text = DtCombo.Rows(0)("superficie_mz").ToString
            Txt_AreaHa.Text = DtCombo.Rows(0)("superficie_hectarea").ToString
            verificar()
        End If
    End Sub

    Protected Sub TxtRegistradaQQ_TextChanged(sender As Object, e As EventArgs)
        verificar()
    End Sub
End Class