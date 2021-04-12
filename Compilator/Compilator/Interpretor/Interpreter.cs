/// TO IMPLEMENT :  - Program.keepBlanckLine
///                 - géré l'affichage en console

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compilator.Interpretor;
using Compilator.Files;
using RobotLibrary;
using Microsoft.CSharp;
using Compilator.Files;


namespace Compilator.Interpretor
{
    public class Interpreter
    {
         //private static string savePath; --> remplacer par BUILD_PATH
        private static string[] usedFunctionName = { "Main", "print", "wait" };
        private static int iFL; // L'index dans le fileLine
        private static string[] fileLine;
        private static StringBuilder sb;
        private static List<string> programList = new List<string>();
        private static List<string> _labelList = new List<string>();
        private const string _EMPTY = "_EMPTY=true;";


        public static string interprete()
        {
            // Ouverture de FanucFastDev.cs
            fileLine = FileGestion.getFileLine();

            // C'est lui qui va contenir tout les lignes a compiler
            sb = new StringBuilder();
            string s;
           



            // Formattage du fichier de base .cs
            // COMIT
            for (iFL = 0; iFL < fileLine.Length; iFL++)
            {
                s = fileLine[iFL];

                // Mise a jour de Main et obtention de la liste des programmes
                if (s.Contains("MainSolution()"))
                {
                    //s = s.Replace("MainSolution()", "Main()");

                    addLine(s);
                    //Console.WriteLine(s);
                    //sb.Append(s + "\n");

                    getAllProgramNames();

                    continue;
                    

                }


                // Ajout de generator.Init
                if (s.Contains("static") && s.Contains("void"))
                {
                    // On vérifie que ce n'est pas le main ni le print
                    int index = s.IndexOf("void") + "void".Length;
                    string programName = s.Substring(index);
                    programName = programName.Substring(0, programName.IndexOf('('));
                    programName = programName.Trim();

                    // Un nouveau programme est détecté.
                    if (!usedFunctionName.Contains(programName))
                    {
                        lsProgramInterprete(programName);
                        continue;
                    }


                    
                }




                addLine(s);            

                //Console.WriteLine(s);
                //sb.Append(s + "\n");
               
            }

            return sb.ToString();
        }


        /// <summary>
        ///     Fonction qui gère de bout en bout la précompilation d'un 
        ///     "sous-programme" du programme en entier.
        /// </summary>
        /// <param name="programName"> Le nom du programme a interpréter </param>
        private static void lsProgramInterprete(string programName)
        {
            int blankLineCount;
            string s = fileLine[iFL];

            while (!s.Contains('{'))
            {
                addLine(s);
                //sb.Append(s + "\n");
                //Console.WriteLine(s);
                s = fileLine[++iFL];
            }
            ++iFL;


            /// A amélioré -->
            ///     Passé le BUILD_PATH une seule fois au lieux de le repasser a chaque programmes .ls
            addLine(s);
            addLine($"Generation.setup(\"{programName}\", @\"{Files.Const.BUILD_PATH}\");\n");


            // On obtient tout le code programme
            int indexProgramEnd = getIndexEndBlock(iFL + 1);
            //int indexToPushProgramCreateProgrammeInfo = getLastProgramInfo(fileLine, iFL);

            for (; iFL < indexProgramEnd; iFL++)
            {
                s = fileLine[iFL].TrimStart();

                if (s.StartsWith("Generation"))
                {
                    addLine(s);
                    continue;
                }



                // Remplacement de "//!" par Comment("...");
                if (s.Contains("//!"))
                    s = "\t" + Comment.getFormatedComment(s);


                // Si la ligne est vide
                if (s.Trim().Length == 0)
                {
                    blankLineCount = 0;
                    do
                    {
                        blankLineCount++;
                        s = fileLine[++iFL];

                        
                    } while (s.Trim().Length == 0 && iFL + 1 < fileLine.Length);

                    addLine(String.Format("Generation.appendXBlankLine({0});", blankLineCount));


                    iFL--;
                    continue;

                }


                // Si c'est l'appel d'un autre programme
                if (programList.Contains(s.Trim())) {
                    


                    programName = s.Substring(0, s.IndexOf('(')).TrimStart();
                    addLine(String.Format("Generation.appendLine(\"  CALL {0}    ;\");", programName));

                    //Console.WriteLine($"\tGeneration.appendLine(\"  CALL {programName}    ;\");");
                    //sb.Append(String.Format("Generation.appendLine(\"  CALL {0}    ;\");", programName));
                    continue;
                }




                // Si c'est un if {
                if (s.StartsWith("if"))
                {
                    IfElseMaker.ifMaker(iFL, ref fileLine);
                    continue;
                }

                // Goto
                if (s.StartsWith("goto"))
                {
                    gotoMaker(s);
                    continue;
                } else if (s.Contains(':'))
                {
                    // C'est un label
                    labelMaker(s);
                    continue;

                } else if (s.Contains(_EMPTY))
                {
                    continue;
                }


                addLine(s);

                //Console.WriteLine(s);
                //sb.Append(s + "\n");


            }

            
            addLine("Generation.finish();\n}\n");

            //Console.WriteLine("\tGeneration.finish();\n\t}");
            //sb.Append("Generation.finish();\n}\n");


        }

