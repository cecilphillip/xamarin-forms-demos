using SQLite.Net;
using SQLite.Net.Async;

namespace XamarinForms.Incidents.Demo.Services
{
	public interface ISQLite {
		SQLiteConnection GetConnection();
		SQLiteAsyncConnection GetAsyncConnection();
	}
}
