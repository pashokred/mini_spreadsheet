using System;
using System.Diagnostics;
using System.Linq;

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

            var resCell = new Cell(result);

            //TODO : fix cycling 
            
            if (Form1.TableIdentifier.ContainsKey(resCell))
            {
                resCell = Form1.TableIdentifier.FirstOrDefault(x => x.Key.Position == result).Key;
                resCell.Dependencies = Form1.TableIdentifier.FirstOrDefault(x => x.Key.Position == result).Key.Dependencies;
                resCell.Expression = Form1.TableIdentifier.FirstOrDefault(x => x.Key.Position == result).Key.Expression;
                
                if (Form1.IsCyclic(resCell))
                {
                    string message = "ERROR: Cycle found in cell " + Form1.CurrentCell.Position + " that refers to cell " + result;
                    throw new InvalidOperationException(message);
                }
                if(!resCell.Dependencies.Contains(Form1.CurrentCell))
                    resCell.Dependencies.Add(Form1.CurrentCell);
                return Form1.TableIdentifier[resCell];
                
            }
            resCell = new Cell(result);
            resCell.Dependencies.Add(Form1.CurrentCell);
            Form1.TableIdentifier.Add(resCell, 0.0);
            return 0.0;
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