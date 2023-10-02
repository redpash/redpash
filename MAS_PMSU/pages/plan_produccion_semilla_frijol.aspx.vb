Imports MySql.Data.MySqlClient

Public Class plan_produccion_semilla_frijol
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub lb_Amadeus_Comercial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_Amadeus_Comercial.SelectedIndexChanged

        If lb_Amadeus_Comercial.SelectedValue = "SI" Then
            txt_In_Comercial_Amadeus.Enabled = True
        End If

        If lb_Amadeus_Certificado.Text = "SI" Then
            txt_In_Certificado_Amadeus.Enabled = True
        End If

    End Sub

    Protected Sub btn_si_nuevo_Click(sender As Object, e As EventArgs) Handles btn_si_nuevo.Click

        Response.Write("<script>alert('Este es un mensaje de alerta en ASP');</script>")

        Dim conex As New MySqlConnection(conn)
        Dim Sql As String

        conex.Open()
        Dim cmd2 As New MySqlCommand()

        'Sql = "INSERT INTO `producción_semilla_frijol` (Ciclo_Siembra,Certificada_Quintales,Comercial_Quintales,Amadeus_77,Carrizalito,Deorho,Azabache,Parasito_mejorado_PM_2,Honduras_nutritivo,Inta_Cardenas,Lenca_Precoz,Rojo_chorti,Tolupan_rojo,Otra_Variedad,Certificada_Amadeus_77,Comercial_Amadeus_77,Certificada_Carrizalito,Comercial_Carrizalito,Certificada_Deorho,Comercial_Deorho,Certificada_Azabache,Comercial_Azabache,Certificado_Parasito_mejorado_PM_2,Comercial_Parasito_mejorado_PM_2,Certificado_Honduras_nutritivo,Comercial_Honduras_nutritivo,Certificado_Inta_Cartenas,Comercial_Inta_Cártenas,Certificado_Lenca_precoz,Comercial_Lenca_precoz,Certificado_Rojo_chorti,Comercial_Rojo_chorti,Certificado_Tolupan_rojo,Comercial_Tolupan_rojo,Certificado_Otra_variedad,Comercial_Otra_variedad,Amadeus_Cantidad_Certificada,Amadeus_Cantidad_Comercial,Amadeus_Detalle_Certificada,Amadeus_Detalle_Comercial,Carrizalito_Cantidad_Certificada,Carrizalito_Cantidad_Comercial,Carrizalito_Detalle_Certificada,Carrizalito_Detalle_Comercial,Deorho_Cantidad_Certificada,Deorho_Cantidad_Comercial,Deorho_Detalle_Certificada,Deorho_Detalle_Comercial,Azabache_Cantidad_Certificada,Azabache_Cantidad_Comercial,Azabache_Detalle_Certificada,Azabache_Detalle_Comercial,Paraisito_Cantidad_Certificada,Paraisito_Cantidad_Comercial,Paraisito_Detalle_Certificada,Paraisito_Detalle_Comercial,Honduras_Nutritiva_Cantidad_Certificada,Honduras_Nutritiva_Cantidad_Comercial,Honduras_Nutritiva_Detalle_Certificada,Honduras_Nutritiva_Detalle_Comercial,Inta_Cardenas_Cantidad_Certificada,Inta_Cardenas_Cantidad_Comercial,Inta_Cardenas_Detalle_Certificada,Inta_Cardenas_Detalle_Comercial,Lenca_Precoz_Cantidad_Certificada,Lenca_Precoz_Cantidad_Comercial,Lenca_Precoz_Detalle_Certificada,Lenca_Precoz_Detalle_Comercial,Rojo_Chorti_Cantidad_Certificada,Rojo_Chorti_Cantidad_Comercial,Rojo_Chorti_Detalle_Certificada,Rojo_Chorti_Detalle_Comercial,Tolupan_Rojo_Cantidad_Certificada,Tolupan_Rojo_Cantidad_Comercial,Tolupan_Rojo_Detalle_Certificada,Tolupan_Rojo_Detalle_Comercial,Otra_Variedad_Cantidad_Certificada,Otra_Variedad_Cantidad_Comercial,Otra_Variedad_Detalle_Certificada,Otra_Variedad_Detalle_Comercial) VALUES (,@Ciclo_Siembra,@Certificada_Quintales,@Comercial_Quintales,@Amadeus_77,@Carrizalito,@Deorho,@Azabache,@Parasito_mejorado_PM_2,@Honduras_nutritivo,@Inta_Cardenas,@Lenca_Precoz,@Rojo_chorti,@Tolupan_rojo,@Otra_Variedad,@Certificada_Amadeus_77,@Comercial_Amadeus_77,@Certificada_Carrizalito,@Comercial_Carrizalito,@Certificada_Deorho,@Comercial_Deorho,@Certificada_Azabache,@Comercial_Azabache,@Certificado_Parasito_mejorado_PM_2,@Comercial_Parasito_mejorado_PM_2,@Certificado_Honduras_nutritivo,@Comercial_Honduras_nutritivo,@Certificado_Inta_Cartenas,@Comercial_Inta_Cártenas,@Certificado_Lenca_precoz,@Comercial_Lenca_precoz,@Certificado_Rojo_chorti,@Comercial_Rojo_chorti,@Certificado_Tolupan_rojo,@Comercial_Tolupan_rojo,@Certificado_Otra_variedad,@Comercial_Otra_variedad,@Amadeus_Cantidad_Certificada,@Amadeus_Cantidad_Comercial,@Amadeus_Detalle_Certificada,@Amadeus_Detalle_Comercial,@Carrizalito_Cantidad_Certificada,@Carrizalito_Cantidad_Comercial,@Carrizalito_Detalle_Certificada,@Carrizalito_Detalle_Comercial,@Deorho_Cantidad_Certificada,@Deorho_Cantidad_Comercial,@Deorho_Detalle_Certificada,@Deorho_Detalle_Comercial,@Azabache_Cantidad_Certificada,@Azabache_Cantidad_Comercial,@Azabache_Detalle_Certificada,@Azabache_Detalle_Comercial,@Paraisito_Cantidad_Certificada,@Paraisito_Cantidad_Comercial,@Paraisito_Detalle_Certificada,@Paraisito_Detalle_Comercial,@Honduras_Nutritiva_Cantidad_Certificada,@Honduras_Nutritiva_Cantidad_Comercial,@Honduras_Nutritiva_Detalle_Certificada,@Honduras_Nutritiva_Detalle_Comercial,@Inta_Cardenas_Cantidad_Certificada,@Inta_Cardenas_Cantidad_Comercial,@Inta_Cardenas_Detalle_Certificada,@Inta_Cardenas_Detalle_Comercial,@Lenca_Precoz_Cantidad_Certificada,@Lenca_Precoz_Cantidad_Comercial,@Lenca_Precoz_Detalle_Certificada,@Lenca_Precoz_Detalle_Comercial,@Rojo_Chorti_Cantidad_Certificada,@Rojo_Chorti_Cantidad_Comercial,@Rojo_Chorti_Detalle_Certificada,Rojo_Chorti_Detalle_Comercial,@Tolupan_Rojo_Cantidad_Certificada,@Tolupan_Rojo_Cantidad_Comercial,@Tolupan_Rojo_Detalle_Certificada,@Tolupan_Rojo_Detalle_Comercial,@Otra_Variedad_Cantidad_Certificada,@Otra_Variedad_Cantidad_Comercial,@Otra_Variedad_Detalle_Certificada@Otra_Variedad_Detalle_Comercial) "

        Sql = "INSERT INTO `producción_semilla_frijol` (Ciclo_Siembra,Certificada_Quintales, Comercial_Quintales,Amadeus_77,Carrizalito,Deorho,Azabache,Parasito_mejorado_PM_2,Honduras_nutritivo,Inta_Cardenas,Lenca_Precoz,Rojo_chorti,Tolupan_rojo,Otra_Variedad,Certificada_Amadeus_77,Comercial_Amadeus_77,Certificada_Carrizalito,Comercial_Carrizalito,Certificada_Deorho,Comercial_Deorho,Certificada_Azabache,Comercial_Azabache,Certificado_Parasito_mejorado_PM_2,Comercial_Parasito_mejorado_PM_2,Certificado_Honduras_nutritivo,Comercial_Honduras_nutritivo,Certificado_Inta_Cartenas,Comercial_Inta_Cártenas,Certificado_Lenca_precoz,Comercial_Lenca_precoz,Certificado_Rojo_chorti,Comercial_Rojo_chorti,Certificado_Tolupan_rojo,Comercial_Tolupan_rojo,Certificado_Otra_variedad,Comercial_Otra_variedad,Amadeus_Cantidad_Certificada,Amadeus_Cantidad_Comercial,Amadeus_Detalle_Certificada,Amadeus_Detalle_Comercial,Carrizalito_Cantidad_Certificada,Carrizalito_Cantidad_Comercial,Carrizalito_Detalle_Certificada,Carrizalito_Detalle_Comercial,Deorho_Cantidad_Certificada,Deorho_Cantidad_Comercial,Deorho_Detalle_Certificada,Deorho_Detalle_Comercial,Azabache_Cantidad_Certificada,Azabache_Cantidad_Comercial,Azabache_Detalle_Certificada,Azabache_Detalle_Comercial,Paraisito_Cantidad_Certificada,Paraisito_Cantidad_Comercial,Paraisito_Detalle_Certificada,Paraisito_Detalle_Comercial,Honduras_Nutritiva_Cantidad_Certificada,Honduras_Nutritiva_Cantidad_Comercial,Honduras_Nutritiva_Detalle_Certificada,Honduras_Nutritiva_Detalle_Comercial,Inta_Cardenas_Cantidad_Certificada,Inta_Cardenas_Cantidad_Comercial,Inta_Cardenas_Detalle_Certificada,Inta_Cardenas_Detalle_Comercial,Lenca_Precoz_Cantidad_Certificada,Lenca_Precoz_Cantidad_Comercial,Lenca_Precoz_Detalle_Certificada,Lenca_Precoz_Detalle_Comercial,Rojo_Chorti_Cantidad_Certificada,Rojo_Chorti_Cantidad_Comercial,Rojo_Chorti_Detalle_Certificada,Rojo_Chorti_Detalle_Comercial,Tolupan_Rojo_Cantidad_Certificada,Tolupan_Rojo_Cantidad_Comercial,Tolupan_Rojo_Detalle_Certificada,Tolupan_Rojo_Detalle_Comercial,Otra_Variedad_Cantidad_Certificada,Otra_Variedad_Cantidad_Comercial,Otra_Variedad_Detalle_Certificada,Otra_Variedad_Detalle_Comercial) values(@Ciclo_Siembra,@Certificada_Quintales,@Comercial_Quintales,@Amadeus_77,@Carrizalito,@Deorho,@Azabache,@Parasito_mejorado_PM_2,@Honduras_nutritivo,@Inta_Cardenas,@Lenca_Precoz,@Rojo_chorti,@Tolupan_rojo,@Otra_Variedad,@Certificada_Amadeus_77,@Comercial_Amadeus_77,@Certificada_Carrizalito,@Comercial_Carrizalito,@Certificada_Deorho,@Comercial_Deorho,@Certificada_Azabache,@Comercial_Azabache,@Certificado_Parasito_mejorado_PM_2,@Comercial_Parasito_mejorado_PM_2,@Certificado_Honduras_nutritivo,@Comercial_Honduras_nutritivo,@Certificado_Inta_Cartenas,@Comercial_Inta_Cártenas,@Certificado_Lenca_precoz,@Comercial_Lenca_precoz,@Certificado_Rojo_chorti,@Comercial_Rojo_chorti,@Certificado_Tolupan_rojo,@Comercial_Tolupan_rojo,@Certificado_Otra_variedad,@Comercial_Otra_variedad,@Amadeus_Cantidad_Certificada,@Amadeus_Cantidad_Comercial,@Amadeus_Detalle_Certificada,@Amadeus_Detalle_Comercial,@Carrizalito_Cantidad_Certificada,@Carrizalito_Cantidad_Comercial,@Carrizalito_Detalle_Certificada,@Carrizalito_Detalle_Comercial,@Deorho_Cantidad_Certificada,@Deorho_Cantidad_Comercial,@Deorho_Detalle_Certificada,@Deorho_Detalle_Comercial,@Azabache_Cantidad_Certificada,@Azabache_Cantidad_Comercial,@Azabache_Detalle_Certificada,@Azabache_Detalle_Comercial,@Paraisito_Cantidad_Certificada,@Paraisito_Cantidad_Comercial,@Paraisito_Detalle_Certificada,@Paraisito_Detalle_Comercial,@Honduras_Nutritiva_Cantidad_Certificada,@Honduras_Nutritiva_Cantidad_Comercial,@Honduras_Nutritiva_Detalle_Certificada,@Honduras_Nutritiva_Detalle_Comercial,@Inta_Cardenas_Cantidad_Certificada,@Inta_Cardenas_Cantidad_Comercial,@Inta_Cardenas_Detalle_Certificada,@Inta_Cardenas_Detalle_Comercial,@Lenca_Precoz_Cantidad_Certificada,@Lenca_Precoz_Cantidad_Comercial,@Lenca_Precoz_Detalle_Certificada,@Lenca_Precoz_Detalle_Comercial,@Rojo_Chorti_Cantidad_Certificada,@Rojo_Chorti_Cantidad_Comercial,@Rojo_Chorti_Detalle_Certificada,@Rojo_Chorti_Detalle_Comercial,@Tolupan_Rojo_Cantidad_Certificada,@Tolupan_Rojo_Cantidad_Comercial,@Tolupan_Rojo_Detalle_Certificada,@Tolupan_Rojo_Detalle_Comercial,@Otra_Variedad_Cantidad_Certificada,@Otra_Variedad_Cantidad_Comercial,@Otra_Variedad_Detalle_Certificada,@Otra_Variedad_Detalle_Comercial)"

        cmd2.Connection = conex
        cmd2.CommandText = Sql
        cmd2.Parameters.AddWithValue("@Ciclo_Siembra", Text_Ciclo_new.Text)
        cmd2.Parameters.AddWithValue("@Certificada_Quintales", TextBox_quintales.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Quintales", txt_Comercial_Quintales.Text)
        cmd2.Parameters.AddWithValue("@Amadeus_77", lb_Amadeus.Text)
        cmd2.Parameters.AddWithValue("@Carrizalito", lb_Carrizalito.Text)
        cmd2.Parameters.AddWithValue("@Deorho", lb_Deorho.Text)
        cmd2.Parameters.AddWithValue("@Azabache", lb_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Parasito_mejorado_PM_2", lb_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Honduras_nutritivo", lb_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Inta_Cardenas", lb_Inta.Text)
        cmd2.Parameters.AddWithValue("@Lenca_Precoz", lb_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Rojo_chorti", lb_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Tolupan_rojo", lb_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Otra_Variedad", lb_Otra.Text)
        cmd2.Parameters.AddWithValue("@Certificada_Amadeus_77", lb_Amadeus_Certificado.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Amadeus_77", lb_Amadeus_Comercial.Text)
        cmd2.Parameters.AddWithValue("@Certificada_Carrizalito", lb_Certificado_Carrizalito.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Carrizalito", lb_Comercial_Carrizalito.Text)
        cmd2.Parameters.AddWithValue("@Certificada_Deorho", lb_Certificado_Deohoro.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Deorho", lb_Comercial_Deohoro.Text)
        cmd2.Parameters.AddWithValue("@Certificada_Azabache", lb_Certificado_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Azabache", lb_Comercial_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Parasito_mejorado_PM_2", lb_Certificado_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Parasito_mejorado_PM_2", lb_Comercial_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Honduras_nutritivo", lb_Certificado_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Honduras_nutritivo", lb_Comercial_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Inta_Cartenas", lb_Certificado_Inta.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Inta_Cártenas", lb_Comercial_Inta.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Lenca_precoz", lb_Certificado_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Lenca_precoz", lb_Comercial_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Rojo_chorti", lb_Certificado_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Rojo_chorti", lb_Comercial_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Tolupan_rojo", lb_Certificado_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Tolupan_rojo", lb_Comercial_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Certificado_Otra_variedad", lb_Certificado_Otra.Text)
        cmd2.Parameters.AddWithValue("@Comercial_Otra_variedad", lb_Comercial_Otra.Text)
        cmd2.Parameters.AddWithValue("@Amadeus_Cantidad_Certificada", txt_In_Certificado_Amadeus.Text)
        cmd2.Parameters.AddWithValue("@Amadeus_Cantidad_Comercial", txt_In_Comercial_Amadeus.Text)
        cmd2.Parameters.AddWithValue("@Amadeus_Detalle_Certificada", txt_Re_Certificado_Amadeus.Text)
        cmd2.Parameters.AddWithValue("@Amadeus_Detalle_Comercial", txt_Re_Comercial_Amadeus.Text)
        cmd2.Parameters.AddWithValue("@Carrizalito_Cantidad_Certificada", txt_In_Certificado_Carrtizalito.Text)
        cmd2.Parameters.AddWithValue("@Carrizalito_Cantidad_Comercial", txt_In_Comercial_Carrtizalito.Text)
        cmd2.Parameters.AddWithValue("@Carrizalito_Detalle_Certificada", txt_re_Certificado_Carrizalito.Text)
        cmd2.Parameters.AddWithValue("@Carrizalito_Detalle_Comercial", txt_re_Comercial_Carrizalito.Text)
        cmd2.Parameters.AddWithValue("@Deorho_Cantidad_Certificada", txt_Ce_Deorho.Text)
        cmd2.Parameters.AddWithValue("@Deorho_Cantidad_Comercial", txt_Co_Deorho.Text)
        cmd2.Parameters.AddWithValue("@Deorho_Detalle_Certificada", txt_Re_Ce_Deorho.Text)
        cmd2.Parameters.AddWithValue("@Deorho_Detalle_Comercial", txt_Re_Co_Deorho.Text)
        cmd2.Parameters.AddWithValue("@Azabache_Cantidad_Certificada", txt_In_Certificado_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Azabache_Cantidad_Comercial", txt_In_Comercial_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Azabache_Detalle_Certificada", txt_Re_Certificado_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Azabache_Detalle_Comercial", txt_Re_Comercial_Azabache.Text)
        cmd2.Parameters.AddWithValue("@Paraisito_Cantidad_Certificada", txt_Ex_Certificado_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Paraisito_Cantidad_Comercial", txt_Ex_Comercial_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Paraisito_Detalle_Certificada", txt_Re_Certificado_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Paraisito_Detalle_Comercial", txt_Re_Comercial_Paraisito.Text)
        cmd2.Parameters.AddWithValue("@Honduras_Nutritiva_Cantidad_Certificada", txt_In_Certificado_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Honduras_Nutritiva_Cantidad_Comercial", txt_In_Comercial_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Honduras_Nutritiva_Detalle_Certificada", txt_Re_Certificado_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Honduras_Nutritiva_Detalle_Comercial", txt_Re_Comercial_Honduras.Text)
        cmd2.Parameters.AddWithValue("@Inta_Cardenas_Cantidad_Certificada", txt_In_Certificado_Inta.Text)
        cmd2.Parameters.AddWithValue("@Inta_Cardenas_Cantidad_Comercial", txt_In_Comercial_Inta.Text)
        cmd2.Parameters.AddWithValue("@Inta_Cardenas_Detalle_Certificada", txt_Re_Certificado_Inta.Text)
        cmd2.Parameters.AddWithValue("@Inta_Cardenas_Detalle_Comercial", txt_Re_Comercial_Inta.Text)
        cmd2.Parameters.AddWithValue("@Lenca_Precoz_Cantidad_Certificada", lb_In_Certificado_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Lenca_Precoz_Cantidad_Comercial", lb_In_Comercial_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Lenca_Precoz_Detalle_Certificada", txt_Re_Certificado_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Lenca_Precoz_Detalle_Comercial", txt_Re_Comercial_Lenca.Text)
        cmd2.Parameters.AddWithValue("@Rojo_Chorti_Cantidad_Certificada", lb_In_Certificado_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Rojo_Chorti_Cantidad_Comercial", lb_In_Comercial_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Rojo_Chorti_Detalle_Certificada", txt_Re_Certificado_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Rojo_Chorti_Detalle_Comercial", txt_Re_Comercial_Rojo.Text)
        cmd2.Parameters.AddWithValue("@Tolupan_Rojo_Cantidad_Certificada", txt_In_Certificado_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Tolupan_Rojo_Cantidad_Comercial", txt_In_Comercial_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Tolupan_Rojo_Detalle_Certificada", txt_Re_Certificado_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Tolupan_Rojo_Detalle_Comercial", txt_Re_Comercial_Tolupan.Text)
        cmd2.Parameters.AddWithValue("@Otra_Variedad_Cantidad_Certificada", txt_In_Certificado_Otra.Text)
        cmd2.Parameters.AddWithValue("@Otra_Variedad_Cantidad_Comercial", lb_In_Comercial_Otra.Text)
        cmd2.Parameters.AddWithValue("@Otra_Variedad_Detalle_Certificada", txt_Re_Certificado_Otra.Text)
        cmd2.Parameters.AddWithValue("@Otra_Variedad_Detalle_Comercial", txt_Re_Comercial_Otra.Text)
        cmd2.ExecuteNonQuery()
        conex.Close()

        Response.Redirect(String.Format("~/pages/plan_produccion_semilla_frijol.aspx"))

        'Response.Write("<script>alert('Este es un mensaje de alerta en ASP');</script>")
        '    Response.Write(ex)

    End Sub

End Class