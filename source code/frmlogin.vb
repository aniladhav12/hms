Imports System.Drawing.Drawing2D
Imports System.Data.OleDb
Public Class frmlogin
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim sql As String
    Dim dr As OleDbDataReader
    Dim IsMouseDown = False
    Dim startPoint

    Dim mainscreen As Form

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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub frmlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = False
       
    End Sub


    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        'frmmain.Show()
        'Me.Hide()
        If txtpass.Text = "" Or txtuid.Text = "" Then
            MsgBox("Please enter UserId & Password", MsgBoxStyle.Exclamation)
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from users where uid='" & txtuid.Text & "' and password='" & txtpass.Text & "'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Me.Hide()
                frmmain.Show()
            Else
                MsgBox("Incorrect UserID or Password", MsgBoxStyle.Critical)
            End If

        End If


    End Sub

    Private Sub btnmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmlogin_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ' Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.White, Color.SteelBlue, LinearGradientMode.Vertical)
        '  e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.SteelBlue, Color.White, LinearGradientMode.Vertical)
        'e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub

    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtpass.Text = "" Or txtuid.Text = "" Then
                MsgBox("Please enter UserId & Password", MsgBoxStyle.Exclamation)
            Else
                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "select * from users where uid='" & txtuid.Text & "' and password='" & txtpass.Text & "'"
                cmd = New OleDbCommand(sql, con)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    Me.Hide()
                    frmmain.Show()
                Else
                    MsgBox("Incorrect UserID or Password", MsgBoxStyle.Critical)
                End If

            End If

        End If
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub txtuid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuid.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtpass.Text = "" Or txtuid.Text = "" Then
                MsgBox("Please enter UserId & Password", MsgBoxStyle.Exclamation)
            Else
                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "select * from users where uid='" & txtuid.Text & "' and password='" & txtpass.Text & "'"
                cmd = New OleDbCommand(sql, con)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    Me.Hide()
                    frmmain.Show()
                Else
                    MsgBox("Incorrect UserID or Password", MsgBoxStyle.Critical)
                End If

            End If

        End If

    End Sub
End Class
