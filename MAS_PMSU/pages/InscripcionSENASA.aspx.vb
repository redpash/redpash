﻿Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class InscripcionSENASA
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
                divIndividual.Visible = False
                Experiencia_Previa.Visible = False
                Experiencia_Previa2.Visible = False
                SectionExperiencia.Visible = False
                divModifiyIn.Visible = False
                divModify.Visible = False
                Button2.Visible = False
                btn_nuevo_prod.Visible = False
                llenarDlOrganizaciones()
                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarcomboOP()
                llenarcomboComboTipoBanco()

                llenarcomboDepartamento_Individual()

                llenarcomboDepartamento_new()
                llenarcombomunicipio_new()
                llenarcomboaldea_new()
                llenarcombocaserio_new()

                llenarcomboEntrenador_new()
                llenarcomboEntrenador_Individual()

                TXT_FECHA_CREATE_OP.Text = DateTime.Today.ToString("yyyy-MM-dd")
                llenagrid()
            End If


            If txt_admin.Text = "SI" Then
                div_admin.Visible = False
            Else
                div_admin.Visible = False
            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    'Private Sub llenarcomboDepto()
    '    Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `redpash_organizaciones` "
    '    Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
    '    Dim DtCombo As New DataTable
    '    adaptcombo.Fill(DtCombo)
    '    TxtDepto.DataSource = DtCombo
    '    TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
    '    TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
    '    TxtDepto.DataBind()
    'End Sub

    'llenar combo para tipo de banco a seleccionar
    Private Sub llenarcomboComboTipoBanco()

        'If ComboTipoBanco.Text = "Individual" Then
        '    div3.Visible = True
        '    'Div_organizacion.visible = False
        '    'Div_individual.visible = True
        'Else
        '    If ComboTipoBanco.Text = "Organización" Then
        '        div3.Visible = True
        '        'Div_organizacion.visible = True
        '        'Div_individual.visible = False

        '    Else
        '        div3.Visible = False
        '        'Div_organizacion.visible = False
        '        'Div_individual.visible = False

        '    End If
        'End If

        'Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `registros_bancos_semilla` "
        'Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        'Dim DtCombo As New DataTable
        'adaptcombo.Fill(DtCombo)
        'ComboTipoBanco.DataSource = DtCombo
        'ComboTipoBanco.DataValueField = DtCombo.Columns(0).ToString()
        'ComboTipoBanco.DataTextField = DtCombo.Columns(1).ToString()
        'ComboTipoBanco.DataBind()
    End Sub

    'filtros
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `vista_banco_semilla_todo` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxTdepto.DataSource = DtCombo
        TxTdepto.DataValueField = DtCombo.Columns(0).ToString()
        TxTdepto.DataTextField = DtCombo.Columns(1).ToString()
        TxTdepto.DataBind()
    End Sub

    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo,ec_nombre FROM `vista_banco_semilla_todo` WHERE Depto_Cod = '" & TxTdepto.SelectedValue & "' ORDER BY ec_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub

    Private Sub llenarcomboOP()
        Dim StrCombo As String = "SELECT '00' as cod_TIPO_BCS,' Todas' as TIPO_BCS UNION SELECT DISTINCT TIPO_BCS as cod_TIPO_BCS, TIPO_BCS FROM `vista_banco_semilla_todo` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY TIPO_BCS "
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

    Private Sub llenarcomboDepartamento_Individual()
        Dim StrCombo As String = "SELECT '00' as CODIGO_DEPARTAMENTO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_DEPARTAMENTO ,NOMBRE FROM tb_departamentos ORDER BY NOMBRE"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        Dl_Departamento_Individual.DataSource = DtCombo
        Dl_Departamento_Individual.DataValueField = DtCombo.Columns(0).ToString()
        Dl_Departamento_Individual.DataTextField = DtCombo.Columns(1).ToString()
        Dl_Departamento_Individual.DataBind()

    End Sub

    Private Sub llenarDlOrganizaciones()
        Dim StrCombo As String = "SELECT id, OP_NOMBRE FROM pash_registro_ops2_nuevos"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Dl_OP_Todos.DataSource = DtCombo
        Dl_OP_Todos.DataValueField = DtCombo.Columns(0).ToString()
        Dl_OP_Todos.DataTextField = DtCombo.Columns(1).ToString()
        Dl_OP_Todos.DataBind()

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

    Private Sub llenarcombomunicipio_In()
        Dim StrCombo As String = "SELECT '00' as CODIGO_MUNICIPIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_MUNICIPIO ,NOMBRE FROM tb_municipio where CODIGO_DEPARTAMENTO = '" & Dl_Departamento_Individual.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Dl_Municipio_Individual.DataSource = DtCombo
        Dl_Municipio_Individual.DataValueField = DtCombo.Columns(0).ToString()
        Dl_Municipio_Individual.DataTextField = DtCombo.Columns(1).ToString()
        Dl_Municipio_Individual.DataBind()
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

    Private Sub llenarcomboaldea_In()
        Dim StrCombo As String = "SELECT '00' as CODIGO_ALDEA, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_ALDEA ,NOMBRE FROM tb_aldea where CODIGO_MUNICIPIO = '" & Dl_Municipio_Individual.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        Dl_Aldea_Individual.DataSource = DtCombo
        Dl_Aldea_Individual.DataValueField = DtCombo.Columns(0).ToString()
        Dl_Aldea_Individual.DataTextField = DtCombo.Columns(1).ToString()
        Dl_Aldea_Individual.DataBind()
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

    Private Sub llenarcombocaserio_In()
        Dim StrCombo As String = "SELECT '00' as CODIGO_CASERIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_CASERIO ,NOMBRE FROM tb_caserios where CODIGO_ALDEA = '" & Dl_Aldea_Individual.SelectedValue & "' ORDER BY NOMBRE "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        Dl_Caserio_Individual.DataSource = DtCombo
        Dl_Caserio_Individual.DataValueField = DtCombo.Columns(0).ToString()
        Dl_Caserio_Individual.DataTextField = DtCombo.Columns(1).ToString()
        Dl_Caserio_Individual.DataBind()
    End Sub

    Private Sub llenarcomboEntrenador_Individual()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as  ec_nombre UNION SELECT DISTINCT ec_codigo, ec_nombre FROM `entrenadores_redpash`  ORDER BY ec_nombre "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Lb_Asignar_Acesor_Ind.DataSource = DtCombo
        Lb_Asignar_Acesor_Ind.DataValueField = DtCombo.Columns(0).ToString()
        Lb_Asignar_Acesor_Ind.DataTextField = DtCombo.Columns(1).ToString()
        Lb_Asignar_Acesor_Ind.DataBind()
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

        If TxTdepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT * " +
            "FROM `vista_banco_semilla_todo`  ORDER BY Id,Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT * " +
                "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT * " +
                    "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT * " +
                    "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND TIPO_BCS='" & cmborganizacion.SelectedValue & "'   ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub

    Protected Sub GridDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Eliminar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM registros_bancos_semilla WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            Txt_Id_Eliminar.Text = dt.Rows(0)("Id").ToString()

            'Label1.Text = "¿Esta seguro que desea eliminar el registro?"
            'BConfirm.Visible = False

            'BBorrarsi.Visible = True
            'BBorrarno.Visible = True

            ' Registro del script para mostrar el modal
            Dim script As String = "$(function () { $('#ModalDelete').modal('show'); });"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowModal", script, True)
        End If
        If (e.CommandName = "Actualizar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM registros_bancos_semilla WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            Txt_Id_Eliminar.Text = dt.Rows(0)("Id").ToString()

            If dt.Rows(0)("TIPO_BCS").ToString() = "Organizacion" Then
                divdatos.Visible = False
                div_nuevo_prod.Visible = True
                divModify.Visible = True
                div2.Visible = False
                'Response.Write("<script language=""javascript"">alert('Congratulations!');</script>")

                gb_departamento_new.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()
                Dim StrCombo As String = "SELECT '00' as CODIGO_MUNICIPIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_MUNICIPIO ,NOMBRE FROM tb_municipio where CODIGO_DEPARTAMENTO = '" & gb_departamento_new.SelectedValue & "' ORDER BY NOMBRE "
                Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
                Dim DtCombo As New DataTable
                adaptcombo.Fill(DtCombo)
                gb_municipio_new.DataSource = DtCombo
                gb_municipio_new.DataValueField = DtCombo.Columns(0).ToString()
                gb_municipio_new.DataTextField = DtCombo.Columns(1).ToString()
                gb_municipio_new.DataBind()
                Dim municipioSeleccionado As String = dt.Rows(0)("Muni_Descripcion").ToString()

                ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                Dim indice As Integer = gb_municipio_new.Items.IndexOf(gb_municipio_new.Items.FindByText(municipioSeleccionado))

                ' Verificar que se encontró el elemento y seleccionarlo
                If indice >= 0 Then
                    gb_municipio_new.SelectedIndex = indice
                End If

                'aldea
                Dim StrCombo1 As String = "SELECT '00' as CODIGO_ALDEA, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_ALDEA ,NOMBRE FROM tb_aldea where CODIGO_MUNICIPIO = '" & gb_municipio_new.SelectedValue & "' ORDER BY NOMBRE "
                Dim adaptcombo1 As New MySqlDataAdapter(StrCombo1, conn)
                Dim DtCombo1 As New DataTable
                adaptcombo1.Fill(DtCombo1)

                gb_aldea_new.DataSource = DtCombo1
                gb_aldea_new.DataValueField = DtCombo1.Columns(0).ToString()
                gb_aldea_new.DataTextField = DtCombo1.Columns(1).ToString()
                gb_aldea_new.DataBind()
                Dim aldeaSeleccionado As String = dt.Rows(0)("Aldea_Descripcion").ToString()

                ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                Dim indice1 As Integer = gb_aldea_new.Items.IndexOf(gb_aldea_new.Items.FindByText(aldeaSeleccionado))

                ' Verificar que se encontró el elemento y seleccionarlo
                If indice1 >= 0 Then
                    gb_aldea_new.SelectedIndex = indice1
                End If

                'caserio
                Dim StrCombo2 As String = "SELECT '00' as CODIGO_CASERIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_CASERIO ,NOMBRE FROM tb_caserios where CODIGO_ALDEA = '" & gb_aldea_new.SelectedValue & "' ORDER BY NOMBRE "
                Dim adaptcombo2 As New MySqlDataAdapter(StrCombo2, conn)
                Dim DtCombo2 As New DataTable
                adaptcombo2.Fill(DtCombo2)

                gb_caserio_new.DataSource = DtCombo2
                gb_caserio_new.DataValueField = DtCombo2.Columns(0).ToString()
                gb_caserio_new.DataTextField = DtCombo2.Columns(1).ToString()
                gb_caserio_new.DataBind()
                Dim caserio As String = dt.Rows(0)("Caserio_Descripcion").ToString()

                ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                Dim indice2 As Integer = gb_caserio_new.Items.IndexOf(gb_caserio_new.Items.FindByText(caserio))

                ' Verificar que se encontró el elemento y seleccionarlo
                If indice2 >= 0 Then
                    gb_caserio_new.SelectedIndex = indice2
                End If

                'txt_id.Text = dt.Rows(0)("Id").ToString()
                txt_nombre_prod_new.Text = dt.Rows(0)("OP_NOMBRE").ToString()

                txtEdadRepresentante.Text = dt.Rows(0)("OP_REPRESENTANTE_EDAD").ToString()
                txt_dni_new.Text = dt.Rows(0)("OP_REPRESENTANTE_ID").ToString()
                txt_telefono_new.Text = dt.Rows(0)("OP_REPRESENTANTE_TELEFONO").ToString()
                TXT_SOCIO_H_NEW.Text = dt.Rows(0)("OP_MIEMBROS_Hombres").ToString()
                GB_RTN_new.Text = dt.Rows(0)("OP_RTN").ToString()

                TXT_SOCIO_M_NEW.Text = dt.Rows(0)("OP_MIEMBROS_Mujeres").ToString()

                TXT_RTN_new.Text = dt.Rows(0)("OP_RTN_NUM").ToString()
                TXT_CAI_new.Text = dt.Rows(0)("OP_CAI_NUM").ToString()
                Dim StrCombo3 As String = "SELECT id, OP_NOMBRE FROM pash_registro_ops2_nuevos"
                Dim adaptcombo3 As New MySqlDataAdapter(StrCombo3, conn)
                Dim DtCombo3 As New DataTable
                adaptcombo3.Fill(DtCombo3)
                Dl_OP_Todos.DataSource = DtCombo3
                Dl_OP_Todos.DataValueField = DtCombo3.Columns(0).ToString()
                Dl_OP_Todos.DataTextField = DtCombo3.Columns(1).ToString()
                Dl_OP_Todos.DataBind()

                Dim OpSeleccionado As String = dt.Rows(0)("Op_Nombre_Organizacion").ToString()

                ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                Dim indice3 As Integer = Dl_OP_Todos.Items.IndexOf(Dl_OP_Todos.Items.FindByText(OpSeleccionado))

                ' Verificar que se encontró el elemento y seleccionarlo
                If indice3 >= 0 Then
                    Dl_OP_Todos.SelectedIndex = indice3
                End If
                gb_ec_new.SelectedValue = dt.Rows(0)("ec_codigo").ToString()
                TXT_OPDIRECCION_NEW.Text = dt.Rows(0)("Op_Direccion_Organizacion").ToString()
                gb_tipo_new.SelectedValue = dt.Rows(0)("OP_TIPO").ToString()
                GB_PERSONERIA_new.SelectedValue = dt.Rows(0)("OP_PERSONERIA").ToString()
                GB_RTN_new.SelectedValue = dt.Rows(0)("OP_RTN").ToString()
                TXT_RTN_new.Text = dt.Rows(0)("OP_RTN_NUM").ToString()
                GB_CAI_new.SelectedValue = dt.Rows(0)("OP_CAI").ToString()
                TXT_CAI_new.Text = dt.Rows(0)("OP_CAI_NUM").ToString()
                Dl_CuentaBancaria_Org.SelectedValue = dt.Rows(0)("Cuenta_Bancaria").ToString()
                Dl_CuentaAhorroBanco_Org.SelectedValue = dt.Rows(0)("Cuenta_Ahorro").ToString()
                Dl_ListaBancosAhorro_Org.SelectedValue = dt.Rows(0)("Lista_De_Bancos").ToString()
                txt_cuentaAhorroBanco_org.Text = dt.Rows(0)("Cuenta_Bancos").ToString()
                txt_BeneficiaroAhorro_Org.Text = dt.Rows(0)("Nombre_Beneficiario").ToString()

                Dl_Experiencia_Org.SelectedValue = dt.Rows(0)("Experiencia_Produccion").ToString()

                If Dl_Experiencia_Org.SelectedItem.Text = "Si" Then
                    Experiencia_Previa.Visible = True
                    Experiencia_Previa2.Visible = True
                Else
                    Experiencia_Previa.Visible = False
                    Experiencia_Previa2.Visible = False
                End If
                Text_Anos_Experiencia_new.Text = dt.Rows(0)("Tiempo_Experiencia").ToString()
                Dl_TipoSemillan_Org.SelectedValue = dt.Rows(0)("Tipo_Semilla").ToString()
                Dl_ManejoProyecto_Org.SelectedValue = dt.Rows(0)("Proyecto_Distribucion_Semilla").ToString()
                Dl_ProdujoSemilla_Org.SelectedValue = dt.Rows(0)("Produjo_Semilla_Registrada").ToString()
                Dl_ProdujoSemillaCer_Org.SelectedValue = dt.Rows(0)("Produjo_Semilla_Certificada").ToString()
                Dl_Asistencia_Org.SelectedValue = dt.Rows(0)("Brindo_Asistencia_Tecnica").ToString()
                Dl_ApoyoInscripciones_Org.SelectedValue = dt.Rows(0)("Apoyo_Inscripcion_Senasa").ToString()
                Txt_Otro_Org.Text = dt.Rows(0)("Otra_Experiencia").ToString()
                Dl_Fao_Org.SelectedValue = dt.Rows(0)("Colaboracion_FAO").ToString()
                Txt_OtroInst_Org.Text = dt.Rows(0)("Colaboracion_Otro").ToString()
                Dl_Afiliado_Org.SelectedValue = dt.Rows(0)("Esta_Asociado").ToString()
                Txt_NombreRed_Org.Text = dt.Rows(0)("Nombre_Asociacion").ToString()
                Txt_CantTierra_Org.Text = dt.Rows(0)("Cantidad_Tierra_En_MZ").ToString()
                Dl_Maiz_Org.SelectedValue = dt.Rows(0)("Tiene_Maiz").ToString()
                Txt_CantTerreno_Org.Text = dt.Rows(0)("Cantidad_Terreno_Maiz").ToString()
                Dl_Frijol_Org.SelectedValue = dt.Rows(0)("Tiene_Frijol").ToString()
                Txt_CantTerrenoFrijol_Org.Text = dt.Rows(0)("Cantidad_Terreno_Frijol").ToString()
                Dl_Sorgo_Org.SelectedValue = dt.Rows(0)("Tiene_Sorgo").ToString()
                Txt_CantTerrenoSorgo_Org.Text = dt.Rows(0)("Cantidad_Terreno_Sorgo").ToString()
                Dl_Cafe_Org.SelectedValue = dt.Rows(0)("Tiene_Cafe").ToString()
                Txt_CantTerrenoCafe_Org.Text = dt.Rows(0)("Cantidad_Terreno_Cafe").ToString()
                Dl_Hortaliza_Org.SelectedValue = dt.Rows(0)("Tiene_Hortaliza").ToString()
                Txt_CantTerrenoHortaliza_Org.Text = dt.Rows(0)("Cantidad_Terreno_Hortaliza").ToString()
                Dl_Frutales_Org.SelectedValue = dt.Rows(0)("Tiene_Frutales").ToString()
                txt_CantTerrenoFrutales_Org.Text = dt.Rows(0)("Cantidad_Terreno_Frutales").ToString()
                Dl_Ganaderia_Org.SelectedValue = dt.Rows(0)("Tiene_Ganaderia").ToString()
                Txt_CantTerrenoGanaderia_Org.Text = dt.Rows(0)("Cantidad_Terreno_Ganaderia").ToString()
                Dl_Conservacion_Org.SelectedValue = dt.Rows(0)("Tiene_ConservacionBosque").ToString()
                txt_TerrenoBosque_Org.Text = dt.Rows(0)("Cantidad_Terreno_ConservacionBosque").ToString()
                Dl_OtrosCosecha_Org.SelectedValue = dt.Rows(0)("Tiene_Otros").ToString()
                Txt_TerrenoOtros_Org.Text = dt.Rows(0)("Cantidad_Terreno_Otros").ToString()
                Txt_TipoCultivo_Org.Text = dt.Rows(0)("Espesifique_Tipo").ToString()
                Txt_CantTerrenoMz_Org.Text = dt.Rows(0)("Cantidad_Terreno_Mz_Certificada").ToString()
                Txt_Cantlotes_Org.Text = dt.Rows(0)("Cantidad_Lotes_Disponibles").ToString()
                Dl_topografia_Org.SelectedValue = dt.Rows(0)("Topografia_Adecuada").ToString()

                Dl_Rio_Org.SelectedValue = dt.Rows(0)("Rio_Dentro_Finca").ToString()
                Dl_Pozo_Org.SelectedValue = dt.Rows(0)("Pozo_Dentro_Finca").ToString()
                Dl_OjoAgua_Org.SelectedValue = dt.Rows(0)("OjoDeAgua_Dentro_Finca").ToString()
                Dl_RioFuera_Org.SelectedValue = dt.Rows(0)("Rio_Fuera_Finca").ToString()
                Dl_PozoFuera_Org.SelectedValue = dt.Rows(0)("Pozo_Fuera_Finca").ToString()
                Dl_OjoFuera_Org.SelectedValue = dt.Rows(0)("OjoDeAgua_Fuera_Finca").ToString()
                Dl_SistemaRiego_Org.SelectedValue = dt.Rows(0)("Possee_Sistema_Riego").ToString()
                Dl_TipoSistema_Org.SelectedValue = dt.Rows(0)("Tipo_Sistema_Riego").ToString()
                Dl_NoRequiere_Org.SelectedValue = dt.Rows(0)("No_Requiere").ToString()
                Dl_Combustion_Org.SelectedValue = dt.Rows(0)("Requiere_Combustion").ToString()
                Dl_Electrica_Org.SelectedValue = dt.Rows(0)("Requiere_Electricidad").ToString()
                Dl_Solar_Org.SelectedValue = dt.Rows(0)("Requiere_Energia_Solar").ToString()
                Dl_CaminoCercano_Org.SelectedValue = dt.Rows(0)("Transitan_Vehiculos").ToString()
                Dl_Automovil_Org.SelectedValue = dt.Rows(0)("Transporte_Automovil").ToString()
                Dl_PickUp_Org.SelectedValue = dt.Rows(0)("Transporte_PickUp").ToString()
                Dl_Moto_Org.SelectedValue = dt.Rows(0)("Transporte_Motocicleta").ToString()
                Dl_Bici_Org.SelectedValue = dt.Rows(0)("Transporte_Bicicleta").ToString()
                Dl_Mula_Org.SelectedValue = dt.Rows(0)("Transporte_Caballo_Mula_Macho").ToString()
                Dl_Bodega_Org.SelectedValue = dt.Rows(0)("Tiene_Bodega").ToString()
                Dl_Secadoras_Org.SelectedValue = dt.Rows(0)("Tiene_Secadoras_Solares").ToString()
                Dl_SecaMecanica_Org.SelectedValue = dt.Rows(0)("Tiene_Secadora_Mecanica").ToString()
                Dl_Pc_Org.SelectedValue = dt.Rows(0)("Tiene_Computadoras").ToString()
                Dl_EquipoAspersion_Org.SelectedValue = dt.Rows(0)("Tiene_Equipo_de_Aspersion").ToString()
                Dl_Desgranadora_Org.SelectedValue = dt.Rows(0)("Tiene_Desgranadora").ToString()
                Dl_Zaranda_Org.SelectedValue = dt.Rows(0)("Tiene_Zaranda").ToString()
                Dl_Tractor_Org.SelectedValue = dt.Rows(0)("Tiene_Maquinaria_Tractor").ToString()
                Dl_Arado_Org.SelectedValue = dt.Rows(0)("Tiene_Arado").ToString()
                Dl_Acamadora_Org.SelectedValue = dt.Rows(0)("Tiene_Acamadora").ToString()
                Dl_Sembradora_Org.SelectedValue = dt.Rows(0)("Tiene_Sembradora").ToString()
                Dl_Clasificadora_Org.SelectedValue = dt.Rows(0)("Tiene_Clasificadora").ToString()
                Dl_Pulidora_Org.SelectedValue = dt.Rows(0)("Tiene_Pulidora").ToString()
                Dl_Envasadora_Org.SelectedValue = dt.Rows(0)("Tiene_Envasadora").ToString()
                Dl_Bomba_Org.SelectedValue = dt.Rows(0)("Tiene_Bomba_Riego").ToString()
                Dl_Patio_Org.SelectedValue = dt.Rows(0)("Tiene_Patio_Secado").ToString()
                Dl_OtrasInfra_Org.SelectedValue = dt.Rows(0)("Tiene_Otras").ToString()

                Txt_AreaBajo_Org.Text = dt.Rows(0)("Terreno_Bajo_Riego").ToString()
                Txt_OtraEnergia_Org.Text = dt.Rows(0)("Otro_Tipo_Energia").ToString()
                Txt_DistanciaKm_Org.Text = dt.Rows(0)("Distancia_Ubicacion").ToString()
                Txt_OtroTransporte_Org.Text = dt.Rows(0)("Otro_Transporte").ToString()
                Txt_CantidadBodega_Org.Text = dt.Rows(0)("Cantidad_Bodega").ToString()
                Txt_CantidadSecadores_Org.Text = dt.Rows(0)("Cantidad_Secadora_Solares").ToString()
                Txt_SecaMecanica_Org.Text = dt.Rows(0)("Cantidad_Secadora_Mecanica").ToString()
                Txt_Pc_Org.Text = dt.Rows(0)("Cantidad_Computadoras").ToString()
                Txt_EquipoAspersion_Org.Text = dt.Rows(0)("Cantidad_Equipo_Aspersion").ToString()
                Txt_Desgranadora_Org.Text = dt.Rows(0)("Cantidad_Desgranadora").ToString()
                Txt_Zaranda_Org.Text = dt.Rows(0)("Cantidad_Zaranda").ToString()
                Txt_Tractor_Org.Text = dt.Rows(0)("Cantidad_Maquinaria").ToString()
                Txt_Arado_Org.Text = dt.Rows(0)("Cantidad_Arado").ToString()
                Txt_Acamadora_Org.Text = dt.Rows(0)("Cantidad_Acamadora").ToString()
                Txt_Sembradora_Org.Text = dt.Rows(0)("Cantidad_Sembradora").ToString()
                Txt_Clasificadora_Org.Text = dt.Rows(0)("Cantidad_Clasificadora").ToString()
                Txt_Pulidora_Org.Text = dt.Rows(0)("Cantidad_Pulidora").ToString()
                Txt_Envasadora_Org.Text = dt.Rows(0)("Cantidad_Envasadora").ToString()
                Txt_Bomba_Org.Text = dt.Rows(0)("Cantida_Bomba_Riego").ToString()
                Txt_Patio_Org.Text = dt.Rows(0)("Cantidad_Patio_Secado").ToString()
                Txt_OtrasInfra_Org.Text = dt.Rows(0)("Describa_Otras").ToString()
                DL_Otro_Transporte.SelectedValue = dt.Rows(0)("Otro_Transporte_Si_Org").ToString()

            Else
                If dt.Rows(0)("TIPO_BCS").ToString() = "Individual" Then
                    divdatos.Visible = False
                    div_nuevo_prod.Visible = False
                    divIndividual.Visible = True
                    div4.Visible = False
                    divModifiyIn.Visible = True
                    Lb_Asignar_Acesor_Ind.SelectedValue = dt.Rows(0)("ec_codigo").ToString()
                    'Dl_Departamento_Individual.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()
                    Dl_Departamento_Individual.SelectedValue = dt.Rows(0)("Depto_Cod").ToString()

                    'llenar municipio datos precargador
                    Dim StrCombo As String = "SELECT '00' as CODIGO_MUNICIPIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_MUNICIPIO ,NOMBRE FROM tb_municipio where CODIGO_DEPARTAMENTO = '" & dt.Rows(0)("Depto_Cod").ToString() & "' ORDER BY NOMBRE "
                    Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
                    Dim DtCombo As New DataTable
                    adaptcombo.Fill(DtCombo)
                    Dl_Municipio_Individual.DataSource = DtCombo
                    Dl_Municipio_Individual.DataValueField = DtCombo.Columns(0).ToString()
                    Dl_Municipio_Individual.DataTextField = DtCombo.Columns(1).ToString()
                    Dl_Municipio_Individual.DataBind()
                    Dim municipioSeleccionado As String = dt.Rows(0)("Muni_Descripcion").ToString()

                    ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                    Dim indice As Integer = Dl_Municipio_Individual.Items.IndexOf(Dl_Municipio_Individual.Items.FindByText(municipioSeleccionado))

                    ' Verificar que se encontró el elemento y seleccionarlo
                    If indice >= 0 Then
                        Dl_Municipio_Individual.SelectedIndex = indice
                    End If

                    'llenar aldea datos precargados
                    Dim StrCombo1 As String = "SELECT '00' as CODIGO_ALDEA, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_ALDEA ,NOMBRE FROM tb_aldea where CODIGO_MUNICIPIO = '" & Dl_Municipio_Individual.SelectedValue & "' ORDER BY NOMBRE "
                    Dim adaptcombo1 As New MySqlDataAdapter(StrCombo1, conn)
                    Dim DtCombo1 As New DataTable
                    adaptcombo1.Fill(DtCombo1)

                    Dl_Aldea_Individual.DataSource = DtCombo1
                    Dl_Aldea_Individual.DataValueField = DtCombo1.Columns(0).ToString()
                    Dl_Aldea_Individual.DataTextField = DtCombo1.Columns(1).ToString()
                    Dl_Aldea_Individual.DataBind()
                    Dim aldeaSeleccionado As String = dt.Rows(0)("Aldea_Descripcion").ToString()

                    ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                    Dim indice1 As Integer = Dl_Aldea_Individual.Items.IndexOf(Dl_Aldea_Individual.Items.FindByText(aldeaSeleccionado))

                    ' Verificar que se encontró el elemento y seleccionarlo
                    If indice1 >= 0 Then
                        Dl_Aldea_Individual.SelectedIndex = indice1
                    End If

                    'para traer el caserio
                    Dim StrCombo2 As String = "SELECT '00' as CODIGO_CASERIO, ' Todos' as NOMBRE UNION SELECT DISTINCT CODIGO_CASERIO ,NOMBRE FROM tb_caserios where CODIGO_ALDEA = '" & Dl_Aldea_Individual.SelectedValue & "' ORDER BY NOMBRE "
                    Dim adaptcombo2 As New MySqlDataAdapter(StrCombo2, conn)
                    Dim DtCombo2 As New DataTable
                    adaptcombo2.Fill(DtCombo2)

                    Dl_Caserio_Individual.DataSource = DtCombo2
                    Dl_Caserio_Individual.DataValueField = DtCombo2.Columns(0).ToString()
                    Dl_Caserio_Individual.DataTextField = DtCombo2.Columns(1).ToString()
                    Dl_Caserio_Individual.DataBind()
                    Dim caserio As String = dt.Rows(0)("Caserio_Descripcion").ToString()

                    ' Buscar el índice del elemento que coincida con el valor deseado en el DataTable
                    Dim indice2 As Integer = Dl_Caserio_Individual.Items.IndexOf(Dl_Caserio_Individual.Items.FindByText(caserio))

                    ' Verificar que se encontró el elemento y seleccionarlo
                    If indice2 >= 0 Then
                        Dl_Caserio_Individual.SelectedIndex = indice2
                    End If



                    Dl_Sexo_In.SelectedValue = dt.Rows(0)("PROD_SEXO").ToString()

                    Txt_Edad_In.Text = dt.Rows(0)("Prod_Edades").ToString()

                    Txt_Dni_In.Text = dt.Rows(0)("PROD_IDENTIDAD").ToString()

                    Txt_Rtn_In.Text = dt.Rows(0)("Prod_RTN").ToString()

                    Txt_Telefono_In.Text = dt.Rows(0)("PROD_TELEFONO").ToString()

                    Fecha_Individual.Text = dt.Rows(0)("FECHA_REGISTRO").ToString()

                    Dl_Cuenta_IN.SelectedValue = dt.Rows(0)("Cuenta_Bancaria").ToString()

                    Dl_Ahorro_In.SelectedValue = dt.Rows(0)("Cuenta_Ahorro").ToString()

                    Dl_Bancos_In.SelectedValue = dt.Rows(0)("Lista_De_Bancos").ToString()

                    txt_NCuenta_In.Text = dt.Rows(0)("Cuenta_Bancos").ToString()

                    Txt_NombreBen_In.Text = dt.Rows(0)("Nombre_Beneficiario").ToString()

                    Dl_Grupo_Edad.SelectedValue = dt.Rows(0)("Grupo_Edad").ToString()
                    Txt_Maculino_In.Text = dt.Rows(0)("Cantidad_Hombres_Hogar").ToString()
                    Txt_Femenino_In.Text = dt.Rows(0)("Cantidad_Mujeres_Hogar").ToString()
                    txt_Hombres_Involucrados.Text = dt.Rows(0)("Hombres_Involucrados").ToString()
                    txt_Mujeres_Involucrados.Text = dt.Rows(0)("Mujeres_Involucradas").ToString()
                    Dl_Semilla_Frijol.SelectedValue = dt.Rows(0)("Productos_Semilla_Frijol").ToString()
                    Tiene_Experiencia.SelectedValue = dt.Rows(0)("Experiencia_Produccion").ToString()
                    Cantidad_Anos.Text = dt.Rows(0)("Tiempo_Experiencia").ToString()
                    Tipo_Semilla.Text = dt.Rows(0)("Tipo_Semilla").ToString()
                    Distribucion_Semilla.SelectedValue = dt.Rows(0)("Proyecto_Distribucion_Semilla").ToString()
                    Semilla_Registrada.SelectedValue = dt.Rows(0)("Produjo_Semilla_Registrada").ToString()
                    Semilla_Certificada.SelectedValue = dt.Rows(0)("Produjo_Semilla_Certificada").ToString()
                    Asistencia_Tecnica.SelectedValue = dt.Rows(0)("Brindo_Asistencia_Tecnica").ToString()
                    Apoyo_Inscripciones_Senasa.SelectedValue = dt.Rows(0)("Apoyo_Inscripcion_Senasa").ToString()
                    Otra_Produccion.Text = dt.Rows(0)("Otra_Experiencia").ToString()

                    Dl_Fao_In.SelectedValue = dt.Rows(0)("Colaboracion_FAO").ToString()
                    Txt_Otro_Inst_In.Text = dt.Rows(0)("Colaboracion_Otro").ToString()
                    Dl_Afiliado_In.SelectedValue = dt.Rows(0)("Esta_Asociado").ToString()
                    Txt_CantierraMz_In.Text = dt.Rows(0)("Cantidad_Tierra_En_MZ").ToString()
                    Dl_Maiz_In.SelectedValue = dt.Rows(0)("Tiene_Maiz").ToString()
                    Txt_CantTerreno_In.Text = dt.Rows(0)("Cantidad_Terreno_Maiz").ToString()
                    Dl_Frijol_In.SelectedValue = dt.Rows(0)("Tiene_Frijol").ToString()
                    Txt_CantTerrenoFrijol_In.Text = dt.Rows(0)("Cantidad_Terreno_Frijol").ToString()
                    Dl_Sorgo_In.SelectedValue = dt.Rows(0)("Tiene_Sorgo").ToString()
                    Txt_CantSorgo_In.Text = dt.Rows(0)("Cantidad_Terreno_Sorgo").ToString()
                    Dl_Cafe_In.SelectedValue = dt.Rows(0)("Tiene_Cafe").ToString()
                    Txt_CantCafe_In.Text = dt.Rows(0)("Cantidad_Terreno_Cafe").ToString()
                    Dl_Hortaliza_In.SelectedValue = dt.Rows(0)("Tiene_Hortaliza").ToString()
                    Txt_CantHortaliza_In.Text = dt.Rows(0)("Cantidad_Terreno_Hortaliza").ToString()
                    Dl_Frutales_In.SelectedValue = dt.Rows(0)("Tiene_Frutales").ToString()
                    Txt_CantFrutales_In.Text = dt.Rows(0)("Cantidad_Terreno_Frutales").ToString()
                    Dl_Ganaderia_In.SelectedValue = dt.Rows(0)("Tiene_Ganaderia").ToString()
                    Dl_CantGanaderia_In.Text = dt.Rows(0)("Cantidad_Terreno_Ganaderia").ToString()
                    Dl_Conservacion_In.SelectedValue = dt.Rows(0)("Tiene_ConservacionBosque").ToString()
                    Dl_CantTerreno_In.Text = dt.Rows(0)("Cantidad_Terreno_ConservacionBosque").ToString()
                    DlOtroTerreno_IN.SelectedValue = dt.Rows(0)("Tiene_Otros").ToString()
                    Txt_TerrenoOtros_Org.Text = dt.Rows(0)("Cantidad_Terreno_Otros").ToString()
                    Txt_CantTipoOtro_In.Text = dt.Rows(0)("Espesifique_Tipo").ToString()
                    Txt_CantTerrenoMz_IN.Text = dt.Rows(0)("Cantidad_Terreno_Mz_Certificada").ToString()
                    Txt_CantLotesDis_IN.Text = dt.Rows(0)("Cantidad_Lotes_Disponibles").ToString()
                    Dl_Pendiente_In.SelectedValue = dt.Rows(0)("Topografia_Adecuada").ToString()
                    Dl_Rio_In.SelectedValue = dt.Rows(0)("Rio_Dentro_Finca").ToString()
                    Dl_Pozo_In.SelectedValue = dt.Rows(0)("Pozo_Dentro_Finca").ToString()
                    Dl_OjoAguaIn_In.SelectedValue = dt.Rows(0)("OjoDeAgua_Dentro_Finca").ToString()
                    Dl_RioFuera_IN.SelectedValue = dt.Rows(0)("Rio_Fuera_Finca").ToString()
                    Dl_PozoFuera_IN.SelectedValue = dt.Rows(0)("Pozo_Fuera_Finca").ToString()
                    Dl_OjoFuera_Org.SelectedValue = dt.Rows(0)("OjoDeAgua_Fuera_Finca").ToString()
                    Dl_SistemaRiego_In.SelectedValue = dt.Rows(0)("Possee_Sistema_Riego").ToString()
                    Dl_TipoSisistema_In.SelectedValue = dt.Rows(0)("Tipo_Sistema_Riego").ToString()
                    Txt_AreaRiego_IN.Text = dt.Rows(0)("Terreno_Bajo_Riego").ToString()
                    Dl_RequiereSistema_In.SelectedValue = dt.Rows(0)("No_Requiere").ToString()
                    Dl_Combustion_In.SelectedValue = dt.Rows(0)("Requiere_Combustion").ToString()
                    Dl_Electrica_Org.SelectedValue = dt.Rows(0)("Requiere_Electricidad").ToString()
                    Dl_Solar_In.SelectedValue = dt.Rows(0)("Requiere_Energia_Solar").ToString()
                    Txt_OtraEnergia_In.Text = dt.Rows(0)("Otro_Tipo_Energia").ToString()
                    Txt_DistanciaKm_IN.Text = dt.Rows(0)("Distancia_Ubicacion").ToString()
                    Dl_CaminoPropiedad_IN.SelectedValue = dt.Rows(0)("Transitan_Vehiculos").ToString()
                    Dl_Auto_in.SelectedValue = dt.Rows(0)("Transporte_Automovil").ToString()
                    Dl_Pick_IN.SelectedValue = dt.Rows(0)("Transporte_PickUp").ToString()
                    Dl_Moto_In.SelectedValue = dt.Rows(0)("Transporte_Motocicleta").ToString()
                    Dl_Bici_In.SelectedValue = dt.Rows(0)("Transporte_Bicicleta").ToString()
                    Dl_Caballo_In.SelectedValue = dt.Rows(0)("Transporte_Caballo_Mula_Macho").ToString()
                    Txt_OtroTrans_In.Text = dt.Rows(0)("Otro_Transporte").ToString()
                    Dl_Bodega_In.SelectedValue = dt.Rows(0)("Tiene_Bodega").ToString()
                    Dl_CantBodega_In.Text = dt.Rows(0)("Cantidad_Bodega").ToString()
                    Dl_Secadora_In.SelectedValue = dt.Rows(0)("Tiene_Secadoras_Solares").ToString()
                    Dl_CantSecadora_In.Text = dt.Rows(0)("Cantidad_Secadora_Solares").ToString()
                    Dl_SecMecanica_In.SelectedValue = dt.Rows(0)("Tiene_Secadora_Mecanica").ToString()
                    Dl_CantSecMecanica_In.Text = dt.Rows(0)("Cantidad_Secadora_Mecanica").ToString()
                    Dl_Pc_In.SelectedValue = dt.Rows(0)("Tiene_Computadoras").ToString()
                    Txt_CantPc_In.Text = dt.Rows(0)("Cantidad_Computadoras").ToString()
                    Dl_Equipo_In.SelectedValue = dt.Rows(0)("Tiene_Equipo_de_Aspersion").ToString()
                    Dl_CantEquipo_In.Text = dt.Rows(0)("Cantidad_Equipo_Aspersion").ToString()
                    Dl_Des_In.SelectedValue = dt.Rows(0)("Tiene_Desgranadora").ToString()
                    Txt_CantDes_IN.Text = dt.Rows(0)("Cantidad_Desgranadora").ToString()
                    Dl_Zaranda_In.SelectedValue = dt.Rows(0)("Tiene_Zaranda").ToString()
                    Txt_CantZara_IN.Text = dt.Rows(0)("Cantidad_Zaranda").ToString()
                    Dl_Maquinaria_IN.SelectedValue = dt.Rows(0)("Tiene_Maquinaria_Tractor").ToString()
                    Txt_CantidadMaquinaria_In.Text = dt.Rows(0)("Cantidad_Maquinaria").ToString()
                    Dl_Arado_IN.SelectedValue = dt.Rows(0)("Tiene_Arado").ToString()
                    Txt_CantidadArado_In.Text = dt.Rows(0)("Cantidad_Arado").ToString()
                    Dl_Aca_In.SelectedValue = dt.Rows(0)("Tiene_Acamadora").ToString()
                    Dl_CantAca_In.Text = dt.Rows(0)("Cantidad_Acamadora").ToString()
                    Dl_Sembra_In.SelectedValue = dt.Rows(0)("Tiene_Sembradora").ToString()
                    Dl_CantSembra_In.Text = dt.Rows(0)("Cantidad_Sembradora").ToString()
                    Dl_Clasifica_In.SelectedValue = dt.Rows(0)("Tiene_Clasificadora").ToString()
                    Txt_CantidadClasifica_IN.Text = dt.Rows(0)("Cantidad_Clasificadora").ToString()
                    Dl_Pulidora_In.SelectedValue = dt.Rows(0)("Tiene_Pulidora").ToString()
                    Txt_CanPuli_IN.Text = dt.Rows(0)("Cantidad_Pulidora").ToString()
                    Dl_Envasa_In.SelectedValue = dt.Rows(0)("Tiene_Envasadora").ToString()
                    Txt_CantEnvasa_In.Text = dt.Rows(0)("Cantidad_Envasadora").ToString()
                    Dl_Bomba_In.SelectedValue = dt.Rows(0)("Tiene_Bomba_Riego").ToString()
                    Txt_CanTBomba_IN.Text = dt.Rows(0)("Cantida_Bomba_Riego").ToString()
                    Dl_Patio_IN.SelectedValue = dt.Rows(0)("Tiene_Patio_Secado").ToString()
                    Dl_PatioCant_IN.Text = dt.Rows(0)("Cantidad_Patio_Secado").ToString()
                    Dl_OtrasCosas_IN.SelectedValue = dt.Rows(0)("Tiene_Otras").ToString()
                    Txt_OtrasCosas_IN.Text = dt.Rows(0)("Describa_Otras").ToString()
                    DL_Otro_Transporte_In.SelectedValue = dt.Rows(0)("Otro_Transporte_Si_Individual").ToString()





                    'Dl_Municipio_Individual. DataSource = dt.Rows(0) ("Muni_Descripcion").ToString()
                    'Dl_Aldea_Individual.DataSource = dt.Rows(0)("Aldea_Descripcion").ToString()

                    'txt_id.Text = dt.Rows(0)("Id").ToString()
                    Txt_Nombre_Completo_IN.Text = dt.Rows(0)("PROD_NOMBRE").ToString()
                End If

            End If

        End If

    End Sub

    Private Sub calcular_socios()
        txt_socio_total.Text = Convert.ToDecimal(txt_socio_H.Text) + Convert.ToDecimal(txt_socio_m.Text)

    End Sub

    Private Sub validarBotonOrganizacion()

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

    Private Sub validar_NEW_Indiviual()
        Dim dep, mun, aldea, caserio, nombre, dni, telefono, socioH, EC, TOTAL As Integer

        '1
        If Dl_Departamento_Individual.SelectedValue = "00" Then
            dep = 1
            Lb_depto_In.Text = "*"
        Else
            dep = 0
            Lb_depto_In.Text = ""
        End If

        '2
        If Dl_Municipio_Individual.SelectedValue = "00" Then
            mun = 1
            Lb_Muni_IN.Text = "*"
        Else
            mun = 0
            Lb_Muni_IN.Text = ""
        End If

        '3
        If Dl_Aldea_Individual.SelectedValue = "00" Then
            aldea = 1
            Lb_aldea_In.Text = "*"
        Else
            aldea = 0
            Lb_aldea_In.Text = ""
        End If

        '4
        If Dl_Caserio_Individual.SelectedValue = "00" Then
            caserio = 1
            Lb_caseerio_In.Text = "*"
        Else
            caserio = 0
            Lb_caseerio_In.Text = ""
        End If

        '5
        If Txt_Nombre_Completo_IN.Text = "" Then
            nombre = 1
            Lb_nombre_in.Text = "*"
        Else
            nombre = 0
            Lb_nombre_in.Text = ""
        End If
        '6

        If Txt_Dni_In.Text.Length = 13 Then
            dni = 0
            Lb_Dni_In.Text = ""
        Else
            dni = 1
            Lb_Dni_In.Text = "*"

        End If
        '7
        If Txt_Telefono_In.Text.Length = 8 Then
            telefono = 0
            Lb_Tel_In.Text = ""
        Else
            telefono = 1
            Lb_Tel_In.Text = "*"

        End If
        '8
        If Txt_Edad_In.Text = "" Then
            socioH = 1
            Lb_Edad_In.Text = "*"
        Else
            socioH = 0
            Lb_Edad_In.Text = ""
        End If

        If Lb_Asignar_Acesor_Ind.SelectedValue = "00" Then
            EC = 1
        Else
            EC = 0
        End If

        TOTAL = dep + mun + aldea + caserio + nombre + dni + telefono + socioH + EC

        If TOTAL = 0 Then
            Button2.Visible = True
        Else
            Button2.Visible = False
        End If

    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxTdepto.SelectedIndexChanged
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
        Dim dt As New DataTable()
        For Each col As DataControlField In GridDatos.Columns
            If col.Visible Then
                dt.Columns.Add(col.HeaderText)
            End If
        Next

        For Each row As GridViewRow In GridDatos.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim dr As DataRow = dt.NewRow()
                For i As Integer = 0 To dt.Columns.Count - 1
                    dr(i) = row.Cells(i).Text.Replace("&nbsp;", "")
                Next
                dt.Rows.Add(dr)
            End If
        Next

        ' Exportar DataTable a Excel
        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt, "Registros_Bancos_Semilla")

            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=Registro_Organizaciones.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.End()
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

    Protected Sub btnsi_Click(sender As Object, e As EventArgs) Handles btnsiActualizarOrg.Click
        Dim id = Txt_Id_Eliminar.Text
        Dim TipoBanco = "Organizacion"
        Try
            Dim conex As New MySqlConnection(conn)
            conex.Open()

            Dim Sql As String
            Dim cmd As New MySqlCommand()

            Sql = "UPDATE `registros_bancos_semilla` SET ec_codigo=@ec_codigo, ec_nombre=@ec_nombre, Depto_Cod=@Depto_Cod, Depto_Descripcion=@Depto_Descripcion, Muni_Descripcion=@Muni_Descripcion, Aldea_Descripcion=@Aldea_Descripcion, Caserio_Descripcion=@Caserio_Descripcion, FECHA_REGISTRO=@FECHA_REGISTRO, OP_NOMBRE=@OP_NOMBRE, OP_REPRESENTANTE_CARGO=@OP_REPRESENTANTE_CARGO, OP_REPRESENTANTE_SEXO=@OP_REPRESENTANTE_SEXO, OP_REPRESENTANTE_EDAD=@OP_REPRESENTANTE_EDAD, OP_REPRESENTANTE_ID=@OP_REPRESENTANTE_ID, OP_REPRESENTANTE_TELEFONO=@OP_REPRESENTANTE_TELEFONO, OP_MIEMBROS_Hombres=@OP_MIEMBROS_Hombres, OP_MIEMBROS_Mujeres=@OP_MIEMBROS_Mujeres,Op_Nombre_Organizacion=@Op_Nombre_Organizacion,Op_Direccion_Organizacion=@Op_Direccion_Organizacion, OP_TIPO=@OP_TIPO, OP_PERSONERIA=@OP_PERSONERIA, OP_RTN=@OP_RTN, OP_RTN_NUM=@OP_RTN_NUM, OP_CAI=@OP_CAI, OP_CAI_NUM=@OP_CAI_NUM, TIPO_BCS=@TIPO_BCS, Cuenta_Bancaria=@Cuenta_Bancaria, Cuenta_Ahorro=@Cuenta_Ahorro, Lista_De_Bancos=@Lista_De_Bancos, Cuenta_Bancos=@Cuenta_Bancos, Nombre_Beneficiario=@Nombre_Beneficiario, Experiencia_Produccion=@Experiencia_Produccion, Tiempo_Experiencia=@Tiempo_Experiencia, Tipo_Semilla=@Tipo_Semilla, Proyecto_Distribucion_Semilla=@Proyecto_Distribucion_Semilla, Produjo_Semilla_Registrada=@Produjo_Semilla_Registrada, Produjo_Semilla_Certificada=@Produjo_Semilla_Certificada, Brindo_Asistencia_Tecnica=@Brindo_Asistencia_Tecnica, Apoyo_Inscripcion_Senasa=@Apoyo_Inscripcion_Senasa, Otra_Experiencia=@Otra_Experiencia, Colaboracion_FAO=@Colaboracion_FAO, Colaboracion_Otro=@Colaboracion_Otro, Esta_Asociado=@Esta_Asociado, Nombre_Asociacion=@Nombre_Asociacion, Cantidad_Tierra_En_MZ=@Cantidad_Tierra_En_MZ, Tiene_Maiz=@Tiene_Maiz, Cantidad_Terreno_Maiz=@Cantidad_Terreno_Maiz, Tiene_Frijol=@Tiene_Frijol, Cantidad_Terreno_Frijol=@Cantidad_Terreno_Frijol, Tiene_Sorgo=@Tiene_Sorgo, Cantidad_Terreno_Sorgo=@Cantidad_Terreno_Sorgo, Tiene_Cafe=@Tiene_Cafe, Cantidad_Terreno_Hortaliza=@Cantidad_Terreno_Hortaliza, Tiene_Hortaliza=@Tiene_Hortaliza, Tiene_Frutales=@Tiene_Frutales, Cantidad_Terreno_Frutales=@Cantidad_Terreno_Frutales, Tiene_Ganaderia=@Tiene_Ganaderia, Cantidad_Terreno_Ganaderia=@Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque=@Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque=@Cantidad_Terreno_ConservacionBosque, Tiene_Otros=@Tiene_Otros, Cantidad_Terreno_Otros=@Cantidad_Terreno_Otros, Espesifique_Tipo=@Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada=@Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles=@Cantidad_Lotes_Disponibles, Topografia_Adecuada=@Topografia_Adecuada, Rio_Dentro_Finca=@Rio_Dentro_Finca, Pozo_Dentro_Finca=@Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca=@OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca=@Rio_Fuera_Finca, Pozo_Fuera_Finca=@Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca=@OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego=@Possee_Sistema_Riego, Tipo_Sistema_Riego=@Tipo_Sistema_Riego, Terreno_Bajo_Riego=@Terreno_Bajo_Riego, No_Requiere=@No_Requiere, Requiere_Combustion=@Requiere_Combustion, Requiere_Electricidad=@Requiere_Electricidad, Requiere_Energia_Solar=@Requiere_Energia_Solar, Otro_Tipo_Energia=@Otro_Tipo_Energia, Distancia_Ubicacion=@Distancia_Ubicacion, Transitan_Vehiculos=@Transitan_Vehiculos, Transporte_Automovil=@Transporte_Automovil, Transporte_PickUp=@Transporte_PickUp, Transporte_Motocicleta=@Transporte_Motocicleta, Transporte_Bicicleta=@Transporte_Bicicleta, Transporte_Caballo_Mula_Macho=@Transporte_Caballo_Mula_Macho, Otro_Transporte=@Otro_Transporte, Tiene_Bodega=@Tiene_Bodega, Cantidad_Bodega=@Cantidad_Bodega, Tiene_Secadoras_Solares=@Tiene_Secadoras_Solares, Cantidad_Secadora_Solares=@Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica=@Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica=@Cantidad_Secadora_Mecanica, Tiene_Computadoras=@Tiene_Computadoras, Cantidad_Computadoras=@Cantidad_Computadoras, Tiene_Equipo_de_Aspersion=@Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion=@Cantidad_Equipo_Aspersion, Tiene_Desgranadora=@Tiene_Desgranadora, Cantidad_Desgranadora=@Cantidad_Desgranadora, Tiene_Zaranda=@Tiene_Zaranda, Cantidad_Zaranda=@Cantidad_Zaranda, Tiene_Maquinaria_Tractor=@Tiene_Maquinaria_Tractor, Cantidad_Maquinaria=@Cantidad_Maquinaria, Tiene_Arado=@Tiene_Arado, Cantidad_Arado=@Cantidad_Arado, Tiene_Acamadora=@Tiene_Acamadora, Cantidad_Acamadora=@Cantidad_Acamadora, Tiene_Sembradora=@Tiene_Sembradora, Cantidad_Sembradora=@Cantidad_Sembradora, Tiene_Clasificadora=@Tiene_Clasificadora, Cantidad_Clasificadora=@Cantidad_Clasificadora, Tiene_Pulidora=@Tiene_Pulidora, Cantidad_Pulidora=@Cantidad_Pulidora, Tiene_Envasadora=@Tiene_Envasadora, Cantidad_Envasadora=@Cantidad_Envasadora, Tiene_Bomba_Riego=@Tiene_Bomba_Riego, Cantida_Bomba_Riego=@Cantida_Bomba_Riego, Tiene_Patio_Secado=@Tiene_Patio_Secado, Cantidad_Patio_Secado=@Cantidad_Patio_Secado, Tiene_Otras=@Tiene_Otras, Describa_Otras=@Describa_Otras , Otro_Transporte_Si_Org=@Otro_Transporte_Si_Org WHERE id=@Id "
            cmd.Connection = conex




            cmd.Parameters.AddWithValue("@ec_codigo", gb_ec_new.SelectedValue)
            cmd.Parameters.AddWithValue("@ec_nombre", gb_ec_new.Text)
            cmd.Parameters.AddWithValue("@Depto_Cod", gb_departamento_new.SelectedValue)
            cmd.Parameters.AddWithValue("@Depto_Descripcion", gb_departamento_new.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Muni_Descripcion", gb_municipio_new.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Aldea_Descripcion", gb_aldea_new.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Caserio_Descripcion", gb_caserio_new.SelectedItem.Text)

            cmd.Parameters.AddWithValue("@FECHA_REGISTRO", TXT_FECHA_CREATE_OP.Text)

            cmd.Parameters.AddWithValue("@OP_NOMBRE", txt_nombre_prod_new.Text)

            cmd.Parameters.AddWithValue("@OP_REPRESENTANTE_CARGO", gb_cargo_nuevo.Text)
            cmd.Parameters.AddWithValue("@OP_REPRESENTANTE_SEXO", gb_sexo_new.Text)
            cmd.Parameters.AddWithValue("@OP_REPRESENTANTE_EDAD", txtEdadRepresentante.Text)
            cmd.Parameters.AddWithValue("@OP_REPRESENTANTE_ID", txt_dni_new.Text)
            cmd.Parameters.AddWithValue("@OP_REPRESENTANTE_TELEFONO", txt_telefono_new.Text)
            cmd.Parameters.AddWithValue("@OP_MIEMBROS_Hombres", TXT_SOCIO_H_NEW.Text)
            cmd.Parameters.AddWithValue("@OP_MIEMBROS_Mujeres", TXT_SOCIO_M_NEW.Text)
            cmd.Parameters.AddWithValue("@Op_Nombre_Organizacion", Dl_OP_Todos.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Op_Direccion_Organizacion", TXT_OPDIRECCION_NEW.Text)
            cmd.Parameters.AddWithValue("@OP_TIPO", gb_tipo_new.Text)
            cmd.Parameters.AddWithValue("@OP_PERSONERIA", GB_PERSONERIA_new.Text)
            cmd.Parameters.AddWithValue("@OP_RTN", GB_RTN_new.Text)
            cmd.Parameters.AddWithValue("@OP_RTN_NUM", TXT_RTN_new.Text)
            cmd.Parameters.AddWithValue("@OP_CAI", GB_CAI_new.Text)
            cmd.Parameters.AddWithValue("@OP_CAI_NUM", TXT_CAI_new.Text)
            cmd.Parameters.AddWithValue("@TIPO_BCS", TipoBanco)
            cmd.Parameters.AddWithValue("@Cuenta_Bancaria", Dl_CuentaBancaria_Org.Text)
            cmd.Parameters.AddWithValue("@Cuenta_Ahorro", Dl_CuentaAhorroBanco_Org.Text)
            cmd.Parameters.AddWithValue("@Lista_De_Bancos", Dl_ListaBancosAhorro_Org.Text)
            cmd.Parameters.AddWithValue("@Cuenta_Bancos", txt_cuentaAhorroBanco_org.Text)
            cmd.Parameters.AddWithValue("@Nombre_Beneficiario", txt_BeneficiaroAhorro_Org.Text)

            cmd.Parameters.AddWithValue("@Experiencia_Produccion", Dl_Experiencia_Org.Text)
            cmd.Parameters.AddWithValue("@Tiempo_Experiencia", Text_Anos_Experiencia_new.Text)
            cmd.Parameters.AddWithValue("@Tipo_Semilla", Dl_TipoSemillan_Org.Text)
            cmd.Parameters.AddWithValue("@Proyecto_Distribucion_Semilla", Dl_ManejoProyecto_Org.Text)
            cmd.Parameters.AddWithValue("@Produjo_Semilla_Registrada", Dl_ProdujoSemilla_Org.Text)
            cmd.Parameters.AddWithValue("@Produjo_Semilla_Certificada", Dl_ProdujoSemillaCer_Org.Text)
            cmd.Parameters.AddWithValue("@Brindo_Asistencia_Tecnica", Dl_Asistencia_Org.Text)
            cmd.Parameters.AddWithValue("@Apoyo_Inscripcion_Senasa", Dl_ApoyoInscripciones_Org.Text)
            cmd.Parameters.AddWithValue("@Otra_Experiencia", Txt_Otro_Org.Text)
            cmd.Parameters.AddWithValue("@Colaboracion_FAO", Dl_Fao_Org.Text)

            cmd.Parameters.AddWithValue("@Colaboracion_Otro", Txt_OtroInst_Org.Text)
            cmd.Parameters.AddWithValue("@Esta_Asociado", Dl_Afiliado_Org.Text)
            cmd.Parameters.AddWithValue("@Nombre_Asociacion", Txt_NombreRed_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Tierra_En_MZ", Txt_CantTierra_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Maiz", Dl_Maiz_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Maiz", Txt_CantTerreno_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Frijol", Dl_Frijol_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Frijol", Txt_CantTerrenoFrijol_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Sorgo", Dl_Sorgo_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Sorgo", Txt_CantTerrenoSorgo_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Cafe", Dl_Cafe_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Cafe", Txt_CantTerrenoCafe_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Hortaliza", Dl_Hortaliza_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Hortaliza", Txt_CantTerrenoHortaliza_Org.Text)

            cmd.Parameters.AddWithValue("@Tiene_Frutales", Dl_Frutales_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Frutales", txt_CantTerrenoFrutales_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Ganaderia", Dl_Ganaderia_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Ganaderia", Txt_CantTerrenoGanaderia_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_ConservacionBosque", Dl_Conservacion_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_ConservacionBosque", txt_TerrenoBosque_Org.Text)

            cmd.Parameters.AddWithValue("@Tiene_Otros", Dl_OtrosCosecha_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Otros", Txt_TerrenoOtros_Org.Text)
            cmd.Parameters.AddWithValue("@Espesifique_Tipo", Txt_TipoCultivo_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Mz_Certificada", Txt_CantTerrenoMz_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Lotes_Disponibles", Txt_Cantlotes_Org.Text)
            cmd.Parameters.AddWithValue("@Topografia_Adecuada", Dl_topografia_Org.Text)


            cmd.Parameters.AddWithValue("@Rio_Dentro_Finca", Dl_Rio_Org.Text)
            cmd.Parameters.AddWithValue("@Pozo_Dentro_Finca", Dl_Pozo_Org.Text)
            cmd.Parameters.AddWithValue("@OjoDeAgua_Dentro_Finca", Dl_OjoAgua_Org.Text)
            cmd.Parameters.AddWithValue("@Rio_Fuera_Finca", Dl_RioFuera_Org.Text)

            cmd.Parameters.AddWithValue("@Pozo_Fuera_Finca", Dl_PozoFuera_Org.Text)
            cmd.Parameters.AddWithValue("@OjoDeAgua_Fuera_Finca", Dl_OjoFuera_Org.Text)
            cmd.Parameters.AddWithValue("@Possee_Sistema_Riego", Dl_SistemaRiego_Org.Text)
            cmd.Parameters.AddWithValue("@Tipo_Sistema_Riego", Dl_TipoSistema_Org.Text)
            cmd.Parameters.AddWithValue("@Terreno_Bajo_Riego", Txt_AreaBajo_Org.Text)

            cmd.Parameters.AddWithValue("@No_Requiere", Dl_NoRequiere_Org.Text)
            cmd.Parameters.AddWithValue("@Requiere_Combustion", Dl_Combustion_Org.Text)
            cmd.Parameters.AddWithValue("@Requiere_Electricidad", Dl_Electrica_Org.Text)
            cmd.Parameters.AddWithValue("@Requiere_Energia_Solar", Dl_Solar_Org.Text)
            cmd.Parameters.AddWithValue("@Otro_Tipo_Energia", Txt_OtraEnergia_Org.Text)

            cmd.Parameters.AddWithValue("@Distancia_Ubicacion", Txt_DistanciaKm_Org.Text)
            cmd.Parameters.AddWithValue("@Transitan_Vehiculos", Dl_CaminoCercano_Org.Text)
            cmd.Parameters.AddWithValue("@Transporte_Automovil", Dl_Automovil_Org.Text)
            cmd.Parameters.AddWithValue("@Transporte_PickUp", Dl_PickUp_Org.Text)
            cmd.Parameters.AddWithValue("@Transporte_Motocicleta", Dl_Moto_Org.Text)
            cmd.Parameters.AddWithValue("@Transporte_Bicicleta", Dl_Bici_Org.Text)

            cmd.Parameters.AddWithValue("@Transporte_Caballo_Mula_Macho", Dl_Mula_Org.Text)
            cmd.Parameters.AddWithValue("@Otro_Transporte", Txt_OtroTransporte_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Bodega", Dl_Bodega_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Bodega", Txt_CantidadBodega_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Secadoras_Solares", Dl_Secadoras_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Secadora_Solares", Txt_CantidadSecadores_Org.Text)

            cmd.Parameters.AddWithValue("@Tiene_Secadora_Mecanica", Dl_SecaMecanica_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Secadora_Mecanica", Txt_SecaMecanica_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Computadoras", Dl_Pc_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Computadoras", Txt_Pc_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Equipo_de_Aspersion", Dl_EquipoAspersion_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Equipo_Aspersion", Txt_EquipoAspersion_Org.Text)

            cmd.Parameters.AddWithValue("@Tiene_Desgranadora", Dl_Desgranadora_Org.Text)

            cmd.Parameters.AddWithValue("@Cantidad_Desgranadora", Txt_Desgranadora_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Zaranda", Dl_Zaranda_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Zaranda", Txt_Zaranda_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Maquinaria_Tractor", Dl_Tractor_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Maquinaria", Txt_Tractor_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Arado", Dl_Arado_Org.Text)

            cmd.Parameters.AddWithValue("@Cantidad_Arado", Txt_Arado_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Acamadora", Dl_Acamadora_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Acamadora", Txt_Acamadora_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Sembradora", Dl_Sembradora_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Sembradora", Txt_Sembradora_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Clasificadora", Dl_Clasificadora_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Clasificadora", Txt_Clasificadora_Org.Text)

            cmd.Parameters.AddWithValue("@Tiene_Pulidora", Dl_Pulidora_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Pulidora", Txt_Pulidora_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Envasadora", Dl_Envasadora_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Envasadora", Txt_Envasadora_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Bomba_Riego", Dl_Bomba_Org.Text)
            cmd.Parameters.AddWithValue("@Cantida_Bomba_Riego", Txt_Bomba_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Patio_Secado", Dl_Patio_Org.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Patio_Secado", Txt_Patio_Org.Text)
            cmd.Parameters.AddWithValue("@Tiene_Otras", Dl_OtrasInfra_Org.Text)
            cmd.Parameters.AddWithValue("@Describa_Otras", Txt_OtrasInfra_Org.Text)
            cmd.Parameters.AddWithValue("@Otro_Transporte_Si_Org", DL_Otro_Transporte.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
            conex.Close()
            llenagrid()
        Catch ex As Exception
            ' Capturar y mostrar el mensaje de error en caso de excepción
            Dim errorMessage As String = "Error al intentar actualizar el registro: " & ex.Message
            MsgBox(errorMessage)
        End Try

        ' Realizar la redirección después de la ejecución del bloque Try...Catch
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))

    End Sub

    Protected Sub btnsiActualizarIn_Click(sender As Object, e As EventArgs) Handles btnsiActualizarIn.Click
        Dim id = Txt_Id_Eliminar.Text
        Dim TipoBanco = "Individual"
        Try
            Dim conex As New MySqlConnection(conn)
            conex.Open()

            Dim Sql As String
            Dim cmd As New MySqlCommand()

            Sql = "UPDATE registros_bancos_semilla SET ec_codigo=@ec_codigo, ec_nombre=@ec_nombre, Depto_Cod=@Depto_Cod, Depto_Descripcion=@Depto_Descripcion, Muni_Descripcion=@Muni_Descripcion, Aldea_Descripcion=@Aldea_Descripcion, Caserio_Descripcion=@Caserio_Descripcion, PROD_NOMBRE=@PROD_NOMBRE, PROD_SEXO=@PROD_SEXO, PROD_IDENTIDAD=@PROD_IDENTIDAD, PROD_TELEFONO=@PROD_TELEFONO, Prod_Edades=@Prod_Edades, Prod_RTN=@Prod_RTN, TIPO_BCS=@TIPO_BCS, Cuenta_Bancaria=@Cuenta_Bancaria, Cuenta_Ahorro=@Cuenta_Ahorro, Lista_De_Bancos=@Lista_De_Bancos, Cuenta_Bancos=@Cuenta_Bancos, Nombre_Beneficiario=@Nombre_Beneficiario, Grupo_Edad=@Grupo_Edad, Cantidad_Hombres_Hogar=@Cantidad_Hombres_Hogar, Cantidad_Mujeres_Hogar=@Cantidad_Mujeres_Hogar, Hombres_Involucrados=@Hombres_Involucrados, Mujeres_Involucradas=@Mujeres_Involucradas, Productos_Semilla_Frijol=@Productos_Semilla_Frijol, Experiencia_Produccion=@Experiencia_Produccion, Tiempo_Experiencia=@Tiempo_Experiencia, Tipo_Semilla=@Tipo_Semilla, Proyecto_Distribucion_Semilla=@Proyecto_Distribucion_Semilla, Produjo_Semilla_Registrada=@Produjo_Semilla_Registrada, Produjo_Semilla_Certificada=@Produjo_Semilla_Certificada, Brindo_Asistencia_Tecnica=@Brindo_Asistencia_Tecnica, Apoyo_Inscripcion_Senasa=@Apoyo_Inscripcion_Senasa, Otra_Experiencia=@Otra_Experiencia, Colaboracion_FAO=@Colaboracion_FAO, Colaboracion_Otro=@Colaboracion_Otro, Esta_Asociado=@Esta_Asociado, Nombre_Asociacion=@Nombre_Asociacion, Cantidad_Tierra_En_MZ=@Cantidad_Tierra_En_MZ, Tiene_Maiz=@Tiene_Maiz, Cantidad_Terreno_Maiz=@Cantidad_Terreno_Maiz, Tiene_Frijol=@Tiene_Frijol, Cantidad_Terreno_Frijol=@Cantidad_Terreno_Frijol, Tiene_Sorgo=@Tiene_Sorgo, Cantidad_Terreno_Sorgo=@Cantidad_Terreno_Sorgo, Tiene_Cafe=@Tiene_Cafe, Cantidad_Terreno_Cafe=@Cantidad_Terreno_Cafe, Tiene_Hortaliza=@Tiene_Hortaliza, Cantidad_Terreno_Hortaliza=@Cantidad_Terreno_Hortaliza, Tiene_Frutales=@Tiene_Frutales, Cantidad_Terreno_Frutales=@Cantidad_Terreno_Frutales, Tiene_Ganaderia=@Tiene_Ganaderia, Cantidad_Terreno_Ganaderia=@Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque=@Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque=@Cantidad_Terreno_ConservacionBosque, Tiene_Otros=@Tiene_Otros, Cantidad_Terreno_Otros=@Cantidad_Terreno_Otros, Espesifique_Tipo=@Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada=@Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles=@Cantidad_Lotes_Disponibles, Topografia_Adecuada=@Topografia_Adecuada, Rio_Dentro_Finca=@Rio_Dentro_Finca, Pozo_Dentro_Finca=@Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca=@OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca=@Rio_Fuera_Finca, Pozo_Fuera_Finca=@Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca=@OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego=@Possee_Sistema_Riego, Tipo_Sistema_Riego=@Tipo_Sistema_Riego, Terreno_Bajo_Riego=@Terreno_Bajo_Riego, No_Requiere=@No_Requiere, Requiere_Combustion=@Requiere_Combustion, Requiere_Electricidad=@Requiere_Electricidad, Requiere_Energia_Solar=@Requiere_Energia_Solar, Otro_Tipo_Energia=@Otro_Tipo_Energia, Distancia_Ubicacion=@Distancia_Ubicacion, Transitan_Vehiculos=@Transitan_Vehiculos, Transporte_Automovil=@Transporte_Automovil, Transporte_PickUp=@Transporte_PickUp, Transporte_Motocicleta=@Transporte_Motocicleta, Transporte_Bicicleta=@Transporte_Bicicleta, Transporte_Caballo_Mula_Macho=@Transporte_Caballo_Mula_Macho, Otro_Transporte=@Otro_Transporte, Tiene_Bodega=@Tiene_Bodega, Cantidad_Bodega=@Cantidad_Bodega, Tiene_Secadoras_Solares=@Tiene_Secadoras_Solares, Cantidad_Secadora_Solares=@Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica=@Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica=@Cantidad_Secadora_Mecanica, Tiene_Computadoras=@Tiene_Computadoras, Cantidad_Computadoras=@Cantidad_Computadoras, Tiene_Equipo_de_Aspersion=@Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion=@Cantidad_Equipo_Aspersion, Tiene_Desgranadora=@Tiene_Desgranadora, Cantidad_Desgranadora=@Cantidad_Desgranadora, Tiene_Zaranda=@Tiene_Zaranda, Cantidad_Zaranda=@Cantidad_Zaranda, Tiene_Maquinaria_Tractor=@Tiene_Maquinaria_Tractor, Cantidad_Maquinaria=@Cantidad_Maquinaria, Tiene_Arado=@Tiene_Arado, Cantidad_Arado=@Cantidad_Arado, Tiene_Acamadora=@Tiene_Acamadora, Cantidad_Acamadora=@Cantidad_Acamadora, Tiene_Sembradora=@Tiene_Sembradora, Cantidad_Sembradora=@Cantidad_Sembradora, Tiene_Clasificadora=@Tiene_Clasificadora, Cantidad_Clasificadora=@Cantidad_Clasificadora, Tiene_Pulidora=@Tiene_Pulidora, Cantidad_Pulidora=@Cantidad_Pulidora, Tiene_Envasadora=@Tiene_Envasadora, Cantidad_Envasadora=@Cantidad_Envasadora, Tiene_Bomba_Riego=@Tiene_Bomba_Riego, Cantida_Bomba_Riego=@Cantida_Bomba_Riego, Tiene_Patio_Secado=@Tiene_Patio_Secado, Cantidad_Patio_Secado=@Cantidad_Patio_Secado, Tiene_Otras=@Tiene_Otras, Describa_Otras=@Describa_Otras , Otro_Transporte_Si_Individual=@Otro_Transporte_Si_Individual WHERE id=@Id"

            cmd.Connection = conex




            cmd.Parameters.AddWithValue("@ec_codigo", Lb_Asignar_Acesor_Ind.SelectedValue)
            cmd.Parameters.AddWithValue("@ec_nombre", Lb_Asignar_Acesor_Ind.Text)
            cmd.Parameters.AddWithValue("@Depto_Cod", Dl_Departamento_Individual.SelectedValue)
            cmd.Parameters.AddWithValue("@Depto_Descripcion", Dl_Departamento_Individual.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@Muni_Descripcion", Dl_Municipio_Individual.SelectedItem)
            cmd.Parameters.AddWithValue("@Aldea_Descripcion", Dl_Aldea_Individual.SelectedItem)
            cmd.Parameters.AddWithValue("@Caserio_Descripcion", Dl_Caserio_Individual.SelectedItem)
            cmd.Parameters.AddWithValue("@PROD_NOMBRE", Txt_Nombre_Completo_IN.Text)
            cmd.Parameters.AddWithValue("@FECHA_REGISTRO", Fecha_Individual.Text)

            cmd.Parameters.AddWithValue("@PROD_SEXO", Dl_Sexo_In.Text)
            'cmd2.Parameters.AddWithValue("@POD_EDAD", Txt_Edad_In.Text)
            cmd.Parameters.AddWithValue("@PROD_IDENTIDAD", Txt_Dni_In.Text)
            cmd.Parameters.AddWithValue("@PROD_TELEFONO", Txt_Telefono_In.Text)
            cmd.Parameters.AddWithValue("@Prod_Edades", Txt_Edad_In.Text)
            cmd.Parameters.AddWithValue("@Prod_RTN", Txt_Rtn_In.Text)


            cmd.Parameters.AddWithValue("@TIPO_BCS", TipoBanco)
            cmd.Parameters.AddWithValue("@Cuenta_Bancaria", Dl_Cuenta_IN.Text)
            cmd.Parameters.AddWithValue("@Cuenta_Ahorro", Dl_Ahorro_In.Text)
            cmd.Parameters.AddWithValue("@Lista_De_Bancos", Dl_Bancos_In.Text)
            cmd.Parameters.AddWithValue("@Cuenta_Bancos", txt_NCuenta_In.Text)
            cmd.Parameters.AddWithValue("@Nombre_Beneficiario", Txt_NombreBen_In.Text)
            cmd.Parameters.AddWithValue("@Grupo_Edad", Dl_Grupo_Edad.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Hombres_Hogar", Txt_Maculino_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Mujeres_Hogar", Txt_Femenino_In.Text)
            cmd.Parameters.AddWithValue("@Hombres_Involucrados", txt_Hombres_Involucrados.Text)
            cmd.Parameters.AddWithValue("@Mujeres_Involucradas", txt_Mujeres_Involucrados.Text)
            cmd.Parameters.AddWithValue("@Productos_Semilla_Frijol", Dl_Semilla_Frijol.Text)

            cmd.Parameters.AddWithValue("@Experiencia_Produccion", Tiene_Experiencia.Text)
            cmd.Parameters.AddWithValue("@Tiempo_Experiencia", Cantidad_Anos.Text)
            cmd.Parameters.AddWithValue("@Tipo_Semilla", Tipo_Semilla.Text)
            cmd.Parameters.AddWithValue("@Proyecto_Distribucion_Semilla", Distribucion_Semilla.Text)
            cmd.Parameters.AddWithValue("@Produjo_Semilla_Registrada", Semilla_Registrada.Text)
            cmd.Parameters.AddWithValue("@Produjo_Semilla_Certificada", Semilla_Certificada.Text)
            cmd.Parameters.AddWithValue("@Brindo_Asistencia_Tecnica", Asistencia_Tecnica.Text)
            cmd.Parameters.AddWithValue("@Apoyo_Inscripcion_Senasa", Apoyo_Inscripciones_Senasa.Text)
            cmd.Parameters.AddWithValue("@Otra_Experiencia", Otra_Produccion.Text)
            cmd.Parameters.AddWithValue("@Colaboracion_FAO", Dl_Fao_In.Text)


            cmd.Parameters.AddWithValue("@Colaboracion_Otro", Txt_Otro_Inst_In.Text)
            cmd.Parameters.AddWithValue("@Esta_Asociado", Dl_Afiliado_In.Text)
            cmd.Parameters.AddWithValue("@Nombre_Asociacion", Txt_NombreRed_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Tierra_En_MZ", Txt_CantierraMz_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Maiz", Dl_Maiz_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Maiz", Txt_CantTerreno_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Frijol", Dl_Frijol_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Frijol", Txt_CantTerrenoFrijol_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Sorgo", Dl_Sorgo_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Sorgo", Txt_CantSorgo_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Cafe", Dl_Cafe_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Cafe", Txt_CantCafe_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Hortaliza", Dl_Hortaliza_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Hortaliza", Txt_CantHortaliza_In.Text)

            cmd.Parameters.AddWithValue("@Tiene_Frutales", Dl_Frutales_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Frutales", Txt_CantFrutales_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Ganaderia", Dl_Ganaderia_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Ganaderia", Dl_CantGanaderia_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_ConservacionBosque", Dl_Conservacion_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_ConservacionBosque", Dl_CantTerreno_In.Text)

            cmd.Parameters.AddWithValue("@Tiene_Otros", DlOtroTerreno_IN.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Otros", Txt_TerrenoOtros_Org.Text)
            cmd.Parameters.AddWithValue("@Espesifique_Tipo", Txt_CantTipoOtro_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Terreno_Mz_Certificada", Txt_CantTerrenoMz_IN.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Lotes_Disponibles", Txt_CantLotesDis_IN.Text)
            cmd.Parameters.AddWithValue("@Topografia_Adecuada", Dl_Pendiente_In.Text)


            cmd.Parameters.AddWithValue("@Rio_Dentro_Finca", Dl_Rio_In.Text)
            cmd.Parameters.AddWithValue("@Pozo_Dentro_Finca", Dl_Pozo_In.Text)
            cmd.Parameters.AddWithValue("@OjoDeAgua_Dentro_Finca", Dl_OjoAguaIn_In.Text)
            cmd.Parameters.AddWithValue("@Rio_Fuera_Finca", Dl_RioFuera_IN.Text)

            cmd.Parameters.AddWithValue("@Pozo_Fuera_Finca", Dl_PozoFuera_IN.Text)
            cmd.Parameters.AddWithValue("@OjoDeAgua_Fuera_Finca", Dl_OjoFuera_Org.Text)
            cmd.Parameters.AddWithValue("@Possee_Sistema_Riego", Dl_SistemaRiego_In.Text)
            cmd.Parameters.AddWithValue("@Tipo_Sistema_Riego", Dl_TipoSisistema_In.Text)
            cmd.Parameters.AddWithValue("@Terreno_Bajo_Riego", Txt_AreaRiego_IN.Text)

            cmd.Parameters.AddWithValue("@No_Requiere", Dl_RequiereSistema_In.Text)
            cmd.Parameters.AddWithValue("@Requiere_Combustion", Dl_Combustion_In.Text)
            cmd.Parameters.AddWithValue("@Requiere_Electricidad", Dl_Electrica_Org.Text)
            cmd.Parameters.AddWithValue("@Requiere_Energia_Solar", Dl_Solar_In.Text)
            cmd.Parameters.AddWithValue("@Otro_Tipo_Energia", Txt_OtraEnergia_In.Text)

            cmd.Parameters.AddWithValue("@Distancia_Ubicacion", Txt_DistanciaKm_IN.Text)
            cmd.Parameters.AddWithValue("@Transitan_Vehiculos", Dl_CaminoPropiedad_IN.Text)
            cmd.Parameters.AddWithValue("@Transporte_Automovil", Dl_Auto_in.Text)
            cmd.Parameters.AddWithValue("@Transporte_PickUp", Dl_Pick_IN.Text)
            cmd.Parameters.AddWithValue("@Transporte_Motocicleta", Dl_Moto_In.Text)
            cmd.Parameters.AddWithValue("@Transporte_Bicicleta", Dl_Bici_In.Text)

            cmd.Parameters.AddWithValue("@Transporte_Caballo_Mula_Macho", Dl_Caballo_In.Text)
            cmd.Parameters.AddWithValue("@Otro_Transporte", Txt_OtroTrans_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Bodega", Dl_Bodega_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Bodega", Dl_CantBodega_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Secadoras_Solares", Dl_Secadora_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Secadora_Solares", Dl_CantSecadora_In.Text)

            cmd.Parameters.AddWithValue("@Tiene_Secadora_Mecanica", Dl_SecMecanica_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Secadora_Mecanica", Dl_CantSecMecanica_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Computadoras", Dl_Pc_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Computadoras", Txt_CantPc_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Equipo_de_Aspersion", Dl_Equipo_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Equipo_Aspersion", Dl_CantEquipo_In.Text)

            cmd.Parameters.AddWithValue("@Tiene_Desgranadora", Dl_Des_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Desgranadora", Txt_CantDes_IN.Text)
            cmd.Parameters.AddWithValue("@Tiene_Zaranda", Dl_Zaranda_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Zaranda", Txt_CantZara_IN.Text)
            cmd.Parameters.AddWithValue("@Tiene_Maquinaria_Tractor", Dl_Maquinaria_IN.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Maquinaria", Txt_CantidadMaquinaria_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Arado", Dl_Arado_IN.Text)

            cmd.Parameters.AddWithValue("@Cantidad_Arado", Txt_CantidadArado_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Acamadora", Dl_Aca_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Acamadora", Dl_CantAca_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Sembradora", Dl_Sembra_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Sembradora", Dl_CantSembra_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Clasificadora", Dl_Clasifica_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Clasificadora", Txt_CantidadClasifica_IN.Text)

            cmd.Parameters.AddWithValue("@Tiene_Pulidora", Dl_Pulidora_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Pulidora", Txt_CanPuli_IN.Text)
            cmd.Parameters.AddWithValue("@Tiene_Envasadora", Dl_Envasa_In.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Envasadora", Txt_CantEnvasa_In.Text)
            cmd.Parameters.AddWithValue("@Tiene_Bomba_Riego", Dl_Bomba_In.Text)
            cmd.Parameters.AddWithValue("@Cantida_Bomba_Riego", Txt_CanTBomba_IN.Text)
            cmd.Parameters.AddWithValue("@Tiene_Patio_Secado", Dl_Patio_IN.Text)
            cmd.Parameters.AddWithValue("@Cantidad_Patio_Secado", Dl_PatioCant_IN.Text)
            cmd.Parameters.AddWithValue("@Tiene_Otras", Dl_OtrasCosas_IN.Text)
            cmd.Parameters.AddWithValue("@Describa_Otras", Txt_OtrasCosas_IN.Text)
            cmd.Parameters.AddWithValue("@Otro_Transporte_Si_Individual", DL_Otro_Transporte_In.Text)


            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
            conex.Close()
            llenagrid()
        Catch ex As Exception
            ' Capturar y mostrar el mensaje de error en caso de excepción
            Dim errorMessage As String = "Error al intentar actualizar el registro: " & ex.Message
            Response.Write(errorMessage)
            MsgBox(errorMessage)
        End Try

        ' Realizar la redirección después de la ejecución del bloque Try...Catch
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))


    End Sub

    Protected Sub Btn_Eliminar_Si_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Si.Click
        Try
            Dim id = Txt_Id_Eliminar.Text
            Dim conex As New MySqlConnection(conn)
            conex.Open()

            Dim Sql As String
            Dim cmd As New MySqlCommand()

            Sql = "UPDATE registros_bancos_semilla SET Estado = '0' WHERE id = @Id"
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.ExecuteNonQuery()

            conex.Close()
            llenagrid()

            ' Mostrar el modal de Operación Exitosa
            'ClientScript.RegisterStartupScript(Me.GetType(), "OperacionExitosa", "$(function () { $('#ModalOperacionExitosa').modal('show'); });", True)
        Catch ex As Exception
            ' Capturar y mostrar el mensaje de error en caso de excepción
            Dim errorMessage As String = "Error al intentar actualizar el registro: " & ex.Message

        End Try

        ' Realizar la redirección después de la ejecución del bloque Try...Catch
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))
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

        If GB_PERSONERIA_new.Text = "Si" Then
            TXT_PERSONERIA_new.ReadOnly = False
        Else

            TXT_PERSONERIA_new.ReadOnly = True
            TXT_PERSONERIA_new.Text = ""
        End If
        validar_NEW_FORM()

    End Sub

    Protected Sub btn_si_nuevo_Click(sender As Object, e As EventArgs) Handles btn_si_nuevo.Click

        Try
            Dim conex As New MySqlConnection(conn)
            Dim Sql As String
            Dim TipoBanco = "Organizacion"
            conex.Open()
            Dim cmd2 As New MySqlCommand()
            Sql = "INSERT INTO `registros_bancos_semilla` (ec_codigo, ec_nombre, Depto_Cod,Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion, FECHA_REGISTRO, OP_NOMBRE, OP_REPRESENTANTE_CARGO, OP_REPRESENTANTE_SEXO, OP_REPRESENTANTE_EDAD, OP_REPRESENTANTE_ID, OP_REPRESENTANTE_TELEFONO, OP_MIEMBROS_Hombres, OP_MIEMBROS_Mujeres,Op_Nombre_Organizacion,Op_Direccion_Organizacion, OP_TIPO,OP_PERSONERIA, OP_RTN, OP_RTN_NUM, OP_CAI, OP_CAI_NUM, TIPO_BCS,Cuenta_Bancaria,Cuenta_Ahorro,Lista_De_Bancos,Cuenta_Bancos,Nombre_Beneficiario,Experiencia_Produccion,Tiempo_Experiencia,Tipo_Semilla,Proyecto_Distribucion_Semilla,Produjo_Semilla_Registrada,Produjo_Semilla_Certificada,Brindo_Asistencia_Tecnica,Apoyo_Inscripcion_Senasa,Otra_Experiencia,Colaboracion_FAO, Colaboracion_Otro, Esta_Asociado, Nombre_Asociacion, Cantidad_Tierra_En_MZ, Tiene_Maiz, Cantidad_Terreno_Maiz, Tiene_Frijol, Cantidad_Terreno_Frijol, Tiene_Sorgo, Cantidad_Terreno_Sorgo, Tiene_Cafe, Cantidad_Terreno_Hortaliza, Tiene_Hortaliza, Tiene_Frutales, Cantidad_Terreno_Frutales, Tiene_Ganaderia, Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque, Tiene_Otros, Cantidad_Terreno_Otros, Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles, Topografia_Adecuada, Rio_Dentro_Finca, Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca, Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego, Tipo_Sistema_Riego, Terreno_Bajo_Riego, No_Requiere, Requiere_Combustion, Requiere_Electricidad, Requiere_Energia_Solar, Otro_Tipo_Energia, Distancia_Ubicacion, Transitan_Vehiculos, Transporte_Automovil, Transporte_PickUp, Transporte_Motocicleta, Transporte_Bicicleta, Transporte_Caballo_Mula_Macho, Otro_Transporte, Tiene_Bodega, Cantidad_Bodega, Tiene_Secadoras_Solares, Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica, Tiene_Computadoras, Cantidad_Computadoras, Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion, Tiene_Desgranadora, Cantidad_Desgranadora, Tiene_Zaranda, Cantidad_Zaranda, Tiene_Maquinaria_Tractor, Cantidad_Maquinaria, Tiene_Arado, Cantidad_Arado, Tiene_Acamadora, Cantidad_Acamadora, Tiene_Sembradora, Cantidad_Sembradora, Tiene_Clasificadora, Cantidad_Clasificadora, Tiene_Pulidora, Cantidad_Pulidora, Tiene_Envasadora, Cantidad_Envasadora, Tiene_Bomba_Riego, Cantida_Bomba_Riego, Tiene_Patio_Secado, Cantidad_Patio_Secado, Tiene_Otras, Describa_Otras,Estado,Otro_Transporte_Si_Org) values (@ec_codigo, @ec_nombre, @Depto_Cod,@Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion, @FECHA_REGISTRO, @OP_NOMBRE, @OP_REPRESENTANTE_CARGO, @OP_REPRESENTANTE_SEXO, @OP_REPRESENTANTE_EDAD, @OP_REPRESENTANTE_ID, @OP_REPRESENTANTE_TELEFONO, @OP_MIEMBROS_Hombres, @OP_MIEMBROS_Mujeres, @Op_Nombre_Organizacion,@Op_Direccion_Organizacion, @OP_TIPO,@OP_PERSONERIA, @OP_RTN, @OP_RTN_NUM, @OP_CAI, @OP_CAI_NUM, @TIPO_BCS,@Cuenta_Bancaria,@Cuenta_Ahorro,@Lista_De_Bancos,@Cuenta_Bancos,@Nombre_Beneficiario, @Experiencia_Produccion,@Tiempo_Experiencia,@Tipo_Semilla,@Proyecto_Distribucion_Semilla,@Produjo_Semilla_Registrada,@Produjo_Semilla_Certificada,@Brindo_Asistencia_Tecnica,@Apoyo_Inscripcion_Senasa,@Otra_Experiencia,@Colaboracion_FAO, @Colaboracion_Otro, @Esta_Asociado, @Nombre_Asociacion, @Cantidad_Tierra_En_MZ, @Tiene_Maiz, @Cantidad_Terreno_Maiz, @Tiene_Frijol, @Cantidad_Terreno_Frijol, @Tiene_Sorgo, @Cantidad_Terreno_Sorgo, @Tiene_Cafe, @Cantidad_Terreno_Hortaliza, @Tiene_Hortaliza, @Tiene_Frutales, @Cantidad_Terreno_Frutales, @Tiene_Ganaderia, @Cantidad_Terreno_Ganaderia, @Tiene_ConservacionBosque, @Cantidad_Terreno_ConservacionBosque, @Tiene_Otros, @Cantidad_Terreno_Otros, @Espesifique_Tipo, @Cantidad_Terreno_Mz_Certificada, @Cantidad_Lotes_Disponibles, @Topografia_Adecuada, @Rio_Dentro_Finca, @Pozo_Dentro_Finca, @OjoDeAgua_Dentro_Finca, @Rio_Fuera_Finca, @Pozo_Fuera_Finca, @OjoDeAgua_Fuera_Finca, @Possee_Sistema_Riego, @Tipo_Sistema_Riego, @Terreno_Bajo_Riego, @No_Requiere, @Requiere_Combustion, @Requiere_Electricidad, @Requiere_Energia_Solar, @Otro_Tipo_Energia, @Distancia_Ubicacion, @Transitan_Vehiculos, @Transporte_Automovil, @Transporte_PickUp, @Transporte_Motocicleta, @Transporte_Bicicleta, @Transporte_Caballo_Mula_Macho, @Otro_Transporte, @Tiene_Bodega, @Cantidad_Bodega, @Tiene_Secadoras_Solares, @Cantidad_Secadora_Solares, @Tiene_Secadora_Mecanica, @Cantidad_Secadora_Mecanica, @Tiene_Computadoras, @Cantidad_Computadoras, @Tiene_Equipo_de_Aspersion, @Cantidad_Equipo_Aspersion, @Tiene_Desgranadora, @Cantidad_Desgranadora, @Tiene_Zaranda, @Cantidad_Zaranda, @Tiene_Maquinaria_Tractor, @Cantidad_Maquinaria, @Tiene_Arado, @Cantidad_Arado, @Tiene_Acamadora, @Cantidad_Acamadora, @Tiene_Sembradora, @Cantidad_Sembradora, @Tiene_Clasificadora, @Cantidad_Clasificadora, @Tiene_Pulidora, @Cantidad_Pulidora, @Tiene_Envasadora, @Cantidad_Envasadora, @Tiene_Bomba_Riego, @Cantida_Bomba_Riego, @Tiene_Patio_Secado, @Cantidad_Patio_Secado ,@Tiene_Otras, @Describa_Otras, @Estado,@Otro_Transporte_Si_Org) "

            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@ec_codigo", gb_ec_new.SelectedValue)
            cmd2.Parameters.AddWithValue("@ec_nombre", gb_ec_new.SelectedItem.Text)

            cmd2.Parameters.AddWithValue("@Depto_Cod", gb_departamento_new.SelectedValue)
            cmd2.Parameters.AddWithValue("@Depto_Descripcion", gb_departamento_new.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Muni_Descripcion", gb_municipio_new.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Aldea_Descripcion", gb_aldea_new.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Caserio_Descripcion", gb_caserio_new.SelectedItem.Text)
            ''cmd.Parameters.AddWithValue("@COD_BCS", 1)
            cmd2.Parameters.AddWithValue("@FECHA_REGISTRO", TXT_FECHA_CREATE_OP.Text)
            'cmd2.Parameters.AddWithValue("@TIPO_BCS", individual_new.Text)
            ''cmd.Parameters.AddWithValue("@cod_op", 1)
            cmd2.Parameters.AddWithValue("@OP_NOMBRE", txt_nombre_prod_new.Text)
            'cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE", txt_nombre_prod_new.Text)
            cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE_CARGO", gb_cargo_nuevo.Text)
            cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE_SEXO", gb_sexo_new.Text)
            cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE_EDAD", txtEdadRepresentante.Text)
            cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE_ID", txt_dni_new.Text)
            cmd2.Parameters.AddWithValue("@OP_REPRESENTANTE_TELEFONO", txt_telefono_new.Text)
            cmd2.Parameters.AddWithValue("@OP_MIEMBROS_Hombres", TXT_SOCIO_H_NEW.Text)
            cmd2.Parameters.AddWithValue("@OP_MIEMBROS_Mujeres", TXT_SOCIO_M_NEW.Text)
            cmd2.Parameters.AddWithValue("@Op_Nombre_Organizacion", Dl_OP_Todos.SelectedItem.Text)
            cmd2.Parameters.AddWithValue("@Op_Direccion_Organizacion", TXT_OPDIRECCION_NEW.Text)
            cmd2.Parameters.AddWithValue("@OP_TIPO", gb_tipo_new.Text)
            cmd2.Parameters.AddWithValue("@OP_PERSONERIA", GB_PERSONERIA_new.Text)
            cmd2.Parameters.AddWithValue("@OP_RTN", GB_RTN_new.Text)
            cmd2.Parameters.AddWithValue("@OP_RTN_NUM", TXT_RTN_new.Text)
            cmd2.Parameters.AddWithValue("@OP_CAI", GB_CAI_new.Text)
            cmd2.Parameters.AddWithValue("@OP_CAI_NUM", TXT_CAI_new.Text)
            cmd2.Parameters.AddWithValue("@TIPO_BCS", TipoBanco)
            cmd2.Parameters.AddWithValue("@Cuenta_Bancaria", Dl_CuentaBancaria_Org.Text)
            cmd2.Parameters.AddWithValue("@Cuenta_Ahorro", Dl_CuentaAhorroBanco_Org.Text)
            cmd2.Parameters.AddWithValue("@Lista_De_Bancos", Dl_ListaBancosAhorro_Org.Text)
            cmd2.Parameters.AddWithValue("@Cuenta_Bancos", txt_cuentaAhorroBanco_org.Text)
            cmd2.Parameters.AddWithValue("@Nombre_Beneficiario", txt_BeneficiaroAhorro_Org.Text)
            cmd2.Parameters.AddWithValue("@Experiencia_Produccion", Dl_Experiencia_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiempo_Experiencia", Text_Anos_Experiencia_new.Text)
            cmd2.Parameters.AddWithValue("@Tipo_Semilla", Dl_TipoSemillan_Org.Text)
            cmd2.Parameters.AddWithValue("@Proyecto_Distribucion_Semilla", Dl_ManejoProyecto_Org.Text)
            cmd2.Parameters.AddWithValue("@Produjo_Semilla_Registrada", Dl_ProdujoSemilla_Org.Text)
            cmd2.Parameters.AddWithValue("@Produjo_Semilla_Certificada", Dl_ProdujoSemillaCer_Org.Text)
            cmd2.Parameters.AddWithValue("@Brindo_Asistencia_Tecnica", Dl_Asistencia_Org.Text)
            cmd2.Parameters.AddWithValue("@Apoyo_Inscripcion_Senasa", Dl_ApoyoInscripciones_Org.Text)
            cmd2.Parameters.AddWithValue("@Otra_Experiencia", Txt_Otro_Org.Text)
            cmd2.Parameters.AddWithValue("@Colaboracion_FAO", Dl_Fao_Org.Text)
            'cmd2.Parameters.AddWithValue("@Colaboracion_Dicta", Dl_Dicta_Org.Text)
            'cmd2.Parameters.AddWithValue("@Colaboracion_Casa_Comercial", Dl_CasaComercial_Org.Text)
            'cmd2.Parameters.AddWithValue("@Colaboracion_Zamorano", Dl_Zamorano_Org.Text)
            cmd2.Parameters.AddWithValue("@Colaboracion_Otro", Txt_OtroInst_Org.Text)
            cmd2.Parameters.AddWithValue("@Esta_Asociado", Dl_Afiliado_Org.Text)
            cmd2.Parameters.AddWithValue("@Nombre_Asociacion", Txt_NombreRed_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Tierra_En_MZ", Txt_CantTierra_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Maiz", Dl_Maiz_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Maiz", Txt_CantTerreno_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Frijol", Dl_Frijol_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Frijol", Txt_CantTerrenoFrijol_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Sorgo", Dl_Sorgo_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Sorgo", Txt_CantTerrenoSorgo_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Cafe", Dl_Cafe_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Cafe", Txt_CantTerrenoCafe_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Hortaliza", Dl_Hortaliza_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Hortaliza", Txt_CantTerrenoHortaliza_Org.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Frutales", Dl_Frutales_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Frutales", txt_CantTerrenoFrutales_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Ganaderia", Dl_Ganaderia_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Ganaderia", Txt_CantTerrenoGanaderia_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_ConservacionBosque", Dl_Conservacion_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_ConservacionBosque", txt_TerrenoBosque_Org.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Otros", Dl_OtrosCosecha_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Otros", Txt_TerrenoOtros_Org.Text)
            cmd2.Parameters.AddWithValue("@Espesifique_Tipo", Txt_TipoCultivo_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Mz_Certificada", Txt_CantTerrenoMz_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Lotes_Disponibles", Txt_Cantlotes_Org.Text)
            cmd2.Parameters.AddWithValue("@Topografia_Adecuada", Dl_topografia_Org.Text)

            'cmd2.Parameters.AddWithValue("@de_Pendiente", Dl_topografia_Org.Text)
            cmd2.Parameters.AddWithValue("@Rio_Dentro_Finca", Dl_Rio_Org.Text)
            cmd2.Parameters.AddWithValue("@Pozo_Dentro_Finca", Dl_Pozo_Org.Text)
            cmd2.Parameters.AddWithValue("@OjoDeAgua_Dentro_Finca", Dl_OjoAgua_Org.Text)
            cmd2.Parameters.AddWithValue("@Rio_Fuera_Finca", Dl_RioFuera_Org.Text)

            cmd2.Parameters.AddWithValue("@Pozo_Fuera_Finca", Dl_PozoFuera_Org.Text)
            cmd2.Parameters.AddWithValue("@OjoDeAgua_Fuera_Finca", Dl_OjoFuera_Org.Text)
            cmd2.Parameters.AddWithValue("@Possee_Sistema_Riego", Dl_SistemaRiego_Org.Text)
            cmd2.Parameters.AddWithValue("@Tipo_Sistema_Riego", Dl_TipoSistema_Org.Text)
            cmd2.Parameters.AddWithValue("@Terreno_Bajo_Riego", Txt_AreaBajo_Org.Text)

            cmd2.Parameters.AddWithValue("@No_Requiere", Dl_NoRequiere_Org.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Combustion", Dl_Combustion_Org.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Electricidad", Dl_Electrica_Org.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Energia_Solar", Dl_Solar_Org.Text)
            cmd2.Parameters.AddWithValue("@Otro_Tipo_Energia", Txt_OtraEnergia_Org.Text)

            cmd2.Parameters.AddWithValue("@Distancia_Ubicacion", Txt_DistanciaKm_Org.Text)
            cmd2.Parameters.AddWithValue("@Transitan_Vehiculos", Dl_CaminoCercano_Org.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Automovil", Dl_Automovil_Org.Text)
            cmd2.Parameters.AddWithValue("@Transporte_PickUp", Dl_PickUp_Org.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Motocicleta", Dl_Moto_Org.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Bicicleta", Dl_Bici_Org.Text)

            cmd2.Parameters.AddWithValue("@Transporte_Caballo_Mula_Macho", Dl_Mula_Org.Text)
            cmd2.Parameters.AddWithValue("@Otro_Transporte", Txt_OtroTransporte_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Bodega", Dl_Bodega_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Bodega", Txt_CantidadBodega_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Secadoras_Solares", Dl_Secadoras_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Secadora_Solares", Txt_CantidadSecadores_Org.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Secadora_Mecanica", Dl_SecaMecanica_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Secadora_Mecanica", Txt_SecaMecanica_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Computadoras", Dl_Pc_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Computadoras", Txt_Pc_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Equipo_de_Aspersion", Dl_EquipoAspersion_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Equipo_Aspersion", Txt_EquipoAspersion_Org.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Desgranadora", Dl_Desgranadora_Org.Text)
            'cmd2.Parameters.AddWithValue("@Tiene_Zaranda", Dl_Desgranadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Desgranadora", Txt_Desgranadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Zaranda", Dl_Zaranda_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Zaranda", Txt_Zaranda_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Maquinaria_Tractor", Dl_Tractor_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Maquinaria", Txt_Tractor_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Arado", Dl_Arado_Org.Text)

            cmd2.Parameters.AddWithValue("@Cantidad_Arado", Txt_Arado_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Acamadora", Dl_Acamadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Acamadora", Txt_Acamadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Sembradora", Dl_Sembradora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Sembradora", Txt_Sembradora_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Clasificadora", Dl_Clasificadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Clasificadora", Txt_Clasificadora_Org.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Pulidora", Dl_Pulidora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Pulidora", Txt_Pulidora_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Envasadora", Dl_Envasadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Envasadora", Txt_Envasadora_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Bomba_Riego", Dl_Bomba_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantida_Bomba_Riego", Txt_Bomba_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Patio_Secado", Dl_Patio_Org.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Patio_Secado", Txt_Patio_Org.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Otras", Dl_OtrasInfra_Org.Text)
            cmd2.Parameters.AddWithValue("@Describa_Otras", Txt_OtrasInfra_Org.Text)
            cmd2.Parameters.AddWithValue("@Estado", "1")
            cmd2.Parameters.AddWithValue("@Otro_Transporte_Si_Org", DL_Otro_Transporte.Text)
            ''cmd.Parameters.AddWithValue("@OP_TIPO_OTRODETALLE", 1)

            'cmd2.Parameters.AddWithValue("@OP_PERSONERIA", TXT_PERSONERIA_new.Text)

            ''cmd.Parameters.AddWithValue("@COD_PRODUCTOR", 1)

            cmd2.ExecuteNonQuery()
            conex.Close()


        Catch ex As Exception
            ' Capturar y mostrar el mensaje de error en caso de excepción
            Dim errorMessage As String = "Error al intentar actualizar el registro: " & ex.Message
            Response.Write(errorMessage)
            MsgBox(errorMessage)
        End Try
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))


    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try
            Dim conex As New MySqlConnection(conn)
            Dim Sql As String
            Dim TipoBanco = "Individual"
            conex.Open()
            Dim cmd2 As New MySqlCommand()

            'Bueno
            Sql = "INSERT INTO `registros_bancos_semilla` (ec_codigo, ec_nombre, Depto_Cod, Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion, PROD_NOMBRE, PROD_SEXO,  PROD_IDENTIDAD, PROD_TELEFONO, Prod_Edades, Prod_RTN, TIPO_BCS, Cuenta_Bancaria, Cuenta_Ahorro, Lista_De_Bancos, Cuenta_Bancos, Nombre_Beneficiario, Grupo_Edad, Cantidad_Hombres_Hogar, Cantidad_Mujeres_Hogar, Hombres_Involucrados, Mujeres_Involucradas, Productos_Semilla_Frijol, Experiencia_Produccion, Tiempo_Experiencia, Tipo_Semilla, Proyecto_Distribucion_Semilla, Produjo_Semilla_Registrada, Produjo_Semilla_Certificada, Brindo_Asistencia_Tecnica, Apoyo_Inscripcion_Senasa, Otra_Experiencia, Colaboracion_FAO, Colaboracion_Otro, Esta_Asociado, Nombre_Asociacion, Cantidad_Tierra_En_MZ, Tiene_Maiz, Cantidad_Terreno_Maiz, Tiene_Frijol, Cantidad_Terreno_Frijol, Tiene_Sorgo, Cantidad_Terreno_Sorgo, Tiene_Cafe, Cantidad_Terreno_Cafe, Tiene_Hortaliza, Cantidad_Terreno_Hortaliza, Tiene_Frutales, Cantidad_Terreno_Frutales, Tiene_Ganaderia, Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque, Tiene_Otros, Cantidad_Terreno_Otros, Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles, Topografia_Adecuada, Rio_Dentro_Finca, Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca, Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego, Tipo_Sistema_Riego, Terreno_Bajo_Riego, No_Requiere, Requiere_Combustion, Requiere_Electricidad, Requiere_Energia_Solar, Otro_Tipo_Energia, Distancia_Ubicacion, Transitan_Vehiculos, Transporte_Automovil, Transporte_PickUp, Transporte_Motocicleta, Transporte_Bicicleta, Transporte_Caballo_Mula_Macho, Otro_Transporte, Tiene_Bodega, Cantidad_Bodega, Tiene_Secadoras_Solares, Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica, Tiene_Computadoras, Cantidad_Computadoras, Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion, Tiene_Desgranadora, Cantidad_Desgranadora, Tiene_Zaranda, Cantidad_Zaranda, Tiene_Maquinaria_Tractor, Cantidad_Maquinaria, Tiene_Arado, Cantidad_Arado, Tiene_Acamadora, Cantidad_Acamadora, Tiene_Sembradora, Cantidad_Sembradora, Tiene_Clasificadora, Cantidad_Clasificadora, Tiene_Pulidora, Cantidad_Pulidora, Tiene_Envasadora, Cantidad_Envasadora, Tiene_Bomba_Riego, Cantida_Bomba_Riego, Tiene_Patio_Secado, Cantidad_Patio_Secado, Tiene_Otras, Describa_Otras, Estado, FECHA_REGISTRO, Otro_Transporte_Si_Individual) values (@ec_codigo, @ec_nombre, @Depto_Cod, @Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion, @PROD_NOMBRE, @PROD_SEXO, @PROD_IDENTIDAD, @PROD_TELEFONO, @Prod_Edades, @Prod_RTN, @TIPO_BCS, @Cuenta_Bancaria, @Cuenta_Ahorro, @Lista_De_Bancos, @Cuenta_Bancos, @Nombre_Beneficiario, @Grupo_Edad, @Cantidad_Hombres_Hogar, @Cantidad_Mujeres_Hogar, @Hombres_Involucrados, @Mujeres_Involucradas, @Productos_Semilla_Frijol, @Experiencia_Produccion, @Tiempo_Experiencia, @Tipo_Semilla, @Proyecto_Distribucion_Semilla, @Produjo_Semilla_Registrada, @Produjo_Semilla_Certificada, @Brindo_Asistencia_Tecnica, @Apoyo_Inscripcion_Senasa, @Otra_Experiencia, @Colaboracion_FAO, @Colaboracion_Otro, @Esta_Asociado, @Nombre_Asociacion, @Cantidad_Tierra_En_MZ, @Tiene_Maiz, @Cantidad_Terreno_Maiz, @Tiene_Frijol, @Cantidad_Terreno_Frijol, @Tiene_Sorgo, @Cantidad_Terreno_Sorgo, @Tiene_Cafe, @Cantidad_Terreno_Cafe, @Tiene_Hortaliza, @Cantidad_Terreno_Hortaliza, @Tiene_Frutales, @Cantidad_Terreno_Frutales, @Tiene_Ganaderia, @Cantidad_Terreno_Ganaderia, @Tiene_ConservacionBosque, @Cantidad_Terreno_ConservacionBosque, @Tiene_Otros, @Cantidad_Terreno_Otros, @Espesifique_Tipo, @Cantidad_Terreno_Mz_Certificada, @Cantidad_Lotes_Disponibles, @Topografia_Adecuada, @Rio_Dentro_Finca, @Pozo_Dentro_Finca, @OjoDeAgua_Dentro_Finca, @Rio_Fuera_Finca, @Pozo_Fuera_Finca, @OjoDeAgua_Fuera_Finca, @Possee_Sistema_Riego, @Tipo_Sistema_Riego, @Terreno_Bajo_Riego, @No_Requiere, @Requiere_Combustion, @Requiere_Electricidad, @Requiere_Energia_Solar, @Otro_Tipo_Energia, @Distancia_Ubicacion, @Transitan_Vehiculos, @Transporte_Automovil, @Transporte_PickUp, @Transporte_Motocicleta, @Transporte_Bicicleta, @Transporte_Caballo_Mula_Macho, @Otro_Transporte, @Tiene_Bodega, @Cantidad_Bodega, @Tiene_Secadoras_Solares, @Cantidad_Secadora_Solares, @Tiene_Secadora_Mecanica, @Cantidad_Secadora_Mecanica, @Tiene_Computadoras, @Cantidad_Computadoras, @Tiene_Equipo_de_Aspersion, @Cantidad_Equipo_Aspersion, @Tiene_Desgranadora, @Cantidad_Desgranadora, @Tiene_Zaranda, @Cantidad_Zaranda, @Tiene_Maquinaria_Tractor, @Cantidad_Maquinaria, @Tiene_Arado, @Cantidad_Arado, @Tiene_Acamadora, @Cantidad_Acamadora, @Tiene_Sembradora, @Cantidad_Sembradora, @Tiene_Clasificadora, @Cantidad_Clasificadora, @Tiene_Pulidora, @Cantidad_Pulidora, @Tiene_Envasadora, @Cantidad_Envasadora, @Tiene_Bomba_Riego, @Cantida_Bomba_Riego, @Tiene_Patio_Secado, @Cantidad_Patio_Secado, @Tiene_Otras, @Describa_Otras, @Estado, @FECHA_REGISTRO, @Otro_Transporte_Si_Individual)"

            'Sql = "INSERT INTO `registros_bancos_semilla` (ec_codigo, ec_nombre, Depto_Cod, Depto_Descripcion, Muni_Descripcion, Aldea_Descripcion, Caserio_Descripcion, PROD_NOMBRE, PROD_SEXO, POD_EDAD, PROD_IDENTIDAD, PROD_TELEFONO, Prod_Edades, TIPO_BCS, Cuenta_Bancaria, Cuenta_Ahorro, Lista_De_Bancos, Cuenta_Bancos, Nombre_Beneficiario, Grupo_Edad, Cantidad_Hombres_Hogar, Cantidad_Mujeres_Hogar, Hombres_Involucrados, Mujeres_Involucradas, Productos_Semilla_Frijol, Experiencia_Produccion, Tiempo_Experiencia, Tipo_Semilla, Proyecto_Distribucion_Semilla, Produjo_Semilla_Registrada, Produjo_Semilla_Certificada, Brindo_Asistencia_Tecnica, Apoyo_Inscripcion_Senasa, Otra_Experiencia, Colaboracion_FAO, Colaboracion_Otro, Esta_Asociado, Nombre_Asociacion, Cantidad_Tierra_En_MZ, Tiene_Maiz, Cantidad_Terreno_Maiz, Tiene_Frijol, Cantidad_Terreno_Frijol, Tiene_Sorgo, Cantidad_Terreno_Sorgo, Tiene_Cafe, Cantidad_Terreno_Cafe, Tiene_Hortaliza, Cantidad_Terreno_Hortaliza, Tiene_Frutales, Cantidad_Terreno_Frutales, Tiene_Ganaderia, Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque, Tiene_Otros, Cantidad_Terreno_Otros, Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles, Topografia_Adecuada, Rio_Dentro_Finca, Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca, Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego, Tipo_Sistema_Riego, Terreno_Bajo_Riego, No_Requiere, Requiere_Combustion, Requiere_Electricidad, Requiere_Energia_Solar, Otro_Tipo_Energia, Distancia_Ubicacion, Transitan_Vehiculos, Transporte_Automovil, Transporte_PickUp, Transporte_Motocicleta, Transporte_Bicicleta, Transporte_Caballo_Mula_Macho, Otro_Transporte, Tiene_Bodega, Cantidad_Bodega, Tiene_Secadoras_Solares, Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica, Tiene_Computadoras, Cantidad_Computadoras, Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion, Tiene_Desgranadora, Cantidad_Desgranadora, Tiene_Zaranda, Cantidad_Zaranda, Tiene_Maquinaria_Tractor, Cantidad_Maquinaria, Tiene_Arado, Cantidad_Arado, Tiene_Acamadora, Cantidad_Acamadora, Tiene_Sembradora, Cantidad_Sembradora, Tiene_Clasificadora, Cantidad_Clasificadora, Tiene_Pulidora, Cantidad_Pulidora, Tiene_Envasadora, Cantidad_Envasadora, Tiene_Bomba_Riego, Cantida_Bomba_Riego, Tiene_Patio_Secado, Cantidad_Patio_Secado, Tiene_Otras, Describa_Otras, Estado) VALUES (@ec_codigo, @ec_nombre, @Depto_Cod, @Depto_Descripcion, @Muni_Descripcion, @Aldea_Descripcion, @Caserio_Descripcion, @PROD_NOMBRE, @PROD_SEXO, @POD_EDAD, @PROD_IDENTIDAD, @PROD_TELEFONO, @Prod_Edades, @TIPO_BCS, @Cuenta_Bancaria, @Cuenta_Ahorro, @Lista_De_Bancos, @Cuenta_Bancos, @Nombre_Beneficiario, @Grupo_Edad, @Cantidad_Hombres_Hogar, @Cantidad_Mujeres_Hogar, @Hombres_Involucrados, @Mujeres_Involucradas, @Productos_Semilla_Frijol, @Experiencia_Produccion, @Tiempo_Experiencia, @Tipo_Semilla, @Proyecto_Distribucion_Semilla, @Produjo_Semilla_Registrada, @Produjo_Semilla_Certificada, @Brindo_Asistencia_Tecnica, @Apoyo_Inscripcion_Senasa, @Otra_Experiencia, @Colaboracion_FAO, @Colaboracion_Otro, @Esta_Asociado, @Nombre_Asociacion, @Cantidad_Tierra_En_MZ, @Tiene_Maiz, @Cantidad_Terreno_Maiz, @Tiene_Frijol, @Cantidad_Terreno_Frijol, @Tiene_Sorgo, @Cantidad_Terreno_Sorgo, @Tiene_Cafe, @Cantidad_Terreno_Cafe, @Tiene_Hortaliza, @Cantidad_Terreno_Hortaliza, @Tiene_Frutales, @Cantidad_Terreno_Frutales, @Tiene_Ganaderia, @Cantidad_Terreno_Ganaderia, @Tiene_ConservacionBosque, @Cantidad_Terreno_ConservacionBosque, @Tiene_Otros, @Cantidad_Terreno_Otros, @Espesifique_Tipo, @Cantidad_Terreno_Mz_Certificada, @Cantidad_Lotes_Disponibles, @Topografia_Adecuada, @Rio_Dentro_Finca, @Pozo_Dentro_Finca, @OjoDeAgua_Dentro_Finca, @Rio_Fuera_Finca, @Pozo_Fuera_Finca, @OjoDeAgua_Fuera_Finca, @Possee_Sistema_Riego, @Tipo_Sistema_Riego, @Terreno_Bajo_Riego, @No_Requiere, @Requiere_Combustion, @Requiere_Electricidad, @Requiere_Energia_Solar, @Otro_Tipo_Energia, @Distancia_Ubicacion, @Transitan_Vehiculos, @Transporte_Automovil, @Transporte_PickUp, @Transporte_Motocicleta, @Transporte_Bicicleta, @Transporte_Caballo_Mula_Macho, @Otro_Transporte, @Tiene_Bodega, @Cantidad_Bodega, @Tiene_Secadoras_Solares, @Cantidad_Secadora_Solares, @Tiene_Secadora_Mecanica, @Cantidad_Secadora_Mecanica, @Tiene_Computadoras, @Cantidad_Computadoras, @Tiene_Equipo_de_Aspersion, @Cantidad_Equipo_Aspersion, @Tiene_Desgranadora, @Cantidad_Desgranadora, @Tiene_Zaranda, @Cantidad_Zaranda, @Tiene_Maquinaria_Tractor, @Cantidad_Maquinaria, @Tiene_Arado, @Cantidad_Arado, @Tiene_Acamadora, @Cantidad_Acamadora, @Tiene_Sembradora, @Cantidad_Sembradora, @Tiene_Clasificadora, @Cantidad_Clasificadora, @Tiene_Pulidora, @Cantidad_Pulidora, @Tiene_Envasadora, @Cantidad_Envasadora, @Tiene_Bomba_Riego, @Cantida_Bomba_Riego, @Tiene_Patio_Secado, @Cantidad_Patio_Secado, @Tiene_Otras, @Describa_Otras, @Estado)"
            'Sql = "INSERT INTO `registros_bancos_semilla` (Depto_Descripcion, TIPO_BCS) values (@Depto_Descripcion, @TIPO_BCS)"
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@ec_codigo", Lb_Asignar_Acesor_Ind.SelectedValue)
            cmd2.Parameters.AddWithValue("@ec_nombre", Lb_Asignar_Acesor_Ind.Text)
            cmd2.Parameters.AddWithValue("@Depto_Cod", Dl_Departamento_Individual.SelectedValue)
            cmd2.Parameters.AddWithValue("@Depto_Descripcion", Dl_Departamento_Individual.SelectedItem)
            cmd2.Parameters.AddWithValue("@Muni_Descripcion", Dl_Municipio_Individual.SelectedItem)
            cmd2.Parameters.AddWithValue("@Aldea_Descripcion", Dl_Aldea_Individual.SelectedItem)
            cmd2.Parameters.AddWithValue("@Caserio_Descripcion", Dl_Caserio_Individual.SelectedItem)
            cmd2.Parameters.AddWithValue("@PROD_NOMBRE", Txt_Nombre_Completo_IN.Text)
            cmd2.Parameters.AddWithValue("@FECHA_REGISTRO", Fecha_Individual.Text)

            cmd2.Parameters.AddWithValue("@PROD_SEXO", Dl_Sexo_In.Text)
            'cmd2.Parameters.AddWithValue("@POD_EDAD", Txt_Edad_In.Text)
            cmd2.Parameters.AddWithValue("@PROD_IDENTIDAD", Txt_Dni_In.Text)
            cmd2.Parameters.AddWithValue("@PROD_TELEFONO", Txt_Telefono_In.Text)
            cmd2.Parameters.AddWithValue("@Prod_Edades", Txt_Edad_In.Text)
            cmd2.Parameters.AddWithValue("@Prod_RTN", Txt_Rtn_In.Text)


            cmd2.Parameters.AddWithValue("@TIPO_BCS", TipoBanco)
            cmd2.Parameters.AddWithValue("@Cuenta_Bancaria", Dl_Cuenta_IN.Text)
            cmd2.Parameters.AddWithValue("@Cuenta_Ahorro", Dl_Ahorro_In.Text)
            cmd2.Parameters.AddWithValue("@Lista_De_Bancos", Dl_Bancos_In.Text)
            cmd2.Parameters.AddWithValue("@Cuenta_Bancos", txt_NCuenta_In.Text)
            cmd2.Parameters.AddWithValue("@Nombre_Beneficiario", Txt_NombreBen_In.Text)
            cmd2.Parameters.AddWithValue("@Grupo_Edad", Dl_Grupo_Edad.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Hombres_Hogar", Txt_Maculino_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Mujeres_Hogar", Txt_Femenino_In.Text)
            cmd2.Parameters.AddWithValue("@Hombres_Involucrados", txt_Hombres_Involucrados.Text)
            cmd2.Parameters.AddWithValue("@Mujeres_Involucradas", txt_Mujeres_Involucrados.Text)
            cmd2.Parameters.AddWithValue("@Productos_Semilla_Frijol", Dl_Semilla_Frijol.Text)

            cmd2.Parameters.AddWithValue("@Experiencia_Produccion", Tiene_Experiencia.Text)
            cmd2.Parameters.AddWithValue("@Tiempo_Experiencia", Cantidad_Anos.Text)
            cmd2.Parameters.AddWithValue("@Tipo_Semilla", Tipo_Semilla.Text)
            cmd2.Parameters.AddWithValue("@Proyecto_Distribucion_Semilla", Distribucion_Semilla.Text)
            cmd2.Parameters.AddWithValue("@Produjo_Semilla_Registrada", Semilla_Registrada.Text)
            cmd2.Parameters.AddWithValue("@Produjo_Semilla_Certificada", Semilla_Certificada.Text)
            cmd2.Parameters.AddWithValue("@Brindo_Asistencia_Tecnica", Asistencia_Tecnica.Text)
            cmd2.Parameters.AddWithValue("@Apoyo_Inscripcion_Senasa", Apoyo_Inscripciones_Senasa.Text)
            cmd2.Parameters.AddWithValue("@Otra_Experiencia", Otra_Produccion.Text)
            cmd2.Parameters.AddWithValue("@Colaboracion_FAO", Dl_Fao_In.Text)

            cmd2.Parameters.AddWithValue("@Colaboracion_Otro", Txt_Otro_Inst_In.Text)
            cmd2.Parameters.AddWithValue("@Esta_Asociado", Dl_Afiliado_In.Text)
            cmd2.Parameters.AddWithValue("@Nombre_Asociacion", Txt_NombreRed_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Tierra_En_MZ", Txt_CantierraMz_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Maiz", Dl_Maiz_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Maiz", Txt_CantMaiz_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Frijol", Dl_Frijol_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Frijol", Txt_CantTerrenoFrijol_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Sorgo", Dl_Sorgo_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Sorgo", Txt_CantSorgo_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Cafe", Dl_Cafe_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Cafe", Txt_CantCafe_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Hortaliza", Dl_Hortaliza_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Hortaliza", Txt_CantHortaliza_In.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Frutales", Dl_Frutales_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Frutales", Txt_CantFrutales_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Ganaderia", Dl_Ganaderia_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Ganaderia", Dl_CantGanaderia_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_ConservacionBosque", Dl_Conservacion_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_ConservacionBosque", Dl_CantTerreno_In.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Otros", DlOtroTerreno_IN.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Otros", Txt_CantTerreno_In.Text)
            cmd2.Parameters.AddWithValue("@Espesifique_Tipo", Txt_CantTipoOtro_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Terreno_Mz_Certificada", Txt_CantTerrenoMz_IN.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Lotes_Disponibles", Txt_CantLotesDis_IN.Text)
            cmd2.Parameters.AddWithValue("@Topografia_Adecuada", Dl_Pendiente_In.Text)

            cmd2.Parameters.AddWithValue("@Rio_Dentro_Finca", Dl_Rio_In.Text)
            cmd2.Parameters.AddWithValue("@Pozo_Dentro_Finca", Dl_Pozo_In.Text)
            cmd2.Parameters.AddWithValue("@OjoDeAgua_Dentro_Finca", Dl_OjoAguaIn_In.Text)
            cmd2.Parameters.AddWithValue("@Rio_Fuera_Finca", Dl_RioFuera_IN.Text)

            cmd2.Parameters.AddWithValue("@Pozo_Fuera_Finca", Dl_PozoFuera_IN.Text)
            cmd2.Parameters.AddWithValue("@OjoDeAgua_Fuera_Finca", Dl_OjoFuera_Org.Text)
            cmd2.Parameters.AddWithValue("@Possee_Sistema_Riego", Dl_SistemaRiego_In.Text)
            cmd2.Parameters.AddWithValue("@Tipo_Sistema_Riego", Dl_TipoSisistema_In.Text)
            cmd2.Parameters.AddWithValue("@Terreno_Bajo_Riego", Txt_AreaRiego_IN.Text)

            cmd2.Parameters.AddWithValue("@No_Requiere", Dl_RequiereSistema_In.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Combustion", Dl_Combustion_In.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Electricidad", Dl_Electrica_Org.Text)
            cmd2.Parameters.AddWithValue("@Requiere_Energia_Solar", Dl_Solar_In.Text)
            cmd2.Parameters.AddWithValue("@Otro_Tipo_Energia", Txt_OtraEnergia_In.Text)

            cmd2.Parameters.AddWithValue("@Distancia_Ubicacion", Txt_DistanciaKm_IN.Text)
            cmd2.Parameters.AddWithValue("@Transitan_Vehiculos", Dl_CaminoPropiedad_IN.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Automovil", Dl_Auto_in.Text)
            cmd2.Parameters.AddWithValue("@Transporte_PickUp", Dl_Pick_IN.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Motocicleta", Dl_Moto_In.Text)
            cmd2.Parameters.AddWithValue("@Transporte_Bicicleta", Dl_Bici_In.Text)

            cmd2.Parameters.AddWithValue("@Transporte_Caballo_Mula_Macho", Dl_Caballo_In.Text)
            cmd2.Parameters.AddWithValue("@Otro_Transporte", Txt_OtroTrans_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Bodega", Dl_Bodega_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Bodega", Dl_CantBodega_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Secadoras_Solares", Dl_Secadora_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Secadora_Solares", Dl_CantSecadora_In.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Secadora_Mecanica", Dl_SecMecanica_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Secadora_Mecanica", Dl_CantSecMecanica_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Computadoras", Dl_Pc_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Computadoras", Txt_CantPc_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Equipo_de_Aspersion", Dl_Equipo_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Equipo_Aspersion", Dl_CantEquipo_In.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Desgranadora", Dl_Des_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Desgranadora", Txt_CantDes_IN.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Zaranda", Dl_Zaranda_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Zaranda", Txt_CantZara_IN.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Maquinaria_Tractor", Dl_Maquinaria_IN.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Maquinaria", Txt_CantidadMaquinaria_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Arado", Dl_Arado_IN.Text)

            cmd2.Parameters.AddWithValue("@Cantidad_Arado", Txt_CantidadArado_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Acamadora", Dl_Aca_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Acamadora", Dl_CantAca_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Sembradora", Dl_Sembra_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Sembradora", Dl_CantSembra_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Clasificadora", Dl_Clasifica_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Clasificadora", Txt_CantidadClasifica_IN.Text)

            cmd2.Parameters.AddWithValue("@Tiene_Pulidora", Dl_Pulidora_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Pulidora", Txt_CanPuli_IN.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Envasadora", Dl_Envasa_In.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Envasadora", Txt_CantEnvasa_In.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Bomba_Riego", Dl_Bomba_In.Text)
            cmd2.Parameters.AddWithValue("@Cantida_Bomba_Riego", Txt_CanTBomba_IN.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Patio_Secado", Dl_Patio_IN.Text)
            cmd2.Parameters.AddWithValue("@Cantidad_Patio_Secado", Dl_PatioCant_IN.Text)
            cmd2.Parameters.AddWithValue("@Tiene_Otras", Dl_OtrasCosas_IN.Text)
            cmd2.Parameters.AddWithValue("@Describa_Otras", Txt_OtrasCosas_IN.Text)
            cmd2.Parameters.AddWithValue("@Estado", "1")

            cmd2.Parameters.AddWithValue("@Otro_Transporte_Si_Individual", DL_Otro_Transporte_In.Text)
            cmd2.ExecuteNonQuery()
            conex.Close()


        Catch ex As Exception
            MsgBox(ex)
        End Try

        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))

    End Sub

    Protected Sub ExportarGridViewToExcel(gridView As GridView)
        Dim dt As New DataTable()

        ' Agregar columnas al DataTable basado en las columnas del GridView
        For Each cell As TableCell In gridView.HeaderRow.Cells
            dt.Columns.Add(cell.Text)
        Next

        ' Agregar filas al DataTable basado en los datos del GridView
        For Each row As GridViewRow In gridView.Rows
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To gridView.HeaderRow.Cells.Count - 1
                dr(i) = row.Cells(i).Text.Replace("&nbsp;", "")
            Next
            dt.Rows.Add(dr)
        Next

        ' Crear el archivo de Excel usando ClosedXML
        Using wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add(dt, "Datos")

            ' Ajustar el estilo del encabezado de las columnas
            Dim headerRow = ws.FirstRowUsed()
            headerRow.Style.Font.Bold = True
            headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue

            ' Autoajustar las columnas
            ws.Columns().AdjustToContents()

            'Exportar el archivo de Excel
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=Datos_Exportados.xlsx")

            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.End()
            End Using
        End Using
    End Sub

    Protected Sub ExportarExceelOrg_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim query As String = ""

        If TxTdepto.SelectedValue = "00" Then
            query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Estado = 1 ORDER BY Id,Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                "SELECT * FROM `vista_banco_semilla_in`   ORDER BY Depto_Descripcion; " +
                "SELECT * FROM `vista_banco_semilla_org` ORDER BY Depto_Descripcion "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT *  FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                     "SELECT *  FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion; " +
                      "SELECT *  FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion "
            Else
                If (cmborganizacion.SelectedValue = "00") Then
                    query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                        "SELECT * FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "'  ORDER BY Depto_Descripcion; " +
                                   "SELECT * FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "'  ORDER BY Depto_Descripcion "
                Else
                    query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND TIPO_BCS='" & cmborganizacion.SelectedValue & "'   ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                        "SELECT * FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND TIPO_BCS='" & cmborganizacion.SelectedValue & "'   ORDER BY Depto_Descripcion; " +
                         "SELECT * FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & TxtEntrenador.SelectedValue & "' AND TIPO_BCS='" & cmborganizacion.SelectedValue & "'   ORDER BY Depto_Descripcion "
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
                        ds.Tables(0).TableName = "Total BCS"
                        ds.Tables(1).TableName = "Total BCS Individual"
                        ds.Tables(2).TableName = "Total BCS Organizacion"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Red+pash_bancos " & Today & ".xlsx")
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

    Protected Sub ComboTipoBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTipoBanco.SelectedIndexChanged

        If ComboTipoBanco.Text = "Individual" Then

            divdatos.Visible = False
            div_nuevo_prod.Visible = False
            divIndividual.Visible = True
            divExportaciones.Visible = False
        Else
            If ComboTipoBanco.Text = "Organización" Then

                divdatos.Visible = False
                div_nuevo_prod.Visible = True
                divIndividual.Visible = False
                divExportaciones.Visible = False
            Else
                divdatos.Visible = True
                div_nuevo_prod.Visible = False
                divIndividual.Visible = False
                divExportaciones.Visible = True

            End If
        End If
    End Sub

    Protected Sub Tiene_Experiencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tiene_Experiencia.SelectedIndexChanged

        If Tiene_Experiencia.Text = "Si" Then
            SectionExperiencia.Visible = True
            Cantidad_Anos.Visible = True
            Tipo_Semilla.Visible = True
            Distribucion_Semilla.Visible = True
            Semilla_Registrada.Visible = True
            Semilla_Certificada.Visible = True
            Asistencia_Tecnica.Visible = True
            Apoyo_Inscripciones_Senasa.Visible = True
            Otra_Produccion.Visible = True
            Label_Cantida_Anos.Visible = True
            Label_Tipo_Semilla.Visible = True
        Else
            SectionExperiencia.Visible = False
            Cantidad_Anos.Visible = False
            Tipo_Semilla.Visible = False
            Distribucion_Semilla.Visible = False
            Semilla_Registrada.Visible = False
            Semilla_Certificada.Visible = False
            Asistencia_Tecnica.Visible = False
            Apoyo_Inscripciones_Senasa.Visible = False
            Otra_Produccion.Visible = False
            Label_Cantida_Anos.Visible = False
            Label_Tipo_Semilla.Visible = False

        End If

    End Sub

    Protected Sub Dl_Experiencia_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Experiencia_Org.SelectedIndexChanged
        If Dl_Experiencia_Org.Text = "No" Then
            Experiencia_Previa.Visible = False
            Experiencia_Previa2.Visible = False
        Else
            Experiencia_Previa.Visible = True
            Experiencia_Previa2.Visible = True
        End If
    End Sub

    Protected Sub Dl_Maiz_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Maiz_Org.SelectedIndexChanged

        If Dl_Maiz_Org.Text = "si" Then

            Txt_CantTerreno_Org.Enabled = True
        Else
            Txt_CantTerreno_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Frijol_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Frijol_Org.SelectedIndexChanged
        If Dl_Frijol_Org.Text = "si" Then

            Txt_CantTerrenoFrijol_Org.Enabled = True
        Else
            Txt_CantTerrenoFrijol_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Sorgo_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Sorgo_Org.SelectedIndexChanged
        If Dl_Sorgo_Org.Text = "si" Then

            Txt_CantTerrenoSorgo_Org.Enabled = True
        Else
            Txt_CantTerrenoSorgo_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Cafe_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Cafe_Org.SelectedIndexChanged
        If Dl_Cafe_Org.Text = "si" Then

            Txt_CantTerrenoCafe_Org.Enabled = True
        Else
            Txt_CantTerrenoCafe_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Hortaliza_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Hortaliza_Org.SelectedIndexChanged
        If Dl_Hortaliza_Org.Text = "si" Then

            Txt_CantTerrenoHortaliza_Org.Enabled = True
        Else
            Txt_CantTerrenoHortaliza_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Frutales_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Frutales_Org.SelectedIndexChanged
        If Dl_Frutales_Org.Text = "si" Then

            txt_CantTerrenoFrutales_Org.Enabled = True
        Else
            txt_CantTerrenoFrutales_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Ganaderia_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Ganaderia_Org.SelectedIndexChanged
        If Dl_Ganaderia_Org.Text = "si" Then

            Txt_CantTerrenoGanaderia_Org.Enabled = True
        Else
            Txt_CantTerrenoGanaderia_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Conservacion_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Conservacion_Org.SelectedIndexChanged
        If Dl_Conservacion_Org.Text = "si" Then

            txt_TerrenoBosque_Org.Enabled = True
        Else
            txt_TerrenoBosque_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_OtrosCosecha_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_OtrosCosecha_Org.SelectedIndexChanged
        If Dl_OtrosCosecha_Org.Text = "si" Then

            Txt_TerrenoOtros_Org.Enabled = True
            Txt_TipoCultivo_Org.Enabled = True
        Else
            Txt_TerrenoOtros_Org.Enabled = False
            Txt_TipoCultivo_Org.Enabled = False
        End If
    End Sub

    'Validaciones  4.0

    Protected Sub Dl_Bodega_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Bodega_Org.SelectedIndexChanged
        If Dl_Bodega_Org.Text = "si" Then

            Txt_CantidadBodega_Org.Enabled = True
        Else
            Txt_CantidadBodega_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Secadoras_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Secadoras_Org.SelectedIndexChanged
        If Dl_Secadoras_Org.Text = "si" Then

            Txt_CantidadSecadores_Org.Enabled = True
        Else
            Txt_CantidadSecadores_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_SecaMecanica_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_SecaMecanica_Org.SelectedIndexChanged
        If Dl_SecaMecanica_Org.Text = "si" Then

            Txt_SecaMecanica_Org.Enabled = True
        Else
            Txt_SecaMecanica_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Pc_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Pc_Org.SelectedIndexChanged
        If Dl_Pc_Org.Text = "si" Then

            Txt_Pc_Org.Enabled = True
        Else
            Txt_Pc_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_EquipoAspersion_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_EquipoAspersion_Org.SelectedIndexChanged
        If Dl_EquipoAspersion_Org.Text = "si" Then

            Txt_EquipoAspersion_Org.Enabled = True
        Else
            Txt_EquipoAspersion_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Desgranadora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Desgranadora_Org.SelectedIndexChanged
        If Dl_Desgranadora_Org.Text = "si" Then

            Txt_Desgranadora_Org.Enabled = True
        Else
            Txt_Desgranadora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Zaranda_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Zaranda_Org.SelectedIndexChanged
        If Dl_Zaranda_Org.Text = "si" Then

            Txt_Zaranda_Org.Enabled = True
        Else
            Txt_Zaranda_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Tractor_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Tractor_Org.SelectedIndexChanged
        If Dl_Tractor_Org.Text = "si" Then

            Txt_Tractor_Org.Enabled = True
        Else
            Txt_Zaranda_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Arado_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Arado_Org.SelectedIndexChanged
        If Dl_Arado_Org.Text = "si" Then

            Txt_Arado_Org.Enabled = True
        Else
            Txt_Arado_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Acamadora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Acamadora_Org.SelectedIndexChanged
        If Dl_Acamadora_Org.Text = "si" Then

            Txt_Acamadora_Org.Enabled = True
        Else
            Txt_Acamadora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Sembradora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Sembradora_Org.SelectedIndexChanged
        If Dl_Secadoras_Org.Text = "si" Then

            Txt_Sembradora_Org.Enabled = True
        Else
            Txt_Sembradora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Clasificadora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Clasificadora_Org.SelectedIndexChanged
        If Dl_Clasificadora_Org.Text = "si" Then

            Txt_Clasificadora_Org.Enabled = True
        Else
            Txt_Clasificadora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Pulidora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Pulidora_Org.SelectedIndexChanged
        If Dl_Pulidora_Org.Text = "si" Then

            Txt_Pulidora_Org.Enabled = True
        Else
            Txt_Pulidora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Envasadora_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Envasadora_Org.SelectedIndexChanged
        If Dl_Envasadora_Org.Text = "si" Then

            Txt_Envasadora_Org.Enabled = True
        Else
            Txt_Envasadora_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Bomba_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Bomba_Org.SelectedIndexChanged
        If Dl_Bomba_Org.Text = "si" Then

            Txt_Bomba_Org.Enabled = True
        Else
            Txt_Bomba_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Patio_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Patio_Org.SelectedIndexChanged
        If Dl_Patio_Org.Text = "si" Then

            Txt_Patio_Org.Enabled = True
        Else
            Txt_Patio_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_OtrasInfra_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_OtrasInfra_Org.SelectedIndexChanged
        If Dl_OtrasInfra_Org.Text = "si" Then

            Txt_OtrasInfra_Org.Enabled = True
        Else
            Txt_OtrasInfra_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Departamento_Individual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Departamento_Individual.SelectedIndexChanged
        llenarcombomunicipio_In()
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Dl_Municipio_Individual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Municipio_Individual.SelectedIndexChanged
        llenarcomboaldea_In()
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Dl_Aldea_Individual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Aldea_Individual.SelectedIndexChanged
        llenarcombocaserio_In()
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Dl_CuentaBancaria_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_CuentaBancaria_Org.SelectedIndexChanged
        If Dl_CuentaBancaria_Org.Text = "Si" Then '

            txt_cuentaAhorroBanco_org.ReadOnly = False
            txt_BeneficiaroAhorro_Org.ReadOnly = False
        Else
            txt_cuentaAhorroBanco_org.ReadOnly = True
            txt_BeneficiaroAhorro_Org.ReadOnly = True
        End If
    End Sub

    Protected Sub Dl_Maiz_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Maiz_In.SelectedIndexChanged

        If Dl_Maiz_In.Text = "si" Then
            Txt_CantMaiz_In.Enabled = True
        Else
            Txt_CantMaiz_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_SistemaRiego_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_SistemaRiego_Org.SelectedIndexChanged
        If Dl_SistemaRiego_Org.Text = "si" Then
            Dl_TipoSistema_Org.Enabled = True
            Txt_AreaBajo_Org.Enabled = True
        Else
            Dl_TipoSistema_Org.Enabled = False
            Txt_AreaBajo_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Bodega_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Bodega_In.SelectedIndexChanged
        If Dl_Bodega_In.Text = "si" Then
            Dl_CantBodega_In.Enabled = True
        Else
            Dl_CantBodega_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Secadora_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Secadora_In.SelectedIndexChanged
        If Dl_Secadora_In.Text = "si" Then
            Dl_CantSecadora_In.Enabled = True
        Else
            Dl_CantSecadora_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_SecMecanica_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_SecMecanica_In.SelectedIndexChanged
        If Dl_SecMecanica_In.Text = "si" Then
            Dl_CantSecMecanica_In.Enabled = True
        Else
            Dl_CantSecMecanica_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Pc_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Pc_In.SelectedIndexChanged

        If Dl_Pc_In.Text = "si" Then
            Txt_CantPc_In.Enabled = True
        Else
            Txt_CantPc_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Equipo_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Equipo_In.SelectedIndexChanged

        If Dl_Equipo_In.Text = "si" Then
            Dl_CantEquipo_In.Enabled = True
        Else
            Dl_CantEquipo_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Des_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Des_In.SelectedIndexChanged
        If Dl_Des_In.Text = "si" Then
            Txt_CantDes_IN.Enabled = True
        Else
            Txt_CantDes_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Zaranda_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Zaranda_In.SelectedIndexChanged
        If Dl_Zaranda_In.Text = "si" Then
            Txt_CantZara_IN.Enabled = True
        Else
            Txt_CantZara_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Maquinaria_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Maquinaria_IN.SelectedIndexChanged

        If Dl_Maquinaria_IN.Text = "si" Then
            Txt_CantidadMaquinaria_In.Enabled = True
        Else
            Txt_CantidadMaquinaria_In.Enabled = False
        End If

    End Sub

    Protected Sub Dl_Arado_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Arado_IN.SelectedIndexChanged

        If Dl_Arado_IN.Text = "si" Then
            Txt_CantidadArado_In.Enabled = True
        Else
            Txt_CantidadArado_In.Enabled = False
        End If

    End Sub

    Protected Sub Dl_Aca_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Aca_In.SelectedIndexChanged

        If Dl_Aca_In.Text = "si" Then
            Dl_CantAca_In.Enabled = True
        Else
            Dl_CantAca_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Sembra_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Sembra_In.SelectedIndexChanged

        If Dl_Sembra_In.Text = "si" Then
            Dl_CantSembra_In.Enabled = True
        Else
            Dl_CantSembra_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Clasifica_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Clasifica_In.SelectedIndexChanged

        If Dl_Clasifica_In.Text = "si" Then
            Txt_CantidadClasifica_IN.Enabled = True
        Else
            Txt_CantidadClasifica_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Pulidora_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Pulidora_In.SelectedIndexChanged

        If Dl_Pulidora_In.Text = "si" Then
            Txt_CanPuli_IN.Enabled = True
        Else
            Txt_CanPuli_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Envasa_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Envasa_In.SelectedIndexChanged

        If Dl_Envasa_In.Text = "si" Then
            Txt_CantEnvasa_In.Enabled = True
        Else
            Txt_CantEnvasa_In.Enabled = False
        End If

    End Sub

    Protected Sub Dl_Bomba_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Bomba_In.SelectedIndexChanged

        If Dl_Bomba_In.Text = "si" Then
            Txt_CanTBomba_IN.Enabled = True
        Else
            Txt_CanTBomba_IN.Enabled = False
        End If

    End Sub

    Protected Sub Dl_Patio_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Patio_IN.SelectedIndexChanged

        If Dl_Patio_IN.Text = "si" Then
            Dl_PatioCant_IN.Enabled = True
        Else
            Dl_PatioCant_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_OtrasCosas_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_OtrasCosas_IN.SelectedIndexChanged

        If Dl_OtrasCosas_IN.Text = "si" Then
            Txt_OtrasCosas_IN.Enabled = True
        Else
            Txt_OtrasCosas_IN.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Afiliado_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Afiliado_In.SelectedIndexChanged

        If Dl_Afiliado_In.Text = "si" Then
            Txt_NombreRed_In.Enabled = True
        Else
            Txt_NombreRed_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Frijol_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Frijol_In.SelectedIndexChanged

        If Dl_Frijol_In.Text = "si" Then
            Txt_CantTerrenoFrijol_In.Enabled = True
        Else
            Txt_CantTerrenoFrijol_In.Enabled = False
        End If

    End Sub

    Protected Sub Dl_Sorgo_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Sorgo_In.SelectedIndexChanged

        If Dl_Sorgo_In.Text = "si" Then
            Txt_CantSorgo_In.Enabled = True
        Else
            Txt_CantSorgo_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Cafe_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Cafe_In.SelectedIndexChanged

        If Dl_Cafe_In.Text = "si" Then
            Txt_CantCafe_In.Enabled = True
        Else
            Txt_CantCafe_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Hortaliza_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Hortaliza_In.SelectedIndexChanged

        If Dl_Hortaliza_In.Text = "si" Then
            Txt_CantHortaliza_In.Enabled = True
        Else
            Txt_CantHortaliza_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Frutales_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Frutales_In.SelectedIndexChanged

        If Dl_Frutales_In.Text = "si" Then
            Txt_CantFrutales_In.Enabled = True
        Else
            Txt_CantFrutales_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Ganaderia_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Ganaderia_In.SelectedIndexChanged

        If Dl_Ganaderia_In.Text = "si" Then
            Dl_CantGanaderia_In.Enabled = True
        Else
            Dl_CantGanaderia_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Conservacion_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Conservacion_In.SelectedIndexChanged

        If Dl_Conservacion_In.Text = "si" Then
            Dl_CantTerreno_In.Enabled = True
        Else
            Dl_CantTerreno_In.Enabled = False
        End If
    End Sub

    Protected Sub DlOtroTerreno_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DlOtroTerreno_IN.SelectedIndexChanged

        If DlOtroTerreno_IN.Text = "si" Then
            Txt_CantTerreno_In.Enabled = True
            Txt_CantTipoOtro_In.Enabled = True
        Else
            Txt_CantTipoOtro_In.Enabled = False
            Txt_CantTerreno_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Cuenta_IN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Cuenta_IN.SelectedIndexChanged
        If Dl_Cuenta_IN.Text = "Si" Then
            Dl_Ahorro_In.Enabled = True
            Dl_Bancos_In.Enabled = True
            txt_NCuenta_In.Enabled = True
            Txt_NombreBen_In.Enabled = True
        Else
            Dl_Ahorro_In.Enabled = False
            Dl_Bancos_In.Enabled = False
            txt_NCuenta_In.Enabled = False
            Txt_NombreBen_In.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Grupo_Edad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Grupo_Edad.SelectedIndexChanged
        Txt_Maculino_In.Enabled = True
        Txt_Femenino_In.Enabled = True
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button12.Click, Button13.Click
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))
    End Sub

    Protected Sub Dl_Caserio_Individual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Caserio_Individual.SelectedIndexChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Txt_Nombre_Completo_IN_TextChanged(sender As Object, e As EventArgs) Handles Txt_Nombre_Completo_IN.TextChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Txt_Edad_In_TextChanged(sender As Object, e As EventArgs) Handles Txt_Edad_In.TextChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Txt_Dni_In_TextChanged(sender As Object, e As EventArgs) Handles Txt_Dni_In.TextChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Txt_Telefono_In_TextChanged(sender As Object, e As EventArgs) Handles Txt_Telefono_In.TextChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Lb_Asignar_Acesor_Ind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lb_Asignar_Acesor_Ind.SelectedIndexChanged
        validar_NEW_Indiviual()
    End Sub

    Protected Sub Dl_Fao_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Fao_Org.SelectedIndexChanged
        If Dl_Fao_Org.SelectedItem.Text = "Otro" Then
            Txt_OtroInst_Org.Enabled = True
        Else
            Txt_OtroInst_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Afiliado_Org_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Afiliado_Org.SelectedIndexChanged
        If Dl_Afiliado_Org.SelectedItem.Text = "si" Then
            Txt_NombreRed_Org.Enabled = True
        Else
            Txt_NombreRed_Org.Enabled = False
        End If
    End Sub

    Protected Sub Dl_Fao_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_Fao_In.SelectedIndexChanged

        If Dl_Fao_In.SelectedItem.Text = "Otro" Then
            Txt_Otro_Inst_In.Enabled = True
        Else
            Txt_Otro_Inst_In.Enabled = False
        End If


    End Sub

    Protected Sub Dl_SistemaRiego_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dl_SistemaRiego_In.SelectedIndexChanged
        If Dl_SistemaRiego_In.Text = "si" Then
            Dl_TipoSisistema_In.Enabled = True
            Txt_AreaRiego_IN.Enabled = True
        Else
            Dl_TipoSisistema_In.Enabled = False
            Txt_AreaRiego_IN.Enabled = False
        End If
    End Sub

    Protected Sub DL_Otro_Transporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DL_Otro_Transporte.SelectedIndexChanged
        If DL_Otro_Transporte.SelectedItem.Text = "si" Then
            Txt_OtroTransporte_Org.Enabled = True
        Else Txt_OtroTransporte_Org.Enabled = False
        End If
    End Sub

    Protected Sub DL_Otro_Transporte_In_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DL_Otro_Transporte_In.SelectedIndexChanged
        If DL_Otro_Transporte_In.SelectedItem.Text = "si" Then
            Txt_OtroTrans_In.Enabled = True
        Else
            Txt_OtroTrans_In.Enabled = False
        End If
    End Sub
End Class