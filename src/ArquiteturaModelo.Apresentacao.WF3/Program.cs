using ArquiteturaModelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF3
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


            //Application.Run(new Form1(new ViewModels.LotacaoViewModel()));

            Application.Run(UnityInitializer.Container.Resolve<Form1>());
        }
    }
}
