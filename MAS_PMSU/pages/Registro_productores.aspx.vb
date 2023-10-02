Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Registro_productores
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                Dim Str As String = "SELECT * FROM usuariotns WHERE  Nombre='" & User.Identity.Name & "' "
                Dim adap As New MySqlDataAdapter(Str, conn)
                Dim dt As New DataTable
                adap.Fill(dt)

                txt_admin.Text = dt.Rows(0)("administrador").ToString()
                div_datos.Visible = True
                div_actualizar.Visible = False
                div_nuevo_prod.Visible = False
                llenarcomboDepto()
                llenarcombocaserio()
                llenarcomboaldea()
                llenarcombomunicipio()
                llenarcomboDepartamento()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenagrid()

                llenarcomboDepartamento_new()
                llenarcombomunicipio_new()
                llenarcomboaldea_new()
                llenarcombocaserio_new()

                llenarcomboEntrenador_new()
                llenarcomboOP_new()

                If txt_admin.Text = "SI" Then
                    div_admin.Visible = True
                Else
                    div_admin.Visible = False
                End If

                llenagridparticpantes()

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `productores+union` order by Depto_Cod "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub

    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as PROYECTO,' Todos' as  PROYECTO_NOM UNION SELECT DISTINCT PROYECTO, PROYECTO AS PROYECTO_NOM FROM `productores+union` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY PROYECTO "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub

    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `productores+union` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()
    End Sub

    Private Sub llenarcomboDepartamento()
        Dim StrCombo As String = "SELECT '00' as CODIGO_DEPARTAMENTO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_DEPARTAMENTO ,NOMBRE FROM tb_departamentos ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TXT_departamento_add.DataSource = DtCombo
        TXT_departamento_add.DataValueField = DtCombo.Columns(0).ToString()
        TXT_departamento_add.DataTextField = DtCombo.Columns(1).ToString()
        TXT_departamento_add.DataBind()
    End Sub

    Private Sub llenarcombomunicipio()
        Dim StrCombo As String = "SELECT '00' as CODIGO_MUNICIPIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_MUNICIPIO ,NOMBRE FROM tb_municipio where CODIGO_DEPARTAMENTO = '" & TXT_departamento_add.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TXT_municipio_add.DataSource = DtCombo
        TXT_municipio_add.DataValueField = DtCombo.Columns(0).ToString()
        TXT_municipio_add.DataTextField = DtCombo.Columns(1).ToString()
        TXT_municipio_add.DataBind()
    End Sub

    Private Sub llenarcomboaldea()
        Dim StrCombo As String = "SELECT '00' as CODIGO_ALDEA, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_ALDEA ,NOMBRE FROM tb_aldea where CODIGO_MUNICIPIO = '" & TXT_municipio_add.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TXT_aldea_add.DataSource = DtCombo
        TXT_aldea_add.DataValueField = DtCombo.Columns(0).ToString()
        TXT_aldea_add.DataTextField = DtCombo.Columns(1).ToString()
        TXT_aldea_add.DataBind()
    End Sub

    Private Sub llenarcombocaserio()
        Dim StrCombo As String = "SELECT '00' as CODIGO_CASERIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_CASERIO ,NOMBRE FROM tb_caserios where CODIGO_ALDEA = '" & TXT_aldea_add.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TXT_caserio_add.DataSource = DtCombo
        TXT_caserio_add.DataValueField = DtCombo.Columns(0).ToString()
        TXT_caserio_add.DataTextField = DtCombo.Columns(1).ToString()
        TXT_caserio_add.DataBind()
    End Sub

    'new formulario gb_llenar

    Private Sub llenarcomboDepartamento_new()
        Dim StrCombo As String = "SELECT '00' as CODIGO_DEPARTAMENTO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_DEPARTAMENTO ,NOMBRE FROM tb_departamentos ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_departamento_new.DataSource = DtCombo
        gb_departamento_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_departamento_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_departamento_new.DataBind()
    End Sub

    Private Sub llenarcombomunicipio_new()
        Dim StrCombo As String = "SELECT '00' as CODIGO_MUNICIPIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_MUNICIPIO ,NOMBRE FROM tb_municipio where CODIGO_DEPARTAMENTO = '" & gb_departamento_new.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_municipio_new.DataSource = DtCombo
        gb_municipio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_municipio_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_municipio_new.DataBind()
    End Sub

    Private Sub llenarcomboaldea_new()
        Dim StrCombo As String = "SELECT '00' as CODIGO_ALDEA, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_ALDEA ,NOMBRE FROM tb_aldea where CODIGO_MUNICIPIO = '" & gb_municipio_new.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_aldea_new.DataSource = DtCombo
        gb_aldea_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_aldea_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_aldea_new.DataBind()
    End Sub

    Private Sub llenarcombocaserio_new()
        Dim StrCombo As String = "SELECT '00' as CODIGO_CASERIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_CASERIO ,NOMBRE FROM tb_caserios where CODIGO_ALDEA = '" & gb_aldea_new.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_caserio_new.DataSource = DtCombo
        gb_caserio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_caserio_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_caserio_new.DataBind()
    End Sub

    Private Sub llenarcomboOP_new()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `pash_registro_ops2_nuevos` where Depto_Cod= '" & gb_departamento_new.SelectedValue & "'  ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_opS_new.DataSource = DtCombo
        gb_opS_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_opS_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_opS_new.DataBind()
    End Sub

    Private Sub llenarcomboEntrenador_new()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as  ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `entrenadores_redpash`  ORDER BY ec_nombre "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        gb_ec_new.DataSource = DtCombo
        gb_ec_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_ec_new.DataTextField = DtCombo.Columns(1).ToString()
        gb_ec_new.DataBind()
    End Sub

    Private Sub Validar_new_registro()

        Dim dep, mun, aldea, caserio, nombre, dni, edad, telefono, ops, asesor, total As Integer

        '1
        If gb_departamento_new.SelectedValue = "00" Then
            dep = 1
            lb_dept_new.Text = "*"
        Else
            dep = 0
            lb_dept_new.Text = ""
        End If

        '2
        If gb_municipio_new.SelectedValue = "00" Then
            mun = 1
            lb_mun_new.Text = "*"
        Else
            mun = 0
            lb_mun_new.Text = ""
        End If

        '3
        If gb_aldea_new.SelectedValue = "00" Then
            aldea = 1
            lb_aldea_new.Text = "*"
        Else
            aldea = 0
            lb_aldea_new.Text = ""
        End If

        '4
        If gb_caserio_new.SelectedValue = "00" Then
            caserio = 1
            lb_caserio_new.Text = "*"
        Else
            caserio = 0
            lb_caserio_new.Text = ""
        End If

        '5
        If txt_nombre_prod_new.Text = "" Then
            nombre = 1
            lb_nombre_new.Text = "*"
        Else
            nombre = 0
            lb_nombre_new.Text = ""
        End If

        '6
        If txt_dni_new.Text.Length = 13 Then
            dni = 0
            lb_dni_new.Text = ""
        Else
            dni = 1
            lb_dni_new.Text = "*"

        End If

        '7
        If txt_edad_new.Text = "" Then
            edad = 1
            lb_edad_new.Text = "*"
        Else
            edad = 0
            lb_edad_new.Text = ""
        End If

        '8
        If txt_telefono_new.Text.Length = 8 Then
            telefono = 0
            lb_telefono_new.Text = ""
        Else
            telefono = 1
            lb_telefono_new.Text = "*"

        End If

        '9
        If gb_opS_new.SelectedValue = "00" Then
            ops = 1
            lb_ops_new.Text = "*"
        Else
            ops = 0
            lb_ops_new.Text = ""
        End If

        '9
        If gb_ec_new.SelectedValue = "00" Then
            asesor = 1
            lb_asesor_new.Text = "*"
        Else
            asesor = 0
            lb_asesor_new.Text = ""
        End If

        total = dep + mun + aldea + caserio + nombre + dni + edad + telefono + ops + asesor

        If total = 0 Then
            btn_nuevo_prod.Visible = True
        Else
            btn_nuevo_prod.Visible = False
        End If

    End Sub

    Private Sub Validar()

        Dim nombre, dni, edad, telefono, total As Integer
        Dim dep, muni, aldea, caserio As Integer

        If TXT_departamento_add.SelectedValue = "00" Then

            lb_dni.Text = txt_dni_add.Text.Length

            If txt_dni_add.Text.Length = 13 Then
                lb_dni.Text = ""
                dni = 0
            Else
                lb_dni.Text = "*"
                dni = 1
            End If

            If txt_telefono_add.Text.Length = 8 Then
                lb_telefono.Text = ""
                telefono = 0
            Else
                lb_telefono.Text = "*"
                telefono = 1
            End If

            If txt_nombre_add.Text = "" Then
                nombre = 1
                lb_nombre.Text = "*"
            Else
                nombre = 0
                lb_nombre.Text = ""
            End If

            If txt_edad.Text = "" Then
                edad = 1
                lb_edad.Text = "*"
            Else
                edad = 0
                lb_edad.Text = ""
            End If

            total = nombre + dni + edad + telefono

            If total = 0 Then
                Guardar_registro.Visible = True
            Else
                Guardar_registro.Visible = False
            End If
        Else

            lb_dni.Text = txt_dni_add.Text.Length

            If txt_dni_add.Text.Length = 13 Then
                lb_dni.Text = ""
                dni = 0
            Else
                lb_dni.Text = "*"
                dni = 1
            End If

            If txt_telefono_add.Text.Length = 8 Then
                lb_telefono.Text = ""
                telefono = 0
            Else
                lb_telefono.Text = "*"
                telefono = 1
            End If

            If txt_nombre_add.Text = "" Then
                nombre = 1
                lb_nombre.Text = "*"
            Else
                nombre = 0
                lb_nombre.Text = ""
            End If

            If txt_edad.Text = "" Then
                edad = 1
                lb_edad.Text = "*"
            Else
                edad = 0
                lb_edad.Text = ""
            End If

            If TXT_departamento_add.SelectedValue = "00" Then
                dep = 1
                lb_depto.Text = "*"
            Else
                dep = 0
                lb_depto.Text = ""
            End If

            If TXT_municipio_add.SelectedValue = "00" Then
                muni = 1
                lb_municipio.Text = "*"
            Else
                muni = 0
                lb_municipio.Text = ""
            End If

            If TXT_aldea_add.SelectedValue = "00" Then
                aldea = 1
                lb_aldea.Text = "*"
            Else
                aldea = 0
                lb_aldea.Text = ""
            End If

            If TXT_caserio_add.SelectedValue = "00" Then
                caserio = 1
                lb_caserio.Text = "*"
            Else
                caserio = 0
                lb_caserio.Text = ""
            End If

            total = nombre + dni + edad + telefono + dep + muni + aldea + caserio

            If total = 0 Then
                Guardar_registro.Visible = True
            Else
                Guardar_registro.Visible = False
            End If

        End If
    End Sub

    Private Sub llenagrid()

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT * FROM `productores+union` "
            If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                Me.SqlDataSource1.SelectCommand += " WHERE NOMBRE LIKE '%" + txtSearch.Text + "%'    "
            End If

            Me.SqlDataSource1.SelectCommand += " ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT * FROM `productores+union` WHERE "
                If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                    Me.SqlDataSource1.SelectCommand += " NOMBRE LIKE '%" + txtSearch.Text + "%'  AND "
                End If

                Me.SqlDataSource1.SelectCommand += "   Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT * FROM `productores+union` WHERE "
                    If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                        Me.SqlDataSource1.SelectCommand += " NOMBRE LIKE '%" + txtSearch.Text + "%'  AND "
                    End If
                    Me.SqlDataSource1.SelectCommand += " Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT * FROM `productores+union` WHERE"
                    If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                        Me.SqlDataSource1.SelectCommand += " NOMBRE LIKE '%" + txtSearch.Text + "%'  AND "
                    End If

                    Me.SqlDataSource1.SelectCommand += " Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE "

                End If
            End If
        End If

        GridDatos.DataBind()

        If (tns.Text = "si") Then
            LinkButton1.Visible = True
        Else
            LinkButton1.Visible = True
        End If

    End Sub

    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        GV_contacto.PageIndex = e.NewPageIndex

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

    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `productores+union` ORDER BY Depto_Descripcion,NOMBRE; " +
                "SELECT * FROM `productores+participantes+pash`  ORDER BY Depto_Descripcion,NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `productores+union` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE ;" +
                    "SELECT * FROM `productores+participantes+pash` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    query = "SELECT * FROM `productores+union` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE; " +
                        "SELECT * FROM `productores+participantes+pash WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,NOMBRE "
                Else
                    query = "SELECT * FROM `productores+union` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE,NOMBRE; " +
                        "SELECT * FROM `productores+participantes+pash` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND PROYECTO='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion, NOMBRE; "
                End If
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
                        ds.Tables(0).TableName = "_REDPASH+registro_productores"
                        ds.Tables(1).TableName = "_REDPASH+participantes"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Registro_productores_IHMA " & Today & ".xlsx")
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
            Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("CmbPage"), DropDownList)
            Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("PagActual"), Label)
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

    Protected Sub CmbPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("CmbPage"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos.PageIndex = pageList.SelectedIndex
        llenagrid()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        LabelTot.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()
    End Sub

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        div_datos.Visible = True
        div_actualizar.Visible = False
    End Sub

    Protected Sub GridDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "Actualizar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)
            div_datos.Visible = False
            div_actualizar.Visible = True

            Dim Str As String = "SELECT * FROM `productores+union`  WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)
            txt_id.Text = dt.Rows(0)("Id").ToString()
            TXT_VERSION.Text = dt.Rows(0)("version").ToString()

            txt_nombre_add.Text = dt.Rows(0)("NOMBRE").ToString()
            txt_dni_add.Text = dt.Rows(0)("ID_PARTIDA").ToString()
            txt_edad.Text = dt.Rows(0)("EDAD").ToString()
            txt_telefono_add.Text = dt.Rows(0)("TELEFONO_PROPIO").ToString()
            llenagridparticpantes()
            Guardar_registro.Visible = False
        End If

    End Sub

    Sub llenagridparticpantes()

        Using con As New MySqlConnection(conn)
            Using cmd As New MySqlCommand()
                Dim sql As String = "SELECT * FROM `registro_participantes` where COD_PRODUCTOR='" & txt_id.Text & "' and ISNULL(eliminado)"

                cmd.CommandText = sql
                cmd.Connection = con
                Using sda As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    GV_contacto.DataSource = dt
                    GV_contacto.DataBind()

                    Label1.Text = dt.Rows.Count
                End Using
            End Using
        End Using

    End Sub

    Protected Sub eliminar_participante()

        Dim conex As New MySqlConnection(conn)
        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = "UPDATE registro_participantes SET eliminado=1  where id='" & txt_id_part.Text & "'"
        cmd.Connection = conex
        cmd.CommandText = Sql

        cmd.ExecuteNonQuery()
        conex.Close()

        lb_add.Text = "Se elimino el registro de participante"

    End Sub

    Protected Sub Btn_add_Click(sender As Object, e As EventArgs) Handles Btn_add.Click

        Dim conex As New MySqlConnection(conn)
        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If txt_nombre_par.Text = "" Or txt_dni.Text.Length <> 13 Then

            lb_add.Text = "Por favor completar la información"
        Else

            Sql = "INSERT INTO registro_participantes (EDAD, SEXO,COD_PRODUCTOR, Nombre, DNI, usuario) VALUES (@EDAD, @SEXO, @COD_PRODUCTOR, @Nombre, @DNI, @usuario) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@EDAD", txt_edad_part.Text)
            cmd.Parameters.AddWithValue("@COD_PRODUCTOR", txt_id.Text)

            cmd.Parameters.AddWithValue("@Nombre", txt_nombre_par.Text)
            cmd.Parameters.AddWithValue("@DNI", txt_dni.Text)
            cmd.Parameters.AddWithValue("@SEXO", dp_sexo_part.Text)

            cmd.Parameters.AddWithValue("@usuario", User.Identity.Name)
            cmd.ExecuteNonQuery()
            conex.Close()

            llenagridparticpantes()

            lb_add.Text = "El registro se agrego exitosamente"
            txt_nombre_par.Text = ""
            txt_dni.Text = ""
        End If
    End Sub

    Protected Sub TXT_departamento_add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXT_departamento_add.SelectedIndexChanged
        llenarcombomunicipio()
        llenarcomboaldea()
        llenarcombocaserio()
        Validar()
    End Sub

    Protected Sub TXT_municipio_add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXT_municipio_add.SelectedIndexChanged

        llenarcomboaldea()
        llenarcombocaserio()
        Validar()
    End Sub

    Protected Sub TXT_aldea_add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXT_aldea_add.SelectedIndexChanged

        Validar()
        llenarcombocaserio()
    End Sub

    Protected Sub TXT_caserio_add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXT_caserio_add.SelectedIndexChanged
        Validar()
    End Sub

    Protected Sub txt_dni_add_TextChanged(sender As Object, e As EventArgs) Handles txt_dni_add.TextChanged
        Validar()
    End Sub

    Protected Sub txt_nombre_add_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_add.TextChanged
        Validar()
    End Sub

    Protected Sub txt_edad_TextChanged(sender As Object, e As EventArgs) Handles txt_edad.TextChanged
        Validar()
    End Sub

    Protected Sub txt_telefono_add_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono_add.TextChanged
        Validar()
    End Sub

    Protected Sub GV_contacto_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_contacto.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GV_contacto.Rows(index)

            Dim Str As String = "SELECT * FROM `registro_participantes`  WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)
            txt_id_part.Text = dt.Rows(0)("Id").ToString()

            eliminar_participante()
            llenagridparticpantes()

        End If

    End Sub

    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Me.llenagrid()
        txtSearch.Focus()
    End Sub

    Protected Sub btn_si_Click(sender As Object, e As EventArgs) Handles btn_si.Click
        Dim conex As New MySqlConnection(conn)
        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        If TXT_VERSION.Text = "IMPORT" Then

            If TXT_departamento_add.SelectedValue = "00" Then

                Sql = "UPDATE productores SET NOMBRE=@NOMBRE, EDAD=@EDAD, ID_PARTIDA=@ID_PARTIDA, TELEFONO_PROPIO=@TELEFONO_PROPIO  where id='" & txt_id.Text & "'"
                cmd.Connection = conex
                cmd.CommandText = Sql

                cmd.Parameters.AddWithValue("@NOMBRE", txt_nombre_add.Text)
                cmd.Parameters.AddWithValue("@EDAD", txt_edad.Text)
                cmd.Parameters.AddWithValue("@ID_PARTIDA", txt_dni_add.Text)
                cmd.Parameters.AddWithValue("@TELEFONO_PROPIO", txt_telefono_add.Text)

                cmd.ExecuteNonQuery()
                conex.Close()
                llenagrid()
                div_datos.Visible = True
                div_actualizar.Visible = False

                Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))
            Else

                Sql = "UPDATE productores SET NOMBRE=@NOMBRE, EDAD=@EDAD, ID_PARTIDA=@ID_PARTIDA, TELEFONO_PROPIO=@TELEFONO_PROPIO, Depto_Cod=@Depto_Cod, Depto_Descripcion=@Depto_Descripcion, Muni_Descripcion=@Muni_Descripcion, Aldea_Descripcion=@Aldea_Descripcion, Caserio_Descripcion=@Caserio_Descripcion  where id='" & txt_id.Text & "'"
                cmd.Connection = conex
                cmd.CommandText = Sql

                cmd.Parameters.AddWithValue("@NOMBRE", txt_nombre_add.Text)
                cmd.Parameters.AddWithValue("@EDAD", txt_edad.Text)
                cmd.Parameters.AddWithValue("@ID_PARTIDA", txt_dni_add.Text)
                cmd.Parameters.AddWithValue("@TELEFONO_PROPIO", txt_telefono_add.Text)
                cmd.Parameters.AddWithValue("@Depto_Descripcion", TXT_departamento_add.SelectedItem)

                cmd.Parameters.AddWithValue("@Depto_Cod", TXT_departamento_add.Text)

                cmd.Parameters.AddWithValue("@Muni_Descripcion", TXT_municipio_add.SelectedItem)
                cmd.Parameters.AddWithValue("@Aldea_Descripcion", TXT_aldea_add.SelectedItem)
                cmd.Parameters.AddWithValue("@Caserio_Descripcion", TXT_caserio_add.SelectedItem)

                cmd.ExecuteNonQuery()
                conex.Close()
                llenagrid()
                div_datos.Visible = True
                div_actualizar.Visible = False

                Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))

            End If
        Else
            'cuando este el formulario web

            If TXT_departamento_add.SelectedValue = "00" Then

                Sql = "UPDATE redpash_productores_nuevos SET NOMBRE=@NOMBRE, EDAD=@EDAD, IDENTIDAD=@IDENTIDAD, TELEFONO_PROPIO=@TELEFONO_PROPIO  where id='" & txt_id.Text & "'"
                cmd.Connection = conex
                cmd.CommandText = Sql

                cmd.Parameters.AddWithValue("@NOMBRE", txt_nombre_add.Text)
                cmd.Parameters.AddWithValue("@EDAD", txt_edad.Text)
                cmd.Parameters.AddWithValue("@IDENTIDAD", txt_dni_add.Text)
                cmd.Parameters.AddWithValue("@TELEFONO_PROPIO", txt_telefono_add.Text)

                cmd.ExecuteNonQuery()
                conex.Close()
                llenagrid()
                div_datos.Visible = True
                div_actualizar.Visible = False

                Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))
            Else

                Sql = "UPDATE redpash_productores_nuevos SET NOMBRE=@NOMBRE, EDAD=@EDAD, IDENTIDAD=@IDENTIDAD, TELEFONO_PROPIO=@TELEFONO_PROPIO, Depto_Cod=@Depto_Cod, Depto_Descripcion=@Depto_Descripcion, Muni_Descripcion=@Muni_Descripcion, Aldea_Descripcion=@Aldea_Descripcion, Caserio_Descripcion=@Caserio_Descripcion  where id='" & txt_id.Text & "'"
                cmd.Connection = conex
                cmd.CommandText = Sql

                cmd.Parameters.AddWithValue("@NOMBRE", txt_nombre_add.Text)
                cmd.Parameters.AddWithValue("@EDAD", txt_edad.Text)
                cmd.Parameters.AddWithValue("@ID_PARTIDA", txt_dni_add.Text)
                cmd.Parameters.AddWithValue("@TELEFONO_PROPIO", txt_telefono_add.Text)
                cmd.Parameters.AddWithValue("@Depto_Descripcion", TXT_departamento_add.SelectedItem)

                cmd.Parameters.AddWithValue("@Depto_Cod", TXT_departamento_add.Text)

                cmd.Parameters.AddWithValue("@Muni_Descripcion", TXT_municipio_add.SelectedItem)
                cmd.Parameters.AddWithValue("@Aldea_Descripcion", TXT_aldea_add.SelectedItem)
                cmd.Parameters.AddWithValue("@Caserio_Descripcion", TXT_caserio_add.SelectedItem)

                cmd.ExecuteNonQuery()
                conex.Close()
                llenagrid()
                div_datos.Visible = True
                div_actualizar.Visible = False

                Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))

            End If

        End If

    End Sub

    Protected Sub GridDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridDatos.SelectedIndexChanged

    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        div_datos.Visible = False
        div_actualizar.Visible = False
        div_nuevo_prod.Visible = True
        Validar_new_registro()
    End Sub

    Protected Sub gb_departamento_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_departamento_new.SelectedIndexChanged
        Validar_new_registro()
        llenarcombomunicipio_new()
        llenarcomboOP_new()
        'llenarcomboaldea_new()
        'llenarcombocaserio_new()
    End Sub

    Protected Sub gb_municipio_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_municipio_new.SelectedIndexChanged
        Validar_new_registro()
        llenarcomboaldea_new()
        'llenarcombocaserio_new()
    End Sub

    Protected Sub gb_aldea_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_aldea_new.SelectedIndexChanged
        Validar_new_registro()
        llenarcombocaserio_new()
    End Sub

    Protected Sub gb_caserio_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_caserio_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub txt_nombre_prod_new_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_prod_new.TextChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_sexo_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_sexo_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub txt_dni_new_TextChanged(sender As Object, e As EventArgs) Handles txt_dni_new.TextChanged
        Validar_new_registro()
    End Sub

    Protected Sub txt_edad_new_TextChanged(sender As Object, e As EventArgs) Handles txt_edad_new.TextChanged
        Validar_new_registro()
    End Sub

    Protected Sub txt_telefono_new_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono_new.TextChanged
        Validar_new_registro()
    End Sub

    Protected Sub txt_fecha_nacimiento_new_TextChanged(sender As Object, e As EventArgs) Handles txt_fecha_nacimiento_new.TextChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_cargo_nuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_cargo_nuevo.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_sabeleer_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_sabeleer_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_cadena_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_cadena_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_opS_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_opS_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub gb_ec_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_ec_new.SelectedIndexChanged
        Validar_new_registro()
    End Sub

    Protected Sub btn_si_nuevo_Click(sender As Object, e As EventArgs) Handles btn_si_nuevo.Click

        Dim conex As New MySqlConnection(conn)
        Dim Sql As String

        conex.Open()
        Dim cmd2 As New MySqlCommand()

        'Sql = "INSERT INTO masp_productores_nuevos (COD_PRODUCTOR, Depto_Cod, Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion, NOMBRE, FECHA_NACIMIENTO, EDAD, CARGO_OP, TELEFONO_PROPIO, SEXO, IDENTIDAD, ID_PARTIDA, ID_RNP, SABE_LEER, COD_ORGANIZACION, OP_NOMBRE, ec_codigo, ec_nombre, CADENA, FECHA_ENVIO, CADENA2, CATEGORIA_CLIENTE, PROYECTO) VALUES (@COD_PRODUCTOR, @Depto_Cod, @Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion, @NOMBRE, @FECHA_NACIMIENTO, @EDAD, @CARGO_OP, @TELEFONO_PROPIO, @SEXO, @IDENTIDAD, @ID_PARTIDA, @ID_RNP, @SABE_LEER, @COD_ORGANIZACION, @OP_NOMBRE, @ec_codigo, @ec_nombre, @CADENA, @FECHA_ENVIO, @CADENA2, @CATEGORIA_CLIENTE, @PROYECTO) "

        Sql = "INSERT INTO masp_productores_nuevos (COD_PRODUCTOR, Depto_Cod, Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion,NOMBRE, FECHA_NACIMIENTO, EDAD, CARGO_OP, TELEFONO_PROPIO, SEXO, IDENTIDAD,SABE_LEER, COD_ORGANIZACION, OP_NOMBRE, ec_codigo, ec_nombre, CADENA,) VALUES (@COD_PRODUCTOR, @Depto_Cod, @Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion,@NOMBRE, @FECHA_NACIMIENTO, @EDAD, @CARGO_OP, @TELEFONO_PROPIO, @SEXO, @IDENTIDAD,@SABE_LEER, @COD_ORGANIZACION, @OP_NOMBRE, @ec_codigo, @ec_nombre, @CADENA) "

        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@COD_PRODUCTOR", txt_dni_new.Text)
        cmd2.Parameters.AddWithValue("@Depto_Cod", gb_departamento_new.SelectedValue)
        cmd2.Parameters.AddWithValue("@Depto_Descripcion", gb_departamento_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@Muni_Descripcion", gb_municipio_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@Aldea_Descripcion", gb_aldea_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@Caserio_Descripcion", gb_caserio_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@NOMBRE", txt_nombre_prod_new.Text)
        cmd2.Parameters.AddWithValue("@FECHA_NACIMIENTO", txt_fecha_nacimiento_new.Text)
        cmd2.Parameters.AddWithValue("@EDAD", txt_edad_new.Text)
        cmd2.Parameters.AddWithValue("@CARGO_OP", gb_cargo_nuevo.Text)
        cmd2.Parameters.AddWithValue("@TELEFONO_PROPIO", txt_telefono_new.Text)
        cmd2.Parameters.AddWithValue("@SEXO", gb_sexo_new.Text)
        cmd2.Parameters.AddWithValue("@IDENTIDAD", txt_dni_new.Text)

        cmd2.Parameters.AddWithValue("@SABE_LEER", gb_sabeleer_new.Text)
        cmd2.Parameters.AddWithValue("@COD_ORGANIZACION", gb_opS_new.SelectedValue)

        cmd2.Parameters.AddWithValue("@OP_NOMBRE", gb_opS_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@ec_codigo", gb_ec_new.SelectedValue)
        cmd2.Parameters.AddWithValue("@ec_nombre", gb_ec_new.SelectedItem)
        cmd2.Parameters.AddWithValue("@CADENA", gb_cadena_new.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()
        llenagrid()

        Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect(String.Format("~/pages/Registro_productores.aspx"))
    End Sub

End Class