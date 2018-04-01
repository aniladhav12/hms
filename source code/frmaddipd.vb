Imports System.Data.OleDb
Public Class frmaddipd
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim sql As String

    Private Property startPoint As Point

    Private Property IsMouseDown As Boolean

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
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
            sql = "insert into ipd_patients(pname,age,addr,mobile,bed_no,description,admit_date) values('" & txtname.Text & "','" & txtage.Text & "','" & txtaddr.Text & "','" & txtmobile.Text & "'," & Val(ComboBox1.Text) & ",'" & txtdescription.Text & "','" & Now() & "' )"
            cmd = New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()

            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "insert into bill(pid) values(" & Val(txtpid.text) & ")"
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
            ComboBox1.Text = ""
            txtpid.Text = Val(txtpid.Text) + 1
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
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

    Private Sub frmaddipd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
        con.Open()
        sql = "select max(pid) from ipd_patients"
        cmd = New OleDbCommand(sql, con)
        Dim pid As Integer
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()

                If dr.GetValue(0).ToString = "" Then
                    txtpid.Text = 1
                Else
                    pid = dr.GetValue(0) + 1
                    txtpid.Text = pid
                End If

            End While
        End If
        cmd.Dispose()
        con.Close()

        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
        con.Open()
        sql = "select * from bed where status=0"
        cmd = New OleDbCommand(sql, con)

        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                ComboBox1.Items.Add(dr("bno").ToString)
            End While
        End If
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class