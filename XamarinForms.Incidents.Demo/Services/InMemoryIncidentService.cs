using System.Linq;
using System.Collections.Generic;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Services
{
    public class InMemoryIncidentService : IIncidentService
    {
        private List<Incident> _incidents = new List<Incident> ();

        public InMemoryIncidentService ()
        {

        }

        public InMemoryIncidentService (IEnumerable<Incident> incidents)
        {
            this._incidents.AddRange (incidents);
        }

        public virtual void CreateIncident (Incident incident)
        {
            incident.ID = _incidents.Count; 
            _incidents.Add (incident);
        }

        public virtual void UpdateIncident (Incident incident)
        {
            var itemToUpdate = _incidents.Where (i => i.ID == incident.ID).Single ();
            itemToUpdate.Location = incident.Location;
            itemToUpdate.Status = incident.Status;
            itemToUpdate.Title = incident.Title;
        }

        public virtual void RemoveIncident (Incident incident)
        {
            var itemToRemove = _incidents.Where (i => i.ID == incident.ID).Single ();
            _incidents.Remove (itemToRemove);
        }

        public virtual IEnumerable<Incident> RetrieveIncidents ()
        {
            return _incidents;
        }

        public virtual Incident RetrieveIncident (int id)
        {
            return _incidents.SingleOrDefault (i => i.ID == id);
        }
    }
    
}
