using System.Collections.ObjectModel;
using XamarinForms.Incidents.Demo.Services;
using Xamarin.Forms;
using System.Linq;
using System;

namespace XamarinForms.Incidents.Demo.Models
{
    public class IncidentsEditDetailVM:BaseViewModel
    {
        IIncidentService service;
        Incident model;

        public const string ModelPropertyName = "Model";

        public Incident Model {
            get { return model; }
            set { SetProperty (ref model, value, ModelPropertyName); }
        }


        bool isVisible;
        public const string IsVisiblePropertyName = "IsVisible";

        public bool IsVisible {
            get { return isVisible; }
            set { SetProperty (ref isVisible, value, IsVisiblePropertyName); }
        }

        public IncidentsEditDetailVM() : this (null, new SQLiteIncidentService())
        {          
        }

        public IncidentsEditDetailVM(Incident incident) : this (incident, new SQLiteIncidentService())
        {          
        }

        public IncidentsEditDetailVM(Incident incident, IIncidentService svc)
        {
            Title = "Incident Information"; 
            service = svc;
            IsVisible = incident != null;
            Model = incident?? new Incident();
         }  

        public void SaveIncident() {
            service.UpdateIncident (model);

            MessagingCenter.Send<IncidentsEditDetailVM> (this, "incident-updated");
        }

        public void ResetModel() {
            Model = new Incident();
        }
    }
}
