using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.InOut;
using RobotLibrary.Utils;

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
    private const string ON = "ON";
    private const string ON_FM = "ON+";
    private const string OFF = "OFF";
    private const string OFF_FD = "OFF-";
    private static bool _EMPTY;




    //////////////////////////////////////////////////////
    //     Déclaration des frames et des tools          //
    //////////////////////////////////////////////////////

    public static void MainSolution()
    {
#endregion

        // Liste des programmes a créer : 
        T_PREMIER_TRAJ();
        T_OUV_PINCE();
        T_FERM_PINCE();

#region
#if DEBUG
        //Console.ReadLine();
#endif

    }

#endregion


    // Déclaration des UserFrame des des UTools.
    public static Uframe frameOrange = new Uframe(4, "Frame Orange par Louis");
    public static Utool toolPince = new Utool(1, "Pince sur flasque");





    static void T_PREMIER_TRAJ()
    {
        Program.desc = "Trajectoire facile";
        Program.groupMask = "1,*,*,*,*";
        Program.type = TP_PROGRAM;

        //! par Louis Gobert
        //! Set de UTOOL et UFRAME
        Uframe.set(frameOrange);
        Utool.set(toolPince);
        T_OUV_PINCE();

        pos pApproche = new pos(1);
        mov.joint(pApproche, 100, 50);
        pos jRepli = new pos(2);
        
        pos pPrise = new pos(3);

        mov.joint(jRepli, 12, 100);
        mov.linear(pPrise, 123, FINE);
        print("Prise de la pièce");
        T_FERM_PINCE();

        mov.linear(pApproche, 12, FINE);
        mov.joint(jRepli, 12, FINE);

        print("Fin du programme.");

        RO pince = RO[11];

        if (pince.State == ON)
        {
            goto lablTest;
        } else
        {
            goto autreLabel;
        }

        if (RO[1].State == OFF)
        {
            print("Fermer");
        }
        if (RO[12].State == ON)
        {
            print("12 fermer");
        }




    autreLabel:
    lablTest:
        print("Arrive au label");


    }

    static void T_FERM_PINCE()
    {
        Program.groupMask = "*,*,*,*,*";
        //!B2 - Lecat Gobert
        RO[7].off();
        RO[8].on();
        wait(1);
    }

    static void T_OUV_PINCE()
    {
        Program.groupMask = "*,*,*,*,*";
        //!B2 - Lecat Gobert
        RO[7].on();
        RO[8].off();
        wait(1);
    }

    #region

    static void print(string toPrint)
    {

        Console.WriteLine(toPrint);

        Utils.textVerify(ref toPrint, Const.COMMENT_MAX_CHAR);

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




#endregion

}






