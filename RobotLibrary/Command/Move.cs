using RobotLibrary.Global;


namespace RobotLibrary.Command
{
    public static class Move
    {
        private static void GlobalMove(char moveType, Pos target, ushort fast, ushort smooth) {

            string formatedOffset = string.Empty;
            if (target.PROffset != null) {
                formatedOffset = " Offset," + target.PROffset.ToString();
                target.PROffset = null;
            }

            Generation.appendLine(
                $"{moveType} {target.formatForBracket()} {fast}" +
                $"{((moveType == 'L') ? "mm/sec" : "%")} {smoothFormat(smooth)}{formatedOffset}    ;");
        }

        private static void GlobalMove(char moveType, PosReg target, ushort fast, ushort smooth) {

            string formatedOffset = string.Empty;
            if (target.PROffset != null) {
                formatedOffset = " Offset," + target.PROffset.ToString();
            }

            Generation.appendLine(
                $"{moveType} {target.ToString()} {fast}" +
                $"{((moveType == 'L') ? "mm/sec" : "%")} {smoothFormat(smooth)}{formatedOffset}    ;");
        }


        public static void Linear(Pos target, ushort fast, ushort smooth)
        {
            GlobalMove('L', target, fast, smooth);
        }


        public static void Joint(Pos target, ushort fast, ushort smooth)
        {
            GlobalMove('J', target, fast, smooth);
        }

        public static void Linear(PosReg target, ushort fast, ushort smooth)
        {
            GlobalMove('L', target, fast, smooth);
        }


        public static void Joint(PosReg target, ushort fast, ushort smooth)
        {
            GlobalMove('J', target, fast, smooth);
        }


        public static void Circular(Pos middle, Pos target, ushort fast, ushort smooth)
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

