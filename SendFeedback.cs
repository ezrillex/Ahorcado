using System;
using System.Windows.Forms;
using Sentry;
using Flurl.Http;

namespace Ahorcado
{
    public partial class SendFeedback : Form
    {
        public SendFeedback()
        {
            InitializeComponent();
        }

        private async void button_sendfeedback_Click(object sender, EventArgs e)
        {
            Sonido.Click();
            string name = textBox_nombre.Text;
            string email = textBox_email.Text;
            string comments = textBox_comentario.Text;

            //Validate that email has correct format, atleast an @ otherwise it will rise a 400 bad post
            if(email.Contains("@") is false)
            {
                //MessageBox.Show("La direccion de correo es invalida")
                errorProvider1.SetError(textBox_email, "El email especificado es invalido.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            try
            {
                 /* This is a breadcrumb not something that will be sent; deprecated for that reason
                string msg = "Name: {0}, Email: {1}, Comment: {2}";
                msg = string.Format(msg, name, email, comment);
                SentrySdk.CaptureMessage("", Sentry.Protocol.SentryLevel.Fatal);
                */
                
                SentrySdk.CaptureEvent(new SentryEvent(new Exception("User Feedback")));
                var event_id = SentrySdk.LastEventId;
                var responseString = await "https://sentry.io/api/0/projects/ezra-abarca/ahorcado-csharp-pc/user-feedback/"
                    .WithHeader("Authorization", "DSN https://f3eeb95f9d5c4085b3d1672f3ff4cb74@sentry.io/1894899")
                    .PostUrlEncodedAsync(new { comments, email, event_id, name})
                    .ReceiveString();
                
                Console.WriteLine(responseString);
                
                MessageBox.Show("Comentarios enviados exitosamente, gracias por su tiempo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FlurlHttpException ex)
            {
                SentrySdk.CaptureException(ex);
                MessageBox.Show("Ocurrio un error al enviar el reporte. Esto ha sido reportado, gracias por su tiempo.", "Error al enviar comentarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

    }
}
