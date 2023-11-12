Imports System.IO
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class Ventas
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then

            Else
                llenarcomboCiclo()
                llenarcomboDepto()
                llenagrid()
            End If
        End If


    End Sub

    Private Sub llenarcomboCiclo()
        Dim StrCombo As String = "SELECT * FROM redpash_ciclo"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TxtCiclo.DataSource = DtCombo
        TxtCiclo.DataValueField = DtCombo.Columns(0).ToString()
        TxtCiclo.DataTextField = DtCombo.Columns(1).ToString
        TxtCiclo.DataBind()
        Dim newitem As New ListItem(" ", " ")
        TxtCiclo.Items.Insert(0, newitem)
    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT * FROM tb_departamentos"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(2).ToString
        TxtDepto.DataBind()
        Dim newitem As New ListItem(" ", " ")
        TxtDepto.Items.Insert(0, newitem)
    End Sub

    Private Sub llenarcomboProductor()
        If TxtDepto.SelectedItem.Text <> " " Then
            Dim StrCombo As String = "SELECT DISTINCT Productor FROM bcs_inscripcion_senasa WHERE Departamento = @nombre ORDER BY Productor ASC"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", TxtDepto.SelectedItem.Text)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)
            TxtProductor.DataSource = DtCombo
            TxtProductor.DataValueField = "Productor"
            TxtProductor.DataTextField = "Productor"
            TxtProductor.DataBind()
            Dim newitem As New ListItem(" ", " ")
            TxtProductor.Items.Insert(0, newitem)
        End If
        If TxtDepto.SelectedItem.Text = " " Then
            TxtProductor.SelectedValue = " "
        End If
    End Sub

    Sub llenagrid()
        'import.Visible = False

        Dim cadena As String = "ID, Departamento, Productor, Tipo_cultivo, CATEGORIA, CICLO, VARIEDAD, NOMBRE_LOTE_FINCA, AREA_SEMBRADA_MZ, AREA_SEMBRADA_HA, DATE_FORMAT(FECHA_SIEMBRA, '%d-%m-%Y') AS FECHA_SIEMBRA, ESTIMADO_PRO_QQ_MZ, ESTIMADO_PRO_QQ_HA, Habilitado"

        If (DDL_cultivo.SelectedItem.Text = " ") Then
            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Estado = '1' ORDER BY Departamento,Productor,CICLO "
        Else
            If (DDL_Categ.SelectedItem.Text = " ") Then
                Me.SqlDataSource1.SelectCommand = " SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
            Else
                If (TxtCiclo.SelectedItem.Text = " ") Then
                    Me.SqlDataSource1.SelectCommand = " SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                Else
                    If (TxtDepto.SelectedItem.Text = " ") Then
                        Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                    Else
                        If (TxtProductor.SelectedItem.Text = " ") Then
                            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Departamento= '" & TxtDepto.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                        Else
                            Me.SqlDataSource1.SelectCommand = "SELECT " & cadena & " FROM bcs_inscripcion_senasa where Tipo_cultivo = '" & DDL_cultivo.SelectedItem.Text & "' AND CATEGORIA = '" & DDL_Categ.SelectedItem.Text & "' AND CICLO = '" & TxtCiclo.SelectedItem.Text & "' AND Departamento= '" & TxtDepto.SelectedItem.Text & "' AND Productor = '" & TxtProductor.SelectedItem.Text & "' AND Estado = '1' ORDER BY Departamento,Productor,CICLO "
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Protected Sub DDL_cultivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_cultivo.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub DDL_Categ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_Categ.SelectedIndexChanged
        llenagrid()
    End Sub
    Protected Sub TxtCiclo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCiclo.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboProductor()
        llenagrid()
    End Sub

    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()
    End Sub

    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        'Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT COSTOS_INSUMOS, COSTOS_INSCRIPCION, COSTOS_MANO, COSTOS_OTROS, COSTOS_ACONDICIONAMIENTO_SEMILLA, COSTOS_EQUIPO,COSTO_TOTAL, Habilitado, check_costo FROM `bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

        End If
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

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Private Sub llenarVAIDAD_CICLO()

    End Sub

    Protected Sub limpiarFiltros(sender As Object, e As EventArgs)
        Response.Redirect("ProduccionCostes.aspx")
    End Sub
    Private Function FileUploadToBytes(fileUpload As FileUpload) As Byte()
        Using stream As System.IO.Stream = fileUpload.PostedFile.InputStream
            Dim length As Integer = fileUpload.PostedFile.ContentLength
            Dim bytes As Byte() = New Byte(length - 1) {}
            stream.Read(bytes, 0, length)
            Return bytes
        End Using
    End Function


    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Dim rptdocument As New ReportDocument
        Dim productor As String = TxtProductor.SelectedItem.Text
        Dim ciclo As String = TxtCiclo.SelectedItem.Text
        'nombre de dataset
        Dim ds As New DataSet1
        Dim Str As String = "Select * FROM vista_inscripcion_senasa_lote WHERE Productor = '" & productor & "' AND CICLO = '" & ciclo & "'"
        Dim adap As New MySqlDataAdapter(Str, conn)
        Dim dt As New DataTable

        ' Nombre de la vista del dataset
        adap.Fill(ds, "vista_inscripcion_senasa_lote")

        Dim nombre As String
        nombre = "Solicitud Inscripcion de Lote o Campo _" + Today
        rptdocument.Load(Server.MapPath("~/pages/CrystalReport3.rpt"))
        rptdocument.SetDataSource(ds)

        ' Usar un HashSet para almacenar municipios únicos
        Dim municipiosUnicos As New HashSet(Of String)()

        For Each row As DataRow In ds.Tables("vista_inscripcion_senasa_lote").Rows
            If Not IsDBNull(row("Municipio")) Then
                municipiosUnicos.Add(row("Municipio").ToString())
            End If
        Next

        ' Convertir el HashSet en una cadena separada por comas
        Dim MunicipiosConcatenados As String = String.Join(", ", municipiosUnicos)

        rptdocument.SetParameterValue("CadenaMunicipios", MunicipiosConcatenados)

        Response.Buffer = False
        Response.ClearContent()
        Response.ClearHeaders()

        rptdocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, True, nombre)

        Response.End()
    End Sub

End Class