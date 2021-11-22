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

        private List<Zipcode> list = new List<Zipcode>();
        private ApplicationContext applicationContext;
        private ZipcodeRepository zipcodeRepository;

        public ZipWindow()
        {
            InitializeComponent();
            applicationContext = new ApplicationContext();
            zipcodeRepository = new ZipcodeRepository(applicationContext);
            Select();
        }

        private void cmdSelect_Click(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void cmdInsert_Click(object sender, RoutedEventArgs e)
        {
            Zipcode insertZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());

            zipcodeRepository.Insert(insertZipcode);
            zipcodeRepository.SaveChanges();
        }

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            Zipcode insertZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());
            applicationContext.ChangeTracker.Clear();

            zipcodeRepository.Update(insertZipcode);
            zipcodeRepository.SaveChanges();

            Refresh();
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            Zipcode insertZipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());
            applicationContext.ChangeTracker.Clear();

            zipcodeRepository.Delete(insertZipcode);
            zipcodeRepository.SaveChanges();

            ClearText();
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Select()
        {
            IEnumerable<Zipcode> searchResults = zipcodeRepository.Select(zipcode => zipcode.Code.StartsWith(txtCode.Text.Trim())
                                                                    && zipcode.City.StartsWith(txtCity.Text.Trim()));
            zipcodeRepository.SaveChanges();

            list.Clear();
            foreach (Zipcode result in searchResults)
            {
                list.Add(new Zipcode { Code = result.Code.ToString(), City = result.City.ToString() }); ;
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
                txtCode.Text = list[n].Code;
                txtCity.Text = list[n].City;
            }
        }

        private void Refresh()
        {
            grid.ItemsSource = new ObservableCollection<Zipcode>(list);
        }


    }
}
