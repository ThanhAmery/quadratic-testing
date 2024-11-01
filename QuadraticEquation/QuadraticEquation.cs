using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    public class QuadraticEquation
    {
        public string CalculateQuadraticEquation(int a, int b, int c)
        {
            string result = "";
            try
            {
                if (a == b && a == c && a == 0)
                {
                    throw new InvalidOperationException("No valid equation!");
                }
                if (a == 0)
                {
                    if (b == 0)
                    {
                        throw new NotFiniteNumberException();
                        
                    }
                    else
                    {
                        result = (-c / b).ToString();
                    }
                }
                else
                {
                    int delta = b * b - (4 * a * c);
                    if (delta < 0)
                    {
                        result = "No real roots!";
                    }
                    else if (delta == 0)
                    {
                        result = (-b / (2 * a)).ToString();
                    }
                    else
                    {
                        double a1 = ((-b + Math.Sqrt(delta)) / (2 * a));
                        double a2 = ((-b - Math.Sqrt(delta)) / (2 * a));
                        result = $"The quadratic has two solutions: {a1} and {a2}";
                    }
                }
            }
            catch (NotFiniteNumberException)
            {
                throw new InvalidOperationException("Invalid result: expected return!"); 
            }
            return result;
        }
    }
}
