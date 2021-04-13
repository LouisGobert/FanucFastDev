using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotLibrary.Utils;

namespace RobotLibrary.Global
{

    public class PosReg
    {

        private int _num;

        private string _desc;
        public string Desc {
            get => _desc;

            set {
                // On vérifie la description
                StringUtils.TextVerify(ref value, Const.PR_DESC_MAX_CHAR);

                _desc = value;
            }
        }

        public int[] Coo;

        public PosReg(int num)
        {
            _num = num;
            _desc = string.Empty;

            Coo = new int[6];

        }



        public static PosReg[] Init()
        {

            PosReg[] list = new PosReg[Const.MAX_PR + 1];
            for (int i = 0; i < Const.MAX_PR+1; i++)
            {
                list[i] = new PosReg(i);
            }

            return list;
        }

        public void Set(PosReg newPR) {
            Coo = newPR.Coo;
            Generation.appendLine($"  {this}={newPR}    ;");
        }


        public override string ToString()
        {
            string s = "PR[" + _num;
            if (Desc != string.Empty)
                s += ":" + _desc;

            return s + "]";

        }


        public static void preCompile(string s)
        {
            if (s.Contains(".State"))
            {
                s.Replace("State", "format()");

            }
        }


        public string formatForBracket()
        {
            return "PR[" + this._num + ((this._desc == string.Empty) ? string.Empty : ":" + this._desc) + "]" ;
        }
    }
}
