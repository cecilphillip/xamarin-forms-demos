using System.Collections.Generic;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Services
{
    public interface IIncidentService
    {
        void CreateIncident (Incident incident);

        void UpdateIncident (Incident incident);

        IEnumerable<Incident> RetrieveIncidents ();

        void RemoveIncident (Incident incident);

        Incident RetrieveIncident (int id);
    }
}
	