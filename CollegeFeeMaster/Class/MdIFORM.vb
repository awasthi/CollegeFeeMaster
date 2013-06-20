Public Class MdIFORM

    Private Sub Menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginForm.ShowDialog(Me)
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If (Me.ActiveMdiChild IsNot Nothing) Then
            Dim frmActiveform As IToolStrip = Me.ActiveMdiChild
            frmActiveform.SaveT()
        End If
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If (Me.ActiveMdiChild IsNot Nothing) Then
            Dim frmActiveform As IToolStrip = Me.ActiveMdiChild
            frmActiveform.PrintT()
        End If
    End Sub



    Private Sub ImposeFeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImposeFeeToolStripMenuItem.Click
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        Me.ToolStripButton3.Enabled = False
        'InstituteMasterToolStripMenuItem.Enabled = False
        Dim f As New ImposeFee
        f.MdiParent() = Me
        f.Show()
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If (Me.ActiveMdiChild IsNot Nothing) Then
            Dim frmActiveform As IToolStrip = Me.ActiveMdiChild
            frmActiveform.NewT()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Do While (Me.ActiveMdiChild IsNot Nothing)

            If (Me.ActiveMdiChild IsNot Nothing) Then

                Dim Aform As System.Windows.Forms.Form

                Aform = Me.ActiveMdiChild

                Aform.Close()
            End If
        Loop
        Dim f As New LoginForm
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ImposeStudentwiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImposeStudentwiseToolStripMenuItem.Click
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        Me.ToolStripButton3.Enabled = False
        'InstituteMasterToolStripMenuItem.Enabled = False
        Dim f As New StudentWiseFeeImpose
        f.MdiParent() = Me
        f.Show()
    End Sub

    Private Sub FeeDueReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeeDueReportToolStripMenuItem.Click
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        Me.ToolStripButton3.Enabled = False
        'InstituteMasterToolStripMenuItem.Enabled = False
        Dim f As New FeeDueReport
        f.MdiParent() = Me
        f.Show()
    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        Me.ToolStripButton3.Enabled = False
        'InstituteMasterToolStripMenuItem.Enabled = False
        Dim f As New MySetting
        f.MdiParent() = Me
        f.Show()
    End Sub
End Class