using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Repo_Pattern_Practice.Models;

using Repo_Pattern_Practice.Repository;

namespace ZipcodeEditor
{
    public partial class MainWindow : Window
    {
        
        private List<Contact> listContacts = new List<Contact>();
        private List<Contact> storageContacts = new List<Contact>();

        private ApplicationContext applicationContext;
        private ZipcodeRepository zipcodeRepository;
        private AddressRepository addressRepository;
        

        public MainWindow()
        {
            InitializeComponent();
            applicationContext = new ApplicationContext();
            zipcodeRepository = new ZipcodeRepository(applicationContext);
            addressRepository = new AddressRepository(applicationContext);
            Populate();
        }

        private void Populate()
        {

            IEnumerable<Addresse> searchResultsAddress = addressRepository.Select
                (address => address.Phone.StartsWith(Phone_Search.Text.Trim())
                && address.FirstName.StartsWith(First_Name_Search.Text.Trim())
                && address.LastName.StartsWith(Last_Name_Search.Text.Trim())
                && address.Address.StartsWith(Address_Search.Text.Trim())
                && address.Title.StartsWith(Title_Search.Text.Trim()));
            addressRepository.SaveChanges();

            
            foreach (Addresse result in searchResultsAddress)
            {
                storageContacts.Add(new Contact(result, zipcodeRepository.ReturnZipCode(result.Zipcode)));
            }

            maingrid.ItemsSource = new ObservableCollection<Contact>(storageContacts);
        }

        private void Select()
        {

            IEnumerable<Contact> searchResultsContact = storageContacts.FindAll
                (contact => contact.addresse.Phone.StartsWith(Phone_Search.Text.Trim())
                && contact.addresse.FirstName.StartsWith(First_Name_Search.Text.Trim())
                && contact.addresse.LastName.StartsWith(Last_Name_Search.Text.Trim())
                && contact.addresse.Address.StartsWith(Address_Search.Text.Trim())
                && contact.addresse.Title.StartsWith(Title_Search.Text.Trim())
                && contact.zipcode.City.StartsWith(City_Search.Text.Trim())
                && contact.zipcode.Code.StartsWith(Zipcode_Search.Text.Trim()));

            listContacts.Clear();
            foreach (Contact result in searchResultsContact)
            {
                listContacts.Add(result);
            }
            
            Refresh();
        }
        private void Refresh()
        {
            maingrid.ItemsSource = new ObservableCollection<Contact>(listContacts);
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
            Select();
        }
    }
}
