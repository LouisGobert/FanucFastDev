using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary.Global
{
    public class Uframe
    {

        private int frameNumber;

        public static int actualFrame;
        private string frameDescription;
        private static List<int> frameList = new List<int>();

        public Uframe(int number, string description)
        {

            if (frameList.Contains(number))
                throw new AccessViolationException("Numéro de Uframe déjà existant.");

            frameList.Add(number);

            frameNumber = number;
            frameDescription = description;

            #if debug
            Console.WriteLine($"Nouveau frame : [{frameNumber}] - \"{frameDescription}\"");
            #endif
        }

        public static void set(Uframe frame)
        {
            actualFrame = frame.frameNumber;

            #if debug
            Console.WriteLine($"Changement de Uframe : [{frame.frameNumber}] - \"{frame.frameDescription}\"");
            #endif

            Generation.appendLine(String.Format("  UFRAME_NUM={0} ;", actualFrame));

        }

    }
}




