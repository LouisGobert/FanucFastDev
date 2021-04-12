using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary.InOut
{

    public class RO
    {

        private int _num;
        public string State { get; private set; }

        public RO(int num)
        {
            _num = num;
        }



        public static RO[] Init()
        {

            RO[] list = new RO[Const.MAX_RO + 1];
            for (int i = 0; i < Const.MAX_RO+1; i++)
            {
                list[i] = new RO(i);
            }

            return list;
        }


        public void on()
        {
            Generation.appendLine(String.Format("  RO[{0}]=ON ;", _num));
            State = "ON";
        }

        public void off()
        {
            Generation.appendLine(String.Format("  RO[{0}]=OFF ;", _num));
            State = "OFF";
        }

        public string format()
        {
            return "RO[" + _num + "]";
        }


        public static void preCompile(string s)
        {
            if (s.Contains(".State"))
            {
                s.Replace("State", "format()");

            }
        }
    }
}
