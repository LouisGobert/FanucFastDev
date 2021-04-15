using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;
using static RobotLibrary.Other;
using RobotLibrary.Command;
using RobotLibrary.Local;

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
        ProgramInfo.KeepBlankLine = true;

        Run("test");
        //! bonjout
        if (RO[12] == OFF) {
            Print("pas bonjour");
        } 
        else 
        {
            Print("oui");
        }

        if (Reg[12] > 123) {
            Print("yes");
        }

        Pos pTest = new Pos(1, "Point de test");
        Pos pInter = new Pos(2);
        PosReg pAPproche = PosReg[12];

        Reg valeurMax = Reg[69];
        valeurMax.Desc = "Valeur maximu";

        Reg valMin = Reg[1];
        valMin.Desc = "valeur min";


        valeurMax.Set(valMin);

        valeurMax.Value = valMin.Value;

        Reg i = Reg[53];
        for (i.Value = 0; i.Value < valeurMax.Value; i.Value--) {
            Print("test");
        }

        goto test;
        test:


        Move.Linear(pInter.Offset(PosReg[8]), 100, 100);

        Move.Linear(pTest, 50, 0);
        

        Move.Circular(pInter, pTest, 23, 0);

    }

}






