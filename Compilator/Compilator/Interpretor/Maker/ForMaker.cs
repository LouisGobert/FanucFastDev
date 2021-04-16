
using System.Linq;
using System.Text;

namespace Compilator.Interpretor.Maker {

    public class ForMaker {

        private static char[] FOR_SEPARATOR = { '<', '>', '=', ' ' };

        public static void Make(int iFL, string[] fileLine) {

            // Décorticage de la ligne du for pour obtenir (..;..;..)
            string sentence = fileLine[iFL];
            sentence = sentence.Substring(sentence.IndexOf('(')+1);
            sentence = sentence.Substring(0, sentence.IndexOf(')'));


            string[] sentenceSplit = sentence.Split(';');
            StringBuilder forBuilder = new StringBuilder();

            SetFrom(forBuilder, sentenceSplit[0]);

            forBuilder.Append((sentenceSplit[2].Contains("+")) ? " TO " : " DOWN TO ");

            SetTo(forBuilder, sentenceSplit[1].TrimEnd());


            // Le formattage du for est fini.
            Interpreter.addLine($"Generation.appendLine(\"{forBuilder}\");");

            // Maintenant on s'ocupe des { }
            int bracketIndex = Utils.ToOpenBracket(iFL, fileLine);

            // On vérifie que la ligne n'est pas vide
            fileLine[bracketIndex] = (fileLine[bracketIndex].Trim().Length == 1) ? "PASS" :
                                    fileLine[bracketIndex].Replace('{', ' ');



            bracketIndex = Utils.GetIndexEndBlock(bracketIndex, fileLine);
            fileLine[bracketIndex] = "Generation.appendLine(\"  ENDFOR ;\");";

        }

        private static void SetFrom(StringBuilder forBuilder, string firstSentence) {

            string thisIs = firstSentence.Substring(0, firstSentence.IndexOf('='));
            string egalTo = firstSentence.Substring(firstSentence.IndexOf('=') + 1);

            thisIs = thisIs.Replace("Value", "ToString()");
            forBuilder.Append($"  FOR \" + {thisIs} + \"=" + egalTo.Trim());
        }


        private static void SetTo(StringBuilder forBuilder, string midSentence) {

            // On se déplace de la droite vers la gauche jusqu'a trouvé un séparateur
            for (int i = midSentence.Length - 1; i > 0; i--) {
                if (FOR_SEPARATOR.Contains(midSentence[i])) {
                    midSentence = midSentence.Substring(i);
                    i = -1;
                }
            }

            // Si il contient un .Value, ce n'est pas une constante donc on
            // ajoute le ToString.
            if (midSentence.Contains("Value"))
                midSentence = midSentence.Replace("Value", "ToString()");


            // Ajout au for builder
            forBuilder.Append($"\" + {midSentence.Trim()} +\" ;");

        }
    }
}