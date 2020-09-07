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
        Me.lblProgression = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.pbxRepair = New System.Windows.Forms.PictureBox()
        Me.chkEN = New System.Windows.Forms.CheckBox()
        Me.chkFR = New System.Windows.Forms.CheckBox()
        Me.chkDE = New System.Windows.Forms.CheckBox()
        CType(Me.pbxPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxInstall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRepair, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxPlay
        '
        Me.pbxPlay.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlay.Image = Global.TERA_Launcher.My.Resources.Resources.play_normal
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
        'lblProgression
        '
        Me.lblProgression.AutoSize = True
        Me.lblProgression.BackColor = System.Drawing.Color.Transparent
        Me.lblProgression.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgression.ForeColor = System.Drawing.Color.Silver
        Me.lblProgression.Location = New System.Drawing.Point(209, 223)
        Me.lblProgression.Name = "lblProgression"
        Me.lblProgression.Size = New System.Drawing.Size(0, 19)
        Me.lblProgression.TabIndex = 17
        Me.lblProgression.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Silver
        Me.lblUser.Location = New System.Drawing.Point(12, 22)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(60, 25)
        Me.lblUser.TabIndex = 18
        Me.lblUser.Text = "User"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pbxRepair
        '
        Me.pbxRepair.BackColor = System.Drawing.Color.Transparent
        Me.pbxRepair.Image = Global.TERA_Launcher.My.Resources.Resources.repair_normal
        Me.pbxRepair.Location = New System.Drawing.Point(115, 113)
        Me.pbxRepair.Name = "pbxRepair"
        Me.pbxRepair.Size = New System.Drawing.Size(257, 107)
        Me.pbxRepair.TabIndex = 19
        Me.pbxRepair.TabStop = False
        '
        'chkEN
        '
        Me.chkEN.AutoSize = True
        Me.chkEN.BackColor = System.Drawing.Color.Transparent
        Me.chkEN.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.chkEN.Location = New System.Drawing.Point(17, 113)
        Me.chkEN.Name = "chkEN"
        Me.chkEN.Size = New System.Drawing.Size(41, 17)
        Me.chkEN.TabIndex = 21
        Me.chkEN.Text = "EN"
        Me.chkEN.UseVisualStyleBackColor = False
        '
        'chkFR
        '
        Me.chkFR.AutoSize = True
        Me.chkFR.BackColor = System.Drawing.Color.Transparent
        Me.chkFR.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.chkFR.Location = New System.Drawing.Point(17, 136)
        Me.chkFR.Name = "chkFR"
        Me.chkFR.Size = New System.Drawing.Size(40, 17)
        Me.chkFR.TabIndex = 22
        Me.chkFR.Text = "FR"
        Me.chkFR.UseVisualStyleBackColor = False
        '
        'chkDE
        '
        Me.chkDE.AutoSize = True
        Me.chkDE.BackColor = System.Drawing.Color.Transparent
        Me.chkDE.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.chkDE.Location = New System.Drawing.Point(17, 159)
        Me.chkDE.Name = "chkDE"
        Me.chkDE.Size = New System.Drawing.Size(41, 17)
        Me.chkDE.TabIndex = 23
        Me.chkDE.Text = "DE"
        Me.chkDE.UseVisualStyleBackColor = False
        '
        'frmSecond
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.TERA_Launcher.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(734, 417)
        Me.Controls.Add(Me.chkDE)
        Me.Controls.Add(Me.chkFR)
        Me.Controls.Add(Me.chkEN)
        Me.Controls.Add(Me.pbxRepair)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblProgression)
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
        CType(Me.pbxRepair, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pbxPlay As PictureBox
    Private WithEvents pbxInstall As PictureBox
    Friend WithEvents ProgressBar As ProgressBar
    Private WithEvents pbxCancel As PictureBox
    Private WithEvents lblProgression As Label
    Private WithEvents lblUser As Label
    Private WithEvents pbxRepair As PictureBox
    Friend WithEvents chkEN As CheckBox
    Friend WithEvents chkFR As CheckBox
    Friend WithEvents chkDE As CheckBox
End Class
