using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator.Files
{
    class FileGestion
    {
        
        /*
        private static string openSolution(string path)
        {
            /* Ouvre une solution et vérifie qu'elle contient une class FanucFastDev 


            if (File.Exists(path)) {
                string[] fileContent = File.ReadAllLines(path);

                // Vérification de la contenance du class 
                foreach (string s in fileContent)
                    if (s.Contains("class"))
                        return path;
            }

            return null;
        }*/


        public static string[] getFileLine(string path) {

            string[] fileLine = null;

            try
            {
                fileLine = File.ReadAllLines(path);
            } catch (Exception ex) {
                Console.WriteLine($"Ouverture impossible du fichier  : \"{path}\".\nErreur : {ex}");
            }

            return fileLine;

        }

        /// Surcharge de la fonction affin de rendre l'autre fonction getFileLine
        /// plus flexibles.
        public static string[] getFileLine() {
            return getFileLine(Const.CS_PATH);
        }


        /*public static string compiledFolder(string path)
        {
            /* Permet de spécifé le lieu de sauvegarde d'une solution 

            /// PAR DEFAULT DANS LE Même répéertoire que le fichier FanucFastDev.cs

            return path;
            

            return null;
        }*/
       
    }
}
