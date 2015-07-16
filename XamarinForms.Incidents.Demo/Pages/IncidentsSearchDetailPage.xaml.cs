using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Services;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
    public partial class IncidentsSearchDetailPage : ContentPage
    {
        IncidentsSearchDetailVm ViewModel {
            get { return BindingContext as IncidentsSearchDetailVm; }
        }

        public IncidentsSearchDetailPage (IncidentsSearchDetailVm vm)
        {
            InitializeComponent ();
            BindingContext = vm;          

            SetBinding (Page.TitleProperty, new Binding (BaseViewModel.TitlePropertyName));

            // wire up incidents SearchBar
            incidentsSb.TextChanged += (sender, e) => LoadIncidents ();

            incidentsSb.SearchButtonPressed += (sender, e) => LoadIncidents ();
            incidentsSb.BackgroundColor = Color.FromHex ("#3498DB");

            // wire up incidents ListView\
            incidentsLv.ItemSelected += async (sender, e) => {
                if (e.SelectedItem != null)
                    await Navigation.PushAsync (new IncidentsEditDetailPage (new IncidentsEditDetailVM(e.SelectedItem as Incident))); 

                incidentsLv.SelectedItem = null;  
            };

            MessagingCenter.Subscribe<IncidentsEditDetailVM> (this, "incident-updated", sender => LoadIncidents ());
        }  

        void LoadIncidents() {
            if (!string.IsNullOrEmpty (incidentsSb.Text))
                ViewModel.SearchIncidents (incidentsSb.Text);
            else
                ViewModel.SearchIncidents(); 
        }
    }
}

