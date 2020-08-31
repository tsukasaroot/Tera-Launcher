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
        CType(Me.pbxPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxPlay
        '
        Me.pbxPlay.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlay.Image = Global.TERA_Launcher.My.Resources.Resources.start_normal
        Me.pbxPlay.Location = New System.Drawing.Point(244, 278)
        Me.pbxPlay.Name = "pbxPlay"
        Me.pbxPlay.Size = New System.Drawing.Size(257, 107)
        Me.pbxPlay.TabIndex = 13
        Me.pbxPlay.TabStop = False
        '
        'frmSecond
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.TERA_Launcher.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(734, 417)
        Me.Controls.Add(Me.pbxPlay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSecond"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TERA-Launcher"
        CType(Me.pbxPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pbxPlay As PictureBox
End Class
