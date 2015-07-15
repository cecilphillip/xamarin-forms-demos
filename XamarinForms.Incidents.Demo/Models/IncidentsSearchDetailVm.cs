using System.Collections.ObjectModel;
using XamarinForms.Incidents.Demo.Services;
using System.Linq;
using System;

namespace XamarinForms.Incidents.Demo.Models
{
    public class IncidentsSearchDetailVm:BaseViewModel
    {
        IIncidentService service;

        public ObservableCollection<Incident> Incidents { get; protected set; }

        public IncidentsSearchDetailVm() : this (new SQLiteIncidentService())
        {          
        }

        public IncidentsSearchDetailVm(IIncidentService svc)
        {
            Title = "Search Incidents"; 
            service = svc;

            Incidents = new ObservableCollection<Incident>(service.RetrieveIncidents ());
        }

        public void SearchIncidents(string text = "")
        {
            Incidents.Clear ();
            if(string.IsNullOrEmpty (text))
                service.RetrieveIncidents ().ForEach ((incident, index) => Incidents.Add (incident));
            else
                service.RetrieveIncidents ()
                          .Where (i => i.Title.Contains (text, StringComparison.CurrentCultureIgnoreCase))
                          .ForEach ((incident, index) => Incidents.Add (incident));  
        }
    }

}
