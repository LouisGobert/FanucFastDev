using RobotLibrary.Global;

namespace RobotLibrary.Local
{
    public static class ProgramInfo
    {
        public static string Name;
        public static string Desc;          // La descirption du programme
        public static string GroupMask;     // Le group mask
        public static int Type;             // Le type de programme [macro, tp]
        public static bool KeepBlankLine;   // Si l'on shouite garder les lignes vides.

        /// <summary>
        ///     Fonction qui est appellée au début de chaque nouveau programme .ls
        ///     affin de "créer" une nouvelle instance d'un progamme.
        ///     
        ///     Je n'utilise pas un object ProgrameInfo car l'utilisateur devrait alors 
        ///     le créer lui même et donc ce serait plus lourd et compliqué.
        /// </summary>
        public static void Reset()
        {
            Name = string.Empty;
            Desc = string.Empty;
            GroupMask = "*,*,*,*,*";
            Type = Const.TP_PROGRAM;
            KeepBlankLine = true;
        }
    }
}
