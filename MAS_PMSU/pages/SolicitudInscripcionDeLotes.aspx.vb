﻿Imports MySql.Data.MySqlClient

Public Class SolicitudInscripcionDeLotes
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then
            Else
                llenarcomboDepto()
            End If
        End If
    End Sub

    Protected Sub guardarSoli_lote(sender As Object, e As EventArgs)
        Dim connectionString As String = conn
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO solicitud_inscripcion_delotes 
            (nombre_productor, representante_legar, identidad_productor, extendida, residencia_productor, telefono_productor, no_registro_productor, nombre_multiplicador, 
            cedula_multiplicador, telefono_multiplicador, nombre_finca, departamento, municipio, aldea, caserio, nombre_persona_finca, nombre_lote, tipo_cultivo,
            variedad, lote_no, fecha_analisis, year_produccion, categoria_semilla, tipo_semilla, cultivo_semilla, variedad_frijol, variedad_maiz, superficie_hectarea, superficie_mz,
            fecha_aprox_siembra, fecha_aprox_cosecha, produccion_est_hectareas, produccion_est_manzanas, destino) VALUES (@nombre_productor, @representante_legal, @identidad_productor, @extendida, @residencia_productor, @telefono_productor, @no_registro_productor, @nombre_multiplicador,
            @cedula_multiplicador, @telefono_multiplicador, @nombre_finca, @departamento, @municipio, @aldea, @caserio, @nombre_persona_finca, @nombre_lote, @tipo_cultivo,
            @variedad, @lote_no, @fecha_analisis, @year_produccion, @categoria_semilla, @tipo_semilla, @cultivo_semilla, @variedad_frijol, @variedad_maiz, @superficie_hectarea, @superficie_mz,
            @fecha_aprox_siembra, @fecha_aprox_cosecha, @produccion_est_hectareas, @produccion_est_manzanas, @destino)"

            Dim fechaConvertida As DateTime
            Dim fechaConvertida2 As DateTime
<<<<<<< HEAD
            Dim fechaConvertida3 As DateTime
            Dim fechaConvertida4 As DateTime
=======
            Dim fechaConvertida3 As Date
            Dim fechaConvertida4 As Date
            Dim año As Date


            If DateTime.TryParse(TextBox1.Text, fechaConvertida) Then
                fechaConvertida.ToString("dd-MM-yyyy")
            End If

            If DateTime.TryParse(TextBox4.Text, fechaConvertida2) Then
                fechaConvertida2.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(TextBox6.Text, año) Then
                año.ToString("yyyy")
            End If

            If Date.TryParse(TxtFechaSiembra.Text, año) Then
                fechaConvertida3.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(TxtCosecha.Text, año) Then
                fechaConvertida4.ToString("dd-MM-yyyy")
            End If
