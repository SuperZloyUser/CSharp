using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    public class StationCollection : IEnumerable<Station>
    {
        private readonly List<Station> _stationList = new List<Station>();

        private string Name { get; set; }

        public StationCollection(string name)
        {
            Name = name;
        }

        public bool Add(Station record)
        {
            if (_stationList.Any(currentStation => currentStation.Number == record.Number))
            {
                return false;
            }
            _stationList.Add(record);
            return true;
        }

        public bool Remove(int currentId)
        {
            foreach (var station in _stationList.Where(currentStation => 
                currentStation.Number == currentId))
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

        public IEnumerator<Station> GetEnumerator()
        {
            return _stationList.GetEnumerator();
        }

        public override string ToString()
        {
            return _stationList.Aggregate($"\"{Name}\" station collection content:\n", 
                (current, train) => current + (train + "\n"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stationList.GetEnumerator();
        }
    }
}