Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared].Json
Imports DocumentFormat.OpenXml.Office.Word
Imports MySql.Data.MySqlClient

Public Class ActaRecepcionSemilla
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String
    Dim validarflag As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If User.Identity.IsAuthenticated = True Then
            If IsPostBack Then

            Else
                TxtFechaSiembra.Text = DateTime.Now.ToString("yyyy-MM-dd")
                FillComboBoxWithProductorNames()
                Verificarvariedades()
            End If
        End If
    End Sub
    Protected Sub vaciar(sender As Object, e As EventArgs)
        Response.Redirect("SolicitudInscripcionDeLotes.aspx")
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
        Dim newitem As New ListItem(" ", " ")
        DropDownList7.Items.Insert(0, newitem)
    End Sub
    Protected Sub descargaPDF(sender As Object, e As EventArgs)
        Dim rptdocument As New ReportDocument
        'nombre de dataset
        Dim ds As New DataSetLotes
        Dim Str As String = "SELECT * FROM solicitud_inscripcion_delotes WHERE nombre_lote = @valor"
        Dim adap As New MySqlDataAdapter(Str, conn)
        adap.SelectCommand.Parameters.AddWithValue("@valor", DropDownList7.Text)
        Dim dt As New DataTable
        adap.Fill(ds, "solicitud_inscripcion_delotes")
        Dim nombre As String

        nombre = "Solicitud Inscripcion de Lote o Campo _" + Today
        rptdocument.Load(Server.MapPath("~/pages/Solicitud Inscripcion de Lote.rpt"))
        rptdocument.SetDataSource(ds)
        Response.Buffer = False
        Response.ClearContent()
        Response.ClearHeaders()
        rptdocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, True, nombre)

        Response.End()
    End Sub
    Protected Sub DropDownList7_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedValue As String = DropDownList7.SelectedValue
        txt_nombre_prod_new.Text = selectedValue
    End Sub
    Protected Sub Verificarvariedades()
        If DDL_Amadeus.SelectedValue = "Si" Then
            div1.Style.Add("display", "block")
        Else
            div1.Style.Add("display", "none")
        End If

        If DDL_Carrizalito.SelectedValue = "Si" Then
            div2.Style.Add("display", "block")
        Else
            div2.Style.Add("display", "none")
        End If

        If DDL_Deorho.SelectedValue = "Si" Then
            div3.Style.Add("display", "block")
        Else
            div3.Style.Add("display", "none")
        End If

        If DDL_Azabache.SelectedValue = "Si" Then
            div4.Style.Add("display", "block")
        Else
            div4.Style.Add("display", "none")
        End If

        If DDL_ParaisitoMejoradoPM2.SelectedValue = "Si" Then
            div5.Style.Add("display", "block")
        Else
            div5.Style.Add("display", "none")
        End If

        If DDL_Hondurasnutritivo.SelectedValue = "Si" Then
            div6.Style.Add("display", "block")
        Else
            div6.Style.Add("display", "none")
        End If

        If DDL_IntaCardenas.SelectedValue = "Si" Then
            div7.Style.Add("display", "block")
        Else
            div7.Style.Add("display", "none")
        End If

        If DDL_Lencaprecoz.SelectedValue = "Si" Then
            div8.Style.Add("display", "block")
        Else
            div8.Style.Add("display", "none")
        End If

        If DDL_Rojochorti.SelectedValue = "Si" Then
            div9.Style.Add("display", "block")
        Else
            div9.Style.Add("display", "none")
        End If

        If DDL_Tolupanrojo.SelectedValue = "Si" Then
            div10.Style.Add("display", "block")
        Else
            div10.Style.Add("display", "none")
        End If

        If DDL_Otravariedad.SelectedValue = "Si" Then
            div11.Style.Add("display", "block")
        Else
            div11.Style.Add("display", "none")
        End If
    End Sub
End Class

