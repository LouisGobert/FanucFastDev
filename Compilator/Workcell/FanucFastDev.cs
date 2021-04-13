using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;

/*
class FanucFastDev {

#region 
    // Constante - Ne pas modifier
    public static string solution_name = "Detection";
    public const ushort P = 1;
    public const ushort J = 0;
    public const int FINE = 0;
    public const bool MM_S = true;
    public const bool POURC_100 = false;
    public const int TP_PROGRAM = -1; // A définir le nom exacte
    public const int MACRO = 1;
    public static RO[] RO = RobotLibrary.InOut.RO.Init();
    public static Flag[]   F = RobotLibrary.InOut.Flag.Init();
    public static PosReg[] PR = RobotLibrary.Reg.PosReg.Init();
    private const string ON = "ON";
    private const string ON_FM = "ONFM";
    private const string OFF = "OFF";
    private const string OFF_FD = "OFFFD";
    private static bool PASS;


#endregion


    //////////////////////////////////////////////////////
    //     Déclaration des frames et des tools          //
    //////////////////////////////////////////////////////

    public static void MainSolution()
    {

        // Lister les programmes a créer : 
        T_PREMIER_TRAJ();
        T_OUV_PINCE();
        T_FERM_PINCE();

    }




    // Déclaration des UserFrame des des UTools.
    public static Uframe frameOrange = new Uframe(4, "Frame Orange par Louis");
    public static Utool toolPince = new Utool(1, "Pince sur flasque");



    static void T_PREMIER_TRAJ()
    {
        ProgramInfo.desc = "Trajectoire facile";
        ProgramInfo.groupMask = "1,*,*,*,*";
        ProgramInfo.type = TP_PROGRAM;
        ProgramInfo.keepBlankLine = true;

        run("T_REPLI");

        Flag flagDemandeQualite = F[1];
        Flag flagTest = F[2];
        flagDemandeQualite.Off();

        if (flagDemandeQualite.State == ON && flagTest.State == OFF || flagTest.State == ON) {
            //! test
            goto autreLabel;
        }
            


        //! par Louis Gobert
        //! Set de UTOOL et UFRAME
        Uframe.set(frameOrange);
        Utool.set(toolPince);
        T_OUV_PINCE();

        Pos pApproche = new Pos(1);
        move.joint(pApproche, 100, 50);
        Pos jRepli = new Pos(2);
        
        Pos pPrise = new Pos(3);

        PosReg pCalculer = PR[12];
        pCalculer.Desc = "Point calcule";
        PosReg pTemp = PR[11];
        pCalculer.set(pTemp);

        move.joint(jRepli, 12, 100);
        move.linear(pPrise, 123, FINE);
        print("Prise de la piece");
        T_FERM_PINCE();

        move.linear(pApproche, 12, FINE);
        move.joint(jRepli, 12, FINE);

        print("Fin du programme.");

        RO pince = RO[11];

        if (pince.State == ON)
        {
            goto lablTest;
        } else
        {
            goto autreLabel;
        }
    autreLabel:

        if (RO[1].State == OFF)
        {
            print("Fermer");
        }
        if (RO[12].State == ON)
        {
            print("12 fermer");
        }




    lablTest:
        print("Arrive au label");


    }

    static void T_FERM_PINCE()
    {
        ProgramInfo.groupMask = "*,*,*,*,*";
        //!B2 - Lecat Gobert
        RO[7].Off();
        RO[8].On();
        wait(1);
    }

    static void T_OUV_PINCE()
    {
        ProgramInfo.groupMask = "*,*,*,*,*";
        //!B2 - Lecat Gobert
        RO[7].On();
        RO[8].Off();
        wait(1);
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


*/



