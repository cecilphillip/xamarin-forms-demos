using System.Linq;
using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Models;
using System.Collections.Generic;
using System;

namespace XamarinForms.Incidents.Demo.Services
{
    public class SQLiteIncidentService: IIncidentService
    {
        ISQLite localdb;

        public SQLiteIncidentService()
        {
            localdb = DependencyService.Get<ISQLite> ();
            using(var conn = localdb.GetConnection ()) {
                conn.CreateTable<Incident> ();
            }
        }

        public void CreateIncident(Incident incident)
        {
            using(var conn = localdb.GetConnection ()) {
                conn.Insert (incident);
            }
        }

        public void UpdateIncident(Incident incident)
        {
            using(var conn = localdb.GetConnection ()) {
                if(incident.ID == 0) {
                    incident.Status = "Open";
                    incident.DateOccurred = DateTime.Now;
                    conn.Insert (incident);
                }
                else
                    conn.Update (incident);
            }
        }

        public IEnumerable<Incident> RetrieveIncidents()
        {
            using(var conn = localdb.GetConnection ()) {
                return conn.Table<Incident> ().ToList ();
            }
        }

        public void RemoveIncident(Incident incident)
        {
            using(var conn = localdb.GetConnection ()) {
                conn.Delete<Incident> (incident);
            }
        }

        public Incident RetrieveIncident(int id)
        {
            using(var conn = localdb.GetConnection ()) {
                return conn.Table<Incident> ().FirstOrDefault (i => i.ID == id);
            }
        }
    }
}
