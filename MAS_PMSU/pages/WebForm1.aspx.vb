Imports MySql.Data.MySqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            'Bindlistview()
        End If
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