Imports MySql.Data.MySqlClient

Public Class SolicitudInscripcionDeLotes
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            Using cmd As New MySqlCommand(query, connection)

                cmd.Parameters.AddWithValue("@nombre_productor", txt_nombre_prod_new.Text)
                cmd.Parameters.AddWithValue("@representante_legal", Txt_Representante_Legal.Text)
                cmd.Parameters.AddWithValue("@identidad_productor", TxtIdentidad.Text)
                cmd.Parameters.AddWithValue("@extendida", fechaConvertida)
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
                cmd.Parameters.AddWithValue("@fecha_analisis", fechaConvertida2)
                cmd.Parameters.AddWithValue("@year_produccion", año)
                cmd.Parameters.AddWithValue("@categoria_semilla", DdlCategoria.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@tipo_semilla", DdlTipo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@cultivo_semilla", DropDownList3.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@variedad_frijol", DropDownList1.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@variedad_maiz", DropDownList2.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@superficie_hectarea", Convert.ToDouble(TxtHectareas.Text))
                cmd.Parameters.AddWithValue("@superficie_mz", Convert.ToDouble(TxtSuperficieMZ.Text))
                cmd.Parameters.AddWithValue("@fecha_aprox_siembra", fechaConvertida3)
                cmd.Parameters.AddWithValue("@fecha_aprox_cosecha", fechaConvertida4)
                cmd.Parameters.AddWithValue("@produccion_est_hectareas", Convert.ToDouble(TxtProHectareas.Text))
                cmd.Parameters.AddWithValue("@produccion_est_manzanas", Convert.ToDouble(TextBox7.Text))
                cmd.Parameters.AddWithValue("@destino", DropDownList4.SelectedItem.Text)

                cmd.ExecuteNonQuery()
                connection.Close()
            End Using
        End Using
    End Sub

End Class