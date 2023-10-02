Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class compromisosopsaseferfin19_20
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    'Dim conn2 As String = ConfigurationManager.ConnectionStrings("OConnODK3").ConnectionString
    Dim op, op_nom, sentencia, identity As String
    Dim fecha2 As Date
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
        Dim StrCombo As String = "SELECT '00' as Depto_Cod,' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod,Depto_Descripcion FROM `mas+cafecomp19_20resumen2` ORDER BY Depto_Descripcion "
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

        Dim StrCombo As String = "SELECT ' Todos' as EXPORTADOR UNION SELECT DISTINCT EXPORTADOR FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY EXPORTADOR "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtOrg.DataSource = DtCombo
        TxtOrg.DataValueField = DtCombo.Columns(0).ToString()
        TxtOrg.DataTextField = DtCombo.Columns(0).ToString()
        TxtOrg.DataBind()
    End Sub
    Sub llenagrid()
        'BAgregar.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT COD_ORGANIZACION,Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,FERT_SOLICITADO,FERT_ENTREGADO " +
            "FROM `mas+cafecomp19_20resumen2` WHERE FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
        Else
            If (TxtOrg.SelectedValue = " Todos") Then
                Me.SqlDataSource1.SelectCommand = "SELECT COD_ORGANIZACION,Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,FERT_SOLICITADO,FERT_ENTREGADO " +
                "FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "

            Else
                Me.SqlDataSource1.SelectCommand = "SELECT COD_ORGANIZACION,Depto_Descripcion,OP_NOMBRE,EXPORTADOR,QQ_PS,FERT_SOLICITADO,FERT_ENTREGADO " +
                "FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' AND FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
                'BAgregar.Visible = True
            End If

        End If

        GridDatos.DataBind()

        'If (GridDatos.Rows.Count > 0) Then
        '    LinkButton1.Visible = True
        'Else
        '    LinkButton1.Visible = False
        'End If
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
            Me.SqlDataSource1.SelectCommand = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
        Else
            If (TxtOrg.SelectedValue = " Todos") Then
                Me.SqlDataSource1.SelectCommand = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "

            Else
                Me.SqlDataSource1.SelectCommand = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' AND FERT_SOLICITADO>0 ORDER BY Depto_Descripcion,OP_NOMBRE,EXPORTADOR "
                'BAgregar.Visible = True
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
                        ds.Tables(0).TableName = "mas+cafecomp19_20"

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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+cafecomp19_20 " & Today & ".xlsx")
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

            Dim Str As String = "SELECT * FROM cafecomp19_20opsfert WHERE  COD_ORGANIZACION='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' and EXPORTADOR='" & HttpUtility.HtmlDecode(gvrow.Cells(3).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtQQSol.Text = gvrow.Cells(5).Text
            TxtCodOrg.Text = gvrow.Cells(0).Text
            TxtExp.Text = gvrow.Cells(3).Text

            If (dt.Rows.Count > 0) Then
                TxtID.Text = 1
                fecha2 = dt.Rows(0)("Fecha").ToString()
                TxtQQEnt.Text = dt.Rows(0)("QQ").ToString()
                TxtPrecio.Text = dt.Rows(0)("PRECIO_QQ").ToString()

                TxtDia.SelectedValue = fecha2.Day
                TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno.SelectedValue = fecha2.Year
            Else
                TxtID.Text = 0
                fecha2 = Now
                TxtDia.SelectedValue = fecha2.Day
                TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno.SelectedValue = fecha2.Year

                TxtQQEnt.Text = 0
                TxtPrecio.Text = 0
            End If



            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)

        End If

        'If (e.CommandName = "Eliminar") Then
        '    Dim gvrow As GridViewRow = GridDatos.Rows(index)

        '    Dim Str As String = "SELECT * FROM cafe_entregas_fortalecidas WHERE  id='" & HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString & "' "
        '    Dim adap As New MySqlDataAdapter(Str, conn)
        '    Dim dt As New DataTable
        '    adap.Fill(dt)

        '    TxtID.Text = dt.Rows(0)("id").ToString()

        '    Label1.Text = "¿Esta seguro que desea eliminar la entrega?"
        '    BConfirm.Visible = False

        '    BBorrarsi.Visible = True
        '    BBorrarno.Visible = True

        '    ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        'End If
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

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtID.Text = 0) Then
            Sql = "INSERT INTO cafecomp19_20opsfert (COD_ORGANIZACION,EXPORTADOR,QQ,PRECIO_QQ,Fecha) VALUES (@COD_ORGANIZACION,@EXPORTADOR,@QQ,@PRECIO_QQ,@Fecha) "

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOrg.Text)
            cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtExp.Text)
            cmd2.Parameters.AddWithValue("@QQ", TxtQQEnt.Text)
            cmd2.Parameters.AddWithValue("@PRECIO_QQ", TxtPrecio.Text)
            cmd2.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))


            cmd2.ExecuteNonQuery()
            conex.Close()

            'Label1.Text = "El compromiso a nivel de organizacion ha sido actualizado"
        Else
            Sql = "UPDATE cafecomp19_20opsfert SET QQ=@QQ,PRECIO_QQ=@PRECIO_QQ,Fecha=@Fecha WHERE COD_ORGANIZACION='" & TxtCodOrg.Text & "' AND EXPORTADOR='" & TxtExp.Text & "' "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@QQ", TxtQQEnt.Text)
            cmd2.Parameters.AddWithValue("@PRECIO_QQ", TxtPrecio.Text)
            cmd2.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))

            cmd2.ExecuteNonQuery()
            conex.Close()

            'Label1.Text = "El compromiso a nivel de organizacion ha sido guardado"
        End If

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        Label1.Text = "La entrega ha sido guardada"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click


        Dim Str As String = "SELECT * FROM `cafecomp19_20opsconv` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtOrg.SelectedValue & "' "
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

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub
End Class