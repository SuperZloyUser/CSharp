namespace Lab_5
{
    public class Station
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Station(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Station name: \"{Name}\", Station number: {Number}";
        }
    }
}
