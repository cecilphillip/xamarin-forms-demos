using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.Incidents.Demo
{
    public partial class IncidentsPage : ContentPage
    {
        public IncidentsPage (Incident incident)
        {
            InitializeComponent ();
            BindingContext = incident;

            saveButton.Clicked += async (sender, e) => {
                await DisplayAlert ("Alert", "You updated an incident", "Ok");
            };
        }
    }
}

