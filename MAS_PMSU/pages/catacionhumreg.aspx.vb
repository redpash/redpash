Imports MySql.Data.MySqlClient
Public Class catacionhumreg
    Inherits System.Web.UI.Page

    Dim conn2 As String = ConfigurationManager.ConnectionStrings("TConnODK3").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If (Not IsPostBack) Then
            If (Request.QueryString("edit") = 1) Then
                Dim Str As String = "SELECT * FROM `mas+cataciones_humedo` WHERE  id='" & Request.QueryString("id") & "' "
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


                TxtExportador.SelectedValue = dt.Rows(0)("Exportador").ToString()
                TxtDano.Text = dt.Rows(0)("Dano").ToString()
                TxtHumedad.Text = dt.Rows(0)("Humedad").ToString()
                TxtApariencia.SelectedValue = dt.Rows(0)("Apariencia").ToString()
                TxtQQPS.Text = dt.Rows(0)("#_Sacos").ToString()

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


                TxtDano.Text = 0
                TxtHumedad.Text = 0
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
       " FROM `masp_productores` WHERE COD_ORGANIZACION='" & TxtCodOP.Text & "' ORDER BY NOMBRE "

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
            Sql = "UPDATE cataciones_humedo SET Tipo = @Tipo,	COD_ORGANIZACION = @COD_ORGANIZACION,	COD_PRODUCTOR = @COD_PRODUCTOR,	Correlativo = @Correlativo,	Fecha = @Fecha, Exportador=@Exportador,	Dano = @Dano,	Humedad = @Humedad,	Apariencia = @Apariencia, QQPS = @QQPS" +
            " WHERE id='" & Request.QueryString("id") & "' "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Tipo", TxtTipo.Text)
            cmd.Parameters.AddWithValue("@Correlativo", TxtCorrelativo.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)
            cmd.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodProd.Text)
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Humedad", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Apariencia", TxtApariencia.SelectedValue)
            cmd.Parameters.AddWithValue("@QQPS", TxtQQPS.Text)

        Else
            Sql = "INSERT INTO cataciones_humedo (Tipo,COD_ORGANIZACION,COD_PRODUCTOR,Correlativo,Fecha,Exportador,Dano,Humedad,Apariencia,QQPS)" +
            " VALUES (@Tipo,@COD_ORGANIZACION,@COD_PRODUCTOR,@Correlativo,@Fecha,@Exportador,@Dano,@Humedad,@Apariencia,@QQPS) "
            cmd.Connection = conex
            cmd.CommandText = Sql

            cmd.Parameters.AddWithValue("@Tipo", TxtTipo.Text)
            cmd.Parameters.AddWithValue("@Correlativo", TxtCorrelativo.Text)
            cmd.Parameters.AddWithValue("@COD_ORGANIZACION", TxtCodOP.Text)
            cmd.Parameters.AddWithValue("@COD_PRODUCTOR", TxtCodProd.Text)
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha))
            cmd.Parameters.AddWithValue("@Exportador", TxtExportador.SelectedValue)
            cmd.Parameters.AddWithValue("@Dano", TxtDano.Text)
            cmd.Parameters.AddWithValue("@Humedad", TxtHumedad.Text)
            cmd.Parameters.AddWithValue("@Apariencia", TxtApariencia.SelectedValue)
            cmd.Parameters.AddWithValue("@QQPS", TxtQQPS.Text)

        End If

        cmd.ExecuteNonQuery()

        conex.Close()

        Label1.Text = "Los datos han sido guardados"

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
    End Sub

    Protected Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        Response.Redirect(String.Format("~/pages/catacioneshumres.aspx?org=" + TxtCodOP.Text + "&dir=1"))
    End Sub

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Response.Redirect(String.Format("~/pages/catacioneshumres.aspx?org=" + TxtCodOP.Text + "&dir=1"))
    End Sub
End Class