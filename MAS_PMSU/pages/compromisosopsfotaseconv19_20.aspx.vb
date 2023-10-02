Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class compromisosopsfotaseconv19_20
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    'Dim conn2 As String = ConfigurationManager.ConnectionStrings("OConnODK3").ConnectionString
    Dim op, op_nom, sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcombodepto()
                llenarcomboorg()
                llenagrid()

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcombodepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod,' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod,Depto_Descripcion FROM `mas+cafecompf19_20resumen2` ORDER BY Depto_Descripcion "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboorg()
        'op = System.Web.HttpContext.Current.Session("op_codigo")

        Dim StrCombo As String = "SELECT ' Todos' as EXPORTADOR UNION SELECT DISTINCT EXPORTADOR FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY EXPORTADOR "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtOrg.DataSource = DtCombo
        TxtOrg.DataValueField = DtCombo.Columns(0).ToString()
        TxtOrg.DataTextField = DtCombo.Columns(0).ToString()
        TxtOrg.DataBind()
    End Sub
    Sub llenagrid()
        BAgregar.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,CONVENIO_OP " +
            "FROM `mas+cafecompf19_20resumen2` ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
        Else
            If (TxtOrg.SelectedValue = " Todos") Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,CONVENIO_OP " +
                "FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "

            Else
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,CONVENIO_OP " +
                "FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
                BAgregar.Visible = True
            End If

        End If

        GridDatos.DataBind()

        'If (GridDatos.Rows.Count > 0) Then
        '    LinkButton1.Visible = True
        'Else
        '    LinkButton1.Visible = False
        'End If
    End Sub
    Sub llenagrid2()

        Me.SqlDataSource2.SelectCommand = "SELECT COD_ORGANIZACION,OP_NOMBRE,EXPORTADOR,QQ_PS " +
       " FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' ORDER BY OP_NOMBRE "


        GridDatos2.DataBind()
    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboorg()
        llenagrid()

    End Sub
    Protected Sub TxtOrg_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtOrg.SelectedIndexChanged
        llenagrid()
    End Sub
    Private Sub revisarorg()
        Dim sql As String = "SELECT * FROM `cafecomp19_20fopsconv` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND	EXPORTADOR='" & TxtOrg.SelectedValue & "' "
        Dim conex As New MySqlConnection(conn)
        Dim cmd As New MySqlCommand(sql, conex)

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        If dt.Rows.Count = 0 Then

        Else
            For Each row As DataRow In dt.Rows
                Dim valor As String = CStr(row("COD_ORGANIZACION"))

                For Each row2 As GridViewRow In GridDatos2.Rows
                    Dim check As CheckBox = TryCast(row2.FindControl("chkSeleccionar"), CheckBox)
                    If (valor = row2.Cells(1).Text) Then
                        check.Checked = True
                        'check.Enabled = False
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub exportar()

        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+cafecompf19_20resumen2` ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
        Else
            If (TxtOrg.SelectedValue = " Todos") Then
                query = "SELECT * FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "

            Else
                query = "SELECT * FROM `mas+cafecompf19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
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
                        ds.Tables(0).TableName = "mas+cafecompfort19_20"

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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+cafecompfort19_20 " & Today & ".xlsx")
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

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Response.Redirect(String.Format("~/pages/entregasreg.aspx?id=" + HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString + "&edit=1"))

        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM cafe_entregas_fortalecidas WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar la entrega?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub
    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()


        Sql = "UPDATE cafe_entregas_fortalecidas SET eliminado=1  WHERE id=" & TxtID.Text & " "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "La entrega ha sido eliminada"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub BGuardarr_Click(sender As Object, e As EventArgs) Handles BGuardar.Click

        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno.SelectedValue.ToString

        Dim conex As New MySqlConnection(conn)
        Dim Sql As String
        Dim cmd As New MySqlCommand()

        conex.Open()
        Sql = "DELETE FROM `cafecomp19_20fopsconv` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()
        conex.Close()

        For Each row As GridViewRow In GridDatos2.Rows
            Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar"), CheckBox)

            If check.Checked Then

                conex.Open()
                Dim cmd2 As New MySqlCommand()
                Sql = "INSERT INTO cafecomp19_20fopsconv (Depto_Cod,COD_ORGANIZACION,EXPORTADOR,Fecha) VALUES (@Depto_Cod,@COD_ORGANIZACION,@EXPORTADOR,@Fecha) "
                cmd2.Connection = conex
                cmd2.CommandText = Sql
                cmd2.Parameters.AddWithValue("@Depto_Cod", TxtDepto.SelectedValue)
                cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtOrg.SelectedValue)
                cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", HttpUtility.HtmlDecode(row.Cells(1).Text))
                cmd2.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
                cmd2.ExecuteNonQuery()
                conex.Close()
            End If
        Next

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        Label1.Text = "Las organizaciones con covenio han sido guardadas"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        Dim fecha2 As Date

        Dim Str As String = "SELECT * FROM `cafecomp19_20fopsconv` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' "
        Dim adap As New MySqlDataAdapter(Str, conn)
        Dim dt As New DataTable
        adap.Fill(dt)

        If (dt.Rows.Count > 0) Then
            fecha2 = dt.Rows(0)("Fecha").ToString()
            TxtDia.SelectedValue = fecha2.Day
            TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
            TxtAno.SelectedValue = fecha2.Year
        Else
            fecha2 = Now
            TxtDia.SelectedValue = fecha2.Day
            TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
            TxtAno.SelectedValue = fecha2.Year
        End If

        'ChNuevo.Checked = True

        llenagrid2()

        revisarorg()

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub
End Class