        private static void labelMaker(string s)
        {
            s = s.Substring(0, s.IndexOf(':')).Trim();

            addLine(String.Format("Generation.appendLine(\"  LBL[{0}:{1}] ;\");", _labelList.IndexOf(s) + 1, s));
        }

        private static void gotoMaker(string s)
        {
            s = s.Substring(s.IndexOf(' '));
            s = s.Substring(0, s.IndexOf(';')).Trim();

            _labelList.Add(s);

            addLine(String.Format("Generation.appendLine(\"  JMP LBL[{0}] ;\");", _labelList.IndexOf(s) + 1));
        }




        


        /// <summary>
        ///     Fonction qui renvois l'index de la ligne qui contient
        ///     le '{' ouvrant.
        /// </summary>
        public static int toOpenBracket(int indexStart)
        {
            string s = fileLine[indexStart];
            while (!s.Contains("{")) {
                s = fileLine[++indexStart];
            }

            return indexStart;
        }


        /// <summary>
        ///     Fonction qui se place à la ligne ou se trouve le crochet
        ///     fermant '}' du block en cours.
        /// </summary>
        /// <param name="indexStart"> L'index de début de recherche </param>
        /// <returns> L'index de la ligne ou se trouve le crochet fermant </returns>
        /// <returns> L'index de la ligne ou se trouve le crochet fermant </returns>
        public static int getIndexEndBlock(int indexStart)
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

        


        /// <summary>
        ///     Fonction qui permet d'obtenir la liste des 
        ///     noms des programmes a créer.
        /// </summary>
        private static void getAllProgramNames()
        {
            string s;

            // Déplacement jusqu'a la ligne après le '{'
            while (!(s = fileLine[iFL++]).Contains("{")) ;

            Console.WriteLine(s + "\n");
            sb.Append(s + "\n\n");


            // on obtient la liste de tout les programmes
            while (!(s = fileLine[iFL++]).Contains("}"))
            {
                if (s.Trim().Length != 0 && !s.Contains("#") && !s.Contains("/") && !s.Contains("."))
                {
                    programList.Add(s.Trim());
                }

                Console.WriteLine($"\t{s}\n");
                sb.Append(s + "\n");
            }

            addLine(s);
           // Console.WriteLine($"\t{s}\n");
           // sb.Append(s + "\n");



        }

        public static void addLine(string line)
        {

#if debug
            Console.WriteLine("\t" + line);
#endif

            sb.AppendLine(line);

        }
        

        
    }
}
