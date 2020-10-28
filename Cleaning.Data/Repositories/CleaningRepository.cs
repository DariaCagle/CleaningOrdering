using Cleaning.Data.Interfaces;
using Cleaning.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Cleaning.Data.Repositories
{
    public class CleaningRepository : ICleaningRepository
    {
        private readonly string _connectionString;
        public CleaningRepository()
        {
            _connectionString = "Data Source=.; Initial Catalog = Cleaning; Integrated Security = true";
        }


        public CleaningOrder Create(CleaningOrder model)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO orders(Phone,FullName,Date,CleaningType)" +
                    " OUTPUT Inserted.Id " +
                    $"Values(\'{model.Phone}\', \'{model.FullName}\', \'{model.Date}\', \'{model.CleaningType}\')";
                var insertedId = Convert.ToInt32(command.ExecuteScalar());
                model.Id = insertedId;
                return model;
            }
        }

        public CleaningOrder GetByDateTime(DateTime date)
        {
            var result = new List<CleaningOrder>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT ord.* FROM orders as ord " +
                    $"WHERE ord.Date = \'{date}\'";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var models = new CleaningOrder();

                    models.Id = reader.GetInt32(0);
                    models.FullName = reader.GetString(1);
                    models.Phone = reader.GetString(2);
                    models.Date = reader.GetDateTime(3);
                    models.CleaningType = reader.GetString(4);

                    result.Add(models);
                }
                reader.Close();
                var model = result.FirstOrDefault();
                return model;
            }
        }

        public CleaningOrder GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT ord.* FROM orders as ord " +
                    $"WHERE ord.Id = {id}";

                SqlDataReader reader = command.ExecuteReader();
                var model = new CleaningOrder();
                while (reader.Read())
                {
                    model.Id = reader.GetInt32(0);
                    model.FullName = reader.GetString(1);
                    model.Phone = reader.GetString(2);
                    model.Date = reader.GetDateTime(3);
                    model.CleaningType = reader.GetString(4);
                }
                reader.Close();
                return model;
            }
        }

        public IEnumerable<CleaningOrder> GetAll()
        {

            var allModels = new List<CleaningOrder>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM orders";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var model = new CleaningOrder();

                    model.Id = reader.GetInt32(0);
                    model.FullName = reader.GetString(1);
                    model.Phone = reader.GetString(2);
                    model.Date = reader.GetDateTime(3);
                    model.CleaningType = reader.GetString(4);

                    allModels.Add(model);
                }
                reader.Close();

            }
            return allModels;
        }
    }
}
