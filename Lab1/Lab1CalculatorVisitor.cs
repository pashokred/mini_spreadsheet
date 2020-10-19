using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using Lab1Calculator;


namespace Lab1
{
    class Lab1Visitor : Lab1BaseVisitor<double>
    {
    //таблиця ідентифікаторів (тут для прикладу)
    //в лабораторній роботі заміните на свою!!!!

        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        public override double VisitCompileUnit(Lab1Parser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(Lab1Parser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(Lab1Parser.IdentifierExprContext context)
        {
            string result = context.GetText();
            double value;
            tableIdentifier = Program.FullFillDictionary(tableIdentifier);
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

        public override double VisitParenthesizedExpr(Lab1Parser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(Lab1Parser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine(" {0} ^ {1} ", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(Lab1Parser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1Lexer.ADD)
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

        public override double VisitMultiplicativeExpr(Lab1Parser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1Lexer.MULTIPLY)
            {
                Debug.WriteLine(" {0} * {1} ", left, right);
                return left * right;
            }
            else //Lab1Lexer.DIVIDE
            {
                Debug.WriteLine(" {0} / {1} ", left, right);
                return left / right;
            }
        }

        public override double VisitComparisonExpr(Lab1Parser.ComparisonExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1Lexer.GT)
            {
                Debug.WriteLine(" {0} > {1} ", left, right);
                return Convert.ToDouble(left > right);
            }
            else if (context.operatorToken.Type == Lab1Lexer.GE)
            {
                Debug.WriteLine(" {0} >= {1} ", left, right);
                return Convert.ToDouble(left >= right);
            }
            else if (context.operatorToken.Type == Lab1Lexer.LT)
            {
                Debug.WriteLine(" {0} < {1} ", left, right);
                return Convert.ToDouble(left < right);
            }
            else if (context.operatorToken.Type == Lab1Lexer.LE)
            {
                Debug.WriteLine(" {0} <= {1} ", left, right);
                return Convert.ToDouble(left <= right);
            }
            else //(context.operatorToken.Type == LabCalculatorLexer.EQ)
            {
                Debug.WriteLine(" {0} = {1} ", left, right);
                return Convert.ToDouble(left == right);
            }
        }

        public override double VisitModExpr(Lab1Parser.ModExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine(" {0} mod {1} ", left, right);
            return left % right;
        }

        public override double VisitDivExpr(Lab1Parser.DivExprContext context)
        {
            int left = Convert.ToInt32(WalkLeft(context));
            int right = Convert.ToInt32(WalkRight(context));
            Debug.WriteLine(" {0} div {1} ", left, right);
            return left / right;
        }


        private double WalkLeft(Lab1Parser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <Lab1Parser.ExpressionContext> (0));
        }

        private double WalkRight(Lab1Parser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <Lab1Parser.ExpressionContext> (1));
        }
    }
}