using System;
using System.IO;

namespace Compilator.Files
{
    class FileGestion
    {

        public static string[] GetFileLine(string path) {

            string[] fileLine = null;

            try
            {
                fileLine = File.ReadAllLines(path);
            } catch (Exception ex) {
                Console.WriteLine($"Ouverture impossible du fichier  : \"{path}\".\nErreur : {ex}");
            }

            return fileLine;
        }


        public static int NewTemplate(string[] args)
        {

            // On vérifie qu'il n'y a pas de .cs
            string csName = (Path.GetExtension(args[1]) == string.Empty) ? args[1] : args[1].Substring(0, args[1].IndexOf('.'))  ;
            string newTemplatePath = Path.Combine(Const.DEFAULT_CS_PATH, csName + ".cs");

            // On vérifié qu'un fichier n'existe pas déjà sous le même nom.
            if (File.Exists(newTemplatePath))
            {

                Console.WriteLine($"Un fichier portant le nom \"{csName}\" existe déjà dans le dossier \"{Const.DEFAULT_CS_PATH}\"");

                string choice;
                do
                {
                    Console.Write("Voulez-vous l'écraser ? [(O)ui / (n)on] ?");
                    choice = Console.ReadLine();
                } while (choice.Length != 1 && (choice[0] != 'O' || choice[0] != 'n'));

                // Annulation
                if (choice[0] == 'n')
                {
                    Console.WriteLine("Annulation de la création.");
                    return (int)Program.ExitCode.Cancel;
                }
            }

            /// Ouverture de la template
            /// Changement de son nom de class
            /// Changement de sa fonction d'entré (Main)
            /// Enregistrement dans newTemplatesPath

            string[] templateLines = GetFileLine(Const.CS_TEMPLATE_PATH);

            string line;
            for (int i = 0; i < templateLines.Length; i++) {
                line = templateLines[i];

                if (line.Contains("TEMPLATE_CLASS"))
                    templateLines[i] = templateLines[i].Replace("TEMPLATE_CLASS", csName);
                else if (line.Contains("TEMPLATE_MAIN")) {
                    templateLines[i] = templateLines[i].Replace("TEMPLATE_MAIN", "Main_" + csName);

                    i = templateLines.Length;
                }
            }

            try 
            {
                FileStream fs = File.Create(newTemplatePath);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    
                    foreach (string l in templateLines) {
                        sw.WriteLine(l);
                    }

                }
            } 
            catch 
            {
                Console.WriteLine("Erreur lors de la création du fichier.");
            }

            Console.WriteLine($"Creation du fichier \"{csName}\" dans le dossier \"Workcell/\" réussi.");

            return (int)Program.ExitCode.Succes;

        }
    }
}
