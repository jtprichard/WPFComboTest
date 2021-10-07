using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using WPFComboTest.Data;



namespace WPFComboTest.Core
{
    public class ViewModel : BaseViewModel
    {
        ObservableCollection<ComboItem> _comboItems;
        ComboItem _selectedComboItem;

        private ObservableCollection<ListItem> _listItems;
        private ListItem _selectedListItem;
        private string _selectedListValue;

        private bool _openDialog;

        private ICommand openDialogCommand = null;


        public bool OpenDialog
        {
            get { return _openDialog; }
            set { _openDialog = value; OnPropertyChanged(nameof(OpenDialog)); }
        }

        public ICommand OpenDialogCommand
        {
            get { return openDialogCommand; }
            set { openDialogCommand = value; }
        }

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

        public ObservableCollection<ListItem> ListItems
        {
            get { return _listItems; }
            set { _listItems = value; OnPropertyChanged(nameof(ListItems)); }
        }

        public ListItem SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                _selectedListItem = value;
                OnPropertyChanged(nameof(SelectedListItem));
                OnPropertyChanged(nameof(SelectedListValue));
            }
        }

        public string SelectedListValue
        {
            get
            {
                if (SelectedListItem != null)
                    return SelectedListItem.Description;
                return "";
            }
            set
            {
                UpdateList(value);
                OnPropertyChanged(nameof(ListItems));
                OnPropertyChanged(nameof(SelectedListItem));
                OnPropertyChanged(nameof(SelectedListValue));
            }
        }
        public ViewModel()
        {
            openDialogCommand = new RelayCommand(OnOpenDialog);

            ComboItems = ComboItem.Populate();
            SelectedComboItem = ComboItems[0];

            ListItems = ListItem.Populate();
            SelectedListItem = ListItems[0];
        }

        private void OnOpenDialog(object parameter)
        {
            OpenDialog = true;

            //UI.InputDialog dialog = new UI.InputDialog( "Question", "");
            //string result;
            //if (dialog.ShowDialog() == true)
            //    result = dialog.Answer;

            //Dialogs.DialogService.DialogViewModelBase vm =
            //    new Dialogs.DialogYesNo.DialogYesNoViewModel("Question");
            //Dialogs.DialogService.DialogResult result =
            //    Dialogs.DialogService.DialogService.OpenDialog(vm, parameter as Window);
        }

        private void UpdateList(string value)
        {
            if (SelectedListItem == null)
                AddToList(value);
            else
            {
                ModifyList(value);
            }

        }

        private void ModifyList(string value)
        {
            //Find the index of the list items based on selected item
            var listItem = ListItems.First(x => x == SelectedListItem);

            //Update the value of the item list
            listItem.Description = value;

            //Update the selected list item
            SelectedListItem = listItem;
        }

        private void AddToList(string value)
        {
            ListItems.Add(new ListItem(value));
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

    }




}
