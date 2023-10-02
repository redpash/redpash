Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Public Class compromisosopsasen18_19
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString

    Dim sentencia, identity As String
    Dim filt As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then

                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenarcomboexp()
                llenagrid()
                llenagrid3()
                llenagrid4()
                'llenarcomboexp()
                'divexp.Visible = False

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+registro_ops2` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `mas+registro_ops2` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY ec_nombre "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `mas+registro_ops2` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' and ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()
    End Sub
    Private Sub llenarcomboexp()
        Dim StrCombo As String = "SELECT ' Todos' as Nom1 UNION SELECT DISTINCT Nom1 FROM `exportadores` ORDER BY Nom1"

        If (cmborganizacion.SelectedValue = "00") Then
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

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
            "FROM `mas+cafecomp18_19nprod` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then

                Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                "FROM `mas+cafecomp18_19nprod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                    "FROM `mas+cafecomp18_19nprod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                Else
                    If (TxtExportador.SelectedValue = " Todos") Then
                        Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                        "FROM `mas+cafecomp18_19nprod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                    Else
                        BAgregar.Visible = True

                        Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                        "FROM `mas+cafecomp18_19nprod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                    End If

                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub
    Sub llenagrid2()

        'If (GridDatos.Rows.Count = 0) Then
        Me.SqlDataSource2.SelectCommand = "SELECT COD_PRODUCTOR,NOMBRE,SEXO,EDAD,ID_PARTIDA " +
       " FROM `masp_productores` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY NOMBRE "
        'Else
        '    pasarcodin()

        '    Me.SqlDataSource2.SelectCommand = "SELECT COD_PRODUCTOR,NOMBRE,SEXO,EDAD,ID_PARTIDA " +
        '    " FROM `masp_productores` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND COD_PRODUCTOR NOT IN (" & TxtIn.Text & ") ORDER BY NOMBRE "
        'End If

        GridDatos2.DataBind()
    End Sub
    Sub llenagrid3()
        BAgregar2.Visible = False

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
            "FROM `mas+cafecomp18_19nops` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then

                Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                "FROM `mas+cafecomp18_19nops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                    "FROM `mas+cafecomp18_19nops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    If (TxtExportador.SelectedValue = " Todos") Then
                        Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                        "FROM `mas+cafecomp18_19nops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                    Else
                        BAgregar2.Visible = True

                        Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
                        "FROM `mas+cafecomp18_19nops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                    End If

                End If
            End If
        End If

        GridDatos3.DataBind()

    End Sub
    Sub llenagrid4()
        'BAgregar3.Visible = False
        'BRegistrar.Visible = False


        'If TxtDepto.SelectedValue = "00" Then
        '    Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '    "FROM `mas+cafecomp18_19nprodno` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        'Else
        '    If TxtEntrenador.SelectedValue = "00" Then

        '        Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '        "FROM `mas+cafecomp18_19nprodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '    Else
        '        If (cmborganizacion.SelectedValue = "00") Then
        '            Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '            "FROM `mas+cafecomp18_19nprodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '        Else
        '            If (TxtExportador.SelectedValue = " Todos") Then
        '                Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp18_19nprodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            Else
        '                BAgregar3.Visible = True
        '                BRegistrar.Visible = True

        '                Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp18_19nprodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            End If

        '        End If
        '    End If
        'End If

        'GridDatos4.DataBind()

    End Sub
    Sub llenagrid5()

        'If (GridDatos4.Rows.Count = 0) Then
        Me.SqlDataSource5.SelectCommand = "SELECT IDENTIDAD,NOMBRE,SEXO,EDAD " +
       " FROM `registronoprodcomp` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND Eliminado IS NULL ORDER BY NOMBRE "
        'Else
        '    pasarcodin2()

        '    Me.SqlDataSource5.SelectCommand = "SELECT IDENTIDAD,NOMBRE,SEXO,EDAD " +
        '    " FROM `registronoprodcomp` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND Eliminado IS NULL AND IDENTIDAD NOT IN (" & TxtIn.Text & ") ORDER BY NOMBRE "
        'End If

        GridDatos5.DataBind()
    End Sub
    Private Sub pasarcodin()

        Dim cadena1, cadena2 As String

        TxtIn.Text = ""

        For Each row2 As GridViewRow In GridDatos.Rows
            TxtIn.Text = TxtIn.Text + "'" + row2.Cells(4).Text + "'" + ","
        Next

        cadena1 = TxtIn.Text
        cadena2 = cadena1.Substring(0, cadena1.Length - 1)

        TxtIn.Text = cadena2

    End Sub
    Private Sub pasarcodin2()

        Dim cadena1, cadena2 As String

        TxtIn.Text = ""

        For Each row2 As GridViewRow In GridDatos4.Rows
            TxtIn.Text = TxtIn.Text + "'" + row2.Cells(4).Text + "'" + ","
        Next

        cadena1 = TxtIn.Text
        cadena2 = cadena1.Substring(0, cadena1.Length - 1)

        TxtIn.Text = cadena2

    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboEntrenador()
        llenarcomboOP()
        llenarcomboexp()
        llenagrid()
        llenagrid3()
        llenagrid4()
    End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        llenarcomboOP()
        llenarcomboexp()
        llenagrid()
        llenagrid3()
        llenagrid4()
    End Sub
    Protected Sub cmborganizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmborganizacion.SelectedIndexChanged
        llenarcomboexp()
        llenagrid()
        llenagrid3()
        llenagrid4()
    End Sub
    Protected Sub TxtExportador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtExportador.SelectedIndexChanged
        llenagrid()
        llenagrid3()
        llenagrid4()
    End Sub

    Protected Sub cambioindexdepto(ByVal sender As Object, ByVal e As EventArgs)
        'llenarcombotemas()
        filt = False
        'revisarmod(TxtID.Text)
    End Sub
    Private Sub exportar()
        Dim query As String = ""

        If TxtEntrenador.SelectedValue = "00" Then
            query = "SELECT * FROM `ops_capacitaciones_web_parti`  ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
        Else
            If (cmborganizacion.SelectedValue = "00") Then
                query = "SELECT * FROM `ops_capacitaciones_web_parti` WHERE asesor_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "
            Else
                query = "SELECT * FROM `ops_capacitaciones_web_parti` WHERE asesor_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,asesor_nombre,OP_NOMBRE "

            End If
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

    Protected Sub GridDatos3_DataBound(sender As Object, ByVal e As EventArgs) Handles GridDatos3.DataBound

        If (GridDatos3.Rows.Count > 0) Then
            ' Recupera la el PagerRow...
            Dim pagerRow2 As GridViewRow = GridDatos3.BottomPagerRow
            ' Recupera los controles DropDownList y label...
            Dim pageList2 As DropDownList = CType(pagerRow2.Cells(0).FindControl("PageDropDownList2"), DropDownList)
            Dim pageLabel2 As Label = CType(pagerRow2.Cells(0).FindControl("CurrentPageLabel2"), Label)
            If Not pageList2 Is Nothing Then
                ' Se crean los valores del DropDownList tomando el número total de páginas... 
                Dim i As Integer
                For i = 0 To GridDatos3.PageCount - 1
                    ' Se crea un objeto ListItem para representar la �gina...
                    Dim pageNumber2 As Integer = i + 1
                    Dim item2 As ListItem = New ListItem(pageNumber2.ToString())
                    If i = GridDatos3.PageIndex Then
                        item2.Selected = True
                    End If
                    ' Se añade el ListItem a la colección de Items del DropDownList...
                    pageList2.Items.Add(item2)
                Next i
            End If
            If Not pageLabel2 Is Nothing Then
                ' Calcula el nº de �gina actual...
                Dim currentPage2 As Integer = GridDatos3.PageIndex + 1
                ' Actualiza el Label control con la �gina actual.
                pageLabel2.Text = "Página " & currentPage2.ToString() & " de " & GridDatos3.PageCount.ToString()
            End If
        End If
        'e As EventArgs

    End Sub
    Protected Sub GridDatos4_DataBound(sender As Object, ByVal e As EventArgs) Handles GridDatos4.DataBound

        If (GridDatos4.Rows.Count > 0) Then
            ' Recupera la el PagerRow...
            Dim pagerRow3 As GridViewRow = GridDatos4.BottomPagerRow
            ' Recupera los controles DropDownList y label...
            Dim pageList3 As DropDownList = CType(pagerRow3.Cells(0).FindControl("PageDropDownList3"), DropDownList)
            Dim pageLabel3 As Label = CType(pagerRow3.Cells(0).FindControl("CurrentPageLabel3"), Label)
            If Not pageList3 Is Nothing Then
                ' Se crean los valores del DropDownList tomando el número total de páginas... 
                Dim i As Integer
                For i = 0 To GridDatos4.PageCount - 1
                    ' Se crea un objeto ListItem para representar la �gina...
                    Dim pageNumber3 As Integer = i + 1
                    Dim item3 As ListItem = New ListItem(pageNumber3.ToString())
                    If i = GridDatos4.PageIndex Then
                        item3.Selected = True
                    End If
                    ' Se añade el ListItem a la colección de Items del DropDownList...
                    pageList3.Items.Add(item3)
                Next i
            End If
            If Not pageLabel3 Is Nothing Then
                ' Calcula el nº de �gina actual...
                Dim currentPage3 As Integer = GridDatos4.PageIndex + 1
                ' Actualiza el Label control con la �gina actual.
                pageLabel3.Text = "Página " & currentPage3.ToString() & " de " & GridDatos3.PageCount.ToString()
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
    Protected Sub PageDropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow2 As GridViewRow = GridDatos3.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList2 As DropDownList = CType(pagerRow2.Cells(0).FindControl("PageDropDownList2"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos3.PageIndex = pageList2.SelectedIndex
        llenagrid3()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub
    Protected Sub PageDropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow3 As GridViewRow = GridDatos4.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList3 As DropDownList = CType(pagerRow3.Cells(0).FindControl("PageDropDownList3"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos4.PageIndex = pageList3.SelectedIndex
        llenagrid()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub
    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "AgregarComp") Then

            ChNuevo.Checked = False

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp18_19nprod` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("Id").ToString()

            If (dt.Rows(0)("COMPBLANCO").ToString() = 1) Then
                TxtNom.Text = dt.Rows(0)("NOMBRE").ToString()
                TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtClave.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo.SelectedIndex = 2
                TxtComp.Text = dt.Rows(0)("COMPROMISO").ToString()
            Else
                TxtNom.Text = dt.Rows(0)("NOMBRE").ToString()
                TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtClave.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo.SelectedValue = dt.Rows(0)("TIPO_CAFE").ToString()
                TxtComp.Text = dt.Rows(0)("COMPROMISO").ToString()

            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
        End If

        If (e.CommandName = "Eliminar") Then
            TxtID.Text = 0
            TxtID2.Text = 0
            TxtID3.Text = 0

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM cafecomp18_19nprod WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("Id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar el compromiso al productor?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If

    End Sub
    Protected Sub GridDatos3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos3.RowCommand

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "AgregarComp2") Then
            'MsgBox("entro")
            Dim gvrow As GridViewRow = GridDatos3.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp18_19nops` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID2.Text = dt.Rows(0)("Id").ToString()

            TxtNomOrg.Text = dt.Rows(0)("OP_NOMBRE").ToString()
            TxtExport2.Text = dt.Rows(0)("EXPORTADOR").ToString()
            TxtTipo2.SelectedValue = dt.Rows(0)("TIPO_CAFE").ToString()
            TxtComp2.Text = dt.Rows(0)("COMPROMISO").ToString()

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal2').modal('show'); });", True)
        End If

        If (e.CommandName = "Eliminar2") Then
            TxtID.Text = 0
            TxtID2.Text = 0
            TxtID3.Text = 0

            Dim gvrow As GridViewRow = GridDatos3.Rows(index)

            Dim Str As String = "SELECT * FROM cafecomp18_19nops WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID2.Text = dt.Rows(0)("Id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar el compromiso a la OP?"
            BConfirm.Visible = False

            BBorrarsi.Visible = True
            BBorrarno.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
        End If

    End Sub
    Protected Sub GridDatos4_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos4.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "AgregarComp3") Then

            ChNuevo.Checked = False

            Dim gvrow As GridViewRow = GridDatos4.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp18_19nprodno` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID3.Text = dt.Rows(0)("Id").ToString()

            If (dt.Rows(0)("COMPBLANCO").ToString() = 1) Then
                TxtNom2.Text = dt.Rows(0)("NOMBRE").ToString()
                'TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtClave2.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport3.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo3.SelectedIndex = 2
                TxtComp3.Text = dt.Rows(0)("COMPROMISO").ToString()
            Else
                TxtNom2.Text = dt.Rows(0)("NOMBRE").ToString()
                'TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtClave2.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport3.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo3.SelectedValue = dt.Rows(0)("TIPO_CAFE").ToString()
                TxtComp3.Text = dt.Rows(0)("COMPROMISO").ToString()

            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal3').modal('show'); });", True)
        End If

        If (e.CommandName = "Eliminar3") Then
            TxtID.Text = 0
            TxtID2.Text = 0
            TxtID3.Text = 0

            Dim gvrow As GridViewRow = GridDatos4.Rows(index)

            Dim Str As String = "SELECT * FROM cafecomp18_19nprodno WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID3.Text = dt.Rows(0)("Id").ToString()

            Label1.Text = "¿Esta seguro que desea eliminar el compromiso al productor no antendido?"
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

                Sql = "INSERT INTO cafecomp18_19nprod (COD_PRODUCTOR,COD_ORGANIZACION,EXPORTADOR,COMPROMISO,IDENTIDAD,COMPBLANCO,FECHA) VALUES (@COD_PRODUCTOR,@COD_ORGANIZACION,@EXPORTADOR,0,@IDENTIDAD,1,now()) "
                cmd2.Connection = conex
                cmd2.CommandText = Sql

                cmd2.Parameters.AddWithValue("@COD_PRODUCTOR", HttpUtility.HtmlDecode(row.Cells(1).Text))
                cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
                cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtExportador.SelectedValue)
                cmd2.Parameters.AddWithValue("@IDENTIDAD", HttpUtility.HtmlDecode(row.Cells(5).Text))

                cmd2.ExecuteNonQuery()
                conex.Close()

            End If
        Next
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub SqlDataSource3_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource3.Selected

        lblTotalClientes2.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub SqlDataSource4_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource4.Selected

        lblTotalClientes3.Text = e.AffectedRows.ToString()

    End Sub
    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        ChNuevo.Checked = True

        llenagrid2()

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)
    End Sub
    Protected Sub BAgregar2_Click(sender As Object, e As EventArgs) Handles BAgregar2.Click
        TxtID2.Text = 0
        TxtNomOrg.Text = cmborganizacion.SelectedItem.Text
        TxtExport2.Text = TxtExportador.SelectedValue
        TxtTipo2.SelectedIndex = 2
        TxtComp2.Text = 0.0


        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal2').modal('show'); });", True)


    End Sub
    Protected Sub BAgregar3_Click(sender As Object, e As EventArgs) Handles BAgregar3.Click

        llenagrid5()

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#NoProdModalList').modal('show'); });", True)
    End Sub
    Protected Sub BRegistrar_Click(sender As Object, e As EventArgs) Handles BRegistrar.Click
        TxtIdentidad.Text = ""
        TxtNombre.Text = ""
        TxtEdad.Text = 0
        TxtSexo.SelectedIndex = 0
        TxtTelefono.Text = 0
        TxtCargo.SelectedIndex = 0

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#NoProdModal').modal('show'); });", True)


    End Sub
    Protected Sub BGuardar2_Click(sender As Object, e As EventArgs) Handles BGuardar2.Click
        guardarprod()

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        Label1.Text = "Los productores han sido seleccionados"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", False)
    End Sub
    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click

        Dim conex As New MySqlConnection(conn3)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()


        Sql = "UPDATE cafecomp18_19nprod SET IDENTIDAD=@IDENTIDAD,TIPO_CAFE=@TIPO_CAFE,COMPROMISO=@COMPROMISO,CLAVE_IHCAFE=@CLAVE_IHCAFE,FECHA=now(),COMPBLANCO=0 WHERE Id=" & TxtID.Text & " "
        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@IDENTIDAD", TxtIden.Text)
        cmd2.Parameters.AddWithValue("@CLAVE_IHCAFE", TxtClave.Text)
        cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo.SelectedValue)
        cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()
        conex.Close()

        Label1.Text = "El compromiso ha sido guardado"

        llenagrid()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

    Protected Sub BGuardar3_Click(sender As Object, e As EventArgs) Handles BGuardar3.Click

        Dim conex As New MySqlConnection(conn3)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtID2.Text > 0) Then
            Sql = "UPDATE cafecomp18_19nops SET COMPROMISO=@COMPROMISO,TIPO_CAFE=@TIPO_CAFE,FECHA=now() WHERE Id=" & TxtID2.Text & " "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp2.Text)
            cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo2.SelectedValue)

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "El compromiso a nivel de organizacion ha sido actualizado"
        Else
            Sql = "INSERT INTO cafecomp18_19nops (COD_ORGANIZACION,EXPORTADOR,COMPROMISO,TIPO_CAFE,FECHA) VALUES (@COD_ORGANIZACION,@EXPORTADOR,@COMPROMISO,@TIPO_CAFE,now()) "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
            cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtExportador.SelectedValue)
            cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp2.Text)
            cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo2.SelectedValue)

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "El compromiso a nivel de organizacion ha sido guardado"
        End If

        llenagrid3()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub
    Protected Sub BGuardar4_Click(sender As Object, e As EventArgs) Handles BGuardar4.Click

        Dim conex As New MySqlConnection(conn3)
        Dim Sql As String

        conex.Open()
        Dim cmd2 As New MySqlCommand()

        Sql = "INSERT INTO registronoprodcomp (COD_ORGANIZACION,IDENTIDAD,NOMBRE,SEXO,EDAD,TELEFONO,CARGO,FECHA) VALUES (@COD_ORGANIZACION,@IDENTIDAD,@NOMBRE,@SEXO,@EDAD,@TELEFONO,@CARGO,now()) "
        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
        cmd2.Parameters.AddWithValue("@IDENTIDAD", TxtIdentidad.Text)
        cmd2.Parameters.AddWithValue("@NOMBRE", TxtNombre.Text)
        cmd2.Parameters.AddWithValue("@SEXO", TxtSexo.SelectedValue)
        cmd2.Parameters.AddWithValue("@EDAD", TxtEdad.Text)
        cmd2.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text)
        cmd2.Parameters.AddWithValue("@CARGO", TxtCargo.SelectedValue)

        cmd2.ExecuteNonQuery()
        conex.Close()

        Label1.Text = "El productor ha sido registrado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub
    Protected Sub BGuardar5_Click(sender As Object, e As EventArgs) Handles BGuardar5.Click
        Dim conex As New MySqlConnection(conn3)
        Dim Sql As String
        Dim cmd As New MySqlCommand()

        For Each row As GridViewRow In GridDatos5.Rows
            Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar2"), CheckBox)

            If check.Checked Then

                conex.Open()
                Dim cmd2 As New MySqlCommand()

                Sql = "INSERT INTO cafecomp18_19nprodno (ID_PRODUCTOR,COD_ORGANIZACION,EXPORTADOR,COMPROMISO,IDENTIDAD,COMPBLANCO,FECHA) VALUES (@ID_PRODUCTOR,@COD_ORGANIZACION,@EXPORTADOR,0,@IDENTIDAD,1,now()) "
                cmd2.Connection = conex
                cmd2.CommandText = Sql

                cmd2.Parameters.AddWithValue("@ID_PRODUCTOR", HttpUtility.HtmlDecode(row.Cells(1).Text))
                cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", cmborganizacion.SelectedValue)
                cmd2.Parameters.AddWithValue("@EXPORTADOR", TxtExportador.SelectedValue)
                cmd2.Parameters.AddWithValue("@IDENTIDAD", HttpUtility.HtmlDecode(row.Cells(1).Text))

                cmd2.ExecuteNonQuery()
                conex.Close()

            End If
        Next

        llenagrid4()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        Label1.Text = "Los productores han sido seleccionados"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub
    Protected Sub BGuardar6_Click(sender As Object, e As EventArgs) Handles BGuardar6.Click

        Dim conex As New MySqlConnection(conn3)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()


        Sql = "UPDATE cafecomp18_19nprodno SET TIPO_CAFE=@TIPO_CAFE,COMPROMISO=@COMPROMISO,CLAVE_IHCAFE=@CLAVE_IHCAFE,FECHA=now(),COMPBLANCO=0 WHERE Id=" & TxtID3.Text & " "
        cmd2.Connection = conex
        cmd2.CommandText = Sql


        cmd2.Parameters.AddWithValue("@CLAVE_IHCAFE", TxtClave2.Text)
        cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo3.SelectedValue)
        cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp3.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()
        conex.Close()

        Label1.Text = "El compromiso ha sido guardado"

        llenagrid4()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub
    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn3)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = " "
        If (TxtID.Text > 0) Then
            Sql = "UPDATE cafecomp18_19nprod SET Eliminado=1  WHERE Id=" & TxtID.Text & " "
            'llenagrid()
        End If

        If (TxtID2.Text > 0) Then
            Sql = "UPDATE cafecomp18_19nops SET Eliminado=1  WHERE Id=" & TxtID2.Text & " "
            'llenagrid3()
        End If

        If (TxtID3.Text > 0) Then
            Sql = "UPDATE cafecomp18_19nprodno SET Eliminado=1  WHERE Id=" & TxtID3.Text & " "
            'llenagrid4()
        End If


        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()



        Label1.Text = "El compromiso ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

        llenagrid()
        llenagrid3()
        llenagrid4()

    End Sub

    'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    '    exportar()
    'End Sub


End Class