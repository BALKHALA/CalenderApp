using System.Collections.Generic;

namespace Calendar
{
    public interface IEventDb
    {
        IEnumerable<CalendarEvents> GetAll();

        CalendarEvents Get(int id);

        int Delete(int id);

        int Insert(CalendarEvents entity);
    }
}