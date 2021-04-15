using System.Collections.Generic;
using RobotLibrary.Global;

namespace RobotLibrary
{

    public class Pos
    {

        private bool _format;
        public string _desc { get; set; }
        public ushort _num { get; private set; }
        public PosReg PROffset;

        public static List<Pos> PosList { get; private set; }

        //public Uframe Uframe;
        //public Utool Utool;

        public Pos(ushort num)
        {
            _num = num;
            _format = Const.J;
            _desc = string.Empty;
            PosList.Add(this);
            
        }


        public Pos(ushort num, string description)
        {
            _desc = description;
            _num = num;
            _format = Const.J;
            PosList.Add(this);
        }

        public Pos(ushort num, string description, bool format)
        {
            _desc = description;
            _num = num;
            _format = format;
            PosList.Add(this);
        }


        public static void DeleteAllPos()
        {
            PosList = new List<Pos>();
        }


        public string formatForBracketMark()
        {
            return (this._desc == string.Empty) ? string.Empty : ":\"" + this._desc + "\"";
        }

        public string formatForBracket()
        {
            return "P[" + this._num + ((this._desc == string.Empty) ? string.Empty : ":" + this._desc) + "]" ;
        }


        public static string generateAllPoint()
        {

            // Le string contenant les instructions P[1:"test"]
            string progPoint = string.Empty;

            foreach (Pos pos in PosList)
            {
                if (pos._format == Const.J)
                    generateJPoint(pos, ref progPoint);
                else
                    generatepPPoint(pos, ref progPoint);
            }


            return progPoint;
        }



        private static void generateJPoint(Pos pos, ref string progPoint)
        {
            progPoint += $"P[{pos._num}{pos.formatForBracketMark()}]{{\n" +
                             "   GP1:\n" +
                             "    UF : 0, UT: 1, \n" +
                             "    J1=     0.000 deg,  J2=     0.000 deg,  J3=     0.000 deg,\n" +
                             "    J4=     0.000 deg,  J5=     0.000 deg,  J6=     0.000 deg\n" +
                             "};\n";


        }

        private static void generatepPPoint(Pos pos, ref string progPoint)
        {

            progPoint += $"P[{pos._num}{pos.formatForBracketMark()}]{{\n" +
                             "   GP1:\n" +
                             "    UF : 0, UT : 1,     CONFIG : 'N U T, 0, 0, 0',\n" +
                             "    X =     0.000  mm,  Y =     0.000  mm,  Z =     0.000  mm,\n" +
                             "    W =     0.000 deg,  P =     0.000 deg,  R =     0.000 deg\n" +
                             "};\n";
        }


        public Pos Offset(PosReg posReg) {
            
            PROffset = posReg;
            return this;
        } 

    }

}

