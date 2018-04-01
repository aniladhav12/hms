Imports System.Data.OleDb
Imports System.Drawing.Drawing2D
Public Class frmmanageipd
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim sql As String
    Dim dr As OleDbDataReader

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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub frmlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = False
    End Sub
    Private Sub frmsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmsearch_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.White, Color.SteelBlue, LinearGradientMode.Vertical)
        'e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.SteelBlue, Color.Aqua, LinearGradientMode.Vertical)
        ' e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub

    Private Sub txtsearchbyid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyid.KeyUp
        If txtsearchbyid.Text = "" Then
            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtmobile.Clear()
            txtdescription.Clear()
            txtid.Clear()
            txtbedno.Clear()
            txtbedcharge.Clear()
            txtmedicinecharge.Clear()
            txtothercharge.Clear()
        ElseIf Not IsNumeric(txtsearchbyid.Text) Then

        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from ipd_patients where pid=" & txtsearchbyid.Text & ""
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtid.Text = Val(dr("pid").ToString)
                    txtname.Text = dr("pname").ToString
                    txtage.Text = dr("age").ToString()
                    txtaddr.Text = dr("addr").ToString()
                    txtmobile.Text = dr("mobile").ToString()
                    txtdescription.Text = dr("description").ToString()
                    DateTimePicker1.Text = dr("admit_date").ToString()
                    txtbedno.Text = dr("bed_no").ToString
                End While
                cmd.Dispose()
                con.Close()

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "select * from bill where pid=" & Val(txtid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()

                        txtbedcharge.Text = Val(dr("bed_charge").ToString)
                        txtmedicinecharge.Text = Val(dr("medicine_charge").ToString)
                        txtothercharge.Text = Val(dr("other_charge").ToString)

                    End While
                End If
                cmd.Dispose()
                con.Close()


            Else
                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtid.Clear()
                txtbedno.Clear()
                txtbedcharge.Clear()
                txtmedicinecharge.Clear()
                txtothercharge.Clear()
            End If
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub txtsearchbyname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyname.KeyUp
        If txtsearchbyname.Text = "" Then
            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtmobile.Clear()
            txtdescription.Clear()
            txtid.Clear()
            txtbedno.Clear()
            txtbedcharge.Clear()
            txtmedicinecharge.Clear()
            txtothercharge.Clear()
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from ipd_patients where pname like '%" & txtsearchbyname.Text & "%'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtid.Text = Val(dr("pid").ToString)
                    txtname.Text = dr("pname").ToString
                    txtage.Text = dr("age").ToString()
                    txtaddr.Text = dr("addr").ToString()
                    txtmobile.Text = dr("mobile").ToString()
                    txtdescription.Text = dr("description").ToString()
                    DateTimePicker1.Text = dr("admit_date").ToString()
                    txtbedno.Text = dr("bed_no").ToString
                End While
                cmd.Dispose()
                con.Close()


                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "select * from bill where pid=" & Val(txtid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()

                        txtbedcharge.Text = Val(dr("bed_charge").ToString)
                        txtmedicinecharge.Text = Val(dr("medicine_charge").ToString)
                        txtothercharge.Text = Val(dr("other_charge").ToString)

                    End While
                End If
                cmd.Dispose()
                con.Close()
                
            Else
                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtid.Clear()
                txtbedno.Clear()
                txtbedcharge.Clear()
                txtmedicinecharge.Clear()
                txtothercharge.Clear()
            End If
            
        End If
    End Sub

    Private Sub txtsearchbyname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearchbyname.TextChanged

    End Sub

    Private Sub txtsearchbymobile_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbymobile.KeyUp
        If txtsearchbymobile.Text = "" Then
            txtname.Clear()
            txtage.Clear()
            txtaddr.Clear()
            txtmobile.Clear()
            txtdescription.Clear()
            txtid.Clear()
            txtbedno.Clear()
            txtbedcharge.Clear()
            txtmedicinecharge.Clear()
            txtothercharge.Clear()

        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from ipd_patients where mobile like '%" & txtsearchbymobile.Text & "%'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtid.Text = Val(dr("pid").ToString)
                    txtname.Text = dr("pname").ToString
                    txtage.Text = dr("age").ToString()
                    txtaddr.Text = dr("addr").ToString()
                    txtmobile.Text = dr("mobile").ToString()
                    txtdescription.Text = dr("description").ToString()
                    DateTimePicker1.Text = dr("admit_date").ToString()
                    txtbedno.Text = dr("bed_no").ToString

                End While
                cmd.Dispose()
                con.Close()

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "select * from bill where pid=" & Val(txtid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()

                        txtbedcharge.Text = Val(dr("bed_charge").ToString)
                        txtmedicinecharge.Text = Val(dr("medicine_charge").ToString)
                        txtothercharge.Text = Val(dr("other_charge").ToString)

                    End While
                End If
                cmd.Dispose()
                con.Close()

            Else
                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtid.Clear()
                txtbedno.Clear()
                txtbedcharge.Clear()
                txtmedicinecharge.Clear()
                txtothercharge.Clear()
            End If
        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtid.Text = "" Then

        Else
            Dim ans As MsgBoxResult
            ans = MsgBox("Really Want to Delete Record ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "delete from ipd_patients where pid=" & Val(txtid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()
                MsgBox("Record Deleted Successfully !")

                txtname.Clear()
                txtage.Clear()
                txtaddr.Clear()
                txtmobile.Clear()
                txtdescription.Clear()
                txtid.Clear()
                txtbedno.Clear()
                txtbedcharge.Clear()
                txtmedicinecharge.Clear()
                txtothercharge.Clear()

            End If
        End If
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If txtid.Text = "" Then

        Else
            Dim ans As MsgBoxResult
            ans = MsgBox("Really Want to Update Record ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then
                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "update ipd_patients set pname='" & txtname.Text & "', age='" & txtage.Text & "', addr='" & txtaddr.Text & "', mobile='" & txtmobile.Text & "', description='" & txtdescription.Text & "',admit_date='" & DateTimePicker1.Value & "' where pid='" & Val(txtid.Text) & "'"
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()

                cmd.Dispose()
                con.Close()

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "update bill set bed_charge=" & Val(txtbedcharge.Text) & ",medicine_charge=" & Val(txtmedicinecharge.Text) & ", other_charge=" & Val(txtothercharge.Text) & " where pid=" & Val(txtid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()
                MsgBox("Record Updated Successfully" + txtid.Text)
                cmd.Dispose()
                con.Close()

            End If
        End If
    End Sub

    Private Sub GroupBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        'Dim gradBrush As New LinearGradientBrush(Me.ClientRectangle, Color.White, Color.SteelBlue, LinearGradientMode.Vertical)
        'e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub



    Private Sub txtsearchbyid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearchbyid.TextChanged

    End Sub
End Class