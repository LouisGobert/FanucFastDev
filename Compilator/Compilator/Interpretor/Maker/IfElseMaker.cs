using Compilator.Interpretor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator.Interpretor.Maker
{
    public class IfElseMaker
    {

        public static void IfMake(int iFL, ref string[] fileLine)
        {

            // Formattage du if () then
            string ifToString = @ConditionMaker.Make(ref iFL, fileLine);
            Interpreter.addLine("Generation.appendLine(\"  " +
                                $"IF \" + \"{ifToString} \"+ \"THEN ;\");");


            // Recherche du { 
            int openBracket = (fileLine[iFL].Contains('{')) ? iFL : Utils.ToOpenBracket(iFL, fileLine);


            // On vérifie qu'on l'a bien trouvé
            // Si on ne l'a pas trouvé on ne trouvera pas le '}' non plus
            // on générera alors une intéruptions --> plus facile.
            if (openBracket == -1)
                throw new FormatException(" '{' manquant dans le if");


            fileLine[openBracket] = fileLine[openBracket].Replace('{', ' ');
            PassIsBlankLine(openBracket, ref fileLine);
          
            
            // Recher de la fin du if
            int closeBracket = Utils.GetIndexEndBlock(iFL, fileLine);
            // Supression du '}'
            fileLine[closeBracket] = fileLine[closeBracket].Replace('}', ' ');
            PassIsBlankLine(closeBracket, ref fileLine);


            // On regarde si il y a un else par la suite
            int closeBracketTemp = closeBracket; // <- donc a la ligne du PASS

            // On se déplace jusqu'a trouvé la premiere instruction suivant le '}'
            string line = fileLine[++closeBracket];
            while (line.Trim().Length == 0)
                line = fileLine[++closeBracket];




            if (line.TrimStart().StartsWith("else"))
                ElseMake(closeBracket, ref fileLine);
            else
                fileLine[closeBracketTemp] = "Generation.appendLine(\"  ENDIF ;\");";
                

            // Car on c'est déplacé jusqu'a la ligne apres le {
            iFL--;

        }


        private static void ElseMake(int closeBracket, ref string[] fileLine)
        {

            int openBracket = (fileLine[closeBracket].Contains('{')) ? 
                                closeBracket : 
                                Utils.ToOpenBracket(closeBracket+1, fileLine);

            fileLine[closeBracket] = "Generation.appendLine(\"  ELSE  ;\");";

            if (openBracket == -1)
                throw new FormatException(" '{' manquant dans le else");

            fileLine[openBracket] = fileLine[openBracket].Replace('{', ' ');
            PassIsBlankLine(openBracket, ref fileLine);

           
            closeBracket = Utils.GetIndexEndBlock(closeBracket, fileLine);
            fileLine[closeBracket] = fileLine[closeBracket].Replace("}", "Generation.appendLine(\"  ENDIF ;\");");
        }



        /// <summary>
        ///     Fonction qui s'assure qu'on ajoute pas une ligne vide dans le programmes ls
        ///     dans le cas ou un if est de cette forme :
        ///         
        ///         if (x == true)
        ///         {
        ///             // Action
        ///         }
        ///         
        ///     Car on supprime le '{' et donc on crée une ligne vide.
        /// </summary>
        /// <param name="index"> L'index de la ligne </param>
        /// <param name="fileLine"> Le tableau contenant toutes les lignes à précompiler </param>
        private static void PassIsBlankLine(int index, ref string[] fileLine)
        {
            if (fileLine[index].Trim().Length == 0)
                fileLine[index] = "PASS";

        }
    }
}
