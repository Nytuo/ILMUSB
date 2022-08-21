Imports System.Net
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 5
        If ProgressBar1.Value <= 10 Then
            Label1.Text = "Préparation du lancement..."
        End If
        If ProgressBar1.Value = 40 Then
            Label1.Text = "Vérification de connexion à Internet..."

        End If
        If ProgressBar1.Value = 50 Then

            Try
                Using client = New WebClient
                    Using Stream = client.OpenRead("https://www.google.fr")
                        Form1.OfflineMode = False
                    End Using
                End Using
            Catch
                Form1.OfflineMode = True
            End Try
        End If
        If ProgressBar1.Value = 60 Then
            Label1.Text = "Accès au info de la clé..."
        End If
        If ProgressBar1.Value = 80 Then
            Label1.Text = "Accès à la base de données du TARDIS..."
        End If
        If ProgressBar1.Value = 90 Then
            Label1.Text = "Lancement en cours..."
        End If
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Form1.Show()
            Me.Close()
        End If
    End Sub
End Class