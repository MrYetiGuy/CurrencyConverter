Public Class Form1

    Dim Amount As Integer
    Dim Rate As Double
    Dim Answer As Double
    Dim Update As Integer = FreeFile()
    Dim HelpFile As Integer = FreeFile()
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Add the help message here as a string.
        Dim TempS As String = ""
        Dim TempL As String
        FileOpen(HelpFile, "Help.txt", OpenMode.Input)
        Do Until EOF(HelpFile)
            TempL = LineInput(HelpFile)
            TempS += TempL + vbCrLf
        Loop
        FileClose(HelpFile)
        MessageBox.Show(TempS)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' The get rate will open the browser with this link
        Process.Start("https://www.google.co.uk/search?safe=strict&rlz=1C1GCEA_enGB786GB786&ei=v_CTWur-DaeBgAah2JTQDA&q=1+pound+to+euro&oq=1+pound+t&gs_l=psy-ab.3.0.0i67k1l6j0l4.4779.6166.0.6894.9.6.0.3.3.0.95.442.6.6.0....0...1c.1.64.psy-ab..0.9.460...0i131k1.0.FuvkRQSMFuw")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Amount = MaskedTextBox1.Text
            Rate = MaskedTextBox2.Text
            If MaskedTextBox1.Text <> "" Then
                Answer = Rate * Convert.ToDouble(Amount)
                TextBox1.Text = "€ " & Math.Round(Answer, 2)
            End If
        Catch
            MessageBox.Show("Please enter an amount to convert")
        End Try
        ' Conversion and checker to see if the box is empty.
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MaskedTextBox1.Clear()
        TextBox1.Text = " "
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Amount = MaskedTextBox1.Text
            Rate = MaskedTextBox2.Text
            If MaskedTextBox1.Text <> "" Then
                Answer = Convert.ToDouble(Amount) / Rate
                TextBox1.Text = "£ " & Math.Round(Answer, 2)
            End If
        Catch
            MessageBox.Show("Please enter an amount to convert")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FileOpen(Update, "Update.txt", OpenMode.Output)
        PrintLine(Update, MaskedTextBox2.Text)
        FileClose(Update)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TempS As String = ""
        Dim TempL As String
        FileOpen(Update, "Update.txt", OpenMode.Input)
        Do Until EOF(Update)
            TempL = LineInput(Update)
            TempS += TempL + vbCrLf
        Loop
        FileClose(Update)
        MaskedTextBox2.Text = TempS
        TextBox1.Text = " "
        MaskedTextBox1.Text = " "
    End Sub

End Class
