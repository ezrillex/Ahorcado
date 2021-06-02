using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class SplashScreen : Form
    {

        Timer CheckLoadedFinished = new Timer();

        public SplashScreen()
        {
            InitializeComponent();
            label_version.Text = "v " + Data.version;
            InitLoadCheck();
        }

        private void InitLoadCheck()
        {
            CheckLoadedFinished.Interval = 2000;
            CheckLoadedFinished.Enabled = true;
            CheckLoadedFinished.Tick += new EventHandler(LoadCheckTick);
            CheckLoadedFinished.Start();

            Sonido.Init();
            Data.Init();
            Data.InitializationFinished = true;
        }

        private void LoadCheckTick(object sender, EventArgs e)
        {
            if(Data.InitializationFinished is true)
            {
                CheckLoadedFinished.Stop();
                CheckLoadedFinished.Enabled = false;
                this.Close(); //if I close this the entire app closes.
            }
        }
    }
    
}
