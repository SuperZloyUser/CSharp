using System;

namespace Lab1
{
    static class Program
    {
        private static double XStart { get; set; }
        private static double XEnd { get; set; }
        private static double Dx { get; set; }
        private static double Precision { get; set; }
        
        static void Main()
        {
            while (true)
            {
                try
                {
                    System.Console.Write("Enter the start number: ");
                    XStart = double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Enter the end value: ");
                    XEnd = double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Enter dx: ");
                    Dx = double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Enter Precision: ");
                    Precision = double.Parse(System.Console.ReadLine()!);
                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine(e.Message);
                }
            }

            System.Console.WriteLine($" {"x  ", 10} | {"f(x)    ", 20} | {"Sum(x)  ", 20} | {"n   ", 7} | {"Condition", 12} ");
            for (var i = XStart; i <= XEnd; i += Dx)
            {
                
                Console.WriteLine($" {$"{i:F10}".TrimEnd('0').TrimEnd('.'), 10} | {$"{Math.Atan(i):F10}", 20} | " +
                                  $"{$"{TaylorSeriesArccotangent.CalculateValue(i, Precision):F10}", 20} | " +
                                  $"{$"{TaylorSeriesArccotangent.I}", 7} | " +
                                  $"{TaylorSeriesArccotangent.Condition}");
                    
            }
            
        }
    }
}
