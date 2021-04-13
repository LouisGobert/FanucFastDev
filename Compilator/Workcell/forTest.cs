using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;

class forTest {

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



    public static void Main_forTest()
    {
        // Lister les programmes a créer : 

        // EX : 
        T_EXEMPLE();
    }



    static void T_EXEMPLE()
    {

        ProgramInfo.keepBlankLine = true;
        Pos pTest = new Pos(1, "Point de test");
        Pos pInter = new Pos(2);
        PosReg pAPproche = PosReg[12];

        Reg valeurMax = Reg[69];
        valeurMax.Desc = "Valeur maximu";

        Reg valMin = Reg[1];
        valMin.Desc = "valeur min";


        valeurMax.Set(valMin);

        Reg i = Reg[53];
        for (i.Value = 0; i.Value < valeurMax.Value; i.Value++) {
            print("test");
        }



        move.linear(pAPproche, 100, 100);

        move.joint(pTest, 100, 100);
        move.linear(pTest, 50, 0);
        

        move.circular(pInter, pTest, 23, 0);

    }

    public static bool For(Reg tes) {
        return true;
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






