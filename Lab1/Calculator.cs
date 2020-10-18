using Antlr4.Runtime;
using Lab1Calculator;

namespace Lab1
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new Lab1CalculatorLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new Lab1CalculatorParser(tokens);
            var tree = parser.compileUnit();
            var visitor = new Lab1CalculatorVisitor();
            return visitor.Visit(tree);
        }
    }
}