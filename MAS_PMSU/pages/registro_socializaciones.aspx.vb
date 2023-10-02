Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.IO
Public Class registro_socializaciones
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("ConnODK").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcomboDepto()
                llenarcomboEntrenador()
                'llenarcomboOP()
            End If
            llenagrid()
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `mas+socializaciones` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(1).ToString()
        TxtDepto.DataBind()
    End Sub
    Private Sub llenarcomboEntrenador()
        Dim StrCombo As String = "SELECT '00' as CODIGO_EC,'Todos' as ec_nombre UNION SELECT DISTINCT CODIGO_EC, ec_nombre FROM `mas+socializaciones` WHERE Depto_Cod = '" & TxtDepto.SelectedValue & "' "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtEntrenador.DataSource = DtCombo
        TxtEntrenador.DataValueField = DtCombo.Columns(0).ToString()
        TxtEntrenador.DataTextField = DtCombo.Columns(1).ToString()
        TxtEntrenador.DataBind()
    End Sub
    'Private Sub llenarcomboOP()
    '    Dim StrCombo As String = "SELECT '00' as COD_ORGANIZACION,'Todas' as OP_NOMBRE UNION SELECT DISTINCT COD_ORGANIZACION, OP_NOMBRE FROM `mas+socializaciones` WHERE ec_codigo = '" & TxtEntrenador.SelectedValue & "' "
    '    Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
    '    Dim DtCombo As New DataTable
    '    adaptcombo.Fill(DtCombo)
    '    cmborganizacion.DataSource = DtCombo
    '    cmborganizacion.DataValueField = DtCombo.Columns(0).ToString()
    '    cmborganizacion.DataTextField = DtCombo.Columns(1).ToString()
    '    cmborganizacion.DataBind()

    'End Sub

    Sub llenagrid()
        If TxtDepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,FECHA,NoOrganizaciones,NoProductoresOrg,NoProductoresInd " +
            "FROM `mas+socializaciones` ORDER BY Depto_Descripcion,ec_nombre,FECHA "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,FECHA,NoOrganizaciones,NoProductoresOrg,NoProductoresInd " +
                "FROM `mas+socializaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,FECHA "
            Else
                Me.SqlDataSource1.SelectCommand = "SELECT Depto_Descripcion,ec_nombre,FECHA,NoOrganizaciones,NoProductoresOrg,NoProductoresInd " +
                    "FROM `mas+socializaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND CODIGO_EC='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,FECHA "
            End If
        End If

        GridDatos.DataBind()
    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged
        llenarcomboEntrenador()
        'llenarcomboOP()
        llenagrid()
    End Sub
    Protected Sub TxtEntrenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEntrenador.SelectedIndexChanged
        'llenarcomboOP()
        llenagrid()
    End Sub
    
    Private Sub exportar()
        Dim query As String = ""

        If TxtDepto.SelectedValue = "00" Then
            query = "SELECT * FROM `mas+socializaciones` ORDER BY Depto_Descripcion,ec_nombre,FECHA "
        Else
            If TxtEntrenador.SelectedValue = "00" Then
                query = "SELECT * FROM `mas+socializaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,FECHA "
            Else
                query = "SELECT * FROM `mas+socializaciones` WHERE Depto_Cod='" & TxtDepto.SelectedValue & "' AND CODIGO_EC='" & TxtEntrenador.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,FECHA "
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
                        ds.Tables(0).TableName = "mas+socializaciones"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Registro_socializaciones_MAS+ " & Today & ".xlsx")
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