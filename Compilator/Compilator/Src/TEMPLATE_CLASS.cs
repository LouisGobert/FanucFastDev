using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;

class TEMPLATE_CLASS {

#region 
    // Constante - Ne pas modifier
    public const ushort P = 1;
    public const ushort J = 0;
    public const int FINE = 0;
    public const int TP_PROGRAM = -1; // A définir le nom exacte
    public const int MACRO = 1;
    public static RO[] RO = RobotLibrary.Global.InOut.RO.Init();
    public static Flag[]   Flag = RobotLibrary.Global.InOut.Flag.Init();
    public static PosReg[] PosReg = RobotLibrary.Global.PosReg.Init();
    public static Reg[] Reg = RobotLibrary.Global.Reg.Init();
    private const string ON = "ON";
    private const string ON_FM = "ONFM";
    private const string OFF = "OFF";
    private const string OFF_FD = "OFFFD";
    private static bool PASS;


    #endregion


    ///////////////////////////////////////////////////////////////
    //     Déclaration des frames et des tools, PR, ...          //
    ///////////////////////////////////////////////////////////////



    public static void TEMPLATE_MAIN()
    {
        // Lister les programmes a créer : 

        // EX : 
        T_EXEMPLE();
    }



    static void T_EXEMPLE()
    {


    }

    

    #region

    static void print(string toPrint)
    {
        #if debug
        Console.WriteLine(toPrint);
        #endif

        StringUtils.TextVerify(ref toPrint, Const.PRINT_MAX_CHAR);

        Generation.appendLine(string.Format("  MESSAGE[{0}]  ;", toPrint));
    }

    static void wait(double sec)
    {
        if (sec <= 0)
            throw new FormatException("Le temps doit être supérieure à 0.");



        NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).NumberFormat;

        nfi.NumberDecimalSeparator = ".";


        Generation.appendLine(String.Format("  WAIT{0, 7}(sec) ;", sec.ToString(".00", nfi)));
    }

    static void wait(bool condition)
    {

    }

    static void run(string s) {
        Generation.appendLine($"  RUN {s} ;");
    }




#endregion

}






