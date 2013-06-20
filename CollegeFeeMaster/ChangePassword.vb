Public Class ChangePassword
    Inherits System.Windows.Forms.Form
    Implements IToolStrip
    Dim cm As SqlClient.SqlCommand
    Dim rd As SqlClient.SqlDataReader
    Dim ds As DataSet
    Dim ad As SqlClient.SqlDataAdapter
    Dim Sql As String
    Dim T1 As SqlClient.SqlTransaction
    Sub fillt() Implements IToolStrip.FillT

    End Sub

    Sub FillLoginName()
        Dim i As Integer
        Sql = "select * from lab_User_Master WHERE ID = " & UserID & ""
        ad = New SqlClient.SqlDataAdapter(Sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        Me.txtlogin.Text = ds.Tables(0).Rows(0).Item("Login")
        Me.txtlogin.Tag = ds.Tables(0).Rows(0).Item("ID")
        'Me.txtOldpassword.Text = ds.Tables(0).Rows(0).Item("Password")
    End Sub
    Sub printt() Implements IToolStrip.PrintT

    End Sub

    Sub Savet() Implements IToolStrip.SaveT
        save()
    End Sub
    Sub Newt() Implements IToolStrip.NewT
        reset()
    End Sub

    Sub save()

        Try

            'If Me.txtlogin.Tag = String.Empty Then Exit Sub
            If Me.txtlogin.Text = String.Empty Then Exit Sub
            ' If Me.txtOldpassword.Text = "" Then Exit Sub
            If Me.txtpassword.Text = "" Then Exit Sub
            If Me.txtrepassword.Text = "" Then Exit Sub
            If Me.txtpassword.Text <> Me.txtrepassword.Text Then
                MessageBox.Show(" New Password not Match Confirm Password")
                Exit Sub
            End If
            Sql = " update lab_User_Master set Password = '" & Trim(Me.txtpassword.Text) & "' where ID = " & UserID & " "
            cm = New SqlClient.SqlCommand(Sql, cn, T1)
            cm.ExecuteNonQuery()
            MessageBox.Show("Password Changed")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub ChangePassword_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'MDIForm.ChangePasswordToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Call Me.FillLoginName()
    End Sub
    Sub reset()
        Me.txtpassword.Text = ""
        Me.txtOldpassword.Text = ""
        Me.txtlogin.Text = ""
        Me.txtrepassword.Text = "'"
    End Sub


End Class