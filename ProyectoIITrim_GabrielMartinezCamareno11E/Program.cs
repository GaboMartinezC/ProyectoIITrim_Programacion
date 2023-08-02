using BL;
using ET;
using ET.DTO;
using WEB.Utilities;
using System.Data;
using System.Windows.Forms;

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
            var dt = bl.EliminarRam(2);
            if (dt)
                MessageBox.Show("1");
            else
                MessageBox.Show("2");
        }
    }
}