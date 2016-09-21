using System.Collections.Generic;
using Android.Util;

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