using BL;
using System.Data;

namespace ProyectoIITrim_GabrielMartinezCamareno11E
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            RAM_BL bl = new RAM_BL();
            DataTable dt = bl.BuscarRam();
            MessageBox.Show(dt.Rows.Count.ToString());
        }
    }
}