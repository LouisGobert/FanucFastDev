using System;
using RobotLibrary.Global;


namespace RobotLibrary
{
    public class move
    {
        private static void GlobalMove(char pointType, string targetFormated, ushort fast, ushort smooth) {
            Generation.appendLine($"{pointType} {targetFormated} {fast}{((pointType == 'L') ? "mm/sec" : "%")} {smoothFormat(smooth)}    ;");
        }


        public static void linear(Pos target, ushort fast, ushort smooth)
        {
            GlobalMove('L', target.formatForBracket(), fast, smooth);
        }


        public static void joint(Pos target, ushort fast, ushort smooth)
        {
            GlobalMove('J', target.formatForBracket(), fast, smooth);
        }

        public static void linear(PosReg target, ushort fast, ushort smooth)
        {
            GlobalMove('L', target.formatForBracket(), fast, smooth);
        }


        public static void joint(PosReg target, ushort fast, ushort smooth)
        {
            GlobalMove('J', target.formatForBracket(), fast, smooth);
        }


        public static void circular(Pos middle, Pos target, ushort fast, ushort smooth)
        {

            Generation.appendLine($"C {middle.formatForBracket()}    \n     :  {target.formatForBracket()} {fast}mm/sec {smoothFormat(smooth)}    ;");

        }


        private static string smoothFormat(ushort smooth)
        {
            if (smooth == 0)
                return "FINE";
            else
                return "CNT" + smooth.ToString();
        }


    }
}

