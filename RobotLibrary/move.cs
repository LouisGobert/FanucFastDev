using System;


namespace RobotLibrary
{
    public class move
    {
        public static void linear(pos target, int fast, int smooth)
        {

            if (smooth < 0)
                throw new FormatException("Le lissage d'un mouvement doit être strictement supérieure à 0");


            string lissage = (smooth == 0) ? "FINE" : smooth.ToString();

            #if  DEBUG 
            Console.WriteLine($"Mouvement linéaire vers {target.m_name} | {fast}mm/sec | {lissage}");
            #endif
            Generation.appendLine(String.Format("L P[{0}{1}] {2}mm/sec {3}    ;",
                                                target.m_num,
                                                target.formatForBracket(),
                                                fast, 
                                                smoothFormat(smooth)));

        }

        public static void joint(pos target, int fast, int smooth)
        {

            string lissage = smoothFormat(smooth);


            #if DEBUG
            Console.WriteLine($"Mouvement articulaire vers {target.m_name} | {fast}% | {lissage}");
            #endif

            Generation.appendLine(String.Format("J P[{0}{1}] {2}% {3}    ;",
                                                target.m_num,
                                                target.formatForBracket(),
                                                fast,
                                                lissage));
        }


        public static void circular(pos middle, pos target, int fast, int smooth)
        {
            string lissage = smoothFormat(smooth);


            #if DEBUG
            Console.WriteLine($"Mouvement circulaire en passant par {middle.m_name} vers {target.m_name} | {fast}mm/sec | {lissage}");
#endif

            Console.WriteLine("Pos formaté : " + target.formatForBracket());

            Generation.appendLine(String.Format("C P[{0}{1}]    \n     :  P[{2}{3}] {4}mm/sec {5}    ;",
                                                middle.m_num,
                                                middle.formatForBracket(),
                                                target.m_num,
                                                target.formatForBracket(),
                                                fast,
                                                lissage));
        }


        private static string smoothFormat(int smooth)
        {
            // Vérification
            if (smooth < 0)
                throw new FormatException("Le lissage d'un mouvement doit être strictement supérieure à 0");

            if (smooth == 0)
                return "FINE";
            else
                return "CNT" + smooth.ToString();
        }


    }
}

