using System;
using System.Windows.Forms;

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
            checkBox_darkmode.Checked = Data.DarkMode;
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

     

  

        private void button_Notas_Click(object sender, EventArgs e)
        {
            Sonido.Click();
            System.Diagnostics.Process.Start("https://github.com/ezrillex/Ahorcado/blob/master/CHANGELOG.md");

        }

        private void checkBox_darkmode_CheckedChanged(object sender, EventArgs e)
        {
            Sonido.Click();

            if (checkBox_darkmode.Checked is true)
            {
                Data.DarkMode = true;
            }
            else if (checkBox_darkmode.Checked is false)
            {
                Data.DarkMode = false;
            }

            Data.RecentlyChangedTheme = true;
            Data.UpdateDarkMode();
        }
    }
}
