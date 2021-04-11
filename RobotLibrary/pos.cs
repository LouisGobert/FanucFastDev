/// TO IMPLEMENT
/// Gestion du numéro des points :
///     - ne peux pas y avoir deux instance de pos avec le même numéro.

using System;
using System.Collections.Generic;

namespace RobotLibrary
{

    public class pos
    {

        private int[] coo;
        public const ushort P = 1;
        public const ushort J = 0;

        public ushort            m_format { get; set; }
        public string              m_name { get; set; }
        public ushort               m_num { get; private set; }
        public static List<pos> m_posList { get; private set; }

        public Uframe Uframe;
        public Utool Utool;

        public pos(ushort num)
        {
            m_num = num;
            m_format = J;
            m_name = string.Empty;
            m_posList.Add(this);
            
        }

        /*public string getFastFormat()
        {
            if (m_format == J)
                return "%";
            else
                return "mm/sec";
        }*/

        public pos(ushort num, string name)
        {
            m_name = name;
            m_num = num;
            m_format = J;
            m_posList.Add(this);
        }

        public pos(ushort num, string name, ushort format)
        {
            m_name = name;
            m_num = num;
            m_format = format;
            m_posList.Add(this);
        }


        public static void deleteAllPos()
        {
            m_posList = new List<pos>();
        }


        public string formatForBracketMark()
        {
            return (this.m_name == string.Empty) ? string.Empty : ":\"" + this.m_name + "\"";
        }

        public string formatForBracket()
        {
            return (this.m_name == string.Empty) ? string.Empty : ":" + this.m_name ;
        }


        public static string generateAllPoint()
        {

            // Le string contenant les instructions P[1:"test"]
            string progPoint = string.Empty;

            foreach (pos pos in m_posList)
            {
                if (pos.m_format == pos.J)
                    generateJPoint(pos, ref progPoint);
                else
                    generatepPPoint(pos, ref progPoint);
            }


            return progPoint;
        }



        private static void generateJPoint(pos pos, ref string progPoint)
        {
            progPoint += $"P[{pos.m_num}{pos.formatForBracketMark()}]{{\n" +
                             "   GP1:\n" +
                             "    UF : 0, UT: 1, \n" +
                             "    J1=     0.000 deg,  J2=     0.000 deg,  J3=     0.000 deg,\n" +
                             "    J4=     0.000 deg,  J5=     0.000 deg,  J6=     0.000 deg\n" +
                             "};\n";


        }

        private static void generatepPPoint(pos pos, ref string progPoint)
        {

            progPoint += $"P[{pos.m_num}{pos.formatForBracketMark()}]{{\n" +
                             "   GP1:\n" +
                             "    UF : 0, UT : 1,     CONFIG : 'N U T, 0, 0, 0',\n" +
                             "    X =     0.000  mm,  Y =     0.000  mm,  Z =     0.000  mm,\n" +
                             "    W =     0.000 deg,  P =     0.000 deg,  R =     0.000 deg\n" +
                             "};\n";
        }



    }

}

