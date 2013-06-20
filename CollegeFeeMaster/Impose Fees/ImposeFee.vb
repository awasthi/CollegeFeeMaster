Public Class ImposeFee

    

    Implements IToolStrip
    Dim cm As SqlClient.SqlCommand
    Dim rd As SqlClient.SqlDataReader
    Dim ad As SqlClient.SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim UpdateC As Boolean
    Dim ret As Integer
    Dim i As Integer
    Dim tb As DataTable
    Dim DISessionO As DataItem3
    Dim DISessionN As DataItem3
    Dim DISection As DataItem
    Dim DIFEEACCOUNT As Dataitem5
    Dim DIInstitute As DataItem
    Public Sub FillT() Implements IToolStrip.FillT

    End Sub

    Public Sub NewT() Implements IToolStrip.NewT

    End Sub

    Public Sub PrintT() Implements IToolStrip.PrintT

    End Sub

    Public Sub SaveT() Implements IToolStrip.SaveT
        If Me.UpdateC = False Then
            Call save()
        Else
            Call UpdateR()
        End If
    End Sub

    Private Sub ImposeFee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized

        InstituteFill()
        SessionUpload()
        FILLACCOUNT()
    End Sub

    Sub SessionUpload()
        sql = "Select Session_Id,Section_set_Active,Session_Name + ' ' + isnull(Remark,'')  as Session_Name  From V_Session ORDER BY Session_id Desc"
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.CboSession.Items.Add(New DataItem3(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2)))
            '   Me.CboNewSESSION.Items.Add(New DataItem3(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2)))
        Next
    End Sub

    Private Sub CboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSection.SelectedIndexChanged
      

        If Me.CboSection.SelectedIndex = -1 Or Me.CboSection.SelectedIndex = 0 Then Exit Sub
        DISection = Me.CboSection.SelectedItem

    End Sub

    Sub SectionFill()
        If Me.CboInstitute.SelectedIndex = -1 Or Me.CboSession.SelectedIndex = -1 Then Exit Sub



        Me.CboSection.Items.Clear()
        'sql = "SELECT Section_Id, Section_Name FROM         M_Section    WHERE  section_set = " & Section_Set_Active & " and institute=" & Me.DIInstitute.Get_Id
        sql = "SELECT Section_Id, Section_Name FROM       V_Section    WHERE  section_set = " & DISessionO.Get_Id2 & " and institute=" & Me.DIInstitute.Get_Id & "  order by Section_Name "
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        Me.CboSection.Items.Add("--Select--")
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.CboSection.Items.Add(New DataItem(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
        Next
        Me.CboSection.SelectedIndex = 0
    End Sub

    Private Sub CboSession_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSession.SelectedIndexChanged
        If Me.CboSession.SelectedIndex = -1 Then Exit Sub
        Me.DISessionO = Me.CboSession.SelectedItem
        SectionFill()
        UploadSectionLIST()
    End Sub

    Sub FillStudent()


        If Me.CBOFEEACCOUNT.SelectedIndex = -1 Then Exit Sub


        Dim sectionidstring = ""

        For i = 0 To Me.Lvwsection.Items.Count - 1

            If Me.Lvwsection.Items(i).Checked = True Then
                If sectionidstring = "" Then
                    sectionidstring = CStr(Me.Lvwsection.Items(i).SubItems(1).Text)
                Else
                    sectionidstring = sectionidstring & "," & CStr(Me.Lvwsection.Items(i).SubItems(1).Text)
                End If
            End If

        Next


        If sectionidstring = String.Empty Then Exit Sub






        '     sql = "  SELECT        V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
        '                       & "  SUM(M_Fee_Transaction_Impose.Dr_Amount) AS Amount, V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No " _
        '& " FROM            M_Fee_Transaction_Impose RIGHT OUTER JOIN " _
        '                      & "   V_2009_Section_StudentO ON M_Fee_Transaction_Impose.Account_No = V_2009_Section_StudentO.Account_No AND  " _
        '                       & "  M_Fee_Transaction_Impose.session_id = V_2009_Section_StudentO.Session_Id " _
        '& " WHERE        (V_2009_Section_StudentO.Session_Id = " & DISessionO.Get_Id1 & ") AND (V_2009_Section_StudentO.Section_Id = " & DISection.Get_Id & ")" _
        '      & " GROUP BY V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
        '                          & "     V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No " _
        '      & " HAVING        (M_Fee_Transaction_Impose.By_Account_No = '" & DIFEEACCOUNT.Get_Id & "') OR " _
        '                            & "   (M_Fee_Transaction_Impose.By_Account_No IS NULL) order by Student_Name"


        Dim session = Me.DISessionO.Get_Id1
        If Session Mod 2 = 0 Then

            session = session - 1

        Else

            session = session

        End If

        sql = "  SELECT        V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
                          & "  SUM(M_Fee_Transaction_Impose.Dr_Amount) AS Amount, V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, M_Fee_Transaction_Impose.Voucher_Id " _
   & " FROM            M_Fee_Transaction_Impose RIGHT OUTER JOIN " _
                         & "   V_2009_Section_StudentO ON M_Fee_Transaction_Impose.Account_No = V_2009_Section_StudentO.Account_No AND  " _
                          & "  M_Fee_Transaction_Impose.session_id = V_2009_Section_StudentO.fId " _
   & " WHERE        (V_2009_Section_StudentO.Session_Id = " & DISessionO.Get_Id1 & ") AND (V_2009_Section_StudentO. Section_Id in (" & sectionidstring & " )) " _
         & " GROUP BY V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
                             & "     V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, M_Fee_Transaction_Impose.Voucher_Id  " _
     & " HAVING        (M_Fee_Transaction_Impose.By_Account_No = '" & DIFEEACCOUNT.Get_Id & "') OR " _
                               & "   (M_Fee_Transaction_Impose.By_Account_No IS NULL) order by Student_Name"


        '     sql = "  SELECT        V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
        '                       & "  SUM(M_Fee_Transaction_Impose.Dr_Amount) AS Amount, V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, M_Fee_Transaction_Impose.Voucher_Id " _
        '& " FROM            M_Fee_Transaction_Impose RIGHT OUTER JOIN " _
        '                      & "   V_2009_Section_StudentO ON M_Fee_Transaction_Impose.Account_No = V_2009_Section_StudentO.Account_No AND  " _
        '                       & "  M_Fee_Transaction_Impose.session_id = V_2009_Section_StudentO.Session_Id " _
        '& " WHERE        (V_2009_Section_StudentO.Session_Id = " & DISessionO.Get_Id1 & ") AND (V_2009_Section_StudentO.StudentID IN                             (SELECT        StudentID    FROM            V_2009_Bus_Allocation_List)) " _
        '      & " GROUP BY V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
        '                          & "     V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, M_Fee_Transaction_Impose.Voucher_Id  " _
        '  & " HAVING        (M_Fee_Transaction_Impose.By_Account_No = '" & DIFEEACCOUNT.Get_Id & "') OR " _
        '                            & "   (M_Fee_Transaction_Impose.By_Account_No IS NULL) order by Student_Name"


        sql = "    SELECT        V_2009_Section_StudentO_1.University_RollNo, V_2009_Section_StudentO_1.Student_Name, V_2009_Section_StudentO_1.Account_No, temp.Amount, " _
                            & "  V_2009_Section_StudentO_1.StudentID, temp.By_Account_No, temp.Voucher_Id " _
                          & "    " _
    & "  FROM            (SELECT        TOP (100) PERCENT V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
                                                      & "   SUM(M_Fee_Transaction_Impose.Dr_Amount) AS Amount, V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, " _
                                                    & "     M_Fee_Transaction_Impose.Voucher_Id " _
                           & "    FROM            M_Fee_Transaction_Impose RIGHT OUTER JOIN " _
                                                    & "     V_2009_Section_StudentO ON M_Fee_Transaction_Impose.Account_No = V_2009_Section_StudentO.Account_No AND  " _
                                                     & "    M_Fee_Transaction_Impose.session_id = V_2009_Section_StudentO.fid " _
                             & "  WHERE        (V_2009_Section_StudentO.Session_Id = " & DISessionO.Get_Id1 & ") AND (V_2009_Section_StudentO.Section_Id IN (" & sectionidstring & ")) " _
                             & "  GROUP BY V_2009_Section_StudentO.University_RollNo, V_2009_Section_StudentO.Student_Name, V_2009_Section_StudentO.Account_No, " _
                                                     & "    V_2009_Section_StudentO.StudentID, M_Fee_Transaction_Impose.By_Account_No, M_Fee_Transaction_Impose.Voucher_Id " _
                             & "  HAVING         (M_Fee_Transaction_Impose.By_Account_No = '" & DIFEEACCOUNT.Get_Id & "') " _
                             & "  ORDER BY V_2009_Section_StudentO.Student_Name) AS temp RIGHT OUTER JOIN " _
                           & "   V_2009_Section_StudentO AS V_2009_Section_StudentO_1 ON temp.StudentID = V_2009_Section_StudentO_1.Student_Id " _
    & " WHERE        (V_2009_Section_StudentO_1.Section_Id IN (" & sectionidstring & " )) AND (V_2009_Section_StudentO_1.Session_Id = " & DISessionO.Get_Id1 & ") "


        sql = " SELECT        V_Section_Student.University_RollNo, V_Section_Student.Student_Name, V_Section_Student.Account_No, 0 AS Amount, V_Section_Student.StudentID, " _
       & "      '0000001' AS By_Account_No, V_Section_Student.Session_Id, M_Fee_Transactionpdp.Voucher_Id" _
& " FROM            M_Fee_Transactionpdp INNER JOIN " _
                     & "    V_Section_Student ON M_Fee_Transactionpdp.Account_No = V_Section_Student.Account_No" _
& " WHERE        (M_Fee_Transactionpdp.session_id = 9) AND (V_Section_Student.Session_Id = 9)"


        ' Section_Id in (" & sectionidstring & " )"
        Me.Cursor = Cursors.WaitCursor
        tb = GetDataset(sql)
        Me.DataGridView1.DataSource = tb
        Check()

        'For i = 0 To Me.DataGridView1.Rows.Count - 1

        '    Me.DataGridView1.Rows(i).Cells(0).Value = True


        'Next

        AutoNumberRows(Me.DataGridView1)

        Me.Cursor = Cursors.Default


    End Sub
    Public Sub AutoNumberRows(ByVal oControl As DataGridView)
        Dim nElement As Integer
        With oControl.Rows
            For nElement = 0 To oControl.Rows.Count - 1
                oControl.Rows(nElement).HeaderCell.Value = Format(nElement + 1, "0")

            Next
        End With
    End Sub
    
    Sub Check()
        For i = 0 To Me.DataGridView1.Rows.Count - 1
            

            If IsDBNull(DataGridView1.Rows(i).Cells("Amount").Value) = True Then

                Me.DataGridView1.Rows(i).Cells(0).Value = True
            End If

        Next

    End Sub





    Sub FILLACCOUNT()
        Me.CBOFEEACCOUNT.Items.Clear()
        sql = "SELECT        Account_No, Account_Holder_Name  FROM   M_Finance_Account" _
            & " WHERE      Account_No LIKE '0%'"
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        Me.CBOFEEACCOUNT.Items.Add("--Select--")
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.CBOFEEACCOUNT.Items.Add(New Dataitem5(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
        Next
        Me.CBOFEEACCOUNT.SelectedIndex = 0

    End Sub
    Sub InstituteFill()
        Me.CboInstitute.Items.Clear()
        sql = "SELECT     *  FROM         M_Institute "
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.CboInstitute.Items.Add(New DataItem(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
        Next
        Me.CboInstitute.SelectedIndex = 0
    End Sub
    Private Sub CBOFEEACCOUNT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBOFEEACCOUNT.SelectedIndexChanged
        If Me.CBOFEEACCOUNT.SelectedIndex = 0 Or Me.CBOFEEACCOUNT.SelectedIndex = -1 Then Exit Sub
        Me.DIFEEACCOUNT = Me.CBOFEEACCOUNT.SelectedItem
        FillStudent()
    End Sub

    Sub save()
        Me.Cursor = Cursors.WaitCursor
        Dim feetype
        Try

            sql = "SELECT        Account_No, Account_Holder_Name,feetype  FROM   M_Finance_Account" _
               & " WHERE      Account_No ='" & Me.DIFEEACCOUNT.Get_Id & "'"


            ad = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            ad.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                feetype = 0
            Else
                If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = False Then
                    feetype = ds.Tables(0).Rows(0).Item(2)
                Else
                    feetype = 0
                End If

            End If
           

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                If Me.DataGridView1.Rows(i).Cells(0).Value = True Then


                    Dim draccountno = Me.DataGridView1.Rows(i).Cells("Account_No").Value
                    Dim USER = "Devesh"

                    Dim cm As SqlClient.SqlCommand = New SqlClient.SqlCommand
                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = "TransactImpose"
                    cm.Connection = cn
                    cm.Parameters.Add("@feetype", SqlDbType.Int)
                    cm.Parameters("@feetype").Value = feetype
                    cm.Parameters.Add("@draccountno", SqlDbType.NVarChar)
                    cm.Parameters("@draccountno").Value = Me.DIFEEACCOUNT.Get_Id

                    cm.Parameters.Add("@craccountno", SqlDbType.NVarChar)
                    cm.Parameters("@craccountno").Value = draccountno

                    cm.Parameters.Add("@amount", SqlDbType.Money)
                    cm.Parameters("@amount").Value = Me.TxtAmount.Text

                    cm.Parameters.Add("@part", SqlDbType.NVarChar)
                    cm.Parameters("@part").Value = " Net Fee "

                    cm.Parameters.Add("@loginsessionid", SqlDbType.NVarChar)
                    cm.Parameters("@loginsessionid").Value = USER



                    cm.Parameters.Add("@inst", SqlDbType.Int)
                    cm.Parameters("@inst").Value = DIInstitute.Get_Id
                    cm.Parameters.Add("@session", SqlDbType.Int)
                    cm.Parameters("@session").Value = 11

                    cm.ExecuteNonQuery()
                    ' cnt = cm.Parameters("@ret").Value
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
        FillStudent()
        MessageBox.Show("Fees Imposed")
        Me.Cursor = Cursors.Default
    End Sub
    Sub UploadSectionLIST()
        If Me.CboInstitute.SelectedIndex = -1 Then Exit Sub
        Me.Lvwsection.Items.Clear()
        Me.CboSection.Items.Clear()
        sql = "Select * From M_Section where institute= " & DIInstitute.Get_Id & " and section_set =" & Section_Set_Active & " "
        sql = "SELECT Section_Id, Section_Name FROM       V_Section    WHERE  section_set = " & DISessionO.Get_Id2 & " and institute=" & Me.DIInstitute.Get_Id & "  order by Section_Name "

        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        'For i = 0 To ds.Tables(0).Rows.Count - 1
        '    Me.CboSection.Items.Add(New DataItem(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(2)))
        'Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.Lvwsection.Items.Clear()
        Dim olist As New ListViewItem
        For i = 0 To ds.Tables(0).Rows.Count - 1
            olist = Me.Lvwsection.Items.Add("")
            olist.SubItems.Add(ds.Tables(0).Rows(i).Item(0))
            olist.SubItems.Add(ds.Tables(0).Rows(i).Item(1))
        Next
    End Sub


    Sub UpdateR()

        Try

            If checkboxes() = False Then Exit Sub
           

            ret = ExecuteQuery(sql)
            MessageBox.Show("record updated succefully")




        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Sub ResetForm()
        UpdateC = False
        Me.CboSection.SelectedIndex = -1
        Me.CboSession.SelectedIndex = -1
        Me.CboSection.SelectedIndex = -1
        Me.CBOFEEACCOUNT.SelectedIndex = 0
        Me.TxtAmount.Text = 0
    End Sub

    Sub Reset()
        UpdateC = False
        Me.CboSection.SelectedIndex = -1


    End Sub

    Function checkboxes() As Boolean

        checkboxes = True
        If Me.CboSection.SelectedIndex = -1 Then
            MessageBox.Show("Select Section ")
            checkboxes = False
            Exit Function
        End If

        If Me.CBOFEEACCOUNT.SelectedIndex = -1 Or Me.CBOFEEACCOUNT.SelectedIndex = 0 Then
            MessageBox.Show("Select Fee Account")
            checkboxes = False
            Exit Function
        End If
        Return checkboxes


    End Function

    Private Sub CboInstitute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboInstitute.SelectedIndexChanged
        If Me.CboInstitute.SelectedIndex = -1 Then Exit Sub
        Me.DIInstitute = Me.CboInstitute.SelectedItem


        SectionFill()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        On Error Resume Next

        Me.Cursor = Cursors.WaitCursor

        Dim c, r As Integer

        r = Me.DataGridView1.CurrentRow.Index
        If CStr(Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value) <> String.Empty Then
            Dim voucher_id = Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value
            Dim cracc = Me.DIFEEACCOUNT.Get_Id
            Dim dracc = Me.DataGridView1.Rows(r).Cells("Account_No").Value

            sql = "UPDATE     M_Fee_Transaction_Impose " _
& " SET  dr_Amount = '" & Me.DataGridView1.Rows(r).Cells("Amount").Value & "' " _
& " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & dracc & "' "

            Dim sql2 = "UPDATE     M_Fee_Transaction_Impose " _
& " SET  CR_Amount = '" & Me.DataGridView1.Rows(r).Cells("Amount").Value & "' " _
& " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & cracc & "' "


            cm = New SqlClient.SqlCommand(sql, cn)
            cm.ExecuteNonQuery()
            cm = New SqlClient.SqlCommand(sql2, cn)
            cm.ExecuteNonQuery()

        End If


        Me.Cursor = Cursors.Default

    End Sub



    Sub UPDATEIMPOSED()
        Try
            Dim cmarks As Integer
            Dim value As Integer
            Dim r As Integer
            value = Me.DataGridView1.Rows.Count
            Dim Amount = Val(TxtAmount.Text)
            For r = 0 To value - 1

                If r < value - 1 Then
                    'If CStr(Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value) = String.Empty Then
                    '    MessageBox.Show("Voucher_Id")
                    '    Exit Sub
                    'End If
                End If

                If r = value - 1 Then
                    Exit For
                End If
                If Me.DataGridView1.Rows(r).Cells(0).Value = False Then


                    Dim voucher_id = Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value
                    Dim cracc = Me.DIFEEACCOUNT.Get_Id
                    Dim dracc = Me.DataGridView1.Rows(r).Cells("Account_No").Value

                    sql = "UPDATE     M_Fee_Transaction_Impose " _
        & " SET  dr_Amount = '" & Amount & "' " _
        & " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & dracc & "' "

                    Dim sql2 = "UPDATE     M_Fee_Transaction_Impose " _
        & " SET  CR_Amount = '" & Amount & "' " _
        & " WHERE     (Voucher_Id =  " & Me.DataGridView1.Rows(r).Cells("Voucher_Id").Value & ") and Account_No ='" & cracc & "' "


                    cm = New SqlClient.SqlCommand(sql, cn)
                    cm.ExecuteNonQuery()
                    cm = New SqlClient.SqlCommand(sql2, cn)
                    cm.ExecuteNonQuery()






JUMP:
                End If

            Next
            MessageBox.Show("Record  Updated")

        Catch ex As Exception


            MessageBox.Show(ex.Message)

        End Try
    End Sub
   

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor

        UPDATEIMPOSED()
        FillStudent()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        For i = 0 To Me.Lvwsection.Items.Count - 1
            Me.Lvwsection.Items(i).Checked = True

        Next
        ResetGRID()

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        For i = 0 To Me.Lvwsection.Items.Count - 1
            Me.Lvwsection.Items(i).Checked = False

        Next
        ResetGRID()

    End Sub


    Sub ResetGRID()
        Dim TB As New DataTable

        Me.DataGridView1.DataSource = TB
    End Sub



End Class