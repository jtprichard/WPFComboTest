using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFComboTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

        ObservableCollection<ComboItem> _comboItems;
        ComboItem _selectedComboItem;

        public ObservableCollection<ComboItem> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; OnPropertyChanged("ComboItems"); }
        }

        public ComboItem SelectedComboItem
        {
            get { return _selectedComboItem; }
            set { _selectedComboItem = ComboValidation(value); OnPropertyChanged("SelectedComboItem"); }
        }

        public ViewModel()
        {
            ComboItems = ComboItem.Populate();
            SelectedComboItem = ComboItems[0];
        }


        private ComboItem ComboValidation(ComboItem item)
        {
            if(item.Item == 2)
            {
                MessageBox.Show("This is an invalid selection", "ComboTest");
                return ComboItems[0];
            }
            return item;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }




}
