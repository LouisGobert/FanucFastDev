using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Compilator.Files;
using Compilator.Interpretor;
using Microsoft.CSharp;
using RobotLibrary;
using System.CodeDom.Compiler;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Reflection;
using System.Linq;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis.Emit;


namespace Compilator
{
    class Compilation
    {

        static Action<string> Write = Console.WriteLine;

        public static void startCompilation()
        {

            string preCompiledFile = Interpreter.interprete();

            if (Compilation.compile(preCompiledFile))
            {
                //Process.Start("explorer.exe", savePath);

            }
            

            
            
        }

        private static bool compile(string preCompiledFile) {
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

                object result = asm.GetType("FanucFastDev").GetMethod("MainSolution").Invoke(null, null);
            } 
            else
            {
                foreach (Diagnostic codeIssue in compilationResult.Diagnostics)
                {
                    string issue = $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()}," +
                    "Location: {codeIssue.Location.GetLineSpan()}," +
                    "Severérité: {codeIssue.Severity}";
                    Console.WriteLine(issue);
                }
            }

/*
            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    Console.WriteLine("Compilation failed!");
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic => 
                        diagnostic.IsWarningAsError || 
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        Console.Error.WriteLine("\t{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                }
                else
                {
                    Console.WriteLine("Compilation successful! Now instantiating and executing the code ...");
                    ms.Seek(0, SeekOrigin.Begin);
                    
                    Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                    var type= assembly.GetType("RoslynCompileSample.Writer");
                    //var instance = assembly.CreateInstance("RoslynCompileSample.Writer");
                    var instance = assembly.CreateInstance("FanucFastDev");
                    var meth = type.GetMember("FanucFastDev").First() as MethodInfo;
                    meth.Invoke(instance, null);
                }
            }
*/

            return true;
        }

  
        private static bool compilee(string preCompiledFile)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();


            ICodeCompiler icc = codeProvider.CreateCompiler();
            //ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "Out.exe";

            CodeDomProvider cs = new CSharpCodeProvider();

            CompilerParameters parameters = new CompilerParameters();

            //CompilerParameters parameters = new CompilerParameters();
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;

            /////////////////////////////////////////////////////////////
            ///
            /// C'est ici qu'on spécifie la blibliothéque RobotLibrary
            /// 
            /////////////////////////////////////////////////////////////
            parameters.ReferencedAssemblies.Add("RobotLibrary.dll");

            codeProvider.CompileAssemblyFromSource(parameters, preCompiledFile);

            // Comppilation
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, preCompiledFile);
            //CompilerResults results = icc.CompileAssemblyFromSource(parameters, preCompiledFile);



            // Erreur lors de la compilation
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    Console.WriteLine("Line number " + CompErr.Line +
                                        ", Error Number: " + CompErr.ErrorNumber +
                                        ", '" + CompErr.ErrorText + ";\n\n");
                }

                return false;
            }


            //Compilation correcte
            Process.Start(Output);
            


            return true;
        }


    }
}
