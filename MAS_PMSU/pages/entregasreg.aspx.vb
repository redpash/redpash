Imports MySql.Data.MySqlClient
Public Class entregasreg
    Inherits System.Web.UI.Page

    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                If (Not IsPostBack) Then
                    divtip.Visible = False
                    divprecal.Visible = False
                    divpretrans.Visible = False

                    If (Request.QueryString("edit") = 1) Then
                        Dim Str As String = "SELECT * FROM `mas+cafe_entregas_fortalecidas` WHERE  id='" & Request.QueryString("id") & "' "
                        Dim adap As New MySqlDataAdapter(Str, conn2)
                        Dim dt As New DataTable
                        adap.Fill(dt)

                        Dim fecha2 As Date

                        TxtCodOP.Text = dt.Rows(0)("COD_ORGANIZACION").ToString()
                        TxtNombreOP.Text = dt.Rows(0)("OP_NOMBRE").ToString()
                        fecha2 = dt.Rows(0)("Fecha").ToString()
                        TxtDia.SelectedValue = fecha2.Day
                        TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                        TxtAno.SelectedValue = fecha2.Year

                        TxtNotaPeso.Text = dt.Rows(0)("NotaPeso").ToString()
                        TxtExportador.SelectedValue = dt.Rows(0)("Exportador").ToString()
                        TxtEntrega.Text = dt.Rows(0)("Entrega").ToString()
                        TxtPeso.Text = dt.Rows(0)("Peso").ToString()
                        TxtDano.Text = dt.Rows(0)("Por_Dano").ToString()
                        TxtHumedad.Text = dt.Rows(0)("Por_Hum").ToString()
                        TxtDescDano.Text = dt.Rows(0)("Desc_dano").ToString()
                        TxtDescHumedad.Text = dt.Rows(0)("Desc_hum").ToString()
                        TxtPesoFinal.Text = dt.Rows(0)("Peso_Final").ToString()
                        TxtPreciobase.Text = dt.Rows(0)("Precio_Base").ToString()
                        TxtPreciocalidad.Text = dt.Rows(0)("Precio_Calidad").ToString()
                        TxtPrecioflete.Text = dt.Rows(0)("Precio_Flete").ToString()
                        TxtPrecioPlaza.Text = dt.Rows(0)("Precio_Plaza").ToString()
                        TxtLiqExport.Text = dt.Rows(0)("Liq_Exp").ToString()
                        TxtLiqPlaza.Text = dt.Rows(0)("Liq_Plaza").ToString()
                        TxtLiqDif.Text = dt.Rows(0)("Liq_Dif").ToString()

                    Else

                        TxtCodOP.Text = Request.QueryString("val")
                        TxtNombreOP.Text = Request.QueryString("val2")

                        TxtPeso.Text = 0
                        TxtHumedad.Text = 0
                        TxtDano.Text = 0
                        TxtPreciobase.Text = 0
                        TxtPreciocalidad.Text = 0
                        TxtPrecioflete.Text = 0
                        TxtPrecioPlaza.Text = 0

                    End If
                End If

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If


    End Sub


    Protected Sub GuardarD_Click(sender As Object, e As EventArgs) Handles GuardarD.Click
        Dim desc_hum, desc_dan, pesofinal, precioexp, liqexp, liqplaza, dif As Decimal

        desc_hum = (Convert.ToDecimal(TxtHumedad.Text) / 100) * Convert.ToDecimal(TxtPeso.Text)
        desc_dan = (Convert.ToDecimal(TxtDano.Text) / 100) * Convert.ToDecimal(TxtPeso.Text)

        pesofinal = Convert.ToDecimal(TxtPeso.Text) - desc_hum - desc_dan

        precioexp = Convert.ToDecimal(TxtPreciobase.Text) + Convert.ToDecimal(TxtPreciocalidad.Text) + Convert.ToDecimal(TxtPrecioflete.Text)

        liqexp = pesofinal * precioexp

        liqplaza = ((pesofinal / 1.2) * 100 * Convert.ToDecimal(TxtPrecioPlaza.Text))

        dif = liqexp - liqplaza

        TxtDescDano.Text = Decimal.Round(desc_dan, 2)
        TxtDescHumedad.Text = Decimal.Round(desc_hum, 2)
        TxtPesoFinal.Text = Decimal.Round(pesofinal, 2)
        TxtLiqExport.Text = Decimal.Round(liqexp, 2)
        TxtLiqPlaza.Text = Decimal.Round(liqplaza, 2)
        TxtLiqDif.Text = Decimal.Round(dif, 2)

        Dim conex As New MySqlConnection(conn2)
        Dim Sql As String

        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno.SelectedValue.ToString

        conex.Open()

        Dim cmd As New MySqlCommand()

        If (Request.QueryString("edit") = 1) Then
            Sql = "UPDATE cafe_entregas_fortalecidas SET COD_ORGANIZACION= @COD_ORGANIZACION,Fecha= @Fecha,	NotaPeso= @NotaPeso,	Exportador= @Exportador,	Entrega= @Entrega,	Peso= @Peso,	Por_Dano= @Por_Dano,	Por_Hum= @Por_Hum,	Desc_dano= @Desc_dano,	Desc_hum= @Desc_hum,	Peso_Final= @Peso_Final,	Precio_Base= @Precio_Base,	Precio_Calidad= @Precio_Calidad,	Precio_Flete= @Precio_Flete,	Precio_Plaza= @Precio_Plaza,	Liq_Exp= @Liq_Exp,	Liq_Plaza= @Liq_Plaza, Liq_Dif=@Liq_Dif" +
            " WHERE id='" & Request.QueryString("id") & "' "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)

            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))

            cmd.Parameters.AddWithValue("@NotaPeso", TxtNotaPeso.Text)
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Entrega", TxtEntrega.Text)
            cmd.Parameters.AddWithValue("@Peso", TxtPeso.Text)
            cmd.Parameters.AddWithValue("@Por_Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Por_Hum", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Desc_dano", TxtDescDano.Text)
            cmd.Parameters.AddWithValue("@Desc_hum", TxtDescHumedad.Text)
            cmd.Parameters.AddWithValue("@Peso_Final", TxtPesoFinal.Text)
            cmd.Parameters.AddWithValue("@Precio_Base", TxtPreciobase.Text)
            cmd.Parameters.AddWithValue("@Precio_Calidad", TxtPreciocalidad.Text)
            cmd.Parameters.AddWithValue("@Precio_Flete", TxtPrecioflete.Text)
            cmd.Parameters.AddWithValue("@Precio_Plaza", TxtPrecioPlaza.Text)
            cmd.Parameters.AddWithValue("@Liq_Exp", TxtLiqExport.Text)
            cmd.Parameters.AddWithValue("@Liq_Plaza", TxtLiqPlaza.Text)
            cmd.Parameters.AddWithValue("@Liq_Dif", TxtLiqDif.Text)

        Else
            Sql = "INSERT INTO cafe_entregas_fortalecidas (COD_ORGANIZACION,Fecha,NotaPeso,Exportador,Entrega,Peso,Por_Dano,Por_Hum,Desc_dano,Desc_hum,Peso_Final,Precio_Base,Precio_Calidad,Precio_Flete,Precio_Plaza,Liq_Exp,Liq_Plaza,Liq_Dif)" +
            " VALUES (@COD_ORGANIZACION,@Fecha,@NotaPeso,@Exportador,@Entrega,@Peso,@Por_Dano,@Por_Hum,@Desc_dano,@Desc_hum,@Peso_Final,@Precio_Base,@Precio_Calidad,@Precio_Flete,@Precio_Plaza,@Liq_Exp,@Liq_Plaza,@Liq_Dif) "
            cmd.Connection = conex
            cmd.CommandText = Sql


            'cmd.Parameters.AddWithValue("@Correlativo", TxtCorrelativo.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)

            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))

            cmd.Parameters.AddWithValue("@NotaPeso", TxtNotaPeso.Text)
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Entrega", TxtEntrega.Text)
            cmd.Parameters.AddWithValue("@Peso", TxtPeso.Text)
            cmd.Parameters.AddWithValue("@Por_Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Por_Hum", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Desc_dano", TxtDescDano.Text)
            cmd.Parameters.AddWithValue("@Desc_hum", TxtDescHumedad.Text)
            cmd.Parameters.AddWithValue("@Peso_Final", TxtPesoFinal.Text)
            cmd.Parameters.AddWithValue("@Precio_Base", TxtPreciobase.Text)
            cmd.Parameters.AddWithValue("@Precio_Calidad", TxtPreciocalidad.Text)
            cmd.Parameters.AddWithValue("@Precio_Flete", TxtPrecioflete.Text)
            cmd.Parameters.AddWithValue("@Precio_Plaza", TxtPrecioPlaza.Text)
            cmd.Parameters.AddWithValue("@Liq_Exp", TxtLiqExport.Text)
            cmd.Parameters.AddWithValue("@Liq_Plaza", TxtLiqPlaza.Text)
            cmd.Parameters.AddWithValue("@Liq_Dif", TxtLiqDif.Text)

        End If

        cmd.ExecuteNonQuery()

        conex.Close()

        '
        Label1.Text = "Detalle de Liquidacion"
        Label2.Text = "Valor en lps. por la venta al exportador:" + liqexp.ToString
        Label3.Text = " Valor en lps. por la venta en plaza: " + liqplaza.ToString
        Label4.Text = " Diferencial en lps. por venta: " + dif.ToString



        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub
    Protected Sub TxtEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtEntrega.SelectedIndexChanged

        If (TxtEntrega.SelectedItem.ToString = "QQ_PH") Then
            divtip.Visible = False
            divhum.Visible = True
            divprecal.Visible = False
            divpretrans.Visible = False
        Else
            divtip.Visible = True
            divhum.Visible = False
            TxtHumedad.Text = 0
            divprecal.Visible = True
            divpretrans.Visible = True
        End If
    End Sub

    Protected Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        Response.Redirect(String.Format("~/pages/entregasres.aspx"))
    End Sub

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Response.Redirect(String.Format("~/pages/entregasres.aspx"))
    End Sub
End Class