using System;

namespace RobotLibrary
{

    public class Comment
    {
        public static void comment(string comment)
        {

            Comment.checkLenght(comment);

            #if DEBUG
            Console.WriteLine($"!{comment}");
            #endif

            Generation.appendLine(String.Format("  !{0} ;", comment));

        }

        private static void checkLenght(string s)
        {
            if (s.Length > 24)
                throw new FormatException("La mongueur maximum pour un commentaire est de 24 caract�res.");
        }

        public static string getFormatedComment(string brutComment)
        {
            string comment = brutComment.Substring(brutComment.IndexOf('!') + 1).TrimStart(' ');
            Comment.checkLenght(comment);

            return "Comment.comment(\"" + comment + "\");";
        }

    }
}

