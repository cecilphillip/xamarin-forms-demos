using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
	public partial class IncidentsEditDetailPage : ContentPage
	{
        IncidentsEditDetailVM ViewModel {
            get { return BindingContext as IncidentsEditDetailVM; }
        }

        public IncidentsEditDetailPage (IncidentsEditDetailVM incidentVm)
		{
			InitializeComponent ();
			
            BindingContext = incidentVm;
            SetBinding (Page.TitleProperty, new Binding (BaseViewModel.TitlePropertyName));

            //Is there a better way to do this?
            dateStack.IsVisible = incidentVm.IsVisible;

			saveButton.Clicked += async (sender, e) => {
                ViewModel.SaveIncident();
				await DisplayAlert ("Alert", "You saved an incident", "Ok");

                ViewModel.ResetModel();
			};

            resetButton.Clicked += (sender, e) => ViewModel.ResetModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing ();

            //ViewModel.ResetModel ();
        }
	}
}

