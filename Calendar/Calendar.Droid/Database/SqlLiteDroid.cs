using Calendar.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteDroid))]
namespace Calendar.Droid
{
    public class SqlLiteDroid : ISqlLite
    {
        public SQLiteConnection GetConnection()
        {
            return new SQLite.SQLiteConnection(Utility.DatabaseLocation);
        }
    }
}