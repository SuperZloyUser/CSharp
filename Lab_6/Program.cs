using System;
using System.Diagnostics;
using System.Threading;

namespace Lab_6
{
    static class Program
    {
        private static double XStart { get; set; }
        private static double XEnd { get; set; }
        private static double Dx { get; set; }
        private static double Precision { get; set; }
        private static int CountOfThreads { get; set; }
        private static Thread[] Threads { get; set; }
        private static AutoResetEvent[] WaitHandler { get; set; }

        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter count of threads: ");
                    CountOfThreads = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter the start number: ");
                    XStart = double.Parse(Console.ReadLine()!);
                    Console.Write("Enter the end value: ");
                    XEnd = double.Parse(Console.ReadLine()!);
                    Console.Write("Enter dx: ");
                    Dx = double.Parse(Console.ReadLine()!);
                    Console.Write("Enter Precision: ");
                    Precision = double.Parse(Console.ReadLine()!);
                    if (XEnd < XStart)
                        throw new Exception("Incorrect X-Start/X-End");
                    if (CountOfThreads > (XEnd - XStart) / Dx)
                        throw new Exception("Incorrect count of threads!");
                    break;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    CountOfThreads = 3;
                    XStart = 0.9999998;
                    XEnd = 0.99999999;
                    Dx = 0.00000001;
                    Precision = 0.00000000001;
                    break;
                }
            }

            Threads = new Thread[CountOfThreads];
            WaitHandler = new AutoResetEvent[CountOfThreads];
            
            for (var i = 0; i < CountOfThreads; i++)
                WaitHandler[i] = new AutoResetEvent(true);

            Console.WriteLine($"{"Thread", 6}{"x  ", 10} | {"f(x)      ", 12} | {"Sum(x)     ", 12} | " +
                              $"{"n   ", 10} | {"Condition     ", 20} | {"   Time elapsed", 8}");
            var counter = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = XStart; i <= XEnd; i += Dx)
            {
                var taylorS = new TaylorSeriesArccotangent();
                Threads[counter % CountOfThreads] = 
                    new Thread(new ParameterizedThreadStart(taylorS.CalculateValue));

                Threads[counter % CountOfThreads].Start(
                    new Params(i, Precision, counter % CountOfThreads, ref WaitHandler[counter % CountOfThreads]));
                
                counter++;
            }
            WaitHandle.WaitAll(WaitHandler);
            stopwatch.Stop();
            Console.WriteLine($"Summary time elapsed: {stopwatch.Elapsed}");
        }
    }
}