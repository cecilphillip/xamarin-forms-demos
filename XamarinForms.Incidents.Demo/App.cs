using System;

using Xamarin.Forms;

namespace XamarinForms.Incidents.Demo
{
    public class App : Application
    {
        public App ()
        { 
            #region SearchPage Demo
            //MainPage = new SearchPage ();
            #endregion
          
            #region SearchXamlPage Demo
            //MainPage = new SearchXamlPage ();
            #endregion

            #region SearchPageCustomTemplate Demo
            //MainPage = new SearchPageCustomTemplate ();
            #endregion

            #region SearchNavigationPage Demo
            //MainPage = new NavigationPage (new SearchNavigationPage ());
            #endregion

            #region Master Detail Demo
            MainPage = new IncidentsMasterDetailPage ();
            #endregion
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

