using SQLite;

namespace Calendar
{
    public class Config
    {
        [PrimaryKey]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}