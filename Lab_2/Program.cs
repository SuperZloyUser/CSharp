using System;
using System.Collections.Generic;

namespace Lab_2
{
    class Program
    {
        private static List<ContainingArray> Series { get; set; }

        static void Main()
        {
            
            Series = new List<ContainingArray>();

            while (true)
            {
               try
               {
                   if (Series.Count > 0)
                   {
                       Console.Write("Created arrays: \n");
                       foreach (var item in Series)
                       {
                           Console.Write($"{Series.IndexOf(item) + 1}) ");
                           foreach (var value in item.SeriesArray)
                           {
                               Console.Write($"{value} ");                               
                           }
                           Console.WriteLine();
                       }
                   }

                   Console.Write("Choose an option:\n1) Allocate memory\n2) Generate a series\n" +
                                 "3) Special property\n4) Special method\n0) Exit\n\n");
                   var option = int.Parse(Console.ReadLine()!);

                   switch (option)
                   {
                       case 1:
                           Console.Write("Enter an array size: ");
                           var tempSize = int.Parse(Console.ReadLine()!);
                           Series.Add(new ContainingArray(tempSize));
                           break;
                       case 2:
                           Console.Write("Enter an array size: ");
                           tempSize = int.Parse(Console.ReadLine()!);
                           Console.Write("Enter a SinH value: ");
                           var tempX = double.Parse(Console.ReadLine()!);
                           Series.Add(new ContainingArray(tempSize, tempX));
                           break;
                       case 3:
                           Console.Write("Enter an array number: ");
                           tempSize = int.Parse(Console.ReadLine()!);
                           var counter = 0;
                           ContainingArray currentEl = null;
                           foreach (var item in Series)
                           {
                               if (counter < tempSize - 1)
                                   counter++;
                               else
                               {
                                   currentEl = item;
                                   break;
                               }
                           }
                           Console.WriteLine(currentEl.GetSum);
                           break;
                       case 4:
                           Console.Write("Enter an array number: ");
                           tempSize = int.Parse(Console.ReadLine()!);
                           counter = 0;
                           currentEl = null;
                           foreach (var item in Series)
                           {
                               if (counter < tempSize - 1)
                                   counter++;
                               else
                               {
                                   currentEl = item;
                                   break;
                               }
                           }
                           Console.WriteLine(currentEl.CalculateSpecialSum());
                           break;
                       case 0:
                           return;
                   }
               }
               catch (Exception e)
               {
                   Console.Error.WriteLine(e.Message);
               }
            }
        }
    }
}
