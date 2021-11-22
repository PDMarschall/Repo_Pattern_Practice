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

        public MainWindow()
        {

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
    }
}
