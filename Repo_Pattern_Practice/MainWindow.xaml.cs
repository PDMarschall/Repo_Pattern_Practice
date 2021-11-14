using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Repo_Pattern_Practice.DatabaseEntities;
using Repo_Pattern_Practice.Repository;
using Microsoft.EntityFrameworkCore;

namespace ZipcodeEditor
{
    public partial class MainWindow : Window
    {
        private List<Zipcode> list = new List<Zipcode>();

        public MainWindow()
        {
            InitializeComponent();
            Seek("", "");
        }
        private void cmdTest_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext applicationContext = new ApplicationContext();
            ZipcodeRepository zipcodeRepository = new ZipcodeRepository(applicationContext);
            //Zipcode zipcode = new Zipcode(txtCode.Text.Trim(), txtCity.Text.Trim());

            //while (reader.Read()) list.Add(new Zipcode { Code = reader[0].ToString(), City = reader[1].ToString() });

            var test = zipcodeRepository.Select(zipcode => zipcode.Code.StartsWith(txtCode.Text.Trim()) && zipcode.City.StartsWith(txtCity.Text.Trim()));
            list.Clear();
            foreach (Zipcode result in test)
            {
                list.Add(new Zipcode { Code = result.Code.ToString(), City = result.City.ToString() }); ;
            }
            Refresh();
        }

        private void Refresh()
        {
            grid.ItemsSource = new ObservableCollection<Zipcode>(list);
        }

        private void cmdSeek_Click(object sender, RoutedEventArgs e)
        {
            Seek(txtCode.Text.Trim(), txtCity.Text.Trim());
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
                SqlCommand command = new SqlCommand("INSERT INTO Zipcodes (code, city) VALUES (@Code, @City)", connection);
                command.Parameters.Add(CreateParam("@Code", txtCode.Text.Trim(), SqlDbType.NVarChar));
                command.Parameters.Add(CreateParam("@City", txtCity.Text.Trim(), SqlDbType.NVarChar));
                connection.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    Clear();
                    return;
                }
                error = "Illegal database operation";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            MessageBox.Show(error);
        }

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
                SqlCommand command = new SqlCommand("UPDATE Zipcodes SET City = @City WHERE Code = @Code", connection);
                command.Parameters.Add(CreateParam("@Code", txtCode.Text.Trim(), SqlDbType.NVarChar));
                command.Parameters.Add(CreateParam("@City", txtCity.Text.Trim(), SqlDbType.NVarChar));
                connection.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    Clear();
                    return;
                }
                error = "Illegal database operation";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            MessageBox.Show(error);
        }

        private void cmdRemove_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
                SqlCommand command = new SqlCommand("DELETE FROM Zipcodes WHERE Code = @Code", connection);
                command.Parameters.Add(CreateParam("@Code", txtCode.Text.Trim(), SqlDbType.NVarChar));
                connection.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    Clear();
                    return;
                }
                error = "Illegal database operation";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            MessageBox.Show(error);
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            grid.SelectedIndex = -1;
            txtCode.Clear();
            txtCity.Clear();
            Seek("", "");
        }

        private void Seek(string code, string city)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
                SqlCommand command = new SqlCommand("SELECT * FROM Zipcodes WHERE Code LIKE @Code AND City LIKE @City", connection);
                command.Parameters.Add(CreateParam("@Code", code + "%", SqlDbType.NVarChar));
                command.Parameters.Add(CreateParam("@City", city + "%", SqlDbType.NVarChar));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                list.Clear();
                while (reader.Read()) list.Add(new Zipcode { Code = reader[0].ToString(), City = reader[1].ToString() });
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        private SqlParameter CreateParam(string name, object value, SqlDbType type)
        {
            SqlParameter param = new SqlParameter(name, type);
            param.Value = value;
            return param;
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

        
    }
}
