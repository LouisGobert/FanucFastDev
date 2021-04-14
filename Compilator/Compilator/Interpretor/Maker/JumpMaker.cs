using System.Collections.Generic;


namespace Compilator.Interpretor.Maker
{
    public class JumpMaker
    {


        public static List<string> LabelList;

        public static void LabelMaker(string s)
        {

            s = s.Substring(0, s.IndexOf(':')).Trim();

            Interpreter.addLine("Generation.appendLine(\"  " +
                                $"LBL[{LabelList.IndexOf(s)+ 1}:{s}] ;\");");

        }

        public static void GotoMaker(string s) {

            s = s.Substring(s.IndexOf(' '));
            s = s.Substring(0, s.IndexOf(';')).Trim();

            LabelList.Add(s);

            Interpreter.addLine("Generation.appendLine(\"  " +
                               $"JMP LBL[{LabelList.IndexOf(s) + 1}] ;\");");
        }


        
    }
}
