Public Class frmKeyboardCalculator
    Dim decimalFlag As Boolean, shouldIClose As Boolean
    Private Sub frmKeyboardCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize(True, True, True)
    End Sub

    Sub initialize(clearMemory As Boolean, clearDisplay As Boolean, clearOperation As Boolean)
        shouldIClose = False
        decimalFlag = False
        If clearMemory = True Then
            txtMemory.Text = ""
        End If
        If clearDisplay = True Then
            txtDisplay.Text = "0"
        End If
        If clearOperation = True Then
            txtOperation.Text = ""
        End If
    End Sub

    Private Sub btnPlusOrMinus_Click(sender As Object, e As EventArgs) Handles btnPlusOrMinus.Click
        Dim savedNum As Integer
        savedNum = txtDisplay.Text
        txtDisplay.Text = 0 - txtDisplay.Text
    End Sub

    Private Sub btnSineFunction_Click(sender As Object, e As EventArgs) Handles btnSineFunction.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Sin(num)
    End Sub


    Private Sub btnCosineFunction_Click(sender As Object, e As EventArgs) Handles btnCosineFunction.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Cos(num)
    End Sub

    Private Sub btnTangentFunction_Click(sender As Object, e As EventArgs) Handles btnTangentFunction.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Tan(num)
    End Sub

    Private Sub btnSquareRootFunction_Click(sender As Object, e As EventArgs) Handles btnSquareRootFunction.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Sqrt(num)
    End Sub

    Private Sub btnGoldenRatio_Click(sender As Object, e As EventArgs) Handles btnGoldenRatio.Click
        txtDisplay.Text = (1 + Math.Sqrt(5)) / 2
    End Sub

    Private Sub btnPi_Click(sender As Object, e As EventArgs) Handles btnPi.Click
        txtDisplay.Text = Math.PI
    End Sub

    Private Sub btnPercent_Click(sender As Object, e As EventArgs) Handles btnPercent.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = num / 100
    End Sub

    Private Sub btnOneOverX_Click(sender As Object, e As EventArgs) Handles btnOneOverX.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = 1 / num
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Log(num)
    End Sub

    Private Sub cbxTakingTest_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTakingTest.CheckedChanged
        If cbxTakingTest.Checked = True Then
            MsgBox("You should not be using this calculator on a test!")
            MsgBox("That is called cheating, cheater!")
            shouldIClose = True
            Close()
        End If
    End Sub

    Private Sub btnLogTen_Click(sender As Object, e As EventArgs) Handles btnLogTen.Click
        Dim num As Double
        num = txtDisplay.Text
        txtDisplay.Text = Math.Log10(num)
    End Sub

    Private Sub buttonsClick(sender As Button, e As EventArgs) Handles btn0.Click, btn1.Click,
                             btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click,
                             btn8.Click, btn9.Click
        Dim digit As String = sender.Text
        If txtDisplay.Text = "0" Then
            txtDisplay.Text = digit
        Else
            txtDisplay.Text = txtDisplay.Text & digit
        End If
    End Sub

    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        If decimalFlag = False Then
            txtDisplay.Text = txtDisplay.Text & "."
            decimalFlag = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        initialize(True, True, True)
    End Sub

    Sub mathOperation(sender As Button, e As EventArgs) Handles btnAdd.Click, btnMinus.Click,
                      btnMultiply.Click, btnDivide.Click, btnPowerOf.Click
        txtMemory.Text = txtDisplay.Text
        Select Case sender.Text
            Case "+"
                txtOperation.Text = "+"
            Case "-"
                txtOperation.Text = "-"
            Case "X"
                txtOperation.Text = "X"
            Case "/"
                txtOperation.Text = "/"
            Case "x^y"
                txtOperation.Text = "^"
        End Select
        initialize(False, True, False)
    End Sub

    Private Sub btnBackspace_Click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        Dim remainingChar As Integer = txtDisplay.Text.Length - 1
        If remainingChar = 0 Then
            txtDisplay.Text = "0"
        Else
            txtDisplay.Text = Mid(txtDisplay.Text, 1, txtDisplay.Text.Length - 1)
        End If
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Dim memory As Double = txtMemory.Text
        Dim display As Double = txtDisplay.Text
        If txtOperation.Text = "+" Then
            txtDisplay.Text = memory + display
            initialize(True, False, True)
        End If
        If txtOperation.Text = "-" Then
            txtDisplay.Text = memory - display
            initialize(True, False, True)
        End If
        If txtOperation.Text = "X" Then
            txtDisplay.Text = memory * display
            initialize(True, False, True)
        End If
        If txtOperation.Text = "/" Then
            txtDisplay.Text = memory / display
            initialize(True, False, True)
        End If
        If txtOperation.Text = "^" Then
            txtDisplay.Text = memory ^ display
            initialize(True, False, True)
        End If
    End Sub

    Private Sub mathOperation(sender As Object, e As EventArgs) Handles btnMultiply.Click, btnMinus.Click, btnDivide.Click, btnAdd.Click, btnPowerOf.Click

    End Sub

    Private Sub frmKeyboardCalculator_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialogYesNo As DialogResult
        If shouldIClose = True Then
            Return
        End If
        dialogYesNo = MessageBox.Show("Are you sure you want to Close the Program???",
                                      "Shut Down Calculator...", MessageBoxButtons.YesNo)
        If dialogYesNo = DialogResult.Yes Then
            MsgBox("Okay. Shutting down...")
        Else
            e.Cancel = True
        End If
    End Sub
End Class
