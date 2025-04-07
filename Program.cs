using FranceInformatiqueInventaire.Controlleur;

namespace FranceInformatiqueInventaire
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {/**
          * 4-Sauvegarder les préfèrences
          **/

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormGestion frmGestionRef = new FormGestion();
            Application.Run(frmGestionRef);
        }
    }
}