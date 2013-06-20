Imports System.Data


Module Module1
    Public cn As New SqlClient.SqlConnection
    Dim cm As SqlClient.SqlCommand
    Dim rd As SqlClient.SqlDataReader
    Dim ad As SqlClient.SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Public SubjectIDarr() As Integer
    Public SubjectNamearr() As String
    Public JumpS As Boolean
    Public ActiveReportName As String
    Public s_AmountToString As String
    Public SalesType As String
    Public myReport
    Public UserID As Integer
    Public CallingForm As String
    Dim tb As DataTable
    Public cnt As Integer
    Public InstituteID As Integer
    Public SessionID As Integer
    Public SessionSelected As String
    Public Section_Set_Active As Integer
    Public RegStudentid As Integer
    Public DatabaseName As String
    Public cnFee As New SqlClient.SqlConnection
    Public FacAppEmpid As Integer
    Public APID As Integer
    'Public AppraisalYearName
    'Public employeeName As String
    'Public EMPDesignation
    'Public empdept As String
    Public Rightlevel As Integer
    Sub main()
        Try
            cn.ConnectionString = "Data Source = " & My.Settings.DataSourceName & "; uid = " & My.Settings.UserID1 & ";pwd= " & My.Settings.Password & " ;database=" & My.Settings.DataBaseName & " "
            'cnFee.ConnectionString = "Data Source = " & My.Settings.DataSourceName & "; uid = " & My.Settings.UserID1 & ";pwd= " & My.Settings.Password & " ;database=efee10 "
            'cn.ConnectionString = "Data Source=My.Settings.DataSourceName; database=ecollege"
            'cn.ConnectionString = "Data Source=192.168.101.163; uid = sa;pwd= hcm582;database=ecollege"
            cn.Open()
            MdIFORM.ShowDialog()
        Catch ex As SqlClient.SqlException
            Dim ed = ex.Number
            If ed = 53 Then
                MySetting.ShowDialog()
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

