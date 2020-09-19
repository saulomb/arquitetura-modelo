using ArquiteturaModelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF
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
            // SimpleInjectorInitializer.Initialize();
            UnityInitializer.Initialize();
            RegisterMappings.Register();


            // Application.Run(SimpleInjectorInitializer.Container.GetInstance<Form2>());
            Application.Run(UnityInitializer.Container.Resolve<Form2>());
        }
    }
}
