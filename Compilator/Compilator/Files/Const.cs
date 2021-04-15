using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Compilator.Files
{
    public static class Const
    {
        /// Le chemin actuel (ou l'application se trouve).
        private static readonly string ACTUAL_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        /// Les chemins vers RobotLibrary.dll et vers un lieu tempon qui servira a stocké
        /// le .dll compilé, c'est lui qui générera en tant que tel le fichier .ls
        public static readonly string ROBOT_LIBRARY_DLL_PATH = Path.Combine(ACTUAL_PATH, "../../../../RobotLibrary/obj/Debug/net5.0/RobotLibrary.dll");
        public static readonly string TMP_DLL_PATH =  Path.Combine(Path.GetTempPath(), "tmpGeneration.dll");

        /// Le chemin que l'on va définir au début du programme et qui pointera vers 
        /// le programme .cs à compiler ainsi que son Path par défaut.
        public static string DEFAULT_CS_PATH = Path.Combine(ACTUAL_PATH, "../../../Workcell/");
        public static string CS_PATH;      


        /// Le chemin que l'on définit au début du programme qui pointe vers le dossier
        /// ou l'on shouaite stocké les fichiers .ls généres ainsi que son Path par défaut.
        public static string DEFAULT_BUILD_PATH = Path.Combine(ACTUAL_PATH, "../../../../Build/");
        public static string BUILD_PATH;

        /// Le chemin qui contient la template de base des .cs
        public static string CS_TEMPLATE_PATH = Path.Combine(ACTUAL_PATH, "../../../Compilator/Src/TEMPLATE_CLASS.cs");

        // Le nom du fichier ls a build
        public static string CS_NAME;

    }
}
