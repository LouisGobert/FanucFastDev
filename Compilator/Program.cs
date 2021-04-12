using System;
using System.Collections.Generic;
using System.IO;
using Compilator.Files;
using System.Reflection;


namespace Compilator
{
    class Program
    {
        static int Main(string[] args)
        {

            List<string> arguments = new List<string>(args);

            if (arguments.Count < 2) {
                Console.WriteLine("Argument manquant.");
                usagePrint();

                return -1;
            } else if (arguments.Count == 2) {

                //string path_src;
                //string path_dest = string.Empty;

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
                
            }

            Console.WriteLine("Fin de la génération.");

            return 1;
        }

        private static void usagePrint() {
            Console.WriteLine(  "Usage:  \n" +
                    "  ./Compilator [OPTION] <program source> <folder dest>\n\n" +
                    "Application Options:\n" +
                    "  -c, --cs                 Programme Source par défaut\n" +
                    "  -b, --build              Dossier de stockage par défaut\n");
        }

    }
}


// dotnet run --project ShowCase/ShowCase.csproj