//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repo_Pattern_Practice.Repository
//{
//    public abstract class GenericRepository<T> : IRepository<T> where T : class
//    {

//        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate)
//        {
//            throw new NotImplementedException();
//        }

//        public T Insert(T entity)
//        {
//            string error = "";
//            SqlConnection connection = null;
//            try
//            {
//                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
//                SqlCommand command = new SqlCommand("INSERT INTO Zipcodes (code, city) VALUES (@Code, @City)", connection);
//                command.Parameters.Add(CreateParam("@Code", txtCode.Text.Trim(), SqlDbType.NVarChar));
//                command.Parameters.Add(CreateParam("@City", txtCity.Text.Trim(), SqlDbType.NVarChar));
//                connection.Open();
//                if (command.ExecuteNonQuery() == 1)
//                {
//                    Clear();
//                    return;
//                }
//                error = "Illegal database operation";
//            }
//            catch (Exception ex)
//            {
//                error = ex.Message;
//            }
//            finally
//            {
//                if (connection != null) connection.Close();
//            }
//            MessageBox.Show(error);
//        }

//        public T Update(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public T Delete(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
