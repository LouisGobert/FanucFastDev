using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public class ProgramInfo
    {
        public static string name;
        public static string desc;          // La descirption du programme
        public static string groupMask;     // Le group mask
        public static int type;             // Le type de programme [macro, tp]
        public static bool keepBlankLine;   // Si l'on shouite garder les lignes vides.

        public const int TP_PROGRAM = -1; // A définir le nom exacte
        public const int MACRO = 1;


        public static void setDefault()
        {
            name = string.Empty;
            desc = string.Empty;
            groupMask = "*,*,*,*,*";
            type = TP_PROGRAM;
            keepBlankLine = true;

        }
    }
}
