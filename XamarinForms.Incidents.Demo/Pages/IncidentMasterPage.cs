using System;
using System.Linq;

using Xamarin.Forms;
using System.Collections.Generic;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo.Pages
{
    public class IncidentMasterPage: ContentPage
    {
        public Action<string> PageSelectionChanged;

        Page pageSelection, about, searchPage, editIncident;
        string cacheKey;

        public Page PageSelection {
            get { return pageSelection; }
            set {
                pageSelection = value;
                if(PageSelectionChanged != null)
                    PageSelectionChanged (cacheKey);
            }
        }

        public IncidentMasterPage(IncidentMasterVm vm)
        {           
            BindingContext = vm;
            SetBinding (Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));

            this.Icon = "slideout.png";

            var layout = new StackLayout { Spacing = 0 };

            var label = new ContentView {
                Padding = new Thickness(10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label {
                    Text = "MENU",
                    FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label))
                }
            };

            layout.Children.Add (label);

            var listView = new ListView();
           
            DataTemplate cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding (TextCell.TextProperty, BaseViewModel.TitlePropertyName);
           
            listView.ItemTemplate = cell;
            listView.ItemsSource = vm.NavItems;

            if(about == null) {                
                about = new IncidentsAboutDetailPage();
            }

            listView.SelectedItem = vm.NavItems.Single (i => i.CacheKey == "AboutPage");
            cacheKey = "AboutPage";
            PageSelection = about;

            listView.ItemSelected += (sender, args) => {

                var menuItem = listView.SelectedItem as MasterNavItem;
                cacheKey = menuItem.CacheKey;

                switch(menuItem.CacheKey) {
                case "AboutPage":
                    if(about == null)
                        about = new IncidentsAboutDetailPage();

                    PageSelection = about;
                    break;
                case "IncidentsPage":
                    if(searchPage == null)
                        searchPage = new IncidentsSearchDetailPage(new IncidentsSearchDetailVm());

                    PageSelection = searchPage;
                    break;
                case "NewIncidentPage":
                    if(editIncident == null)
                        editIncident = new IncidentsEditDetailPage(new IncidentsEditDetailVM());

                    PageSelection = editIncident;
                    break;            
                }
            };

            layout.Children.Add (listView);

            Content = layout;
        }
    }
}
