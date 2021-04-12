using Compilator.Interpretor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator.Interpretor
{
    public class IfElseMaker
    {

        public static void ifMaker(int iFL, ref string[] fileLine)
        {


            string res = @ConditionMaker.make(ref iFL, fileLine);
            Interpreter.addLine(String.Format("Generation.appendLine(\"  IF \" + \"{0} \"+ \"THEN ;\");", res));

            // Recherche du { et on le remplace par du vide
            int openBracket = Interpreter.toOpenBracket(iFL);
            fileLine[openBracket] = fileLine[openBracket].Replace('{', ' ');
            putIfEmpty(openBracket, ref fileLine);

            // Recher de la fin du if
            int endIfIndex = Interpreter.getIndexEndBlock(iFL);
            // Supression du '}'
            fileLine[endIfIndex] = fileLine[endIfIndex].Replace('}', ' ');
            putIfEmpty(endIfIndex, ref fileLine);


            // On regarde si il y a un else par la suite
            int endIfIndexTemp = endIfIndex;

            string s = fileLine[endIfIndexTemp];

            while (s.Trim().Length == 0)
                s = fileLine[++endIfIndexTemp];
           

            if (s.TrimStart().StartsWith("else"))
            {
                elseMaker(endIfIndex, endIfIndexTemp, ref fileLine);
            }
            else
            {
                fileLine[endIfIndex] = "Generation.appendLine(\"  ENDIF ;\");";
                
            }


            // Car on c'est déplacé jusqu'a la ligne apres le {
            iFL--;



        }


        private static void elseMaker(int endIfIndex, int endIfIndexTemp, ref string[] fileLine)
        {
            fileLine[endIfIndexTemp] = "Generation.appendLine(\"  ELSE  ;\");";
            int openBracket = Interpreter.toOpenBracket(endIfIndexTemp);
            fileLine[openBracket] = fileLine[openBracket].Replace('{', ' ');
            putIfEmpty(openBracket, ref fileLine);

            endIfIndex = Interpreter.getIndexEndBlock(endIfIndexTemp);
            fileLine[endIfIndex] = fileLine[endIfIndex].Replace("}", "Generation.appendLine(\"  ENDIF ;\");");
        }


        private static void putIfEmpty(int index, ref string[] fileLine)
        {
            if (fileLine[index].Trim().Length == 0)
                fileLine[index] = "_EMPTY=true;";

        }
    }
}
