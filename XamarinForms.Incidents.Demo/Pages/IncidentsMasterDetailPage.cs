using System;
using System.Linq;

using Xamarin.Forms;
using System.Collections.Generic;

namespace XamarinForms.Incidents.Demo
{
    public class IncidentsMasterDetailPage : MasterDetailPage
    {
        private IncidentMasterVm ViewModel {
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

            master.PageSelectionChanged = async (key) => {

                if (Detail != null && Device.OS == TargetPlatform.WinPhone) {
                    await Detail.Navigation.PopToRootAsync ();
                }

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

    public class IncidentMasterPage: ContentPage
    {
        public Action<string> PageSelectionChanged;

        private Page pageSelection;
        private string cacheKey;

        public Page PageSelection {
            get { return pageSelection; }
            set {
                pageSelection = value;
                if (PageSelectionChanged != null)
                    PageSelectionChanged (cacheKey);
            }
        }

        private Page about, searchPage, editIncident;

        public IncidentMasterPage (IncidentMasterVm vm)
        {           
            BindingContext = vm;
            SetBinding (Page.TitleProperty, new Binding (BaseViewModel.TitlePropertyName));

            this.Icon = "slideout.png";

            var layout = new StackLayout { Spacing = 0 };

            var label = new ContentView {
                Padding = new Thickness (10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label {
                    Text = "MENU",
                    FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label))
                }
            };

            layout.Children.Add (label);

            var listView = new ListView ();
           
            DataTemplate cell = new DataTemplate (typeof(TextCell));
            cell.SetBinding (TextCell.TextProperty, IncidentMasterVm.TitlePropertyName);
           

            listView.ItemTemplate = cell;

            listView.ItemsSource = vm.NavItems;
            if (about == null) {                
                about = new IncidentsAboutDetailPage ();
            }

            cacheKey = "AboutPage";
            PageSelection = about;

            listView.ItemSelected += (sender, args) => {

                var menuItem = listView.SelectedItem as MasterNavItem;
                cacheKey = menuItem.CacheKey;

                switch (menuItem.CacheKey) {
                case "AboutPage":
                    if (about == null)
                        about = new IncidentsAboutDetailPage ();

                    PageSelection = about;
                    break;
                case "IncidentsPage":
                    if (searchPage == null)
                        searchPage = new SearchNavigationPage ();

                    PageSelection = searchPage;
                    break;
                case "NewIncidentPage":
                    if (editIncident == null)
                        //TODO: Replace this page
                        editIncident = new IncidentsPage (null);

                    PageSelection = editIncident;
                    break;            
                }

                listView.SelectedItem = null;
            };

            layout.Children.Add (listView);

            Content = layout;

        }
        
    }
}


