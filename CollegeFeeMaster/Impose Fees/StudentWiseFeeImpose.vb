Public Class StudentWiseFeeImpose
    Implements IToolStrip
    Dim SECTIONNAME As String
    Dim j As Integer
    Dim cm As SqlClient.SqlCommand
    Dim rd As SqlClient.SqlDataReader
    Dim ad As SqlClient.SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim i As Integer
    Dim DISubject As DataItem
    Dim Acno As String
    Dim savec As Boolean
    Dim T1 As SqlClient.SqlTransaction
    Dim TUpdate As SqlClient.SqlTransaction
    Dim TSave As SqlClient.SqlTransaction
    Dim present As Boolean
    Dim cancelc As Boolean
    Dim TB As System.Data.DataTable
    Dim DiStudent As DataItem
    Dim instituteId As Integer
    Dim UPDATEC As Boolean
    Dim photo
    Dim dss As DataSet
    Dim DIFEEACCOUNT As Dataitem5
    Dim DIFEEACCOUNT1 As Dataitem5
    Dim DIfEE As DataItem
    Sub PrintT() Implements IToolStrip.PrintT
    End Sub
    Sub saveT() Implements IToolStrip.SaveT

        If UPDATEC = False Then
            save()
        Else
            UpdateR()
        End If

    End Sub
    Sub fillT() Implements IToolStrip.FillT
        'Call UploadSection()
    End Sub
  

    Sub UpdateR()





    End Sub

    Sub NewT() Implements IToolStrip.NewT
        ResetForm()
    End Sub


    Function CheckBoxes() As Boolean
        CheckBoxes = True

        If TxtStudentID.Text = "" Then
            MessageBox.Show("Student Id  must be filled")
            CheckBoxes = False
            Exit Function
        End If



    End Function

    Sub save()
        If CheckBoxes() = False Then Exit Sub

        Try
            TSave = cn.BeginTransaction

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'cm = New SqlClient.SqlCommand(sql, cn, TSave)
            'ad = New SqlClient.SqlDataAdapter(cm)
            'ds = New DataSet
            'ad.Fill(ds)

            'If ds.Tables(0).Rows.Count > 0 Then
            '    MessageBox.Show("Record Already Exist")
            '    Exit Sub
            'End If

            'cm = New SqlClient.SqlCommand(sql, cn, TSave)
            'cm.ExecuteNonQuery()
            ''''''''''''''''

            TSave.Commit()
            'FILLLIST()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            TSave.Rollback()
        End Try
    End Sub
    Sub ResetForm()
        Me.UPDATEC = False

        Me.TxtStudentID.Text = ""
        Me.TxtSid.Text = ""
        Me.TxtStudentName.Text = ""
        ' Me.ChKSearchBy.Checked = True
        Me.instituteId = 0

        Me.PictureBox1.ImageLocation = ""

        UPDATEC = False
    End Sub
    Sub Reset()
        Me.UPDATEC = False

        Me.TxtStudentID.Text = ""

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TxtSid.Text = String.Empty Then Exit Sub

        FillStudentInfo()

    End Sub


    Sub RESETSEARCH()
        Me.TxtStudentName.Text = ""
        Me.TxtSid.Tag = ""

        Me.PictureBox1.ImageLocation = ""
        Me.TxtStudentID.Text = ""
        UPDATEC = False
    End Sub

    Sub FillStudentInfo()
        RESETSEARCH()


        If Me.TxtSid.Text = String.Empty Then Exit Sub
        Dim CheckIdType As String
        CheckIdType = Mid(Trim(Me.TxtSid.Text), 1, 2)
        CheckIdType = Mid(Trim(Me.TxtSid.Text), 1, 2)
        If Asc(CheckIdType) >= 48 And Asc(CheckIdType) <= 57 Then
            sql = "SELECT     StudentID, University_RollNo, Student_Name, Father_Name, Lib_code AS photo, PEmail, MobileNumber, ParentContactNumber, Phone,institute,Account_No" _
& "  FROM  V_2009_Section_StudentO    WHERE   (StudentID =" & Me.TxtSid.Text & " ) OR  (University_RollNo = '" & Me.TxtSid.Text & "') and session_id in(select session_id from v_session where isactive=1)"

        Else
            sql = "SELECT     StudentID, University_RollNo, Student_Name, Father_Name, Lib_code AS photo, PEmail, MobileNumber, ParentContactNumber, Phone,institute,Account_No" _
& "  FROM  V_2009_Section_StudentO    WHERE    (University_RollNo = '" & Me.TxtSid.Text & "') or Account_No= '" & Me.TxtSid.Text & "'  and session_id in(select session_id from v_session where isactive=1)"

        End If




    
      

        dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        If dss.Tables(0).Rows.Count = 0 Then Exit Sub
        If IsDBNull(dss.Tables(0).Rows(0).Item(0)) = True Then Exit Sub

        Me.TxtStudentID.Text = dss.Tables(0).Rows(0).Item("StudentiD")
        Me.TxtStudentName.Text = dss.Tables(0).Rows(0).Item("Student_Name")
        Me.TXTAcno.Text = dss.Tables(0).Rows(0).Item("Account_No")
        '  Me.TxtUniversityRollNumber.Text = dss.Tables(0).Rows(0).Item("Student_Name")
        Me.TxtSid.Tag = dss.Tables(0).Rows(0).Item("StudentID")
        Me.TxtStudentID.Tag = dss.Tables(0).Rows(0).Item("StudentID")
        instituteId = dss.Tables(0).Rows(0).Item("Institute")
        If IsDBNull(dss.Tables(0).Rows(0).Item("photo")) = False Then
            photo = dss.Tables(0).Rows(0).Item("photo")
        End If
        dss.Dispose()
        dss.Clear()
        '   UPDATEC = True
        Acno = TXTAcno.Text.Trim
        Call fillpicturebox()
        FillStudentMarks()
    End Sub
    Sub fillpicturebox()
        Dim strPathName As String
        If Me.TxtSid.Text = String.Empty Then Exit Sub
        strPathName = "http://www.psit.in/ProjectCollege/student/images/"
        Dim strFullPath As String
        strFullPath = strPathName & CStr(photo) & ".jpg"
        Me.PictureBox1.ImageLocation = strFullPath
    End Sub

    Sub FillStudentMarks()

        '    sql = "SELECT    Date, cast(Voucher_Id as varchar) + ' ' + Particular as Particulars, " _
        '& " LoginSessionId, Fee_Type_Name,  dramount as DR, Amount as CR" _
        '& " FROM V_Transaction_Datewise WHERE Account_No = '" & Me.Acno & "' and session_id=9 ORDER BY Voucher_Id DESC"
        sql = "SELECT Transaction_Id,   Date, Voucher_Id, By_account_No, Particular as Particulars, " _
    & " LoginSessionId, dr_amount as DR, cr_Amount as CR" _
    & " FROM V_Fee_Transacriot_2011 WHERE Account_No = '" & Me.Acno & "' and session_id=9 ORDER BY Voucher_Id DESC"

        dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        DataGridView1.DataSource = dss.Tables(0)

        '        sql = "SELECT     Account_No, 0 as Refund ,  SUM(Dr_Amount)  AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance " _
        '            & " FROM V_Fee_Transacriot_2011 " _
        '            & " WHERE        (By_Account_No <> '0000010')" _
        '& " GROUP BY Account_No Having Account_No = '" & Me.Acno & "'" _
        '            & " UNION SELECT     Account_No, 0 as Refund ,  SUM(Dr_Amount)  AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance " _
        '            & " FROM V_Fee_Transacriot_2011 " _
        '            & " WHERE        (By_Account_No = '0000010')" _
        '& " GROUP BY Account_No Having Account_No = '" & Me.Acno & "'"
        sql = "SELECT        Account_No, SUM(Refund) as Refund, SUM(Dr) as Dr, SUM(Cr) as Cr, SUM(Balance) as Balance" _
            & " FROM            (SELECT        Account_No, SUM(Dr_Amount) AS Refund, 0 AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance" _
            & " FROM V_Fee_Transacriot_2011  WHERE        (By_Account_No = '0000010')" _
            & " GROUP BY Account_No  UNION  SELECT        Account_No, 0 AS Refund, SUM(Dr_Amount) AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance" _
            & " FROM            V_Fee_Transacriot_2011 AS V_Fee_Transacriot_2011_1    WHERE        (By_Account_No <> '0000010')" _
            & " GROUP BY Account_No) AS Tmp GROUP BY Account_No Having Account_No = '" & Me.Acno & "'"


        '        sql = "SELECT     Account_No, case when by_account_no='0000010' Then SUM(Dr_Amount) Else 0 END  AS Refund , case when NOT(by_account_no='0000010') Then SUM(Dr_Amount) Else 0 END  AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance " _
        '           & " FROM V_Fee_Transacriot_2011 " _
        '& " GROUP BY Account_No Having Account_No = '" & Me.Acno & "'"
        dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        DataGridView2.DataSource = dss.Tables(0)
    End Sub
    


    Private Sub TxtSid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSid.KeyPress
        'If Me.TxtSid.Text = String.Empty Then Exit Sub
        'If Me.TxtSid.Text = "" Then Exit Sub
        'If Asc(e.KeyChar) = 13 Then
        '    Button1_Click(Nothing, Nothing)
        'End If
        If Asc(e.KeyChar) = 13 Then
            If Me.TxtSid.Text = String.Empty Then Exit Sub
            If Me.TxtSid.Text = String.Empty Then Exit Sub
            FillStudentInfo()
        End If
    End Sub

   
   


    Sub FILLACCOUNT()
        Me.cboAccount.Items.Clear()
        sql = "SELECT        Account_No, Account_Holder_Name  FROM   M_Finance_Account" _
            & " WHERE      Account_No LIKE '0%'"
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        Me.cboAccount.Items.Add("--Select--")
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.cboAccount.Items.Add(New Dataitem5(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
        Next
        Me.cboAccount.SelectedIndex = 0

    End Sub
    Private Sub StudentWiseFeeImpose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        FILLACCOUNT()


    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        If Me.cboAccount.SelectedIndex = 0 Or Me.cboAccount.SelectedIndex = -1 Then Exit Sub
        Me.DIFEEACCOUNT = Me.cboAccount.SelectedItem

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If Me.rdImpose.Checked = True Then
            FeeImpose()
        End If

        If Me.rdReceive.Checked = True Then

        End If

    End Sub

    Sub FeeImpose()
        Try

            Dim draccountno = Acno
            Dim USER = "Devesh"

            Dim cm As SqlClient.SqlCommand = New SqlClient.SqlCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "TransactImpose"
            cm.Connection = cn
            cm.Parameters.Add("@feetype", SqlDbType.Int)
            cm.Parameters("@feetype").Value = 1
            cm.Parameters.Add("@draccountno", SqlDbType.NVarChar)
            cm.Parameters("@draccountno").Value = Me.DIFEEACCOUNT.Get_Id

            cm.Parameters.Add("@craccountno", SqlDbType.NVarChar)
            cm.Parameters("@craccountno").Value = draccountno

            cm.Parameters.Add("@amount", SqlDbType.Money)
            cm.Parameters("@amount").Value = Me.TXTAmount.Text

            cm.Parameters.Add("@part", SqlDbType.NVarChar)
            cm.Parameters("@part").Value = " Net Fee "

            cm.Parameters.Add("@loginsessionid", SqlDbType.NVarChar)
            cm.Parameters("@loginsessionid").Value = USER



            cm.Parameters.Add("@inst", SqlDbType.Int)
            cm.Parameters("@inst").Value = instituteId
            cm.Parameters.Add("@session", SqlDbType.Int)
            cm.Parameters("@session").Value = 9

            cm.ExecuteNonQuery()

            MessageBox.Show("Fee Imposed")
            FillStudentMarks()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Sub FeeReceive()


    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

   

 

   
    Private Sub DataGridView1_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Me.Cursor = Cursors.WaitCursor

        Dim c, r As Integer

        r = Me.DataGridView1.CurrentRow.Index
        If CStr(Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value) <> String.Empty Then
            Dim voucher_id = Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value
            Dim cracc = Me.DataGridView1.Rows(r).Cells("By_Account_No").Value
            Dim dracc = Acno

            sql = "UPDATE     M_Fee_Transaction_Impose " _
& " SET  dr_Amount = '" & Me.DataGridView1.Rows(r).Cells("DR").Value & "' " _
& " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & dracc & "' "

            Dim sql2 = "UPDATE     M_Fee_Transaction_Impose " _
& " SET  CR_Amount = '" & Me.DataGridView1.Rows(r).Cells("CR").Value & "' " _
& " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & cracc & "' "


            cm = New SqlClient.SqlCommand(sql, cn)
            cm.ExecuteNonQuery()
            cm = New SqlClient.SqlCommand(sql2, cn)
            cm.ExecuteNonQuery()

        End If


        Me.Cursor = Cursors.Default

    End Sub
End Class