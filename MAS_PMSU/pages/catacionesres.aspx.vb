Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class catacionesres
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then

                If (Request.QueryString("dir") = 1) Then

                    Dim Str As String = "SELECT Depto_Cod,ec_codigo,COD_ORGANIZACION FROM `mas+registro_ops2` WHERE  COD_ORGANIZACION='" & Request.QueryString("org") & "' "
                    Dim adap As New MySqlDataAdapter(Str, conn)
                    Dim dt As New DataTable
                    adap.Fill(dt)

                    TxtDepto.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()
                    TxtEntrenador.SelectedValue = dt.Rows(0)("ec_codigo").ToString()
                    cmborganizacion.SelectedValue = dt.Rows(0)("COD_ORGANIZACION").ToString()
                End If

                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenagrid()

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, ' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+registro_productores2` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `mas+registro_productores2` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY ec_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `mas+registro_productores2` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()

    End Sub


    Sub llenagrid()
        BAgregar.Visible = False
        BAgregar2.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Id,Depto_Descripcion,Correlativo,ec_nombre,fecha,Tipo,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO,Correlativo,Muestra,Catacion " +
            "FROM `mas+cataciones` ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Id,Depto_Descripcion,Correlativo,ec_nombre,fecha,Tipo,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO,Correlativo,Muestra,Catacion " +
                "FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Id,Depto_Descripcion,Correlativo,ec_nombre,fecha,Tipo,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO,Correlativo,Muestra,Catacion " +
                    "FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT Id,Depto_Descripcion,Correlativo,ec_nombre,fecha,Tipo,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,SEXO,Correlativo,Muestra,Catacion " +
                        "FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "

                    BAgregar.Visible = True
                    BAgregar2.Visible = True
                End If
            End If
        End If

        GridDatos.DataBind()

        If (GridDatos.Rows.Count > 0) Then
            LinkButton1.Visible = True
        Else
            LinkButton1.Visible = False
        End If
    End Sub
    'Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged

    '    llenarcomboEntrenador()
    '    llenarcomboOP()
    '    llenagrid()
    'End Sub
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
    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+cataciones` ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    query = "SELECT * FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "
                Else
                    query = "SELECT * FROM `mas+cataciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,OP_NOMBRE,NOMBRE "

                    BAgregar.Visible = True
                    BAgregar2.Visible = True
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
                        ds.Tables(0).TableName = "mas+cataciones"

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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+cataciones " & Today & ".xlsx")
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

            Dim Str As String = "SELECT * FROM creditos_banc_comer WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "



            Response.Redirect(String.Format("~/pages/catacionreg.aspx?id=" + HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString + "&edit=1"))

        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM cataciones WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn2)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar la catacion?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If
    End Sub
    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn2)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()


        Sql = "UPDATE cataciones SET eliminado=1  WHERE id=" & TxtID.Text & " "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "La catacion ha sido eliminada"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        Response.Redirect(String.Format("~/pages/catacionreg.aspx?val=" + cmborganizacion.SelectedValue + "&val2=" + cmborganizacion.SelectedItem.Text + "&val3=Organizacion_productores"))
    End Sub

    Protected Sub BAgregar2_Click(sender As Object, e As EventArgs) Handles BAgregar2.Click
        Response.Redirect(String.Format("~/pages/catacionreg.aspx?val=" + cmborganizacion.SelectedValue + "&val2=" + cmborganizacion.SelectedItem.Text + "&val3=Productor"))
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub
End Class