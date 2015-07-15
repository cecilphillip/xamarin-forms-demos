using System;
using SQLite.Net.Attributes;

namespace XamarinForms.Incidents.Demo.Models
{
    public class Incident
    {
		[PrimaryKey, AutoIncrement]
        public int ID {
            get;
            set;
        }

        public string Title {
            get;
            set;
        }

        public string Location {
            get;
            set;
        }

        public string ReportedBy {
            get;
            set;
        }

        public string Status {
            get;
            set;
        }

        public DateTime DateOccurred {
            get;
            set;
        }

        public override string ToString ()
        {
            return this.Title;
        }

    }
}

