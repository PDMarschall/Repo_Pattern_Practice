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
        private List<Contact> _listContacts = new List<Contact>();
        private List<Contact> _storageContacts = new List<Contact>();

        private ApplicationContext _applicationContext;
        private ZipcodeRepository _zipcodeRepository;
        private AddressRepository _addressRepository;

        public MainWindow()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            _applicationContext = new ApplicationContext();
            _zipcodeRepository = new ZipcodeRepository(_applicationContext);
            _addressRepository = new AddressRepository(_applicationContext);

            IEnumerable<Addresse> searchResultsAddress = _addressRepository.Select
                (address => address.Phone.StartsWith(Phone_Search.Text.Trim())
                && address.FirstName.StartsWith(First_Name_Search.Text.Trim())
                && address.LastName.StartsWith(Last_Name_Search.Text.Trim())
                && address.Address.StartsWith(Address_Search.Text.Trim())
                && address.Title.StartsWith(Title_Search.Text.Trim()));
            _addressRepository.SaveChanges();

            _storageContacts.Clear();
            _listContacts.Clear();

            foreach (Addresse result in searchResultsAddress)
            {
                _storageContacts.Add(new Contact(result, _zipcodeRepository.ReturnEntity(result.Zipcode)));
                _listContacts.Add(new Contact(result, _zipcodeRepository.ReturnEntity(result.Zipcode)));
            }

            maingrid.ItemsSource = new ObservableCollection<Contact>(_storageContacts);
        }

        private void Select()
        {
            IEnumerable<Contact> searchResultsContact = _storageContacts.FindAll
                (contact => contact.Addresse.Phone.StartsWith(Phone_Search.Text.Trim())
                && contact.Addresse.FirstName.StartsWith(First_Name_Search.Text.Trim())
                && contact.Addresse.LastName.StartsWith(Last_Name_Search.Text.Trim())
                && contact.Addresse.Address.StartsWith(Address_Search.Text.Trim())
                && contact.Addresse.Title.StartsWith(Title_Search.Text.Trim())
                && contact.Zipcode.City.StartsWith(City_Search.Text.Trim())
                && contact.Zipcode.Code.StartsWith(Zipcode_Search.Text.Trim()));

            _listContacts.Clear();
            foreach (Contact result in searchResultsContact)
            {
                _listContacts.Add(result);
            }

            Refresh();
        }
        private void Refresh()
        {
            maingrid.ItemsSource = new ObservableCollection<Contact>(_listContacts);
        }


        private void NewAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressWindow addressWindow = new AddressWindow();
            addressWindow.Phone_Box.IsEnabled = true;
            addressWindow.ShowDialog();
        }

        private void ManageZipcodes_Click(object sender, RoutedEventArgs e)
        {
            ZipWindow zipWindow = new ZipWindow();
            zipWindow.ShowDialog();
        }

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            Phone_Search.Clear();
            First_Name_Search.Clear();
            Last_Name_Search.Clear();
            Address_Search.Clear();
            Zipcode_Search.Clear();
            Title_Search.Clear();
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, RoutedEventArgs e)
        {
            Select();            
        }

        private void maingrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {            
            int n = maingrid.SelectedIndex;
            AddressWindow addressWindow = new AddressWindow(_listContacts[n].Addresse);
            addressWindow.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Populate();
            Select();
        }
    }
}
