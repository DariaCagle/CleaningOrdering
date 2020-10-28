using Cleaning.Data.Interfaces;
using Cleaning.Data.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Cleaning.Data.Repositories
{
    public class CleaningDapperRepository : ICleaningRepository
    {

        private readonly string _connectionString;

        public CleaningDapperRepository()
        {
            _connectionString = "Data Source=.; Initial Catalog = Cleaning; Integrated Security = true";
        }

        public CleaningOrder Create(CleaningOrder model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var insertedModel = connection.QueryFirstOrDefault<CleaningOrder>($"INSERT INTO orders(Phone,FullName,Date,CleaningType) Values(\'{model.Phone}\', \'{model.FullName}\', \'{model.Date}\', \'{model.CleaningType}\')");
                model.Id = insertedModel.Id;
                return model;
            }
        }


        public CleaningOrder GetByDateTime(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<CleaningOrder>($"SELECT ord.* FROM orders as ord WHERE ord.Date = \'{date}\';");
            }
        }

        public CleaningOrder GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<CleaningOrder>($"SELECT ord.* FROM orders as ord WHERE Id = {id};");
            }
        }

        public IEnumerable<CleaningOrder> GetAll()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<CleaningOrder>("SELECT * FROM orders;");
            }
        }
    }
}
