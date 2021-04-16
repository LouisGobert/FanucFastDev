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
namespace Compilator.Interpretor.Maker
{

    public static class ConditionMaker
    {
        private static char[] _separator = { '&', '|', '(', ')', ' ', '=', '>', '<' };
        private static StringBuilder conditionBuilder;
        private static int _bracketNumber;
        private static char _atIndex;
        private static string _line;
        private static int _lineIndex;

        public static string Make(ref int iFL, string[] fileLine)
        {
            // On obtient la condition pure --> "(x == 1)"
            _line = fileLine[iFL];
            _line = _line.Substring(_line.IndexOf("(") + 1);

            conditionBuilder = new StringBuilder();
            conditionBuilder.Append('(');
            _bracketNumber = 1;


            _lineIndex = 0;
            while (_bracketNumber != 0 && _lineIndex < _line.Length) 
            {

                _atIndex = _line[_lineIndex];

                if (_separator.Contains(_atIndex))
                    separatorAnalysis();
                else if (!char.IsWhiteSpace(_atIndex))
                    wordAnalysis();


                // If we are at the end of the line and the _bracketNumber != 0
                if (++_lineIndex >= _line.Length && _bracketNumber != 0) {
                    if (iFL + 1 >= fileLine.Length)
                        throw new Exception("Fin de la condition non valide.");
                    else {
                        _lineIndex = 0;
                        _line = fileLine[++iFL].Trim();

                        fileLine[iFL] = (_line.Contains('{')) ? "{" : "PASS";
                    }
                }
                
            }



            return conditionBuilder.ToString();
        }

        private static void wordAnalysis()
        {
            string word = _line.Substring(_lineIndex);
            int jumpIndex = word.IndexOfAny(_separator);

            // On récupré le mot en entier (jusqu'au prochain séparateur)
            if (jumpIndex != -1)
            {
                word = word.Substring(0, word.IndexOfAny(_separator));
                _lineIndex += jumpIndex-1;
            }
            else
                throw new Exception("L'expression ne se termine pas par une parenthèse.");


            // On a récupéré le mot, maintenant on replace la ce qui se trouve après son . par
            // sa fonction adéquate on fonction de ce qui se trouve apès ce point.

            // Si le mot ne contient pas de point.
            word = word.Trim();
            if (word == "ON" || word == "OFF")
                conditionBuilder.Append(word);
            else if (!word.Contains("."))
            {

                // Si il ne contient que des chiffres on l'ajoute directement
                // sinon on lui rajoute un .toString
                if (AllStringIsNumber(word))
                conditionBuilder.Append(word);
                else
                    conditionBuilder.Append($"\" + {word}{".ToString()"} + \"");

            } else
            {
                // Analyse de l'attribut
                attibutAnalysis(word.Substring(word.IndexOf('.') + 1), ref word);

                // MAJ du sb ajout des + "...." +
                conditionBuilder.Append($"\" + {word} + \"");
            }


        }

        /// <summary>
        ///     Fonction qui vérifie que tout les char d'un string soient bien des nombres.
        /// </summary>
        /// <param name="str"> Le string à vérifier</param>
        /// <returns> 
        ///     True si toutes les lettres sont des chiffres.
        ///     False sinon.
        /// </returns>
        private static bool AllStringIsNumber(string str) {

            foreach (char ch in str)
                if (!char.IsNumber(ch))
                    return false;

            return true;
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
                    word = word.Replace(".State", ".ToString()");
                    break;
            }
        }
        

        private static void separatorAnalysis()
        {
            switch (_atIndex)
            {
                case  ' ':
                    break;
                case '(':
                    _bracketNumber++;
                    conditionBuilder.Append('(');
                    break;
                case ')':
                    _bracketNumber--;
                    conditionBuilder.Append(')');
                    break;
                case '&':
                    if (_line[_lineIndex+1] == '&')
                        _lineIndex++;
                    conditionBuilder.Append(" AND ");
                    break;
                case '|':
                    if (_line[_lineIndex+1] == '|')
                        _lineIndex++;
                    conditionBuilder.Append(" OR ");
                    break;
                case '=':
                    if (_line[_lineIndex+1] == '=')
                        _lineIndex++;
                    conditionBuilder.Append("=");
                    break;
                case '>':
                    conditionBuilder.Append('>');
                    if (_line[_lineIndex+1] == '=') {
                        conditionBuilder.Append('=');
                        _lineIndex++;
                    }
                    break;
                case '<':
                    conditionBuilder.Append('<');
                    if (_line[_lineIndex+1] == '=') {
                        conditionBuilder.Append('=');
                        _lineIndex++;
                    }
                    break;
                default:
                    throw new NotImplementedException($" \" { _atIndex} \" n'est pas encore implémenté");
                    

            }
        }
    }
}
