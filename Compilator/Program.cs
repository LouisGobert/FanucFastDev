using System;
using System.Collections.Generic;
using System.IO;
using Compilator.FileGestion;


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

                string path_src;
                string path_dest = string.Empty;

                // Si programme par défault
                if (arguments.Contains("-p") || arguments.Contains("--prog-dft")) {
                    path_src = FileGestion.FileGestion.DEFAULT_PROG;
                } else {
                    path_src = args[0];
                }

                if (arguments.Contains("-s") || arguments.Contains("--fold-dft")) {
                    path_dest = FileGestion.FileGestion.DEFAULT_FOLDER;
                } else {
                    path_dest = args[1];
                }

                

                string acutualPath = Directory.GetCurrentDirectory();
                Console.WriteLine("Path actuelle : " + acutualPath);

                if (File.Exists(path_src)) {
                    if (Directory.Exists(path_dest)) {
                        Console.WriteLine("Début de la génération...");
                        Compilation.startCompilation(path_src,true); // true pour garder les lignes vides
                        
                    }
                }


            }

            Console.WriteLine("Fin de la génération.");

            return 1;
        }

        private static void usagePrint() {
            Console.WriteLine(  "Usage:  \n" +
                    "  ./Compilator [OPTION] <program source> <folder dest>\n\n" +
                    "Application Options:\n" +
                    "  -p, --prog-dft           Programme Source par défaut\n" +
                    "  -s, --fold-dft           Dossier de stockage par défaut\n" +
                    "  -k, --keep-blanck        Garder les lignes vides\n");
        }

    }
}


// dotnet run --project ShowCase/ShowCase.csproj