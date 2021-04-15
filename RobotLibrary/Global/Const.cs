using RobotLibrary.Global.InOut;
using RobotLibrary.Global;


namespace RobotLibrary.Global
{
    public static class Const
    {

        public static readonly ushort MAX_RO = 100;
        public static readonly ushort MAX_PR = 100;
        public static readonly ushort MAX_F  = 100;
        public static readonly ushort MAX_R  = 100;
        public static readonly ushort MAX_UFRAME  = 10;
        public static readonly ushort MAX_UTOOL  = 10;
  
        

        public static readonly ushort COMMENT_MAX_CHAR = 24; // A vérifié
        public static readonly ushort PR_DESC_MAX_CHAR = 24; // A vérifié
        public static readonly ushort R_DESC_MAX_CHAR = 24; // A vérifié
        public static readonly ushort PRINT_MAX_CHAR = 24; // A vérifié
        public static readonly ushort UFRAME_MAX_CHAR = 24;// A vérifié
        public static readonly ushort UTOOL_MAX_CHAR = 24;// A vérifié
        

        public static readonly ushort FINE = 0;


        public static readonly bool P = true;
        public static readonly bool J = false;
        public static readonly ushort TP_PROGRAM = 0; // A définir le nom exacte
        public static readonly ushort MACRO = 1;


        public static readonly RO[] RO = RobotLibrary.Global.InOut.RO.Init();
        public static readonly Flag[]   Flag = RobotLibrary.Global.InOut.Flag.Init();
        public static readonly PosReg[] PR = RobotLibrary.Global.PosReg.Init();
        public static readonly Reg[] R = RobotLibrary.Global.Reg.Init();
        public static readonly string ON = "ON";
        public static readonly string ON_FM = "ONFM";
        public static readonly string OFF = "OFF";
        public static readonly string OFF_FD = "OFFFD";



        public static readonly Uframe[] UserFrame = Uframe.Init();
        public static Uframe UFRAME_NUM = UserFrame[0];

        public static readonly Utool[] UserTool = Utool.Init();
        public static Utool UTOOL_NUM = UserTool[0]; // Pas en readonly car on utilise UTOOL_NUM = x


        
        ///     Liste des lettres qui ne peuvent pas appaitre dans un commentaire
        ///     ou être affiché a l'écran ...
        public static readonly char[] ACCENT = { 'é', 'è', 'ê', 'â', 'û', 'î' };


    }
}
