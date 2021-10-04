using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFComboTest.Data
{
    public class ComboItem
    {
        public int Item { get; private set; }
        public string Description { get; private set; }

        public ComboItem() { }

        public static ObservableCollection<ComboItem> Populate()
        {
            ObservableCollection<ComboItem> items = new ObservableCollection<ComboItem>
            {
                new ComboItem {Item = 0, Description = "Item 1"},
                new ComboItem {Item = 1, Description = "Item 2"},
                new ComboItem {Item = 2, Description = "Invalid Item"}

            };
            return items;
        }
    }
}
