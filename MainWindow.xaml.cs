using PhoneDisplayer.Business;
using System.Windows;

namespace PhoneDisplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PhoneService service;
        public MainWindow()
        {
            service = new PhoneService();
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var phones = service.GetAllPhones();
                dgMain.ItemsSource = phones;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }   
        }
    }
}