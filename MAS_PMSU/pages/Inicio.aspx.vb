Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            Label1.Text = System.Web.HttpContext.Current.Session("saludo")
        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If
    End Sub

End Class