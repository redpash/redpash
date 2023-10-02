Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Portal_Sag
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim conn4 As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString

    Dim sentencia, identity As String
    Dim nuevo As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then

                llenarcomboDepto()
                llenarcomboProductor()
                llenagrid()

            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboDepto()
        Dim StrCombo As String

        If TxtCiclo.SelectedValue = "Todos" Then
            StrCombo = "SELECT ' Todos' as Depto_Descripcion "
        Else


            StrCombo = "SELECT 'Todos' as NOMBRE UNION SELECT DISTINCT NOMBRE FROM `tb_departamentos` "
        End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(0).ToString()
        TxtDepto.DataBind()
    End Sub

    Private Sub llenarcomboProductor()
        Dim StrCombo As String

        StrCombo = "SELECT '00' as COD_BCS, 'Todos' as Nombres_registros_organizacion_y_Individual union SELECT    concat( 'BCS-', `registros_bancos_semilla`.`Depto_Cod`, '-00', `registros_bancos_semilla`.`Id` ) AS `COD_BCS`, CONCAT(COALESCE(OP_NOMBRE, ''), COALESCE(PROD_NOMBRE, '')) AS Nombres_registros_organizacion_y_Individual
        FROM registros_bancos_semilla WHERE Depto_Descripcion = '" & TxtDepto.SelectedValue & "' "

        'StrCombo = "SELECT * FROM vista_registro_org_in"

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtProductor.DataSource = DtCombo
        TxtProductor.DataValueField = DtCombo.Columns(0).ToString()
        TxtProductor.DataTextField = DtCombo.Columns(1).ToString()
        TxtProductor.DataBind()
    End Sub

    Sub llenagrid()

        BAgregar.Visible = False
        If TxtCiclo.SelectedValue = "Todos" Then
            Me.SqlDataSource1.SelectCommand = "SELECT * FROM `mas+bcs_inscripcion_senasa`  ORDER BY Departamento,Productor,CICLO "
        Else

            If (TxtDepto.SelectedValue = "Todos") Then
                Me.SqlDataSource1.SelectCommand = " SELECT * FROM `mas+bcs_inscripcion_senasa` where CICLO='" & TxtCiclo.SelectedValue & "'   ORDER BY Departamento,Productor,CICLO "
            Else

                If (TxtProductor.Text = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT * FROM `mas+bcs_inscripcion_senasa` where CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "
                Else



                    Me.SqlDataSource1.SelectCommand = " SELECT * FROM `mas+bcs_inscripcion_senasa` where CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "' AND COD_BCS='" & TxtProductor.SelectedValue & "'   ORDER BY Departamento,Productor,CICLO "
                    BAgregar.Visible = True
                End If
            End If

        End If

        GridDatos.DataBind()

    End Sub

    Protected Sub TxtCiclo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCiclo.SelectedIndexChanged
        llenarcomboDepto()
        llenarcomboProductor()
        llenagrid()
    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboProductor()
        llenagrid()

    End Sub

    Protected Sub TxtProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtProductor.SelectedIndexChanged
        llenagrid()

    End Sub

    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Editar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn4)
            Dim dt As New DataTable
            adap.Fill(dt)

            nuevo = False

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo de edición, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else

                TxtNom.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString
                TxtCicloD.Text = dt.Rows(0)("CICLO").ToString()
                TxtVariedad.Text = dt.Rows(0)("VARIEDAD").ToString()
                TxtCategoria.Text = dt.Rows(0)("CATEGORIA").ToString()

                fecha2 = dt.Rows(0)("FECHA_SIEMBRA").ToString()
                TxtDia.SelectedValue = fecha2.Day
                TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
                TxtAno.SelectedValue = fecha2.Year

                TxtAreaSemb.Text = dt.Rows(0)("INVENTARIO_EN_DICTA").ToString()
                TxtPronostico.Text = dt.Rows(0)("SEMILLA_A_PRODUCIR").ToString()

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip').modal('show'); });", True)
            End If
        End If

        If (e.CommandName = "Eliminar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+bcs_inscripcion_senasa` WHERE  ID='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn4)
            Dim dt As New DataTable
            adap.Fill(dt)

            TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

            If txt_habilitado.Text = "NO" Then

                Label3.Text = "Para este ciclo ya ha finalizado el tiempo para eliminar, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else

                Label1.Text = "¿Esta seguro que desea eliminar el registro?"
                BConfirm.Visible = False

                BBorrarsi.Visible = True
                BBorrarno.Visible = True

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)
            End If
        End If
    End Sub

    Protected Sub GridDatos_DataBound(sender As Object, e As EventArgs) Handles GridDatos.DataBound
        If (GridDatos.Rows.Count > 0) Then
            ' Recupera la el PagerRow...
            Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
            ' Recupera los controles DropDownList y label...
            Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
            Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("CurrentPageLabel"), Label)
            If Not pageList Is Nothing Then
                ' Se crean los valores del DropDownList tomando el número total de páginas...
                Dim i As Integer
                For i = 0 To GridDatos.PageCount - 1
                    ' Se crea un objeto ListItem para representar la �gina...
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
                ' Calcula el nº de �gina actual...
                Dim currentPage As Integer = GridDatos.PageIndex + 1
                ' Actualiza el Label control con la �gina actual.
                pageLabel.Text = "Página " & currentPage.ToString() & " de " & GridDatos.PageCount.ToString()
            End If
        End If
    End Sub

    Protected Sub PageDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos.PageIndex = pageList.SelectedIndex
        llenagrid()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        lblTotalClientes.Text = e.AffectedRows.ToString()

    End Sub

    Private Sub exportar()

        Dim query As String = ""

        If TxtCiclo.SelectedValue = "Todos" Then
            query = "SELECT * FROM `mas+bcs_inscripcion_senasa`  ORDER BY Departamento,Productor,CICLO "
        Else
            If (TxtDepto.SelectedValue = " Todos") Then
                query = "SELECT * FROM `mas+bcs_inscripcion_senasa` WHERE CICLO='" & TxtCiclo.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "
            Else
                query = "SELECT * FROM `mas+bcs_inscripcion_senasa` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "
            End If
        End If

        Using con As New MySqlConnection(conn4)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "bcs_inscripcion_senasa"

                        Using wb As New XLWorkbook()
                            For Each dt As DataTable In ds.Tables
                                ' Add DataTable as Worksheet.
                                Dim ws As IXLWorksheet = wb.Worksheets.Add(dt)

                                ' Set auto width for all columns based on content.
                                ws.Columns().AdjustToContents()
                            Next

                            ' Export the Excel file.
                            Response.Clear()
                            Response.Buffer = True
                            Response.Charset = ""
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Response.AddHeader("content-disposition", "attachment;filename=PLAN PRODUCCIÓN DE SEMILLA DE FRIJOL  " & Today & ".xlsx")
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

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        exportar()

    End Sub

    Private Sub llenarVAIDAD_CICLO()

    End Sub

    Protected Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click

        If TxtCiclo.Text = "2022-Ciclo A" Or TxtCiclo.Text = "2022-Ciclo B" Or TxtCiclo.Text = "2022-Ciclo C" Or TxtCiclo.Text = "2023-Ciclo A" Or TxtCiclo.Text = "2023-Ciclo B" Or TxtCiclo.Text = "2023-Ciclo C" Then

            TxtID.Text = ""

            Dim fecha2 As Date

            TxtNom.Text = TxtProductor.SelectedItem.Text
            TxtCicloD.Text = TxtCiclo.SelectedItem.Text
            TxtVariedad.SelectedIndex = 0
            TxtCategoria.SelectedIndex = 0
            TxtAreaSemb.Text = 0

            fecha2 = Now
            TxtDia.SelectedValue = fecha2.Day
            TxtMes.SelectedIndex = Convert.ToInt32(fecha2.Month - 1)
            TxtAno.SelectedValue = fecha2.Year

            TxtPronostico.Text = 0

            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#AdInscrip').modal('show'); });", True)
        Else

            Label3.Text = "Para este ciclo ya ha finalizado el tiempo para agregar registros, por favor si desea agregar el registro realizar la solicitud mediante correo electronico"
            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)

        End If

    End Sub

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim fecha As String
        Dim mes As Integer
        mes = TxtMes.SelectedIndex + 1
        fecha = TxtDia.SelectedValue.ToString + "/" + mes.ToString + "/" + TxtAno.SelectedValue.ToString

        Dim conex As New MySqlConnection(conn4)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        If (TxtID.Text = "") Then
            Sql = "INSERT INTO bcs_inscripcion_senasa (COD_BCS,CICLO, Productor,VARIEDAD,CATEGORIA,INVENTARIO_EN_DICTA,FECHA_SIEMBRA,SEMILLA_A_PRODUCIR, Departamento, Estado, QQ_PRODUCCION, PROYECTO) VALUES (@COD_BCS,@CICLO, @Productor,@VARIEDAD,@CATEGORIA,@INVENTARIO_EN_DICTA,@FECHA_SIEMBRA,@SEMILLA_A_PRODUCIR, @Departamento, @Estado, @QQ_PRODUCCION, @PROYECTO ) "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@COD_BCS", TxtProductor.SelectedValue)
            cmd2.Parameters.AddWithValue("@CICLO", TxtCiclo.SelectedValue)
            cmd2.Parameters.AddWithValue("@Productor", TxtProductor.SelectedValue)
            cmd2.Parameters.AddWithValue("@Departamento", TxtDepto.SelectedValue)
            cmd2.Parameters.AddWithValue("@VARIEDAD", TxtVariedad.SelectedValue)
            cmd2.Parameters.AddWithValue("@CATEGORIA", TxtCategoria.SelectedValue)
            cmd2.Parameters.AddWithValue("@PROYECTO", "RedPash")
            cmd2.Parameters.AddWithValue("@INVENTARIO_EN_DICTA", TxtAreaSemb.Text)
            cmd2.Parameters.AddWithValue("@FECHA_SIEMBRA", Convert.ToDateTime(fecha))
            cmd2.Parameters.AddWithValue("@SEMILLA_A_PRODUCIR", TxtPronostico.Text)
            cmd2.Parameters.AddWithValue("@Estado", "1")

            cmd2.Parameters.AddWithValue("@QQ_PRODUCCION", 0)

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "La inscripcion del lote ha sido agregada"
        Else
            Sql = "UPDATE bcs_inscripcion_senasa SET VARIEDAD=@VARIEDAD,CATEGORIA=@CATEGORIA,INVENTARIO_EN_DICTA=@INVENTARIO_EN_DICTA,FECHA_SIEMBRA=@FECHA_SIEMBRA,SEMILLA_A_PRODUCIR=@SEMILLA_A_PRODUCIR WHERE ID=" & TxtID.Text & " "
            cmd2.Connection = conex
            cmd2.CommandText = Sql

            cmd2.Parameters.AddWithValue("@VARIEDAD", TxtVariedad.SelectedValue)
            cmd2.Parameters.AddWithValue("@CATEGORIA", TxtCategoria.SelectedValue)
            cmd2.Parameters.AddWithValue("@INVENTARIO_EN_DICTA", TxtAreaSemb.Text)
            cmd2.Parameters.AddWithValue("@FECHA_SIEMBRA", Convert.ToDateTime(fecha))
            cmd2.Parameters.AddWithValue("@SEMILLA_A_PRODUCIR", TxtPronostico.Text)
            cmd2.Parameters.AddWithValue("@Estado", "0")

            cmd2.ExecuteNonQuery()
            conex.Close()

            Label1.Text = "La inscripcion del lote ha sido actualizada"

        End If

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

    Protected Sub BBorrarsi_Click(sender As Object, e As EventArgs) Handles BBorrarsi.Click
        Dim conex As New MySqlConnection(conn4)

        conex.Open()

        Dim Sql As String
        Dim cmd As New MySqlCommand()

        Sql = "UPDATE bcs_inscripcion_senasa SET Estado=0  WHERE ID=" & TxtID.Text & " "

        cmd.Connection = conex
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()

        llenagrid()

        Label1.Text = "El registro ha sido eliminado"

        BConfirm.Visible = True

        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)

    End Sub

End Class