Imports MySql.Data.MySqlClient

Public Class VisitaTecnicos
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim consulta As String = "INSERT INTO asistencia_tecnica (nombre_completo,
                                coordenada_gps,
                                codigo_bsc,
                                fecha_visita_productor,
                                numero_visitas_productor,
                                ciclo_siembra_visita_AT,
                                fase_cultivo_frijol_realizar_visita,
                                fue_reportada_visita_anterior,
                                Amadeus_77,
                                Amadeus_77_certificado,
                                Amadeus_77_comercial,
                                Amadeus_77_fecha_siembra,
                                Carrizalito,
                                Carrizalito_certificado,
                                Carrizalito_comercial,
                                Carrizalito_fecha_siembra,
                                Deorho,
                                Deorho_certificado,
                                Deorho_comercial,
                                Deorho_fecha_siembra,
                                ParaisitoMejoradoPM_2,
                                ParaisitoMejoradoPM_2_certificado,
                                ParaisitoMejoradoPM_2_comercial,
                                ParaisitoMejoradoPM_2_fecha_siembra,
                                Hondurasnutritivo,
                                Hondurasnutritivo_certificado,
                                Hondurasnutritivo_comercial,
                                Hondurasnutritivo_fecha_siembra,
                                IntaCardenas,
                                IntaCardenas_certificado,
                                IntaCardenas_comercial,
                                IntaCardenas_fecha_siembra,
                                Azabache40,
                                Azabache40_certificado,
                                Azabache40_comercial,
                                Azabache40_fecha_siembra,
                                LencaPrecoz,
                                LencaPrecoz_certificado,
                                LencaPrecoz_comercial,
                                LencaPrecoz_fecha_siembra,
                                RojoChorti,
                                RojoChorti_certificado,
                                RojoChorti_comercial,
                                RojoChorti_fecha_siembra,
                                TolupanRojo,
                                TolupanRojo_certificado,
                                TolupanRojo_comercial,
                                TolupanRojo_fecha_siembra,
                                Brindo_recomendacion_5,
                                Cantidad_semilla_regist_utili_mz,
                                Porcentaje_germinacion,
                                Gramos_inoculante_utilizados,
                                Problemas_encontrados_5,
                                Recomendacion_tecnica_5,
                                Brindo_recomendacion_6,
                                control_quimico_herbicida,
                                control_quimico_herbicida_contacto_NO,
                                Problemas_encontrados_6,
                                Recomendacion_tecnica_6,
                                Brindo_recomendacion_7,
                                Realizo_este_anio_analisis_suelo_cultivar_frijol,
                                Porque_7_1,
                                fertilizaciones_realizado_base_resultados_analisis_suelo,
                                Cuenta_con_resultados_analisis_suelo,
                                codigo_resultado_analisis,
                                aplico_fertilizantes_quimicos_organicos_foliares,
                                Porque_7_2,
                                Problemas_encontrados_7,
                                Recomendacion_tecnica_7,
                                Brindo_recomendacion_8,
                                Realizo_tipo_prevencion_control_plagas_enfermedades,
                                Porque_8,
                                etapa_fase_cultivo_afectaron_plagas,
                                Cantidad_libras_8,
                                Cantidad_manzana_8,
                                Problemas_encontrados_8,
                                Recomendacion_tecnica_8,
                                Brindo_recomendacion_9,
                                Presenta_estres_hidrico_plantas,
                                Lotes_regados,
                                Area_Mz,
                                cuantos_dias_riega_dias,
                                Cantidad_horas_riego_Horas_dia,
                                Fugas,
                                Reduccion_caudal,
                                Diseno,
                                Agua_con_sedimentos_sucio_pesada,
                                Otro_tipo_riego,
                                Recomendacion_tecnica_9) VALUES (@nombre_completo,
                                @coordenada_gps,
                                @codigo_bsc,
                                @fecha_visita_productor,
                                @numero_visitas_productor,
                                @ciclo_siembra_visita_AT,
                                @fase_cultivo_frijol_realizar_visita,
                                @fue_reportada_visita_anterior,
                                @Amadeus_77,
                                @Amadeus_77_certificado,
                                @Amadeus_77_comercial,
                                @Amadeus_77_fecha_siembra,
                                @Carrizalito,
                                @Carrizalito_certificado,
                                @Carrizalito_comercial,
                                @Carrizalito_fecha_siembra,
                                @Deorho,
                                @Deorho_certificado,
                                @Deorho_comercial,
                                @Deorho_fecha_siembra,
                                @ParaisitoMejoradoPM_2,
                                @ParaisitoMejoradoPM_2_certificado,
                                @ParaisitoMejoradoPM_2_comercial,
                                @ParaisitoMejoradoPM_2_fecha_siembra,
                                @Hondurasnutritivo,
                                @Hondurasnutritivo_certificado,
                                @Hondurasnutritivo_comercial,
                                @Hondurasnutritivo_fecha_siembra,
                                @IntaCardenas,
                                @IntaCardenas_certificado,
                                @IntaCardenas_comercial,
                                @IntaCardenas_fecha_siembra,
                                @Azabache40,
                                @Azabache40_certificado,
                                @Azabache40_comercial,
                                @Azabache40_fecha_siembra,
                                @LencaPrecoz,
                                @LencaPrecoz_certificado,
                                @LencaPrecoz_comercial,
                                @LencaPrecoz_fecha_siembra,
                                @RojoChorti,
                                @RojoChorti_certificado,
                                @RojoChorti_comercial,
                                @RojoChorti_fecha_siembra,
                                @TolupanRojo,
                                @TolupanRojo_certificado,
                                @TolupanRojo_comercial,
                                @TolupanRojo_fecha_siembra,
                                @Brindo_recomendacion_5,
                                @Cantidad_semilla_regist_utili_mz,
                                @Porcentaje_germinacion,
                                @Gramos_inoculante_utilizados,
                                @Problemas_encontrados_5,
                                @Recomendacion_tecnica_5,
                                @Brindo_recomendacion_6,
                                @control_quimico_herbicida,
                                @control_quimico_herbicida_contacto_NO,
                                @Problemas_encontrados_6,
                                @Recomendacion_tecnica_6,
                                @Brindo_recomendacion_7,
                                @Realizo_este_anio_analisis_suelo_cultivar_frijol,
                                @Porque_7_1,
                                @fertilizaciones_realizado_base_resultados_analisis_suelo,
                                @Cuenta_con_resultados_analisis_suelo,
                                @codigo_resultado_analisis,
                                @aplico_fertilizantes_quimicos_organicos_foliares,
                                @Porque_7_2,
                                @Problemas_encontrados_7,
                                @Recomendacion_tecnica_7,
                                @Brindo_recomendacion_8,
                                @Realizo_tipo_prevencion_control_plagas_enfermedades,
                                @Porque_8,
                                @etapa_fase_cultivo_afectaron_plagas,
                                @Cantidad_libras_8,
                                @Cantidad_manzana_8,
                                @Problemas_encontrados_8,
                                @Recomendacion_tecnica_8,
                                @Brindo_recomendacion_9,
                                @Presenta_estres_hidrico_plantas,
                                @Lotes_regados,
                                @Area_Mz,
                                @cuantos_dias_riega_dias,
                                @Cantidad_horas_riego_Horas_dia,
                                @Fugas,
                                @Reduccion_caudal,
                                @Diseno,
                                @Agua_con_sedimentos_sucio_pesada,
                                @Otro_tipo_riego,
                                @Recomendacion_tecnica_9)"
        Using con As New MySqlConnection(conn)
            con.Open()

            Dim fecha As Date
            Dim fechaAmadeus As Date
            Dim fechaCarrizalito As Date
            Dim fechaDeorho As Date
            Dim fechaParaisitoMejoradoPM_2 As Date
            Dim fechaHondurasnutritivo As Date
            Dim fechaIntaCardenas As Date
            Dim fechaAzabache40 As Date
            Dim fechaLencaPrecoz As Date
            Dim fechaRojoChorti As Date
            Dim fechaTolupanRojo As Date

            Dim opcionesSeleccionadas As New List(Of String)

            For Each item As ListItem In cblEtapasAfectadas.Items
                If item.Selected Then
                    opcionesSeleccionadas.Add(item.Text)
                End If
            Next

            If Date.TryParse(txtFechaVisita.Text, fecha) Then
                fecha.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaAmadeus.Text, fechaAmadeus) Then
                fechaAmadeus.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaCarrizalito.Text, fechaCarrizalito) Then
                fechaCarrizalito.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaDeorho.Text, fechaDeorho) Then
                fechaDeorho.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechalb_ParaisitoMejoradoPM_2.Text, fechaParaisitoMejoradoPM_2) Then
                fechaParaisitoMejoradoPM_2.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaHondurasnutritivo.Text, fechaHondurasnutritivo) Then
                fechaHondurasnutritivo.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaIntaCardenas.Text, fechaIntaCardenas) Then
                fechaIntaCardenas.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaAzabache40.Text, fechaAzabache40) Then
                fechaAzabache40.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaLencaPrecoz.Text, fechaLencaPrecoz) Then
                fechaLencaPrecoz.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaRojoChorti.Text, fechaRojoChorti) Then
                fechaRojoChorti.ToString("dd-MM-yyyy")
            End If

            If Date.TryParse(txtFechaTolupanRojo.Text, fechaTolupanRojo) Then
                fechaTolupanRojo.ToString("dd-MM-yyyy")
            End If

            Using cmd As New MySqlCommand(consulta, con)
                cmd.Parameters.AddWithValue("@nombre_completo", txtNombreCompleto.Text)
                cmd.Parameters.AddWithValue("@coordenada_gps", txtCoordenadaGPS.Text)
                cmd.Parameters.AddWithValue("@codigo_bsc", txtCodigoAsignado.Text)
                cmd.Parameters.AddWithValue("@fecha_visita_productor", fecha)
                cmd.Parameters.AddWithValue("@numero_visitas_productor", Convert.ToInt64(txtVisitasRealizadas.Text))
                cmd.Parameters.AddWithValue("@ciclo_siembra_visita_AT", ddlCicloSiembra.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@fase_cultivo_frijol_realizar_visita", ddlFaseVisita.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@fue_reportada_visita_anterior", ddlConfirmaInspeccion.SelectedItem.Text)
                If ddlConfirmaInspeccion.SelectedItem.Text = "No" Then
                    cmd.Parameters.AddWithValue("@Amadeus_77", lb_Amadeus.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Amadeus_77_certificado", lb_Amadeus_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Amadeus_77_comercial", lb_Amadeus_Comercial.SelectedItem.Text)
                    If txtFechaAmadeus.Text <> "" Then
                        cmd.Parameters.AddWithValue("@Amadeus_77_fecha_siembra", fechaAmadeus)
                    Else
                        cmd.Parameters.AddWithValue("@Amadeus_77_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@Carrizalito", lb_Carrizalito.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Carrizalito_certificado", lb_Carrizalito_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Carrizalito_comercial", lb_Carrizalito_Comercial.SelectedItem.Text)
                    If txtFechaCarrizalito.Text <> "" Then
                        cmd.Parameters.AddWithValue("@Carrizalito_fecha_siembra", fechaCarrizalito)
                    Else
                        cmd.Parameters.AddWithValue("@Carrizalito_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@Deorho", lb_Deorho.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Deorho_certificado", lb_Deorho_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Deorho_comercial", lb_Deorho_Comercial.SelectedItem.Text)
                    If txtFechaDeorho.Text <> "" Then
                        cmd.Parameters.AddWithValue("@Deorho_fecha_siembra", fechaDeorho)
                    Else
                        cmd.Parameters.AddWithValue("@Deorho_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2", lb_ParaisitoMejoradoPM_2.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_certificado", lb_ParaisitoMejoradoPM_2_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_comercial", lb_ParaisitoMejoradoPM_2_Comercial.SelectedItem.Text)
                    If txtFechalb_ParaisitoMejoradoPM_2.Text <> "" Then
                        cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_fecha_siembra", fechaParaisitoMejoradoPM_2)
                    Else
                        cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo", lb_Hondurasnutritivo.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo_certificado", lb_Hondurasnutritivo_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo_comercial", lb_Hondurasnutritivo_Comercial.SelectedItem.Text)
                    If txtFechaHondurasnutritivo.Text <> "" Then
                        cmd.Parameters.AddWithValue("@Hondurasnutritivo_fecha_siembra", fechaHondurasnutritivo)
                    Else
                        cmd.Parameters.AddWithValue("@Hondurasnutritivo_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@IntaCardenas", lb_IntaCardenas.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@IntaCardenas_certificado", lb_IntaCardenas_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@IntaCardenas_comercial", lb_IntaCardenas_Comercial.SelectedItem.Text)
                    If txtFechaIntaCardenas.Text <> "" Then
                        cmd.Parameters.AddWithValue("@IntaCardenas_fecha_siembra", fechaIntaCardenas)
                    Else
                        cmd.Parameters.AddWithValue("@IntaCardenas_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@Azabache40", lb_Azabache40.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Azabache40_certificado", lb_Azabache40_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Azabache40_comercial", lb_Azabache40_Comercial.SelectedItem.Text)
                    If txtFechaAzabache40.Text <> "" Then
                        cmd.Parameters.AddWithValue("@Azabache40_fecha_siembra", fechaAzabache40)
                    Else
                        cmd.Parameters.AddWithValue("@Azabache40_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@LencaPrecoz", lb_LencaPrecoz.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@LencaPrecoz_certificado", lb_LencaPrecoz_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@LencaPrecoz_comercial", lb_LencaPrecoz_Comercial.SelectedItem.Text)
                    If txtFechaLencaPrecoz.Text <> "" Then
                        cmd.Parameters.AddWithValue("@LencaPrecoz_fecha_siembra", fechaLencaPrecoz)
                    Else
                        cmd.Parameters.AddWithValue("@LencaPrecoz_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@RojoChorti", lb_RojoChorti.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@RojoChorti_certificado", lb_RojoChorti_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@RojoChorti_comercial", lb_RojoChorti_Comercial.SelectedItem.Text)
                    If txtFechaRojoChorti.Text <> "" Then
                        cmd.Parameters.AddWithValue("@RojoChorti_fecha_siembra", fechaRojoChorti)
                    Else
                        cmd.Parameters.AddWithValue("@RojoChorti_fecha_siembra", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@TolupanRojo", lb_TolupanRojo.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@TolupanRojo_certificado", lb_TolupanRojo_Certificado.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@TolupanRojo_comercial", lb_TolupanRojo_Comercial.SelectedItem.Text)
                    If txtFechaTolupanRojo.Text <> "" Then
                        cmd.Parameters.AddWithValue("@TolupanRojo_fecha_siembra", fechaTolupanRojo)
                    Else
                        cmd.Parameters.AddWithValue("@TolupanRojo_fecha_siembra", DBNull.Value)
                    End If
                Else
                    cmd.Parameters.AddWithValue("@Amadeus_77", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Amadeus_77_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Amadeus_77_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Amadeus_77_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@Carrizalito", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Carrizalito_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Carrizalito_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Carrizalito_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@Deorho", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Deorho_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Deorho_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Deorho_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2", DBNull.Value)
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@ParaisitoMejoradoPM_2_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@Hondurasnutritivo", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Hondurasnutritivo_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@IntaCardenas", DBNull.Value)
                    cmd.Parameters.AddWithValue("@IntaCardenas_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@IntaCardenas_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@IntaCardenas_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@Azabache40", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Azabache40_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Azabache40_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@Azabache40_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@LencaPrecoz", DBNull.Value)
                    cmd.Parameters.AddWithValue("@LencaPrecoz_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@LencaPrecoz_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@LencaPrecoz_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@RojoChorti", DBNull.Value)
                    cmd.Parameters.AddWithValue("@RojoChorti_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@RojoChorti_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@RojoChorti_fecha_siembra", DBNull.Value)

                    cmd.Parameters.AddWithValue("@TolupanRojo", DBNull.Value)
                    cmd.Parameters.AddWithValue("@TolupanRojo_certificado", DBNull.Value)
                    cmd.Parameters.AddWithValue("@TolupanRojo_comercial", DBNull.Value)
                    cmd.Parameters.AddWithValue("@TolupanRojo_fecha_siembra", DBNull.Value)
                End If
                cmd.Parameters.AddWithValue("@Brindo_recomendacion_5", ddlRecomendacion.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Cantidad_semilla_regist_utili_mz", Convert.ToDouble(txtCantidadSemilla.Text))
                cmd.Parameters.AddWithValue("@Porcentaje_germinacion", Convert.ToDouble(txtPorcentajeGerminacion.Text))
                cmd.Parameters.AddWithValue("@Gramos_inoculante_utilizados", Convert.ToDouble(txtCantidadInoculante.Text))
                cmd.Parameters.AddWithValue("@Problemas_encontrados_5", txtProblemasEncontrados.Text)
                cmd.Parameters.AddWithValue("@Recomendacion_tecnica_5", txtRecomendacionTecnica.Text)

                cmd.Parameters.AddWithValue("@Brindo_recomendacion_6", ddlControlMalezas.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@control_quimico_herbicida", ddlControlQuimicoSelectivo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@control_quimico_herbicida_contacto_NO", ddlControlQuimicoNoSelectivo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Problemas_encontrados_6", txtProblemasEncontrados2.Text)
                cmd.Parameters.AddWithValue("@Recomendacion_tecnica_6", txtRecomendacionTecnica2.Text)

                cmd.Parameters.AddWithValue("@Brindo_recomendacion_7", ddlPlanNutricional.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Realizo_este_anio_analisis_suelo_cultivar_frijol", ddlAnalisisSuelo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Porque_7_1", txtRazonSinAnalisisSuelo.Text)
                cmd.Parameters.AddWithValue("@fertilizaciones_realizado_base_resultados_analisis_suelo", ddlFertilizacionesBasadasEnAnalisis.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Cuenta_con_resultados_analisis_suelo", ddlResultadosAnalisisSuelo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@codigo_resultado_analisis", txtCodigoResultadoAnalisis.Text)
                cmd.Parameters.AddWithValue("@aplico_fertilizantes_quimicos_organicos_foliares", ddlAplicoFertilizantes.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Porque_7_2", txtRazonSinFertilizantes.Text)
                cmd.Parameters.AddWithValue("@Problemas_encontrados_7", txtProblemasFertilizantes.Text)
                cmd.Parameters.AddWithValue("@Recomendacion_tecnica_7", txtRecomendacionFertilizantes.Text)

                cmd.Parameters.AddWithValue("@Brindo_recomendacion_8", ddlPrevencionControlPlagas.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Realizo_tipo_prevencion_control_plagas_enfermedades", ddlTipoPrevencionPlagas.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Porque_8", txtRazonSinPrevencionPlagas.Text)
                cmd.Parameters.AddWithValue("@etapa_fase_cultivo_afectaron_plagas", String.Join(",", opcionesSeleccionadas))
                cmd.Parameters.AddWithValue("@Cantidad_libras_8", Convert.ToDouble(txtCantidadQuintalesPerdidos.Text))
                cmd.Parameters.AddWithValue("@Cantidad_manzana_8", Convert.ToDouble(txtAreaAfectada.Text))
                cmd.Parameters.AddWithValue("@Problemas_encontrados_8", txtProblemasPlagas.Text)
                cmd.Parameters.AddWithValue("@Recomendacion_tecnica_8", txtRecomendacionPlagas.Text)

                cmd.Parameters.AddWithValue("@Brindo_recomendacion_9", ddlRiegoRecomendacion.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Presenta_estres_hidrico_plantas", ddlEstresHidrico.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Lotes_regados", txtLotesRegados.Text)
                cmd.Parameters.AddWithValue("@Area_Mz", Convert.ToDouble(txtAreaMz.Text))
                cmd.Parameters.AddWithValue("@cuantos_dias_riega_dias", txtFrecuenciaRiego.Text)
                cmd.Parameters.AddWithValue("@Cantidad_horas_riego_Horas_dia", txtHorasRiego.Text)
                cmd.Parameters.AddWithValue("@Fugas", ddlFugas.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Reduccion_caudal", ddlReduccionCaudal.Text)
                cmd.Parameters.AddWithValue("@Diseno", ddlDisenoRiego.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Agua_con_sedimentos_sucio_pesada", ddlAguaSedimentos.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Otro_tipo_riego", txtOtroRiego.Text)
                cmd.Parameters.AddWithValue("@Recomendacion_tecnica_9", txtRecomendacionRiego.Text)

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class