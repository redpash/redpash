﻿Public Class TC_REGISTRO_BCS
    Inherits System.Web.UI.Page
    Dim conn As String = ConfigurationManager.ConnectionStrings("CONN_REDPASH").ConnectionString
    Dim sentencia, identity As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If User.Identity.IsAuthenticated = True Then

        Else
            Response.Redirect(String.Format("~/pages/login.aspx"))
        End If

    End Sub


End Class