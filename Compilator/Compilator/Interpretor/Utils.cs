namespace Compilator.Interpretor {

    public class Utils {

        /// <summary>
        ///     Fonction qui permet de sauter toutes les lignes vides
        ///     et de les compters.
        /// </summary>
        /// <param name="iFL"> La référence du pointeur d'index de la ligne dans fileLine[] </param>
        /// <param name="fileLine"> Le tableau contenant toutes les lignes à précompiler </param>
        public static void PassBlankLine(ref int iFL, string[] fileLine)
        {
            int blankLineCount = 0;
            string s;
            do
            {
                blankLineCount++;
                s = fileLine[++iFL];


            } while (s.Trim().Length == 0 && iFL + 1 < fileLine.Length);

            Interpreter.addLine($"Generation.appendXBlankLine({blankLineCount});");

            iFL--;
        }


        /// <summary>
        ///     Fonction qui permet d'obtenir la liste des 
        ///     noms des programmes a créer.
        /// </summary>
        public static void GetAllProgramNames(ref int iFL, string[] fileLine)
        {
            string s;

            // Déplacement jusqu'a la ligne après le '{'
            while (!(s = fileLine[iFL++]).Contains("{")) ;

            Interpreter.addLine(s + "\n");

            // on obtient la liste de tout les programmes
            while (!(s = fileLine[iFL++]).Contains("}"))
            {
                if (s.Trim().Length != 0 && !s.Contains("#") && !s.Contains("/") && !s.Contains("."))
                {
                    Interpreter.ProgramList.Add(s.Trim());
                }

                Interpreter.addLine(s + "\n");

            }

            Interpreter.addLine(s);

        }


        /// <summary>
        ///     Fonction qui renvois l'index de la ligne qui contient
        ///     le '{' ouvrant.
        /// </summary>
        /// <param name="indexStart"> L'index de la ligne d'ou il faut commencer à chercher</param>
        /// <param name="fileLine"> Le tableau contenant toutes les lignes à précompiler </param>
        /// <returns> 
        ///     Retourne l'index de la ligne contenant le '{' 
        ///         ou
        ///     Retourne -1 si une instruction a été détecté avant le '{'
        /// </returns>
        public static int ToOpenBracket(int indexStart, string[] fileLine)
        {
            string s = fileLine[indexStart];
            while (indexStart + 1 < fileLine.Length && s.Trim().Length == 0 && !s.Contains("{"))
                s = fileLine[++indexStart];

            if (!s.Contains('{'))
                return -1;

            return indexStart;
        }


        /// <summary>
        ///     Fonction qui se place à la ligne ou se trouve le crochet
        ///     fermant '}' du block en cours.
        /// </summary>
        /// <param name="indexStart"> L'index de début de recherche </param>
        /// <returns> L'index de la ligne ou se trouve le crochet fermant </returns>
        /// <returns> L'index de la ligne ou se trouve le crochet fermant </returns>
        public static int GetIndexEndBlock(int indexStart, string[] fileLine)
        {
            // On assume que l'index de start est celui après le premier bracket
            int bracket = 1;
            int iTemp = indexStart;
            string s;

            while (bracket >= 1 && iTemp < fileLine.Length)
            {
                s = fileLine[iTemp];
                if (s.Contains("{"))
                    bracket++;
                else if (s.Contains("}"))
                    bracket--;

                iTemp++;
            }

            return iTemp - 1;
        }
    }
}