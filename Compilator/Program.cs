using System;
using System.Collections.Generic;
using System.IO;
using Compilator.Files;
using Compilator.Files;


namespace Compilator
{
    class Program
    {

        public enum ExitCode : int
        {
            Cancel = 0,
            Succes = 1,
            ErrorArgs = -1,
            ErrorNotFound = -2
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



            /*
            List<string> arguments = new List<string>(args);

            if (arguments.Count == 0) {
                Console.WriteLine("Argument manquant.");
                usagePrint();

                return -1;
            } else if (arguments.Count == 2) {

                // Si programme par défault
                if (arguments.Contains("-c") || arguments.Contains("--cs")) {
                    Const.CS_PATH = Files.Const.DEFAULT_CS_PATH;
                } else {
                    if (File.Exists(args[0]))
                        Const.CS_PATH = args[0];
                    else {
                        Console.WriteLine("Le chemin vers le fichier .cs n'est pas valide/n'existe pas.\n");
                        return -1;
                    }
                }

                if (arguments.Contains("-b") || arguments.Contains("--build")) {
                    Const.BUILD_PATH = Files.Const.DEFAULT_BUILD_PATH;
                } else {
                    if (Directory.Exists(args[1]))
                        Const.BUILD_PATH = args[1];
                    else {
                        Console.WriteLine("Le chemin du dossier de destination n'est pas valide/n'existe pas.\n");
                        return -1;
                    }
                }

                
                // Début de la compilation
                Console.WriteLine("Début de la génération...");
                Compilation.startCompilation(); // true pour garder les lignes vides
                
            }*/

            PrintUsage();
            return (int)ExitCode.ErrorArgs;
        }

        private static int BuildTemplate(string[] args) {

            // Folder path by default, not implemented
            Const.BUILD_PATH = Const.DEFAULT_BUILD_PATH;

            // Obtention du nom sans le .cs
            string buildName = (Path.GetExtension(args[1]) == string.Empty) ? args[1] : args[1].Substring(0, args[1].IndexOf('.'))  ;

            Const.CS_PATH = Path.Combine(Const.DEFAULT_CS_PATH, buildName + ".cs");


            if (File.Exists(Const.CS_PATH)) {

                Const.CS_NAME = buildName;
                Console.WriteLine("Début de la génération...");
                Compilation.startCompilation();
                return (int)ExitCode.Succes;
            } 
            else 
            {
                Console.WriteLine($"Le nom du fichier \"{buildName}\" n'existe pas dans le dossier \"{Const.DEFAULT_CS_PATH}\"");
                return (int)ExitCode.ErrorNotFound;
            }
        }

        



        private static void PrintUsage() {
            Console.WriteLine(  "Usage:  \n" +
                    "  ./Compilator [ACTION] [FILE NAME]\n\n" +
                    "Application Actions:\n" +
                    "  -n ,  new         Créer une nouvelle template .cs\n" +
                    "  -b ,  build       Dossier de stockage par défaut\n");
        }

    }
}


// dotnet run --project ShowCase/ShowCase.csproj