using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.Incidents.Demo
{
    public partial class SearchXamlPage : ContentPage
    {
        IIncidentService service;

        public SearchXamlPage ()
        {
            InitializeComponent ();

            service = new InMemoryIncidentService (Constants.Incidents);
            BindingContext = service.RetrieveIncidents ();
        }

        protected void OnTextChanged (object sender, TextChangedEventArgs e)
        {             
            if (!string.IsNullOrEmpty (incidentsSB.Text))
                incidentsLV.ItemsSource = SearchIncidents (incidentsSB.Text);
            else
                incidentsLV.ItemsSource = service.RetrieveIncidents ();            
        }

        protected void OnSearchButtonPressed (object sender, EventArgs e)
        {           
            if (!string.IsNullOrEmpty (incidentsSB.Text))
                incidentsLV.ItemsSource = SearchIncidents (incidentsSB.Text);
            else
                incidentsLV.ItemsSource = service.RetrieveIncidents ();
        }

        protected IEnumerable<Incident> SearchIncidents (string text)
        {
            return service.RetrieveIncidents ().Where (i => i.Title.Contains (text, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

