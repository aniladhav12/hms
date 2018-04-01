Imports System.Data.OleDb
Public Class frmmanagedoctors
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim sql As String
    Private Sub frmmanagedoctors_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim row As String() = New String() {"1", "Dr. Google baba", "MBBS"}
        'DataGridView1.Rows.Add(row)

        
    End Sub

    Private Sub txtseachbyname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearchbyname.KeyPress

    End Sub

    Private Sub txtseachbyname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyname.KeyUp
        If txtsearchbyname.Text = "" Then
            txtdid.Clear()
            txtdname.Clear()
            txtemail.Clear()
            txtqualification.Clear()
            txtspecialization.Clear()
            txtaddress.Clear()
            txtcontactno.Clear()
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from doctors where dname like '%" & txtsearchbyname.Text & "%'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtdid.Text = dr("did").ToString
                    txtdname.Text = dr("dname").ToString
                    txtqualification.Text = dr("qualification").ToString
                    txtspecialization.Text = dr("specialization").ToString()
                    txtaddress.Text = dr("address").ToString()
                    txtcontactno.Text = dr("contact_no").ToString()
                    txtemail.Text = dr("email").ToString
                End While
                cmd.Dispose()
                con.Close()


            Else
                txtdid.Clear()
                txtdname.Clear()
                txtemail.Clear()
                txtqualification.Clear()
                txtspecialization.Clear()
                txtaddress.Clear()
                txtcontactno.Clear()
            End If

        End If
    End Sub

    Private Sub txtsearchbyname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearchbyname.TextChanged

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub


    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If txtdname.Text = "" Then

        Else
            Dim ans As MsgBoxResult
            ans = MsgBox("Really Want to Update Record ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then
                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "update doctors set dname='" & txtdname.Text & "', qualification='" & txtqualification.Text & "',specialization='" & txtspecialization.Text & "',contact_no='" & txtcontactno.Text & "', email='" & txtemail.Text & "', address='" & txtaddress.Text & "' where did=" & Val(txtdid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()
                MsgBox("Record Updated Successfully !")
                cmd.Dispose()
                con.Close()
            End If
        End If
    End Sub

    Private Sub btnaddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddnew.Click

        txtdname.Clear()
        txtemail.Clear()
        txtqualification.Clear()
        txtspecialization.Clear()
        txtaddress.Clear()
        txtcontactno.Clear()

        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
        con.Open()
        sql = "select max(did) from doctors"
        cmd = New OleDbCommand(sql, con)
        Dim did As Integer
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                did = dr.GetValue(0) + 1
                txtdid.Text = did
            End While
        End If
        cmd.Dispose()
        con.Close()

        btnsave.Enabled = True
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtdname.Text = "" Then
            MsgBox("Please Enter Doctor Name")
            txtdname.Focus()
        ElseIf txtqualification.Text = "" Then
            MsgBox("Please enter Qualification")
            txtqualification.Focus()
        ElseIf txtaddress.Text = "" Then
            MsgBox("Please Enter Address")
            txtaddress.Focus()
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "insert into doctors(dname,qualification,specialization,contact_no,email,address) values('" & txtdname.Text & "','" & txtqualification.Text & "','" & txtspecialization.Text & "','" & txtcontactno.Text & "','" & txtemail.Text & "','" & txtaddress.Text & "')"
            cmd = New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record Saved Successfully !")
            cmd.Dispose()
            con.Close()

            txtdid.Clear()
            txtdname.Clear()
            txtemail.Clear()
            txtqualification.Clear()
            txtspecialization.Clear()
            txtaddress.Clear()
            txtcontactno.Clear()
            btnsave.Enabled = False
        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtdid.Text = "" Then

        Else
            Dim ans As MsgBoxResult
            ans = MsgBox("Really Want to Delete Record ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then

                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
                con.Open()
                sql = "delete from doctors where did=" & Val(txtdid.Text) & ""
                cmd = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()
                MsgBox("Record Deleted Successfully !")

                txtdname.Clear()
                txtqualification.Clear()
                txtaddress.Clear()
                txtcontactno.Clear()
                txtspecialization.Clear()
                txtdid.Clear()
                txtemail.Clear()
                

            End If
        End If
    End Sub

    Private Sub txtsearchbyspecialization_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchbyspecialization.KeyUp
        If txtsearchbyspecialization.Text = "" Then
            txtdid.Clear()
            txtdname.Clear()
            txtemail.Clear()
            txtqualification.Clear()
            txtspecialization.Clear()
            txtaddress.Clear()
            txtcontactno.Clear()
        Else
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\hospital.mdb")
            con.Open()
            sql = "select * from doctors where specialization like '%" & txtsearchbyspecialization.Text & "%'"
            cmd = New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then



                While dr.Read()
                    txtdid.Text = dr("did").ToString
                    txtdname.Text = dr("dname").ToString
                    txtqualification.Text = dr("qualification").ToString
                    txtspecialization.Text = dr("specialization").ToString()
                    txtaddress.Text = dr("address").ToString()
                    txtcontactno.Text = dr("contact_no").ToString()
                    txtemail.Text = dr("email").ToString
                End While
                cmd.Dispose()
                con.Close()


            Else
                txtdid.Clear()
                txtdname.Clear()
                txtemail.Clear()
                txtqualification.Clear()
                txtspecialization.Clear()
                txtaddress.Clear()
                txtcontactno.Clear()
            End If

        End If
    End Sub
End Class