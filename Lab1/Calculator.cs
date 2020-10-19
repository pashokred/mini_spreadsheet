using Antlr4.Runtime;

namespace Lab1
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new Lab1Lexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new Lab1Parser(tokens);
            var tree = parser.compileUnit();
            var visitor = new Lab1Visitor();
            return visitor.Visit(tree);
        }
    }
}