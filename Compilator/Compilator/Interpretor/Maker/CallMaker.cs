namespace Compilator.Interpretor.Maker {

    public static class CallMaker {

        public static void Call(string calledProgram) {
            Interpreter.addLine("Generation.appendLine(\"  " +
                                $"CALL {calledProgram.Substring(0, calledProgram.IndexOf('(')).TrimStart()}    ;\");");
            
        }

    }
}