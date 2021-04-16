using System;
using System.Globalization;
using RobotLibrary.Utils;
using RobotLibrary.Global;

namespace RobotLibrary.Command
{

    public static class Other
    {
        /// <summary>
        ///     Permet d'afficher un écran sur le Teach Pendant.
        /// </summary>
        /// <param name="toPrint"> Le message à afficher </param>
        public static void Print(string toPrint)
        {
            #if debug
            Console.WriteLine(toPrint);
            #endif

            StringUtils.TextVerify(ref toPrint, Const.PRINT_MAX_CHAR);

            Generation.appendLine(string.Format("  MESSAGE[{0}]  ;", toPrint));
        }

        /// <summary>
        ///     Permet d'attendre un certain nombre de seconde.
        /// </summary>
        /// <param name="sec"> Le nombre de seconde à attendre</param>
        public static void Wait(double sec)
        {
            if (sec <= 0)
                throw new FormatException("Le temps doit être supérieure à 0.");



            NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name).NumberFormat;

            nfi.NumberDecimalSeparator = ".";


            Generation.appendLine(String.Format("  WAIT{0, 7}(sec) ;", sec.ToString(".00", nfi)));
        }

        public static void Wait(bool condition)
        {

        }

        public static void Run(string s)
        {
            Generation.appendLine($"  RUN {s} ;");
        }


    }
}