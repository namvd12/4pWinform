using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GiamSat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            //Application.Run(new CauhinhThietbi());
            //Application.Run(new DanhsachThietbi());

            gMainForm = new Main();
            Application.Idle += OnApplicationIdle;
            Application.Run(gMainForm);
        }

        public static Main gMainForm;
        static EventHandler OnApplicationIdle = new EventHandler(Application_Idle);
        static void Application_Idle(object sender, EventArgs e)
        {

        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.Idle -= OnApplicationIdle;
        }

    }
}
