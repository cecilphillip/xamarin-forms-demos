using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.Incidents.Demo
{
    public partial class SearchPageCustomTemplate : ContentPage
    {
        IIncidentService service;

        public SearchPageCustomTemplate ()
        {
            InitializeComponent ();

            service = new InMemoryIncidentService (Constants.Incidents);
            incidentsLV.ItemsSource = service.RetrieveIncidents ();

            searchBar.TextChanged += (sender, e) => {
                if (!string.IsNullOrEmpty (searchBar.Text))
                    incidentsLV.ItemsSource = SearchIncidents (searchBar.Text);
                else
                    incidentsLV.ItemsSource = service.RetrieveIncidents ();
            };

            searchBar.SearchButtonPressed += (sender, e) => {
                if (!string.IsNullOrEmpty (searchBar.Text))
                    incidentsLV.ItemsSource = SearchIncidents (searchBar.Text);
                else
                    incidentsLV.ItemsSource = service.RetrieveIncidents ();
            };
        }

        IEnumerable<Incident> SearchIncidents (string text)
        {
            return service.RetrieveIncidents ().Where (i => i.Title.Contains (text, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

