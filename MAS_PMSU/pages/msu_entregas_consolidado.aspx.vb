
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports ClosedXML.Excel
Imports System.Linq
Imports System.Data.OleDb
Public Class msu_entregas_consolidado
    Inherits System.Web.UI.Page

    Dim conn As String = ConfigurationManager.ConnectionStrings("MConnODK").ConnectionString
    Dim conn3 As String = ConfigurationManager.ConnectionStrings("MConnODK3").ConnectionString
    Dim conn4 As String = ConfigurationManager.ConnectionStrings("MConnODK4").ConnectionString
    Dim nombre_usuario As String

    Dim sentencia, identity As String
    Dim filt, nuevo As Boolean
    Dim editar As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then
            If (Not IsPostBack) Then
                llenarcombociclo()
                llenarcomboDepto()
                llenagrid()
                llenarcombocompradores()
                llenarcomboprod()
                llenarcombocompradores_grano()
                txt_qq.Text = 0
                txt_precio.Text = 0

                txt_ingreso_consumo.Text = 0
                txt_total_venta.Text = 0

                txt_precio_consumo.Text = 0
                txt_qq_consumo.Text = 0
                TXT_QQ_VENTA_GRANO.Text = 0
                TXT_PRECIO_GRANO.Text = 0
                TXT_QQ_GRANO_CONSUMO.Text = 0
                TXT_PRECIO_GRANO_CONSUMO.Text = 0

                Guardar_registro.Visible = False
                divedit.Visible = False
                dived.Visible = False
                divdatos.Visible = True
                Lb_user.Text = System.Web.HttpContext.Current.Session("Nombre_Detalle")
            End If
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub
    Private Sub llenarcombociclo()
        Dim StrCombo As String

        StrCombo = "SELECT ' Todos' as CICLO UNION SELECT DISTINCT CICLO FROM `mas+bcs_inscripcion_senasa_prodcos` ORDER BY CICLO "

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtCiclo.DataSource = DtCombo
        TxtCiclo.DataValueField = DtCombo.Columns(0).ToString()
        TxtCiclo.DataTextField = DtCombo.Columns(0).ToString()
        TxtCiclo.DataBind()
    End Sub
    Private Sub llenarcomboDepto()
        Dim StrCombo As String

        'If TxtCiclo.SelectedValue = "Todos" Then
        '    StrCombo = "SELECT 'Todos' as Departamento "
        'Else
        StrCombo = "SELECT ' Todos' as Departamento UNION SELECT DISTINCT Departamento FROM `mas+bcs_inscripcion_senasa_prodcos` WHERE CICLO='" & TxtCiclo.SelectedValue & "' "
        'End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        TxtDepto.DataSource = DtCombo
        TxtDepto.DataValueField = DtCombo.Columns(0).ToString()
        TxtDepto.DataTextField = DtCombo.Columns(0).ToString()
        TxtDepto.DataBind()
    End Sub

    Private Sub llenarcomboprod()
        Dim StrCombo As String

        'If TxtCiclo.SelectedValue = "Todos" Then
        '    StrCombo = "SELECT 'Todos' as Departamento "
        'Else
        StrCombo = "SELECT ' Todos' as Productor UNION SELECT DISTINCT Productor FROM `mas+bcs_inscripcion_senasa_prodcos` WHERE Departamento='" & TxtDepto.SelectedValue & "'  ORDER BY Productor "
        'End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Txtproductor.DataSource = DtCombo
        Txtproductor.DataValueField = DtCombo.Columns(0).ToString()
        Txtproductor.DataTextField = DtCombo.Columns(0).ToString()
        Txtproductor.DataBind()
    End Sub

    Private Sub llenarcombocompradores()
        Dim StrCombo As String

        'If TxtCiclo.SelectedValue = "Todos" Then
        '    StrCombo = "SELECT 'Todos' as Departamento "
        'Else
        StrCombo = "SELECT ' Todos' as Nombre UNION SELECT DISTINCT Nombre FROM `compradores` "
        'End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        Dp_comprador.DataSource = DtCombo
        Dp_comprador.DataValueField = DtCombo.Columns(0).ToString()
        Dp_comprador.DataTextField = DtCombo.Columns(0).ToString()
        Dp_comprador.DataBind()
    End Sub



    Private Sub llenarcombocompradores_grano()
        Dim StrCombo As String

        'If TxtCiclo.SelectedValue = "Todos" Then
        '    StrCombo = "SELECT 'Todos' as Departamento "
        'Else
        StrCombo = "SELECT ' Todos' as Nombre UNION SELECT DISTINCT Nombre FROM `compradores` "
        'End If

        Dim adaptcombo As New MySqlDataAdapter(StrCombo, conn4)
        Dim DtCombo As New DataTable
        adaptcombo.Fill(DtCombo)
        dp_comprador_grano.DataSource = DtCombo
        dp_comprador_grano.DataValueField = DtCombo.Columns(0).ToString()
        dp_comprador_grano.DataTextField = DtCombo.Columns(0).ToString()
        dp_comprador_grano.DataBind()
    End Sub


    Sub llenagrid()
        'BAgregar.Visible = False
        'import.Visible = False


        If TxtCiclo.SelectedValue = " Todos" Then
            Me.SqlDataSource1.SelectCommand = "SELECT ID2,Departamento,Productor,CICLO,VARIEDAD,AREA_SEMBRADA,FECHA_SIEMBRA,ifnull(QQ_PRODUCCION,0.00) as QQ_PRODUCCION ,ifnull(QQ_ORO,0.00) as QQ_ORO ,ifnull(QQ_CONSUMO, 0.00) as QQ_CONSUMO, if(fuente='Dinamica', ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado + QQ_consumo_semilla_consolidado ), ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado  ) ) AS QQ_ORO_entregado, if(fuente='Dinamica',( QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle ),(QQ_consumo_semilla_consolidado+QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle )) AS QQ_CONSUMO_entregado, habilitado  " +
            "FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` ORDER BY Departamento,Productor,CICLO "
        Else


            If (TxtDepto.SelectedValue = " Todos") Then
                Me.SqlDataSource1.SelectCommand = "SELECT ID2,Departamento,Productor,CICLO,VARIEDAD,AREA_SEMBRADA,FECHA_SIEMBRA,ifnull(QQ_PRODUCCION,0.00) as QQ_PRODUCCION ,ifnull(QQ_ORO,0.00) as QQ_ORO ,ifnull(QQ_CONSUMO, 0.00) as QQ_CONSUMO, if(fuente='Dinamica', ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado + QQ_consumo_semilla_consolidado ), ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado  ) ) AS QQ_ORO_entregado, if(fuente='Dinamica',( QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle ),(QQ_consumo_semilla_consolidado+QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle )) AS QQ_CONSUMO_entregado, habilitado  " +
          "FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` WHERE CICLO='" & TxtCiclo.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "
            Else

                If (Txtproductor.SelectedValue = " Todos") Then
                    Me.SqlDataSource1.SelectCommand = "SELECT ID2,Departamento,Productor,CICLO,VARIEDAD,AREA_SEMBRADA,FECHA_SIEMBRA,ifnull(QQ_PRODUCCION,0.00) as QQ_PRODUCCION ,ifnull(QQ_ORO,0.00) as QQ_ORO ,ifnull(QQ_CONSUMO, 0.00) as QQ_CONSUMO, if(fuente='Dinamica', ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado + QQ_consumo_semilla_consolidado ), ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado  ) ) AS QQ_ORO_entregado, if(fuente='Dinamica',( QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle ),(QQ_consumo_semilla_consolidado+QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle )) AS QQ_CONSUMO_entregado, habilitado  " +
    "FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "

                Else








                    Me.SqlDataSource1.SelectCommand = "SELECT ID2,Departamento,Productor,CICLO,VARIEDAD,AREA_SEMBRADA,FECHA_SIEMBRA,ifnull(QQ_PRODUCCION,0.00) as QQ_PRODUCCION ,ifnull(QQ_ORO,0.00) as QQ_ORO ,ifnull(QQ_CONSUMO, 0.00) as QQ_CONSUMO, if(fuente='Dinamica', ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado + QQ_consumo_semilla_consolidado ), ( QQ_venta_semilla_consolidado + QQ_venta_semilla_detallado  ) ) AS QQ_ORO_entregado, if(fuente='Dinamica',( QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle ),(QQ_consumo_semilla_consolidado+QQ_Venta_Consumo_Detalle + QQ_UsoPropio_Consumo_Detalle )) AS QQ_CONSUMO_entregado, habilitado  " +
        "FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "' AND Productor='" & Txtproductor.SelectedValue & "' ORDER BY Departamento,Productor,CICLO "
                End If
            End If
        End If

        GridDatos.DataBind()

    End Sub


    Protected Sub TxtCiclo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCiclo.SelectedIndexChanged
        llenarcomboDepto()

        llenagrid()
    End Sub
    Protected Sub TxtDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDepto.SelectedIndexChanged

        llenagrid()
        llenarcomboprod()
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


    Protected Sub VALIDAR_ENTREGAS()



        Dim QQ_SEMILLA_ENTREGADO, QQ_VENTA_SEMILLA, QQ_ORO_PROD, TOTAL_LIMITE As Decimal


        Dim entregado_grano, produccion_consumo, venta_qq_grano, consumo_qq_grano, total_qq_grano As Decimal





        Dim validado, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 As Integer

        'semilla

        QQ_ORO_PROD = Text_QQ_Produccion_ORO.Text

        QQ_SEMILLA_ENTREGADO = TXT_QQ_ORO_ENTRE.Text

        QQ_VENTA_SEMILLA = txt_qq.Text

        QQ_VENTA_CONSUMO = txt_qq_consumo.Text


        TOTAL_LIMITE = QQ_SEMILLA_ENTREGADO + QQ_VENTA_SEMILLA + QQ_VENTA_CONSUMO



        'grano

        produccion_consumo = Text_QQ_Produccion_consumo.Text

        entregado_grano = TXT_QQ_CONSUMO_ENTRE.Text

        venta_qq_grano = TXT_QQ_VENTA_GRANO.Text


        consumo_qq_grano = TXT_QQ_GRANO_CONSUMO.Text


        total_qq_grano = entregado_grano + venta_qq_grano + consumo_qq_grano






        If TOTAL_LIMITE > QQ_ORO_PROD Then

            LB_VALIDACION_QQ_sEMILLA.Text = "Por favor revisar la informacion a  ingresar, el resultado de  QQ a entregar + QQ entregado es:  " & TOTAL_LIMITE & "  y la producción de QQ  semilla es: " & QQ_ORO_PROD & " "
            a1 = 1

        Else

            LB_VALIDACION_QQ_sEMILLA.Text = " ✔ "


            a1 = 0
        End If


        'campos venta semilla

        If txt_qq.Text > 0 Then
            If txt_precio.Text > 0 Then
                lb_precio_semilla_venta.Text = " ✔ "
                a2 = 0
            Else
                a2 = 1
                lb_precio_semilla_venta.Text = " Por favor ingresar el precio"
            End If
        Else
            lb_precio_semilla_venta.Text = " ✔ "
        End If



        If txt_qq.Text > 0 Then
            If Dp_comprador.Text = "Otro" And txt_detalle_comprador.Text = "" Then
                a3 = 1
                Lb_comprador_semilla.Text = "  Por favor ingresar comprador"
                Lb_comprador_semilla_detalle.Text = "  Por favor detallar comprador"
            Else
                a3 = 0
                Lb_comprador_semilla.Text = " ✔ "
                Lb_comprador_semilla_detalle.Text = " ✔ "
            End If

            If Dp_comprador.Text = " Todos" Then
                a4 = 1
                Lb_comprador_semilla.Text = "  Por favor detallar comprador"
            Else
                a4 = 0
                Lb_comprador_semilla.Text = " ✔ "
            End If
        Else


            Lb_comprador_semilla.Text = " ✔ "
            Lb_comprador_semilla_detalle.Text = ""
        End If








        'campos consumo semilla
        If txt_qq_consumo.Text > 0 Then
            If txt_precio_consumo.Text > 0 Then
                lb_precio_consumo_semilla.Text = " ✔ "
            Else
                lb_precio_consumo_semilla.Text = " Por favor ingresar el precio"
                a5 = 1
            End If

        Else
            lb_precio_consumo_semilla.Text = " ✔ "
        End If





        'campos venta grano (consumo)






        If total_qq_grano > produccion_consumo Then

            lb_validacion_consumo.Text = "Por favor revisar la informacion a  ingresar, el resultado de  QQ a entregar + QQ entregado es:  " & total_qq_grano & "  y la producción de QQ  semilla es: " & produccion_consumo & " "
            a6 = 1

        Else

            lb_validacion_consumo.Text = " ✔"


            a6 = 0
        End If

        If TXT_QQ_VENTA_GRANO.Text > 0 Then

            If dp_comprador_grano.Text = "Otro" And TXT_COMPRADOR_GRANO.Text = "" Then
                a7 = 1
                lb_comprador_detalle_grano.Text = "Por favor detallar comprador"
                lb_comprador_grano.Text = "  Por favor detallar comprador"
            Else
                a7 = 0
                lb_comprador_detalle_grano.Text = " ✔"
                lb_comprador_grano.Text = " ✔"
            End If

            If dp_comprador_grano.Text = " Todos" Then
                a8 = 1
                lb_comprador_grano.Text = "  Por favor ingresar comprador"

            Else
                a8 = 0
                lb_comprador_grano.Text = " ✔"
            End If


        Else

            lb_comprador_grano.Text = " ✔"
            lb_comprador_detalle_grano.Text = ""

        End If




        If TXT_QQ_VENTA_GRANO.Text > 0 Then
            If TXT_PRECIO_GRANO.Text > 0 Then

                a9 = 0
                lb_precio_grano_venta.Text = " ✔"
            Else
                a9 = 1
                lb_precio_grano_venta.Text = " Por favor ingresar el precio"
            End If
        Else
            lb_precio_grano_venta.Text = " ✔"
        End If


        If TXT_QQ_GRANO_CONSUMO.Text > 0 Then
            If TXT_PRECIO_GRANO_CONSUMO.Text > 0 Then

                a10 = 0
                LB_grano_consumo.Text = " ✔"
            Else
                a10 = 1
                LB_grano_consumo.Text = " Por favor ingresar el precio"
            End If

        Else
            LB_grano_consumo.Text = " ✔"
        End If









        validado = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10


        If validado = 0 Then
            Guardar_registro.Visible = True
        Else
            Guardar_registro.Visible = False


        End If







    End Sub

    Protected Sub GridDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDatos.RowCommand
        Dim fecha2 As Date

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim qq_entregado_con, qq_entregado_det As Decimal


        If (e.CommandName = "Ventas") Then

            Guardar_registro.Visible = False
            llenarcombocompradores()
            llenarcombocompradores_grano()
            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` WHERE  ID2='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn4)
            Dim dt As New DataTable
            adap.Fill(dt)





            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()

                If txt_habilitado.Text = "🔒︎" Then


                    Label8.Text = "Para este ciclo ya ha finalizado el tiempo para detallar los valores de ventas, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                    ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
                Else
                    divedit.Visible = True
                divdatos.Visible = False





                TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
                    TxtNom2.Text = HttpUtility.HtmlDecode(gvrow.Cells(2).Text).ToString
                    Text_departamento.Text = dt.Rows(0)("Departamento").ToString()
                    Text_municipio.Text = dt.Rows(0)("Municipio").ToString()
                    Text_aldea.Text = dt.Rows(0)("Aldea").ToString()
                    Text_caserio.Text = dt.Rows(0)("Municipio").ToString()
                    Text_codigo_bcs.Text = dt.Rows(0)("COD_BCS").ToString()
                    Text_nombre_productor.Text = dt.Rows(0)("Productor").ToString()
                    Text_categoria.Text = dt.Rows(0)("CATEGORIA").ToString()
                    Text_ciclo.Text = dt.Rows(0)("CICLO").ToString()
                    Text_variedad.Text = dt.Rows(0)("VARIEDAD").ToString()

                    Text_QQ_Produccion.Text = dt.Rows(0)("QQ_PRODUCCION").ToString()
                    Text_QQ_Produccion_ORO.Text = dt.Rows(0)("QQ_ORO").ToString()
                    Text_QQ_Produccion_consumo.Text = dt.Rows(0)("QQ_CONSUMO").ToString()
                    Text_QQ_Produccion_basura.Text = dt.Rows(0)("QQ_BASURA").ToString()

                txt_fuente.Text = dt.Rows(0)("QQ_BASURA").ToString()


                If txt_fuente.Text = "Dinamica" Then

                    TXT_QQ_ORO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(10).Text).ToString
                    TXT_QQ_CONSUMO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString

                    txt_semilla_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(8).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(10).Text).ToString
                    txt_consumo_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(9).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString

                    '    TXT_QQ_ORO_ENTRE.Text = Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_consolidado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_detallado").ToString()) + Convert.ToDecimal((dt.Rows(0)("QQ_consumo_semilla_consolidado").ToString())))
                    '    TXT_QQ_CONSUMO_ENTRE.Text = Convert.ToDecimal((dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString()))

                    '    txt_semilla_por_detallar.Text = Convert.ToDecimal(dt.Rows(0)("QQ_ORO").ToString()) - (Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_consolidado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_venta_semilla_detallado").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_consumo_semilla_consolidado").ToString())))
                    '    txt_consumo_por_detallar.Text = Convert.ToDecimal(dt.Rows(0)("QQ_CONSUMO").ToString()) - (Convert.ToDecimal((dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString())) + Convert.ToDecimal((dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString())))
                Else

                    TXT_QQ_ORO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(10).Text).ToString
                    TXT_QQ_CONSUMO_ENTRE.Text = HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString

                    txt_semilla_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(8).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(10).Text).ToString
                    txt_consumo_por_detallar.Text = HttpUtility.HtmlDecode(gvrow.Cells(9).Text).ToString - HttpUtility.HtmlDecode(gvrow.Cells(11).Text).ToString

                End If

                TXT_QQ_VENTA_GRANO.Text = dt.Rows(0)("QQ_Venta_Consumo_Detalle").ToString()

                    TXT_QQ_GRANO_CONSUMO.Text = dt.Rows(0)("QQ_UsoPropio_Consumo_Detalle").ToString()

                    txt_qq.Text = 0
                    txt_precio.Text = 0
                    txt_qq_consumo.Text = 0
                    txt_precio_consumo.Text = 0

                    TXT_QQ_VENTA_GRANO.Text = 0

                    TXT_PRECIO_GRANO.Text = 0
                    TXT_QQ_GRANO_CONSUMO.Text = 0
                    TXT_PRECIO_GRANO_CONSUMO.Text = 0


                    ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DetCostos').modal('show'); });", True)






                End If
            End If









        If (e.CommandName = "eliminar") Then


            Dim gvrow As GridViewRow = GridDatos.Rows(index)

            Dim Str As String = "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas` WHERE  ID2='" & HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString & "' "
            Dim adap As New MySqlDataAdapter(Str, conn4)
            Dim dt As New DataTable
            adap.Fill(dt)


            txt_habilitado.Text = dt.Rows(0)("Habilitado").ToString()
            If txt_habilitado.Text = "🔒︎" Then


                Label8.Text = "Para este ciclo ya ha finalizado el tiempo para eliminar los valores de ventas, por favor si desea actualizar el registro realizar la solicitud mediante correo electronico"
                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal2').modal('show'); });", True)
            Else

                TxtID.Text = HttpUtility.HtmlDecode(gvrow.Cells(0).Text).ToString
                Text_codigo_bcs.Text = dt.Rows(0)("COD_BCS").ToString()
                Text_nombre_productor.Text = dt.Rows(0)("Productor").ToString()
                Text_categoria.Text = dt.Rows(0)("CATEGORIA").ToString()
                Text_ciclo.Text = dt.Rows(0)("CICLO").ToString()
                Text_variedad.Text = dt.Rows(0)("VARIEDAD").ToString()



                Label5.Text = "Hola " + Lb_user.Text + ", está seguro que desea todas las ventas registadas para el banco: " + Text_codigo_bcs.Text + "                                      ciclo: " + Text_ciclo.Text + " y Variedad: " + Text_variedad.Text + ""

                ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModalVENTA').modal('show'); });", True)
            End If

        End If

    End Sub



    Protected Sub eliminar_venta()


        Dim conex As New MySqlConnection(conn4)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()


        Sql = "UPDATE `bcs_entregas_new` SET Eliminado=@Eliminado  WHERE ID2='" + TxtID.Text + "'   "
        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@Eliminado", 1)

        cmd2.ExecuteNonQuery()
        conex.Close()



        llenagrid()




    End Sub
    Private Sub exportar()

        Dim query As String = ""

        If TxtCiclo.SelectedValue = " Todos" Then
            query = "select * from `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle_resumen` ORDER BY Departamento,Productor,CICLO; " +
                "select * from `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle` ORDER BY Departamento,Productor,CICLO "


        Else
            If (TxtDepto.SelectedValue = " Todos") Then
                query = "select * from `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle_resumen` WHERE CICLO='" & TxtCiclo.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO; " +
                "select * from `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle` WHERE CICLO='" & TxtCiclo.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "


            Else
                If (Txtproductor.SelectedValue = " Todos") Then



                    query = "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle_resumen` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "' ORDER BY Departamento,Productor,CICLO; " +
                    "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "' ORDER BY Departamento,Productor,CICLO "








                Else
                    query = "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle_resumen` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "'  AND Productor='" & Txtproductor.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO; " +
                    "SELECT * FROM `mas+bcs_inscripcion_senasa_prodcos_new_ventas_detalle` WHERE CICLO='" & TxtCiclo.SelectedValue & "' AND Departamento='" & TxtDepto.SelectedValue & "'  AND Productor='" & Txtproductor.SelectedValue & "'  ORDER BY Departamento,Productor,CICLO "

                End If
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
                        ds.Tables(0).TableName = "Resumen ventas"
                        ds.Tables(1).TableName = "Detalle ventas"


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
                            Response.AddHeader("content-disposition", "attachment;filename=mas+bcs_entregas_ventas " & Today & ".xlsx")
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

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Response.Redirect(String.Format("~/pages/msu_entregas_consolidado.aspx"))
        'divedit.Visible = False
        'divdatos.Visible = True

    End Sub




    Protected Sub calcular_venta()
        txt_total_venta.Text = Convert.ToDecimal(txt_precio.Text) * Convert.ToDecimal(txt_qq.Text)

    End Sub
    Protected Sub calcular_venta_consumo()
        txt_ingreso_consumo.Text = Convert.ToDecimal(txt_qq_consumo.Text) * Convert.ToDecimal(txt_precio_consumo.Text)

    End Sub

    Protected Sub calcular_venta_grano()
        TXT_INGRESO_TOTAL_VENGRANO.Text = Convert.ToDecimal(TXT_QQ_VENTA_GRANO.Text) * Convert.ToDecimal(TXT_PRECIO_GRANO.Text)

    End Sub


    Protected Sub calcular_venta_consumo_grano()
        TXT_INGRESO_TOTAL_CONSGRANO.Text = Convert.ToDecimal(TXT_QQ_GRANO_CONSUMO.Text) * Convert.ToDecimal(TXT_PRECIO_GRANO_CONSUMO.Text)

    End Sub





    Protected Sub validar()




        If Dp_comprador.Text = "Otro" And txt_detalle_comprador.Text = "" Then
            Guardar_registro.Visible = False

        Else
            Guardar_registro.Visible = True
        End If










    End Sub






    Protected Sub Dp_comprador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dp_comprador.SelectedIndexChanged



        If Dp_comprador.Text = "Otro" Then
            txt_detalle_comprador.ReadOnly = False
            validar()
        Else
            txt_detalle_comprador.ReadOnly = True
            txt_detalle_comprador.Text = ""
            validar()
        End If


        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub txt_qq_TextChanged(sender As Object, e As EventArgs) Handles txt_qq.TextChanged
        calcular_venta()



        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub txt_precio_TextChanged(sender As Object, e As EventArgs) Handles txt_precio.TextChanged
        calcular_venta()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_detalle_comprador_TextChanged(sender As Object, e As EventArgs) Handles txt_detalle_comprador.TextChanged
        validar()
        VALIDAR_ENTREGAS()
    End Sub


    Protected Sub btn_eliminar_venta_Click(sender As Object, e As EventArgs) Handles btn_eliminar_venta.Click
        eliminar_venta()
    End Sub

    Protected Sub txt_qq_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_qq_consumo.TextChanged
        calcular_venta_consumo()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub txt_precio_consumo_TextChanged(sender As Object, e As EventArgs) Handles txt_precio_consumo.TextChanged
        calcular_venta_consumo()
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub Txtproductor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Txtproductor.SelectedIndexChanged
        llenagrid()
    End Sub



    Protected Sub Cancelar_edit_Click(sender As Object, e As EventArgs) Handles Cancelar_edit.Click
        Response.Redirect(String.Format("~/pages/msu_entregas_consolidado.aspx"))

    End Sub

    Protected Sub SI_editar_Click(sender As Object, e As EventArgs) Handles SI_editar.Click




        Dim conex As New MySqlConnection(conn4)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()


        Sql = "UPDATE  `bcs_entregas_2022` set QQ_entregado=@QQ_entregado, Precio=@Precio , Total_entrega=@Total_entrega, comprador=@comprador, otro_comprador=@otro_comprador, QQ_entregado_consumo=@QQ_entregado_consumo,  Precio_consumo=@Precio_consumo,  Total_entrega_consumo=@Total_entrega_consumo  WHERE COD_BCS='" + Text_codigo_bcs.Text + "' AND Ciclo='" + Text_ciclo.Text + "' AND  variedad='" + Text_variedad.Text + "'  "

        cmd2.Connection = conex
        cmd2.CommandText = Sql




        cmd2.Parameters.AddWithValue("@QQ_entregado", txt_qq.Text)
        cmd2.Parameters.AddWithValue("@Precio", txt_precio.Text)
        cmd2.Parameters.AddWithValue("@Total_entrega", txt_total_venta.Text)

        cmd2.Parameters.AddWithValue("@comprador", Dp_comprador.Text)
        cmd2.Parameters.AddWithValue("@otro_comprador", txt_detalle_comprador.Text)




        cmd2.Parameters.AddWithValue("@QQ_entregado_consumo", txt_qq_consumo.Text)
        cmd2.Parameters.AddWithValue("@Precio_consumo", txt_precio_consumo.Text)
        cmd2.Parameters.AddWithValue("@Total_entrega_consumo", txt_ingreso_consumo.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()






        llenagrid()



    End Sub

    Protected Sub TXT_QQ_VENTA_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_VENTA_GRANO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_grano()
    End Sub

    Protected Sub TXT_QQ_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_QQ_GRANO_CONSUMO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_consumo_grano()
    End Sub

    Protected Sub TXT_PRECIO_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_grano()
    End Sub

    Protected Sub dp_comprador_grano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dp_comprador_grano.SelectedIndexChanged


        If dp_comprador_grano.Text = "Otro" Then
            TXT_COMPRADOR_GRANO.ReadOnly = False
            validar()
        Else
            TXT_COMPRADOR_GRANO.ReadOnly = True
            TXT_COMPRADOR_GRANO.Text = ""
            validar()
        End If


        VALIDAR_ENTREGAS()

    End Sub

    Protected Sub TXT_COMPRADOR_GRANO_TextChanged(sender As Object, e As EventArgs) Handles TXT_COMPRADOR_GRANO.TextChanged
        VALIDAR_ENTREGAS()
    End Sub

    Protected Sub TXT_PRECIO_GRANO_CONSUMO_TextChanged(sender As Object, e As EventArgs) Handles TXT_PRECIO_GRANO_CONSUMO.TextChanged
        VALIDAR_ENTREGAS()
        calcular_venta_consumo_grano()
    End Sub

    Protected Sub btn_si_Click(sender As Object, e As EventArgs) Handles btn_si.Click



        Dim conex As New MySqlConnection(conn4)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()

        Sql = "INSERT INTO  bcs_entregas_new (Observacion, Usuario, ID2, COD_BCS, Ciclo, Variedad, Categoria, Tipo_venta, QQ_SEMILLA_VENTA, PRECIO_QQ_SEMILLA_VENTA, COMPRADOR_SEMILLA, DETALLE_COMPRADOR_SEMILLA, QQ_SEMILLA_CONSUMO, PRECIO_QQ_SEMILLA_CONSUMO, QQ_GRANO_VENTA, PRECIO_QQ_GRANO_VENTA, COMPRADOR_GRANO, DETALLE_COMPRADOR_GRANO, QQ_GRANO_CONSUMO, PRECIO_QQ_GRANO_CONSUMO) values(@Observacion,@Usuario, @ID2, @COD_BCS, @Ciclo, @Variedad, @Categoria, @Tipo_venta, @QQ_SEMILLA_VENTA, @PRECIO_QQ_SEMILLA_VENTA, @COMPRADOR_SEMILLA, @DETALLE_COMPRADOR_SEMILLA, @QQ_SEMILLA_CONSUMO, @PRECIO_QQ_SEMILLA_CONSUMO, @QQ_GRANO_VENTA, @PRECIO_QQ_GRANO_VENTA, @COMPRADOR_GRANO, @DETALLE_COMPRADOR_GRANO, @QQ_GRANO_CONSUMO, @PRECIO_QQ_GRANO_CONSUMO) "

        cmd2.Connection = conex
        cmd2.CommandText = Sql


        cmd2.Parameters.AddWithValue("@Observacion", txt_observacion.Text)


        cmd2.Parameters.AddWithValue("@Usuario", User.Identity.Name)
        cmd2.Parameters.AddWithValue("@ID2", TxtID.Text)
        cmd2.Parameters.AddWithValue("@COD_BCS", Text_codigo_bcs.Text)
        cmd2.Parameters.AddWithValue("@Ciclo", Text_ciclo.Text)
        cmd2.Parameters.AddWithValue("@Variedad", Text_variedad.Text)
        cmd2.Parameters.AddWithValue("@Categoria", Text_categoria.Text)



        cmd2.Parameters.AddWithValue("@Tipo_venta", "Modulo consolidado")

        If txt_qq.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_VENTA", txt_qq.Text)
        End If

        If txt_precio.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_VENTA", txt_precio.Text)
        End If

        If Dp_comprador.Text = " Todos" Then
            cmd2.Parameters.AddWithValue("@COMPRADOR_SEMILLA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@COMPRADOR_SEMILLA", Dp_comprador.SelectedValue)
        End If



        If txt_detalle_comprador.Text = "" Then
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_SEMILLA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_SEMILLA", txt_detalle_comprador.Text)
        End If


        If txt_qq_consumo.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_SEMILLA_CONSUMO", txt_qq_consumo.Text)
        End If




        If txt_qq_consumo.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_SEMILLA_CONSUMO", txt_precio_consumo.Text)
        End If



        If TXT_QQ_VENTA_GRANO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_GRANO_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_GRANO_VENTA", TXT_QQ_VENTA_GRANO.Text)
        End If

        If TXT_QQ_VENTA_GRANO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_VENTA", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_VENTA", TXT_PRECIO_GRANO.Text)
        End If



        If dp_comprador_grano.Text = " Todos" Then
            cmd2.Parameters.AddWithValue("@COMPRADOR_GRANO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@COMPRADOR_GRANO", dp_comprador_grano.SelectedValue)
        End If


        If TXT_COMPRADOR_GRANO.Text = "" Then
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_GRANO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@DETALLE_COMPRADOR_GRANO", TXT_COMPRADOR_GRANO.Text)
        End If


        If TXT_QQ_GRANO_CONSUMO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@QQ_GRANO_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@QQ_GRANO_CONSUMO", TXT_QQ_GRANO_CONSUMO.Text)
        End If


        If TXT_PRECIO_GRANO_CONSUMO.Text <= 0 Then
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", DBNull.Value)
        Else
            cmd2.Parameters.AddWithValue("@PRECIO_QQ_GRANO_CONSUMO", TXT_PRECIO_GRANO_CONSUMO.Text)
        End If





        cmd2.ExecuteNonQuery()
        conex.Close()



        Response.Redirect(String.Format("~/pages/msu_entregas_consolidado.aspx"))


        llenagrid()



        divedit.Visible = False
        divdatos.Visible = True
    End Sub

    Protected Sub GridDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridDatos.SelectedIndexChanged



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


        Sql = "UPDATE bcs_inscripcion_senasa SET AREA_SEMBRADA2=@AREA_SEMBRADA2,FECHA_SIEMBRA2=@FECHA_SIEMBRA2,AREA_PERDIDA=@AREA_PERDIDA,CAUSAS_PERDIDAS=@CAUSAS_PERDIDAS,QQ_PRODUCCION=@QQ_PRODUCCION,QQ_ORO=@QQ_ORO,QQ_CONSUMO=@QQ_CONSUMO,QQ_BASURA=@QQ_BASURA WHERE ID=" & TxtID.Text & " "
        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@AREA_SEMBRADA2", TxtAreaSemb.Text)
        cmd2.Parameters.AddWithValue("@FECHA_SIEMBRA2", Convert.ToDateTime(fecha))
        cmd2.Parameters.AddWithValue("@AREA_PERDIDA", TxtAreaPerdida.Text)
        cmd2.Parameters.AddWithValue("@CAUSAS_PERDIDAS", TxtCausasPerdida.Text)
        cmd2.Parameters.AddWithValue("@QQ_PRODUCCION", TxtProduccion.Text)
        cmd2.Parameters.AddWithValue("@QQ_ORO", TxtSemilla.Text)
        cmd2.Parameters.AddWithValue("@QQ_CONSUMO", TxtConsumo.Text)
        cmd2.Parameters.AddWithValue("@QQ_BASURA", Txtbasura.Text)

        cmd2.ExecuteNonQuery()
        conex.Close()

        Label1.Text = "La informacion de produccion ha sido actualizada"

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#exampleModalLabel').modal('hide'); });", True)


    End Sub




    Protected Sub BGuardar2_Click(sender As Object, e As EventArgs) Handles BGuardar2.Click

        Dim conex As New MySqlConnection(conn4)

        conex.Open()
        Dim Sql As String
        Dim cmd2 As New MySqlCommand()


        Sql = "UPDATE bcs_inscripcion_senasa SET COSTOS_INSUMOS=@COSTOS_INSUMOS,COSTOS_MANO=@COSTOS_MANO,COSTOS_EQUIPO=@COSTOS_EQUIPO,COSTOS_OTROS=@COSTOS_OTROS,COSTOS_INSCRIPCION=@COSTOS_INSCRIPCION,COSTOS_ACONDICIONAMIENTO_SEMILLA=@COSTOS_ACONDICIONAMIENTO_SEMILLA WHERE Id=" & TxtID.Text & " "
        cmd2.Connection = conex
        cmd2.CommandText = Sql

        cmd2.Parameters.AddWithValue("@COSTOS_INSUMOS", TxtInsumos.Text)
        cmd2.Parameters.AddWithValue("@COSTOS_MANO", TxtMano.Text)
        cmd2.Parameters.AddWithValue("@COSTOS_EQUIPO", TxtEquipo.Text)
        cmd2.Parameters.AddWithValue("@COSTOS_OTROS", TxtOtros.Text)
        cmd2.Parameters.AddWithValue("@COSTOS_INSCRIPCION", TxtInscri.Text)
        cmd2.Parameters.AddWithValue("@COSTOS_ACONDICIONAMIENTO_SEMILLA", TxtAcond.Text)


        cmd2.ExecuteNonQuery()
        conex.Close()

        Label1.Text = "La informacion de costos ha sido actualizada"

        llenagrid()

        BConfirm.Visible = True
        BBorrarsi.Visible = False
        BBorrarno.Visible = False

        ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#DeleteModal').modal('show'); });", True)


    End Sub

End Class