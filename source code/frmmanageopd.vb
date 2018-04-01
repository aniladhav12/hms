Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmmanageopd
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim sql As String
    Dim IsMouseDown = False
    Dim startPoint


    Private Sub frmupdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmupdate_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.SteelBlue, Color.SteelBlue, LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)

        ' ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.SteelBlue, Color.SteelBlue, LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub


    Private Sub btnclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
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



    Private Sub btnupdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "|DataDirectory|\hospital.mdb")
        con.Open()
        sql = "update opd_register set pname='" & txtname.Text & "', age='" & txtage.Text & "', addr='" & txtaddr.Text & "', mobile='" & txtmobile.Text & "', description='" & txtdescription.Text & "',visit_date='" & DateTimePicker1.Value & "' where pid=" & Val(txtpid.Text) & ""
        cmd = New OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Record Updated !")
        cmd.Dispose()
        con.Close()
    End Sub


    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtpid.Text = "" Then

        Else
            Dim ans As MsgBoxResult
            ans = MsgBox("Really Want to Delete Record ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "delete from opd_register where pid=" & Val(txtpid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()
                MsgBox("Record Deleted Successfully !")

                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtpid.Clear()


            End If
        End If
    End Sub

    Private Sub txtsearchbyid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyid.KeyUp
        If txtsearchbyid.Text = "" Then
            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtmobile.Clear()
            txtdescription.Clear()
            txtpid.Clear()

        ElseIf Not IsNumeric(txtsearchbyid.Text) Then

        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from opd_register where pid=" & txtsearchbyid.Text & ""
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtpid.Text = Val(dr("pid").ToString)
                    txtname.Text = dr("pname").ToString
                    txtage.Text = dr("age").ToString()
                    txtaddr.Text = dr("addr").ToString()
                    txtmobile.Text = dr("mobile").ToString()
                    txtdescription.Text = dr("description").ToString()
                    DateTimePicker1.Text = dr("visit_date").ToString()
                End While
                cmd.Dispose()
                con.Close()
            Else
                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtpid.Clear()

            End If
        End If
    End Sub

    Private Sub txtsearchbyname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyname.KeyUp
        If txtsearchbyname.Text = "" Then
            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtmobile.Clear()
            txtdescription.Clear()
            txtpid.Clear()

        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from opd_register where pname like '%" & txtsearchbyname.Text & "%'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtpid.Text = Val(dr("pid").ToString)
                    txtname.Text = dr("pname").ToString
                    txtage.Text = dr("age").ToString()
                    txtaddr.Text = dr("addr").ToString()
                    txtmobile.Text = dr("mobile").ToString()
                    txtdescription.Text = dr("description").ToString()
                    DateTimePicker1.Text = dr("visit_date").ToString()
                End While
                cmd.Dispose()
                con.Close()
            Else
                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtpid.Clear()

            End If
        End If
    End Sub

    Private Sub txtsearchbyid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearchbyid.TextChanged

    End Sub
End Class