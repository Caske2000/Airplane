using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotPlanes
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
            Application.Run(new Form1());

            Setup();
        }

        private static void Setup()
        {
            // Variabelen bovenaan
            


            // Som alle files op die in de Afbeeldingen/picturen van de user staan

            // Zet alle paden naar de afbeeldingen in een String array

            // Itereer over elke foto en vergelijk (VEEL WERK & MOEILIJK)
        }
    }
}
