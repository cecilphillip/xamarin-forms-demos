using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Services;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
    public partial class SearchNavigationPage : ContentPage
    {
        IIncidentService service;

        public SearchNavigationPage ()
        {
            InitializeComponent ();

            service = new InMemoryIncidentService (Constants.Incidents);

            // wire up incidents SearchBar
            incidentsSb.TextChanged += (sender, e) => {
                if (!string.IsNullOrEmpty (incidentsSb.Text))
                    incidentsLv.ItemsSource = SearchIncidents (incidentsSb.Text);
                else
                    incidentsLv.ItemsSource = service.RetrieveIncidents ();
            };

            incidentsSb.SearchButtonPressed += (sender, e) => {
                if (!string.IsNullOrEmpty (incidentsSb.Text))
                    incidentsLv.ItemsSource = SearchIncidents (incidentsSb.Text);
                else
                    incidentsLv.ItemsSource = service.RetrieveIncidents ();
            };

            // wire up incidents ListView
            incidentsLv.ItemsSource = service.RetrieveIncidents ();

            incidentsLv.ItemSelected += async (sender, e) => {
                if (e.SelectedItem != null)
                    await Navigation.PushAsync (new IncidentsPage (e.SelectedItem as Incident)); 

                incidentsLv.SelectedItem = null;  
            };
        }

        IEnumerable<Incident> SearchIncidents (string text)
        {
            return service.RetrieveIncidents ().Where (i => i.Title.Contains (text, StringComparison.CurrentCultureIgnoreCase));
        }
            
    }
}

