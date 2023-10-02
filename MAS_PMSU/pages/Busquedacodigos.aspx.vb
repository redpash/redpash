Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.IO
Public Class Busquedacodigos
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then

        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If
    End Sub
    Private Sub buscar()
        Dim query, query2 As String

        query = "SELECT * FROM `tabla_busqueda` "

        Dim con3 As New MySqlConnection(conn3)
        Dim cmd As New MySqlCommand()
        Dim sda As New MySqlDataAdapter()

        Dim ds As New DataSet

        cmd.CommandText = query
        cmd.Connection = con3
        sda.SelectCommand = cmd

        sda.Fill(ds, "tabla_busqueda")

        If (ds.Tables("tabla_busqueda").Rows.Count > 0) Then

            con3.Open()
            Dim cmd2 As New MySqlCommand()
            query2 = "TRUNCATE TABLE tabla_busqueda_espejo; ALTER TABLE tabla_busqueda_espejo AUTO_INCREMENT = 0; "
            cmd2.Connection = con3
            cmd2.CommandText = query2
            cmd2.ExecuteNonQuery()
            con3.Close()

            For Each Fila As DataRow In ds.Tables("tabla_busqueda").Rows

                Dim Str As String = "SELECT " + Fila.Item("CAMPO").ToString() + " FROM " + Fila.Item("BD").ToString() + ".`" + Fila.Item("TABLA").ToString() + "` WHERE " + Fila.Item("CAMPO").ToString() + "='" & TxtCodigo.Text & "' "
                Dim adap As New MySqlDataAdapter(Str, conn3)
                Dim dt As New DataTable
                adap.Fill(dt)

                If (dt.Rows.Count > 0) Then

                    Dim cmd3 As New MySqlCommand()
                    con3.Open()
                    query2 = "INSERT INTO tabla_busqueda_espejo (TABLA,CAMPO,BD,COD_PRODUCTOR) VALUES (@TABLA,@CAMPO,@BD,@COD_PRODUCTOR) "
                    cmd3.Connection = con3
                    cmd3.CommandText = query2
                    cmd3.Parameters.AddWithValue("@TABLA", Fila.Item("TABLA").ToString())
                    cmd3.Parameters.AddWithValue("@CAMPO", Fila.Item("CAMPO").ToString())
                    cmd3.Parameters.AddWithValue("@BD", Fila.Item("BD").ToString())
                    cmd3.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodigo.Text)
                    cmd3.ExecuteNonQuery()
                    con3.Close()

                End If
            Next

            llenagrid()

        End If
    End Sub
    Private Sub buscar2()
        Dim query, query2 As String

        query = "SELECT * FROM `tabla_busqueda` "

        Dim con3 As New MySqlConnection(conn3)
        Dim cmd As New MySqlCommand()
        Dim sda As New MySqlDataAdapter()

        Dim ds As New DataSet

        cmd.CommandText = query
        cmd.Connection = con3
        sda.SelectCommand = cmd

        sda.Fill(ds, "tabla_busqueda")

        If (ds.Tables("tabla_busqueda").Rows.Count > 0) Then

            con3.Open()
            Dim cmd2 As New MySqlCommand()
            query2 = "TRUNCATE TABLE tabla_busqueda_espejo2; ALTER TABLE tabla_busqueda_espejo2 AUTO_INCREMENT = 0; "
            cmd2.Connection = con3
            cmd2.CommandText = query2
            cmd2.ExecuteNonQuery()
            con3.Close()

            For Each Fila As DataRow In ds.Tables("tabla_busqueda").Rows

                Dim Str As String = "SELECT " + Fila.Item("CAMPO").ToString() + " FROM " + Fila.Item("BD").ToString() + ".`" + Fila.Item("TABLA").ToString() + "` WHERE " + Fila.Item("CAMPO").ToString() + "='" & TxtCodigo2.Text & "' "
                Dim adap As New MySqlDataAdapter(Str, conn3)
                Dim dt As New DataTable
                adap.Fill(dt)

                If (dt.Rows.Count > 0) Then

                    Dim cmd3 As New MySqlCommand()
                    con3.Open()
                    query2 = "INSERT INTO tabla_busqueda_espejo2 (TABLA,CAMPO,BD,COD_PRODUCTOR) VALUES (@TABLA,@CAMPO,@BD,@COD_PRODUCTOR) "
                    cmd3.Connection = con3
                    cmd3.CommandText = query2
                    cmd3.Parameters.AddWithValue("@TABLA", Fila.Item("TABLA").ToString())
                    cmd3.Parameters.AddWithValue("@CAMPO", Fila.Item("CAMPO").ToString())
                    cmd3.Parameters.AddWithValue("@BD", Fila.Item("BD").ToString())
                    cmd3.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodigo2.Text)
                    cmd3.ExecuteNonQuery()
                    con3.Close()

                End If
            Next

            llenagrid2()

        End If
    End Sub
    Sub llenagrid()
        Me.SqlDataSource1.SelectCommand = "SELECT ID,TABLA,CAMPO,BD,COD_PRODUCTOR " +
       " FROM `tabla_busqueda_espejo` "
        GridDatos.DataBind()

    End Sub
    Sub llenagrid2()
        Me.SqlDataSource2.SelectCommand = "SELECT ID,TABLA,CAMPO,BD,COD_PRODUCTOR " +
       " FROM `tabla_busqueda_espejo2` "
        GridDatos2.DataBind()

    End Sub
    Protected Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        buscar()
        buscar2()
    End Sub
    Protected Sub GridDatos_DataBound(sender As Object, ByVal e As EventArgs) Handles GridDatos.DataBound

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
        'e As EventArgs

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
    Protected Sub SqlDataSource2_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource2.Selected

        lblTotalClientes2.Text = e.AffectedRows.ToString()

    End Sub
    Private Sub exportar()
        Dim query As String = ""

        query = "SELECT * FROM `tabla_busqueda_espejo`; " +
             "SELECT * FROM `tabla_busqueda_espejo2` "

        Using con As New MySqlConnection(conn3)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "tabla_busqueda_espejo"
                        ds.Tables(1).TableName = "tabla_busqueda_espejo2"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Busqueda_codigo_" + TxtCodigo.Text + "-" + TxtCodigo2.Text + " " & Today & ".xlsx")
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
End Class