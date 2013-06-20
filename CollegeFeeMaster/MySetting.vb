Public Class MySetting
    Sub save()
        If checkboxes() = False Then Exit Sub
        My.Settings.DataSourceName = Me.txtServerName.Text
        My.Settings.DataBaseName = Me.Txtdatabase.Text
        My.Settings.UserID1 = Me.txtUserID.Text
        My.Settings.Password = Me.txtpassword.Text
        My.Settings.Save()
        MessageBox.Show("Configuration Saved")
    End Sub


    Function checkboxes() As Boolean
        checkboxes = True
        'If Me.TxtAddress.Text = "" Then
        '    MessageBox.Show("fill address")
        '    checkboxes = False
        '    Exit Function
        'End If
        If Me.Txtdatabase.Text = "" Then
            MessageBox.Show("fill database")
            checkboxes = False
            Exit Function

        End If
        If Me.txtServerName.Text = "" Then
            MessageBox.Show("Fill ServerName")
            checkboxes = False
            Exit Function

        End If
        If Me.txtUserID.Text = "" Then
            MessageBox.Show("fill UserID")
            checkboxes = False
            Exit Function
        End If
        If Me.txtpassword.Text = "" Then
            MessageBox.Show("fill password")
            checkboxes = False
            Exit Function

        End If


        'If Me.TxtInstituteName.Text = "" Then

        '    MessageBox.Show("fill InstituteName")
        '    checkboxes = False
        '    Exit Function

        'End If
        checkboxes = checkboxes

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        save()
    End Sub

    Private Sub MySetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Normal
        'Me.Txtdatabase.Text = My.Settings.DataBaseName
        'Me.txtpassword.Text = My.Settings.Password
        'Me.txtServerName.Text = My.Settings.DataSourceName
        'Me.txtUserID.Text = My.Settings.UserID1
        Me.TxtAddress.Enabled = True
        Me.Txtdatabase.Enabled = True
        Me.TxtInstituteName.Enabled = True
        Me.txtpassword.Enabled = True
        Me.txtServerName.Enabled = True
        Me.txtUserID.Enabled = True
    End Sub
End Class