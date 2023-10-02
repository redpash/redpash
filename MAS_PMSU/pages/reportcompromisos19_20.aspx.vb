Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class reportcompromisos19_20
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString

    Dim crystalReport As New ReportDocument()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcomboexp()
                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenagrid()
            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If


    End Sub

    Private Sub llenarcomboexp()

        StrCombo = "SELECT DISTINCT EXPORTADOR FROM `mas+cafecomp19_20resumen2` ORDER BY EXPORTADOR"


        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtExportador.DataSource = DtCombo
        TxtExportador.DataValueField = DtCombo.Columns(0).ToString()
        TxtExportador.DataTextField = DtCombo.Columns(0).ToString()
        TxtExportador.DataBind()
    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY ec_nombre "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `mas+cafecomp19_20resumen2` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' and ec_codigo = '" & TxtEntrenador.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()
    End Sub
    Protected Sub TxtExportador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtExportador.SelectedIndexChanged
        llenarcomboDepto()
        llenarcomboEntrenador()
        llenarcomboOP()
        llenagrid()
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

    Sub llenagrid()


        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,QQ_PS " +
            "FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,QQ_PS " +
                "FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,QQ_PS " +
                    "FROM `mas+cafecomp19_20resumen2` WHERE  EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,Muni_Descripcion,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,EXPORTADOR,QQ_PS " +
                    "FROM `mas+cafecomp19_20resumen2` WHERE  EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                End If
            End If
        End If

        GridDatos.DataBind()

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
    Private Sub cargarreporte()
        Dim DatSet As New BDCrystal

        Dim stropsres, strprod, strops, strprodno As String

        If TxtDepto.SelectedValue = "00" Then
            stropsres = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' "
            strprod = "SELECT * FROM `mas+cafecomp19_20prod` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' "
            strops = "SELECT * FROM `mas+cafecomp19_20ops` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' "
            strprodno = "SELECT * FROM `mas+cafecomp19_20prodno` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                stropsres = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' "
                strprod = "SELECT * FROM `mas+cafecomp19_20prod` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' "
                strops = "SELECT * FROM `mas+cafecomp19_20ops` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' "
                strprodno = "SELECT * FROM `mas+cafecomp19_20prodno` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' "

            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    stropsres = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' "
                    strprod = "SELECT * FROM `mas+cafecomp19_20prod` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' "
                    strops = "SELECT * FROM `mas+cafecomp19_20ops` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' "
                    strprodno = "SELECT * FROM `mas+cafecomp19_20prodno` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' "
                Else
                    stropsres = "SELECT * FROM `mas+cafecomp19_20resumen2` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' "
                    strprod = "SELECT * FROM `mas+cafecomp19_20prod` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' "
                    strops = "SELECT * FROM `mas+cafecomp19_20ops` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' "
                    strprodno = "SELECT * FROM `mas+cafecomp19_20prodno` WHERE EXPORTADOR='" & TxtExportador.SelectedValue & "' AND Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' "

                End If
            End If
        End If

        Dim sdaopsres = New MySqlDataAdapter(stropsres, conn3)
        Dim sdaprod = New MySqlDataAdapter(strprod, conn3)
        Dim sdaops = New MySqlDataAdapter(strops, conn3)
        Dim sdaprodno = New MySqlDataAdapter(strprodno, conn3)

        sdaopsres.Fill(DatSet, "mas_cafecomp19_20resumen2")
        sdaprod.Fill(DatSet, "mas_cafecomp19_20prod")
        sdaops.Fill(DatSet, "mas_cafecomp19_20ops")
        sdaprodno.Fill(DatSet, "mas_cafecomp19_20prodno")


        crystalReport.Load(Server.MapPath("~/pages/CRCompromisosOPS.rpt"))
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
End Class