using System;

namespace Lab_1
{
    public static class TaylorSeriesArccotangent
    {
        
        private const int MaxN = 100000;
        private static double Result { get; set; }
        public static string Condition { get; private set; }
        public static int I { get; private set; }

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

        public static double CalculateValue(double x, double precision)
        {
            Result = 0d;
            var stepData = new StepData(x, 1d, true);
            I = 0;

            if (Math.Abs(x) >= 1)
            {
                Condition = "Неверное значение x!";
                return Result;
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
                return 0d;
            }

            Condition = "Значение получено";
            return Result;
        }

        private static void UpdateDataForNextStep(ref StepData stepData, double x)
        {
            stepData.Top *= x * x;
            stepData.Under += 2;
            stepData.Mark = !stepData.Mark;
        }

        private static double CalculateCurrent(StepData stepData)
        {
            return stepData.Mark ? stepData.Top / stepData.Under : - stepData.Top / stepData.Under;
        }
        
    }
}