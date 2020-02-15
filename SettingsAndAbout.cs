using System;
using System.Windows.Forms;
using Sentry;

namespace Ahorcado
{
    public partial class SettingsAndAbout : Form
    {
        public SettingsAndAbout()
        {
            InitializeComponent();
        }

        private void linkLabel_donos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/ezrillex");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sonido.Click();
            this.Close();
        }

        private void checkBox_antialiasing_CheckedChanged(object sender, EventArgs e)
        {
            Sonido.Click();

            if (checkBox_antialiasing.Checked == true)
            {
                Data.AntialiasEnabled = true;
            }
            else if (checkBox_antialiasing.Checked == false)
            {
                Data.AntialiasEnabled = false;
            }
        }

        private void SettingsAndAbout_Load(object sender, EventArgs e)
        {
            checkBox_antialiasing.Checked = Data.AntialiasEnabled;
            label2.Text += Data.version;
        }

        private void button_ResetScore_Click(object sender, EventArgs e)
        {
            Sonido.Click();

            DialogResult dialogResult = MessageBox.Show
                ("Esta accion reiniciara tu puntaje permanente a 0. ¿Estas seguro que quieres continuar?",
                "Confirmar reinicio de puntaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            Sonido.Click();

            if (dialogResult == DialogResult.Yes)
            {
                Data.Puntaje = 0;

                MessageBox.Show
                    ("El puntaje ha sido reiniciado a 0",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Sonido.Click();

            }
        }

        private void button_ReportWord_Click(object sender, EventArgs e)
        {
            Sonido.Click();
            try
            {
                string ContenidoDeReporte = Data.History.ToSerializedUnverified();
                SentrySdk.CaptureEvent(new SentryEvent(new Exception("User is reporting words: " + Data.History.ToSerializedUnverified())));
                MessageBox.Show("La palabra fue reportada exitosamente. Tomaremos su retroalimentacion en cuenta en futuras actualizaciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }catch(Exception ex)
            {
                SentrySdk.CaptureException(ex);
                MessageBox.Show("Ocurrio un error al enviar el reporte. Esto ha sido reportado, gracias por su tiempo.", "Error al enviar palabras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sonido.Click();
            SendFeedback sendFeedback = new SendFeedback();
            sendFeedback.Owner = this;
            sendFeedback.ShowDialog();
        }
    }
}
