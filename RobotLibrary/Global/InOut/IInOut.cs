
namespace RobotLibrary.Global.InOut
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
