using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public class Generation
    {
        //public static string generatePath; // Le chemin du fichier .LS en cours de modification

        private static int indexLsLine;

        //public static string globalPath;
        private static string savePath;

        private static string progInstru;



        /* Initialisation de la génération du fichier .LS */
        /*public static void globalInit() {

            if (Directory.Exists(pathFolder))
            {
                globalPath = pathFolder;
                Console.WriteLine("Lieu de sauvegarde : " + globalPath);
            } else
            {
                throw new Exception("Le dossier sélectionner n'existe pas.");
            }

        }*/

        public static string setupInfo()
        {
            //savePath = newSavePath;
            

            // Supression des point déjà existant
            /*
            pos.deleteAllPos();

            savePath += programName.ToUpper() + ".LS";
            Console.WriteLine("GLOBAL path = " + savePath);
            Console.WriteLine("Generated path = " + savePath);
            indexLsLine = 1;*/


            
         

            string progInfo =        $"/PROG  {Program.name}\n" 
                                + "/ATTR\n"
                                + "OWNER       = MNEDITOR;\n"
                                + $"COMMENT     = \"{Program.desc}\";\n"
                                + "PROG_SIZE   = 1382;\n"
                                + "CREATE      = DATE 20-10-15  TIME 15:42:30;\n"
                                + "MODIFIED    = DATE 20-10-15  TIME 16:10:46;\n"
                                + "FILE_NAME   = ;\n"
                                + "VERSION     = 0;\n"
                                + $"LINE_COUNT  = {indexLsLine-1};\n"
                                + "MEMORY_SIZE = 1662;\n"
                                + "PROTECT     = READ_WRITE;\n"
                                + "TCD:  STACK_SIZE        = 0,\n"
                                + "      TASK_PRIORITY     = 50,\n"
                                + "      TIME_SLICE        = 0,\n"
                                + "      BUSY_LAMP_OFF     = 0,\n"
                                + "      ABORT_REQUEST     = 0,\n"
                                + "      PAUSE_REQUEST     = 0;\n"
                                + $"DEFAULT_GROUP   = {Program.groupMask};\n"
                                + "CONTROL_CODE    = 00000000 00000000;\n"
                                + "/APPL\n"
                                + "/MN\n";




            return progInfo;

        }


        public static void setup(string programName, string newSavePath)
        {

            // Supression des point déjà existant
            pos.deleteAllPos();
            savePath = newSavePath;
            savePath += programName.ToUpper() + ".LS";
            indexLsLine = 1;
            progInstru = string.Empty;
            Program.setDefault();

            Program.name = programName;
        }

        public static void appendLine(string line)
        {
            //progInstru += $"   {indexLsLine}:{line}\n";
            progInstru += string.Format("{0, 4}:{1}\n", indexLsLine++, line);
        }

        public static void appendXBlankLine(int x)
        {
            for (int i = 0; i < x; i++)
                appendLine("   ;");
        }



        public static void finish()
        {

            string progFinal = setupInfo() + progInstru + "/POS\n" + pos.generateAllPoint() + "/END\n";




            Console.WriteLine("\n\n########################################\nFinished program :\n");
            Console.WriteLine(progFinal);

            // Création du fichier final
            Console.WriteLine("Fichier créer sous : " + savePath);
            try
            {
                if (File.Exists(savePath))
                    File.Delete(savePath);
                FileStream fs = File.Create(savePath);

                using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                {
                    sw.Write(progFinal);
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Erreur = {ex}");
            }

        }


        
    }
}
