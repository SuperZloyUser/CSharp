using System;

namespace Lab_4
{
    public class JournalEntry 
    {
        public string CollectionName { get; set; }
        public DateTime Time { get; set; }
        public string ChangeType { get; set; }
        public string ChangeInfo { get; set; }
        public Train Entry { get; set; }

        public JournalEntry(string collectionName, string changeType, string changeInfo, Train entry)
        {
            CollectionName = collectionName;
            Time = DateTime.Now;
            ChangeType = changeType;
            ChangeInfo = changeInfo;
            Entry = entry;
        }

        public override string ToString()
        {
            return $"1) Collection Name: \"{CollectionName}\"\n2) Change time: {Time}\n3)" +
                   $" Change type: {ChangeType}\n4) Change info: {ChangeInfo}\nEntry info: {{" + 
                   Entry.ToString() + "}";
        }
        
        public static int CompareByCollectionName(JournalEntry entry1, JournalEntry entry2)
        {
            return string.CompareOrdinal(entry1.CollectionName, entry2.CollectionName);
        }
        
        public static int CompareByTime(JournalEntry entry1, JournalEntry entry2)
        {
            return DateTime.Compare(entry1.Time, entry2.Time);
        }

        public static int CompareByChangeType(JournalEntry entry1, JournalEntry entry2)
        {
            return string.CompareOrdinal(entry1.ChangeType, entry2.ChangeType);
        }
        
        public static int CompareByChangeInfo(JournalEntry entry1, JournalEntry entry2)
        {
            return string.CompareOrdinal(entry1.ChangeInfo, entry2.ChangeInfo);
        }
        
    }
}
