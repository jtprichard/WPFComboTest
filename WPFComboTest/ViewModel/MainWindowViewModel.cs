using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using WPFComboTest.Data;
using MvvmDialogs;



namespace WPFComboTest.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        
        ObservableCollection<ComboItem> _comboItems;
        ComboItem _selectedComboItem;

        private ObservableCollection<ListItem> _listItems;
        private ListItem _selectedListItem;
        private string _selectedListValue;

        private bool _openDialog;

        private ICommand openDialogCommand = null;




        //public bool OpenDialog
        //{
        //    get { return _openDialog; }
        //    set { _openDialog = value; OnPropertyChanged(nameof(OpenDialog)); }
        //}

        public ICommand OpenDialogCommand
        {
            get { return openDialogCommand; }
            set { openDialogCommand = value; }
        }
        public ICommand ImplicitShowDialogCommand { get; }

        public ICommand ExplicitShowDialogCommand { get; }

        public ObservableCollection<ComboItem> ComboItems
        {
            get { return _comboItems; }
            //set { _comboItems = value; OnPropertyChanged("ComboItems"); }
            set => Set(nameof(ComboItems), ref _comboItems, value);
        }

        public ComboItem SelectedComboItem
        {
            get { return _selectedComboItem; }
            //set { _selectedComboItem = ComboValidation(value); OnPropertyChanged("SelectedComboItem"); }
            set => Set(nameof(SelectedComboItem), ref _selectedComboItem, value);
        }

        public ObservableCollection<ListItem> ListItems
        {
            get { return _listItems; }
            //set { _listItems = value; OnPropertyChanged(nameof(ListItems)); }
            set => Set(nameof(ListItems), ref _listItems, value);
        }

        public ListItem SelectedListItem
        {
            get { return _selectedListItem; }
            //set
            //{
            //    _selectedListItem = value;
            //    OnPropertyChanged(nameof(SelectedListItem));
            //    OnPropertyChanged(nameof(SelectedListValue));

                

            //}
            set => Set(nameof(SelectedListItem), ref _selectedListItem, value);
        }

        //public string SelectedListValue
        //{
        //    get
        //    {
        //        if (SelectedListItem != null)
        //            return SelectedListItem.Description;
        //        return "";
        //    }
        //    set
        //    {
        //        UpdateList(value);
        //        OnPropertyChanged(nameof(ListItems));
        //        OnPropertyChanged(nameof(SelectedListItem));
        //        OnPropertyChanged(nameof(SelectedListValue));
        //    }
        //}

        public ObservableCollection<string> Texts { get; } = new ObservableCollection<string>();
        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ImplicitShowDialogCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(ImplicitShowDialog);
            ExplicitShowDialogCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(ExplicitShowDialog);
            //openDialogCommand = new RelayCommand(OnOpenDialog);

            ComboItems = ComboItem.Populate();
            SelectedComboItem = ComboItems[0];

            ListItems = ListItem.Populate();
            SelectedListItem = ListItems[0];
        }

        private void ImplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog(this, viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog<WPFComboTest.View.InputDialog>(this, viewModel));
        }

        private void ShowDialog(Func<InputDialogViewModel, bool?> showDialog)
        {
            var dialogViewModel = new InputDialogViewModel();

            bool? success = showDialog(dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }

        private void OnOpenDialog(object parameter)
        {
            //OpenDialog = true;

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
