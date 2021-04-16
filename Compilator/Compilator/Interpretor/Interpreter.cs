#define debug

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compilator.Files;
using RobotLibrary;
using Compilator.Interpretor.Maker;
using RobotLibrary.Global;
using RobotLibrary.Command;


namespace Compilator.Interpretor
{
    public class Interpreter
    {
         //private static string savePath; --> remplacer par BUILD_PATH
        private static string[] usedFunctionName = { "Main", "print", "wait", "run" };
        private static int iFL = 0; // L'index dans le fileLine
        private static string[] fileLine;
        private static StringBuilder sb = new StringBuilder();
        public static List<string> ProgramList = new List<string>();
        
        private const string PASS = "PASS";


        public static string Interprete()
        {
            // Ouverture de du programme à compiler/interpreté
            fileLine = FileGestion.GetFileLine(Files.Const.CS_PATH);
            string line;
           

            // Formattage du fichier de base .cs
            for (; iFL < fileLine.Length; iFL++)
            {
                line = fileLine[iFL];

                // Mise a jour de Main et obtention de la liste des programmes
                if (line.Contains("Main_" + Files.Const.CS_NAME))
                {
                    addLine(line);
                    Utils.GetAllProgramNames(ref iFL, fileLine);


                }
                else if (line.Contains("static") && line.Contains("void"))
                {
                    // On vérifie que ce n'est pas le main ni le print
                    int index = line.IndexOf("void") + "void".Length;
                    string programName = line.Substring(index);
                    programName = programName.Substring(0, programName.IndexOf('('));
                    programName = programName.Trim();

                    // Un nouveau programme est détecté.
                    if (!usedFunctionName.Contains(programName))
                        ProgramInterprete(programName);
                    else 
                        addLine(line);
                } 
                else 
                    addLine(line);       


            }

            return sb.ToString();
        }


        /// <summary>
        ///     Fonction qui gère de bout en bout la précompilation d'un 
        ///     "sous-programme" du programme en entier.
        /// </summary>
        /// <param name="programName"> Le nom du programme a interpréter </param>
        private static void ProgramInterprete(string programName)
        {
            
            string line = fileLine[iFL];
            JumpMaker.LabelList = new List<string>();


            while (!line.Contains('{'))
            {
                addLine(line);
                line = fileLine[++iFL];
            }
            ++iFL;


            /// A amélioré -->
            ///     Passé le BUILD_PATH une seule fois au lieux de le repasser a chaque programmes .ls
            addLine($"{line}\nGeneration.setup(\"{programName}\", @\"{Files.Const.BUILD_PATH}\");\n");


            // On obtient tout le code programme
            int indexProgramEnd = Utils.GetIndexEndBlock(iFL + 1, fileLine);
            //int indexToPushProgramCreateProgrammeInfo = getLastProgramInfo(fileLine, iFL);

            for (; iFL < indexProgramEnd; iFL++)
            {
                line = fileLine[iFL].TrimStart();

                // Generation déjà présent
                if (line.StartsWith("Generation"))
                    addLine(line);
                // Commentaire
                else if (line.StartsWith("//!"))
                    addLine(Comment.ToString(line));
                // Ligne vide
                else if (line.Trim().Length == 0)
                    Utils.PassBlankLine(ref iFL, fileLine);
                // Call 
                else if (ProgramList.Contains(line.Trim()))
                    CallMaker.Call(line);
                // If
                else if (line.StartsWith("if"))
                    IfElseMaker.IfMake(iFL, ref fileLine);
                // Goto
                else if (line.StartsWith("goto"))
                    JumpMaker.GotoMaker(line);
                // Label
                else if (line.Contains(':'))
                    JumpMaker.LabelMaker(line);    
                // For               
                else if (line.StartsWith("for"))
                    ForMaker.Make(iFL, fileLine);
                else if (line.StartsWith("UFRAME_NUM"))
                    addLine(Uframe.SetMake(line));
                else if (line.StartsWith("UTOOL_NUM"))
                    addLine(Utool.SetMake(line));
                // Autre
                else if (!line.Contains(PASS))
                    addLine(line);
                

            }


            // Fin du programme, on peux donc le créer et l'enregistré dans un .ls
            addLine("Generation.Save();\n}\n");

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
