using PhoneDisplayer.Business.Models;
using PhoneDisplayer.Business.Services;
using System.Windows;

namespace PhoneDisplayer
{
    /// <summary>
    /// Interaction logic for AddPhone.xaml
    /// </summary>
    public partial class AddPhoneWindow : Window
    {
        private readonly PhoneService phoneService;
        private readonly CompanyService companyService;

        public bool AddedNew { get; private set; } = false;
        public AddPhoneWindow()
        {
            phoneService = new PhoneService();
            companyService = new CompanyService();  
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbModel.Text) ||
                cbCompanies.SelectedValue is null ||
                Int32.TryParse(tbPrice.Text, out int price) == false)
            {
                return;
            }

            var newPhone = new PhoneModel
            {
                Name = tbModel.Text,    
                Price = price,
                Company = (cbCompanies.SelectedValue as CompanyModel)?.Name
            };

            try
            {
                phoneService.AddNewPhone(newPhone);
                AddedNew = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();    
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            cbCompanies.ItemsSource = companyService.GetAllCompanies();
        }
    }
}
