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
            return AddColorToRow(_connection.Table<CalendarEvents>().Where(a => a.Date.Equals(date)).ToList());
        }

        public IEnumerable<CalendarEvents> GetSearchData(string query)
        {
            return AddColorToRow(_connection.Table<CalendarEvents>().Where(a => a.Title.Contains(query)).ToList());
        }

        public IEnumerable<CalendarEvents> GetAll()
        {
            return AddColorToRow((from i in _connection.Table<CalendarEvents>() select i).ToList());
        }

        private List<CalendarEvents> AddColorToRow(List<CalendarEvents> calendarEventsList)
        {
            for (int i = 0; i < calendarEventsList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    calendarEventsList[i].RowColor = "#f44336";
                }
            }
            return calendarEventsList;
        }

        public int Insert(CalendarEvents entity)
        {
            return _connection.Insert(entity);
        }

        public int Update(CalendarEvents entity)
        {
            return _connection.Update(entity);
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
