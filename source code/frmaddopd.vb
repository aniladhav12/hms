Imports System.Data.OleDb
Public Class frmaddopd
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim sql As String
    Dim IsMouseDown = False
    Dim startPoint

    Private Sub btnclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnsave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtname.Text = "" Then
            MsgBox("Please Enter Name")
            txtname.Focus()
        ElseIf txtage.Text = "" Then
            MsgBox("Please enter Age")
            txtage.Focus()
        ElseIf txtaddr.Text = "" Then
            MsgBox("Please Enter Address")
            txtaddr.Focus()
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "insert into opd_register(pname,age,addr,mobile,description,visit_date) values('" & txtname.Text & "','" & txtage.Text & "','" & txtaddr.Text & "','" & txtmobile.Text & "','" & txtdescription.Text & "','" & Now() & "' )"
            cmd = New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record Inserted Successfully !")
            cmd.Dispose()
            con.Close()

            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtdescription.Clear()
            txtmobile.Clear()
        End If
    End Sub

    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        startPoint = e.Location
        IsMouseDown = True
    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If IsMouseDown Then
            Dim p1 = New Point(e.X, e.Y)
            Dim p2 = PointToScreen(p1)
            Dim p3 = New Point(p2.X - startPoint.X, p2.Y - startPoint.Y)
            Location = p3
        End If
    End Sub

    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        IsMouseDown = False
    End Sub


    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub frmaddopd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class