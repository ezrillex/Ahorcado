using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Media;

namespace Ahorcado
{
    public partial class SettingsAndAbout : Form
    {
        SoundPlayer sound_Click = new SoundPlayer("Click.wav");

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
            sound_Click.Play();
            this.Close();
        }

        private void checkBox_antialiasing_CheckedChanged(object sender, EventArgs e)
        {
            sound_Click.Play();

            if (checkBox_antialiasing.Checked == true)
            {
                GameForm.AntialiasEnabled = true;
            }
            else if (checkBox_antialiasing.Checked == false)
            {
                GameForm.AntialiasEnabled = false;
            }
        }

        private void SettingsAndAbout_Load(object sender, EventArgs e)
        {
            checkBox_antialiasing.Checked = GameForm.AntialiasEnabled;
        }

        private void button_ResetScore_Click(object sender, EventArgs e)
        {
            sound_Click.Play();

            DialogResult dialogResult = MessageBox.Show
                ("Esta accion reiniciara tu puntaje permanente a 0. ¿Estas seguro que quieres continuar?",
                "Confirmar reinicio de puntaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            sound_Click.Play();

            if (dialogResult == DialogResult.Yes)
            {
                GameForm.Puntaje = 0;

                MessageBox.Show
                    ("El puntaje ha sido reiniciado a 0",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            sound_Click.Play();
        }

        private void SettingsAndAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            sound_Click.Dispose();
        }

    }
}
