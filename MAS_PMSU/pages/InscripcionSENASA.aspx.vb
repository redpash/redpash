Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class InscripcionSENASA
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("conn_REDPASH").ConnectionString
    Dim sentencia As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                Dim Str As String = "SELECT * FROM usuariotns WHERE  Nombre='" & User.Identity.Name & "' "
                Dim adap As New MySqlDataAdapter(Str, conn)
                Dim dt As New DataTable
                adap.Fill(dt)

                llenarcomboDepto()
                llenarcomboCicloSiembra()
                llenarcomboProductor()
                llenarcomboComboTipoBanco()
                llenagrid()
            End If

        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub

    Private Sub llenarcomboComboTipoBanco()

    End Sub

    Private Sub llenarcomboDepto()
        'ListBox Departamento
        Dim StrCombo As String = "SELECT '00' as Depto_Cod, 'Todos' as Depto_Descripcion UNION SELECT DISTINCT Depto_Cod ,Depto_Descripcion FROM `vista_banco_semilla_todo` "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxTdepto.DataSource = DtCombo
        TxTdepto.DataValueField = DtCombo.Columns(0).ToString()
        TxTdepto.DataTextField = DtCombo.Columns(1).ToString()
        TxTdepto.DataBind()
    End Sub

    Private Sub llenarcomboCicloSiembra()
        'ListBox Ciclo de Siembra
        Dim StrCombo As String = "SELECT '00' as ec_codigo,' Todos' as ec_nombre UNION SELECT DISTINCT ec_codigo,ec_nombre FROM `vista_banco_semilla_todo` WHERE Depto_Cod = '" & TxTdepto.SelectedValue & "' ORDER BY ec_nombre"
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        DDL_CicloSiembra.DataSource = DtCombo
        DDL_CicloSiembra.DataValueField = DtCombo.Columns(0).ToString()
        DDL_CicloSiembra.DataTextField = DtCombo.Columns(1).ToString()
        DDL_CicloSiembra.DataBind()
    End Sub

    Private Sub llenarcomboProductor()
        'ListBox Productor
        Dim StrCombo As String = "SELECT '00' as cod_TIPO_BCS,' Todas' as TIPO_BCS UNION SELECT DISTINCT TIPO_BCS as cod_TIPO_BCS, TIPO_BCS FROM `vista_banco_semilla_todo` WHERE ec_codigo = '" & DDL_CicloSiembra.SelectedValue & "' ORDER BY TIPO_BCS "
        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        DDL_Productor.DataSource = DtCombo
        DDL_Productor.DataValueField = DtCombo.Columns(0).ToString()
        DDL_Productor.DataTextField = DtCombo.Columns(1).ToString()
        DDL_Productor.DataBind()

    End Sub

    Sub llenagrid()

        If TxTdepto.SelectedValue = "00" Then
            Me.SqlDataSource1.SelectCommand = "SELECT * " +
            "FROM `vista_banco_semilla_todo`  ORDER BY Id,Depto_Descripcion,ec_nombre,OP_NOMBRE "
        Else
            If DDL_CicloSiembra.SelectedValue = "00" Then
                Me.SqlDataSource1.SelectCommand = "SELECT * " +
                "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
            Else
                If (DDL_Productor.SelectedValue = "00") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT * " +
                    "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                Else
                    Me.SqlDataSource1.SelectCommand = "SELECT * " +
                    "FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "' AND TIPO_BCS='" & DDL_Productor.SelectedValue & "'   ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE "
                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub

    Protected Sub GridDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        If (e.CommandName = "Eliminar") Then

            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM registros_bancos_semilla WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            'Label1.Text = "¿Esta seguro que desea eliminar el registro?"
            'BConfirm.Visible = False

            'BBorrarsi.Visible = True
            'BBorrarno.Visible = True

            ' Registro del script para mostrar el modal
            Dim script As String = "$(function () { $('#ModalDelete').modal('show'); });"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowModal", script, True)
        End If
        If (e.CommandName = "Actualizar") Then
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM registros_bancos_semilla WHERE  Id='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn)
            Dim dt As New DataTable
            adap.Fill(dt)

            If dt.Rows(0)("TIPO_BCS").ToString() = "Organizacion" Then

            Else
                If dt.Rows(0)("TIPO_BCS").ToString() = "Individual" Then

                End If

            End If

        End If

    End Sub

    Private Sub validarBotonOrganizacion()

    End Sub

    Private Sub validar_NEW_FORM()
        Dim dep, mun, aldea, caserio, nombre, dni, telefono, socioH, socioM, OP_nombre, direccion, RTN, CAI, PERSONERIA, EC, TOTAL As Integer

    End Sub

    Private Sub validar_NEW_Indiviual()
        Dim dep, mun, aldea, caserio, nombre, dni, telefono, socioH, EC, TOTAL As Integer

    End Sub

    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxTdepto.SelectedIndexChanged
        llenarcomboCicloSiembra()
        llenarcomboProductor()
        llenagrid()

    End Sub

    Protected Sub DDL_CicloSiembra_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_CicloSiembra.SelectedIndexChanged
        llenarcomboProductor()
        llenagrid()
    End Sub

    Protected Sub DDL_Productor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDL_Productor.SelectedIndexChanged
        llenagrid()
    End Sub

    Private Sub exportar()
        Dim dt As New DataTable()
        For Each col As DataControlField In GridDatos.Columns
            If col.Visible Then
                dt.Columns.Add(col.HeaderText)
            End If
        Next

        For Each row As GridViewRow In GridDatos.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim dr As DataRow = dt.NewRow()
                For i As Integer = 0 To dt.Columns.Count - 1
                    dr(i) = row.Cells(i).Text.Replace("&nbsp;", "")
                Next
                dt.Rows.Add(dr)
            End If
        Next

        ' Exportar DataTable a Excel
        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt, "Registros_Bancos_Semilla")

            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=Registro_Organizaciones.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.End()
            End Using
        End Using
    End Sub

    Protected Sub GridDatos_DataBound(sender As Object, e As EventArgs) Handles GridDatos.DataBound
        If (GridDatos.Rows.Count > 0) Then
            ' Recupera la el PagerRow...
            Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
            ' Recupera los controles DropDownList y label...
            Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("CmbPage"), DropDownList)
            Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("PagActual"), Label)
            If Not pageList Is Nothing Then
                ' Se crean los valores del DropDownList tomando el número total de páginas...
                Dim i As Integer
                For i = 0 To GridDatos.PageCount - 1
                    ' Se crea un objeto ListItem para representar la  gina...
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
                ' Calcula el nº de  gina actual...
                Dim currentPage As Integer = GridDatos.PageIndex + 1
                ' Actualiza el Label control con la  gina actual.
                pageLabel.Text = "Página " & currentPage.ToString() & " de " & GridDatos.PageCount.ToString()
            End If
        End If
    End Sub

    Protected Sub CmbPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow As GridViewRow = GridDatos.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("CmbPage"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...
        GridDatos.PageIndex = pageList.SelectedIndex
        llenagrid()
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub

    Protected Sub SqlDataSource1_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected

        LabelTot.Text = e.AffectedRows.ToString()

    End Sub

    Protected Sub btnsi_Click(sender As Object, e As EventArgs) Handles btnsiActualizarOrg.Click
        Dim TipoBanco = "Organizacion"
        Try
            Dim conex As New MySqlConnection(conn)
            conex.Open()

            Dim Sql As String
            Dim cmd As New MySqlCommand()

            Sql = "UPDATE `registros_bancos_semilla` SET ec_codigo=@ec_codigo, ec_nombre=@ec_nombre, Depto_Cod=@Depto_Cod, Depto_Descripcion=@Depto_Descripcion, Muni_Descripcion=@Muni_Descripcion, Aldea_Descripcion=@Aldea_Descripcion, Caserio_Descripcion=@Caserio_Descripcion, FECHA_REGISTRO=@FECHA_REGISTRO, OP_NOMBRE=@OP_NOMBRE, OP_REPRESENTANTE_CARGO=@OP_REPRESENTANTE_CARGO, OP_REPRESENTANTE_SEXO=@OP_REPRESENTANTE_SEXO, OP_REPRESENTANTE_EDAD=@OP_REPRESENTANTE_EDAD, OP_REPRESENTANTE_ID=@OP_REPRESENTANTE_ID, OP_REPRESENTANTE_TELEFONO=@OP_REPRESENTANTE_TELEFONO, OP_MIEMBROS_Hombres=@OP_MIEMBROS_Hombres, OP_MIEMBROS_Mujeres=@OP_MIEMBROS_Mujeres,Op_Nombre_Organizacion=@Op_Nombre_Organizacion,Op_Direccion_Organizacion=@Op_Direccion_Organizacion, OP_TIPO=@OP_TIPO, OP_PERSONERIA=@OP_PERSONERIA, OP_RTN=@OP_RTN, OP_RTN_NUM=@OP_RTN_NUM, OP_CAI=@OP_CAI, OP_CAI_NUM=@OP_CAI_NUM, TIPO_BCS=@TIPO_BCS, Cuenta_Bancaria=@Cuenta_Bancaria, Cuenta_Ahorro=@Cuenta_Ahorro, Lista_De_Bancos=@Lista_De_Bancos, Cuenta_Bancos=@Cuenta_Bancos, Nombre_Beneficiario=@Nombre_Beneficiario, Experiencia_Produccion=@Experiencia_Produccion, Tiempo_Experiencia=@Tiempo_Experiencia, Tipo_Semilla=@Tipo_Semilla, Proyecto_Distribucion_Semilla=@Proyecto_Distribucion_Semilla, Produjo_Semilla_Registrada=@Produjo_Semilla_Registrada, Produjo_Semilla_Certificada=@Produjo_Semilla_Certificada, Brindo_Asistencia_Tecnica=@Brindo_Asistencia_Tecnica, Apoyo_Inscripcion_Senasa=@Apoyo_Inscripcion_Senasa, Otra_Experiencia=@Otra_Experiencia, Colaboracion_FAO=@Colaboracion_FAO, Colaboracion_Otro=@Colaboracion_Otro, Esta_Asociado=@Esta_Asociado, Nombre_Asociacion=@Nombre_Asociacion, Cantidad_Tierra_En_MZ=@Cantidad_Tierra_En_MZ, Tiene_Maiz=@Tiene_Maiz, Cantidad_Terreno_Maiz=@Cantidad_Terreno_Maiz, Tiene_Frijol=@Tiene_Frijol, Cantidad_Terreno_Frijol=@Cantidad_Terreno_Frijol, Tiene_Sorgo=@Tiene_Sorgo, Cantidad_Terreno_Sorgo=@Cantidad_Terreno_Sorgo, Tiene_Cafe=@Tiene_Cafe, Cantidad_Terreno_Hortaliza=@Cantidad_Terreno_Hortaliza, Tiene_Hortaliza=@Tiene_Hortaliza, Tiene_Frutales=@Tiene_Frutales, Cantidad_Terreno_Frutales=@Cantidad_Terreno_Frutales, Tiene_Ganaderia=@Tiene_Ganaderia, Cantidad_Terreno_Ganaderia=@Cantidad_Terreno_Ganaderia, Tiene_ConservacionBosque=@Tiene_ConservacionBosque, Cantidad_Terreno_ConservacionBosque=@Cantidad_Terreno_ConservacionBosque, Tiene_Otros=@Tiene_Otros, Cantidad_Terreno_Otros=@Cantidad_Terreno_Otros, Espesifique_Tipo=@Espesifique_Tipo, Cantidad_Terreno_Mz_Certificada=@Cantidad_Terreno_Mz_Certificada, Cantidad_Lotes_Disponibles=@Cantidad_Lotes_Disponibles, Topografia_Adecuada=@Topografia_Adecuada, Rio_Dentro_Finca=@Rio_Dentro_Finca, Pozo_Dentro_Finca=@Pozo_Dentro_Finca, OjoDeAgua_Dentro_Finca=@OjoDeAgua_Dentro_Finca, Rio_Fuera_Finca=@Rio_Fuera_Finca, Pozo_Fuera_Finca=@Pozo_Fuera_Finca, OjoDeAgua_Fuera_Finca=@OjoDeAgua_Fuera_Finca, Possee_Sistema_Riego=@Possee_Sistema_Riego, Tipo_Sistema_Riego=@Tipo_Sistema_Riego, Terreno_Bajo_Riego=@Terreno_Bajo_Riego, No_Requiere=@No_Requiere, Requiere_Combustion=@Requiere_Combustion, Requiere_Electricidad=@Requiere_Electricidad, Requiere_Energia_Solar=@Requiere_Energia_Solar, Otro_Tipo_Energia=@Otro_Tipo_Energia, Distancia_Ubicacion=@Distancia_Ubicacion, Transitan_Vehiculos=@Transitan_Vehiculos, Transporte_Automovil=@Transporte_Automovil, Transporte_PickUp=@Transporte_PickUp, Transporte_Motocicleta=@Transporte_Motocicleta, Transporte_Bicicleta=@Transporte_Bicicleta, Transporte_Caballo_Mula_Macho=@Transporte_Caballo_Mula_Macho, Otro_Transporte=@Otro_Transporte, Tiene_Bodega=@Tiene_Bodega, Cantidad_Bodega=@Cantidad_Bodega, Tiene_Secadoras_Solares=@Tiene_Secadoras_Solares, Cantidad_Secadora_Solares=@Cantidad_Secadora_Solares, Tiene_Secadora_Mecanica=@Tiene_Secadora_Mecanica, Cantidad_Secadora_Mecanica=@Cantidad_Secadora_Mecanica, Tiene_Computadoras=@Tiene_Computadoras, Cantidad_Computadoras=@Cantidad_Computadoras, Tiene_Equipo_de_Aspersion=@Tiene_Equipo_de_Aspersion, Cantidad_Equipo_Aspersion=@Cantidad_Equipo_Aspersion, Tiene_Desgranadora=@Tiene_Desgranadora, Cantidad_Desgranadora=@Cantidad_Desgranadora, Tiene_Zaranda=@Tiene_Zaranda, Cantidad_Zaranda=@Cantidad_Zaranda, Tiene_Maquinaria_Tractor=@Tiene_Maquinaria_Tractor, Cantidad_Maquinaria=@Cantidad_Maquinaria, Tiene_Arado=@Tiene_Arado, Cantidad_Arado=@Cantidad_Arado, Tiene_Acamadora=@Tiene_Acamadora, Cantidad_Acamadora=@Cantidad_Acamadora, Tiene_Sembradora=@Tiene_Sembradora, Cantidad_Sembradora=@Cantidad_Sembradora, Tiene_Clasificadora=@Tiene_Clasificadora, Cantidad_Clasificadora=@Cantidad_Clasificadora, Tiene_Pulidora=@Tiene_Pulidora, Cantidad_Pulidora=@Cantidad_Pulidora, Tiene_Envasadora=@Tiene_Envasadora, Cantidad_Envasadora=@Cantidad_Envasadora, Tiene_Bomba_Riego=@Tiene_Bomba_Riego, Cantida_Bomba_Riego=@Cantida_Bomba_Riego, Tiene_Patio_Secado=@Tiene_Patio_Secado, Cantidad_Patio_Secado=@Cantidad_Patio_Secado, Tiene_Otras=@Tiene_Otras, Describa_Otras=@Describa_Otras , Otro_Transporte_Si_Org=@Otro_Transporte_Si_Org WHERE id=@Id "
            cmd.Connection = conex

            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
            conex.Close()
            llenagrid()
        Catch ex As Exception
            ' Capturar y mostrar el mensaje de error en caso de excepción
            Dim errorMessage As String = "Error al intentar actualizar el registro: " & ex.Message
            MsgBox(errorMessage)
        End Try

        ' Realizar la redirección después de la ejecución del bloque Try...Catch
        Response.Redirect(String.Format("~/pages/Registro_Banco_Semilla.aspx"))

    End Sub

    Protected Sub btnsiActualizarIn_Click(sender As Object, e As EventArgs) Handles btnsiActualizarIn.Click

    End Sub

    Protected Sub ExportarGridViewToExcel(gridView As GridView)
        Dim dt As New DataTable()

        ' Agregar columnas al DataTable basado en las columnas del GridView
        For Each cell As TableCell In gridView.HeaderRow.Cells
            dt.Columns.Add(cell.Text)
        Next

        ' Agregar filas al DataTable basado en los datos del GridView
        For Each row As GridViewRow In gridView.Rows
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To gridView.HeaderRow.Cells.Count - 1
                dr(i) = row.Cells(i).Text.Replace("&nbsp;", "")
            Next
            dt.Rows.Add(dr)
        Next

        ' Crear el archivo de Excel usando ClosedXML
        Using wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add(dt, "Datos")

            ' Ajustar el estilo del encabezado de las columnas
            Dim headerRow = ws.FirstRowUsed()
            headerRow.Style.Font.Bold = True
            headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue

            ' Autoajustar las columnas
            ws.Columns().AdjustToContents()

            'Exportar el archivo de Excel
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=Datos_Exportados.xlsx")

            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.End()
            End Using
        End Using
    End Sub

    Protected Sub ExportarExceelOrg_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim query As String = ""

        If TxTdepto.SelectedValue = "00" Then
            query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Estado = 1 ORDER BY Id,Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                "SELECT * FROM `vista_banco_semilla_in`   ORDER BY Depto_Descripcion; " +
                "SELECT * FROM `vista_banco_semilla_org` ORDER BY Depto_Descripcion "
        Else
            If DDL_CicloSiembra.SelectedValue = "00" Then
                query = "SELECT *  FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                     "SELECT *  FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion; " +
                      "SELECT *  FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' ORDER BY Depto_Descripcion "
            Else
                If (DDL_Productor.SelectedValue = "00") Then
                    query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "'  ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                        "SELECT * FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "'  ORDER BY Depto_Descripcion; " +
                                   "SELECT * FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "'  ORDER BY Depto_Descripcion "
                Else
                    query = "SELECT * FROM `vista_banco_semilla_todo` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "' AND TIPO_BCS='" & DDL_Productor.SelectedValue & "'   ORDER BY Depto_Descripcion,ec_nombre,OP_NOMBRE; " +
                        "SELECT * FROM `vista_banco_semilla_in` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "' AND TIPO_BCS='" & DDL_Productor.SelectedValue & "'   ORDER BY Depto_Descripcion; " +
                         "SELECT * FROM `vista_banco_semilla_org` WHERE Depto_Cod='" & TxTdepto.SelectedValue & "' AND ec_codigo='" & DDL_CicloSiembra.SelectedValue & "' AND TIPO_BCS='" & DDL_Productor.SelectedValue & "'   ORDER BY Depto_Descripcion "
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
                        ds.Tables(0).TableName = "Total BCS"
                        ds.Tables(1).TableName = "Total BCS Individual"
                        ds.Tables(2).TableName = "Total BCS Organizacion"

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
                            Response.AddHeader("content-disposition", "attachment;filename=Red+pash_bancos " & Today & ".xlsx")
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

End Class