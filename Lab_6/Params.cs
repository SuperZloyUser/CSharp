using System.Threading;

namespace Lab_6
{
    public class Params
    {
        public double X { get; }
        public double Precision { get; }
        public int ThreadNumber { get; }
        public AutoResetEvent WaitHandler { get; }

        public Params(double x, double precision, int threadNumber, ref AutoResetEvent waitHandler)
        {
            X = x;
            Precision = precision;
            ThreadNumber = threadNumber;
            WaitHandler = waitHandler;
        }
    }
}