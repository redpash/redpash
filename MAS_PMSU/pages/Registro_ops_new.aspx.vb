Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Registro_ops_new
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
                divedit.Visible = False
                div_nuevo_prod.Visible = False

                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()

                llenarcomboDepartamento_new()
                llenarcombomunicipio_new()
                llenarcomboaldea_new()
                llenarcombocaserio_new()

                llenarcomboEntrenador_new()

                TXT_FECHA_CREATE_OP.Text = DateTime.Today.ToString("yyyy-MM-dd")

            End If
            llenagrid()

            If txt_admin.Text = "SI" Then
                div_admin.Visible = True
            Else
                div_admin.Visible = False
            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `redpash_organizaciones` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub

    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo,ec_nombre FROM `redpash_organizaciones` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' ORDER BY ec_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub

    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,' Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `redpash_organizaciones` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY OP_NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        cmborganizacion.DataSource = DtCombo
        cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
        cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
        cmborganizacion.DataBind()

    End Sub

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

    Sub llenagrid()

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,REPRESENTANTE_JUNTA_DIRECTIVA,SOCIOS_ORIGINAL_HOMBRES,SOCIOS_ACTUAL_HOMBRES,SOCIOS_ORIGINAL_MUJERES,SOCIOS_ACTUAL_MUJERES,id " +
            "FROM `redpash_organizaciones` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,REPRESENTANTE_JUNTA_DIRECTIVA,SOCIOS_ORIGINAL_HOMBRES,SOCIOS_ACTUAL_HOMBRES,SOCIOS_ORIGINAL_MUJERES,SOCIOS_ACTUAL_MUJERES,id " +
                "FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,REPRESENTANTE_JUNTA_DIRECTIVA,SOCIOS_ORIGINAL_HOMBRES,SOCIOS_ACTUAL_HOMBRES,SOCIOS_ORIGINAL_MUJERES,SOCIOS_ACTUAL_MUJERES,id " +
                    "FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,COD_ORGANIZACION,OP_NOMBRE,REPRESENTANTE_NOMBRE,REPRESENTANTE_JUNTA_DIRECTIVA,SOCIOS_ORIGINAL_HOMBRES,SOCIOS_ACTUAL_HOMBRES,SOCIOS_ORIGINAL_MUJERES,SOCIOS_ACTUAL_MUJERES,id " +
                    "FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub

    Protected Sub GridDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        If (e.CommandName = "Actualizar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)
            divdatos.Visible = False
            divedit.Visible = True

            Dim Str As String = "SELECT * FROM `redpash_organizaciones`  WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)
            'txt_id.Text = dt.Rows(0)("Id").ToString()

            TXT_nombre_joven.Text = dt.Rows(0)("REPRESENTANTE_NOMBRE").ToString()
            TXT_DNI.Text = dt.Rows(0)("REPRESENTANTE_IDENTIDAD").ToString()
            'TXT_telefono.Text = dt.Rows(0)("REPRESENTANTE_TELEFONO1").ToString()

            'Txttrabaja.Text = dt.Rows(0)("TIENE_PERSONERIA").ToString()
            'txt_det_personeria.Text = dt.Rows(0)("PERSONERIA_NUM").ToString()

            'gb_rtn.Text = dt.Rows(0)("TIENE_RTN").ToString()
            'txt_det_rtn.Text = dt.Rows(0)("RTN_NUM").ToString()

            'gb_cai.Text = dt.Rows(0)("TIENE_CAI").ToString()
            'txt_det_cai.Text = dt.Rows(0)("CAI_NUM").ToString()

            'txt_socio_H.Text = dt.Rows(0)("SOCIOS_ACTUAL_HOMBRES").ToString()
            'txt_socio_m.Text = dt.Rows(0)("SOCIOS_ACTUAL_MUJERES").ToString()
            'txt_socio_total.Text = dt.Rows(0)("TOTAL_HM_ACTUAL").ToString()

        End If

    End Sub

    Private Sub calcular_socios()
        txt_socio_total.Text = Convert.ToDecimal(txt_socio_H.Text) + Convert.ToDecimal(txt_socio_m.Text)

    End Sub

    Private Sub validar()

        Dim personeria, rtn, cai, total As Integer

        If Txttrabaja.Text = "Si" And txt_det_personeria.Text = "" Then
            personeria = 1
        Else
            personeria = 0
        End If

        If gb_rtn.Text = "Si" And txt_det_rtn.Text = "" Then
            rtn = 1
        Else
            rtn = 0
        End If

        If gb_cai.Text = "Si" And txt_det_cai.Text = "" Then
            cai = 1
        Else
            cai = 0
        End If

        total = personeria + rtn + cai

        If total = 0 Then
            Guardar.Visible = True
        Else
            Guardar.Visible = False
        End If

    End Sub

    Private Sub validar_NEW_FORM()
        Dim dep, mun, aldea, caserio, nombre, dni, telefono, socioH, socioM, OP_nombre, direccion, RTN, CAI, PERSONERIA, EC, TOTAL As Integer

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
        If txt_telefono_new.Text.Length = 8 Then
            telefono = 0
            lb_telefono_new.Text = ""
        Else
            telefono = 1
            lb_telefono_new.Text = "*"

        End If
        '8
        If TXT_SOCIO_H_NEW.Text = "" Then
            socioH = 1
            LB_SOCIO_H_NEW.Text = "*"
        Else
            socioH = 0
            LB_SOCIO_H_NEW.Text = ""
        End If

        '9
        If TXT_SOCIO_M_NEW.Text = "" Then
            socioM = 1
            LB_SOCIO_M_NEW.Text = "*"
        Else
            socioH = 0
            LB_SOCIO_M_NEW.Text = ""
        End If

        '10
        If TXT_OP_NOMBRE_NEW.Text = "" Then

            OP_nombre = 1
            LB_OP_NOMBRE_NEW.Text = "*"
        Else
            OP_nombre = 0
            LB_OP_NOMBRE_NEW.Text = ""
        End If

        '11

        If TXT_OPDIRECCION_NEW.Text = "" Then

            direccion = 1
            LB_DIRECCION_NEW.Text = "*"
        Else

            direccion = 0
            LB_DIRECCION_NEW.Text = ""
        End If
        '12
        If GB_RTN_new.Text = "Si" And TXT_RTN_new.Text = "" Then
            RTN = 1
            LB_RTN.Text = "*"
        Else
            RTN = 0
            LB_RTN.Text = ""
        End If

        '13
        If GB_PERSONERIA_new.Text = "Si" And TXT_PERSONERIA_new.Text = "" Then
            PERSONERIA = 1
            LB_PERSONERIA.Text = "*"
        Else
            PERSONERIA = 0
            LB_PERSONERIA.Text = ""
        End If
        '14
        If GB_CAI_new.Text = "Si" And TXT_CAI_new.Text = "" Then
            CAI = 1
            LB_CAI.Text = "*"
        Else
            CAI = 0
            LB_CAI.Text = ""
        End If

        If gb_ec_new.SelectedValue = "00" Then
            EC = 1
        Else
            EC = 0
        End If

        TOTAL = dep + mun + aldea + caserio + nombre + dni + telefono + socioH + socioM + OP_nombre + direccion + RTN + CAI + PERSONERIA + EC

        If TOTAL = 0 Then
            btn_nuevo_prod.Visible = True
        Else
            btn_nuevo_prod.Visible = False
        End If

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
            query = "SELECT * FROM `redpash_organizaciones` ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    query = "SELECT * FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    query = "SELECT * FROM `redpash_organizaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND COD_ORGANIZACION='" & cmborganizacion.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
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
                        ds.Tables(0).TableName = "_REDPASH+registro_ORG"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Registro_Organizaciones " & Today & ".xlsx")
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
                    ' Se crea un objeto ListItem para representar la  gina...
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
                ' Calcula el nº de  gina actual...
                Dim currentPage As Integer = GridDatos.PageIndex + 1
                ' Actualiza el Label control con la  gina actual.
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

    Protected Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        divdatos.Visible = True
        divedit.Visible = False
    End Sub

    Protected Sub txt_socio_H_TextChanged(sender As Object, e As EventArgs) Handles txt_socio_H.TextChanged
        calcular_socios()
        validar()
    End Sub

    Protected Sub txt_socio_m_TextChanged(sender As Object, e As EventArgs) Handles txt_socio_m.TextChanged
        calcular_socios()
        validar()
    End Sub

    Protected Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        'aqui hacer el update
    End Sub

    Protected Sub Txttrabaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Txttrabaja.SelectedIndexChanged

        If Txttrabaja.Text = "Si" Then
            txt_det_personeria.ReadOnly = False
        Else
            txt_det_personeria.ReadOnly = True
            txt_det_personeria.Text = ""
        End If
        validar()

    End Sub

    Protected Sub gb_rtn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_rtn.SelectedIndexChanged
        If gb_rtn.Text = "Si" Then
            txt_det_rtn.ReadOnly = False
        Else
            txt_det_rtn.ReadOnly = True
            txt_det_rtn.Text = ""
        End If
        validar()
    End Sub

    Protected Sub gb_cai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_cai.SelectedIndexChanged
        If gb_cai.Text = "Si" Then
            txt_det_cai.ReadOnly = False
        Else
            txt_det_cai.ReadOnly = True
            txt_det_cai.Text = ""
        End If
        validar()
    End Sub

    Protected Sub btnsi_Click(sender As Object, e As EventArgs) Handles btnsi.Click

        Dim conex As New MySqlConnection(conn)
        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = "UPDATE `registros_bancos_semilla` SET REPRESENTANTE_NOMBRE=@REPRESENTANTE_NOMBRE, REPRESENTANTE_ID_PARTIDA=@REPRESENTANTE_ID_PARTIDA, REPRESENTANTE_TELEFONO1=@REPRESENTANTE_TELEFONO1,   TIENE_PERSONERIA =@TIENE_PERSONERIA,PERSONERIA_NUM=@PERSONERIA_NUM, TIENE_RTN=@TIENE_RTN, RTN_NUM=@RTN_NUM, TIENE_CAI=@TIENE_CAI,CAI_NUM=@CAI_NUM, SOCIOS_ORIGINAL_HOMBRES=@SOCIOS_ORIGINAL_HOMBRES, SOCIOS_ORIGINAL_MUJERES =@SOCIOS_ORIGINAL_MUJERES, TOTAL_HM_ACTUAL=@TOTAL_HM_ACTUAL
 where id='" & txt_id.Text & "'"
        cmd.Connection = conex
        cmd.CommandText = Sql

        cmd.Parameters.AddWithValue("@REPRESENTANTE_NOMBRE", TXT_nombre_joven.Text)
        cmd.Parameters.AddWithValue("@REPRESENTANTE_ID_PARTIDA", TXT_DNI.Text)
        cmd.Parameters.AddWithValue("@REPRESENTANTE_TELEFONO1", TXT_telefono.Text)
        cmd.Parameters.AddWithValue("@TIENE_PERSONERIA", Txttrabaja.Text)
        cmd.Parameters.AddWithValue("@PERSONERIA_NUM", txt_det_personeria.Text)
        cmd.Parameters.AddWithValue("@TIENE_RTN", gb_rtn.Text)
        cmd.Parameters.AddWithValue("@RTN_NUM", txt_det_rtn.Text)
        cmd.Parameters.AddWithValue("@TIENE_CAI", gb_cai.Text)
        cmd.Parameters.AddWithValue("@CAI_NUM", txt_det_cai.Text)
        cmd.Parameters.AddWithValue("@SOCIOS_ORIGINAL_HOMBRES", TXT_SOCIO_H_NEW.Text)
        cmd.Parameters.AddWithValue("@SOCIOS_ORIGINAL_MUJERES", TXT_SOCIO_M_NEW.Text)
        cmd.Parameters.AddWithValue("@TOTAL_HM_ACTUAL", txt_socio_total.Text)

        cmd.ExecuteNonQuery()
        conex.Close()
        llenagrid()
        divdatos.Visible = True
        divedit.Visible = False

    End Sub

    Protected Sub TXT_nombre_joven_TextChanged(sender As Object, e As EventArgs) Handles TXT_nombre_joven.TextChanged
        validar()
    End Sub

    Protected Sub TXT_DNI_TextChanged(sender As Object, e As EventArgs) Handles TXT_DNI.TextChanged
        validar()
    End Sub

    Protected Sub TXT_telefono_TextChanged(sender As Object, e As EventArgs) Handles TXT_telefono.TextChanged
        validar()
    End Sub

    Protected Sub txt_det_personeria_TextChanged(sender As Object, e As EventArgs) Handles txt_det_personeria.TextChanged
        validar()
    End Sub

    Protected Sub txt_det_rtn_TextChanged(sender As Object, e As EventArgs) Handles txt_det_rtn.TextChanged
        validar()
    End Sub

    Protected Sub txt_det_cai_TextChanged(sender As Object, e As EventArgs) Handles txt_det_cai.TextChanged
        validar()
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        divedit.Visible = False
        divdatos.Visible = False
        div_nuevo_prod.Visible = True
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_departamento_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_departamento_new.SelectedIndexChanged
        llenarcombomunicipio_new()
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_municipio_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_municipio_new.SelectedIndexChanged
        llenarcomboaldea_new()
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_aldea_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_aldea_new.SelectedIndexChanged
        llenarcombocaserio_new()
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_caserio_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_caserio_new.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub txt_nombre_prod_new_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_prod_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_sexo_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_sexo_new.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub txt_dni_new_TextChanged(sender As Object, e As EventArgs) Handles txt_dni_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub txt_telefono_new_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_cargo_nuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_cargo_nuevo.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_SOCIO_H_NEW_TextChanged(sender As Object, e As EventArgs) Handles TXT_SOCIO_H_NEW.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_SOCIO_M_NEW_TextChanged(sender As Object, e As EventArgs) Handles TXT_SOCIO_M_NEW.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_cadena_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_cadena_new.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_OP_NOMBRE_NEW_TextChanged(sender As Object, e As EventArgs) Handles TXT_OP_NOMBRE_NEW.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_OPDIRECCION_NEW_TextChanged(sender As Object, e As EventArgs) Handles TXT_OPDIRECCION_NEW.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_tipo_new.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_FECHA_CREATE_OP_TextChanged(sender As Object, e As EventArgs) Handles TXT_FECHA_CREATE_OP.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub GB_RTN_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GB_RTN_new.SelectedIndexChanged

        If GB_RTN_new.Text = "Si" Then
            TXT_RTN_new.ReadOnly = False
        Else
            TXT_RTN_new.ReadOnly = True
            TXT_RTN_new.Text = ""
        End If

        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_RTN_new_TextChanged(sender As Object, e As EventArgs) Handles TXT_RTN_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_PERSONERIA_new_TextChanged(sender As Object, e As EventArgs) Handles TXT_PERSONERIA_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub GB_CAI_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GB_CAI_new.SelectedIndexChanged

        If GB_CAI_new.Text = "Si" Then
            TXT_CAI_new.ReadOnly = False
        Else
            TXT_CAI_new.ReadOnly = True
            TXT_CAI_new.Text = ""
        End If
        validar_NEW_FORM()
    End Sub

    Protected Sub TXT_CAI_new_TextChanged(sender As Object, e As EventArgs) Handles TXT_CAI_new.TextChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub gb_ec_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gb_ec_new.SelectedIndexChanged
        validar_NEW_FORM()
    End Sub

    Protected Sub GB_PERSONERIA_new_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GB_PERSONERIA_new.SelectedIndexChanged
        validar_NEW_FORM()

        If GB_PERSONERIA_new.Text = "Si" Then
            TXT_PERSONERIA_new.ReadOnly = False
        Else
            TXT_PERSONERIA_new.ReadOnly = True
            TXT_PERSONERIA_new.Text = ""
        End If
    End Sub

    Protected Sub btn_si_nuevo_Click(sender As Object, e As EventArgs) Handles btn_si_nuevo.Click
        Try
            Dim conex As New MySqlConnection(conn)
            Dim Sql As String

            conex.Open()
            Dim cmd2 As New MySqlCommand()

            Sql = "INSERT INTO `pash_registro_ops2_nuevos` (CADENA2,Depto_Cod, Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion,ec_codigo,ec_nombre, REPRESENTANTE_NOMBRE, REPRESENTANTE_IDENTIDAD,  REPRESENTANTE_JUNTA_DIRECTIVA, REPRESENTANTE_TELEFONO1, OP_NOMBRE, OP_DIRECCION, OP_FECHA_CREACION, TIPO_ORGANIZACION, TIENE_PERSONERIA, PERSONERIA_NUM, TIENE_RTN, RTN_NUM, TIENE_CAI, CAI_NUM, SOCIOS_ORIGINAL_HOMBRES, SOCIOS_ORIGINAL_MUJERES) VALUES (@CADENA2,@Depto_Cod, @Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion, @ec_codigo,@ec_nombre, @REPRESENTANTE_NOMBRE, @REPRESENTANTE_IDENTIDAD,  @REPRESENTANTE_JUNTA_DIRECTIVA, @REPRESENTANTE_TELEFONO1, @OP_NOMBRE, @OP_DIRECCION, @OP_FECHA_CREACION, @TIPO_ORGANIZACION, @TIENE_PERSONERIA, @PERSONERIA_NUM, @TIENE_RTN, @RTN_NUM, @TIENE_CAI, @CAI_NUM, @SOCIOS_ORIGINAL_HOMBRES, @SOCIOS_ORIGINAL_MUJERES) "
            'Sql = "INSERT INTO `pash_registro_ops2_nuevos` (CADENA2) values(@CADENA2) "

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@CADENA2", gb_cadena_new.Text)
            cmd2.Parameters.AddWithValue("@Depto_Cod", gb_departamento_new.SelectedValue)
            cmd2.Parameters.AddWithValue("@Depto_Descripcion", gb_departamento_new.SelectedItem)
            cmd2.Parameters.AddWithValue("@Muni_Descripcion", gb_municipio_new.SelectedItem)
            cmd2.Parameters.AddWithValue("@Aldea_Descripcion", gb_aldea_new.SelectedItem)
            cmd2.Parameters.AddWithValue("@Caserio_Descripcion", gb_caserio_new.SelectedItem)
            cmd2.Parameters.AddWithValue("@REPRESENTANTE_NOMBRE", txt_nombre_prod_new.Text)

            cmd2.Parameters.AddWithValue("@ec_codigo", gb_ec_new.SelectedValue)
            cmd2.Parameters.AddWithValue("@ec_nombre", gb_ec_new.SelectedItem.Text)

            cmd2.Parameters.AddWithValue("@REPRESENTANTE_IDENTIDAD", txt_dni_new.Text)

            cmd2.Parameters.AddWithValue("@REPRESENTANTE_JUNTA_DIRECTIVA", gb_cargo_nuevo.Text)
            cmd2.Parameters.AddWithValue("@REPRESENTANTE_TELEFONO1", txt_telefono_new.Text)
            cmd2.Parameters.AddWithValue("@OP_NOMBRE", TXT_OP_NOMBRE_NEW.Text)
            cmd2.Parameters.AddWithValue("@OP_DIRECCION", TXT_OPDIRECCION_NEW.Text)
            cmd2.Parameters.AddWithValue("@OP_FECHA_CREACION", TXT_FECHA_CREATE_OP.Text)
            cmd2.Parameters.AddWithValue("@TIPO_ORGANIZACION", gb_tipo_new.Text)
            cmd2.Parameters.AddWithValue("@TIENE_PERSONERIA", GB_PERSONERIA_new.Text)
            cmd2.Parameters.AddWithValue("@PERSONERIA_NUM", TXT_PERSONERIA_new.Text)
            cmd2.Parameters.AddWithValue("@TIENE_RTN", GB_RTN_new.Text)
            cmd2.Parameters.AddWithValue("@RTN_NUM", TXT_RTN_new.Text)
            cmd2.Parameters.AddWithValue("@TIENE_CAI", GB_CAI_new.Text)
            cmd2.Parameters.AddWithValue("@CAI_NUM", TXT_CAI_new.Text)
            cmd2.Parameters.AddWithValue("@SOCIOS_ORIGINAL_HOMBRES", TXT_SOCIO_H_NEW.Text)
            cmd2.Parameters.AddWithValue("@SOCIOS_ORIGINAL_MUJERES", TXT_SOCIO_M_NEW.Text)

            cmd2.ExecuteNonQuery()
            conex.Close()


        Catch ex As Exception
            MsgBox(ex)
        End Try
        Response.Redirect(String.Format("~/pages/Registro_ops_new.aspx"))


    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Response.Redirect(String.Format("~/pages/Registro_ops_new.aspx"))

    End Sub



End Class