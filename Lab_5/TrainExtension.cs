using System.Linq;

namespace Lab_5
{
    public static class TrainExtension
    {
        public static double AverageTripCount(this Train train)
        {
            return train.WeekInfo.Aggregate(0.0, (current, day) => current + day) / 5;
        }
    }
}