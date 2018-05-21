
namespace LinqProj
{
    public class Person
    {
        public int Id;
        public int Year;
        public int Month;
        public int Duration;

        public Person()
        {
            Id = 0;
            Year = 0;
            Month = 0;
            Duration = 0;
        }
            

        public Person(int id, int year, int month, int duration)
        {
            Id = id;
            Year = year;
            Month = month;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Year: {Year}; Month: {Month}; Duration: {Duration}";
        }
    }
}