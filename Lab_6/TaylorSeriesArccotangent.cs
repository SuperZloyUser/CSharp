using System;
using System.Diagnostics;

namespace Lab_6
{
    public class TaylorSeriesArccotangent
    {
        
        private const int MaxN = 1000000000;
        private double Result { get; set; }
        public string Condition { get; private set; }
        public int I { get; private set; }
        public Stopwatch Stopwatch = new Stopwatch();

        private struct StepData
        {
            public double Top { get; set; }
            public double Under { get; set; }
            public bool Mark { get; set; }

            public StepData(double top, double under, bool mark)
            {
                Top = top;
                Under = under;
                Mark = mark;
            }
        }

        public void CalculateValue(object obj)
        {
            var curParams = (Params) obj;
            if (curParams != null)
            {
                var x = curParams.X;
                var precision = curParams.Precision;
                var threadNumber = curParams.ThreadNumber;
                var waitHandler = curParams.WaitHandler;
                waitHandler.WaitOne();
                
                Stopwatch.Start();
            
                Result = 0d;
                var stepData = new StepData(x, 1d, true);
                I = 0;

                if (Math.Abs(x) >= 1)
                {
                    Condition = "Неверное значение x!";
                    PrintCondition(x, threadNumber);
                    return;
                }

                for (; I < MaxN; I++)
                {
                    var stepValue = CalculateCurrent(stepData);

                    if (Math.Abs(stepValue) < precision)
                    {
                        break;
                    }

                    Result += stepValue;
                    // Console.WriteLine($"{I}) {$"{_result:F20}", 10}");
                    
                    UpdateDataForNextStep(ref stepData, x);
                }

                if (I == MaxN)
                {
                    Condition = "Ошибка вычисления! (Превышено число итераций)";
                    // throw new Exception("Задана слишком высокая точность!");
                    PrintCondition(x, threadNumber);
                    return;
                }

                Condition = "Значение получено";
                Stopwatch.Stop();
                
                PrintCondition(x, threadNumber);
                // Thread.Sleep(new Random().Next(300, 1000));
                waitHandler.Set();
            }
        }

        private void PrintCondition(double x, int threadNumber)
        {
            Console.WriteLine($"{$"  {threadNumber}) ", 6}" +
                              $"{$"{x:F10}".TrimEnd('0').TrimEnd('.'), 10} | {$"{Math.Atan(x):F10}", 12} | " +
                              $"{$"{Result:F10}", 12} | " +
                              $"{$"{I}", 10} | " +
                              $"{$"{Condition}", 20} | {$"{Stopwatch.Elapsed}", 8}");
        }

        private void UpdateDataForNextStep(ref StepData stepData, double x)
        {
            stepData.Top *= x * x;
            stepData.Under += 2;
            stepData.Mark = !stepData.Mark;
        }

        private double CalculateCurrent(StepData stepData)
        {
            return stepData.Mark ? stepData.Top / stepData.Under : - stepData.Top / stepData.Under;
        }

        public static void CalculateValue()
        {
            throw new NotImplementedException();
        }
    }
}