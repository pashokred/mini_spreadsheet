using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;


namespace Lab1
{
    class Lab1Visitor : Lab1BaseVisitor<double>
    {
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
            //видобути значення змінної з таблиці
            if (Form1.TableIdentifier.TryGetValue(result, out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        /*private static (string, int) ParseIdentifier(string identifier)
        {
            (string, int) column_row = ("", 0);
            string row = "";

            for (int i = 0; identifier[i] >= 'A' && identifier[i] <= 'Z'; ++i)
            {
                column_row.Item1 += identifier[i].ToString();
            }
            for (int i = column_row.Item1.Length; identifier[i] >= '0' && identifier[i] <= '9'; ++i)
            {
                row += identifier[i].ToString();
            }
            column_row.Item2 = int.Parse(row);

            return column_row;
        }*/


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
            switch (context.operatorToken.Type)
            {
                case Lab1Lexer.MULTIPLY:
                    Debug.WriteLine(" {0} * {1} ", left, right);
                    return left * right;
                case Lab1Lexer.DIVIDE:
                    Debug.WriteLine(" {0} / {1} ", left, right);
                    return left / right;
                case Lab1Lexer.DIV:
                    Debug.WriteLine(" {0} div {1} ", left, right);
                    return Convert.ToInt32(left) / Convert.ToInt32(right);
                //if (context.operatorToken.Type == Lab1Lexer.MOD)
                default:
                    Debug.WriteLine(" {0} mod {1} ", left, right);
                    return left % right;
            }
        }

        public override double VisitRelationalExpr(Lab1Parser.RelationalExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            switch (context.operatorToken.Type)
            {
                case Lab1Lexer.GT:
                    Debug.WriteLine(" {0} > {1} ", left, right);
                    return Convert.ToDouble(left > right);
                case Lab1Lexer.GE:
                    Debug.WriteLine(" {0} >= {1} ", left, right);
                    return Convert.ToDouble(left >= right);
                case Lab1Lexer.LT:
                    Debug.WriteLine(" {0} < {1} ", left, right);
                    return Convert.ToDouble(left < right);
                //if (context.operatorToken.Type == Lab1Lexer.LE)
                default:
                    Debug.WriteLine(" {0} <= {1} ", left, right);
                    return Convert.ToDouble(left <= right);
            }
        }

        public override double VisitEqualityExpr(Lab1Parser.EqualityExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == Lab1Lexer.EQ)
            {
                Debug.WriteLine(" {0} = {1} ", left, right);
                return Convert.ToDouble(left == right);
            }
            else //(context.operatorToken.Type == Lab1Lexer.NE)
            {
                Debug.WriteLine(" {0} <> {1} ", left, right);
                return Convert.ToDouble(left != right);
            }
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