using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sentry;

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
            using (SentrySdk.Init("https://f3eeb95f9d5c4085b3d1672f3ff4cb74@sentry.io/1894899"))
            {
                // App code
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GameForm());
            }
            
        }
    }
}
