using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Repo_Pattern_Practice.DatabaseEntities;
using Repo_Pattern_Practice.Repository;

namespace ZipcodeEditor
{
    public partial class MainWindow : Window
    {
        private List<Zipcode> listZipcodes = new List<Zipcode>();
        private List<Addresse> listAddresses = new List<Addresse>();
        private ApplicationContext applicationContext;
        private ZipcodeRepository zipcodeRepository;
        private AddressRepository addressRepository;

        public MainWindow()
        {
            InitializeComponent();
            applicationContext = new ApplicationContext();
            zipcodeRepository = new ZipcodeRepository(applicationContext);
            addressRepository = new AddressRepository(applicationContext);
            Select();
        }

        private void Select()
        {
            IEnumerable<Zipcode> searchResultsZipcode = zipcodeRepository.Select(zipcode => zipcode.Code.StartsWith(Zipcode_Search.Text.Trim())
                                                                    && zipcode.City.StartsWith(City_Search.Text.Trim()));
            zipcodeRepository.SaveChanges();
            IEnumerable<Addresse> searchResultsAddress = addressRepository.Select(address => address.Phone.StartsWith(Phone_Search.Text.Trim()));
            addressRepository.SaveChanges();

            listZipcodes.Clear();
            foreach (Zipcode result in searchResultsZipcode)
            {
                listZipcodes.Add(new Zipcode { 
                    Code = result.Code.ToString(), 
                    City = result.City.ToString() }); ;
            }
            listAddresses.Clear();
            foreach (Addresse result in searchResultsAddress)
            {
                listAddresses.Add(new Addresse { 
                    Phone = result.Phone.ToString(), 
                    FirstName = result.FirstName.ToString(), 
                    LastName = result.LastName.ToString(),
                    Address = result.Address.ToString(),
                    Email = result.Email.ToString(),
                    Title = result.Title.ToString(),
                    Zipcode = result.Zipcode.ToString(),
                    City = result.City.ToString()}) ;
            }

            Refresh();
        }
        private void Refresh()
        {
            maingrid.ItemsSource = new ObservableCollection<Zipcode>(listZipcodes);
            maingrid.ItemsSource = new ObservableCollection<Addresse>(listAddresses);
        }


        private void NewAddress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageZipcodes_Click(object sender, RoutedEventArgs e)
        {
            ZipWindow zipWindow = new ZipWindow();
            zipWindow.ShowDialog();
        }

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
