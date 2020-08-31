Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

#Disable Warning IDE1006 ' Styles d'affectation de noms

Public Class frmSecond
    Private Sub frmSecond_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub pbxPlay_Click(sender As Object, e As EventArgs) Handles pbxPlay.Click

    End Sub
    Private Sub pbxStart_MouseEnter(sender As Object, e As EventArgs) Handles pbxPlay.MouseEnter
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.start_hover
    End Sub

    Private Sub pbxStart_MouseLeave(sender As Object, e As EventArgs) Handles pbxPlay.MouseLeave
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.start_normal
    End Sub

    Private Sub pbxStart_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxPlay.MouseDown
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.start_active
    End Sub

    Private Sub pbxStart_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxPlay.MouseUp
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.start_normal
        'Check if tera.exe file exists.
        If Not File.Exists("tera.exe") Then
            MsgBox("Could not find tera.exe", MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If
        'Start client with parameters. the 2nd 1 correspond to an immediate login into the first server
        Process.Start("tera.exe", "1 " + frmMain.getMD5(frmMain.PlayerPassword) + " 1 1 " + frmMain.PlayerName + " en")
        'Close launcher.
        End
    End Sub
End Class

#Enable Warning IDE1006 ' Styles d'affectation de noms