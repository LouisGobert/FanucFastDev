using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator.FileGestion
{
    class FileGestion
    {
        public static string DEFAULT_PROG = @"/home/louis/Documents/dev/c#/FanucFastDev/Compilator/Compilator/loadedProgram/FanucFastDev.cs";
        public static string DEFAULT_DLL = @"/tmp/" + Path.GetRandomFileName() + ".dll";

        public static string DEFAULT_FOLDER = @"/home/louis/Documents/dev/c#/FanucFastDev/GeneratedProgram";
        public static string solution_name = "FanucFastDev";
        public static string solution_path = "../../Compilation/loadedProgram/" + solution_name + ".cs";
        private const string defaultPath = "../../Compilation/loadedProgram/";
        //public const string TPtemplatePath = "../../Compilation/src/template/tp_template.LS";


        public static void loadSolution()
        {


            throw new NotImplementedException("loadSolution() pas encore implémenté");
            

        }


        private static string openSolution(string path)
        {
            /* Ouvre une solution et vérifie qu'elle contient une class FanucFastDev */


            if (File.Exists(path)) {
                string[] fileContent = File.ReadAllLines(path);

                // Vérification de la contenance du class FanucFastDev
                foreach (string s in fileContent)
                    if (s.Contains("class") && s.Contains(solution_name))
                        return path;
            }

            return null;
        }


        public static string[] getFileLine(string filePath) {

            string[] fileLine = null;

            try
            {
                fileLine = File.ReadAllLines(filePath);
            } catch (Exception ex) {
                Console.WriteLine($"Ouverture impossible du fichier \"{filePath}\".\nErreur : {ex}");
            }

            return fileLine;

        }

        public static string compiledFolder(string path)
        {
            /* Permet de spécifé le lieu de sauvegarde d'une solution */

            /// PAR DEFAULT DANS LE Même répéertoire que le fichier FanucFastDev.cs

            return path;
            

            return null;
        }


       
    }
}
