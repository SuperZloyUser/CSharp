using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    public class StationCollection
    {
        private readonly List<Station> _stationList = new List<Station>();

        private string Name { get; set; }

        public StationCollection(string name)
        {
            Name = name;
        }

        public bool Add(Station record)
        {
            if (_stationList.Any(train => train.Number == record.Number))
            {
                return false;
            }
            _stationList.Add(record);
            return true;
        }

        public bool Remove(int currentId)
        {
            foreach (var station in _stationList.Where(train => train.Number == currentId))
            {
                _stationList.Remove(station);
                return true;
            }
            return false;
        }

        public bool AddDefaults()
        {
            return Add(new Station("Station-1", 1)) && 
                   Add(new Station("Station-2", 2)) &&
                   Add(new Station("Station-3", 3)) &&
                   Add(new Station("Station-4", 4)) &&
                   Add(new Station("Station-50", 50));
        }

        public override string ToString()
        {
            return _stationList.Aggregate($"\"{Name}\" station collection content:\n", 
                (current, train) => current + (train.ToString() + "\n"));
        }
    }
}