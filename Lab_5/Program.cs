using System;

namespace Lab_5
{
    class Program
    {
        static void Main()
        {
            var trainCollection = new TrainCollection("newTCollect");
            var stationCollection = new StationCollection("newSCollect");
            trainCollection.AddDefaults();
            stationCollection.AddDefaults();
            
            Console.WriteLine(stationCollection);
            Console.WriteLine(trainCollection["Number-1"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-9"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-10"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-0"]?.AverageTripCount());
        }
    }
}
