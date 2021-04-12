using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RobotLibrary.InOut
{

    interface IInOut
    {

        // String car il faut pouvoir mettre :
        //      - ON
        //      - OFF
        //      - ON+
        //      - OFF-
        string State { get; }

        void On();
        void Off();

        string ToString();

    }
}
