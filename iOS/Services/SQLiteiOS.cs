using System;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System.IO;
using XamarinForms.Incidents.Demo.Services;
using SQLite.Net.Async;
using Xamarin.Forms;
using XamarinForms.Incidents.Demo.iOS.Services;

[assembly: Dependency (typeof (SQLiteiOS))]

namespace XamarinForms.Incidents.Demo.iOS.Services
{
	public class SQLiteiOS: ISQLite
	{
		public SQLiteiOS ()
		{
		}

		public  SQLiteConnection GetConnection ()
		{			
			var sqliteFilename = "IncidentsSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine (libraryPath, sqliteFilename);


			var platform = new SQLitePlatformIOS ();
            var sqLiteConnectionString = new SQLiteConnectionString(path, false);

            var conn = new SQLiteConnectionWithLock (platform, sqLiteConnectionString);
			return conn;
		}

		public SQLiteAsyncConnection GetAsyncConnection ()
		{
			var sqliteFilename = "IncidentsSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine (libraryPath, sqliteFilename);

			var platform = new SQLitePlatformIOS ();
			var sqLiteConnectionString = new SQLiteConnectionString(path, false);

			var conn = new SQLiteConnectionWithLock (platform, sqLiteConnectionString);
			var connAsync = new SQLiteAsyncConnection (() => conn);
			return connAsync;
		}
	}
}

