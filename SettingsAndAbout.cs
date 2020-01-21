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
            this.Close();
        }
    }
}
