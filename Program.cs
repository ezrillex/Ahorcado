using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

           
            // App code
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen()); // Initialization
            Application.Run(new GameForm()); // Main Game

            // Dispose unusued resources
            Sonido.Dispose();
            Data.Dispose();
            
            
        }
    }
}