#Region "Key Press Checks"
    Public Function CheckNumeric(ByVal Character As Char) As Boolean
        If IsNumeric(Character) Or Asc(Character) = 8 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckDecimal(ByVal Character As Char) As Boolean
        If IsNumeric(Character) Or Asc(Character) = 8 Or Asc(Character) = 46 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckPhone(ByVal Character As Char) As Boolean
        If IsNumeric(Character) Or Asc(Character) = 8 Or Asc(Character) = 45 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckAlphaNumeric(ByVal Character As Char) As Boolean
        If Asc(Character) = 34 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CheckChar(ByVal KeyValue As Char) As Boolean
        If Asc(KeyValue) >= 48 And Asc(KeyValue) <= 57 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ConvertAmtToString(ByVal s_ConvertedValue As String)
        If s_ConvertedValue = "" Then
            s_AmountToString = ""
            Exit Function
        End If
        Dim s_ChkMinus As String
        s_AmountToString = ""
        If Mid(s_ConvertedValue, 1, 1) = "-" Then
            'MsgBox "Amount Can't Be Negative"
            'Exit Function
            s_ChkMinus = s_ConvertedValue
            s_ConvertedValue = Mid(s_ConvertedValue, 2, Len(s_ConvertedValue))
        End If
        Dim s_Value As String
        Dim n_LenOfBeforeDot As Integer
        Dim FinalNo As String
        Dim NDigits(20) As String
        Dim NTens(10) As String

        NDigits(1) = "one"
        NDigits(2) = "two"
        NDigits(3) = "three"
        NDigits(4) = "four"
        NDigits(5) = "five"
        NDigits(6) = "six"
        NDigits(7) = "seven"
        NDigits(8) = "eight"
        NDigits(9) = "nine"
        NDigits(10) = "ten"
        NDigits(11) = "eleven"
        NDigits(12) = "twelve"
        NDigits(13) = "thirteen"
        NDigits(14) = "fourteen"
        NDigits(15) = "fifteen"
        NDigits(16) = "sixteen"
        NDigits(17) = "seventeen"
        NDigits(18) = "eighteen"
        NDigits(19) = "nineteen"

        'NTens(1) = "ten"
        NTens(2) = "twenty"
        NTens(3) = "thirty"
        NTens(4) = "forty"
        NTens(5) = "fifty"
        NTens(6) = "sixty"
        NTens(7) = "seventy"
        NTens(8) = "eighty"
        NTens(9) = "ninety"

        n_LenOfBeforeDot = InStr(1, Trim(s_ConvertedValue), ".")
        If n_LenOfBeforeDot > 0 Then
            n_LenOfBeforeDot = n_LenOfBeforeDot - 1
        Else
            n_LenOfBeforeDot = Len(Trim(s_ConvertedValue))
        End If
        If n_LenOfBeforeDot > 9 Then
            MsgBox("You can Enter Only 9 digits before dot")
            Exit Function
        End If
        s_Value = Mid(Trim(s_ConvertedValue), 1, n_LenOfBeforeDot)
        If (Len(s_Value) = 9) Then  'And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " crore "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " crore "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " crore "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 8
            'If Len(s_Value) = 8 And Mid(s_Value, 1, 1) > 0 Then
            If Len(s_Value) = 8 And Mid(s_Value, 1, 1) <> "" Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " crore "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for lakh
        If (Len(s_Value) = 7) Then  'And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " lakh "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " lakh "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " lakh "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 6
            If Len(s_Value) = 6 And Mid(s_Value, 1, 1) <> "" Then
                'If Len(s_Value) = 6 And Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " lakh "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for thousand
        If (Len(s_Value) = 5) Then '' And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " thousand "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " thousand "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " thousand "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 4
            If Len(s_Value) = 4 And Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " thousand "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for hundread
        If Len(s_Value) = 3 Then  ''And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " Hundread "
            End If
            s_Value = Mid(s_Value, 2, Len(s_Value))
        End If
        'after hundread
        Dim n_noFor2digit As Integer
        If (Len(s_Value) = 2 Or Len(s_Value) = 1) And Val(s_Value) <> 0 Then
            If s_Value >= 1 And s_Value <= 19 Then
                FinalNo = FinalNo & NDigits(s_Value)
            Else
                n_noFor2digit = Int(s_Value / 10)
                FinalNo = FinalNo & NTens(n_noFor2digit)
                n_noFor2digit = (s_Value - n_noFor2digit * 10)
                FinalNo = FinalNo & " " & NDigits(n_noFor2digit)
            End If
        End If
        'for decimal value
        If InStr(1, Trim(s_ConvertedValue), ".") > 0 Then
            's_Value = Mid(s_ConvertedValue, n_LenOfBeforeDot + 2, Len(Trim(s_ConvertedValue)))
            s_Value = Mid(s_ConvertedValue, n_LenOfBeforeDot + 2, 2)
            If Len(s_Value) = 1 Then s_Value = s_Value & "0"

            If Val(s_Value) <> 0 Then ''Len(s_value) = 2 And
                If s_Value >= 1 And s_Value <= 19 Then
                    FinalNo = FinalNo & " and " & NDigits(s_Value) & " Paise"
                Else
                    n_noFor2digit = Int(s_Value / 10)
                    FinalNo = FinalNo & " and " & NTens(n_noFor2digit)
                    n_noFor2digit = (s_Value - n_noFor2digit * 10)
                    FinalNo = FinalNo & " " & NDigits(n_noFor2digit) & " Paise"
                End If
            End If
        End If
        If FinalNo <> "" Then
            If Mid(FinalNo, 1, 4) = " and" Then
                s_AmountToString = Mid(FinalNo, 5, Len(FinalNo)) & " Only"
            Else
                s_AmountToString = "Rs. " & FinalNo & " Only"
            End If
        Else
            s_AmountToString = "Zero"
        End If
        If Mid(s_ChkMinus, 1, 1) = "-" Then
            s_AmountToString = "( Minus ) " & s_AmountToString
        End If


    End Function


    Public Function ConvertAmtToStringN(ByVal s_ConvertedValue As String) As String
        If s_ConvertedValue = "" Then
            s_AmountToString = ""
            Exit Function
        End If
        Dim t, th, f As String
        t = "Twenty"
        th = "Thirty"
        f = "Forty"
        Dim s_ChkMinus As String
        s_AmountToString = ""
        If Mid(s_ConvertedValue, 1, 1) = "-" Then
            'MsgBox "Amount Can't Be Negative"
            'Exit Function
            s_ChkMinus = s_ConvertedValue
            s_ConvertedValue = Mid(s_ConvertedValue, 2, Len(s_ConvertedValue))
        End If
        Dim s_Value As String
        Dim n_LenOfBeforeDot As Integer
        Dim FinalNo As String
        Dim NDigits(20) As String
        Dim NTens(10) As String

        NDigits(1) = "One"
        NDigits(2) = "Two"
        NDigits(3) = "Three"
        NDigits(4) = "Four"
        NDigits(5) = "Five"
        NDigits(6) = "Six"
        NDigits(7) = "Seven"
        NDigits(8) = "Eight"
        NDigits(9) = "Nine"
        NDigits(10) = "Ten"
        NDigits(11) = "Eleven"
        NDigits(12) = "Twelve"
        NDigits(13) = "Thirteen"
        NDigits(14) = "Fourteen"
        NDigits(15) = "Fifteen"
        NDigits(16) = "Sixteen"
        NDigits(17) = "Seventeen"
        NDigits(18) = "Eighteen"
        NDigits(19) = "Nineteen"

        'NTens(1) = "ten"
        NTens(2) = "Twenty"
        NTens(3) = "Thirty"
        NTens(4) = "Forty"
        NTens(5) = "Fifty"
        NTens(6) = "Sixty"
        NTens(7) = "Seventy"
        NTens(8) = "Eighty"
        NTens(9) = "Ninety"

        n_LenOfBeforeDot = InStr(1, Trim(s_ConvertedValue), ".")
        If n_LenOfBeforeDot > 0 Then
            n_LenOfBeforeDot = n_LenOfBeforeDot - 1
        Else
            n_LenOfBeforeDot = Len(Trim(s_ConvertedValue))
        End If
        If n_LenOfBeforeDot > 9 Then
            MsgBox("You can Enter Only 9 digits before dot")
            Exit Function
        End If
        s_Value = Mid(Trim(s_ConvertedValue), 1, n_LenOfBeforeDot)
        If (Len(s_Value) = 9) Then  'And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " crore "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " crore "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " crore "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 8
            'If Len(s_Value) = 8 And Mid(s_Value, 1, 1) > 0 Then
            If Len(s_Value) = 8 And Mid(s_Value, 1, 1) <> "" Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " crore "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for lakh
        If (Len(s_Value) = 7) Then  'And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " lakh "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " lakh "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " lakh "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 6
            If Len(s_Value) = 6 And Mid(s_Value, 1, 1) <> "" Then
                'If Len(s_Value) = 6 And Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " lakh "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for thousand
        If (Len(s_Value) = 5) Then '' And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 2) >= 1 And Mid(s_Value, 1, 2) <= 19 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 2)) & " thousand "
            Else
                FinalNo = FinalNo & NTens(Mid(s_Value, 1, 1))
                If Mid(s_Value, 2, 1) <> 0 Then
                    FinalNo = FinalNo & " " & NDigits(Mid(s_Value, 2, 1)) & " thousand "
                Else
                    If Mid(s_Value, 1, 2) <> 0 Then FinalNo = FinalNo & " thousand "
                End If
            End If
            s_Value = Mid(s_Value, 3, Len(s_Value))
        Else
            'for len 4
            If Len(s_Value) = 4 And Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " thousand "
                s_Value = Mid(s_Value, 2, Len(s_Value))
            End If
        End If
        'for hundread
        If Len(s_Value) = 3 Then  ''And Mid(s_value, 1, 1) > 0)
            If Mid(s_Value, 1, 1) > 0 Then
                FinalNo = FinalNo & NDigits(Mid(s_Value, 1, 1)) & " Hundread "
            End If
            s_Value = Mid(s_Value, 2, Len(s_Value))
        End If
        'after hundread
        Dim n_noFor2digit As Integer
        If (Len(s_Value) = 2 Or Len(s_Value) = 1) And Val(s_Value) <> 0 Then
            If s_Value >= 1 And s_Value <= 19 Then
                FinalNo = FinalNo & NDigits(s_Value)
            Else
                n_noFor2digit = Int(s_Value / 10)
                FinalNo = FinalNo & NTens(n_noFor2digit)
                n_noFor2digit = (s_Value - n_noFor2digit * 10)
                FinalNo = FinalNo & " " & NDigits(n_noFor2digit)
            End If
        End If
        'for decimal value
        If InStr(1, Trim(s_ConvertedValue), ".") > 0 Then
            's_Value = Mid(s_ConvertedValue, n_LenOfBeforeDot + 2, Len(Trim(s_ConvertedValue)))
            s_Value = Mid(s_ConvertedValue, n_LenOfBeforeDot + 2, 2)
            If Len(s_Value) = 1 Then s_Value = s_Value & "0"

            If Val(s_Value) <> 0 Then ''Len(s_value) = 2 And
                If s_Value >= 1 And s_Value <= 19 Then
                    FinalNo = FinalNo & " and " & NDigits(s_Value) & " Paise"
                Else
                    n_noFor2digit = Int(s_Value / 10)
                    FinalNo = FinalNo & " and " & NTens(n_noFor2digit)
                    n_noFor2digit = (s_Value - n_noFor2digit * 10)
                    FinalNo = FinalNo & " " & NDigits(n_noFor2digit) & " Paise"
                End If
            End If
        End If
        If FinalNo <> "" Then
            If Mid(FinalNo, 1, 4) = " and" Then
                's_AmountToString = Mid(FinalNo, 5, Len(FinalNo)) & " Only"
                s_AmountToString = Mid(FinalNo, 5, Len(FinalNo))
            Else
                ' s_AmountToString = FinalNo & " Only"
                s_AmountToString = " " & FinalNo & " "
            End If
        Else
            s_AmountToString = "Zero"
        End If

        If Trim(s_AmountToString) = t Then
            s_AmountToString = s_AmountToString & " Only"
        End If


        If Trim(s_AmountToString) = th Then
            s_AmountToString = s_AmountToString & " Only"
        End If

        If Trim(s_AmountToString) = f Then

            s_AmountToString = s_AmountToString & " Only"
        End If

        If Trim(s_AmountToString) = "Zero" Then
            s_AmountToString = "Absent"
        End If


        If Mid(s_ChkMinus, 1, 1) = "-" Then
            s_AmountToString = "( Minus ) " & s_AmountToString
        End If
        Return s_AmountToString

    End Function


