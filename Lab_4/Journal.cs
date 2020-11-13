using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4
{
    public class Journal
    {
        private static readonly List<JournalEntry> JournalEntries = new List<JournalEntry>();

        public static void TrainCountChanged(string trainCollectionName, string changeType,  string message, ref Train record)
        {
            JournalEntries.Add(new JournalEntry(trainCollectionName, changeType, message, record));
        }
        
        public static void TrainReferenceChanged(string trainCollectionName, string changeType,  string message, ref Train record)
        {
            JournalEntries.Add(new JournalEntry(trainCollectionName, changeType, message, record));
        }

        // public static void Sort(Func<JournalEntry, JournalEntry, int> comp)
        // {
        //     JournalEntries.Sort(comp);
        //     JournalEntries.Sort(JournalEntry.CompareByTime);
        // }
        public static void Sort(int value)
        {
            switch (value)
            {
                case 1:
                    JournalEntries.Sort(JournalEntry.CompareByCollectionName);
                    break;
                case 2:
                    JournalEntries.Sort(JournalEntry.CompareByTime);
                    break;
                case 3:
                    JournalEntries.Sort(JournalEntry.CompareByChangeType);
                    break;
                case 4:
                    JournalEntries.Sort(JournalEntry.CompareByChangeInfo);
                    break;
                default:
                    return;
            }
        }
        
        public override string ToString()
        {
            return JournalEntries.Aggregate("", (current, entry) => current + (entry.ToString() + "\n\n"));
        }
    }
}
    