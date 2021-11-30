using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Repo_Pattern_Practice.Models;
using Repo_Pattern_Practice.Repository;

namespace ZipcodeEditor
{
    public partial class ZipWindow : Window
    {
        private List<Zipcode> _list = new List<Zipcode>();
        private ApplicationContext _applicationContext;
        private ZipcodeRepository _zipcodeRepository;

        public ZipWindow()
        {
            InitializeComponent();
            _applicationContext = new ApplicationContext();
            _zipcodeRepository = new ZipcodeRepository(_applicationContext);
            Select();
        }

        private void cmdSelect_Click(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void cmdInsert_Click(object sender, RoutedEventArgs e)
        {
            Zipcode insertZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());

            _zipcodeRepository.Insert(insertZipcode);
            _zipcodeRepository.SaveChanges();
        }

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            Zipcode insertZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());
            _applicationContext.ChangeTracker.Clear();

            _zipcodeRepository.Update(insertZipcode);
            _zipcodeRepository.SaveChanges();

            Refresh();
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            Zipcode deleteZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());
            _applicationContext.ChangeTracker.Clear();

            _zipcodeRepository.Delete(deleteZipcode);
            _zipcodeRepository.SaveChanges();

            ClearText();
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Select()
        {
            IEnumerable<Zipcode> searchResults = _zipcodeRepository.Select(zipcode => zipcode.Code.StartsWith(txtCode.Text.Trim())
                                                                    && zipcode.City.StartsWith(txtCity.Text.Trim()));

            _list.Clear();
            foreach (Zipcode result in searchResults)
            {
                _list.Add(result);
            }

            Refresh();
        }

        private void Clear()
        {
            grid.SelectedIndex = -1;
            txtCode.Clear();
            txtCity.Clear();
            Select();
        }

        private void ClearText()
        {
            txtCity.Clear();
            txtCode.Clear();
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = grid.SelectedIndex;
            if (n >= 0)
            {
                txtCode.Text = _list[n].Code;
                txtCity.Text = _list[n].City;
            }
        }

        private void Refresh()
        {
            grid.ItemsSource = new ObservableCollection<Zipcode>(_list);
        }


    }
}
