Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Imports System.Linq
Imports System.Data.OleDb
Public Class detplanilla
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("TConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString

    Dim sentencia, identity As String
    Dim filt As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If User.Identity.IsAuthenticated = True Then
        If (Not IsPostBack) Then
            llenarcomboOP()
            'llenagrid()
        End If
        'Else
        '    Response.Redirect(String.Format("~/pages/login.aspx"))
        'End If

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
        Dim StrCombo As String = "SELECT ' Seleccione una planilla' as PLANILLA UNION SELECT DISTINCT PLANILLA FROM `planilla` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn3)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(0).ToString()
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
        'BAgregar.Visible = False
        'import.Visible = False

        'If TxtDepto.SelectedValue = "00" Then
        'Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_codigo,ec_nombre,'' as Entrenamientos FROM entrenadores" +
        '" INNER JOIN departamentos ON departamentos.Depto_Cod = entrenadores.ec_departamento " +
        '"WHERE entrenadores.ec_activo = 1 ORDER BY Depto_Descripcion,ec_nombre"
        '    If TxtEntrenador.SelectedValue = "00" Then

        '        Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO,FINAN_FERTILIZANTE " +
        '        "FROM `mas+cafecomp19_20prod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '    Else
        '        If (cmborganizacion.SelectedValue = "00") Then
        '            Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO,FINAN_FERTILIZANTE " +
        '            "FROM `mas+cafecomp19_20prod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '        Else
        '            If (TxtExportador.SelectedValue = " Todos") Then
        '                Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO,FINAN_FERTILIZANTE " +
        '                "FROM `mas+cafecomp19_20prod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            Else
        '                BAgregar.Visible = True
        '                import.Visible = True

        '                Me.SqlDataSource1.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,COD_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO,FINAN_FERTILIZANTE " +
        '                "FROM `mas+cafecomp19_20prod` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            End If

        '        End If
        '    End If
        'End If

        'GridDatos.DataBind()

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
        'BAgregar2.Visible = False

        'If TxtDepto.SelectedValue = "00" Then
        '    Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '    "FROM `mas+cafecomp19_20ops` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        'Else
        '    If TxtEntrenador.SelectedValue = "00" Then

        '        Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '        "FROM `mas+cafecomp19_20ops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        '    Else
        '        If (cmborganizacion.SelectedValue = "00") Then
        '            Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '            "FROM `mas+cafecomp19_20ops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        '        Else
        '            If (TxtExportador.SelectedValue = " Todos") Then
        '                Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp19_20ops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        '            Else
        '                BAgregar2.Visible = True

        '                Me.SqlDataSource3.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp19_20ops` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        '            End If

        '        End If
        '    End If
        'End If

        'GridDatos3.DataBind()

    End Sub
    Sub llenagrid4()
        'BAgregar3.Visible = False
        'BRegistrar.Visible = False


        'If TxtDepto.SelectedValue = "00" Then
        '    Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '    "FROM `mas+cafecomp19_20prodno` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        'Else
        '    If TxtEntrenador.SelectedValue = "00" Then

        '        Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '        "FROM `mas+cafecomp19_20prodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '    Else
        '        If (cmborganizacion.SelectedValue = "00") Then
        '            Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '            "FROM `mas+cafecomp19_20prodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '        Else
        '            If (TxtExportador.SelectedValue = " Todos") Then
        '                Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp19_20prodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            Else
        '                BAgregar3.Visible = True
        '                BRegistrar.Visible = True

        '                Me.SqlDataSource4.SelectCommand = "SELECT Id as id,Depto_Descripcion,ec_nombre,OP_NOMBRE,ID_PRODUCTOR,NOMBRE,TIPO_CAFE,EXPORTADOR,COMPROMISO " +
        '                "FROM `mas+cafecomp19_20prodno` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        '            End If

        '        End If
        '    End If
        'End If

        'GridDatos4.DataBind()

    End Sub
    Sub llenagrid5()

        ' 'If (GridDatos4.Rows.Count = 0) Then
        ' Me.SqlDataSource5.SelectCommand = "SELECT IDENTIDAD,NOMBRE,SEXO,EDAD " +
        '" FROM `registronoprodcomp` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND Eliminado IS NULL ORDER BY NOMBRE "
        ' 'Else
        ' '    pasarcodin2()

        ' '    Me.SqlDataSource5.SelectCommand = "SELECT IDENTIDAD,NOMBRE,SEXO,EDAD " +
        ' '    " FROM `registronoprodcomp` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' AND Eliminado IS NULL AND IDENTIDAD NOT IN (" & TxtIn.Text & ") ORDER BY NOMBRE "
        ' 'End If

        ' GridDatos5.DataBind()
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
        'exportar2()
        'llenagrid()
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

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20prod` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("Id").ToString()
            TxtTabla.Text = dt.Rows(0)("TABLA").ToString()

            If (dt.Rows(0)("COMPBLANCO").ToString() = 1) Then
                TxtNom.Text = dt.Rows(0)("NOMBRE").ToString()
                TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtRTN.Text = dt.Rows(0)("RTN").ToString()
                TxtClave.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo.SelectedIndex = 2
                TxtComp.Text = dt.Rows(0)("COMPROMISO").ToString()
            Else
                TxtNom.Text = dt.Rows(0)("NOMBRE").ToString()
                TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtRTN.Text = dt.Rows(0)("RTN").ToString()
                TxtClave.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo.SelectedValue = dt.Rows(0)("TIPO_CAFE").ToString()
                TxtComp.Text = dt.Rows(0)("COMPROMISO").ToString()

            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditModal').modal('show'); });", True)
        End If
        If (e.CommandName = "AgregarFin") Then
            ChNuevo.Checked = False

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20prod` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtTabla.Text = dt.Rows(0)("TABLA").ToString()
            TxtID4.Text = dt.Rows(0)("Id").ToString()


            TxtNom3.Text = dt.Rows(0)("NOMBRE").ToString()
            TxtAreatotal.Text = dt.Rows(0)("AREA_TOTAL").ToString()
            TxtAreaproduccion.Text = dt.Rows(0)("AREA_PRODUCCION").ToString()
            TxtAreaplantilla.Text = dt.Rows(0)("AREA_PLANTILLA").ToString()
            TxtQQPROD.Text = dt.Rows(0)("QQPROD_18-19").ToString()
            TxtQQESTIM.Text = dt.Rows(0)("QQESTIM_19-20").ToString()
            TxtQQFERT.Text = dt.Rows(0)("QQ_FERT_PLANTIA").ToString()
            TxtQQFERT2.Text = dt.Rows(0)("QQ_FERT_MANTENIMIENTO").ToString()
            TxtQQFERT3.Text = dt.Rows(0)("QQ_FERT_PRE-CORTE").ToString()
            TxtGAN1.SelectedValue = dt.Rows(0)("GAR_SOLIDARIA").ToString()
            TxtGAN2.SelectedValue = dt.Rows(0)("GAR_PRENDARIA").ToString()
            TxtGAN3.SelectedValue = dt.Rows(0)("GAR_HIPOTECARIA").ToString()



            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#EditFin').modal('show'); });", True)
        End If

        If (e.CommandName = "Eliminar") Then
            TxtID.Text = 0
            TxtID2.Text = 0
            TxtID3.Text = 0

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20prod` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = dt.Rows(0)("Id").ToString()
            TxtTabla.Text = dt.Rows(0)("TABLA").ToString()

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

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20ops` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
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

            Dim Str As String = "SELECT * FROM cafecomp19_20ops WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
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

            Dim Str As String = "SELECT * FROM `mas+cafecomp19_20prodno` WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn3)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID3.Text = dt.Rows(0)("Id").ToString()

            If (dt.Rows(0)("COMPBLANCO").ToString() = 1) Then
                TxtNom2.Text = dt.Rows(0)("NOMBRE").ToString()
                'TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtRTN2.Text = dt.Rows(0)("RTN").ToString()
                TxtClave2.Text = dt.Rows(0)("CLAVE_IHCAFE").ToString()
                TxtExport3.Text = dt.Rows(0)("EXPORTADOR").ToString()
                TxtTipo3.SelectedIndex = 2
                TxtComp3.Text = dt.Rows(0)("COMPROMISO").ToString()
            Else
                TxtNom2.Text = dt.Rows(0)("NOMBRE").ToString()
                'TxtIden.Text = dt.Rows(0)("IDENTIDAD").ToString()
                TxtRTN2.Text = dt.Rows(0)("RTN").ToString()
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

            Dim Str As String = "SELECT * FROM cafecomp19_20prodno WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
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

                Sql = "INSERT INTO cafecomp19_20prod (COD_PRODUCTOR,COD_ORGANIZACION,EXPORTADOR,COMPROMISO,IDENTIDAD,COMPBLANCO,FECHA,AREA_TOTAL,AREA_PRODUCCION,AREA_PLANTILLA,ES_QQPROD,ES_QQESTIM,SFERT,GFERT_GF_QQFERT,GFERT_GF2_QQFERT2,GFERT_GF2_QQFERT3,GAR_SOLIDARIA,GAR_PRENDARIA,GAR_HIPOTECARIA,SOTROFIN,FIN_TESTER,FIN_SECADORAS,FIN_DESP,FIN_HERRAMIENTAS) VALUES (@COD_PRODUCTOR,@COD_ORGANIZACION,@EXPORTADOR,0,@IDENTIDAD,1,now(),0,0,0,0,0,'NO',0,0,0,'NO','NO','NO','NO',0,0,0,0) "
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
        Dim conex2 As New MySqlConnection(conn)

        conex.Open()
        conex2.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtTabla.Text = "ODK") Then
            Sql = "UPDATE cafe_compromisos_19_20_v2_prod SET DET2_QQCOM=@DET2_QQCOM WHERE _URI='" & TxtID.Text & "' "
            cmd2.Connection = conex2
            cmd2.CommandText = Sql


            cmd2.Parameters.AddWithValue("@DET2_QQCOM", TxtComp.Text)
        Else
            Sql = "UPDATE cafecomp19_20prod SET IDENTIDAD=@IDENTIDAD,RTN=@RTN,TIPO_CAFE=@TIPO_CAFE,COMPROMISO=@COMPROMISO,CLAVE_IHCAFE=@CLAVE_IHCAFE,FECHA=now(),COMPBLANCO=0 WHERE Id=" & TxtID.Text & " "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@IDENTIDAD", TxtIden.Text)
            cmd2.Parameters.AddWithValue("@RTN", TxtRTN.Text)
            cmd2.Parameters.AddWithValue("@CLAVE_IHCAFE", TxtClave.Text)
            cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo.SelectedValue)
            cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp.Text)

        End If


        cmd2.ExecuteNonQuery()

        conex2.Close()
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
            Sql = "UPDATE cafecomp19_20ops SET COMPROMISO=@COMPROMISO,TIPO_CAFE=@TIPO_CAFE,FECHA=now() WHERE Id=" & TxtID2.Text & " "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@COMPROMISO", TxtComp2.Text)
            cmd2.Parameters.AddWithValue("@TIPO_CAFE", TxtTipo2.SelectedValue)

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "El compromiso a nivel de organizacion ha sido actualizado"
        Else
            Sql = "INSERT INTO cafecomp19_20ops (COD_ORGANIZACION,EXPORTADOR,COMPROMISO,TIPO_CAFE,FECHA) VALUES (@COD_ORGANIZACION,@EXPORTADOR,@COMPROMISO,@TIPO_CAFE,now()) "
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

                Sql = "INSERT INTO cafecomp19_20prodno (ID_PRODUCTOR,COD_ORGANIZACION,EXPORTADOR,COMPROMISO,IDENTIDAD,COMPBLANCO,FECHA) VALUES (@ID_PRODUCTOR,@COD_ORGANIZACION,@EXPORTADOR,0,@IDENTIDAD,1,now()) "
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


        Sql = "UPDATE cafecomp19_20prodno SET TIPO_CAFE=@TIPO_CAFE,COMPROMISO=@COMPROMISO,RTN=@RTN,CLAVE_IHCAFE=@CLAVE_IHCAFE,FECHA=now(),COMPBLANCO=0 WHERE Id=" & TxtID3.Text & " "
        cmd2.Connection = conex
        cmd2.CommandText = Sql


        cmd2.Parameters.AddWithValue("@RTN", TxtRTN2.Text)
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
    Protected Sub BGuardar7_Click(sender As Object, e As EventArgs) Handles BGuardar7.Click

        Dim conex As New MySqlConnection(conn3)
        Dim conex2 As New MySqlConnection(conn)


        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        conex.Open()
        conex2.Open()

        If (TxtTabla.Text = "ODK") Then
            Sql = "UPDATE cafe_compromisos_19_20_v2_prod SET ES_QQPROD=@ES_QQPROD,ES_QQESTIM=@ES_QQESTIM,GFERT_GF_QQFERT=@GFERT_GF_QQFERT,GFERT_GF2_QQFERT2=@GFERT_GF2_QQFERT2,GFERT_GF2_QQFERT3=@GFERT_GF2_QQFERT3,GAR_SOLIDARIA=@GAR_SOLIDARIA,GAR_PRENDARIA=@GAR_PRENDARIA,GAR_HIPOTECARIA=@GAR_HIPOTECARIA WHERE _URI='" & TxtID4.Text & "' "
            cmd2.Connection = conex2
            cmd2.CommandText = Sql
        Else
            Sql = "UPDATE cafecomp19_20prod SET AREA_TOTAL=@AREA_TOTAL,AREA_PRODUCCION=@AREA_PRODUCCION,AREA_PLANTILLA=@AREA_PLANTILLA,ES_QQPROD=@ES_QQPROD,ES_QQESTIM=@ES_QQESTIM,GFERT_GF_QQFERT=@GFERT_GF_QQFERT,GFERT_GF2_QQFERT2=@GFERT_GF2_QQFERT2,GFERT_GF2_QQFERT3=@GFERT_GF2_QQFERT3,GAR_SOLIDARIA=@GAR_SOLIDARIA,GAR_PRENDARIA=@GAR_PRENDARIA,GAR_HIPOTECARIA=@GAR_HIPOTECARIA WHERE Id=" & TxtID4.Text & " "
            cmd2.Connection = conex
            cmd2.CommandText = Sql
        End If

        cmd2.Parameters.AddWithValue("@AREA_TOTAL", TxtAreatotal.Text)
        cmd2.Parameters.AddWithValue("@AREA_PRODUCCION", TxtAreaproduccion.Text)
        cmd2.Parameters.AddWithValue("@AREA_PLANTILLA", TxtAreaplantilla.Text)
        cmd2.Parameters.AddWithValue("@ES_QQPROD", TxtQQPROD.Text)
        cmd2.Parameters.AddWithValue("@ES_QQESTIM", TxtQQESTIM.Text)
        cmd2.Parameters.AddWithValue("@GFERT_GF_QQFERT", TxtQQFERT.Text)
        cmd2.Parameters.AddWithValue("@GFERT_GF2_QQFERT2", TxtQQFERT2.Text)
        cmd2.Parameters.AddWithValue("@GFERT_GF2_QQFERT3", TxtQQFERT3.Text)
        cmd2.Parameters.AddWithValue("@GAR_SOLIDARIA", TxtGAN1.SelectedValue)
        cmd2.Parameters.AddWithValue("@GAR_PRENDARIA", TxtGAN2.SelectedValue)
        cmd2.Parameters.AddWithValue("@GAR_HIPOTECARIA", TxtGAN3.SelectedValue)

        cmd2.ExecuteNonQuery()
        conex.Close()
        conex2.Close()

        Label1.Text = "El financiamiento ha sido guardado"

        llenagrid4()

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn3)
        Dim conex2 As New MySqlConnection(conn)

        conex.Open()
        conex2.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = " "
        If (TxtID.Text <> "0") Then
            If (TxtTabla.Text = "ODK") Then
                Sql = "UPDATE cafe_compromisos_19_20_v2_prod SET Eliminado=1  WHERE _URI='" & TxtID.Text & "' "

                cmd.Connection = conex2
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            Else
                Sql = "UPDATE cafecomp19_20prod SET Eliminado=1  WHERE Id=" & TxtID.Text & " "

                cmd.Connection = conex
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If

            'llenagrid()
        End If

        If (TxtID2.Text > 0) Then
            Sql = "UPDATE cafecomp19_20ops SET Eliminado=1  WHERE Id=" & TxtID2.Text & " "
            cmd.Connection = conex
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
            'llenagrid3()
        End If

        If (TxtID3.Text > 0) Then
            Sql = "UPDATE cafecomp19_20prodno SET Eliminado=1  WHERE Id=" & TxtID3.Text & " "
            'llenagrid4()

            cmd.Connection = conex
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
        End If

        conex.Close()
        conex2.Close()

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
    Private Sub exportar()
        Dim query, query2 As String

        query = "SELECT * FROM `mas+cafecomp19_20prodimp` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "'  AND EXPORTADOR='" & TxtExportador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        query2 = " SELECT '-1' AS Id,Depto_Cod,Depto_Descripcion,Muni_Descripcion,Aldea_Descripcion,Caserio_Descripcion,COD_PRODUCTOR,NOMBRE,SEXO,CARGO_OP,COD_ORGANIZACION,OP_NOMBRE,ec_codigo,ec_nombre,CADENA,ID_PARTIDA AS IDENTIDAD,'S/D' AS RTN,'S/D' AS CLAVE_IHCAFE,'' AS EXPORTADOR,'PS' AS TIPO_CAFE,0.00 AS COMPROMISO,0.00 AS AREA_TOTAL,0.00 AS AREA_PRODUCCION,0.00 AS AREA_PLANTILLA,0.00 AS `QQPROD_18-19`,0.00 AS `QQESTIM_19-20`,0.00 AS QQ_FERT_PLANTIA,0.00 AS QQ_FERT_MANTENIMIENTO,0.00 AS `QQ_FERT_PRE-CORTE`,'NO' AS GAR_SOLIDARIA,'NO' AS GAR_PRENDARIA,'NO' AS GAR_HIPOTECARIA FROM `masp_productores` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY NOMBRE "

        'Using con As New MySqlConnection(conn3)
        '    Using cmd As New MySqlCommand(query)
        Dim con As New MySqlConnection(conn)
        Dim con3 As New MySqlConnection(conn3)

        Dim cmd As New MySqlCommand()
        Dim cmd2 As New MySqlCommand()

        Dim sda As New MySqlDataAdapter()
        Dim sda2 As New MySqlDataAdapter()

        Using ds As New DataSet()
            cmd.CommandText = query
            cmd.Connection = con3
            sda.SelectCommand = cmd

            cmd2.CommandText = query2
            cmd2.Connection = con
            sda2.SelectCommand = cmd2

            sda.Fill(ds, "mas+cafecomp19_20prodimp")
            sda2.Fill(ds, "masp_productores")

            'ds.Tables(0).TableName = "mas+cafecomp19_20prodimp"
            'ds.Tables(1).TableName = "masp_productores"

            If (ds.Tables("mas+cafecomp19_20prodimp").Rows.Count > 0) Then

                For Each Fila As DataRow In ds.Tables("masp_productores").Rows

                    For Each Fila2 As DataRow In ds.Tables("mas+cafecomp19_20prodimp").Rows
                        If Fila2.Item("COD_PRODUCTOR").ToString() = Fila.Item("COD_PRODUCTOR").ToString() Then
                            Fila.SetField("Id", Fila2.Item("Id").ToString())

                            Fila.SetField("IDENTIDAD", Fila2.Item("IDENTIDAD").ToString())
                            Fila.SetField("RTN", Fila2.Item("RTN").ToString())
                            Fila.SetField("CLAVE_IHCAFE", Fila2.Item("CLAVE_IHCAFE").ToString())

                            Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
                            Fila.SetField("TIPO_CAFE", "PS")
                            Fila.SetField("COMPROMISO", Fila2.Item("COMPROMISO"))
                            Fila.SetField("AREA_TOTAL", Fila2.Item("AREA_TOTAL"))
                            Fila.SetField("AREA_PRODUCCION", Fila2.Item("AREA_PRODUCCION"))
                            Fila.SetField("AREA_PLANTILLA", Fila2.Item("AREA_PLANTILLA"))
                            Fila.SetField("QQPROD_18-19", Fila2.Item("QQPROD_18-19"))
                            Fila.SetField("QQESTIM_19-20", Fila2.Item("QQESTIM_19-20"))
                            Fila.SetField("QQ_FERT_PLANTIA", Fila2.Item("QQ_FERT_PLANTIA"))
                            Fila.SetField("QQ_FERT_MANTENIMIENTO", Fila2.Item("QQ_FERT_MANTENIMIENTO"))
                            Fila.SetField("QQ_FERT_PRE-CORTE", Fila2.Item("QQ_FERT_PRE-CORTE"))

                            Fila.SetField("GAR_SOLIDARIA", Fila2.Item("GAR_SOLIDARIA").ToString())
                            Fila.SetField("GAR_PRENDARIA", Fila2.Item("GAR_PRENDARIA").ToString())
                            Fila.SetField("GAR_HIPOTECARIA", Fila2.Item("GAR_HIPOTECARIA").ToString())
                        Else
                            Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
                            Fila.SetField("TIPO_CAFE", "PS")
                        End If

                    Next
                Next
            Else
                For Each Fila As DataRow In ds.Tables("masp_productores").Rows

                    Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
                    Fila.SetField("TIPO_CAFE", "PS")

                Next
            End If


            Using wb As New XLWorkbook()
                'For Each dt As DataTable In ds.Tables
                'Add DataTable as Worksheet.
                wb.Worksheets.Add(ds.Tables("masp_productores"))
                'Next

                'Export the Excel file.
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;filename=mas+cafecomp19_20import" & Today & ".xlsx")
                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(Response.OutputStream)
                    Response.Flush()
                    Response.End()
                End Using
            End Using
        End Using

        '    End Using
        'End Using
    End Sub
    Private Sub exportar2()

        Dim fecha1, fecha2 As Date


        Dim Str As String = "SELECT * FROM `planilla` WHERE  PLANILLA='" & cmborganizacion.SelectedValue & "' "
        Dim adap As New MySqlDataAdapter(Str, conn3)
        Dim dt As New DataTable
        adap.Fill(dt)

        fecha1 = dt.Rows(0)("Fecha_Ini").ToString()
        fecha2 = dt.Rows(0)("Fecha_Fin").ToString()

        Dim query, query2 As String

        query = "select `odk_bd`.`entrenamientos_2019_core`.`_URI` AS `_URI`,`odk_bd`.`entrenamientos_2019_prod`.`_URI` AS `_URI2`,`odk_bd`.`entrenamientos_2019_core`.`_CREATION_DATE` AS `FECHA_ENVIO`,`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO` AS `FECHA_MODULO`,concat_ws('-',(case when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'January') then '01-Enero' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'February') then '02-Febrero' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'March') then '03-Marzo' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'April') then '04-Abril' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'May') then '05-Mayo' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'June') then '06-Junio' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'July') then '07-Julio' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'August') then '08-Agosto' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'September') then '09-Septiembre' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'October') then '10-Octubre' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'November') then '11-Noviembre' when (monthname(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`) = 'December') then '12-Diciembre' else 'N/A' end),year(`odk_bd`.`entrenamientos_2019_core`.`FECHA_MODULO`)) AS `FECHA2`,`odk_bd`.`entrenamientos_2019_core`.`CODIGO_MODULO` AS `CODIGO_MODULO`,`odk_masp`.`modulos`.`mod_nombre` AS `NOMBRE_MODULO`,`odk_bd`.`entrenamientos_2019_core`.`CODIGO_ECA` AS `CODIGO_ECA`,`mas+registro_ecas3`.`NOM_PRODUCTOR` AS `NOM_PRODUCTOR_ECA`,`mas+registro_ecas3`.`AREA` AS `AREA`,`mas+registro_ecas3`.`LATITUD` AS `LATITUD`,`mas+registro_ecas3`.`LONGITUD` AS `LONGITUD`,`odk_bd`.`masp_productores`.`Depto_Cod` AS `Depto_Cod`,`odk_bd`.`masp_productores`.`Depto_Descripcion` AS `Depto_Descripcion`,`odk_bd`.`masp_productores`.`Muni_Descripcion` AS `Muni_Descripcion`,`odk_bd`.`masp_productores`.`Aldea_Descripcion` AS `Aldea_Descripcion`,`odk_bd`.`masp_productores`.`Caserio_Descripcion` AS `Caserio_Descripcion`,`odk_bd`.`entrenamientos_2019_prod`.`COD_PRODUCTOR` AS `COD_PRODUCTOR`,`odk_bd`.`masp_productores`.`NOMBRE` AS `NOM_PRODUCTOR`,`odk_bd`.`masp_productores`.`FECHA_NACIMIENTO` AS `FECHA_NACIMIENTO`,`odk_bd`.`masp_productores`.`EDAD` AS `EDAD`,`odk_bd`.`masp_productores`.`CARGO_OP` AS `CARGO_OP`,`odk_bd`.`masp_productores`.`CODIGO_FAM` AS `CODIGO_FAM`,`odk_bd`.`masp_productores`.`TELEFONO_PROPIO` AS `TELEFONO_PROPIO`,`odk_bd`.`masp_productores`.`TELEFONO_ADICIONAL` AS `TELEFONO_ADICIONAL`,`odk_bd`.`masp_productores`.`SEXO` AS `SEXO`,`odk_bd`.`masp_productores`.`ID_PARTIDA` AS `ID_PARTIDA`,`odk_bd`.`masp_productores`.`SABE_LEER` AS `SABE_LEER`,`odk_bd`.`masp_productores`.`COD_ORGANIZACION` AS `COD_ORGANIZACION`,`odk_bd`.`masp_productores`.`OP_NOMBRE` AS `OP_NOMBRE`,`odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC` AS `ec_codigo`,`odk_masp`.`entrenadores`.`ec_nombre` AS `ec_nombre`,`odk_masp`.`modulos`.`mod_cadena` AS `CADENA`,`mas+registro_ecas3`.`ALTURA` AS `ALTURA`,`odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC` AS `CODIGO_EC`,`odk_masp`.`departamentos`.`Depto_Descripcion` AS `Depto_EC`,'MAS2' AS `PROYECTO` from ((((((`odk_bd`.`entrenamientos_2019_core` join `odk_bd`.`entrenamientos_2019_prod` on((`odk_bd`.`entrenamientos_2019_core`.`_URI` = `odk_bd`.`entrenamientos_2019_prod`.`_PARENT_AURI`))) join `odk_masp`.`modulos` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_MODULO` = `odk_masp`.`modulos`.`mod_codigo`))) left join `odk_bd`.`mas+registro_ecas3` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_ECA` = `mas+registro_ecas3`.`CODIGO_ECA`))) left join `odk_bd`.`masp_productores` on((`odk_bd`.`entrenamientos_2019_prod`.`COD_PRODUCTOR` = `odk_bd`.`masp_productores`.`COD_PRODUCTOR`))) left join `odk_masp`.`entrenadores` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC` = `odk_masp`.`entrenadores`.`ec_codigo`))) join `odk_masp`.`departamentos` on((`odk_masp`.`entrenadores`.`ec_departamento` = `odk_masp`.`departamentos`.`Depto_Cod`))) " +
        "WHERE (isnull(`odk_bd`.`entrenamientos_2019_prod`.`Eliminado`)) AND (entrenamientos_2019_core._CREATION_DATE BETWEEN '" & fecha1.Year.ToString + "-" + fecha1.Month.ToString + "-" + fecha1.Day.ToString & "' and '" & fecha2.Year.ToString + "-" + fecha2.Month.ToString + "-" + fecha2.Day.ToString & "') "
        query2 = " Select '-1' AS Id,Depto_Cod,Depto_Descripcion,Muni_Descripcion,Aldea_Descripcion,Caserio_Descripcion,COD_PRODUCTOR,NOMBRE,SEXO,CARGO_OP,COD_ORGANIZACION,OP_NOMBRE,ec_codigo,ec_nombre,CADENA,ID_PARTIDA AS IDENTIDAD,'S/D' AS RTN,'S/D' AS CLAVE_IHCAFE,'' AS EXPORTADOR,'PS' AS TIPO_CAFE,0.00 AS COMPROMISO,0.00 AS AREA_TOTAL,0.00 AS AREA_PRODUCCION,0.00 AS AREA_PLANTILLA,0.00 AS `QQPROD_18-19`,0.00 AS `QQESTIM_19-20`,0.00 AS QQ_FERT_PLANTIA,0.00 AS QQ_FERT_MANTENIMIENTO,0.00 AS `QQ_FERT_PRE-CORTE`,'NO' AS GAR_SOLIDARIA,'NO' AS GAR_PRENDARIA,'NO' AS GAR_HIPOTECARIA FROM `masp_productores` WHERE COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY NOMBRE "

        'Using con As New MySqlConnection(conn3)
        '    Using cmd As New MySqlCommand(query)
        Dim con As New MySqlConnection(conn)
        Dim con3 As New MySqlConnection(conn3)

        Dim cmd As New MySqlCommand()
        Dim cmd2 As New MySqlCommand()

        Dim sda As New MySqlDataAdapter()
        Dim sda2 As New MySqlDataAdapter()

        Using ds As New DataSet()
            cmd.CommandText = query
            cmd.Connection = con3
            sda.SelectCommand = cmd

            cmd2.CommandText = query2
            cmd2.Connection = con
            sda2.SelectCommand = cmd2

            sda.Fill(ds, "entrenamientos")
            sda2.Fill(ds, "masp_productores")

            MsgBox("Total:" + ds.Tables("entrenamientos").Rows.Count.ToString)
            'ds.Tables(0).TableName = "mas+cafecomp19_20prodimp"
            'ds.Tables(1).TableName = "masp_productores"

            'If (ds.Tables("mas+cafecomp19_20prodimp").Rows.Count > 0) Then

            '    For Each Fila As DataRow In ds.Tables("masp_productores").Rows

            '        For Each Fila2 As DataRow In ds.Tables("mas+cafecomp19_20prodimp").Rows
            '            If Fila2.Item("COD_PRODUCTOR").ToString() = Fila.Item("COD_PRODUCTOR").ToString() Then
            '                Fila.SetField("Id", Fila2.Item("Id").ToString())

            '                Fila.SetField("IDENTIDAD", Fila2.Item("IDENTIDAD").ToString())
            '                Fila.SetField("RTN", Fila2.Item("RTN").ToString())
            '                Fila.SetField("CLAVE_IHCAFE", Fila2.Item("CLAVE_IHCAFE").ToString())

            '                Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
            '                Fila.SetField("TIPO_CAFE", "PS")
            '                Fila.SetField("COMPROMISO", Fila2.Item("COMPROMISO"))
            '                Fila.SetField("AREA_TOTAL", Fila2.Item("AREA_TOTAL"))
            '                Fila.SetField("AREA_PRODUCCION", Fila2.Item("AREA_PRODUCCION"))
            '                Fila.SetField("AREA_PLANTILLA", Fila2.Item("AREA_PLANTILLA"))
            '                Fila.SetField("QQPROD_18-19", Fila2.Item("QQPROD_18-19"))
            '                Fila.SetField("QQESTIM_19-20", Fila2.Item("QQESTIM_19-20"))
            '                Fila.SetField("QQ_FERT_PLANTIA", Fila2.Item("QQ_FERT_PLANTIA"))
            '                Fila.SetField("QQ_FERT_MANTENIMIENTO", Fila2.Item("QQ_FERT_MANTENIMIENTO"))
            '                Fila.SetField("QQ_FERT_PRE-CORTE", Fila2.Item("QQ_FERT_PRE-CORTE"))

            '                Fila.SetField("GAR_SOLIDARIA", Fila2.Item("GAR_SOLIDARIA").ToString())
            '                Fila.SetField("GAR_PRENDARIA", Fila2.Item("GAR_PRENDARIA").ToString())
            '                Fila.SetField("GAR_HIPOTECARIA", Fila2.Item("GAR_HIPOTECARIA").ToString())
            '            Else
            '                Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
            '                Fila.SetField("TIPO_CAFE", "PS")
            '            End If

            '        Next
            '    Next
            'Else
            '    For Each Fila As DataRow In ds.Tables("masp_productores").Rows

            '        Fila.SetField("EXPORTADOR", TxtExportador.SelectedValue)
            '        Fila.SetField("TIPO_CAFE", "PS")

            '    Next
            'End If


            'Using wb As New XLWorkbook()
            '    'For Each dt As DataTable In ds.Tables
            '    'Add DataTable as Worksheet.
            '    wb.Worksheets.Add(ds.Tables("masp_productores"))
            '    'Next

            '    'Export the Excel file.
            '    Response.Clear()
            '    Response.Buffer = True
            '    Response.Charset = ""
            '    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            '    Response.AddHeader("content-disposition", "attachment;filename=mas+cafecomp19_20import" & Today & ".xlsx")
            '    Using MyMemoryStream As New MemoryStream()
            '        wb.SaveAs(MyMemoryStream)
            '        MyMemoryStream.WriteTo(Response.OutputStream)
            '        Response.Flush()
            '        Response.End()
            '    End Using
            'End Using
        End Using

        '    End Using
        'End Using
    End Sub
    Protected Sub BDescarga_Click(sender As Object, e As EventArgs) Handles BDescarga.Click
        Dim ds As New DataSet()
        Dim fecha1, fecha2 As Date


        Dim Str As String = "SELECT * FROM `planilla` WHERE  PLANILLA='" & cmborganizacion.SelectedValue & "' "
        Dim adap As New MySqlDataAdapter(Str, conn3)
        Dim dt As New DataTable
        adap.Fill(dt)

        fecha1 = dt.Rows(0)("Fecha_Ini").ToString()
        fecha2 = dt.Rows(0)("Fecha_Fin").ToString()

        Dim Str2 As String = "Select Depto_Descripcion,ec_codigo,ec_nombre,'' as Entrenamientos FROM entrenadores " +
        "INNER JOIN departamentos ON departamentos.Depto_Cod = entrenadores.ec_departamento " +
        "WHERE entrenadores.ec_activo = 1 ORDER BY Depto_Descripcion,ec_nombre "
        Dim adap2 As New MySqlDataAdapter(Str2, conn3)
        Dim dt2 As New DataTable

        adap2.Fill(ds, "Entrenamientos")

        For Each Fila As DataRow In ds.Tables("Entrenamientos").Rows
            'Fila.SetField("CLAVE_IHCAFE", Fila.Item("CLAVE_IHCAFE").ToString())

            Dim Str3 As String = Str = "SELECT Count(entrenamientos_2019_prod.COD_PRODUCTOR) as `ENTRENADOS` " +
             "FROM entrenamientos_2019_core INNER JOIN entrenamientos_2019_prod ON entrenamientos_2019_core._URI = entrenamientos_2019_prod._PARENT_AURI " +
             "WHERE entrenamientos_2019_prod.Eliminado IS NULL AND entrenamientos_2019_core.CODIGO_EC = '" & Fila.Item("ec_codigo").ToString() & "' AND (entrenamientos_2019_core._CREATION_DATE BETWEEN '" & fecha1.Year.ToString + "-" + fecha1.Month.ToString + "-" + fecha1.Day.ToString & "' and '" & fecha2.Year.ToString + "-" + fecha2.Month.ToString + "-" + fecha2.Day.ToString & "') " +
             "GROUP BY entrenamientos_2019_core.CODIGO_EC "
            Dim adap3 As New MySqlDataAdapter(Str3, conn3)
            Dim dt3 As New DataTable

            adap3.Fill(dt3)

            If (dt3.Rows.Count > 0) Then
                Fila.SetField("Entrenamientos", dt.Rows(0)("ENTRENADOS").ToString())
                MsgBox("encontro")
            Else
                Fila.SetField("Entrenamientos", 0)
            End If

        Next

        GridDatos.DataSource = ds.Tables("Entrenamientos")
        GridDatos.DataBind()

        'For Each row As GridViewRow In GridDatos.Rows


        '    'Str = "select COUNT(`odk_bd`.`entrenamientos_2019_prod`.`COD_PRODUCTOR`) AS `ENTRENADOS` from ((((((`odk_bd`.`entrenamientos_2019_core` join `odk_bd`.`entrenamientos_2019_prod` on((`odk_bd`.`entrenamientos_2019_core`.`_URI` = `odk_bd`.`entrenamientos_2019_prod`.`_PARENT_AURI`))) join `odk_masp`.`modulos` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_MODULO` = `odk_masp`.`modulos`.`mod_codigo`))) left join `odk_bd`.`mas+registro_ecas3` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_ECA` = `mas+registro_ecas3`.`CODIGO_ECA`))) left join `odk_bd`.`masp_productores` on((`odk_bd`.`entrenamientos_2019_prod`.`COD_PRODUCTOR` = `odk_bd`.`masp_productores`.`COD_PRODUCTOR`))) left join `odk_masp`.`entrenadores` on((`odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC` = `odk_masp`.`entrenadores`.`ec_codigo`))) join `odk_masp`.`departamentos` on((`odk_masp`.`entrenadores`.`ec_departamento` = `odk_masp`.`departamentos`.`Depto_Cod`))) " +
        '    ' "WHERE (isnull(`odk_bd`.`entrenamientos_2019_prod`.`Eliminado`)) AND (entrenamientos_2019_core._CREATION_DATE BETWEEN '" & fecha1.Year.ToString + "-" + fecha1.Month.ToString + "-" + fecha1.Day.ToString & "' and '" & fecha2.Year.ToString + "-" + fecha2.Month.ToString + "-" + fecha2.Day.ToString & "') AND (`odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC`='" & HttpUtility.HtmlDecode(row.Cells(1).Text) & "')  GROUP BY `odk_bd`.`entrenamientos_2019_core`.`CODIGO_EC`"

        '    'adap = New MySqlDataAdapter(Str, conn3)
        '    'adap.Fill(dt)

        '    'If (dt.Rows.Count > 0) Then
        '    '    row.Cells(3).Text = dt.Rows(0)("ENTRENADOS").ToString()
        '    'Else
        '    row.Cells(3).Text = 0
        '    'End If

        'Next
        'exportar()
    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)

        Dim conStr As String = ""

        Select Case Extension

            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                Exit Select

            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                Exit Select

        End Select

        conStr = String.Format(conStr, FilePath, isHDR)



        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()


        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()


        'Bind Data to GridView
        GridView1.Caption = Path.GetFileName(FilePath)
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub
    Protected Sub BCarga_Click(sender As Object, e As EventArgs) Handles BCarga.Click


    End Sub

End Class