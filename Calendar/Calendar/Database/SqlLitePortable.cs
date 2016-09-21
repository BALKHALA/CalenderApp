using SQLite;
using Xamarin.Forms;

namespace Calendar
{

    public class SqlLitePortable
    {
        private static SQLiteConnection _connection = null;
        private static readonly object padlock = new object();
        SqlLitePortable()
        {

        }

        public static SQLiteConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_connection == null)
                    {
                        _connection = DependencyService.Get<ISqlLite>().GetConnection();
                    }
                    return _connection;
                }
            }
        }
    }
}
