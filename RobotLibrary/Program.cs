using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public class Program
    {
        public static string name;
        public static string desc;
        public static string groupMask;
        public static int type;

        public const int TP_PROGRAM = -1; // A définir le nom exacte
        public const int MACRO = 1;

        /*public static void createProgramInfo()
        {

        }*/

        public static void setDefault()
        {
            name = string.Empty;
            desc = string.Empty;
            groupMask = "*,*,*,*,*";
            type = TP_PROGRAM;

        }
    }
}
