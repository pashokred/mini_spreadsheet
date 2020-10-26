using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            //видобути значення змінної з таблиці

            Cell resCell = new Cell(result);

            if (Form1.TableIdentifier.ContainsKey(resCell))
            {
                if (Form1.IsCyclic(resCell))
                {
                    string message = "ERROR: Cycle found in cell " + Form1.CurrentCell.position + " that refers to cell " + result;
                    throw new InvalidOperationException(message);
                }

                Form1.CurrentCell.TemporaryDependencies.Add(resCell);
                return Form1.TableIdentifier[resCell];
            }
            return 0.0;

            /*foreach (var (cell, value) in Form1.TableIdentifier)
            {
                if (cell.position == result)
                {
                    if (Form1.IsCyclic(cell))
                    {
                        string message = "ERROR: Cycle found in cell " + Form1.CurrentCellColumnIndex +
                                         (Form1.CurrentCellRowIndex + 1).ToString() + "that refers to cell " + result;
                        throw new InvalidOperationException(message);
                    }

                    Form1.Dependencies[Form1.CurrentCellColumnIndex + (Form1.CurrentCellRowIndex + 1).ToString()].Add();


                    return value;
                }
            }
            return 0.0;*/
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
            return Math.Pow(left, right);
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

            Debug.WriteLine(" {0} - {1} ", left, right);
            return left - right;
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

            Debug.WriteLine(" {0} <> {1} ", left, right);
            return Convert.ToDouble(left != right);
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