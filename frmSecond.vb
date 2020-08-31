Imports System.IO
Imports System.Net
Imports System.ComponentModel

#Disable Warning IDE1006 ' Styles d'affectation de noms

Public Class frmSecond
    Public PlayerPassword As String = frmMain.PlayerPassword
    Public PlayerName As String = frmMain.PlayerName
    Private WithEvents WC As New WebClient
    Private Progression As Integer = 1
    Private MAX_FILES As Integer = 29


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

    ' Start the download
    Private Sub pbxInstall_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxInstall.MouseUp
        pbxInstall.Image = TERA_Launcher.My.Resources.Resources.install_normal
        pbxManageDownload()
        pbxInstall.Visible = False
        pbxCancel.Visible = True
    End Sub

    ' Display the progression
    Private Sub pbxProgressBar(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar.Value = e.ProgressPercentage
        lblProgression.Text = e.ProgressPercentage.ToString + "% " + Progression.ToString + "/" + MAX_FILES.ToString
    End Sub

    ' Do actions when download complete
    Private Sub pbxDownloadCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        If Progression.Equals(MAX_FILES) Then
            pbxClearAll()
        ElseIf Not e.Cancelled Then
            ProgressBar.Value = 0
            WC.CancelAsync()
            Progression += 1
            WC.Dispose()
            pbxManageDownload()
        End If
    End Sub

    Private Sub pbxClearAll()
        pbxPlay.Visible = True
        pbxInstall.Visible = False
        pbxCancel.Visible = False
        ProgressBar.Visible = False
        lblProgression.Visible = False
        WC.CancelAsync()
        WC.Dispose()
        MsgBox("Download completed", MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    ' Manage the files download
    Private Sub pbxManageDownload()
        If Not File.Exists("part" + Progression.ToString + ".rar") Then
            WC.DownloadFileAsync(New Uri("http://51.210.41.122/client/TERA%20NAEU-1732.part" + Progression.ToString + ".rar"), "./part" + Progression.ToString + ".rar")
        ElseIf Not Progression.Equals(MAX_FILES) Then
            WC.CancelAsync()
            WC.Dispose()
            Progression += 1
            pbxManageDownload()
        Else
            pbxClearAll()
        End If
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
        My.Computer.FileSystem.DeleteFile("part" + Progression.ToString + ".rar")
    End Sub
End Class

#Enable Warning IDE1006 ' Styles d'affectation de noms