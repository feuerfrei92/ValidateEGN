using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidatorService;
using SimpleInjector;

namespace ValidatorUI
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<ValidatorForm>());
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.Register<IValidator, Validator>(Lifestyle.Singleton);
            container.Register<IDataDisplayer, DataDisplayer>(Lifestyle.Singleton);
            container.Register<ValidatorForm>(Lifestyle.Singleton);

            container.Verify();
        }
    }
}
