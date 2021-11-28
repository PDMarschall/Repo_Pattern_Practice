using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Repo_Pattern_Practice.Models;

using Repo_Pattern_Practice.Repository;

namespace ZipcodeEditor
{
    public partial class AddressWindow : Window
    {
        private Addresse _initialAddress;
        private ApplicationContext _context;
        private AddressRepository _addressRepository;

        public AddressWindow()
        {
            InitializeComponent();
            _context = new ApplicationContext();
            _addressRepository = new AddressRepository(_context);
        }
        public AddressWindow(Addresse addresse)
        {
            InitializeComponent();
            _initialAddress = addresse;
            GetInitialText(addresse);
            _context = new ApplicationContext();
            _addressRepository = new AddressRepository(_context);
        }

        private void GetInitialText(Addresse addresse)
        {
            Phone_Box.Text = addresse.Phone;
            FirstName_Box.Text = addresse.FirstName;
            LastName_Box.Text = addresse.LastName;
            Address_Box.Text = addresse.Address;
            Zipcode_Box.Text = addresse.Zipcode;
            Email_Box.Text = addresse.Email;
            Title_Box.Text = addresse.Title;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            if (_initialAddress == null)
            {
                Addresse insertAddress = ConstructAddress();
                _addressRepository.Insert(insertAddress);
                _addressRepository.SaveChanges();

            }
            else if (Phone_Box.Text.Trim() != "")
            {
                Addresse updateAddresse = ConstructAddress();
                _addressRepository.Update(updateAddresse);
                _addressRepository.SaveChanges();
            }
            Close();

        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void cmdRemove_Click(object sender, RoutedEventArgs e)
        {
            Addresse removeAddresse = ConstructAddress();
            _addressRepository.RepoContext.ChangeTracker.Clear();
            _addressRepository.Delete(removeAddresse);
            _addressRepository.SaveChanges();
            Close();
        }
        private Addresse ConstructAddress()
        {
            Addresse newAddress = new Addresse(
                Phone_Box.Text.Trim(),
                FirstName_Box.Text.Trim(),
                LastName_Box.Text.Trim(),
                Address_Box.Text.Trim(),
                Zipcode_Box.Text.Trim(),
                Email_Box.Text.Trim(),
                Title_Box.Text.Trim());

            return newAddress;
        }
    }
}
