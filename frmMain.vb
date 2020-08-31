﻿Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

#Disable Warning IDE1006 ' Styles d'affectation de noms

Public Class frmMain
    Public PlayerPassword As String
    Public PlayerName As String

    Private Sub pbxStart_Click(sender As Object, e As EventArgs) Handles pbxStart.Click
        'Check if info is entered.
        If txtAccount.Text.Equals("") Then
            MsgBox("Please enter your account name.", MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If
        If txtPassword.Text.Equals("") Then
            MsgBox("Please enter your password.", MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If
        If PlayerExist(txtAccount.Text, txtPassword.Text) Then
            PlayerName = txtAccount.Text
            PlayerPassword = txtPassword.Text
            frmSecond.Show()
            Me.Close()
        Else
            MsgBox("Wrong credentials", MsgBoxStyle.OkOnly, Me.Text)
        End If
    End Sub

    Private Function PlayerExist(ByVal PlayerName As String, ByVal PlayerPassword As String) As Boolean
        Return Boolean.Parse(GetWebPageText("http://51.210.41.122/auth.php?username=" + PlayerName + "&password=" + getMD5(PlayerPassword)))
    End Function

    Private Function GetWebPageText(ByVal url As String) As String
        Dim Request As WebRequest = WebRequest.Create(url)
        Request.Credentials = CredentialCache.DefaultCredentials
        Return New StreamReader(Request.GetResponse().GetResponseStream()).ReadToEnd()
    End Function


    Private Sub pbxRegister_Click(sender As Object, e As EventArgs) Handles pbxRegister.Click
    End Sub

    Private Sub pbxRegister_MouseLeave(sender As Object, e As EventArgs) Handles pbxRegister.MouseLeave
        pbxRegister.Image = TERA_Launcher.My.Resources.Resources.register_normal
    End Sub
    Private Sub pbxRegister_MouseDown(sender As Object, e As EventArgs) Handles pbxRegister.MouseDown
        pbxRegister.Image = TERA_Launcher.My.Resources.Resources.register_active
    End Sub
    Private Sub pbxRegister_MouseMouseUp(sender As Object, e As EventArgs) Handles pbxRegister.MouseUp
        pbxRegister.Image = TERA_Launcher.My.Resources.Resources.register_normal
        Dim temp = Me.Cursor
        Try
            Me.Cursor = Cursors.WaitCursor
            Process.Start("http://51.210.41.122/register.php")
        Finally
            Me.Cursor = temp
        End Try
    End Sub
    Private Sub pbxRegister_MouseEnter(sender As Object, e As EventArgs) Handles pbxRegister.MouseEnter
        pbxRegister.Image = TERA_Launcher.My.Resources.Resources.register_hover
    End Sub
    Private Sub pbxStart_MouseEnter(sender As Object, e As EventArgs) Handles pbxStart.MouseEnter
        pbxStart.Image = TERA_Launcher.My.Resources.Resources.start_hover
    End Sub

    Private Sub pbxStart_MouseLeave(sender As Object, e As EventArgs) Handles pbxStart.MouseLeave
        pbxStart.Image = TERA_Launcher.My.Resources.Resources.start_normal
    End Sub

    Private Sub pbxStart_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxStart.MouseDown
        pbxStart.Image = TERA_Launcher.My.Resources.Resources.start_active
    End Sub

    Private Sub pbxStart_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxStart.MouseUp
        pbxStart.Image = TERA_Launcher.My.Resources.Resources.start_normal
    End Sub

    Public Function getMD5(ByVal source As String) As String
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()
        Bytes = Encoding.Default.GetBytes(source)
        Bytes = MD5.Create().ComputeHash(Bytes)
        For x As Integer = 0 To Bytes.Length - 1
            sb.Append(Bytes(x).ToString("x2"))
        Next
        Return sb.ToString()
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblAccount_Click(sender As Object, e As EventArgs) Handles lblAccount.Click

    End Sub

    Private Sub txtAccount_TextChanged(sender As Object, e As EventArgs) Handles txtAccount.TextChanged

    End Sub

    Private Sub lblPassword_Click(sender As Object, e As EventArgs) Handles lblPassword.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
End Class
#Enable Warning IDE1006 ' Styles d'affectation de noms