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
        private Addresse initialAddress;
        private ApplicationContext context;

        private AddressRepository addressRepository;

        public AddressWindow()
        {
            InitializeComponent();
            context = new ApplicationContext();
            addressRepository = new AddressRepository(context);
        }
        public AddressWindow(Addresse addresse)
        {
            InitializeComponent();
            initialAddress = addresse;
            GetInitialText(addresse);
            context = new ApplicationContext();
            addressRepository = new AddressRepository(context);
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
            if (initialAddress == null)
            {
                Addresse insertAddress = ConstructAddress();
                addressRepository.Insert(insertAddress);
                addressRepository.SaveChanges();
            }
            else if (Phone_Box.Text.Trim() != "")
            {
                Addresse updateAddresse = ConstructAddress();
                addressRepository.Update(updateAddresse);
                addressRepository.SaveChanges();
            }
            Close();

        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
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

        private void cmdRemove_Click(object sender, RoutedEventArgs e)
        {
            Addresse removeAddresse = ConstructAddress();
            addressRepository.RepoContext.ChangeTracker.Clear();
            addressRepository.Delete(removeAddresse);
            addressRepository.SaveChanges();
            Close();
        }
    }
}
