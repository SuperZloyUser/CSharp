using System;
using System.Linq;

namespace Lab_2
{
    public class ContainingArray
    {
        public readonly double[] SeriesArray;
        private static long Factorial(long x)
        {
            return (x == 0) ? 1 : x * Factorial(x - 1);
        }
        
        public double GetSum
        {
            get
            {
                return SeriesArray.Count(value => value <= 0.9);
                // var result = 0;
                // foreach (var value in _seriesArray)
                // {
                //     if (value <= 0.9) result++;
                // }
                // return result;
            }
        }

        public ContainingArray(int count)
        {
            SeriesArray = new double[count];
        }

        public ContainingArray(int count, double x)
        {
            var currentUp = x;
            var currentDown = 1;
            var result = 0d;
            
            SeriesArray = new double[count];

            for (var i = 0; i < count; i++)
            {
                result += currentUp / Factorial(currentDown);

                try
                {
                    SeriesArray[i] = result;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }

                currentUp *= x * x;
                currentDown += 2;
            }
        }

        public double CalculateSpecialSum()
        {
            var flag = 0;
            var firstPos = -1;
            var lastPos = -1;
            var result = 0d;
            
            
            for (var i = 0; i < SeriesArray.Length; i++)
            {
                if (flag < 2 && SeriesArray[i] > 0 && firstPos == -1)
                {
                    firstPos = i;
                    flag++;
                }

                if (flag < 2 && SeriesArray[SeriesArray.Length - i - 1] > 0 && lastPos == -1)
                {
                    lastPos = SeriesArray.Length - i - 1;
                    flag++;
                }

                if (flag == 2) break;
            }

            for (var i = firstPos; i <= lastPos; i++)
            {
                result += SeriesArray[i];
            }

            return result;
        }
        
    }
}
