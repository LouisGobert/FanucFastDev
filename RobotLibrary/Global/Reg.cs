using RobotLibrary.Utils;
using System;

namespace RobotLibrary.Global
{

    public class Reg
    {

        private int _num;
        private string _desc;


        private int _value;
        public int Value;

        public string Desc {
            get => _desc;

            set {
                // On vérifie la description
                StringUtils.TextVerify(ref value, Const.R_DESC_MAX_CHAR);

                _desc = value;
            }
        }


        public Reg(int num)
        {
            _num = num;
            _desc = string.Empty;
        }


        public void Set(Reg newReg) {
            Generation.appendLine($"  {this}={newReg}    ;");
        }




        public static Reg[] Init()
        {
            Reg[] list = new Reg[Const.MAX_R + 1];
            for (int i = 0; i < Const.MAX_R+1; i++)
                list[i] = new Reg(i);
            

            return list;
        }

        
        public override string ToString()
        {
            string s = "R[" + _num;
            if (Desc != string.Empty)
                s += ":" + _desc;

            return s + "]";

        }


        public string formatForBracket()
        {
            return "R[" + this._num + ((this._desc == string.Empty) ? string.Empty : ":" + this._desc) + "]" ;
        }



/*
        public static string operator +(Reg x, int xx) {
            return x.ToString() + xx.ToString();
        }

        public static implicit operator Reg(string s) => new Reg(123);*/
    }
}
