using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonMethod;

namespace CheckNewtonMethod
{
    class CheckNewtonMethod
    {
        static void Main(string[] args)
        {
            int number = 15;
            uint pow = 4;

            double sqrt = NewtonMethodRoot.Root(number, 4, 0.001);

            if ((int)Math.Pow(sqrt, pow) == number)
                Console.WriteLine("Check true");
            else
                Console.WriteLine("Check false");

            Console.ReadKey();
        }
    }
}
