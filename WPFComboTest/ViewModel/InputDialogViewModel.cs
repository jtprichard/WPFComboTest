using System;
using System.Windows.Input;
using MvvmDialogs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WPFComboTest.ViewModel
{
    public class InputDialogViewModel: ViewModelBase, IModalDialogViewModel
    {
        private string text;
        private bool? dialogResult;

        public string Text
        {
            get => text;
            set => Set(nameof(Text), ref text, value);
        }

        public ICommand OkCommand { get; }

        public bool? DialogResult
        {
            get => dialogResult;
            private set => Set(nameof(DialogResult), ref dialogResult, value);
        }

        public InputDialogViewModel()
        {
            OkCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Ok);
        }

        private void Ok()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                DialogResult = true;
            }
        }


    }
}
