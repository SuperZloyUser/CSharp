using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4
{
    public class TrainCollection
    {
        private readonly List<Train> _trainList = new List<Train>();

        private string Name { get; set; }
        
        private delegate void TrainCollectionHandler(string trainCollectionName, string changeType, string message, ref Train record);
        private event TrainCollectionHandler OnTrainCollectionCountChanged;
        private event TrainCollectionHandler OnTrainReferenceChanged;
        
        public TrainCollection(string name)
        {
            Name = name;
            OnTrainCollectionCountChanged += Journal.TrainCountChanged;
            OnTrainReferenceChanged += Journal.TrainReferenceChanged;
        }
        
        public Train this[int pos] 
        {
            get
            {
                return _trainList.FirstOrDefault(train => train.GetTrainInTuple().Item3 == pos);
            }
            set
            {
                var flag = false;
                foreach (var train in _trainList.Where(train =>
                    train.GetTrainInTuple().Item3 == value.GetTrainInTuple().Item3))
                {
                    _trainList.Remove(train);
                    flag = true;
                    break;
                }

                _trainList.Add(value);
                if (flag)
                    OnTrainReferenceChanged?.Invoke(Name, "Update", "Record was updated successfully!", ref value);
            }
        }

        public bool Add(Train record)
        {
            if (_trainList.Any(train => train.GetTrainInTuple().Item3 == record.GetTrainInTuple().Item3))
            {
                return false;
            }
            
            _trainList.Add(record);
            OnTrainCollectionCountChanged?.Invoke(Name, "Add","Record was added successfully!", ref record);
            
            return true;
        }

        public bool Remove(int pos)
        {
            foreach (var train in _trainList.Where(train => train.GetTrainInTuple().Item3 == pos))
            {
                _trainList.Remove(train);
                var tempTrain = train;
                OnTrainCollectionCountChanged?.Invoke(Name, "Remove", "Record was removed successfully!", ref tempTrain);
                return true;
            }

            return false;
        }

        public bool AddDefaults()
        {
            return Add(new Train(new Tuple<string, string, short>("temp3", "temp3", 3))) && 
                   Add(new Train(new Tuple<string, string, short>("temp1", "temp2", 2))) && 
                   Add(new Train(new Tuple<string, string, short>("temp2", "temp1", 1)));
        }

        public override string ToString()
        {
            return _trainList.Aggregate($"\"{Name}\" collection content:\n", (current, train) => current + (train.ToString() + "\n"));
        }
    }
}