using System;
using RobotLibrary.Utils;

namespace RobotLibrary.Global
{
    public class Uframe
    {

        private int _num;

        private string _desc;
        public string Desc {

            get => _desc;
            set {
                // On vérifie la description
                StringUtils.TextVerify(ref value, Const.UFRAME_MAX_CHAR);

                _desc = value;
            }
        }
   

        public Uframe(int num)
        {
            _num = num;
        }

        public static void Set(Uframe frame)
        {
            Generation.appendLine(String.Format("  UFRAME_NUM={0} ;", frame._num));

        }

        public static string SetMake(string line) {
            line = line.Substring(line.IndexOf('=') + 1);
            return $"Uframe.Set({line.Substring(0, line.IndexOf(';'))});";
        }


        public static Uframe[] Init() {

            Uframe[] uList = new Uframe[Const.MAX_UFRAME + 1];
            for (int i = 0; i < Const.MAX_UFRAME; i++)
                uList[i] = new Uframe(i);

            return uList;
        }

    }
}




