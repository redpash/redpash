Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class entrenamientoscalidad2019
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then

                Dim Str As String = "SELECT * FROM usuariotns WHERE  Nombre='" & User.Identity.Name & "' "
                Dim adap As New MySqlDataAdapter(Str, conn)
                Dim dt As New DataTable
                adap.Fill(dt)

                TxtCod.Text = dt.Rows(0)("codigo").ToString()

                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenarmodulos()
                llenagrid()
            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+registro_productores` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `masp_productores` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY ec_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `mas+registro_ops2` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' and Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()

    End Sub
    Private Sub llenarmodulos()
        Dim StrCombo As String = "SELECT '00' as mod_codigo,' Todos' as mod_nombre UNION SELECT mod_codigo,mod_nombre FROM modulos_calidad ORDER BY mod_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn2)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtTema.DataSource = DtCombo
        TxtTema.DataValueField = DtCombo.Columns(0).ToString()
        TxtTema.DataTextField = DtCombo.Columns(1).ToString()
        TxtTema.DataBind()

    End Sub
    Sub llenagrid()
        BAgregar.Visible = False
        BAgregar2.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT id,id2,Depto_Descripcion,ec_nombre,mod_nombre,fecha,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO " +
            "FROM `mas+entrenamientos_calidad2019_pdet` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT id,id2,Depto_Descripcion,ec_nombre,mod_nombre,fecha,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO " +
                "FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT id,id2,Depto_Descripcion,ec_nombre,mod_nombre,fecha,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO " +
                    "FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                Else
                    If (TxtTema.SelectedValue = "00") Then
                        Me.SqlDataSource1.SelectCommand = "SELECT id,id2,Depto_Descripcion,ec_nombre,mod_nombre,fecha,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO " +
                        "FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                    Else
                        Me.SqlDataSource1.SelectCommand = "SELECT id,id2,Depto_Descripcion,ec_nombre,mod_nombre,fecha,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO " +
                        "FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND mod_codigo='" & TxtTema.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "

                        BAgregar.Visible = True

                    End If
                End If
            End If
        End If

        GridDatos.DataBind()

        If (GridDatos.Rows.Count > 0 And TxtTema.SelectedValue <> "00") Then
            BAgregar2.Visible = True
        End If

    End Sub
    Sub llenagrid2()
        Me.SqlDataSource2.SelectCommand = "SELECT COD_PRODUCTOR,NOMBRE,SEXO,EDAD " +
       " FROM `masp_productores` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY NOMBRE "

        GridDatos2.DataBind()
    End Sub
    Protected Sub GridDatos2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        'GridDatos2.PageIndex = e.NewPageIndex
        'SqlDataSource2.DataBind()
        llenagrid2()
    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboEntrenador()
        llenarcomboOP()
        llenagrid()
    End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        llenarcomboOP()
        llenagrid()
    End Sub
    Protected Sub cmborganizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmborganizacion.SelectedIndexChanged
        llenagrid()
    End Sub
    Protected Sub TxtTema_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtTema.SelectedIndexChanged
        llenagrid()
    End Sub

    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    query = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                Else
                    If (TxtTema.SelectedValue = "00") Then
                        query = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                    Else
                        query = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND mod_codigo='" & TxtTema.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "

                    End If
                End If
            End If
        End If

        Using con As New MySqlConnection(conn2)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "mas+entrenamientos_calidad"

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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+entrenamientos_calidad " & Today & ".xlsx")
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
        'If (e.CommandName = "Editar") Then

        '    ChNuevo.Checked = False

        '    Dim gvrow As GridViewRow = GridDatos.Rows(index)

        '    Dim Str As String = "SELECT * FROM creditos_banc_comer WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
        '    Dim adap As New MySqlDataAdapter(Str, conn)
        '    Dim dt As New DataTable
        '    adap.Fill(dt)

        '    TxtID.Text = dt.Rows(0)("id").ToString()
        '    TxtOrg.SelectedValue = dt.Rows(0)("COD_ORGANIZACION").ToString()
        '    TxtTrimestre.SelectedValue = dt.Rows(0)("Trimestre").ToString()
        '    TxtAno.SelectedValue = dt.Rows(0)("Ano").ToString()
        '    TxtEntidad.SelectedValue = dt.Rows(0)("Entidad").ToString()
        '    TxtValor.Text = dt.Rows(0)("Valor").ToString()

        '    ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
        'End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE  id2='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn2)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID2.Text = dt.Rows(0)("id2").ToString()

            Dim Str2 As String = "SELECT * FROM `mas+entrenamientos_calidad2019_pdet` WHERE  id2='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap2 As New MySqlDataAdapter(Str2, conn2)
            Dim dt2 As New DataTable
            adap2.Fill(dt2)

            Dim descon As String = Mid(dt.Rows(0)("COD_PRODUCTOR").ToString(), 1, 3)

            TxtTip.Text = descon

            Label1.Text = "¿Esta seguro que desea eliminar el participante?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub btClick1(sender As Object, e As EventArgs)
        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno2.SelectedValue.ToString

        Dim fecha2 As Date

        Dim gvrow As GridViewRow = GridDatos.Rows(0)
        fecha2 = gvrow.Cells(1).Text


        MsgBox(fecha2)
    End Sub
    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        If (GridDatos.Rows.Count > 0) Then
            Dim fecha2 As Date
            Dim gvrow As GridViewRow = GridDatos.Rows(0)
            fecha2 = gvrow.Cells(6).Text
            TxtDia.SelectedValue = fecha2.Day
            TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
            TxtAno2.SelectedValue = fecha2.Year

            TxtID.Text = gvrow.Cells(1).Text
            TxtID2.Text = gvrow.Cells(2).Text
        Else
            TxtDia.SelectedValue = 1
            TxtMes.SelectedIndex = 0
            TxtAno2.SelectedValue = 1

            TxtID.Text = 0
            TxtID2.Text = 0
        End If

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)


        llenagrid2()
    End Sub
    Protected Sub BAgregar2_Click(sender As Object, e As EventArgs) Handles BAgregar2.Click



        Dim gvrow As GridViewRow = GridDatos.Rows(0)
        TxtFecha.Text = gvrow.Cells(6).Text
        TxtNombre.Text = ""
        TxtIdentidad.Text = ""
        TxtSexo.SelectedIndex = 0
        TxtEdad.Text = 0
        TxtTelefono.Text = 0

        TxtID.Text = gvrow.Cells(1).Text
        TxtID2.Text = gvrow.Cells(2).Text

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#NoProdModal').modal('show'); });", True)



    End Sub
    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim conex As New MySqlConnection(conn2)
        Dim Sql As String

        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno2.SelectedValue.ToString

        conex.Open()

        If (GridDatos.Rows.Count = 0) Then


            Dim cmd As New MySqlCommand()
            Sql = "INSERT INTO capacitaciones_calidad2019 (mod_codigo,fecha,catador,COD_ORGANIZACION,fecha_ingreso) VALUES (@mod_codigo,@fecha,@catador,@COD_ORGANIZACION,now()) "
            cmd.Connection = conex
            cmd.CommandText = Sql
            cmd.Parameters.AddWithValue("@mod_codigo", TxtTema.SelectedValue)
            cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@catador", TxtCod.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
            cmd.ExecuteNonQuery()

            Dim cmd2 As New MySqlCommand()
            Sql = "SELECT *  from capacitaciones_calidad2019 ORDER BY Id DESC limit 1 "
            cmd2.Connection = conex
            cmd2.CommandText = Sql
            Dim count As Integer = Convert.ToInt32(cmd2.ExecuteScalar())

            For Each row As GridViewRow In GridDatos2.Rows
                Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar"), CheckBox)

                If check.Checked Then
                    Dim cmd3 As New MySqlCommand()
                    Sql = "INSERT INTO capacitaciones_calidad2019_prod (Id_parent,COD_PRODUCTOR,fecha_ingreso) VALUES (@Id_parent,@COD_PRODUCTOR,now()) "
                    cmd3.Connection = conex
                    cmd3.CommandText = Sql

                    cmd3.Parameters.AddWithValue("@Id_parent", count)
                    cmd3.Parameters.AddWithValue("@COD_PRODUCTOR", HttpUtility.HtmlDecode(row.Cells(1).Text))

                    cmd3.ExecuteNonQuery()

                End If
            Next

        Else
            For Each row As GridViewRow In GridDatos2.Rows
                Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar"), CheckBox)

                If check.Checked Then
                    Dim cmd4 As New MySqlCommand()
                    Sql = "INSERT INTO capacitaciones_calidad2019_prod (Id_parent,COD_PRODUCTOR,fecha_ingreso) VALUES (@Id_parent,@COD_PRODUCTOR,now()) "
                    cmd4.Connection = conex
                    cmd4.CommandText = Sql

                    cmd4.Parameters.AddWithValue("@Id_parent", TxtID.Text)
                    cmd4.Parameters.AddWithValue("@COD_PRODUCTOR", HttpUtility.HtmlDecode(row.Cells(1).Text))

                    cmd4.ExecuteNonQuery()

                End If
            Next

            Dim cmd5 As New MySqlCommand()
            Sql = " UPDATE capacitaciones_calidad2019  SET fecha=@fecha,catador=@catador WHERE Id=@Id"
            cmd5.Connection = conex
            cmd5.CommandText = Sql
            cmd5.Parameters.AddWithValue("@Id", TxtID.Text)
            cmd5.Parameters.AddWithValue("@catador", TxtCod.Text)
            cmd5.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha))
            cmd5.ExecuteNonQuery()

        End If

        conex.Close()

        Label1.Text = "La capacitacion ha sido guardada"

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", False)

    End Sub
    Protected Sub BGuardar2_Click(sender As Object, e As EventArgs) Handles BGuardar2.Click

        Dim conex As New MySqlConnection(conn2)
        Dim Sql As String

        conex.Open()

        Dim cmd As New MySqlCommand()
        Sql = "INSERT INTO capacitaciones_calidad2019_noprod (Id_parent,nombre,identidad,sexo,edad,telefono,fecha_ingreso) VALUES (@Id_parent,@nombre,@identidad,@sexo,@edad,telefono,now()) "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.Parameters.AddWithValue("@Id_parent", TxtID.Text)
        cmd.Parameters.AddWithValue("@nombre", TxtNombre.Text)
        cmd.Parameters.AddWithValue("@identidad", TxtIdentidad.Text)
        cmd.Parameters.AddWithValue("@sexo", TxtSexo.SelectedValue)
        cmd.Parameters.AddWithValue("@edad", TxtEdad.Text)
        cmd.Parameters.AddWithValue("@telefono", TxtTelefono.Text)
        cmd.ExecuteNonQuery()

        conex.Close()

        Label1.Text = "El productor no socio ha sido guardado en la capacitacion"

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#NoProdModal').modal('show'); });", False)

    End Sub
    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn2)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If (TxtTip.Text = "PPM") Then
            Sql = "UPDATE capacitaciones_calidad2019_prod SET eliminado=1  WHERE id=" & TxtID2.Text & " "
        Else
            Sql = "UPDATE capacitaciones_calidad2019_noprod SET eliminado=1  WHERE id=" & TxtID2.Text & " "
        End If


        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "El participante ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub



End Class