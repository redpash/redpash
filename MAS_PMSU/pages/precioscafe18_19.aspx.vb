Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class precioscafe18_19
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcomboDepto()
                llenarcomboMuni()
                llenagrid()


            End If
            'llenagrid()
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, ' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `departamentos` ORDER BY Depto_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboDepto2()
        'Dim StrCombo As String = " SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `departamentos` ORDER BY Depto_Descripcion"
        'Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        'Dim DtCombo As New DataTable
        'adaptcombo.Fill(DtCombo)
        'TxtDepto2.DataSource = DtCombo
        'TxtDepto2.DataValueField = DtCombo.Columns(0).ToString()
        'TxtDepto2.DataTextField = DtCombo.Columns(1).ToString()
        'TxtDepto2.DataBind()
    End Sub
    Private Sub llenarcomboDepto3()
        'Dim StrCombo As String = "SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `departamentos` ORDER BY Depto_Descripcion"
        'Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        'Dim DtCombo As New DataTable
        'adaptcombo.Fill(DtCombo)
        'TxtDepto3.DataSource = DtCombo
        'TxtDepto3.DataValueField = DtCombo.Columns(0).ToString()
        'TxtDepto3.DataTextField = DtCombo.Columns(1).ToString()
        'TxtDepto3.DataBind()
    End Sub
    Private Sub llenarcomboMuni()
        Dim StrCombo As String = "SELECT '00' as Muni_Cod,' Todos' as Muni_Descripcion UNION SELECT DISTINCT Muni_Cod,Muni_Descripcion FROM `municipios` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY Muni_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtMuni.DataSource = DtCombo
        TxtMuni.DataValueField = DtCombo.Columns(0).ToString()
        TxtMuni.DataTextField = DtCombo.Columns(1).ToString()
        TxtMuni.DataBind()
    End Sub
    Private Sub llenarcomboMuni2()
        'Dim StrCombo As String = "SELECT DISTINCT Muni_Cod,Muni_Descripcion FROM `municipios` WHERE Depto_Cod = '" & TxtDepto2.SelectedValue & "' ORDER BY Muni_Descripcion"
        'Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        'Dim DtCombo As New DataTable
        'adaptcombo.Fill(DtCombo)
        'TxtMuni2.DataSource = DtCombo
        'TxtMuni2.DataValueField = DtCombo.Columns(0).ToString()
        'TxtMuni2.DataTextField = DtCombo.Columns(1).ToString()
        'TxtMuni2.DataBind()
    End Sub
    Private Sub llenarcomboMuni3()
        'Dim StrCombo As String = "SELECT DISTINCT Muni_Cod,Muni_Descripcion FROM `municipios` WHERE Depto_Cod = '" & TxtDepto3.SelectedValue & "' ORDER BY Muni_Descripcion"
        'Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        'Dim DtCombo As New DataTable
        'adaptcombo.Fill(DtCombo)
        'TxtMuni3.DataSource = DtCombo
        'TxtMuni3.DataValueField = DtCombo.Columns(0).ToString()
        'TxtMuni3.DataTextField = DtCombo.Columns(1).ToString()
        'TxtMuni3.DataBind()
    End Sub
    Sub llenagrid()
        BAgregar.Visible = False
        BAgregar2.Visible = False

        'GridDatos.Columns(2).Visible = True


        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT id,Fecha,Depto_Descripcion,Muni_Descripcion,Asesor,Exportador,PrecioPHH,PrecioPH,PrecioPS,PrecioOro " +
                "FROM `mas+precioscafe1819` ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
        Else
            If (TxtMuni.SelectedValue = "00") Then
                Me.SqlDataSource1.SelectCommand = "SELECT id,Fecha,Depto_Descripcion,Muni_Descripcion,Asesor,Exportador,PrecioPHH,PrecioPH,PrecioPS,PrecioOro " +
                    "FROM `mas+precioscafe1819` WHERE  Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
            Else
                BAgregar.Visible = True
                BAgregar2.Visible = True

                Me.SqlDataSource1.SelectCommand = "SELECT id,Fecha,Depto_Descripcion,Muni_Descripcion,Asesor,Exportador,PrecioPHH,PrecioPH,PrecioPS,PrecioOro " +
                    "FROM `mas+precioscafe1819` WHERE  Depto_Cod='" & TxtDepto.SelectedValue & "' AND Muni_Cod='" & TxtMuni.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
            End If
        End If


        GridDatos.DataBind()

        'GridDatos.Columns(2).Visible = False

    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged

        llenarcomboMuni()
        llenagrid()
    End Sub
    'Protected Sub TxtDepto2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto2.SelectedIndexChanged

    '    llenarcomboMuni2()

    'End Sub
    Protected Sub cambioindexdepto(ByVal sender As Object, ByVal e As EventArgs)
        llenarcomboMuni2()
    End Sub
    Protected Sub cambioindexdepto2(ByVal sender As Object, ByVal e As EventArgs)
        llenarcomboMuni3()
    End Sub
    Protected Sub TxtMuni_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtMuni.SelectedIndexChanged
        'llenarcomboOP()
        llenagrid()
    End Sub
    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+precioscafe1819` ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
        Else
            If (TxtMuni.SelectedValue = "00") Then
                query = "SELECT * FROM `mas+precioscafe1819` WHERE  Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
            Else
                query = "SELECT * FROM `mas+precioscafe1819` WHERE  Depto_Cod='" & TxtDepto.SelectedValue & "' AND Muni_Cod='" & TxtMuni.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,Muni_Descripcion,Exportador "
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
                        ds.Tables(0).TableName = "mas+precioscafe1819"

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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+precioscafe1819 " & Today & ".xlsx")
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

        Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "Editar") Then



            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+precioscafe1819` WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)
            '
            TxtID.Text = dt.Rows(0)("id").ToString()
            fecha2 = dt.Rows(0)("Fecha").ToString()

            If (dt.Rows(0)("Exportador").ToString() = "Plaza") Then
                TxtDia2.SelectedValue = fecha2.Day
                TxtMes2.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno3.SelectedValue = fecha2.Year

                'llenarcomboDepto3()
                'TxtDepto3.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()
                'llenarcomboMuni3()
                'TxtMuni3.SelectedValue = dt.Rows(0)("Muni_Cod").ToString()

                TxtAsesor2.Text = dt.Rows(0)("Asesor").ToString()
                TxtPHH2.Text = dt.Rows(0)("PrecioPHH").ToString()
                TxtPH2.Text = dt.Rows(0)("PrecioPH").ToString()
                TxtPS2.Text = dt.Rows(0)("PrecioPS").ToString()
                TxtOro2.Text = dt.Rows(0)("PrecioOro").ToString()
                ChNuevo2.Checked = False

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal2').modal('show'); });", True)

            Else

                TxtDia.SelectedValue = fecha2.Day
                TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno2.SelectedValue = fecha2.Year

                'llenarcomboDepto2()
                'TxtDepto2.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()
                'llenarcomboMuni2()
                'TxtMuni2.SelectedValue = dt.Rows(0)("Muni_Cod").ToString()

                TxtAsesor.Text = dt.Rows(0)("Asesor").ToString()
                TxtPHH.Text = dt.Rows(0)("PrecioPHH").ToString()
                TxtPH.Text = dt.Rows(0)("PrecioPH").ToString()
                TxtPS.Text = dt.Rows(0)("PrecioPS").ToString()
                TxtOro.Text = dt.Rows(0)("PrecioOro").ToString()

                ChNuevo.Checked = False

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
            End If

        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+precioscafe1819` WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar el credito?"
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

        TxtPHH.Text = 0
        TxtPH.Text = 0
        TxtPS.Text = 0
        TxtOro.Text = 0

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
    End Sub
    Protected Sub BAgregar2_Click(sender As Object, e As EventArgs) Handles BAgregar2.Click

        ChNuevo2.Checked = True

        TxtID2.Text = 0

        TxtPHH2.Text = 0
        TxtPH2.Text = 0
        TxtPS2.Text = 0
        TxtOro2.Text = 0

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal2').modal('show'); });", True)
    End Sub
    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click


        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno2.SelectedValue.ToString

        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If (ChNuevo.Checked = True) Then

            Sql = ""
            Sql = "INSERT INTO precio_cosechacafe1819 (Fecha,Fecha2,Depto_Cod,Muni_Cod,Asesor,Exportador,PrecioPHH,PrecioPH,PrecioPS,PrecioOro) VALUES (@Fecha,now(),@Depto_Cod,@Muni_Cod,@Asesor,@Exportador,@PrecioPHH,@PrecioPH,@PrecioPS,@PrecioOro) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Depto_Cod", TxtDepto.SelectedValue)
            cmd.Parameters.AddWithValue("@Muni_Cod", TxtMuni.SelectedValue)
            cmd.Parameters.AddWithValue("@Asesor", TxtAsesor.SelectedValue)
            cmd.Parameters.AddWithValue("@Exportador", TxtExp.SelectedValue)
            cmd.Parameters.AddWithValue("@PrecioPHH", TxtPHH.Text)
            cmd.Parameters.AddWithValue("@PrecioPH", TxtPH.Text)
            cmd.Parameters.AddWithValue("@PrecioPS", TxtPS.Text)
            cmd.Parameters.AddWithValue("@PrecioOro", TxtOro.Text)
            cmd.ExecuteNonQuery()
            Label1.Text = "El precio ha sido guardado"
        Else


            Sql = ""
            Sql = "UPDATE precio_cosechacafe1819 SET Fecha=@Fecha,Asesor=@Asesor,Exportador=@Exportador,PrecioPHH=@PrecioPHH,PrecioPH=@PrecioPH,PrecioPS=@PrecioPS,PrecioOro=@PrecioOro WHERE id=" & TxtID.Text & " "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Asesor", TxtAsesor.SelectedValue)
            cmd.Parameters.AddWithValue("@Exportador", TxtExp.SelectedValue)
            cmd.Parameters.AddWithValue("@PrecioPHH", TxtPHH.Text)
            cmd.Parameters.AddWithValue("@PrecioPH", TxtPH.Text)
            cmd.Parameters.AddWithValue("@PrecioPS", TxtPS.Text)
            cmd.Parameters.AddWithValue("@PrecioOro", TxtOro.Text)
            cmd.ExecuteNonQuery()
            Label1.Text = "El precio ha sido modificado"
        End If

        conex.Close()

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", False)

    End Sub
    Protected Sub BGuardar2_Click(sender As Object, e As EventArgs) Handles BGuardar2.Click


        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes2.SelectedIndex + 1
        fecha = TxtDia2.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno3.SelectedValue.ToString

        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If (ChNuevo2.Checked = True) Then

            Sql = ""
            Sql = "INSERT INTO precio_cosechacafe1819 (Fecha,Fecha2,Depto_Cod,Muni_Cod,Asesor,Exportador,PrecioPHH,PrecioPH,PrecioPS,PrecioOro) VALUES (@Fecha,now(),@Depto_Cod,@Muni_Cod,@Asesor,'Plaza',@PrecioPHH,@PrecioPH,@PrecioPS,@PrecioOro) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Depto_Cod", TxtDepto.SelectedValue)
            cmd.Parameters.AddWithValue("@Muni_Cod", TxtMuni.SelectedValue)
            cmd.Parameters.AddWithValue("@Asesor", TxtAsesor2.SelectedValue)
            'cmd.Parameters.AddWithValue("@Exportador", TxtExp.SelectedValue)
            cmd.Parameters.AddWithValue("@PrecioPHH", TxtPHH2.Text)
            cmd.Parameters.AddWithValue("@PrecioPH", TxtPH2.Text)
            cmd.Parameters.AddWithValue("@PrecioPS", TxtPS2.Text)
            cmd.Parameters.AddWithValue("@PrecioOro", TxtOro2.Text)
            cmd.ExecuteNonQuery()
            Label1.Text = "El precio ha sido guardado"
        Else


            Sql = ""
            Sql = "UPDATE precio_cosechacafe1819 SET Fecha=@Fecha,Asesor=@Asesor,PrecioPHH=@PrecioPHH,PrecioPH=@PrecioPH,PrecioPS=@PrecioPS,PrecioOro=@PrecioOro WHERE id=" & TxtID.Text & " "
            cmd.Connection = conex
            cmd.CommandText = Sql

            'cmd.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            'cmd.Parameters.AddWithValue("@Depto_Cod", TxtDepto.SelectedValue)
            'cmd.Parameters.AddWithValue("@Muni_Cod", TxtMuni.SelectedValue)
            cmd.Parameters.AddWithValue("@Asesor", TxtAsesor2.SelectedValue)
            'cmd.Parameters.AddWithValue("@Exportador", TxtExp.SelectedValue)
            cmd.Parameters.AddWithValue("@PrecioPHH", TxtPHH2.Text)
            cmd.Parameters.AddWithValue("@PrecioPH", TxtPH2.Text)
            cmd.Parameters.AddWithValue("@PrecioPS", TxtPS2.Text)
            cmd.Parameters.AddWithValue("@PrecioOro", TxtOro2.Text)
            cmd.ExecuteNonQuery()
            Label1.Text = "El precio ha sido modificado"
        End If

        conex.Close()

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal2').modal('show'); });", False)

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub

    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()


        Sql = "DELETE FROM precio_cosechacafe1819 WHERE id=" & TxtID.Text & " "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "El precio ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub

End Class