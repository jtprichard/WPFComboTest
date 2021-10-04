using System.Windows;
using System.Windows.Controls;
using WPFComboTest.Core;

namespace WPFComboTest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ViewModel _instance;
        public MainWindow()
        {
            InitializeComponent();
            _instance = new ViewModel();
            DataContext = _instance;
        }

        private void ShowComboItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ComboBox in ViewModel: " + _instance.SelectedComboItem.Description, "Combo Test");
        }

        private void UpdateVMSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            _instance.SelectedComboItem = _instance.ComboItems[0];
        }

        private void EditListValue_OnClick(object sender, RoutedEventArgs e)
        {
            var value = ListValue.Text;
            var dialog = new InputDialog("Modify List Item", value);
            if (dialog.ShowDialog() == true)
                ListValue.Text = dialog.Answer;


        }

        private void AddListValue_OnClick(object sender, RoutedEventArgs e)
        {
            List.UnselectAll();
            var dialog = new InputDialog("Add Venue", "");
            if (dialog.ShowDialog() == true)
                ListValue.Text = dialog.Answer;
        }
    }
}
