using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     Classe qui va analysé une expression d'un IF ou autre
///     et qui en déduire la correspondance.
///     
///     EX = RO[1] == OFF && DO[12]
///     deviendra : 
///        = RO[1]=OFF AND DO[12]=ON
///        
/// 
///     Liste des séparateur à prendre en compte : 
///         -   && --> AND (&)
///         -   || --> OR  (|)
///         -   +  --> +
///         -   *  --> *
///         -   /  --> /
///         -   == --> =
///         -   != --> <>
///         -   <  --> <
///         -   >  --> >
///         -   <= --> <=
///         -   >= --> >=
///         
/// </summary>
namespace Compilator.Interpreter
{

    public class ConditionMaker
    {
        private static char[] separator = { '&', '|', '(', ')', ' ', '=' };
        private static StringBuilder conditionBuilder;
        private static int bracketNumber;
        private static string line;
        private static int index;

        public static string make(ref int iFL, string[] fileLine)
        {
            // On obtient la condition pure --> "(x == 1)"
            line = fileLine[iFL];
            line = line.Substring(line.IndexOf("(") + 1);

            conditionBuilder = new StringBuilder();
            conditionBuilder.Append('(');
            bracketNumber = 1;


            char atIndex;

            while (bracketNumber != 0)
            {

                for (index = 0; index < line.Length; index++)
                {
                    atIndex = line[index];

                    if (separator.Contains(atIndex))
                    {
                        separatorAnalysis(atIndex);
                    }
                    else if (!char.IsWhiteSpace(atIndex))
                    {
                        wordAnalysis(atIndex);
                    }

                }

                if (bracketNumber != 0)
                {
                    if (iFL + 1 >= fileLine.Length)
                        throw new Exception("Fin de la condition non valie.");
                    else
                        line = fileLine[++iFL];

                }



            }





            return conditionBuilder.ToString();
        }

        private static void wordAnalysis(char atIndex)
        {
            string word = line.Substring(index);
            int jumpIndex = word.IndexOfAny(separator);
            // On récupré le mot en entier (jusqu'au prochain séparateur)
            if (jumpIndex != -1)
            {
                word = word.Substring(0, word.IndexOfAny(separator));
                index += jumpIndex-1;
            }
            else
            {
                throw new Exception("L'expression ne se termine pas par une parenthèse.");
            }


            // On a récupéré le mot, maintenant on replace la ce qui se trouve après son . par
            // sa fonction adéquate on fonction de ce qui se trouve apès ce point.

            // Si le mot ne contient pas de point.
            if (!word.Contains("."))
            {

                conditionBuilder.Append(word);

            } else
            {
                // Analyse de l'attribut
                attibutAnalysis(word.Substring(word.IndexOf('.') + 1), ref word);

                // MAJ du sb ajout des + "...." +
                conditionBuilder.Append(String.Format("\" + {0} + \"", word));
            }





        }

        /// <summary>
        ///     Fonction qui analyse le l'attribut et on fonction de ca met a jour le mot
        ///     avec sa nouvelle définition.
        ///     
        ///     EX : RO[1].State 
        ///     
        ///         Devient
        ///         
        ///         RO[1].format()
        ///     
        /// </summary>
        /// <param name="attribut"></param>
        /// <param name="word"></param>
        private static void attibutAnalysis(string attribut, ref string word)
        {
            switch (attribut)
            {
                case "State":
                    word = word.Replace(".State", ".format()");
                    //index += 3;
                    break;
            }
        }
        

        private static void separatorAnalysis(char atIndex)
        {
            switch (atIndex)
            {
                case  ' ':
                    break;
                case '(':
                    bracketNumber++;
                    conditionBuilder.Append('(');
                    break;
                case ')':
                    bracketNumber--;
                    conditionBuilder.Append(')');
                    break;
                case '&':
                    if (line[index+1] == '&')
                        index++;
                    conditionBuilder.Append("AND");
                    break;
                case '=':
                    if (line[index+1] == '=')
                        index++;
                    conditionBuilder.Append("=");
                    break;
                default:
                    throw new NotImplementedException("\"atIndex\" n'est pas encore implémenté");
                    

            }
        }
    }
}