>>>>>>> 0a64b8c19a7401bd87b3449cd483f9570bbe621d

            Using cmd As New MySqlCommand(query, connection)

                cmd.Parameters.AddWithValue("@nombre_productor", txt_nombre_prod_new.Text)
                cmd.Parameters.AddWithValue("@representante_legal", Txt_Representante_Legal.Text)
                cmd.Parameters.AddWithValue("@identidad_productor", TxtIdentidad.Text)
                If DateTime.TryParse(TextBox1.Text, fechaConvertida) Then
                    cmd.Parameters.AddWithValue("@extendida", fechaConvertida.ToString("yyyy-MM-dd")) ' Aquí se formatea correctamente como yyyy-MM-dd
                End If
                cmd.Parameters.AddWithValue("@residencia_productor", TxtResidencia.Text)
                cmd.Parameters.AddWithValue("@telefono_productor", Convert.ToInt64(TxtTelefono.Text))
                cmd.Parameters.AddWithValue("@no_registro_productor", txtNoRegistro.Text)
                cmd.Parameters.AddWithValue("@nombre_multiplicador", txtNombreRe.Text)
                cmd.Parameters.AddWithValue("@cedula_multiplicador", txtIdentidadRe.Text)
                cmd.Parameters.AddWithValue("@telefono_multiplicador", Convert.ToInt64(TxtTelefonoRe.Text))
                cmd.Parameters.AddWithValue("@nombre_finca", TxtNombreFinca.Text)
                cmd.Parameters.AddWithValue("@departamento", gb_departamento_new.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@municipio", gb_municipio_new.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@aldea", gb_aldea_new.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@caserio", gb_caserio_new.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@nombre_persona_finca", TxtPersonaFinca.Text)
                cmd.Parameters.AddWithValue("@nombre_lote", TxtLote.Text)
                'cmd.Parameters.AddWithValue("@croquis", )
                cmd.Parameters.AddWithValue("@tipo_cultivo", CmbTipoSemilla.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@variedad", TextVariedad.Text)
                cmd.Parameters.AddWithValue("@lote_no", TextBox3.Text)
                If DateTime.TryParse(TextBox4.Text, fechaConvertida2) Then
                    cmd.Parameters.AddWithValue("@fecha_analisis", fechaConvertida2.ToString("yyyy-MM-dd")) ' Aquí se formatea correctamente como yyyy-MM-dd
                End If
                cmd.Parameters.AddWithValue("@year_produccion", TextBox6.Text)
                cmd.Parameters.AddWithValue("@categoria_semilla", DdlCategoria.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@tipo_semilla", DdlTipo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@cultivo_semilla", DropDownList3.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@variedad_frijol", DropDownList1.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@variedad_maiz", DropDownList2.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@superficie_hectarea", Convert.ToDouble(TxtHectareas.Text))
                cmd.Parameters.AddWithValue("@superficie_mz", Convert.ToDouble(TxtSuperficieMZ.Text))
                If DateTime.TryParse(TxtFechaSiembra.Text, fechaConvertida3) Then
                    cmd.Parameters.AddWithValue("@fecha_aprox_siembra", fechaConvertida3.ToString("yyyy-MM-dd")) ' Aquí se formatea correctamente como yyyy-MM-dd
                End If
                If DateTime.TryParse(TxtCosecha.Text, fechaConvertida4) Then
                    cmd.Parameters.AddWithValue("@fecha_aprox_cosecha", fechaConvertida4.ToString("yyyy-MM-dd")) ' Aquí se formatea correctamente como yyyy-MM-dd
                End If
                cmd.Parameters.AddWithValue("@produccion_est_hectareas", Convert.ToDouble(TxtProHectareas.Text))
                cmd.Parameters.AddWithValue("@produccion_est_manzanas", Convert.ToDouble(TextBox7.Text))
                cmd.Parameters.AddWithValue("@destino", DropDownList4.SelectedItem.Text)

                cmd.ExecuteNonQuery()
                connection.Close()
            End Using
        End Using
    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT * FROM tb_departamentos"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_departamento_new.DataSource = DtCombo
        gb_departamento_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_departamento_new.DataTextField = DtCombo.Columns(2).ToString
        gb_departamento_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_departamento_new.Items.Insert(0, newitem)
    End Sub

    Private Function DevolverValorDepart(cadena As String)

        If gb_departamento_new.SelectedItem.Text <> "" Then
            Dim codigoDepartamento As String = ""
            Dim StrCombo As String = "SELECT CODIGO_DEPARTAMENTO FROM tb_departamentos WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoDepartamento = DtCombo.Rows(0)("CODIGO_DEPARTAMENTO").ToString()
            Return codigoDepartamento
        End If

        Return 0
    End Function

    Private Function DevolverValorMuni(cadena As String)
        If gb_municipio_new.SelectedItem.Text <> "" Then
            Dim codigoMunicipio As String = ""
            Dim StrCombo As String = "SELECT CODIGO_MUNICIPIO FROM tb_municipio WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoMunicipio = DtCombo.Rows(0)("CODIGO_MUNICIPIO").ToString()
            Return codigoMunicipio
        End If
        Return 0
    End Function

    Private Function DevolverValorAlde(cadena As String)
        If gb_aldea_new.SelectedItem.Text <> "" Then
            Dim codigoCaserio As String = ""
            Dim StrCombo As String = "SELECT CODIGO_ALDEA FROM tb_aldea WHERE NOMBRE = @nombre"
            Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
            adaptcombo.SelectCommand.Parameters.AddWithValue("@nombre", cadena)
            Dim DtCombo As New DataTable
            adaptcombo.Fill(DtCombo)

            codigoCaserio = DtCombo.Rows(0)("CODIGO_ALDEA").ToString()
            Return codigoCaserio
        End If
        Return 0
    End Function
    Private Sub llenarmunicipio()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim departamento As String = DevolverValorDepart(gb_departamento_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_municipio WHERE CODIGO_DEPARTAMENTO = " & departamento & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_municipio_new.DataSource = DtCombo
        gb_municipio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_municipio_new.DataTextField = DtCombo.Columns(3).ToString
        gb_municipio_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_municipio_new.Items.Insert(0, newitem)
        'End If
    End Sub

    Private Sub llenarAldea()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim municipio As String = DevolverValorMuni(gb_municipio_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_aldea WHERE CODIGO_MUNICIPIO = " & municipio & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_aldea_new.DataSource = DtCombo
        gb_aldea_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_aldea_new.DataTextField = DtCombo.Columns(3).ToString
        gb_aldea_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_aldea_new.Items.Insert(0, newitem)
        'End If
    End Sub

    Private Sub llenarCaserio()
        'If gb_departamento_new.SelectedItem.Text <> " " Then
        Dim aldea As String = DevolverValorAlde(gb_aldea_new.SelectedItem.Text)
        Dim StrCombo As String = "SELECT * FROM tb_caserios WHERE CODIGO_ALDEA = " & aldea & ""
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        gb_caserio_new.DataSource = DtCombo
        gb_caserio_new.DataValueField = DtCombo.Columns(0).ToString()
        gb_caserio_new.DataTextField = DtCombo.Columns(5).ToString
        gb_caserio_new.DataBind()
        Dim newitem As New ListItem(" ", " ")
        gb_caserio_new.Items.Insert(0, newitem)
        'End If
    End Sub

    Protected Sub gb_departamento_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_departamento_new.SelectedIndexChanged
        llenarmunicipio()
    End Sub

    Protected Sub gb_municipio_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_municipio_new.SelectedIndexChanged
        llenarAldea()
    End Sub

    Protected Sub gb_aldea_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_aldea_new.SelectedIndexChanged
        llenarCaserio()
    End Sub

    Protected Sub TxtHectareas_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtHectareas.TextChanged
        TxtSuperficieMZ.Text = Convert.ToString(Convert.ToDouble(TxtHectareas.Text) * 0.7)
    End Sub

    Protected Sub TxtProHectareas_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProHectareas.TextChanged
        TextBox7.Text = Convert.ToString(Convert.ToDouble(TxtProHectareas.Text) * 0.7)
    End Sub
End Class