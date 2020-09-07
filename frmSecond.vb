Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports System.IO.Compression

#Disable Warning IDE1006 ' Styles d'affectation de noms

Public Class frmSecond
    Public PlayerPassword As String = frmMain.PlayerPassword
    Public PlayerName As String = frmMain.PlayerName
    Private WithEvents WC As New WebClient
    Private Progression As Integer = 1
    Private MAX_FILES As Integer = 3 ' 7
    Private Abort As AsyncCompletedEventArgs
    Private Enum Lang As Integer
        en
        fr
        de
    End Enum
    Private LangStatus As Integer = 0
    Private txtLang = New String() {"uk", "fr", "de"}

    ' Load everything
    Private Sub frmSecond_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbxPlay.Visible = False
        pbxInstall.Visible = False
        pbxCancel.Visible = False
        lblProgression.Visible = False
        ProgressBar.Visible = False
        pbxRepair.Visible = False
        lblUser.Text = PlayerName
        LangStatus = Lang.en

        If Not File.Exists("Client\Binaries\terauk.exe") And Not File.Exists("Client\Binaries\terafr.exe") Then
            pbxInstall.Visible = True
            lblProgression.Visible = True
        Else
            pbxRepair.Visible = True
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
        Dim realLong = LangStatus + 1
        Dim lang As String = txtLang(LangStatus)
        'Start client with parameters. the 2nd 1 correspond to an immediate login into the first server 3rd one correspond to client language
        Process.Start("Client\Binaries\tera" + lang + ".exe", "1 " + frmMain.getMD5(PlayerPassword) + " 1 " + realLong.ToString + " " + PlayerName + " " + lang)
        'Close launcher.
        'frmMain.Close()
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
        ProgressBar.Visible = True
    End Sub

    ' Display the progression
    Private Sub pbxProgressBar(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar.Value = e.ProgressPercentage
        lblProgression.Text = e.ProgressPercentage.ToString + "% " + Progression.ToString + "/" + MAX_FILES.ToString
    End Sub

    ' Do actions when download complete
    Private Sub pbxDownloadCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        Abort = e
        If Progression.Equals(MAX_FILES) Then
            pbxClearAll()
        ElseIf Not Abort.Cancelled Then
            ProgressBar.Value = 0
            WC.CancelAsync()
            Progression += 1
            WC.Dispose()
            pbxManageDownload()
        ElseIf Abort.Cancelled Then
            lblProgression.Text = "0% " + "0/" + MAX_FILES.ToString
        End If
    End Sub

    Private Sub pbxClearAll()
        WC.Dispose()
        pbxManageArchitecture()
        pbxPlay.Visible = True
        pbxInstall.Visible = False
        pbxCancel.Visible = False
        ProgressBar.Visible = False
        lblProgression.Visible = False
        WC.Dispose()
        MsgBox("Download & Installation completed", MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    ' Manage the files download
    Private Sub pbxManageDownload()
        If Not File.Exists("part" + Progression.ToString + ".zip") Then
            WC.DownloadFileAsync(New Uri("http://51.210.41.122/client/part" + Progression.ToString + ".zip"), "./part" + Progression.ToString + ".zip")
        ElseIf Not Progression.Equals(MAX_FILES) Then
            WC.CancelAsync()
            WC.Dispose()
            Progression += 1
            pbxManageDownload()
        ElseIf Progression.Equals(MAX_FILES) Then
            pbxClearAll()
        End If
    End Sub

    ' When all parts are present in the same folder, we build them back
    Private Sub pbxManageArchitecture()
        lblProgression.Visible = True
        For X = 1 To MAX_FILES
            Try
                If X = 1 Then
                    lblProgression.Text = "1/" + MAX_FILES.ToString
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\")
                ElseIf X = 2 Then
                    lblProgression.Text = "2/" + MAX_FILES.ToString
                    My.Computer.FileSystem.CreateDirectory("Client")
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\")
                ElseIf X = 3 Then
                    lblProgression.Text = "3/" + MAX_FILES.ToString
                    My.Computer.FileSystem.CreateDirectory("Client\S1Game")
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\S1Game\")
                ElseIf X = 4 Then
                    lblProgression.Text = "4/" + MAX_FILES.ToString
                    My.Computer.FileSystem.CreateDirectory("Client\S1Game\CookedPC")
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\S1Game\CookedPC\")
                ElseIf X = 5 Then
                    lblProgression.Text = "5/" + MAX_FILES.ToString
                    My.Computer.FileSystem.CreateDirectory("Client\S1Game\CookedPC\Art_Data")
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\S1Game\CookedPC\Art_Data\Maps\")
                ElseIf X = 6 Then
                    lblProgression.Text = "6/" + MAX_FILES.ToString
                    My.Computer.FileSystem.CreateDirectory("Client\S1Game\CookedPC\Art_Data")
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\S1Game\CookedPC\Art_Data\Packages\")
                ElseIf X = 7 Then
                    lblProgression.Text = "7/" + MAX_FILES.ToString
                    ZipFile.ExtractToDirectory("part" + X.ToString + ".zip", ".\Client\S1Game\CookedPC\Art_Data\Packages\")
                End If
                lblProgression.Text = "Installing " + X.ToString
            Catch ex As Exception
                MsgBox("Can't Extract file" & vbCrLf & ex.Message)
            End Try
        Next X
        lblProgression.Visible = False
    End Sub

    ' Cancel download
    Private Sub pbxCancel_Click(sender As Object, e As EventArgs) Handles pbxCancel.Click
    End Sub

    Private Sub pbxCancel_MouseEnter(sender As Object, e As EventArgs) Handles pbxCancel.MouseEnter
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
        pbxInstall.Visible = True
        ProgressBar.Value = 0
        pbxCancel.Visible = False
        lblProgression.Text = "0% " + "0/" + MAX_FILES.ToString
        My.Computer.FileSystem.DeleteFile("part" + Progression.ToString + ".zip")
    End Sub

    ' Repair part
    Private Sub pbxRepair_Click(sender As Object, e As EventArgs) Handles pbxRepair.Click
    End Sub

    Private Sub pbxRepair_MouseEnter(sender As Object, e As EventArgs) Handles pbxRepair.MouseEnter
        pbxRepair.Image = TERA_Launcher.My.Resources.Resources.repair_hover
    End Sub

    Private Sub pbxRepair_MouseLeave(sender As Object, e As EventArgs) Handles pbxRepair.MouseLeave
        pbxRepair.Image = TERA_Launcher.My.Resources.Resources.repair_normal
    End Sub

    Private Sub pbxRepair_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxRepair.MouseDown
        pbxRepair.Image = TERA_Launcher.My.Resources.Resources.repair_active
    End Sub

    Private Sub pbxRepair_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxRepair.MouseUp
        pbxCancel.Image = TERA_Launcher.My.Resources.Resources.repair_normal
    End Sub

    Private Sub chkEN_Click(sender As Object, e As EventArgs) Handles chkEN.Click
        If chkEN.Checked Then
            chkFR.CheckState = False
            chkDE.CheckState = False
            LangStatus = Lang.en
        End If
    End Sub

    Private Sub chkFR_Click(sender As Object, e As EventArgs) Handles chkFR.Click
        If chkFR.Checked Then
            chkEN.CheckState = False
            chkDE.CheckState = False
            LangStatus = Lang.fr
        End If
    End Sub

    Private Sub chkDE_Click(sender As Object, e As EventArgs) Handles chkDE.Click
        If chkDE.Checked Then
            chkFR.CheckState = False
            chkEN.CheckState = False
            LangStatus = Lang.de
        End If
    End Sub
End Class

#Enable Warning IDE1006 ' Styles d'affectation de noms