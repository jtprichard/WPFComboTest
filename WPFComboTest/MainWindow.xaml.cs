using System.Windows;


namespace WPFComboTest
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
    }
}
