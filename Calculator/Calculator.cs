using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        private string mathExpression;
        public Calculator(string mathExpression)
        {
            this.mathExpression = mathExpression;
        }
        public string GetSimplifiedExpression()
        {
            Tuple<string, double, bool> intermediateExpressionData = СalculateIntermediateResult();
            if (intermediateExpressionData.Item3)
            {
                return this.mathExpression = mathExpression.Replace("(" + intermediateExpressionData.Item1 + ")", intermediateExpressionData.Item2.ToString());
            }
            return this.mathExpression = mathExpression.Replace(intermediateExpressionData.Item1.ToString(), intermediateExpressionData.Item2.ToString());
        }
        public Tuple<string, double, bool> СalculateIntermediateResult()
        {
            Tuple<double, double, char, bool> intermediateExpressionData = GetOperands();
            double result;
            switch (intermediateExpressionData.Item3)
            {
                case '/':
                    result = new Division(intermediateExpressionData.Item1, intermediateExpressionData.Item2).Divide();
                    return new Tuple<string, double, bool>(intermediateExpressionData.Item1 + "/" + intermediateExpressionData.Item2, result, intermediateExpressionData.Item4);
                case '*':
                    result = new Multiplication(intermediateExpressionData.Item1, intermediateExpressionData.Item2).Multiply();
                    return new Tuple<string, double, bool>(intermediateExpressionData.Item1 + "*" + intermediateExpressionData.Item2, result, intermediateExpressionData.Item4);
                case '+':
                    result = new Addition(intermediateExpressionData.Item1, intermediateExpressionData.Item2).Add();
                    return new Tuple<string, double, bool>(intermediateExpressionData.Item1 + "+" + intermediateExpressionData.Item2, result, intermediateExpressionData.Item4);
                case '-':
                    result = new Subtraction(intermediateExpressionData.Item1, intermediateExpressionData.Item2).Subtract();
                    return new Tuple<string, double, bool>(intermediateExpressionData.Item1 + "-" + intermediateExpressionData.Item2, result, intermediateExpressionData.Item4);
                default:
                    throw new Exception("Данная математическая операция не существует.");
            }

        }
        public Tuple<double, double, char, bool> GetOperands()
        {
            Tuple<int, char, bool> signData = DeterminePriorityMathOperation(mathExpression);
            StringBuilder operand1 = new StringBuilder();
            StringBuilder operand2 = new StringBuilder();
            for (int i = signData.Item1 - 1; i >= 0; i--)
            {
                if (char.IsNumber(mathExpression[i]) || mathExpression[i].Equals(','))
                {
                    operand1.Insert(0, mathExpression[i]);
                }
                else
                {
                    break;
                }
            }
            for (int i = signData.Item1 + 1; i < mathExpression.Length; i++)
            {
                if (char.IsNumber(mathExpression[i]) || mathExpression[i].Equals(','))
                {
                    operand2.Append(mathExpression[i]);
                }
                else
                {
                    break;
                }
            }
            return new Tuple<double, double, char, bool>(Convert.ToDouble(operand1.ToString()), Convert.ToDouble(operand2.ToString()), signData.Item2, signData.Item3);
        }

        public Tuple<int, char, bool> DeterminePriorityMathOperation(string mathExpression)
        {
            StringBuilder partMathExpression = new StringBuilder();
            Tuple<int, char, bool> signData = null;
            if (mathExpression.Contains('('))
            {
                for (int i = mathExpression.IndexOf('(') + 1; i < mathExpression.Length; i++)
                {
                    if (mathExpression[i].Equals('('))
                    {
                        partMathExpression.Clear();
                    }
                    else if (mathExpression[i].Equals(')'))
                    {
                        break;
                    }
                    //if (!char.IsNumber(mathExpression[i]) && !mathExpression[i].Equals('.') && mathExpression[i] != '(' && mathExpression[i + 1] != '(')
                    //{
                    //    return new Tuple<int, char, bool>(i, mathExpression[i], true);
                    //}
                    else
                    {
                        partMathExpression.Append(mathExpression[i]);
                    }
                }
                for (int j = 0; j < partMathExpression.Length; j++)
                {
                    if (!char.IsNumber(partMathExpression[j]))
                    {
                        if(signData == null)
                        {
                            signData = new Tuple<int, char, bool>(j, partMathExpression[j], true);
                        }
                        else
                        {
                            this.mathExpression = partMathExpression.ToString();
                            double result;
                            string newMathExpression = "";
                            while (!Double.TryParse(newMathExpression.ToString(), out result))
                            {
                                newMathExpression = GetSimplifiedExpression();
                            }
                        }
                    }
                }
                //for (int j = 0; j < partMathExpression.Length; j++)
                //{
                //    if (!char.IsNumber(partMathExpression[j]))
                //    {

                //        return new Tuple<int, char, bool>(j, partMathExpression[j], true);
                //    }
                //}
            }
            else if (mathExpression.Contains('/') && mathExpression.Contains('*'))
            {
                if(mathExpression.IndexOf('/') < mathExpression.IndexOf('*'))
                {
                    return new Tuple<int, char, bool>(mathExpression.IndexOf('/'), '/', false);
                }
                return new Tuple<int, char, bool>(mathExpression.IndexOf('*'), '*', false);
            }
            else if (mathExpression.Contains('/'))
            {
                return new Tuple<int, char, bool>(mathExpression.IndexOf('/'), '/', false);
            }
            else if (mathExpression.Contains('*'))
            {
                return new Tuple<int, char, bool>(mathExpression.IndexOf('*'), '*', false);
            }
            else if (mathExpression.Contains('-') && mathExpression.Contains('+'))
            {
                if (mathExpression.IndexOf('-') < mathExpression.IndexOf('+'))
                {
                    return new Tuple<int, char, bool>(mathExpression.IndexOf('-'), '-', false);
                }
                return new Tuple<int, char, bool>(mathExpression.IndexOf('+'), '+', false);
            }
            else if (mathExpression.Contains('+'))
            {
                return new Tuple<int, char, bool>(mathExpression.IndexOf('+'), '+', false);
            }
            return new Tuple<int, char, bool>(mathExpression.IndexOf('-'), '-', false);
        }
    }
}
