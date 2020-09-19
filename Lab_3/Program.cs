using System;
using System.Collections.Generic;

namespace Lab_3
{
    internal static class Program
    {
        
        private static List<Train> Array { get; set; }

        static void Main()
        {

            Array = new List<Train>
            {
                new Train(new Tuple<string, string, short>("temp3",
                    "temp3", 3)),
                new Train(new Tuple<string, string, short>("temp1",
                    "temp2", 2)),
                new Train(new Tuple<string, string, short>("temp2",
                    "temp1", 1))
            };


            while (true)
            {
                Console.Write("Choose an option:\n1) Show an array\n2) Add an element\n" +
                              "3) Show an element by property \"Id\"\n4) Sort list\n0) Exit\n\n");

                var option = 0;
                try
                {
                    option = int.Parse(Console.ReadLine()!);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }

                switch (option)
               {
                   case 1:
                       Console.Write("Created arrays: \n");
                       foreach (var item in Array)
                       {
                           Console.WriteLine($"{Array.IndexOf(item) + 1}) {item.ToString()}");
                       }
                       Console.WriteLine();
                       break;
                   case 2:
                       Console.Write("Enter a train destination: ");
                       var tempDestination = Console.ReadLine();
                       Console.Write("Enter a train departure time: ");
                       var tempDepartureTime = Console.ReadLine();
                       Console.Write("Enter a train id: ");
                       var tempTrainId = Convert.ToInt16(Console.ReadLine());
                       try
                       {
                           lock (Array)
                           {
                               Array.Add(new Train(new Tuple<string, string, short>(tempDestination, 
                                   tempDepartureTime, tempTrainId)));
                           }
                       }
                       catch (Exception e)
                       {
                           Console.Error.WriteLine(e.Message);
                       }
                       break;
                   case 3:
                       Console.Write("Enter a train id: ");
                       
                       var inputTrainId = Convert.ToInt16(Console.ReadLine());
                       var flag = true;
                       
                       foreach (var train in Array)
                       {
                           if (train.GetTrainInTuple().Item3.Equals(inputTrainId))
                           {
                               Console.Write(train.ToString());
                               flag = false;
                           }
                       }

                       if (flag)
                       {
                           Console.Write("Specified ID not found!\n\n");
                       }
                       break;
                   case 4:
                       try
                       {
                           Console.Write("Choose an option:\n1) Compare by Destination\n2) Compare by DepartureTime\n" +
                                         "3) Compare by TrainId\n4) Compare by IComparable interface\n\n");
                           
                           var sortOption = int.Parse(Console.ReadLine()!);
                           switch (sortOption)
                           {
                               case 1:
                                   Array.Sort(Train.CompareByDestination);
                                   break;
                               case 2:
                                   Array.Sort(Train.CompareByDepartureTime);
                                   break;
                               case 3:
                                   Array.Sort(Train.CompareByTrainId);
                                   break;
                               case 4:
                                   Array.Sort();
                                   break;
                               default:
                                   continue;
                           }
                       }
                       catch (Exception e)
                       {
                           Console.WriteLine(e.Message);
                       }
                       break;
                   case 0:
                       return;
               }
            }
        }
    }
}
