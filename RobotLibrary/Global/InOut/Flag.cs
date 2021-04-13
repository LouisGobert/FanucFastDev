using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary.Global.InOut
{

    public class Flag : IInOut
    {

        private const string ON = "ON";
        private const string OFF = "OFF";

        private int _num;
        public string State { get; private set; }

        public Flag(int num)
        {
            _num = num;
        }

        public static Flag[] Init()
        {

            Flag[] list = new Flag[Const.MAX_F + 1];
            for (int i = 0; i < Const.MAX_F+1; i++)
            {
                list[i] = new Flag(i);
            }

            return list;
        }


        public void On()
        {
            Generation.appendLine(String.Format("  {0}=ON ;", this));
            State = ON;
        }

        public void Off()
        {
            Generation.appendLine(String.Format("  {0}=OFF ;", this));
            State = OFF;
        }

        public override string ToString()
        {
            return "F[" + _num + "]";
        }

    }
}
