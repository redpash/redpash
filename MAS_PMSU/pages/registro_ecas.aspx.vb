Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.IO
Public Class registro_ecas
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("ConnODK").ConnectionString
    Dim sentencia As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        lblModalTitle.Text = "Validation Errors List for HP7 Citation"
        lblModalBody.Text = "This is modal body"
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "myModal", "$('#myModal').modal();", True)
        upModal.Update()
    End Sub
End Class