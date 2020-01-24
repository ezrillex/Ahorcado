using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sentry;
using Flurl.Http;
using System.Media;

namespace Ahorcado
{
    public partial class SendFeedback : Form
    {
        SoundPlayer sound_click = new SoundPlayer("Click.wav");

        public SendFeedback()
        {
            InitializeComponent();
        }

        private async void button_sendfeedback_Click(object sender, EventArgs e)
        {
            sound_click.Play();
            string name = textBox_nombre.Text;
            string email = textBox_email.Text;
            string comment = textBox_comentario.Text;
            try
            {
                SentrySdk.CaptureEvent(new SentryEvent(new Exception("User Feedback")));
                var a = SentrySdk.LastEventId;
                var responseString = await "https://sentry.io/api/0/projects/ezra-abarca/ahorcado-csharp-pc/user-feedback/"
                    .WithHeader("Authorization", "DSN https://f3eeb95f9d5c4085b3d1672f3ff4cb74@sentry.io/1894899")
                    .PostUrlEncodedAsync(new { comments = comment, email = email, event_id = a, name =name})
                    .ReceiveString();
                Console.WriteLine(responseString);

                MessageBox.Show("Comentarios enviados exitosamente, gracias por su tiempo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureEvent(new SentryEvent(ex));
                MessageBox.Show("Ocurrio un error al enviar el reporte. Esto ha sido reportado, gracias por su tiempo.", "Error al enviar comentarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void SendFeedback_FormClosing(object sender, FormClosingEventArgs e)
        {
            sound_click.Dispose();
        }
    }
}
