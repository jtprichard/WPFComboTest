using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WPFComboTest.ViewModel;

namespace WPFComboTest
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
