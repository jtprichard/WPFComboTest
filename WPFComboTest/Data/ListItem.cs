using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPFComboTest.Data
{
    public class ListItem : INotifyPropertyChanged
    {
        private string _description;
        private static int count = 100;

        public int Item { get; private set; }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public ListItem() { }

        public ListItem(string value)
        {
            Description = value;
            Item = count;
            count++;
        }

        public static ObservableCollection<ListItem> Populate()
        {
            ObservableCollection<ListItem> items = new ObservableCollection<ListItem>
            {
                new ListItem {Item = 0, Description = "List Item 1"},
                new ListItem {Item = 1, Description = "List Item 2"},
                new ListItem {Item = 2, Description = "List Item 3"},
                new ListItem {Item = 3, Description = "List Item 4"},
                new ListItem {Item = 4, Description = "List Item 5"},
                new ListItem {Item = 5, Description = "List Item 6"},


            };
            return items;
        }


        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Property Changed Method
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
