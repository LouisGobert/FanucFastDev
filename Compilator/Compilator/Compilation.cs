using System;
using System.IO;
using Compilator.Interpretor;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection;
using System.Linq;
using System.Runtime.Loader;


namespace Compilator
{
    class Compilation
    {

        public static bool Start()
        {

            string preCompiledFile = Interpreter.Interprete();

            return Compilation.Compile(preCompiledFile);
            
        }

        private static bool Compile(string preCompiledFile) {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(preCompiledFile);

            //string formatation = ViewModelGeneration.GenerateViewModel(syntaxTree);

            var refPaths = new [] {
                typeof(System.Object).GetTypeInfo().Assembly.Location,
                typeof(Console).GetTypeInfo().Assembly.Location,
                Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "System.Runtime.dll"),
                Files.Const.ROBOT_LIBRARY_DLL_PATH
            };

            MetadataReference[] references = refPaths.Select(r => MetadataReference.CreateFromFile(r)).ToArray();
            

            CSharpCompilation compilation = CSharpCompilation.Create(
                "assembly",
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));


            // Endroit ou le fichier .dll va être créé
            string path = Files.Const.TMP_DLL_PATH;
            
            // Compilation
            EmitResult compilationResult = compilation.Emit(path);

            if (compilationResult.Success) 
            {
                // Chargement de du dll puis exécution
                Assembly asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

                asm.GetType(Files.Const.CS_NAME).GetMethod("Main_" + Files.Const.CS_NAME).Invoke(null, null);
            } 
            else
            {
                foreach (Diagnostic codeIssue in compilationResult.Diagnostics)
                    Console.WriteLine($"ID: {codeIssue.Id} --> Message: {codeIssue.GetMessage()}\n" +
                                      $"Location: {codeIssue.Location.GetLineSpan()}\n" +
                                      $"Sévérité: {codeIssue.Severity}\n");
                

                return false;
            }

            return true;
        }

    }
}
