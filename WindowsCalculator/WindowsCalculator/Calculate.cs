using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsCalculator
{
    public class Calculate
    {
        public static Double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static Double Divide(double num1, double num2)
        {
            
            return num1 / num2;
        }
        public static Double Multiply(double num1, double num2)
        {

            return num1 * num2;
        }
        public static Double Minus(double num1, double num2)
        {
            return num1 - num2;
        }
        public static Double SquareRoot(double num1)
        {
            return Math.Sqrt(num1);
        }

        public static Double BackSpace(double num1)
        {
            if (num1.ToString().Length > 0)
            {
                return double.Parse(num1.ToString().Remove(num1.ToString().Length - 1));
            }
            else
            {
                return 0;
            }
             
        }

        public static Double Squared(double num1)
        {
            return num1 * num1;
        }

        public static Double Reciprocal(double num1)
        {
            return 1 / num1;
        }

    }
}
