using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewtonMethod
{
    public static class NewtonMethodRoot
    {
        public static double Root(double number, uint pow, double accuracy)
        {
            if (number < 0)
                throw new ArgumentException("Подкорневое число должно быть положительным действительным");

            if (accuracy > 1)
                throw new ArgumentException("Точность должна быть меньше единицы");

            double x0 = number;
            double x1 = x0 - ((Math.Pow(x0, pow) - number) / (number * Math.Pow(x0, pow - 1)));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = x0 - ((Math.Pow(x0, pow) - number) / (number * Math.Pow(x0, pow - 1)));
            }

            int i = 0;
            while (true)
            {
                if ((accuracy * (Math.Pow(10, i)) > 1))
                    return Math.Round(x1, i);

                i++;
            }
        }
    }
}
