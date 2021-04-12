﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary.InOut
{

    public class RO : IInOut
    {

        private const string ON = "ON";
        private const string OFF = "OFF";

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


        public void On()
        {
            Generation.appendLine(String.Format("  {0}=ON ;", this.ToString()));
            State = ON;
        }

        public void Off()
        {
            Generation.appendLine(String.Format("  {0}=OFF ;", this.ToString()));
            State = OFF;
        }

        public override string ToString()
        {
            return "RO[" + _num + "]";
        }

    }
}
