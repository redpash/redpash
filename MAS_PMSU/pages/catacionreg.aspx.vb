Imports MySql.Data.MySqlClient
Public Class catacionreg
    Inherits System.Web.UI.Page

    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'TxtCatacion.SelectedIndex = 1
        If (Not IsPostBack) Then
            If (Request.QueryString("edit") = 1) Then
                Dim Str As String = "SELECT * FROM `mas+cataciones` WHERE  id='" & Request.QueryString("id") & "' "
                Dim adap As New MySqlDataAdapter(Str, conn2)
                Dim dt As New DataTable
                adap.Fill(dt)

                Dim fecha2 As Date

                TxtTipo.Text = dt.Rows(0)("Tipo").ToString()
                TxtCorrelativo.Text = dt.Rows(0)("Correlativo").ToString()
                TxtCodOP.Text = dt.Rows(0)("COD_ORGANIZACION").ToString()
                TxtCodProd.Text = dt.Rows(0)("COD_PRODUCTOR").ToString()
                TxtNombreOP.Text = dt.Rows(0)("OP_NOMBRE").ToString()
                TxtNombreProd.Text = dt.Rows(0)("NOMBRE").ToString()

                fecha2 = dt.Rows(0)("Fecha").ToString()
                TxtDia.SelectedValue = fecha2.Day
                TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno.SelectedValue = fecha2.Year

                TxtMuestra.SelectedValue = dt.Rows(0)("Muestra").ToString()
                TxtExportador.SelectedValue = dt.Rows(0)("Exportador").ToString()
                TxtVariedad.SelectedValue = dt.Rows(0)("Variedad").ToString()
                TxtAltitud.Text = dt.Rows(0)("Altitud").ToString()
                TxtRendimiento.Text = dt.Rows(0)("Rendimiento").ToString()
                TxtDano.Text = dt.Rows(0)("Dano").ToString()
                TxtHumedad.Text = dt.Rows(0)("Humedad").ToString()
                TxtCatacion.SelectedValue = dt.Rows(0)("Catacion").ToString()
                TxtObservacion.Text = dt.Rows(0)("Observacion").ToString()


                TxtApariencia.SelectedValue = dt.Rows(0)("Apariencia").ToString()
                TxtFragancia.SelectedValue = dt.Rows(0)("Fragancia").ToString()
                TxtAroma.SelectedValue = dt.Rows(0)("Aroma").ToString()
                TxtAcidez.SelectedValue = dt.Rows(0)("Acidez").ToString()
                TxtCuerpo.SelectedValue = dt.Rows(0)("Cuerpo").ToString()
                TxtSabor.SelectedValue = dt.Rows(0)("Sabor").ToString()
                TxtNota.Text = dt.Rows(0)("Nota").ToString()
                TxtCalidad.SelectedValue = dt.Rows(0)("Calidad").ToString()
                TxtFormato.SelectedValue = dt.Rows(0)("Formato").ToString()
                TxtQQPS.Text = dt.Rows(0)("QQPS").ToString()

                If (TxtTipo.Text = "Organizacion_productores") Then
                    divp.Visible = False
                    divp2.Visible = False
                Else
                    divp.Visible = True
                    divp2.Visible = True
                End If

            Else

                TxtCodOP.Text = Request.QueryString("val")
                TxtNombreOP.Text = Request.QueryString("val2")
                TxtTipo.Text = Request.QueryString("val3")

                TxtAltitud.Text = 0
                TxtDano.Text = 0
                TxtHumedad.Text = 0
                TxtNota.Text = 0
                TxtQQPS.Text = 0

                If (TxtTipo.Text = "Organizacion_productores") Then
                    divp.Visible = False
                    divp2.Visible = False
                Else
                    divp.Visible = True
                    divp2.Visible = True
                End If
            End If
        End If

    End Sub
    Sub llenagrid2()
        Me.SqlDataSource2.SelectCommand = "SELECT COD_PRODUCTOR,NOMBRE,SEXO,EDAD " +
       " FROM `mas+registro_productores2` WHERE COD_ORGANIZACION='" & TxtCodOP.Text & "' ORDER BY NOMBRE "

        GridDatos2.DataBind()
    End Sub
    Protected Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", True)

        llenagrid2()
    End Sub

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click


        For Each row As GridViewRow In GridDatos2.Rows
            Dim check As CheckBox = TryCast(row.FindControl("chkSeleccionar"), CheckBox)

            If check.Checked Then
                TxtCodProd.Text = HttpUtility.HtmlDecode(row.Cells(1).Text)
                TxtNombreProd.Text = HttpUtility.HtmlDecode(row.Cells(2).Text)

            End If
        Next

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#ProdModal').modal('show'); });", False)

    End Sub
    Protected Sub GuardarD_Click(sender As Object, e As EventArgs) Handles GuardarD.Click
        Dim conex As New MySqlConnection(conn2)
        Dim Sql As String

        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno.SelectedValue.ToString

        conex.Open()

        Dim cmd As New MySqlCommand()

        If (Request.QueryString("edit") = 1) Then
            Sql = "UPDATE cataciones SET Tipo = @Tipo,	COD_ORGANIZACION = @COD_ORGANIZACION,	COD_PRODUCTOR = @COD_PRODUCTOR,	Correlativo = @Correlativo,	Fecha = @Fecha,	Muestra = @Muestra, Exportador=@Exportador,	Variedad = @Variedad,	Altitud = @Altitud,	Rendimiento = @Rendimiento,	Dano = @Dano,	Humedad = @Humedad,	Catacion = @Catacion,	Observacion = @Observacion,	Apariencia = @Apariencia,	Fragancia = @Fragancia,	Aroma = @Aroma,	Acidez = @Acidez,	Cuerpo = @Cuerpo,	Sabor = @Sabor,	Nota = @Nota,	Calidad = @Calidad,	Formato = @Formato, QQPS = @QQPS" +
            " WHERE id='" & Request.QueryString("id") & "' "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Tipo", TxtTipo.Text)
            cmd.Parameters.AddWithValue("@Correlativo", TxtCorrelativo.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)
            cmd.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodProd.Text)
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Muestra", TxtMuestra.SelectedValue)
            cmd.Parameters.AddWithValue("@Variedad", TxtVariedad.SelectedValue)
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Altitud", TxtAltitud.Text)
            cmd.Parameters.AddWithValue("@Rendimiento", TxtRendimiento.Text)
            cmd.Parameters.AddWithValue("@Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Humedad", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Catacion", TxtCatacion.SelectedValue)
            cmd.Parameters.AddWithValue("@Observacion", TxtObservacion.Text)

            If (TxtCatacion.SelectedItem.ToString = "Si") Then
                cmd.Parameters.AddWithValue("@Apariencia", TxtApariencia.SelectedValue)
                cmd.Parameters.AddWithValue("@Fragancia", TxtFragancia.SelectedValue)
                cmd.Parameters.AddWithValue("@Aroma", TxtAroma.SelectedValue)
                cmd.Parameters.AddWithValue("@Acidez", TxtAcidez.SelectedValue)
                cmd.Parameters.AddWithValue("@Cuerpo", TxtCuerpo.SelectedValue)
                cmd.Parameters.AddWithValue("@Sabor", TxtSabor.SelectedValue)
                cmd.Parameters.AddWithValue("@Nota", TxtNota.Text)
                cmd.Parameters.AddWithValue("@Calidad", TxtCalidad.SelectedValue)
                cmd.Parameters.AddWithValue("@Formato", TxtFormato.SelectedValue)
                cmd.Parameters.AddWithValue("@QQPS", TxtQQPS.Text)
            Else
                cmd.Parameters.AddWithValue("@Apariencia", "")
                cmd.Parameters.AddWithValue("@Fragancia", "")
                cmd.Parameters.AddWithValue("@Aroma", "")
                cmd.Parameters.AddWithValue("@Acidez", "")
                cmd.Parameters.AddWithValue("@Cuerpo", "")
                cmd.Parameters.AddWithValue("@Sabor", "")
                cmd.Parameters.AddWithValue("@Nota", 0)
                cmd.Parameters.AddWithValue("@Calidad", "")
                cmd.Parameters.AddWithValue("@Formato", "")
                cmd.Parameters.AddWithValue("@QQPS", 0)
            End If

        Else
            Sql = "INSERT INTO cataciones (Tipo,COD_ORGANIZACION,COD_PRODUCTOR,Correlativo,Fecha,Muestra,Exportador,Variedad,Altitud,Rendimiento,Dano,Humedad,Catacion,Observacion,Apariencia,Fragancia,Aroma,Acidez,Cuerpo,Sabor,Nota,Calidad,Formato,QQPS)" +
            " VALUES (@Tipo,@COD_ORGANIZACION,@COD_PRODUCTOR,@Correlativo,@Fecha,@Muestra,@Exportador,@Variedad,@Altitud,@Rendimiento,@Dano,@Humedad,@Catacion,@Observacion,@Apariencia,@Fragancia,@Aroma,@Acidez,@Cuerpo,@Sabor,@Nota,@Calidad,@Formato,@QQPS) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Tipo", TxtTipo.Text)
            cmd.Parameters.AddWithValue("@Correlativo", TxtCorrelativo.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)
            cmd.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodProd.Text)
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Muestra", TxtMuestra.SelectedValue)
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Variedad", TxtVariedad.SelectedValue)
            cmd.Parameters.AddWithValue("@Altitud", TxtAltitud.Text)
            cmd.Parameters.AddWithValue("@Rendimiento", TxtRendimiento.Text)
            cmd.Parameters.AddWithValue("@Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Humedad", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Catacion", TxtCatacion.SelectedValue)
            cmd.Parameters.AddWithValue("@Observacion", TxtObservacion.Text)

            If (TxtCatacion.SelectedItem.ToString = "Si") Then
                cmd.Parameters.AddWithValue("@Apariencia", TxtApariencia.SelectedValue)
                cmd.Parameters.AddWithValue("@Fragancia", TxtFragancia.SelectedValue)
                cmd.Parameters.AddWithValue("@Aroma", TxtAroma.SelectedValue)
                cmd.Parameters.AddWithValue("@Acidez", TxtAcidez.SelectedValue)
                cmd.Parameters.AddWithValue("@Cuerpo", TxtCuerpo.SelectedValue)
                cmd.Parameters.AddWithValue("@Sabor", TxtSabor.SelectedValue)
                cmd.Parameters.AddWithValue("@Nota", TxtNota.Text)
                cmd.Parameters.AddWithValue("@Calidad", TxtCalidad.SelectedValue)
                cmd.Parameters.AddWithValue("@Formato", TxtFormato.SelectedValue)
                cmd.Parameters.AddWithValue("@QQPS", TxtQQPS.Text)
            Else
                cmd.Parameters.AddWithValue("@Apariencia", "")
                cmd.Parameters.AddWithValue("@Fragancia", "")
                cmd.Parameters.AddWithValue("@Aroma", "")
                cmd.Parameters.AddWithValue("@Acidez", "")
                cmd.Parameters.AddWithValue("@Cuerpo", "")
                cmd.Parameters.AddWithValue("@Sabor", "")
                cmd.Parameters.AddWithValue("@Nota", 0)
                cmd.Parameters.AddWithValue("@Calidad", "")
                cmd.Parameters.AddWithValue("@Formato", "")
                cmd.Parameters.AddWithValue("@QQPS", 0)
            End If

        End If

        cmd.ExecuteNonQuery()

        conex.Close()

        Label1.Text = "Los datos han sido guardados"



        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub
    Protected Sub TxtCatacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtCatacion.SelectedIndexChanged

        If (TxtCatacion.SelectedItem.ToString = "Si") Then
            diva.Visible = True

            TxtApariencia.SelectedIndex = 0
            TxtAromaSelectedIndex = 0
            TxtAcidez.SelectedIndex = 0
            TxtCuerpo.SelectedIndex = 0
            TxtSabor.SelectedIndex = 0
            TxtNota.Text = 0
            TxtCalidad.SelectedIndex = 0
            TxtFormato.SelectedIndex = 0
            TxtQQPS.Text = 0
        Else
            diva.Visible = False

            TxtNota.Text = 0
            TxtQQPS.Text = 0
        End If
    End Sub

    Protected Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        Response.Redirect(String.Format("~/pages/catacionesres.aspx?org=" + TxtCodOP.Text + "&dir=1"))
    End Sub

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Response.Redirect(String.Format("~/pages/catacionesres.aspx?org=" + TxtCodOP.Text + "&dir=1"))
    End Sub
End Class