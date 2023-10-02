Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class opsfortalecidasupdate
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
        Dim StrCombo As String = "SELECT '00' as Depto_Cod,' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod,Depto_Descripcion FROM `masops_fortalecidas` ORDER BY Depto_Descripcion "
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

        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION,OP_NOMBRE FROM `masops_fortalecidas` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY OP_NOMBRE "
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

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOM_REPRESENTANTE,COD_ORGANIZACION,OP_NOMBRE,SOCIOS_TOTALES,SOCIOS_ACTIVOS,CADENA " +
            "FROM `masops_fortalecidas` ORDER BY  Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If (TxtOrg.SelectedValue = "00") Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOM_REPRESENTANTE,COD_ORGANIZACION,OP_NOMBRE,SOCIOS_TOTALES,SOCIOS_ACTIVOS,CADENA " +
                "FROM `masops_fortalecidas` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "

            Else
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOM_REPRESENTANTE,COD_ORGANIZACION,OP_NOMBRE,SOCIOS_TOTALES,SOCIOS_ACTIVOS,CADENA " +
                "FROM `masops_fortalecidas` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND COD_ORGANIZACION='" & TxtOrg.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                BAgregar.Visible = True
            End If

        End If

        GridDatos.DataBind()

        If (GridDatos.Rows.Count > 0) Then
            LinkButton1.Visible = True
        Else
            LinkButton1.Visible = False
        End If
    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboorg()
        llenagrid()

    End Sub
    Protected Sub TxtOrg_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtOrg.SelectedIndexChanged
        llenagrid()
    End Sub
    Private Sub exportar()

        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `masops_fortalecidas` ORDER BY Fecha,Depto_Descripcion,OP_NOMBRE "
        Else
            If (TxtOrg.SelectedValue = "00") Then
                query = "SELECT * FROM `masops_fortalecidas` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,OP_NOMBRE "

            Else
                query = "SELECT * FROM `masops_fortalecidas` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND COD_ORGANIZACION='" & TxtOrg.SelectedValue & "' ORDER BY Fecha,Depto_Descripcion,OP_NOMBRE "

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
                        ds.Tables(0).TableName = "masops_fortalecidas"

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
                            Response.AddHeader("content-disposition", "attachment;filename=masops_fortalecidas " & Today & ".xlsx")
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

            Dim Str As String = "SELECT * FROM masops_fortalecidas WHERE COD_ORGANIZACION='" & HttpUtility.HtmlDecode(gvrow.Cells(4).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            'TxtID.Text = dt.Rows(0)("id").ToString()
            TxtCodgOrg.Text = dt.Rows(0)("COD_ORGANIZACION").ToString()
            TxtCodRep.Text = dt.Rows(0)("COD_REPRESENTANTE").ToString()
            TxtNomRep.Text = dt.Rows(0)("NOM_REPRESENTANTE").ToString()
            TxtIdent.Text = dt.Rows(0)("ID_REPRESENTANTE").ToString()
            TxtRTN.Text = dt.Rows(0)("RTN").ToString()
            TxtTelRep.Text = dt.Rows(0)("TEL_REPRESENTANTE").ToString()
            TxtOPNom.Text = dt.Rows(0)("OP_NOMBRE").ToString()
            TxtSociosAct.Text = dt.Rows(0)("SOCIOS_TOTALES").ToString()
            TxtSociosTot.Text = dt.Rows(0)("SOCIOS_ACTIVOS").ToString()


            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
        End If
    End Sub
    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim conex As New MySqlConnection(conn)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()


        Sql = "UPDATE masops_fortalecidas SET COD_ORGANIZACION=@COD_ORGANIZACION,COD_REPRESENTANTE=@COD_REPRESENTANTE,NOM_REPRESENTANTE=@NOM_REPRESENTANTE,ID_REPRESENTANTE=@ID_REPRESENTANTE,RTN=@RTN,TEL_REPRESENTANTE=@TEL_REPRESENTANTE,OP_NOMBRE=@OP_NOMBRE,SOCIOS_TOTALES=@SOCIOS_TOTALES,SOCIOS_ACTIVOS=@SOCIOS_ACTIVOS  WHERE COD_ORGANIZACION='" & TxtCodgOrg.Text & "' "
        cmd.Connection = conex
        cmd.CommandText = Sql

        cmd.Parameters.AddWithValue("COD_ORGANIZACION", TxtCodgOrg.Text)
        cmd.Parameters.AddWithValue("COD_REPRESENTANTE", TxtCodRep.Text)
        cmd.Parameters.AddWithValue("NOM_REPRESENTANTE", TxtNomRep.Text)
        cmd.Parameters.AddWithValue("ID_REPRESENTANTE", TxtIdent.Text)
        cmd.Parameters.AddWithValue("RTN", TxtRTN.Text)
        cmd.Parameters.AddWithValue("TEL_REPRESENTANTE", TxtTelRep.Text)
        cmd.Parameters.AddWithValue("OP_NOMBRE", TxtOPNom.Text)
        cmd.Parameters.AddWithValue("SOCIOS_TOTALES", TxtSociosTot.Text)
        cmd.Parameters.AddWithValue("SOCIOS_ACTIVOS", TxtSociosAct.Text)

        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "Los datos de la OP han sido modificados"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        Response.Redirect(String.Format("~/pages/entregasreg.aspx?val=" & TxtOrg.SelectedValue & "&val2=" & TxtOrg.SelectedItem.Text & " "))
    End Sub


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub
End Class