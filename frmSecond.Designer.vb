<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSecond
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSecond))
        Me.pbxPlay = New System.Windows.Forms.PictureBox()
        Me.pbxInstall = New System.Windows.Forms.PictureBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pbxCancel = New System.Windows.Forms.PictureBox()
        CType(Me.pbxPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxInstall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxPlay
        '
        Me.pbxPlay.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlay.Image = Global.TERA_Launcher.My.Resources.Resources.start_normal
        Me.pbxPlay.Location = New System.Drawing.Point(115, 287)
        Me.pbxPlay.Name = "pbxPlay"
        Me.pbxPlay.Size = New System.Drawing.Size(257, 107)
        Me.pbxPlay.TabIndex = 13
        Me.pbxPlay.TabStop = False
        '
        'pbxInstall
        '
        Me.pbxInstall.BackColor = System.Drawing.Color.Transparent
        Me.pbxInstall.Image = Global.TERA_Launcher.My.Resources.Resources.install_normal
        Me.pbxInstall.Location = New System.Drawing.Point(115, 287)
        Me.pbxInstall.Name = "pbxInstall"
        Me.pbxInstall.Size = New System.Drawing.Size(257, 107)
        Me.pbxInstall.TabIndex = 14
        Me.pbxInstall.TabStop = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(115, 245)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(257, 23)
        Me.ProgressBar.TabIndex = 15
        '
        'pbxCancel
        '
        Me.pbxCancel.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancel.Image = Global.TERA_Launcher.My.Resources.Resources.cancel_normal
        Me.pbxCancel.Location = New System.Drawing.Point(115, 287)
        Me.pbxCancel.Name = "pbxCancel"
        Me.pbxCancel.Size = New System.Drawing.Size(257, 107)
        Me.pbxCancel.TabIndex = 16
        Me.pbxCancel.TabStop = False
        '
        'frmSecond
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.TERA_Launcher.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(734, 417)
        Me.Controls.Add(Me.pbxCancel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.pbxInstall)
        Me.Controls.Add(Me.pbxPlay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSecond"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TERA-Launcher"
        CType(Me.pbxPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxInstall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pbxPlay As PictureBox
    Private WithEvents pbxInstall As PictureBox
    Friend WithEvents ProgressBar As ProgressBar
    Private WithEvents pbxCancel As PictureBox
End Class
