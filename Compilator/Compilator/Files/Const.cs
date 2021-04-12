using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Compilator.Files
{
    class Const
    {
        /// Le chemin actuel (ou l'application se trouve).
        private static string ACTUAL_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        //private static string test = Path.GetDirectoryName(ACTUAL_PATH);


        /// Les chemins vers RobotLibrary.dll et vers un lieu tempon qui servira a stocké
        /// le .dll compilé, c'est lui qui générera en tant que tel le fichier .ls
        public static string ROBOT_LIBRARY_DLL_PATH = Path.Combine(ACTUAL_PATH, "../../../../RobotLibrary/obj/Debug/net5.0/RobotLibrary.dll");
        public static string TMP_DLL_PATH =  Path.Combine(Path.GetTempPath(), "tmpGeneration.dll");

        //public static string solution_name = "FanucFastDev";

        //public static string solution_path = "../../Compilation/loadedProgram/" + solution_name + ".cs";
        //private const string defaultPath = "../../Compilation/loadedProgram/";

        /// Le chemin que l'on va définir au début du programme et qui pointera vers 
        /// le programme .cs à compiler ainsi que son Path par défaut.
        public static string DEFAULT_CS_PATH = Path.Combine(ACTUAL_PATH, "../../../Compilator/loadedProgram/FanucFastDev.cs");
        public static string CS_PATH;      


        /// Le chemin que l'on définit au début du programme qui pointe vers le dossier
        /// ou l'on shouaite stocké les fichiers .ls généres ainsi que son Path par défaut.
        public static string DEFAULT_BUILD_PATH = Path.Combine(ACTUAL_PATH, "../../../../Build/");
        public static string BUILD_PATH;
     
    }
}
