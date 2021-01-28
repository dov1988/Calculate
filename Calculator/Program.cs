using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Program
    {
        static public double Calculate(string mathExpression)
        {
            Calculator calculator = new Calculator(mathExpression);
            string newMathExpression = "";
            double result;
            while (!Double.TryParse(newMathExpression.ToString(), out result))
            {
                newMathExpression = calculator.GetSimplifiedExpression();
            }       
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Program.Calculate("122+545452/39999*(425454-(1234+5678/128))"));
            Console.ReadKey();
        }
    }
}
