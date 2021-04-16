using System;
using static RobotLibrary.Global.Const;

namespace RobotLibrary.Global.InOut
{

    public class Rout : IInOut
    {

        private int _num;
        public string State { get; private set; }

        public Rout(int num)
        {
            _num = num;
        }



        public static Rout[] Init()
        {

            Rout[] list = new Rout[Const.MAX_RO + 1];
            for (int i = 0; i < Const.MAX_RO+1; i++)
            {
                list[i] = new Rout(i);
            }

            return list;
        }


        public void On()
        {
            Generation.appendLine($"  {this}=ON ;");
            State = ON;
        }

        public void Off()
        {
            Generation.appendLine($"  {this}=OFF ;");
            State = OFF;
        }

        public override string ToString() =>  "RO[" + _num + "]";
        

        public static implicit operator bool(Rout RobotOut) => true;
        public static implicit operator string(Rout r) => string.Empty;

        
        /*
        public static string operator +(Reg x, int xx) {
            return x.ToString() + xx.ToString();
        }

        public static implicit operator Reg(string s) => new Reg(123);*/

    }
}
