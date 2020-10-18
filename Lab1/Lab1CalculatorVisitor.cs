using System.Collections.Generic;
using System.Diagnostics;
using Lab1Calculator;

namespace Lab1
{
    class Lab1CalculatorVisitor : Lab1CalculatorBaseVisitor<double>
    {
    //таблиця ідентифікаторів (тут для прикладу)
    //в лабораторній роботі заміните на свою!!!!

        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();

        public override double VisitCompileUnit(Lab1CalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(Lab1CalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(Lab1CalculatorParser.IdentifierExprContext context)
        {
            string result = context.GetText();
            double value;
            //видобути значення змінної з таблиці
            if (tableIdentifier.TryGetValue(result, out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(Lab1CalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(Lab1CalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine(" {0} ^ {1} ", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(Lab1CalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1CalculatorLexer.ADD)
            {
                Debug.WriteLine(" {0} + {1} ", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine(" {0} - {1} ", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(Lab1CalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1CalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine(" {0} * {1} ", left, right);
                return left * right;
            }
            else //Lab1CalculatorLexer.DIVIDE
            {
                Debug.WriteLine(" {0} / {1} ", left, right);
                return left / right;
            }
        }

        private double WalkLeft(Lab1CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <Lab1CalculatorParser.ExpressionContext> (0));
        }

        private double WalkRight(Lab1CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <Lab1CalculatorParser.ExpressionContext> (1));
        }
    }
}