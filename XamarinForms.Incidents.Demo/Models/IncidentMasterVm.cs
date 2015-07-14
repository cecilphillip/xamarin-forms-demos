using System;
using System.Collections.ObjectModel;


namespace XamarinForms.Incidents.Demo
{
    public class IncidentMasterVm : BaseViewModel
    {
        public ObservableCollection<MasterNavItem> NavItems { get; protected set; }

        public IncidentMasterVm ()
        {
            Title = "Hanselman"; 
            NavItems = new ObservableCollection<MasterNavItem> () {
                new MasterNavItem{ Id = 0, Title = "Incidents", CacheKey = "IncidentsPage" },
                new MasterNavItem{ Id = 2, Title = "New Incident", CacheKey = "NewIncidentPage" },
                new MasterNavItem{ Id = 1, Title = "About", CacheKey = "AboutPage" },
            };   
        }
    }
}


