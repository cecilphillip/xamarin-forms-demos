using System;
using System.Collections.Generic;
using XamarinForms.Incidents.Demo.Models;

namespace XamarinForms.Incidents.Demo
{	
	public static class Constants
	{
		public static IEnumerable<Incident> Incidents = new List<Incident> {
			new Incident {
				ID = 0,
				Title = "Broken Chair",
				Location = "Building 1",
				ReportedBy = "David",
				Status = "Open",
				DateOccurred = new DateTime (2015, 1, 12),
			},
			new Incident {
				ID = 1,
				Title = "Cracked Monitor",
				Location = "Building 5",
				ReportedBy = "James",
				Status = "Closed",
				DateOccurred = new DateTime (2015, 2, 14),
			},
			new Incident {
				ID = 2,
				Title = "Printer Ink Empty",
				Location = "Building 12",
				ReportedBy = "Michael",
				Status = "Open",
				DateOccurred = new DateTime (2015, 3, 8),
			},
			new Incident {
				ID = 3,
				Title = "Broken Bathroom Tile",
				Location = "Building 4",
				ReportedBy = "Kim",
				Status = "Open",
				DateOccurred = new DateTime (2015, 2, 1),
			},
			new Incident {
				ID = 4,
				Title = "Broken Chair",
				Location = "Building 8",
				ReportedBy = "Barry",
				Status = "Open",
				DateOccurred = new DateTime (2015, 5, 3),
			},
			new Incident {
				ID = 5,
				Title = "Printer Paper Run Out",
				Location = "Building 2",
				ReportedBy = "Peter",
				Status = "Open",
				DateOccurred = new DateTime (2015, 1, 12),
			},
			new Incident {
				ID = 6,
				Title = "Bulbs Blown",
				Location = "Building 6",
				ReportedBy = "Thomas",
				Status = "Open",
				DateOccurred = new DateTime (2015, 1, 15),
			},
			new Incident {
				ID = 7,
				Title = "Faulty Wiring",
				Location = "Building 9",
				ReportedBy = "James",
				Status = "Open",
				DateOccurred = new DateTime (2015, 6, 15),
			},
			new Incident {
				ID = 8,
				Title = "Restock Stationary",
				Location = "Building 11",
				ReportedBy = "Nicole",
				Status = "Open",
				DateOccurred = new DateTime (2015, 1, 12),
			},
			new Incident {
				ID = 9,
				Title = "Clean Windows",
				Location = "Building 3",
				ReportedBy = "David",
				Status = "Open",
				DateOccurred = new DateTime (2014, 12, 31),
			},
			new Incident {
				ID = 10,
				Title = "dotNet Miami Hacked",
				Location = "Building 7",
				ReportedBy = "Thomas",
				Status = "Open",
				DateOccurred = new DateTime (2015, 1, 12),
			},
			new Incident {
				ID = 11,
				Title = "Land Mine Found",
				Location = "Building 10",
				ReportedBy = "Cecil",
				Status = "Open",
				DateOccurred = new DateTime (2015, 7, 6),
			},
			new Incident {
				ID = 12,
				Title = "Richie Won The Lotto",
				Location = "Building 11",
				ReportedBy = "Nicole",
				Status = "Open",
				DateOccurred = new DateTime (2015, 4, 22),
			},
			new Incident {
				ID = 13,
				Title = "Somebody Ate All The Cookies",
				Location = "Building 8",
				ReportedBy = "James",
				Status = "Open",
				DateOccurred = new DateTime (2015, 2, 25),
			},
			new Incident {
				ID = 14,
				Title = "We Found Waldo",
				Location = "Building 6",
				ReportedBy = "Nicole",
				Status = "Open",
				DateOccurred = new DateTime (2014, 12, 20),
			},
			new Incident {
				ID = 15,
				Title = "The Dark Knight Returned",
				Location = "Building 4",
				ReportedBy = "Cecil",
				Status = "Open",
				DateOccurred = new DateTime (2015, 5, 21),
			},
		};
	}
}
