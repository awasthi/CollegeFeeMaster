Public Class LoginForm
    Inherits System.Windows.Forms.Form
    ''College Master
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LBLInstituteName1 As System.Windows.Forms.Label
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInstituteName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.LBLInstituteName1 = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblInstituteName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLInstituteName1
        '
        Me.LBLInstituteName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLInstituteName1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LBLInstituteName1.Location = New System.Drawing.Point(200, 330)
        Me.LBLInstituteName1.Name = "LBLInstituteName1"
        Me.LBLInstituteName1.Size = New System.Drawing.Size(278, 24)
        Me.LBLInstituteName1.TabIndex = 27
        Me.LBLInstituteName1.Text = "Pranveer Singh Institute of Technology"
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.No
        Me.lblHeading.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHeading.Image = CType(resources.GetObject("lblHeading.Image"), System.Drawing.Image)
        Me.lblHeading.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeading.Location = New System.Drawing.Point(-2, -2)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(528, 56)
        Me.lblHeading.TabIndex = 28
        Me.lblHeading.Text = "College Fee Manager"
        Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(0, 354)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(525, 9)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        '
        'lblInstituteName
        '
        Me.lblInstituteName.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstituteName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInstituteName.Location = New System.Drawing.Point(8, 66)
        Me.lblInstituteName.Name = "lblInstituteName"
        Me.lblInstituteName.Size = New System.Drawing.Size(387, 21)
        Me.lblInstituteName.TabIndex = 31
        Me.lblInstituteName.Text = "Pranveer Singh Institute Of Technology"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(201, 308)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Developed By:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Powered By:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblLogin)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(102, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 122)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Login !!!"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(102, 42)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(169, 21)
        Me.txtPassword.TabIndex = 1
        '
        'txtLogin
        '
        Me.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtLogin.Location = New System.Drawing.Point(102, 15)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(169, 21)
        Me.txtLogin.TabIndex = 0
        Me.txtLogin.Text = "admin"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(207, 86)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 21)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(137, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(10, 44)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(69, 16)
        Me.lblPassword.TabIndex = 11
        Me.lblPassword.Text = "Password"
        '
        'lblLogin
        '
        Me.lblLogin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.lblLogin.Location = New System.Drawing.Point(10, 20)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(86, 16)
        Me.lblLogin.TabIndex = 21
        Me.lblLogin.Text = "Login Name"
        '
        'LoginForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(525, 363)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblInstituteName)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.LBLInstituteName1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "College Fee Manager"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim cm As SqlClient.SqlCommand
    Dim rd As SqlClient.SqlDataReader
    Dim ad As SqlClient.SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim i As Integer
    Dim DISession As DataItem3


    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.lblInstituteName.Text = InstitueName
        'Me.LBLInstituteName1.Text = InstitueName
        Me.txtLogin.Focus()
        'SessionUpload()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Button1_Click_1(Nothing, Nothing)
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
        MdIFORM.Dispose()
        MdIFORM.Close()
    End Sub

    Private Sub txtLogin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.txtLogin.Text = StrConv(Me.txtLogin.Text, VbStrConv.ProperCase)
        'Me.txtPassword.Text = StrConv(Me.txtPassword.Text, VbStrConv.ProperCase)
    End Sub
    'Sub SessionUpload()

    '    Me.CboSession.Items.Clear()

    '    sql = "Select Session_Id,Section_set_Active,Session_Name + ' ' + isnull(Remark,'')  as Session_Name  From M_session"
    '    ad = New SqlClient.SqlDataAdapter(sql, cn)

    '    ds = New DataSet
    '    ad.Fill(ds)
    '    If ds.Tables(0).Rows.Count = 0 Then Exit Sub
    '    For i = 0 To ds.Tables(0).Rows.Count - 1

    '        Me.CboSession.Items.Add(New DataItem3(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2)))

    '    Next

    'End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub CboSession_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboSession_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.DISession = Me.CboSession.SelectedItem
        'SessionID = DISession.Get_Id1
        'SessionSelected = Me.DISession.Get_Value
        'MDIForm.ToolStripStatusLabel1.Text = SessionSelected

        'SessionSetActive = DISession.Get_Id2
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim l As String
        l = Me.txtLogin.Text

        If Me.txtLogin.Text = "" Or Me.txtPassword.Text = "" Then
            UserID = 0
            MessageBox.Show("Invalid UserName or Password ! Try Again")
            Me.Dispose()
            Me.Close()
            Menu.Dispose()
            MdIFORM.Close()

            MdIFORM.ShowDialog()

            Me.txtLogin.Text = ""
            Me.txtPassword.Text = ""
            Me.txtLogin.Focus()
        End If
        'If Me.CboSession.SelectedIndex = -1 Then
        '    UserID = 0
        '    MessageBox.Show("Select Session ! Try Again")
        '    Me.Dispose()
        '    Me.Close()
        '    MDIForm.Dispose()
        '    MDIForm.Close()

        '    MDIForm.ShowDialog()

        '    'Me.txtLogin.Text = ""
        '    ' Me.txtPassword.Text = ""
        '    Me.txtLogin.Focus()

        'End If

        'sql = "select * from E_User_master " _
        '& " where Login = '" & Trim(StrConv(Me.txtLogin.Text, VbStrConv.ProperCase)) & "' " _
        '& " and   Password = '" & Trim(StrConv(Me.txtPassword.Text, VbStrConv.ProperCase)) & "' "

        sql = "select * from FEE_User_Master " _
       & " where Login = '" & Trim(Me.txtLogin.Text) & "' " _
       & " and   Password = '" & Trim(Me.txtPassword.Text) & "' "

        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            UserID = ds.Tables(0).Rows(0).Item(0)
            'MDIForm.HideModules()
            ' MDIForm.ShowModules()
            Me.Dispose()
            Me.Close()
        Else
            UserID = 0
            MessageBox.Show("Invalid UserName or Password ! Try Again")
            Me.Dispose()
            Me.Close()
            MdIFORM.Dispose()
            MdIFORM.Close()

            Me.txtLogin.Text = ""
            Me.txtPassword.Text = ""
            Me.txtLogin.Focus()
        End If

    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
        Me.Close()
        MdIFORM.Dispose()

    End Sub

  
End Class
