using System;

namespace Lab_4
{
    static class Program
    {
        static void Main()
        {
            try
            {
                var journal = new Journal();
                var temp1 = new TrainCollection("Test1");
                var temp2 = new TrainCollection("Test2");
                temp1.AddDefaults();
                temp2.AddDefaults();

                // Console.WriteLine(temp1.ToString());
                
                temp1.Add(new Train(new Tuple<string, string, short>("NX", "1 2 3", 5)));
                temp1.Add(new Train(new Tuple<string, string, short>("NY", "1 2 4", 6)));
                temp1.Add(new Train(new Tuple<string, string, short>("NZ", "1 2 5", 7)));
                temp1.Add(new Train(new Tuple<string, string, short>("NA", "3 2 1", 8)));

                temp1.Remove(6);
                temp1.Remove(7);

                Console.WriteLine(temp1[1]);

                temp1[1] = new Train(new Tuple<string, string, short>("AB", "3 3 3", 1));
                temp1[3] = new Train(new Tuple<string, string, short>("AC", "3 3 3", 3));

                Console.WriteLine(temp1[20]);

                Console.WriteLine(journal.ToString());

                Journal.Sort(1);
                
                Console.WriteLine("----------------\n\n" + journal);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
