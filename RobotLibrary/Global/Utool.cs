using System;
using RobotLibrary.Utils;

namespace RobotLibrary.Global
{


    public class Utool
    {

        private int _num;
                private string _desc;
        public string Desc {

            get => _desc;
            set {
                // On vérifie la description
                StringUtils.TextVerify(ref value, Const.UTOOL_MAX_CHAR);

                _desc = value;
            }
        }


        public Utool(int num) {
            _num = num;
        }

        public static Utool[] Init() {

            Utool[] uList = new Utool[Const.MAX_UTOOL + 1];
            for (int i = 0; i < Const.MAX_UTOOL; i++)
                uList[i] = new Utool(i);

            return uList;
        }

        public static void Set(Utool tool) {

            Generation.appendLine(String.Format("  UTOOL_NUM={0} ;", tool._num));
        }

        public static string SetMake(string line) {
            line = line.Substring(line.IndexOf('=') + 1);
            return $"Utool.Set({line.Substring(0, line.IndexOf(';'))});";
        }


        public static implicit operator int(Utool utool) => 0;
        public static implicit operator Utool(int x) => Const.UserTool[x];
        //public static implicit operator int(Reg r) => 0;

        
    }

}



