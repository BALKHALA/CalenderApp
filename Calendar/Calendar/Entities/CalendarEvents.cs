using SQLite;

namespace Calendar
{
    public class CalendarEvents
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string RowColor { get; set; }
    }
}
