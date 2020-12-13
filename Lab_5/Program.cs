using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    static class Program
    {
        static void Main()
        {
            var trainCollection = new TrainCollection("newTCollect");
            var stationCollection = new StationCollection("newSCollect");
            trainCollection.AddDefaults();
            stationCollection.AddDefaults();
            
            Console.WriteLine(stationCollection);
            Console.WriteLine(trainCollection);
            Console.WriteLine(trainCollection["Number-1"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-9"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-10"]?.AverageTripCount());
            Console.WriteLine(trainCollection["Number-0"]?.AverageTripCount());

            
            var firstJoin = from t in trainCollection
                join s in stationCollection on t.StationId equals s.Number 
                select new
                {
                    trainId = t.Id, weekInfo = t.WeekInfo, stationId = t.StationId,
                    stationName = s.Name, trainStation = t.StationId
                };

            foreach (var one in firstJoin)
            {
                Console.WriteLine($"\"{one.trainId}\" - " +
                                  $"{one.weekInfo.Aggregate("|", (cur, w) => cur + " " + w)} |" +
                                  $" - {one.trainStation} : {one.stationName} - {one.stationId}");    
            }
            
            var secondJoin = from s in stationCollection
                join t in trainCollection on s.Number equals t.StationId 
                select new
                {
                    stationName = s.Name, stationId = s.Number,
                    trainId = t.Id, weekInfo = t.WeekInfo, trainStation = t.StationId
                };

            foreach (var one in secondJoin)
            {
                Console.WriteLine($"{one.stationName} - {one.stationId} : {one.trainStation} - \"{one.trainId}\" - " +
                                  $"{one.weekInfo.Aggregate("|", (cur, w) => cur + " " + w)} |");    
            }

            var groupBy = stationCollection
                .GroupJoin(
                    trainCollection,
                    s => s.Number,
                    t => t.StationId,
                    (station, res) =>
                    {
                        IEnumerable<Train> enumerable = res.ToList();
                        return new
                        {
                            stationName = station.Name, stationId = station.Number,
                            train = enumerable.Select(t => t)
                                .OrderBy(t => t.AverageTripCount())
                        };
                    });
            
            foreach (var station in groupBy)
            {
                Console.WriteLine($"{station.stationName}:");
                foreach (var prop in station.train)
                {
                    Console.WriteLine($"{prop.Id}) Station ID: {prop.StationId} - Average Trips: {prop.AverageTripCount()}; " +
                                      $"{prop.WeekInfo.Aggregate("|", (cur, w) => cur + " " + w)} |");
                }
                Console.WriteLine();
            }
        }
    }
}
