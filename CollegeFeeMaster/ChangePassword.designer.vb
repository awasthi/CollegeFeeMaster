<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePassword))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrepassword = New System.Windows.Forms.TextBox()
        Me.txtOldpassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtlogin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblReligion = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtpassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtrepassword)
        Me.GroupBox1.Controls.Add(Me.txtOldpassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtlogin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblReligion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(598, 266)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'txtpassword
        '
        Me.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtpassword.Location = New System.Drawing.Point(197, 68)
        Me.txtpassword.MaxLength = 25
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(168, 20)
        Me.txtpassword.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "New Password"
        '
        'txtrepassword
        '
        Me.txtrepassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrepassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtrepassword.Location = New System.Drawing.Point(197, 96)
        Me.txtrepassword.MaxLength = 25
        Me.txtrepassword.Name = "txtrepassword"
        Me.txtrepassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtrepassword.Size = New System.Drawing.Size(168, 20)
        Me.txtrepassword.TabIndex = 36
        '
        'txtOldpassword
        '
        Me.txtOldpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldpassword.Enabled = False
        Me.txtOldpassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtOldpassword.Location = New System.Drawing.Point(197, 44)
        Me.txtOldpassword.MaxLength = 25
        Me.txtOldpassword.Name = "txtOldpassword"
        Me.txtOldpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldpassword.Size = New System.Drawing.Size(168, 20)
        Me.txtOldpassword.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Confirm New password"
        '
        'txtlogin
        '
        Me.txtlogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlogin.Enabled = False
        Me.txtlogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtlogin.Location = New System.Drawing.Point(197, 19)
        Me.txtlogin.MaxLength = 32
        Me.txtlogin.Multiline = True
        Me.txtlogin.Name = "txtlogin"
        Me.txtlogin.Size = New System.Drawing.Size(168, 18)
        Me.txtlogin.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Login Name"
        '
        'lblReligion
        '
        Me.lblReligion.AutoSize = True
        Me.lblReligion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReligion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.lblReligion.Location = New System.Drawing.Point(12, 51)
        Me.lblReligion.Name = "lblReligion"
        Me.lblReligion.Size = New System.Drawing.Size(94, 13)
        Me.lblReligion.TabIndex = 31
        Me.lblReligion.Text = "Old Password"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox2.Controls.Add(Me.lblHeading)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(599, 76)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.No
        Me.lblHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeading.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHeading.Image = CType(resources.GetObject("lblHeading.Image"), System.Drawing.Image)
        Me.lblHeading.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblHeading.Location = New System.Drawing.Point(3, 16)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(593, 57)
        Me.lblHeading.TabIndex = 36
        Me.lblHeading.Text = "Change Password"
        Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(716, 370)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ChangePassword"
        Me.Text = "Change Password"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtrepassword As System.Windows.Forms.TextBox
    Friend WithEvents txtOldpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtlogin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReligion As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblHeading As System.Windows.Forms.Label
End Class