#End Region

    Function ExecuteQuery(ByVal sql As String)
        cm = New SqlClient.SqlCommand(sql, cn)
        cnt = cm.ExecuteNonQuery()
    End Function

    Function GetDataset(ByVal sql As String) As DataTable
        ad = New SqlClient.SqlDataAdapter(sql, cn)
        Dim tb As New DataTable
        ad.Fill(tb)
        GetDataset = tb
    End Function

    Public Sub RepairConnectionState()
        If cn.State = ConnectionState.Broken Then
            cn.Close()
            cn.Open()
        End If
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub
    

#Region "Validation"
    Public Sub SaveByToolBar()

    End Sub


    Public Sub allowmoney(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If (Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) And Asc(e.KeyChar) <> 46 Then
            e.Handled = True
        End If
    End Sub
    Public Sub notallowalphabet(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub

    Public Sub allowalphabet(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub allownumber(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Public Sub allownumberalphabet(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Sub CharBoxAfterLostFocus(ByVal txtBox As TextBox)
        Dim i As Integer
        Dim KeyAscii As Integer
        For i = 1 To Len(txtBox.Text)
            KeyAscii = Asc(Mid(txtBox.Text, i, 1))
            If KeyAscii >= 65 And KeyAscii <= 90 Or KeyAscii >= 97 And KeyAscii <= 122 Or KeyAscii = 32 Then
                'Else
                '    MsgBox("Numeric And (') Character Not Allowed")

                Exit For
            End If
        Next
    End Sub
#End Region


    '#Region "Crystal"

    '    Sub CrystalReportSetting(ByVal crpt As ReportClass)
    '        Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        For Each myTable In crpt.Database.Tables
    '            myLogin = myTable.LogOnInfo
    '            'myLogin.ConnectionInfo.ServerName = "surabhi"
    '            'myLogin.ConnectionInfo.DatabaseName = "ecollege"
    '            'myLogin.ConnectionInfo.Password = "hcm582"
    '            'myLogin.ConnectionInfo.UserID = "sa"
    '            'myTable.ApplyLogOnInfo(myLogin)
    '            myLogin.ConnectionInfo.ServerName = My.Settings.DataSourceName
    '            myLogin.ConnectionInfo.DatabaseName = My.Settings.DataBaseName
    '            myLogin.ConnectionInfo.Password = My.Settings.Password
    '            myLogin.ConnectionInfo.UserID = My.Settings.UserID1
    '            myTable.ApplyLogOnInfo(myLogin)
    '        Next
    '    End Sub

    '    'Sub CrystalReportSetting1(ByVal crpt As ReportClass)
    '    '    Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
    '    '    Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '    '    For Each myTable In crpt.Database.Tables
    '    '        myLogin = myTable.LogOnInfo
    '    '        myLogin.ConnectionInfo.ServerName = My.Settings.DataSourceName
    '    '        myLogin.ConnectionInfo.DatabaseName = My.Settings.DataBaseName
    '    '        myLogin.ConnectionInfo.Password = My.Settings.Password
    '    '        myLogin.ConnectionInfo.UserID = My.Settings.UserID1
    '    '        myTable.ApplyLogOnInfo(myLogin)

    '    '    Next
    '    'End Sub
    '    'Sub CrystalReportSettingA(ByVal crpt As ReportClass)
    '    '    Dim currpath As String = System.Environment.CurrentDirectory
    '    '    Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
    '    '    Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '    '    crpt.SetDataSource(GetDataset("SELECT * from CMS_REPORTTABLE1 ORDER BY F0"))
    '    '    For Each myTable In crpt.Database.Tables
    '    '        myLogin = myTable.LogOnInfo
    '    '        myLogin.TableName = "ReportTable"
    '    '        myLogin.ConnectionInfo.ServerName = My.Settings.DataSourceName
    '    '        myLogin.ConnectionInfo.DatabaseName = My.Settings.DataBaseName
    '    '        myLogin.ConnectionInfo.Password = My.Settings.Password
    '    '        myLogin.ConnectionInfo.UserID = My.Settings.UserID1
    '    '        myTable.ApplyLogOnInfo(myLogin)
    '    '    Next
    '    'End Sub

    '    'Sub CrystalReportSettingQuery(ByVal crpt As ReportClass)
    '    '    Dim currpath As String = System.Environment.CurrentDirectory
    '    '    Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
    '    '    Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '    '    Dim sql As String
    '    '    'sql = ""
    '    '    'crpt.SetDataSource(GetDataset(sql))
    '    '    For Each myTable In crpt.Database.Tables
    '    '        myLogin = myTable.LogOnInfo
    '    '        myLogin.ConnectionInfo.ServerName = My.Settings.DataSourceName
    '    '        myLogin.ConnectionInfo.DatabaseName = My.Settings.DataBaseName
    '    '        myLogin.ConnectionInfo.Password = My.Settings.Password
    '    '        myLogin.ConnectionInfo.UserID = My.Settings.UserID1
    '    '        myTable.ApplyLogOnInfo(myLogin)
    '    '    Next
    '    'End Sub

    '#End Region

    
End Module
