using System;

namespace Lab_4
{
    public readonly struct Train : IComparable
    {
        private string Destination { get; }
        private string DepartureTime { get; }
        private short TrainId { get; }

        public Train(Tuple<string, string, short> args)
        {
            var (item1, item2, item3) = args;
            Destination = item1;
            DepartureTime = item2;
            TrainId = item3;
        }

        public Tuple<string, string, short> GetTrainInTuple()
        {
            return new Tuple<string, string, short>(Destination, DepartureTime, TrainId);
        }

        public override string ToString()
        {
            return $"Destination: \"{Destination}\", DepartureTime: " +
                   $"\"{DepartureTime}\", TrainId: \"{TrainId}\"";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            
            if (obj is Train temp)
            {
                var (tempDestination, tempDepartureTime, tempTrainId) = temp.GetTrainInTuple();

                if (TrainId.CompareTo(tempTrainId) != 0) return TrainId.CompareTo(tempTrainId);
                
                if (string.Compare(Destination, tempDestination, StringComparison.Ordinal) != 0)
                    return string.Compare(Destination, tempDestination, StringComparison.Ordinal);
                
                if (string.Compare(DepartureTime, tempDepartureTime, StringComparison.Ordinal) != 0)
                    return string.Compare(DepartureTime, tempDepartureTime, StringComparison.Ordinal);
            }
            else
                throw new ArgumentException("Object is not a Train");

            return 0;
        }

        public static int CompareByDestination(Train train1, Train train2)
        {
            return string.CompareOrdinal(train1.GetTrainInTuple().Item1, train2.GetTrainInTuple().Item1);
        }
        
        public static int CompareByDepartureTime(Train train1, Train train2)
        {
            return string.CompareOrdinal(train1.GetTrainInTuple().Item2, train2.GetTrainInTuple().Item2);
        }

        public static int CompareByTrainId(Train train1, Train train2)
        {
            return train1.GetTrainInTuple().Item3.CompareTo(train2.GetTrainInTuple().Item3);
        }
        
    }
}
