using Xamarin.Forms;
using System.Collections.Generic;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
    public class IncidentsMasterDetailPage : MasterDetailPage
    {
        IncidentMasterVm ViewModel {
            get { return BindingContext as IncidentMasterVm; }
        }

        IncidentMasterPage master;
        Dictionary<string, NavigationPage> cachedPages;

        public IncidentsMasterDetailPage ()
        {
            BindingContext = new IncidentMasterVm ();
            cachedPages = new Dictionary<string, NavigationPage> ();

            Master = master = new IncidentMasterPage (ViewModel);

            var homeNav = new NavigationPage (master.PageSelection) {
                BarBackgroundColor = Color.FromHex ("#3498DB"),
                BarTextColor = Color.White
            };

            Detail = homeNav;

            cachedPages.Add ("AboutPage", homeNav);

            master.PageSelectionChanged = (key) => {
                
                NavigationPage navPage;

                if (cachedPages.ContainsKey (key)) {
                    navPage = cachedPages [key];
                } else {
                    navPage = new NavigationPage (master.PageSelection) {
                        BarBackgroundColor = Color.FromHex ("#3498DB"),
                        BarTextColor = Color.White
                    };
                    cachedPages.Add (key, navPage);
                }

                Detail = navPage;
                Detail.Title = master.PageSelection.Title;
                if (Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;
            };

            this.Icon = "slideout.png";
        }
    }
}

