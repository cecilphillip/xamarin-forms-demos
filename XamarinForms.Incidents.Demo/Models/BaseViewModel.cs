using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace XamarinForms.Incidents.Demo.Models
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string title = string.Empty;
        public const string TitlePropertyName = "Title";

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public string Title {
            get { return title; }
            set { SetProperty (ref title, value, TitlePropertyName); }
        }

        private bool isBusy;
        /// <summary>
        /// Gets or sets if the view is busy.
        /// </summary>
        public const string IsBusyPropertyName = "IsBusy";

        public bool IsBusy {
            get { return isBusy; }
            set { SetProperty (ref isBusy, value, IsBusyPropertyName); }
        }

        protected void SetProperty<T> (ref T backingStore, T value, [CallerMemberName]string propertyName = null, Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals (backingStore, value))
                return;

            backingStore = value;

            if (onChanged != null)
                onChanged ();

            OnPropertyChanged (propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged (string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}

