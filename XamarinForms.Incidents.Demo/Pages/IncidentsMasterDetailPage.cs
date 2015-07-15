using System;
using System.Linq;

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
                
                NavigationPage newPage;
                if (cachedPages.ContainsKey (key)) {
                    newPage = cachedPages [key];
                } else {
                    newPage = new NavigationPage (master.PageSelection) {
                        BarBackgroundColor = Color.FromHex ("#3498DB"),
                        BarTextColor = Color.White
                    };
                    cachedPages.Add (key, newPage);
                }
                Detail = newPage;
                Detail.Title = master.PageSelection.Title;
                if (Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;
            };

            this.Icon = "slideout.png";
        }
    }
}

