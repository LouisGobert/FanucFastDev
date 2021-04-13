using System;
using System.Collections.Generic;

namespace RobotLibrary.Global
{


    public class Utool
    {

        private int _toolNumber;
        private string _toolDescription;
        private static List<int> toolList = new List<int>();

        public Utool(int number, string description) {

            if (toolList.Contains(number)) {
                throw new AccessViolationException("Numéro de Utool déjà existant.");
            }

            toolList.Add(number);

            _toolNumber = number;
            _toolDescription = description;

            #if debug
            Console.WriteLine($"Nouveau tool : [{_toolNumber}] - \"{_toolDescription}\"");
            #endif
        }

        public static void set(Utool tool) {

            #if debug
            Console.WriteLine($"Changement de Utool : [{tool._toolNumber}] - \"{tool._toolDescription}\"");
            #endif


            Generation.appendLine(String.Format("  UTOOL_NUM={0} ;", tool._toolNumber));
        }

        
    }

}



