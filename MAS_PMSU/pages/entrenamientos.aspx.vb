Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.IO
Public Class entrenamientos
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("ConnODK").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcomboDepto()
                llenarcomboEntrenador()
                llenarECA()
                llenarModulo()
            End If
            llenagrid()
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Descripcion, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Descripcion ,Depto_Descripcion FROM `mas+entrenamientos_resumen` WHERE Depto_Descripcion IS NOT NULL"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as ec_codigo,'Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo,ec_nombre FROM `mas+entrenamientos_resumen` WHERE Depto_Descripcion = '" & TxtDepto.SelectedValue & "' "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    Private Sub llenarECA()
        Dim StrCombo As String = "SELECT '00' as CODIGO_ECA,'Todos' as NOM_PRODUCTOR_ECA UNION SELECT DISTINCT CODIGO_ECA,NOM_PRODUCTOR_ECA FROM `mas+entrenamientos_resumen` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "'  "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEca.DataSource = DtCombo
        TxtEca.DataValueField = DtCombo.Columns(0).ToString()
        TxtEca.DataTextField = DtCombo.Columns(1).ToString()
        TxtEca.DataBind()

    End Sub
    Private Sub llenarModulo()
        Dim StrCombo As String = "SELECT '00' as CODIGO_MODULO,'Todos' as NOMBRE_MODULO UNION SELECT DISTINCT CODIGO_MODULO,NOMBRE_MODULO FROM `mas+entrenamientos_resumen` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' and CODIGO_ECA= '" & TxtEca.SelectedValue & "' "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtModulo.DataSource = DtCombo
        TxtModulo.DataValueField = DtCombo.Columns(0).ToString()
        TxtModulo.DataTextField = DtCombo.Columns(1).ToString()
        TxtModulo.DataBind()

    End Sub
    Private Sub llenagrid()

        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOMBRE_MODULO,FECHA_MODULO,CODIGO_ECA,NOM_PRODUCTOR_ECA,No_Entrenados " +
            "FROM `mas+entrenamientos_resumen` WHERE Depto_Descripcion IS NOT NULL ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOMBRE_MODULO,FECHA_MODULO,CODIGO_ECA,NOM_PRODUCTOR_ECA,No_Entrenados " +
                "FROM `mas+entrenamientos_resumen` WHERE Depto_Descripcion='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
            Else
                If (TxtEca.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOMBRE_MODULO,FECHA_MODULO,CODIGO_ECA,NOM_PRODUCTOR_ECA,No_Entrenados " +
                    "FROM `mas+entrenamientos_resumen` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                Else
                    If (TxtModulo.SelectedValue = "00") Then
                        Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOMBRE_MODULO,FECHA_MODULO,CODIGO_ECA,NOM_PRODUCTOR_ECA,No_Entrenados " +
                        "FROM `mas+entrenamientos_resumen` WHERE CODIGO_ECA= '" & TxtEca.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                    Else
                        Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,NOMBRE_MODULO,FECHA_MODULO,CODIGO_ECA,NOM_PRODUCTOR_ECA,No_Entrenados " +
                        "FROM `mas+entrenamientos_resumen` WHERE CODIGO_ECA= '" & TxtEca.SelectedValue & "' AND CODIGO_MODULO= '" & TxtModulo.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                    End If
                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboEntrenador()
        llenarECA()
        llenarModulo()
        'llenagrid()
    End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        llenarECA()
        llenarModulo()
        'llenagrid()
    End Sub
    Protected Sub TxtEca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtEca.SelectedIndexChanged
        llenarModulo()
    End Sub

    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+entrenamientos` WHERE Depto_Descripcion IS NOT NULL ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `mas+entrenamientos` WHERE Depto_Descripcion='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
            Else
                If (TxtEca.SelectedValue = "00") Then
                    query = "SELECT * FROM `mas+entrenamientos` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                Else
                    If (TxtModulo.SelectedValue = "00") Then
                        query = "SELECT * FROM `mas+entrenamientos` WHERE CODIGO_ECA= '" & TxtEca.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                    Else
                        query = "SELECT * FROM `mas+entrenamientos` WHERE CODIGO_ECA= '" & TxtEca.SelectedValue & "' AND CODIGO_MODULO= '" & TxtModulo.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,NOMBRE_MODULO "
                    End If
                End If
            End If
        End If
        Using con As New MySqlConnection(conn)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)

                        'Set Name of DataTables.
                        ds.Tables(0).TableName = "mas+entrenamientos"

                        Using wb As New XLWorkbook()
                            For Each dt As DataTable In ds.Tables
                                'Add DataTable as Worksheet.
                                wb.Worksheets.Add(dt)
                            Next

                            'Export the Excel file.
                            Response.Clear()
                            Response.Buffer = True
                            Response.Charset = ""
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Response.AddHeader("content-disposition", "attachment;filename=Entrenamientos_MAS+ " & Today & ".xlsx")
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


End Class