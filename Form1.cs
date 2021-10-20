using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListViewLiveSearch
{
    public partial class Form1 : Form
    {
        private List<Spacecraft> _spacecrafts;

        public Form1()
        {
            InitializeComponent();
            SetupListView();
        }

        private void SetupListView()
        {
            lv_data.View = View.Details;
            lv_data.GridLines = true;
            lv_data.FullRowSelect = true;
            lv_data.Columns.Add("Name", 150);
            lv_data.Columns.Add("Destination", 250);

            //LISTVIEW
            _spacecrafts = new List<Spacecraft>
            {
                new Spacecraft { Name = "Casini", Destination = "Saturn" },
                new Spacecraft { Name = "Enterprise", Destination = "Andromeda" },
                new Spacecraft { Name = "Challenger", Destination = "Pluto" },
                new Spacecraft { Name = "New Horizon", Destination = "Asteroid Belt" },
                new Spacecraft { Name = "Opportunity", Destination = "Mars" },
                new Spacecraft { Name = "Curiosity", Destination = "Mars" },
                new Spacecraft { Name = "Juno", Destination = "Jupiter" },
                new Spacecraft { Name = "Apollo 15", Destination = "Monn" },
                new Spacecraft { Name = "Apollo 17", Destination = "Moon" },
                new Spacecraft { Name = "Voyager A", Destination = "Alpha Centauri" },
                new Spacecraft { Name = "Voyager B", Destination = "Proxima Centauri" },
                new Spacecraft { Name = "Rosetter", Destination = "Venus" },
                new Spacecraft { Name = "Spitzer", Destination = "Uranus" },
                new Spacecraft { Name = "Chandra", Destination = "Mercury" },
                new Spacecraft { Name = "Pioneer", Destination = "Mars" },
                new Spacecraft { Name = "Atlantis", Destination = "Jupiter" }
            };

            //POPULATE SPACECRAFTS
            foreach (var s in _spacecrafts) lv_data.Items.Add(new ListViewItem(new[] { s.Name, s.Destination }));
        }

        private void SearchData(string searchTerm)
        {
            lv_data.Items.Clear();

            foreach (var s in _spacecrafts)
                if (s.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    s.Destination.ToLower().Contains(searchTerm.ToLower()))
                    lv_data.Items.Add(new ListViewItem(new[] { s.Name, s.Destination }));
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchData(tb_search.Text);
        }
    }

    internal class Spacecraft
    {
        public string Name { get; set; }
        public string Destination { get; set; }
    }
}