using PhoneDisplayer.Business.Models;
using PhoneDisplayer.Business.Services;
using System.Windows;

namespace PhoneDisplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PhoneService phoneService;
        private readonly CompanyService companyService;
        public MainWindow()
        {
            phoneService = new PhoneService();
            companyService = new CompanyService();  
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var companies = companyService.GetAllCompanies();   
                cbFilter.ItemsSource = companies;
                UpdatePhones(); 
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }   
        }

        private void cbFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {        
            var company = cbFilter.SelectedValue as CompanyModel;

            if (cbFilter.SelectedValue is null || company is null)
                return;

            dgMain.ItemsSource = phoneService.GetAllPhonesByCompany(company.Name);   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddPhoneWindow();
            window.ShowDialog();

            if (window.AddedNew)
            {
                cbFilter.SelectedItem = null;
               UpdatePhones();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgMain.SelectedItem is null)
                return;

            var item = dgMain.SelectedItem as PhoneModel;

            if (item is null) 
                return;

            try
            {
                phoneService.RemovePhoneById(item.Id);
                UpdatePhones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePhones() => dgMain.ItemsSource = phoneService.GetAllPhones();
    }
}