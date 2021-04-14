using System;
using System.Globalization;
using RobotLibrary;
using RobotLibrary.Global;
using RobotLibrary.Global.InOut;
using RobotLibrary.Utils;
using static RobotLibrary.Other;
using static RobotLibrary.Const;

class same {


    ///////////////////////////////////////////////////////////////
    //     Déclaration des frames et des tools, PR, ...          //
    ///////////////////////////////////////////////////////////////


    public static void Main_same()
    {
        // Lister les programmes a créer : 

        // EX : 
        T2_DEP_2();
        M2_OUVERTURE_PINCE();
    }


    static Uframe planCarton = UserFrame[1];
    
    static void T2_DEP_2()
    {
        ProgramInfo.groupMask = "1,*,*,*,*";
        //! Dépot pièce

        UFRAME_NUM = planCarton;
        UTOOL_NUM = 3;


        Move.Joint(PR[41], 100, 50);

        //! calcul du déplacement
        R[51].Set(R[53]);
        PR[50].Desc = "Hauteur approche";

        PR[21].Desc = "depot-calc";
        Move.Joint(PR[21], 100, 2);
        Move.Linear(PR[21].Offset(PR[50]), 100, FINE);
        M2_OUVERTURE_PINCE();
        Move.Linear(PR[21], 100, FINE);
        

    }

    static void M2_OUVERTURE_PINCE() {

    }
}






