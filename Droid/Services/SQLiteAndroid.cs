using System;
using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Droid.Services;
using SQLite.Net;
using System.IO;
using XamarinForms.Incidents.Demo.Services;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net.Async;

[assembly: Dependency (typeof(SQLiteAndroid))]

namespace XamarinForms.Incidents.Demo.Droid.Services
{
	public class SQLiteAndroid : ISQLite
	{
		public SQLiteAndroid ()
		{
		}

		public SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "IncidentsSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, sqliteFilename);

			var platform = new SQLitePlatformAndroid ();
            var sqLiteConnectionString = new SQLiteConnectionString(path, false);

            var conn = new SQLiteConnectionWithLock (platform, sqLiteConnectionString);           
			return conn;
		}

		public SQLiteAsyncConnection GetAsyncConnection ()
		{
			var sqliteFilename = "IncidentsSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, sqliteFilename);

			var platform = new SQLitePlatformAndroid ();
			var sqLiteConnectionString = new SQLiteConnectionString(path, false);

			var conn = new SQLiteConnectionWithLock (platform, sqLiteConnectionString);
			var connAsync = new SQLiteAsyncConnection (() => conn);
			return connAsync;
		}
	}
}

