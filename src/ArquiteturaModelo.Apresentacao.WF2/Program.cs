using ArquiteturaModelo.Apresentacao.WF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SimpleInjectorInitializer.Initialize();
            //Application.Run(new Views.FormLotacao());
            Application.Run(SimpleInjectorInitializer.Container.GetInstance<Views.FormLotacao>());
        }
    }
}
