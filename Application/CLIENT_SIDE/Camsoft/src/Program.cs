using System;
using System.Windows.Forms;

namespace Camsoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* AppDomain.CurrentDomain.UnhandledException
             += delegate (object sender, UnhandledExceptionEventArgs args)
             {
                 var exception = (Exception)args.ExceptionObject;
                 ACHP._instance.myConsoleWrite("Unhandled exception: " + exception);
             };*/
            try { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Achp());
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                Application.Restart();
            }
        }
    }
}
