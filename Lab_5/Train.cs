using System.Linq;

namespace Lab_5
{
    public class Train
    {
        public string Id { get; set; }
        public int StationId { get; set; }
        public int[] WeekInfo { get; set; }

        public Train(string id, int stationId, int[] weekInfo)
        {
            Id = id;
            StationId = stationId;
            WeekInfo = weekInfo;
        }

        public override string ToString()
        {
            var result = $"Train ID: \"{Id}\", Station ID: {StationId}, Week info: ";

            foreach (var day in WeekInfo)
            {
                result += day + " ";
            }
            
            return result;
        }
    }
}
