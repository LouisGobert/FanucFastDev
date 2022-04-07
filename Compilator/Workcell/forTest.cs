using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;
using static RobotLibrary.Other;
using static RobotLibrary.Global.Const;
using RobotLibrary.Command;
using RobotLibrary.Local;


class forTest {

    ///////////////////////////////////////////////////////////////
    //     Déclaration des frames et des tools, PR, ...          //
    ///////////////////////////////////////////////////////////////

    public static void Main_forTest()
    {
        // Lister les programmes a créer : 

        // EX : 
        T_EXEMPLE_GITHUB();
    }


    static void T_EXEMPLE_GITHUB()
    {
        ProgramInfo.KeepBlankLine = true;

        Run("test");

        RO[1].Off();
        //! bonjout
        if (RO[12] == OFF) {
            Print("pas bonjour");
        } 
        else 
        {
            Print("oui");
        }
        if (R[12] > 123) {
            Print("yes");
        }
        Pos pTest = new Pos(1, "Point de test");
        Pos pInter = new Pos(2);
        PosReg pAPproche = PR[12];

        Reg valeurMax = R[69];
        valeurMax.Desc = "Valeur maximu";

        Reg valMin = R[1];
        valMin.Desc = "valeur min";


        valeurMax.Set(valMin);

        valeurMax.Value = valMin.Value;

        Reg i = R[53];
        for (i.Value = 0; i.Value < valeurMax.Value; i.Value--)
         {
            Print("test");
        }
        goto test;
        test:
        Move.Linear(pInter.Offset(PR[8]), 100, 100);
        Move.Linear(pTest, 50, 0);
        Move.Circular(pInter, pTest, 23, 0);
    }

}






