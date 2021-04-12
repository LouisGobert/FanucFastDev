using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary.Utils
{
    public class StringUtils
    {
        private static char[] accent = { 'é', 'è', 'ê', 'â', 'û', 'î' };

        public static void textVerify(ref string s, int maxLength)
        {

            if (s.Length > maxLength)
            {
                Console.Write($"La phrase : \"{s}\" ne peux contenir que {maxLength} caractères.\n" +
                                         $"Veuillez introduire une phrase plus courte : ");

                s = Console.ReadLine();
                textVerify(ref s, maxLength);
                return;
            }
                

            for (int i = 0; i < s.Length; i++)
            {
                if (accent.Contains(s[i]))
                {
                    Console.Write(  $"La phrase : \"{s}\" ne peux pas contenir des accents.\n" +
                                         $"Veuillez introduire une nouvelle phrase : ");

                    s = Console.ReadLine();

                    // Vérification de la nouvelle phrase
                    textVerify(ref s, maxLength);
                    return;

                }
            }
        }
    }
}
