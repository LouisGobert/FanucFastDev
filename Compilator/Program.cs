using System;
using System.Diagnostics;
using System.IO;
using Compilator.Files;

namespace Compilator
{
    class Program
    {

        public enum ExitCode : int
        {
            Cancel = 0,         /// Annulation
            Succes = 1,         /// Succès
            ErrorArgs = -1,     /// Argument invalide
            ErrorNotFound = -2  /// Fichier introubale
        }

        static int Main(string[] args)
        {

            if (args.Length < 2)
            {
                Console.WriteLine("Argument manquant.");
                PrintUsage();
                return (int)ExitCode.ErrorArgs;
            }
            else if (args[0] == "-n" || args[0] == "new")
                return FileGestion.NewTemplate(args);
            else if (args[0] == "-b" || args[0] == "build")
                return BuildTemplate(args);
            else if (args[0] == "-o" || args[0] == "open")
                return OpenCode(args);

            PrintUsage();
            return (int)ExitCode.ErrorArgs;
        }

        /// <summary>
        ///     Fonction qui va initier la génération des fichiers .ls et qui va
        ///     configuré les constantes de path de builds.
        /// </summary>
        /// <param name="args"> La listes des arguments fourni par l'utilisateur </param>
        /// <returns></returns>
        private static int BuildTemplate(string[] args) {

            // Folder path by default, not implemented
            Const.BUILD_PATH = Const.DEFAULT_BUILD_PATH;

            // Obtention du nom sans le .cs
            string buildName = (Path.GetExtension(args[1]) == string.Empty) ? args[1] : args[1].Substring(0, args[1].IndexOf('.'))  ;

            Const.CS_PATH = Path.Combine(Const.DEFAULT_CS_PATH, buildName + ".cs");


            if (File.Exists(Const.CS_PATH)) {

                Const.CS_NAME = buildName;
                Console.WriteLine("Début de la génération...");
                Compilation.Start();
                return (int)ExitCode.Succes;
            } 
            else 
            {
                Console.WriteLine($"Le nom du fichier \"{buildName}\" n'existe pas dans le dossier \"{Const.DEFAULT_CS_PATH}\"");
                return (int)ExitCode.ErrorNotFound;
            }
        }

        /// <summary>
        ///     Permet d'ouvir un programme passé en argument dans VS Code.
        /// </summary>
        /// <param name="args"> La listes des arguments fourni par l'utilisateur </param>
        /// <returns> ExitStatus </returns>
        private static int OpenCode(string[] args) {

            string codeName = (Path.GetExtension(args[1]) == string.Empty) ? args[1] + ".cs" : args[1];
            string codePath = Path.Combine(Const.DEFAULT_CS_PATH, codeName);

            if (!File.Exists(codePath)) {
                Console.WriteLine($"Fichier : \n{codeName}\" introuvable.");
                return (int)ExitCode.ErrorNotFound;
            }

            Process.Start("code", codePath);
            return (int)ExitCode.Succes;
        }

        /// <summary>
        ///     Fonction qui affiche dans la console les différent parramètre
        ///     et fonction de l'application.
        /// </summary>
        private static void PrintUsage() {
            Console.WriteLine("Usage:  \n" +
                    "  ./Compilator [ACTION] [FILE NAME]\n\n" +
                    "Actions:\n" +
                    "  -n ,  new         Créer une nouvelle template .cs\n" +
                    "  -b ,  build       Build un programme .cs\n" +
                    "  -o ,  open        Ouvrir une programme .cs\n" +
                    "\n" +
                    "File Name:\n" +
                    "  Le nom du fichier à créer/build/ouvrir");
        }

    }
}
