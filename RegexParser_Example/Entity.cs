using System;

namespace RegexParser_Example
{
    public class Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public double Number { get; set; }

        public override string ToString() 
            => $"{nameof(FirstName)}: {FirstName}\n" +
                $"{nameof(LastName)}: {LastName}\n" +
                $"{nameof(Date)}: {Date.ToString()}\n" +
                $"{nameof(Number)}: {Number}\n";
    }
}