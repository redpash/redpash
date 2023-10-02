Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class reportcompromisosops19_20
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString

    Dim sentencia, identity As String
    Dim filt As Boolean

    Dim crystalReport As New ReportDocument()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then

                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboexp()
                llenagrid()

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, ' Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `departamentos` ORDER BY Depto_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboDepto2()
        Dim StrCombo As String = "SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `departamentos` ORDER BY Depto_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto2.DataSource = DtCombo
        TxtDepto2.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto2.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto2.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as Muni_Cod,' Todos' as Muni_Descripcion UNION SELECT DISTINCT Muni_Cod,Muni_Descripcion FROM `municipios` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY Muni_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboMuni2()
        Dim StrCombo As String = "SELECT DISTINCT Muni_Cod,Muni_Descripcion FROM `municipios` WHERE Depto_Cod = '" & TxtDepto2.SelectedValue & "' ORDER BY Muni_Descripcion"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtMuni2.DataSource = DtCombo
        TxtMuni2.DataValueField = DtCombo.Columns(1).ToString()
        TxtMuni2.DataTextField = DtCombo.Columns(1).ToString()
        TxtMuni2.DataBind()
    End Sub
    Private Sub llenarcomboexp()
        Dim StrCombo As String = "SELECT ' Todos' as Nom1 UNION SELECT DISTINCT Nom1 FROM `exportadores` ORDER BY Nom1"

        If (TxtEntrenador.SelectedValue = "00") Then
            StrCombo = "SELECT ' Todos' as Nom1 UNION SELECT DISTINCT Nom1 FROM `exportadores` WHERE Id=-1 ORDER BY Nom1"
        End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtExportador.DataSource = DtCombo
        TxtExportador.DataValueField = DtCombo.Columns(0).ToString()
        TxtExportador.DataTextField = DtCombo.Columns(0).ToString()
        TxtExportador.DataBind()
    End Sub
    Sub llenagrid()
        BAgregar.Visible = False
        dexp.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,COMPROMISO " +
            "FROM `mas+cafecomp19_20resumenfirm` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,COMPROMISO " +
                "FROM `mas+cafecomp19_20resumenfirm` WHERE Depto_Firma='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (TxtExportador.SelectedValue = " Todos") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,COMPROMISO " +
                    "FROM `mas+cafecomp19_20resumenfirm` WHERE Depto_Firma='" & TxtDepto.SelectedValue & "' AND Muni_Firma='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    BAgregar.Visible = True
                    Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,COMPROMISO " +
                    "FROM `mas+cafecomp19_20resumenfirm` WHERE Depto_Firma='" & TxtDepto.SelectedValue & "' AND Muni_Firma='" & TxtEntrenador.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                End If
            End If
        End If

        GridDatos.DataBind()

        If (GridDatos.Rows.Count > 0 And TxtExportador.SelectedValue <> " Todos") Then
            dexp.Visible = True
        End If

    End Sub
    Sub llenagrid2()
        'MsgBox("ENTRO:" + TxtDepto2.SelectedValue.ToString + TxtMuni2.SelectedValue.ToString + TxtExportador.SelectedValue.ToString)


        If (GridDatos.Rows.Count = 0) Then
            Me.SqlDataSource2.SelectCommand = "SELECT COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,QQ_PS " +
            "FROM `mas+cafecomp19_20resumen2` WHERE  Depto_Cod='" & TxtDepto2.SelectedValue & "' AND Muni_Descripcion='" & TxtMuni2.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Else
            pasarcodin()

            Me.SqlDataSource2.SelectCommand = "SELECT COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,QQ_PS " +
            "FROM `mas+cafecomp19_20resumen2` WHERE  Depto_Cod='" & TxtDepto2.SelectedValue & "' AND Muni_Descripcion='" & TxtMuni2.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' AND COD_ORGANIZACION NOT IN (" & TxtIn.Text & ") ORDER BY OP_NOMBRE "
        End If

        GridDatos2.DataBind()
    End Sub
    Private Sub pasarcodin()

        Dim cadena1, cadena2 As String

        TxtIn.Text = ""

        For Each row2 As GridViewRow In GridDatos.Rows
            TxtIn.Text = TxtIn.Text + "'" + row2.Cells(3).Text + "'" + ","
        Next

        cadena1 = TxtIn.Text
        cadena2 = cadena1.Substring(0, cadena1.Length - 1)

        TxtIn.Text = cadena2

    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboEntrenador()
        llenarcomboexp()
        llenagrid()

    End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        llenarcomboexp()
        llenagrid()

    End Sub

    Protected Sub TxtExportador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtExportador.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub cambioindexdepto(ByVal sender As Object, ByVal e As EventArgs)
        llenarcomboMuni2()
        llenagrid2()
    End Sub
    Protected Sub cambioindexmuni(ByVal sender As Object, ByVal e As EventArgs)
        llenagrid2()
    End Sub
    Private Sub exportar()
        Dim query As String = ""

        If TxtEntrenador.SelectedValue = "00" Then
            query = "SELECT * FROM `ops_capacitaciones_web_parti`  ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
        Else
            'If (cmborganizacion.SelectedValue = "00") Then
            '    query = "SELECT * FROM `ops_capacitaciones_web_parti` WHERE asesor_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
            'Else
            '    query = "SELECT * FROM `ops_capacitaciones_web_parti` WHERE asesor_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "

            'End If
        End If

        'Autenticacion.descarga(User.Identity.Name, "ops_capacitaciones_web_parti")

        Using con As New MySqlConnection(conn)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "ops_capacitaciones_web_parti"

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
                            Response.AddHeader("content-disposition", "attachment;filename=ops_capacitaciones_web " & Today & ".xlsx")
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

    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Eliminar") Then


            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20resumenfirm` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("Id").ToString()


            Label1.Text = "¿Esta seguro que desea eliminar el compromiso?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If

    End Sub
    Private Sub guardarprod()
        Dim conex As New MySqlConnection(conn3)
        Dim Sql As String
        Dim cmd As New MySqlCommand()

        For Each row As GridViewRow In GridDatos2.Rows
            Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar"), CheckBox)

            If check.Checked Then

                conex.Open()
                Dim cmd2 As New MySqlCommand()

                Sql = "INSERT INTO cafecomp19_20xfirm (Depto_Firma,Muni_Firma,COD_ORGANIZACION,EXPORTADOR,COMPROMISO,FECHA) VALUES (@Depto_Firma,@Muni_Firma,@COD_ORGANIZACION,@EXPORTADOR,@COMPROMISO,now()) "
                cmd2.Connection = conex
                cmd2.CommandText = Sql

                cmd2.Parameters.AddWithValue("@Depto_Firma", TxtDepto.SelectedValue)
                cmd2.Parameters.AddWithValue("@Muni_Firma", TxtEntrenador.SelectedValue)
                cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", HttpUtility.HtmlDecode(row.Cells(1).Text))
                cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtExportador.SelectedValue)
                cmd2.Parameters.AddWithValue("@COMPROMISO", HttpUtility.HtmlDecode(row.Cells(4).Text))

                cmd2.ExecuteNonQuery()
                conex.Close()

            End If
        Next
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        'ChNuevo.Checked = True
        llenarcomboDepto2()
        llenarcomboMuni2()
        llenagrid2()

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)
    End Sub

    Protected Sub BGuardar2_Click(sender As Object, e As EventArgs) Handles BGuardar2.Click
        guardarprod()

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        Label1.Text = "Las organizaciones han sido seleccionadas"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", False)
    End Sub
    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn3)

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        conex.Open()
        Sql = "DELETE FROM cafecomp19_20xfirm WHERE Id=" & TxtID.Text & " "
        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()
        conex.Close()

        llenagrid()

        Label1.Text = "El compromiso ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Private Sub cargarreporte()
        Dim DatSet As New BDCrystal

        Dim stropsres, strprod, strops, strprodno As String

        stropsres = "SELECT * FROM `mas+cafecomp19_20resumenfirm` WHERE Depto_Firma='" & TxtDepto.SelectedValue & "' AND Muni_Firma='" & TxtEntrenador.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "

        Dim sdaopsres = New MySqlDataAdapter(stropsres, conn3)


        sdaopsres.Fill(DatSet, "mas_cafecomp19_20resumenfirm")


        crystalReport.Load(Server.MapPath("~/pages/CRCompromisosFirma.rpt"))
        crystalReport.SetDataSource(DatSet)

    End Sub
    Protected Sub BCargar_Click(sender As Object, e As EventArgs) Handles BCargar.Click
        cargarreporte()

        Dim formatType As ExportFormatType = ExportFormatType.NoFormat

        Select Case TxtTipo.SelectedItem.Value
            Case "WORD"
                formatType = ExportFormatType.WordForWindows
                Exit Select
            Case "PDF"
                formatType = ExportFormatType.PortableDocFormat
                Exit Select
            Case "EXCEL"
                formatType = ExportFormatType.Excel
                Exit Select
            Case "CSV"
                formatType = ExportFormatType.CharacterSeparatedValues
                Exit Select
            Case "RTF"
                formatType = ExportFormatType.EditableRTF
                Exit Select
        End Select


        crystalReport.ExportToHttpResponse(formatType, Response, True, "Crystal")
        Response.End()
    End Sub
    'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    '    exportar()
    'End Sub


End Class