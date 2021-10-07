using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using WPFComboTest.Data;



namespace WPFComboTest.ViewModelTest
{
    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<ComboItem> _comboItems;
        ComboItem _selectedComboItem;
        private IDialogService _dialogService;

        private ObservableCollection<ListItem> _listItems;
        private ListItem _selectedListItem;
        private string _selectedListValue;

        private ICommand openDialogCommand = null;



        public ICommand OpenDialogCommand
        {
            get { return openDialogCommand; }
            set { openDialogCommand = value; }
        }

        public ObservableCollection<ComboItem> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; }
            //set { _comboItems = value; OnPropertyChanged("ComboItems"); }
        }

        public ComboItem SelectedComboItem
        {
            get { return _selectedComboItem; }
            set { _selectedComboItem = ComboValidation(value); }
            //set { _selectedComboItem = ComboValidation(value); OnPropertyChanged("SelectedComboItem"); }
        }

        public ObservableCollection<ListItem> ListItems
        {
            get { return _listItems; }
            set { _listItems = value; }
            //set { _listItems = value; OnPropertyChanged(nameof(ListItems)); }
        }

        public ListItem SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                _selectedListItem = value;
                //OnPropertyChanged(nameof(SelectedListItem));
                //OnPropertyChanged(nameof(SelectedListValue));
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
                //OnPropertyChanged(nameof(ListItems));
                //OnPropertyChanged(nameof(SelectedListItem));
                //OnPropertyChanged(nameof(SelectedListValue));
            }
        }
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            openDialogCommand = new RelayCommand(OnOpenDialog);

            ComboItems = ComboItem.Populate();
            SelectedComboItem = ComboItems[0];

            ListItems = ListItem.Populate();
            SelectedListItem = ListItems[0];
        }

        private void OnOpenDialog(object parameter)
        {
            string result = "";
            var message = "This is a message that should be shown in the dialog.";

            _dialogService.ShowDialog("PrismInputDialog", new DialogParameters($"question={message}"), r =>
            {
                
            });

            //using the dialog service as-is
            //_dialogService.ShowDialog("PrismInputDialog", new DialogParameters($"message={message}"), r =>
            //{
            //    if (r.Result == ButtonResult.None)
            //        result = "Result is None";
            //    else if (r.Result == ButtonResult.OK)
            //        result = "Result is OK";
            //    else if (r.Result == ButtonResult.Cancel)
            //        result = "Result is Cancel";
            //    else
            //        result = "I Don't know what you did!?";
            //});

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
