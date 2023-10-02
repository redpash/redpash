Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class opssituacionfinanciera
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("ConnODK2").ConnectionString
    Dim sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If User.Identity.IsAuthenticated = True Then
        If (Not IsPostBack) Then
                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
            llenarcomboOP2()
            llenagrid()

        End If
        ''llenagrid()
        'Else
        '    Response.Redirect(String.Format("~/pages/login.aspx"))
        'End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+registro_ops` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        'TxtDepto.DataSource = DtCombo
        'TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        'TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        'TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as asesor_codigo,'Todos' as asesor_nombre UNION SELECT DISTINCT `mas+registro_ops`.asesor_codigo, `mas+registro_ops`.asesor_nombre FROM `mas+registro_ops` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,'Todos' as OP_NOMBRE UNION SELECT DISTINCT `mas+registro_ops`.COD_ORGANIZACION, `mas+registro_ops`.OP_NOMBRE FROM `mas+registro_ops` WHERE `mas+registro_ops`.asesor_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY OP_NOMBRE"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()

    End Sub
    Private Sub llenarcomboOP2()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,'Todos' as OP_NOMBRE UNION SELECT DISTINCT `mas+registro_ops`.COD_ORGANIZACION, `mas+registro_ops`.OP_NOMBRE FROM `mas+registro_ops` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtOrg.DataSource = DtCombo
        TxtOrg.DataValueField = DtCombo.Columns(0).ToString()
        TxtOrg.DataTextField = DtCombo.Columns(1).ToString()
        TxtOrg.DataBind()

    End Sub

    Sub llenagrid()
        BAgregar.Visible = False

        'GridDatos.Columns(2).Visible = True


        If TxtEntrenador.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                "FROM `ops_situacion_financiera` ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
        Else
            If (cmborganizacion.SelectedValue = "00") Then
                Me.SqlDataSource1.SelectCommand = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                    "FROM `ops_situacion_financiera` WHERE  asesor_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
            Else
                BAgregar.Visible = True
                Me.SqlDataSource1.SelectCommand = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                    "FROM `ops_situacion_financiera` WHERE  asesor_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
            End If
        End If


        GridDatos.DataBind()

        'GridDatos.Columns(2).Visible = False

    End Sub
    'Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged

    '    llenarcomboEntrenador()
    '    llenarcomboOP()
    '    llenagrid()
    'End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        llenarcomboOP()
        llenagrid()
    End Sub
    Protected Sub cmborganizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmborganizacion.SelectedIndexChanged
        llenagrid()
    End Sub

    Private Sub exportar()
        Dim query As String = ""


        If TxtEntrenador.SelectedValue = "00" Then
            query = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                "FROM `ops_situacion_financiera` ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
        Else
            If (cmborganizacion.SelectedValue = "00") Then
                query = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                    "FROM `ops_situacion_financiera` WHERE  asesor_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
            Else
                BAgregar.Visible = True
                query = "SELECT id,Depto_Descripcion,asesor_nombre,OP_NOMBRE,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo " +
                    "FROM `ops_situacion_financiera` WHERE  asesor_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
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
                        ds.Tables(0).TableName = "ops_situacion_financiera"

                        Using wb As New XLWorkbook()
                            For Each dt As DataTable In ds.Tables
                                'Add DataTable as Worksheet.
                                wb.Worksheets.Add(dt)
                            Next

                            'Export the Excel file.
                            Response.Clear()
                            Response.Buffer = True
                            Response.Charset = ""
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Response.AddHeader("content-disposition", "attachment;filename=OPS_situacion_financiera " & Today & ".xlsx")
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
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "Editar") Then

            ChNuevo.Checked = False

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM situacion_financiera WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("id").ToString()
            TxtOrg.SelectedValue = dt.Rows(0)("COD_ORGANIZACION").ToString()
            TxtTrimestre.SelectedValue = dt.Rows(0)("Trimestre").ToString()
            TxtAno.SelectedValue = dt.Rows(0)("Ano").ToString()
            TxtCartera.Text = dt.Rows(0)("Cartera_Prestamos").ToString()
            TxtMora.Text = dt.Rows(0)("Mora_Prestamos").ToString()
            TxtDepositos.Text = dt.Rows(0)("Depositos_Ahorro").ToString()
            TxtPrestamos.Text = dt.Rows(0)("Prestamos_Pagar").ToString()
            TxtCapital.Text = dt.Rows(0)("Capital_Social").ToString()
            TxtReservas.Text = dt.Rows(0)("Reserva").ToString()
            TxtSemilla.Text = dt.Rows(0)("Capital_Semilla").ToString()
            TxtInteresesCobrados.Text = dt.Rows(0)("Intereses_Cobrados").ToString()
            TxtInteresesPagados.Text = dt.Rows(0)("Intereses_Pagados").ToString()
            TxtTrabajo.Text = dt.Rows(0)("Capital_Trabajo").ToString()

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM situacion_financiera WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar el registro?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        ChNuevo.Checked = True

        TxtID.Text = 0
        TxtOrg.SelectedValue = cmborganizacion.SelectedValue
        TxtTrimestre.SelectedIndex = 0
        TxtAno.SelectedIndex = 0
        TxtCartera.Text = 0
        TxtMora.Text = 0
        TxtDepositos.Text = 0
        TxtPrestamos.Text = 0
        TxtCapital.Text = 0
        TxtReservas.Text = 0
        TxtSemilla.Text = 0
        TxtInteresesCobrados.Text = 0
        TxtInteresesPagados.Text = 0
        TxtTrabajo.Text = 0

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
    End Sub

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If (ChNuevo.Checked = True) Then

            Sql = ""
            Sql = "INSERT INTO situacion_financiera (FechaReg,COD_ORGANIZACION,Trimestre,Ano,Cartera_Prestamos,Mora_Prestamos,Depositos_Ahorro,Prestamos_Pagar,Capital_Social,Reserva,Capital_Semilla,Intereses_Cobrados,Intereses_Pagados,Capital_Trabajo) VALUES (now(),@COD_ORGANIZACION,@Trimestre,@Ano,@Cartera_Prestamos,@Mora_Prestamos,@Depositos_Ahorro,@Prestamos_Pagar,@Capital_Social,@Reserva,@Capital_Semilla,@Intereses_Cobrados,@Intereses_Pagados,@Capital_Trabajo) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
            cmd.Parameters.AddWithValue("@Trimestre", TxtTrimestre.SelectedValue)
            cmd.Parameters.AddWithValue("@Ano", TxtAno.SelectedValue)
            cmd.Parameters.AddWithValue("@Cartera_Prestamos", TxtCartera.Text)
            cmd.Parameters.AddWithValue("@Mora_Prestamos", TxtMora.Text)
            cmd.Parameters.AddWithValue("@Depositos_Ahorro", TxtDepositos.Text)
            cmd.Parameters.AddWithValue("@Prestamos_Pagar", TxtPrestamos.Text)
            cmd.Parameters.AddWithValue("@Capital_Social", TxtCapital.Text)
            cmd.Parameters.AddWithValue("@Reserva", TxtReservas.Text)
            cmd.Parameters.AddWithValue("@Capital_Semilla", TxtSemilla.Text)
            cmd.Parameters.AddWithValue("@Intereses_Cobrados", TxtInteresesCobrados.Text)
            cmd.Parameters.AddWithValue("@Intereses_Pagados", TxtInteresesPagados.Text)
            cmd.Parameters.AddWithValue("@Capital_Trabajo", TxtCapital.Text)

            cmd.ExecuteNonQuery()
            Label1.Text = "El registro ha sido guardado"
        Else
            'MsgBox(identity)
            Sql = ""
            Sql = "UPDATE situacion_financiera SET COD_ORGANIZACION=@COD_ORGANIZACION,Trimestre=@Trimestre,Ano=@Ano,Cartera_Prestamos=@Cartera_Prestamos,Mora_Prestamos=@Mora_Prestamos,	Depositos_Ahorro=@Depositos_Ahorro,Prestamos_Pagar=@Prestamos_Pagar,Capital_Social=@Capital_Social,Reserva=@Reserva,Capital_Semilla=@Capital_Semilla,Intereses_Cobrados=@Intereses_Cobrados,Intereses_Pagados=@Intereses_Pagados,Capital_Trabajo=@Capital_Trabajo WHERE id=" & TxtID.Text & " "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtOrg.SelectedValue)
            cmd.Parameters.AddWithValue("@Trimestre", TxtTrimestre.SelectedValue)
            cmd.Parameters.AddWithValue("@Ano", TxtAno.SelectedValue)
            cmd.Parameters.AddWithValue("@Cartera_Prestamos", TxtCartera.Text)
            cmd.Parameters.AddWithValue("@Mora_Prestamos", TxtMora.Text)
            cmd.Parameters.AddWithValue("@Depositos_Ahorro", TxtDepositos.Text)
            cmd.Parameters.AddWithValue("@Prestamos_Pagar", TxtPrestamos.Text)
            cmd.Parameters.AddWithValue("@Capital_Social", TxtCapital.Text)
            cmd.Parameters.AddWithValue("@Reserva", TxtReservas.Text)
            cmd.Parameters.AddWithValue("@Capital_Semilla", TxtSemilla.Text)
            cmd.Parameters.AddWithValue("@Intereses_Cobrados", TxtInteresesCobrados.Text)
            cmd.Parameters.AddWithValue("@Intereses_Pagados", TxtInteresesPagados.Text)
            cmd.Parameters.AddWithValue("@Capital_Trabajo", TxtTrabajo.Text)

            cmd.ExecuteNonQuery()
            Label1.Text = "El registro ha sido modificado"
        End If

        conex.Close()

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", False)

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub

    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()


        Sql = "DELETE FROM situacion_financiera WHERE id=" & TxtID.Text & " "
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

End Class