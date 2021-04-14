using System;

namespace RobotLibrary
{

    public class Comment
    {
        public static void comment(string comment)
        {

            Utils.StringUtils.TextVerify(ref comment, Const.COMMENT_MAX_CHAR);
            //Comment.checkLenght(comment);

            #if debug
            Console.WriteLine($"!{comment}");
            #endif

            Generation.appendLine(String.Format("  !{0} ;", comment));

        }

        /*public static string getFormatedComment(string brutComment)
        {
            string comment = brutComment.Substring(brutComment.IndexOf('!') + 1).TrimStart(' ').TrimEnd();

            return "Comment.comment(\"" + comment + "\");";
        }*/

        public static string ToString(string comment) {
            return "Comment.comment(\"" + 
            comment.Substring(comment.IndexOf('!') + 1).TrimStart(' ').TrimEnd() + 
            "\");";
        }   

    }
}

