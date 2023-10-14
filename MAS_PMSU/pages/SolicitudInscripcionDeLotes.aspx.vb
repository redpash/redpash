Imports CrystalDecisions.[Shared].Json
Imports DocumentFormat.OpenXml.Office.Word
Imports MySql.Data.MySqlClient

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
                btnNuevoProductor.Visible = False
                VerificarTextBox()
                FillComboBoxWithProductorNames()
            End If
        End If
    End Sub

    Protected Sub guardarSoli_lote(sender As Object, e As EventArgs)
        Dim connectionString As String = conn
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO solicitud_inscripcion_delotes 
            (nombre_productor, representante_legar, identidad_productor, extendida, residencia_productor, telefono_productor, no_registro_productor, nombre_multiplicador, 
            cedula_multiplicador, telefono_multiplicador, nombre_finca, departamento, municipio, aldea, caserio, nombre_persona_finca, nombre_lote, croquis, tipo_cultivo,
            lote_no, fecha_analisis, year_produccion, categoria_semilla, tipo_semilla, cultivo_semilla, variedad_frijol, variedad_maiz, superficie_hectarea, superficie_mz,
            fecha_aprox_siembra, fecha_aprox_cosecha, produccion_est_hectareas, produccion_est_manzanas, destino) VALUES (@nombre_productor, @representante_legal, @identidad_productor, 
            @extendida, @residencia_productor, @telefono_productor, @no_registro_productor, @nombre_multiplicador, @cedula_multiplicador, @telefono_multiplicador, @nombre_finca, @departamento,
            @municipio, @aldea, @caserio, @nombre_persona_finca, @nombre_lote, @croquis, @tipo_cultivo,@lote_no, @fecha_analisis, @year_produccion, @categoria_semilla, @tipo_semilla, @cultivo_semilla, 
            @variedad_frijol, @variedad_maiz, @superficie_hectarea, @superficie_mz, @fecha_aprox_siembra, @fecha_aprox_cosecha, @produccion_est_hectareas, @produccion_est_manzanas, @destino)"

            Dim fechaConvertida As DateTime
            Dim fechaConvertida2 As DateTime
            Dim fechaConvertida3 As DateTime
            Dim fechaConvertida4 As DateTime
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
                If fileUpload.HasFile Then
                    ' Obtener el contenido del archivo
                    Dim fileBytes As Byte() = fileUpload.FileBytes


                    cmd.Parameters.AddWithValue("@croquis", fileBytes)
                End If
                cmd.Parameters.AddWithValue("@tipo_cultivo", CmbTipoSemilla.SelectedItem.Text)

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

                vaciar()
                Response.Write("<script>window.alert('¡Se ha registrado correctamente la solicitud de inscripción de lotes!') </script>")
            End Using
        End Using
    End Sub

    Protected Sub vaciar()
        txt_nombre_prod_new.Text = " "
        Txt_Representante_Legal.Text = " "
        TxtIdentidad.Text = " "
        TextBox1.Text = " "
        TxtResidencia.Text = " "
        TxtTelefono.Text = " "
        txtNoRegistro.Text = " "
        txtNombreRe.Text = " "
        txtIdentidadRe.Text = " "
        TxtTelefonoRe.Text = " "
        TxtNombreFinca.Text = " "
        gb_departamento_new.SelectedItem.Text = " "
        gb_municipio_new.SelectedItem.Text = " "
        gb_aldea_new.SelectedItem.Text = " "
        gb_caserio_new.SelectedItem.Text = " "
        TxtPersonaFinca.Text = " "
        TxtLote.Text = " "
        'FileUpload
        CmbTipoSemilla.SelectedItem.Text = " "
        TextBox3.Text = " "
        TextBox4.Text = " "
        TextBox6.Text = " "
        DdlCategoria.SelectedItem.Text = " "
        DdlTipo.SelectedItem.Text = " "
        DropDownList3.SelectedItem.Text = " "
        DropDownList1.SelectedItem.Text = " "
        DropDownList2.SelectedItem.Text = " "
        TxtHectareas.Text = " "
        TxtSuperficieMZ.Text = " "
        TxtFechaSiembra.Text = " "
        TxtCosecha.Text = " "
        TxtProHectareas.Text = " "
        TextBox7.Text = " "
        DropDownList4.SelectedItem.Text = " "
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
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
        VerificarTextBox()
        'End If
    End Sub

    'Private Function existeProductor(ByVal cadena As String)
    '    Dim nombre As String = ""
    '    Dim StrCOmbo As String = "SELECT PROD_NOMBRE FROM registros_bancos_semilla WHERE PROD_NOMBRE = @valor"
    '    Dim adaptcombo As New MySqlDataAdapter(StrCOmbo, conn)
    'adaptcombo.SelectCommand.Parameters.AddWithValue("@valor", "")
    '    Dim DtCombo As New DataTable
    '    adaptcombo.Fill(DtCombo)
    '
    '    Return nombre = DtCombo.Rows(0)("PROD_NOMBRE").ToString()
    'End Function
    Protected Sub buscar_productor(sender As Object, e As EventArgs)
        llenarProdutor()
        VerificarTextBox()
    End Sub
    'Protected Sub txt_nombre_prod_new_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_nombre_prod_new.TextChanged
    ' llenarProdutor()
    'End Sub

    Protected Sub llenarProdutor()
        Dim StrCombo As String = "SELECT * FROM registros_bancos_semilla WHERE PROD_NOMBRE = @valor"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        adaptcombo.SelectCommand.Parameters.AddWithValue("@valor", txt_nombre_prod_new.Text)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        If DtCombo.Rows.Count > 0 Then
            txt_nombre_prod_new.Text = DtCombo.Rows(0)("PROD_NOMBRE").ToString
            TxtIdentidad.Text = DtCombo.Rows(0)("PROD_IDENTIDAD").ToString
            TxtTelefono.Text = DtCombo.Rows(0)("PROD_TELEFONO").ToString
            btnNuevoProductor.Visible = False
            PanelA1.Visible = True
            PanelA2.Visible = True
            PanelB.Visible = True
            PanelC.Visible = True
            PanelD.Visible = True
            btnGuardarLote.Visible = True
        Else
            btnNuevoProductor.Visible = True
            Response.Write("<script>window.alert('¡No existe productor en la base de datos!') </script>")
        End If
        VerificarTextBox()
    End Sub

    Protected Sub gb_departamento_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_departamento_new.SelectedIndexChanged
        llenarmunicipio()
        VerificarTextBox()
    End Sub

    Protected Sub gb_municipio_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_municipio_new.SelectedIndexChanged
        llenarAldea()
        VerificarTextBox()
    End Sub

    Protected Sub gb_aldea_new_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gb_aldea_new.SelectedIndexChanged
        llenarCaserio()
        VerificarTextBox()
    End Sub

    Protected Sub TxtHectareas_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtHectareas.TextChanged
        If TxtHectareas.Text <> "" Then
            TxtSuperficieMZ.Text = Convert.ToString(Convert.ToDouble(TxtHectareas.Text) / 0.7)
            VerificarTextBox()
        Else
            TxtSuperficieMZ.Text = ""
            VerificarTextBox()
        End If
    End Sub

    Protected Sub TxtProHectareas_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProHectareas.TextChanged
        If TxtProHectareas.Text <> "" Then
            TextBox7.Text = Convert.ToString(Convert.ToDouble(TxtProHectareas.Text) * 0.7)
            VerificarTextBox()
        Else
            TextBox7.Text = ""
            VerificarTextBox()
        End If
    End Sub

    Protected Sub btnNuevoProductor_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevoProductor.Click
        Response.Redirect("Registro_Banco_Semilla.aspx")
    End Sub

    'Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    If fileUpload.HasFile Then
    '        ' Obtener el contenido del archivo
    '        Dim fileBytes As Byte() = fileUpload.FileBytes
    '
    '        ' Crear una conexión a la base de datos
    '        Dim connectionString As String = conn
    '        Using con As New MySqlConnection(connectionString)
    '            'con.Open()
    '
    '            ' Query para insertar el archivo en el campo 'croquis' de la tabla (asumiendo que tienes una tabla llamada 'tu_tabla' con un campo 'croquis' de tipo LONGBLOB)
    '            Dim query As String = "INSERT INTO solicitud_inscripcion_delotes (croquis) VALUES (@croquis)"
    '
    '            Using cmd As New MySqlCommand(query, con)
    '                cmd.Parameters.AddWithValue("@croquis", fileBytes)
    '
    '                ' Ejecutar la consulta
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using
    '
    '        ' Limpia la etiqueta de advertencia (si la tienes)
    '        Label5.Text = ""
    '
    '        ' Opcional: Mostrar un mensaje de éxito
    '        ' Response.Write("Archivo subido exitosamente")
    '    Else
    '        ' Mostrar un mensaje de advertencia si no se seleccionó ningún archivo
    '        Label5.Text = "Por favor, seleccione un archivo para subir."
    '    End If
    'End Sub

    Protected Sub CmbTipoSemilla_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Obtiene el valor seleccionado en la DropDownList
        Dim selectedValue As String = CmbTipoSemilla.SelectedValue

        ' Si selecciona "Frijol," muestra la TextBox de Variedad; de lo contrario, ocúltala
        If selectedValue = "Frijol" Then
            VariedadFrijol.Visible = True
            VariedadMaiz.Visible = False
        ElseIf selectedValue = "Maiz" Then
            VariedadMaiz.Visible = True
            VariedadFrijol.Visible = False
        Else
            VariedadMaiz.Visible = False
            VariedadFrijol.Visible = False
        End If

        VerificarTextBox()
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Obtiene el valor seleccionado en la DropDownList
        Dim selectedValue As String = DropDownList3.SelectedValue

        ' Si selecciona "Frijol," muestra la TextBox de Variedad; de lo contrario, ocúltala
        If selectedValue = "Frijol" Then
            variedadfrijol2.Visible = True
            variedadmaiz2.Visible = False
        ElseIf selectedValue = "Maiz" Then
            variedadmaiz2.Visible = True
            variedadfrijol2.Visible = False
        Else
            variedadmaiz2.Visible = False
            variedadfrijol2.Visible = False
        End If

        VerificarTextBox()
    End Sub

    Protected Sub VerificarTextBox()

        If String.IsNullOrEmpty(txt_nombre_prod_new.Text) Then
            lb_nombre_new.Text = "*"
        Else
            lb_nombre_new.Text = ""
        End If

        If String.IsNullOrEmpty(Txt_Representante_Legal.Text) Then
            LB_RepresentanteLegal.Text = "*"
        Else
            LB_RepresentanteLegal.Text = ""
        End If

        If String.IsNullOrEmpty(TxtIdentidad.Text) Then
            Lb_CedulaIdentidad.Text = "*"
        Else
            Lb_CedulaIdentidad.Text = ""
        End If

        If String.IsNullOrEmpty(TextBox1.Text) Then
            Label1.Text = "*"
        Else
            Label1.Text = ""
        End If

        If String.IsNullOrEmpty(TxtResidencia.Text) Then
            LbResidencia.Text = "*"
        Else
            LbResidencia.Text = ""
        End If

        If String.IsNullOrEmpty(TxtTelefono.Text) Then
            LblTelefono.Text = "*"
        Else
            LblTelefono.Text = ""
        End If

        If String.IsNullOrEmpty(txtNoRegistro.Text) Then
            LbNoRegistro.Text = "*"
        Else
            LbNoRegistro.Text = ""
        End If

        If String.IsNullOrEmpty(txtNombreRe.Text) Then
            lbNombreRe.Text = "*"
        Else
            lbNombreRe.Text = ""
        End If

        If String.IsNullOrEmpty(txtIdentidadRe.Text) Then
            lbIdentidadRe.Text = "*"
        Else
            lbIdentidadRe.Text = ""
        End If

        If String.IsNullOrEmpty(TxtTelefonoRe.Text) Then
            LbTelefonoRe.Text = "*"
        Else
            LbTelefonoRe.Text = ""
        End If

        If String.IsNullOrEmpty(TxtNombreFinca.Text) Then
            LblNombreFinca.Text = "*"
        Else
            LblNombreFinca.Text = ""
        End If

        If (gb_departamento_new.SelectedItem.Text = " ") Then
            lb_dept_new.Text = "*"
        Else
            lb_dept_new.Text = ""
        End If

        If (gb_municipio_new.SelectedItem.Text = " ") Then
            lb_mun_new.Text = "*"
        Else
            lb_mun_new.Text = ""
        End If

        If (gb_aldea_new.SelectedItem.Text = " ") Then
            lb_aldea_new.Text = "*"
        Else
            lb_aldea_new.Text = ""
        End If

        If (gb_caserio_new.SelectedItem.Text = " ") Then
            lb_caserio_new.Text = "*"
        Else
            lb_caserio_new.Text = ""
        End If

        If String.IsNullOrEmpty(TxtPersonaFinca.Text) Then
            LblPersonaFinca.Text = "*"
        Else
            LblPersonaFinca.Text = ""
        End If

        If String.IsNullOrEmpty(TxtLote.Text) Then
            LbLote.Text = "*"
        Else
            LbLote.Text = ""
        End If

        'If String.IsNullOrEmpty(***Label5) Then
        '    Label1.Text = "*"
        'Else
        '    Label1.Text = ""
        'End If

        If String.IsNullOrEmpty(CmbTipoSemilla.Text) Then
            Label2.Text = "*"
        Else
            Label2.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList5.Text) Then
            Label3.Text = "*"
        Else
            Label3.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList6.Text) Then
            Label4.Text = "*"
        Else
            Label4.Text = ""
        End If

        If String.IsNullOrEmpty(TextBox3.Text) Then
            Label8.Text = "*"
        Else
            Label8.Text = ""
        End If

        If String.IsNullOrEmpty(TextBox4.Text) Then
            Label9.Text = "*"
        Else
            Label9.Text = ""
        End If

        If String.IsNullOrEmpty(TextBox6.Text) Then
            Label10.Text = "*"
        Else
            Label10.Text = ""
        End If

        If String.IsNullOrEmpty(DdlCategoria.Text) Then
            Label6.Text = "*"
        Else
            Label6.Text = ""
        End If

        If String.IsNullOrEmpty(DdlTipo.Text) Then
            Label7.Text = "*"
        Else
            Label7.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList3.Text) Then
            Label11.Text = "*"
        Else
            Label11.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList1.Text) Then
            Label15.Text = "*"
        Else
            Label15.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList2.Text) Then
            Label16.Text = "*"
        Else
            Label16.Text = ""
        End If

        If String.IsNullOrEmpty(TxtHectareas.Text) Then
            Label12.Text = "*"
        Else
            Label12.Text = ""
        End If

        If String.IsNullOrEmpty(TxtSuperficieMZ.Text) Then
            Label13.Text = "*"
        Else
            Label13.Text = ""
        End If

        If String.IsNullOrEmpty(TxtFechaSiembra.Text) Then
            Label14.Text = "*"
        Else
            Label14.Text = ""
        End If

        If String.IsNullOrEmpty(TxtCosecha.Text) Then
            Label17.Text = "*"
        Else
            Label17.Text = ""
        End If

        If String.IsNullOrEmpty(TxtProHectareas.Text) Then
            Label19.Text = "*"
        Else
            Label19.Text = ""
        End If

        If String.IsNullOrEmpty(TextBox7.Text) Then
            Label20.Text = "*"
        Else
            Label20.Text = ""
        End If

        If String.IsNullOrEmpty(DropDownList4.Text) Then
            Label21.Text = "*"
        Else
            Label21.Text = ""
        End If

    End Sub
    Private Sub FillComboBoxWithProductorNames()
        Dim StrCombo As String = "SELECT PROD_NOMBRE FROM registros_bancos_semilla"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)

        DropDownList7.DataSource = DtCombo
        DropDownList7.DataValueField = DtCombo.Columns(0).ToString()
        DropDownList7.DataTextField = DtCombo.Columns(0).ToString
        DropDownList7.DataBind()
    End Sub
    Protected Sub DropDownList7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedValue As String = DropDownList7.SelectedValue
        txt_nombre_prod_new.Text = selectedValue
        VerificarTextBox()
    End Sub
End Class

