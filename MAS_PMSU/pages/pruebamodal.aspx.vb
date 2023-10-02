Imports MySql.Data.MySqlClient
Public Class pruebamodal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            'Bindlistview()
        End If

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        sb.Append("<script type='text/javascript'>")
        sb.Append("$('#addModal').modal('show');")
        sb.Append("</script>")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "AddShowModalScript", sb.ToString, False)
    End Sub
    Protected Sub btnAddRecord_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        'Dim username As String = txtUsername.Text.Trim()
        'Dim password As String = txtPassword.Text.Trim()
        'Dim userId As Integer = 0
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand("Validate_User")
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.AddWithValue("@Username", username)
        '        cmd.Parameters.AddWithValue("@Password", password)
        '        cmd.Connection = con
        '        con.Open()
        '        userId = Convert.ToInt32(cmd.ExecuteScalar())
        '        con.Close()
        '    End Using
        '    Select Case userId
        '        Case -1
        '            dvMessage.Visible = True
        '            lblMessage.Text = "Username and/or password is incorrect."
        '            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", True)
        '            Exit Select
        '        Case -2
        '            dvMessage.Visible = True
        '            lblMessage.Text = "Account has not been activated."
        '            ClientScript.RegisterStartupScript(Me.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", True)
        '            Exit Select
        '        Case Else
        '            If Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
        '                FormsAuthentication.SetAuthCookie(username, chkRememberMe.Checked)
        '                Response.Redirect(Request.QueryString("ReturnUrl"))
        '            Else
        '                FormsAuthentication.RedirectFromLoginPage(username, chkRememberMe.Checked)
        '            End If
        '            Exit Select
        '    End Select
        'End Using
    End Sub
    'Private Sub Bindlistview()
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("ConnODK").ConnectionString

    '    Using con As MySqlConnection = New MySqlConnection(constr)

    '        Using cmd As MySqlCommand = New MySqlCommand("SELECT * FROM cafe_ficha_produccion_2018 ", con)
    '            cmd.CommandType = CommandType.Text

    '            Using sda As MySqlDataAdapter = New MySqlDataAdapter(cmd)
    '                Dim ds As DataSet = New DataSet()
    '                sda.Fill(ds)
    '                lvCustomers.DataSource = ds.Tables(0)
    '                lvCustomers.DataBind()
    '            End Using
    '        End Using
    '    End Using
    'End Sub

    'Protected Sub lvCustomers_ItemEditing(ByVal sender As Object, ByVal e As ListViewEditEventArgs)
    '    lvCustomers.EditIndex = e.NewEditIndex
    '    Bindlistview()
    'End Sub

    'Protected Sub lvCustomers_ItemCanceling(ByVal sender As Object, ByVal e As ListViewCancelEventArgs)
    '    lvCustomers.EditIndex = -1
    '    Bindlistview()
    'End Sub

    'Protected Sub lvCustomers_ItemUpdating(ByVal sender As Object, ByVal e As ListViewUpdateEventArgs)
    '    Dim item As ListViewItem = lvCustomers.Items(e.ItemIndex)
    '    Dim tx As TextBox = TryCast(item.FindControl("txtToDoDate"), TextBox)
    '    Response.Write(tx.Text)
    'End Sub
End Class