// TO IMPLEMENT : meilleur gestion de l'exeption


using System;
using System.Collections.Generic;

namespace RobotLibrary
{


    public class Utool
    {

        private int toolNumber;
        private string toolDescription;
        private static List<int> toolList = new List<int>();

        public Utool(int number, string description) {

            if (toolList.Contains(number)) {
                throw new AccessViolationException("Numéro de Utool déjà existant.");
            }

            toolList.Add(number);

            toolNumber = number;
            toolDescription = description;

            #if debug
            Console.WriteLine($"Nouveau tool : [{toolNumber}] - \"{toolDescription}\"");
            #endif
        }

        public static void set(Utool tool) {

            #if debug
            Console.WriteLine($"Changement de Utool : [{tool.toolNumber}] - \"{tool.toolDescription}\"");
            #endif


            Generation.appendLine(String.Format("  UTOOL_NUM={0} ;", tool.toolNumber));
        }

        
    }

}



