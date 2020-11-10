using NUnit.Framework;

namespace Lab1.Tests
{
    public class Form1Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsDependent_CheckIfCellsHaveCycle_True()
        {
            // Arrange
            
            Cell a1Cell = new Cell("A1");
            Cell b2Cell = new Cell("B2");
            Cell c3Cell = new Cell("C3");
            Cell d4Cell = new Cell("D4");
            a1Cell.Dependencies.Add(b2Cell);
            b2Cell.Dependencies.Add(c3Cell);
            c3Cell.Dependencies.Add(a1Cell);
            d4Cell.Dependencies.Add(a1Cell);

            // Act

            bool a1B2 = Form1.IsDependent(a1Cell, b2Cell);
            bool a1C3 = Form1.IsDependent(a1Cell, c3Cell);
            bool b2C3 = Form1.IsDependent(b2Cell, c3Cell);
            bool d4C3 = Form1.IsDependent(d4Cell, c3Cell);
            
            // Assert
            
            Assert.AreEqual(a1B2, true);
            Assert.AreEqual(a1C3, true);
            Assert.AreEqual(b2C3, true);
            Assert.AreEqual(d4C3, true);
        }
    }

    public class ProgramTests
    {
        [Test]
        public void ComputeColumnName_ComputeReversedColumnNameFromNumber_True()
        {
            // Arrange

            int numb1 = 50;
            int numb2 = 14;
            int numb3 = -5;
            int numb4 = 0;
            int numb5 = 4000;

            // Act

            string col1 = Program.ComputeColumnName(numb1);
            string col2 = Program.ComputeColumnName(numb2);
            string col3 = Program.ComputeColumnName(numb3);
            string col4 = Program.ComputeColumnName(numb4);
            string col5 = Program.ComputeColumnName(numb5);

            // Assert
            
            Assert.AreEqual(col1, "YA");
            Assert.AreEqual(col2, "O");
            Assert.AreEqual(col3, "");
            Assert.AreEqual(col4, "A");
            Assert.AreEqual(col5, "WWE");
            
        }
        
        [Test]
        public void PrintColumnName_ComputeColumnNameReversed_True()
        {
            // Arrange

            int numb1 = 50;
            int numb2 = 14;
            int numb3 = -5;
            int numb4 = 0;
            int numb5 = 4000;

            // Act

            string col1 = Program.PrintColumnName(numb1);
            string col2 = Program.PrintColumnName(numb2);
            string col3 = Program.PrintColumnName(numb3);
            string col4 = Program.PrintColumnName(numb4);
            string col5 = Program.PrintColumnName(numb5);

            // Assert
            
            Assert.AreEqual(col1, "AY");
            Assert.AreEqual(col2, "O");
            Assert.AreEqual(col3, "");
            Assert.AreEqual(col4, "A");
            Assert.AreEqual(col5, "EWW");
        }
    }

    
    /*public class CalculatorTests
    {
        [Test]
        public void Evaluate_EvaluateValueFromCell_True()
        {
            // Arrange

            string expr1 = "(15-40/5)*10";
            string expr2 = "(15-40/5)*10 > 0";
            string expr3 = "(15-40/5)*10 = 15";
            string expr4 = "(15-40/5)*10 <> 14";
            string expr5 = "(15-40/5)*10 + 10";

            // Act

            double val1 = Calculator.Evaluate(expr1);
            double val2 = Calculator.Evaluate(expr2);
            double val3 = Calculator.Evaluate(expr3);
            double val4 = Calculator.Evaluate(expr4);
            double val5 = Calculator.Evaluate(expr5);

            // Assert
            
            Assert.AreEqual(val1, 70.0);
            Assert.AreEqual(val2, 1.0);
            Assert.AreEqual(val3, 0.0);
            Assert.AreEqual(val4, 1.0);
            Assert.AreEqual(val5, 80.0);

        }
            
    }*/
    
}