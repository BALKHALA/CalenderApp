using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public class EventsDb : IEventDb
    {
        private static EventsDb _instance = null;

        private static readonly object padlock = new object();

        private readonly SQLite.SQLiteConnection _connection;

        public int Delete(int id)
        {
            return _connection.Delete<CalendarEvents>(id);
        }

        public CalendarEvents Get(int id)
        {
            return _connection.Table<CalendarEvents>().FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<CalendarEvents> GetEventsByDate(string date)
        {
            return _connection.Table<CalendarEvents>().Where(a => a.Date.Equals(date));
        }

        public IEnumerable<CalendarEvents> GetSearchData(string query)
        {
            return _connection.Table<CalendarEvents>().Where(a => a.Title.Contains(query));
        }

        public IEnumerable<CalendarEvents> GetAll()
        {
            return (from i in _connection.Table<CalendarEvents>() select i);
        }

        public int Insert(CalendarEvents entity)
        {
            return _connection.Insert(entity);
        }

        public EventsDb()
        {
            _connection = SqlLitePortable.Instance;
            _connection.CreateTable<CalendarEvents>();
            _connection.CreateTable<Config>();
        }

        public static EventsDb Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new EventsDb();
                    }
                    return _instance;
                }
            }
        }
    }
}
