Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

#Disable Warning IDE1006 ' Styles d'affectation de noms

Public Class frmSecond
    Public PlayerPassword As String = frmMain.PlayerPassword
    Public PlayerName As String = frmMain.PlayerName
    Private WithEvents WC As New WebClient
    Private Progression As Integer = 1


    Private Sub frmSecond_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbxPlay.Visible = False
        pbxInstall.Visible = False
        pbxCancel.Visible = False
        lblProgression.Visible = False
        lblUser.Text = PlayerName

        If Not File.Exists("tera.exe") Then
            pbxInstall.Visible = True
            lblProgression.Visible = True
        Else
            pbxPlay.Visible = True
        End If
    End Sub

    Private Sub pbxPlay_Click(sender As Object, e As EventArgs) Handles pbxPlay.Click
    End Sub
    Private Sub pbxPlay_MouseEnter(sender As Object, e As EventArgs) Handles pbxPlay.MouseEnter
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.play_hover
    End Sub

    Private Sub pbxPlay_MouseLeave(sender As Object, e As EventArgs) Handles pbxPlay.MouseLeave
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.play_normal
    End Sub

    Private Sub pbxPlay_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxPlay.MouseDown
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.play_active
    End Sub

    Private Sub pbxPlay_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxPlay.MouseUp
        pbxPlay.Image = TERA_Launcher.My.Resources.Resources.play_normal
        'Start client with parameters. the 2nd 1 correspond to an immediate login into the first server
        Process.Start("tera.exe", "1 " + frmMain.getMD5(PlayerPassword) + " 1 1 " + PlayerName + " en")
        'Close launcher.
        frmMain.Close()
        Me.Close()
        End
    End Sub

    ' If Tera is not installed
    Private Sub pbxInstall_Click(sender As Object, e As EventArgs) Handles pbxInstall.Click
    End Sub
    Private Sub pbxInstall_MouseEnter(sender As Object, e As EventArgs) Handles pbxInstall.MouseEnter
        pbxInstall.Image = TERA_Launcher.My.Resources.Resources.install_hover
    End Sub

    Private Sub pbxInstall_MouseLeave(sender As Object, e As EventArgs) Handles pbxInstall.MouseLeave
        pbxInstall.Image = TERA_Launcher.My.Resources.Resources.install_normal
    End Sub

    Private Sub pbxInstall_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxInstall.MouseDown
        pbxInstall.Image = TERA_Launcher.My.Resources.Resources.install_active
    End Sub

    Private Sub pbxInstall_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxInstall.MouseUp
        pbxInstall.Image = TERA_Launcher.My.Resources.Resources.install_normal
        pbxManageDownload()
        pbxInstall.Visible = False
        pbxCancel.Visible = True
    End Sub

    Private Sub pbxProgressBar(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar.Value = e.ProgressPercentage
        lblProgression.Text = e.ProgressPercentage.ToString + "%"
    End Sub

    Private Sub pbxDownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        ProgressBar.Value = 0
        Progression += 1
        pbxManageDownload()
    End Sub

    Private Sub pbxManageDownload()
        WC.DownloadFileAsync(New Uri("http://51.210.41.122/client/TERA%20NAEU-1732.part" + Progression.ToString + ".rar"), "./part" + Progression.ToString + ".rar")
    End Sub

    ' Cancel download
    Private Sub pbxCancel_Click(sender As Object, e As EventArgs) Handles pbxCancel.Click
    End Sub
    Private Sub pbxCancel_MouseEnter(sender As Object, e As EventArgs) Handles pbxCancel.MouseEnter, pbxInstall.MouseEnter
        pbxCancel.Image = TERA_Launcher.My.Resources.Resources.cancel_hover
    End Sub

    Private Sub pbxCancel_MouseLeave(sender As Object, e As EventArgs) Handles pbxCancel.MouseLeave
        pbxCancel.Image = TERA_Launcher.My.Resources.Resources.cancel_normal
    End Sub

    Private Sub pbxCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxCancel.MouseDown
        pbxCancel.Image = TERA_Launcher.My.Resources.Resources.cancel_active
    End Sub

    Private Sub pbxCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxCancel.MouseUp
        pbxCancel.Image = TERA_Launcher.My.Resources.Resources.cancel_normal
        WC.CancelAsync()
        WC.Dispose()
        pbxInstall.Visible = True
        ProgressBar.Value = 0
        pbxCancel.Visible = False
        lblProgression.Text = "0%"
    End Sub
End Class

#Enable Warning IDE1006 ' Styles d'affectation de noms