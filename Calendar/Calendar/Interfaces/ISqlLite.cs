using SQLite;

namespace Calendar
{
    public interface ISqlLite
    {
        SQLiteConnection GetConnection();
    }
}
