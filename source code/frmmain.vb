Public Class frmmain
    Dim IsMouseDown = False
    Dim startPoint
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        startPoint = e.Location
        IsMouseDown = True
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If IsMouseDown Then
            Dim p1 = New Point(e.X, e.Y)
            Dim p2 = PointToScreen(p1)
            Dim p3 = New Point(p2.X - startPoint.X, p2.Y - startPoint.Y)
            Location = p3
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        IsMouseDown = False
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ans As String
        ans = MsgBox("Exit From Applicatin ?", MsgBoxStyle.YesNo)
        If (ans = "6") Then
            End
        End If

    End Sub

    Private Sub frmmain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        End
    End Sub
    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Text = ""
        Me.ControlBox = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmmanageopd.Show()
        frmmanageopd.Focus()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dim ans As String
        ans = MsgBox("Sure to Exit ?", MsgBoxStyle.YesNo)
        If (ans = "6") Then
            End
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmmanageipd.Show()
        frmmanageipd.Focus()
    End Sub

    Private Sub ToolStripButton5_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToIPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToIPDToolStripMenuItem.Click
        frmaddopd.Show()
        frmaddopd.Focus()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        frmmanagedoctors.Show()
        frmmanagedoctors.Focus()
    End Sub

    Private Sub OPDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPDToolStripMenuItem1.Click
        frmaddipd.Show()
        frmaddipd.Focus()
    End Sub

    Private Sub OPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPDToolStripMenuItem.Click
        report_opd.Show()
        report_opd.Focus()
    End Sub

    Private Sub IPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPDToolStripMenuItem.Click
        report_ipd.Show()
    End Sub

    Private Sub DoctorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoctorsToolStripMenuItem.Click
        report_doctors.Show()
    End Sub
End Class