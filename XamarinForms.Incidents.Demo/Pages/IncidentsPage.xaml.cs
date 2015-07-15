using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
    public partial class IncidentsPage : ContentPage
    {
        public IncidentsPage (Incident incident)
        {
            InitializeComponent ();
            BindingContext = incident;

            saveButton.Clicked += async (sender, e) => await DisplayAlert ("Alert", "You updated an incident", "Ok");
        }
    }
}

