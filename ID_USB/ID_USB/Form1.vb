Imports System.IO
Imports System.IO.Directory
Imports System.Net.Mail
Imports System.Net
Public Class Form1
    Public OfflineMode As Boolean
    Private NomproprioUSB As String = "Arnaud BEUX"
    Private TelproprioUSB As String = "07.82.16.74.88"
    Private emailproprioUSB As String = "arnaud.beux.ab@gmail.com"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If OfflineMode = True Then
            Label5.Text = "Sur : " + System.Environment.MachineName + " / Non connecter"
            Button1.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        Else
            Label5.Text = "Sur : " + System.Environment.MachineName + " / Connecter"
        End If
        Label6.Text = "Version : " + Application.ProductVersion
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Voici quelques moyens de contacter " + NomproprioUSB + " : " + vbNewLine + "Téléphone : " + TelproprioUSB + vbNewLine + "Email : " + emailproprioUSB, MsgBoxStyle.Information, "ILMUSB - Info Utilisateur")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OfflineMode = False Then
            Dim strHistName As String = System.Net.Dns.GetHostName
            Dim elmail As String = TextBox2.Text
            Dim mail As New MailMessage
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            mail.From = New MailAddress("nytuogames.launcher@gmail.com")
            mail.To.Add("arnaud.beux.ab@gmail.com")
            mail.Subject = "ILMUSB - Clé perdu"
            mail.Body = TextBox1.Text.ToString + vbNewLine + "Nom de l'ordi : " + System.Environment.MachineName.ToString + vbNewLine + "Adresse mail :" + elmail + vbNewLine + "IP : " + System.Net.Dns.GetHostByName(strHistName).AddressList(0).ToString
            SMTP.Port = "587"
            SMTP.Credentials = New System.Net.NetworkCredential("nytuogames.launcher@gmail.com", "adzawadzpisieqvg")
            SMTP.EnableSsl = True
            SMTP.Send(mail)
            MsgBox("Email Envoyé !", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
