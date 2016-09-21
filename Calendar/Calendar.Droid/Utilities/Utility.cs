using System.IO;

namespace Calendar.Droid
{
    public static class Utility
    {
        public static string DatabaseLocation
        {
            get
            {
                var sqliteFilename = "CalendarSqlLiteDb.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                return Path.Combine(documentsPath, sqliteFilename);
            }
        }
    }
}