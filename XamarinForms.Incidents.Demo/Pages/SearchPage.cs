using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace XamarinForms.Incidents.Demo
{
    public class SearchPage : ContentPage
    {
        IIncidentService service;

        SearchBar searchbar;
        ListView listview;
        Label label;

        public SearchPage ()
        {
            Title = "Incidents";

            this.Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

            label = new Label { Text = "Incidents", HorizontalOptions = LayoutOptions.CenterAndExpand };
            service = new InMemoryIncidentService (Constants.Incidents);

            listview = new ListView ();
            listview.ItemsSource = service.RetrieveIncidents ();

            searchbar = new SearchBar () {
                Placeholder = "Search",
            };

            searchbar.TextChanged += (sender, e) => {
                if (!string.IsNullOrEmpty (searchbar.Text))
                    listview.ItemsSource = SearchIncidents (searchbar.Text);
                else
                    listview.ItemsSource = service.RetrieveIncidents ();
            };

            searchbar.SearchButtonPressed += (sender, e) => {
                if (!string.IsNullOrEmpty (searchbar.Text))
                    listview.ItemsSource = SearchIncidents (searchbar.Text);
                else
                    listview.ItemsSource = service.RetrieveIncidents ();

            };


            var stack = new StackLayout () {
                Orientation = StackOrientation.Vertical,
                Children = {
                    label,
                    searchbar,
                    listview
                }
            };

            Content = stack;
        }

        IEnumerable<Incident> SearchIncidents (string text)
        {
            return service.RetrieveIncidents ().Where (i => i.Title.Contains (text, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}