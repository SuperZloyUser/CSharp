using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
 public class TrainCollection : IEnumerable<Train>
 {
        private readonly List<Train> _trainList = new List<Train>();
        
        private string Name { get; set; }

        public TrainCollection(string name)
        {
            Name = name;
        }

        public Train this[string pos]
        {
            get
            {
                return _trainList.FirstOrDefault(train => train.Id.Equals(pos));
            }
        }

        public bool Add(Train record)
        {
            if (_trainList.Any(train => train.Id.Equals(record.Id)))
            {
                return false;
            }
            _trainList.Add(record);
            return true;
        }

        public bool Remove(string currentId)
        {
            foreach (var train in _trainList.Where(train => train.Id.Equals(currentId)))
            {
                _trainList.Remove(train);
                return true;
            }
            return false;
        }

        public bool AddDefaults()
        {
            return Add(new Train("Number-1", 50, new[] {1, 2, 3, 4, 5})) &&
                   Add(new Train("Number-2", 2, new[] {2, 2, 2, 2, 2})) &&
                   Add(new Train("Number-3", 1, new[] {5, 4, 3, 2, 1})) &&
                   Add(new Train("Number-4", 2, new[] {1, 1, 1, 1, 1})) &&
                   Add(new Train("Number-5", 3, new[] {1, 2, 3, 2, 1})) &&
                   Add(new Train("Number-6", 4, new[] {1, 2, 3, 2, 1})) &&
                   Add(new Train("Number-7", 4, new[] {1, 2, 3, 2, 1})) &&
                   Add(new Train("Number-8", 3, new[] {1, 2, 3, 2, 1})) &&
                   Add(new Train("Number-9", 2, new[] {1, 2, 3, 2, 1})) &&
                   Add(new Train("Number-10", 1, new[] {5, 5, 5, 5, 5}));
        }

        public override string ToString()
        {
            return _trainList.Aggregate($"\"{Name}\" Train collection content:\n", 
                (current, train) => current + (train + "\n"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _trainList.GetEnumerator();
        }
     
        public IEnumerator<Train> GetEnumerator()
        {
            return _trainList.GetEnumerator();
        }
        
    }
}
