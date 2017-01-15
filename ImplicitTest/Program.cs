using System;
using System.Windows.Forms;

using EyeXFramework.Forms;

namespace ImplicitTest
{
    static class Program
    {
        private static FormsEyeXHost _eyeXHost = new FormsEyeXHost();

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        
        public static FormsEyeXHost EyeXHost
        {
            get { return _eyeXHost; }
        }

        [STAThread]
        static void Main()
        {
            _eyeXHost.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            _eyeXHost.Dispose();
        }
    }
}
