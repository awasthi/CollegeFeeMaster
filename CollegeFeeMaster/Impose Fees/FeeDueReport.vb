Public Class FeeDueReport
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
    Friend DISection As DataItem
    Dim savec As Boolean
    Dim T1 As SqlClient.SqlTransaction
    Dim present As Boolean
    Dim cancelc As Boolean
    Dim c As Integer
    Dim CF, BF, HF, IMF, LF, FINE As Double

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xls"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()
        If saveFileDialog1.FileName <> "" Then
            Load_Excel_Details(saveFileDialog1.FileName)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Sub Reset()
        Dim s As System.Windows.Forms.DataGridViewAutoSizeColumnMode
        Dim s1 As System.Windows.Forms.DataGridViewAutoSizeColumnMode
        Dim s3 As System.Windows.Forms.DataGridViewAutoSizeColumnMode


        s = DataGridViewAutoSizeColumnMode.DisplayedCells
        s1 = DataGridViewAutoSizeColumnMode.None

        s3 = DataGridViewAutoSizeColumnMode.Fill
        Me.SplitContainer2.Panel2Collapsed = True
        Me.Button1.Image = CollegeFeeMaster.My.Resources.Resources.OPEN
        Me.DataGridView1.Width = 2000

        Me.DataGridView1.AutoSizeColumnsMode = s3

    End Sub
    Private Sub Load_Excel_Details(ByVal FileName As String)
        If Me.CboSection.SelectedIndex = -1 Then Exit Sub
        If Me.CboSection.SelectedIndex = 0 Then Exit Sub


        'Extracting from database
        Dim str, filename1, sql1 As String
        Dim col, row As Integer
        Dim j, m As Integer
        Dim cnt As Integer
        Dim ad1 As SqlClient.SqlDataAdapter
        Dim tb2 As System.Data.DataTable
        str = "SELECT * from Table1"
        Dim Tb As System.Data.DataTable

      

        sql = "SELECT       University_RollNo,   Account_No, Student_Name, DueCollFee, DueHosFee, DueBusFee, Imprest, LF, Fine " _
     & "  FROM  Vtest   " _
     & "  WHERE  ( Section_id =  " & DISection.Get_Id & ") order by University_RollNo "


    
        tb2 = New DataTable
        tb2 = GetDataset(Sql)



        Dim columncount As Integer = tb2.Columns.Count

        Dim Excel As Object = CreateObject("Excel.Application")
        If Excel Is Nothing Then
            MsgBox("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.", MsgBoxStyle.Critical)
            Return
        End If


        'Export to Excel process
        Try
            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()

                Dim i As Integer = 1
                For col = 0 To tb2.Columns.Count - 1
                    .cells(1, i).value = tb2.Columns(col).ColumnName
                    .cells(1, i).EntireRow.Font.Bold = True
                    i += 1
                Next
                i = 2
                Dim k As Integer = 1
                For col = 0 To tb2.Columns.Count - 1
                    i = 2
                    For row = 0 To tb2.Rows.Count - 1
                        Dim OI
                        .Cells(i, k).Value = tb2.Rows(row).ItemArray(col)
                        i += 1
                    Next
                    k += 1
                Next
                'filename = "c:\File_Exported" & Format(Now(), "dd-MM-yyyy_hh-mm-ss") & ".xls"
                .ActiveCell.Worksheet.SaveAs(FileName)
            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            MsgBox("Data's are exported to Excel Succesfully in '" & FileName & "'", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' The excel is created and opened for insert value. We most close this excel using this system
        Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each i As Process In pro
            i.Kill()
        Next
    End Sub

    Public Sub FillT() Implements IToolStrip.FillT

    End Sub

    Public Sub NewT() Implements IToolStrip.NewT

    End Sub

    Public Sub PrintT() Implements IToolStrip.PrintT

    End Sub

    Public Sub SaveT() Implements IToolStrip.SaveT

    End Sub

    Public Sub AutoNumberRows(ByVal oControl As DataGridView)
        Dim nElement As Integer
        With oControl.Rows
            For nElement = 0 To oControl.Rows.Count - 1
                oControl.Rows(nElement).HeaderCell.Value = Format(nElement + 1, "0")
                oControl.RowHeadersWidth = 70
            Next
        End With
    End Sub
    Sub FillStudentInfo(ByVal Account_No As String)


       
        sql = "SELECT     StudentID, University_RollNo, Student_Name, Father_Name, Lib_code AS photo, PEmail, MobileNumber, ParentContactNumber, Phone,institute,Account_No" _
& "  FROM  V_2009_Section_StudentO    WHERE    (University_RollNo = '" & Account_No & "') or Account_No= '" & Account_No & "'  and session_id in(select session_id from v_session where isactive=1)"


        Me.PictureBox1.ImageLocation = ""
        Me.TxtStudentName.Text = ""
        Me.TXTAcno.Text = ""




        Dim photo

        Dim dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        If dss.Tables(0).Rows.Count = 0 Then Exit Sub
        If IsDBNull(dss.Tables(0).Rows(0).Item(0)) = True Then Exit Sub
        Me.TxtStudentName.Text = dss.Tables(0).Rows(0).Item(2)
        Me.TXTAcno.Text = dss.Tables(0).Rows(0).Item("Account_No")
      
        InstituteID = dss.Tables(0).Rows(0).Item("Institute")
        If IsDBNull(dss.Tables(0).Rows(0).Item("photo")) = False Then
            photo = dss.Tables(0).Rows(0).Item("photo")
        End If
        dss.Dispose()
        dss.Clear()
        '   UPDATEC = True

        Call fillpicturebox()



        Dim strPathName As String

        strPathName = "http://www.psit.in/ProjectCollege/student/images/"
        Dim strFullPath As String
        strFullPath = strPathName & CStr(photo) & ".jpg"
        Me.PictureBox1.ImageLocation = strFullPath
    End Sub
    Sub fillpicturebox()
       
    End Sub
    Sub Fill(ByVal Account_No As String)
        Dim fd As New DataTable
        DataGridView2.DataSource = fd
        DataGridView3.DataSource = fd

        sql = "SELECT        Account_No, SUM(Refund) as Refund, SUM(Dr) as Dr, SUM(Cr) as Cr, SUM(Balance) as Balance" _
           & " FROM            (SELECT        Account_No, SUM(Dr_Amount) AS Refund, 0 AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance" _
           & " FROM V_Fee_Transacriot_2011  WHERE        (By_Account_No = '0000010')" _
           & " GROUP BY Account_No  UNION  SELECT        Account_No, 0 AS Refund, SUM(Dr_Amount) AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance" _
           & " FROM            V_Fee_Transacriot_2011 AS V_Fee_Transacriot_2011_1    WHERE        (By_Account_No <> '0000010')" _
           & " GROUP BY Account_No) AS Tmp GROUP BY Account_No Having Account_No = '" & Account_No & "'"


        '        sql = "SELECT     Account_No, case when by_account_no='0000010' Then SUM(Dr_Amount) Else 0 END  AS Refund , case when NOT(by_account_no='0000010') Then SUM(Dr_Amount) Else 0 END  AS Dr, SUM(Cr_Amount) AS Cr, SUM(Dr_Amount) - SUM(Cr_Amount) AS Balance " _
        '           & " FROM V_Fee_Transacriot_2011 " _
        '& " GROUP BY Account_No Having Account_No = '" & Me.Acno & "'"
        Dim dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        DataGridView2.DataSource = dss.Tables(0)


        sql = "SELECT   Date, Voucher_Id as V_Id, By_account_No, Particular as Particulars, " _
& " LoginSessionId as login, dr_amount as DR, cr_Amount as CR" _
& " FROM V_Fee_Transacriot_2011 WHERE Account_No = '" & Account_No & "' and session_id=9 ORDER BY Voucher_Id DESC"


        sql = "SELECT   Date,  By_account_No, Particular as Particulars, " _
& " LoginSessionId as login, dr_amount as DR, cr_Amount as CR" _
& " FROM V_Fee_Transacriot_2011 WHERE Account_No = '" & Account_No & "' and session_id=9 ORDER BY Voucher_Id DESC"
        dss = New DataSet
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ad.Fill(dss)
        DataGridView3.DataSource = dss.Tables(0)









    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Me.CboSection.SelectedIndex = -1 Then Exit Sub
        '  Reset()

        If Me.CboSection.SelectedIndex = 0 Then
            sql = "SELECT      University_RollNo,   Account_No, Student_Name, DueCollFee, DueHosFee, DueBusFee, Imprest, LF, Fine " _
               & "  FROM  Vtest   " _
               & "   order by Section_id, University_RollNo "
        Else
            sql = "SELECT      University_RollNo,   Account_No, Student_Name, DueCollFee, DueHosFee, DueBusFee, Imprest, LF, Fine " _
               & "  FROM  Vtest   " _
               & "  WHERE  ( Section_id =  " & DISection.Get_Id & ") order by University_RollNo "
        End If


      
        CF = 0
        BF = 0
        HF = 0
        IMF = 0
        LF = 0
        FINE = 0



        Dim tb2 = New DataTable
        tb2 = GetDataset(sql)
        Me.DataGridView1.DataSource = tb2

        AutoNumberRows(DataGridView1)



        For i = 0 To DataGridView1.RowCount - 1

            CF += DataGridView1.Rows(i).Cells("Column3").Value
            HF += DataGridView1.Rows(i).Cells("Column4").Value
            BF += DataGridView1.Rows(i).Cells("Column5").Value
            IMF += DataGridView1.Rows(i).Cells("Column1").Value
            LF += DataGridView1.Rows(i).Cells("Column2").Value
            FINE += DataGridView1.Rows(i).Cells("Column6").Value
        Next

        Dim DC1, DC2, DC3, DC4, DC5, DC6, DC7, DC8, DC9 As New DataColumn

        'Dim aa As New DataTable
        '' object of data row
        Dim drow As DataRow


       
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView1.Font, FontStyle.Bold)
        End With


        'With DataGridView1.RowsDefaultCellStyle
        '    .BackColor = Color.Navy
        '    .ForeColor = Color.White
        '    .Font = New Font(DataGridView1.Font, FontStyle.Bold)
        'End With




        drow = tb2.NewRow



        drow(0) = "Total Dues"
        drow(1) = "---"
        drow(2) = "---"
        drow(3) = CF
        drow(4) = HF

        drow(5) = BF
        drow(6) = IMF
        drow(7) = LF
        drow(8) = FINE

        tb2.Rows.Add(drow)
        Me.DataGridView1.DataSource = tb2

        AutoNumberRows(DataGridView1)

        Dim count = DataGridView1.Rows.Count
        For i = 0 To DataGridView1.ColumnCount - 1
            'Me.DataGridView1.Rows(count - 1).Cells(i).Style.Format

            Me.DataGridView1.Rows(count - 2).Cells(i).Style.ForeColor = Color.DarkRed
            Me.DataGridView1.Rows(count - 2).Cells(i).Style.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            Me.DataGridView1.Rows(count - 2).Cells(i).Style.Font = New Font(DataGridView1.Font.Size, 14)


        Next




    End Sub

    Private Sub FeeDueReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Reset()
        Me.WindowState = FormWindowState.Maximized
        SectionFill()
    End Sub
    'Sub UploadSection()
    '    'sql = "Select * From M_Section where session_id=" & sessionid & " and section_set =" & SessionSetActive & " "
    '    Me.CboSection.Items.Clear()
    '    sql = "Select * From M_Section where  section_set =" & Section_Set_Active & " and institute= " & InstituteID & ""
    '    ad = New SqlClient.SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    ad.Fill(ds)
    '    If ds.Tables(0).Rows.Count = 0 Then Exit Sub
    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        Me.CboSection.Items.Add(New IODataitem2(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1), ds.Tables(0).Rows(i).Item(2)))
    '    Next
    'End Sub

    Sub SectionFill()



        Me.CboSection.Items.Clear()
        'sql = "SELECT Section_Id, Section_Name FROM         M_Section    WHERE  section_set = " & Section_Set_Active & " and institute=" & Me.DIInstitute.Get_Id
        sql = "SELECT Section_Id, Section_Name FROM       V_Section    WHERE  section_set = 5  order by  institute ,  Section_Name "
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        ad.Fill(ds)
        Me.CboSection.Items.Add("--Select All---")
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.CboSection.Items.Add(New DataItem(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
        Next
        Me.CboSection.SelectedIndex = 0
    End Sub

    Private Sub CboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSection.SelectedIndexChanged
        If Me.CboSection.SelectedIndex = -1 Then Exit Sub
        If Me.CboSection.SelectedIndex = 0 Then Exit Sub
        DISection = Me.CboSection.SelectedItem
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error Resume Next
        If e.RowIndex = -1 Then Exit Sub
        Dim J As Integer
        J = e.RowIndex

        Dim Account_no As String

        Account_no = Me.DataGridView1.Rows(J).Cells("Account_no").Value

        FillStudentInfo(Account_no)
        Fill(Account_no)
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim count = DataGridView1.Rows.Count
        For i = 0 To DataGridView1.ColumnCount - 1
            'Me.DataGridView1.Rows(count - 1).Cells(i).Style.Format

            Me.DataGridView1.Rows(count - 2).Cells(i).Style.ForeColor = Color.DarkRed
            Me.DataGridView1.Rows(count - 2).Cells(i).Style.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            Me.DataGridView1.Rows(count - 2).Cells(i).Style.Font = New Font(DataGridView1.Font.Size, 14)


        Next



    End Sub

  
    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As System.Windows.Forms.DataGridViewAutoSizeColumnMode
        Dim s1 As System.Windows.Forms.DataGridViewAutoSizeColumnMode
        s = DataGridViewAutoSizeColumnMode.DisplayedCells
        s1 = DataGridViewAutoSizeColumnMode.None

        If Me.SplitContainer2.Panel2Collapsed = False Then
            Me.SplitContainer2.Panel2Collapsed = True
            Me.Button1.Image = CollegeFeeMaster.My.Resources.Resources.OPEN
            Me.DataGridView1.Width = 900
            Me.DataGridView1.AutoSizeColumnsMode = s1
        Else
            Me.SplitContainer2.Panel2Collapsed = False
            Me.Button1.Image = CollegeFeeMaster.My.Resources.Resources.close1
            Me.DataGridView1.Width = 1000
            Me.DataGridView1.AutoSizeColumnsMode = s
        End If


    End Sub

  

    Private Sub DataGridView1_CellContentClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        If e.RowIndex = -1 Then Exit Sub
        Dim J As Integer
        J = e.RowIndex

        Dim Account_no As String

        Account_no = Me.DataGridView1.Rows(J).Cells("Account_no").Value

        FillStudentInfo(Account_no)
        Fill(Account_no)
    End Sub

  

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If e.RowIndex = -1 Then Exit Sub
        Dim J As Integer
        J = e.RowIndex
        Dim Account_no As String

        Account_no = Me.DataGridView1.Rows(J).Cells("Account_no").Value

        FillStudentInfo(Account_no)
        Fill(Account_no)
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        AutoNumberRows(DataGridView1)
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If e.RowIndex = -1 Then Exit Sub
        Dim J As Integer
        J = e.RowIndex
        ' UpdateC = True
        Dim Account_no As String



        Account_no = Me.DataGridView1.Rows(J).Cells("Account_no").Value

        FillStudentInfo(Account_no)
        Fill(Account_no)
    End Sub
End Class