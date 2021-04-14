using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotLibrary.Global.InOut;
using RobotLibrary.Global;


namespace RobotLibrary
{
    public class Const
    {

        public const ushort MAX_RO = 100;
        public const ushort MAX_PR = 100;
        public const ushort MAX_F  = 100;
        public const ushort MAX_R  = 100;
        public const ushort MAX_UFRAME  = 10;
        public const ushort MAX_UTOOL  = 10;
  
        

        public const ushort COMMENT_MAX_CHAR = 24; // A vérifié
        public const ushort PR_DESC_MAX_CHAR = 24; // A vérifié
        public const ushort R_DESC_MAX_CHAR = 24; // A vérifié
        public const ushort PRINT_MAX_CHAR = 24; // A vérifié
        public const ushort UFRAME_MAX_CHAR = 24;// A vérifié
        public const ushort UTOOL_MAX_CHAR = 24;// A vérifié
        

        public const ushort FINE = 0;


        public const bool P = true;
        public const bool J = false;
        public const ushort TP_PROGRAM = 0; // A définir le nom exacte
        public const ushort MACRO = 1;


        public static RO[] RO = RobotLibrary.Global.InOut.RO.Init();
        public static Flag[]   Flag = RobotLibrary.Global.InOut.Flag.Init();
        public static PosReg[] PR = RobotLibrary.Global.PosReg.Init();
        public static Reg[] R = RobotLibrary.Global.Reg.Init();
        public const string ON = "ON";
        public const string ON_FM = "ONFM";
        public const string OFF = "OFF";
        public const string OFF_FD = "OFFFD";



        public static Uframe[] UserFrame = Uframe.Init();
        public static Uframe UFRAME_NUM = UserFrame[0];

        public static Utool[] UserTool = Utool.Init();
        public static Utool UTOOL_NUM = UserTool[0];


    }
}
