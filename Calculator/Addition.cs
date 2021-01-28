using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Addition
    {
        private double operand1;
        private double operand2;
        public Addition(double operand1, double operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public double Add()
        {
            return operand1 + operand2;
        }
    }
}
