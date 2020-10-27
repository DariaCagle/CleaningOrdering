using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaning.Data.Interfaces;
using Cleaning.Data.Models;
using Dapper;

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

                var insertedId = connection.Query<CleaningOrder>($"INSERT INTO orders(Phone,FullName,Date,CleaningType) OUTPUT Inserted.Id Values(\'{model.Phone}\', \'{model.FullName}\', \'{model.Date}\', \'{model.CleaningType}\')");
                model.Id = insertedId.FirstOrDefault().Id;
                return model;
            }
        }


        public CleaningOrder GetByDateTime(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<CleaningOrder>($"SELECT ord.* FROM orders as ord WHERE ord.Date = \'{date}\';").FirstOrDefault();
            }
        }

        public CleaningOrder GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<CleaningOrder>($"SELECT ord.* FROM orders as ord WHERE Id = {id};").FirstOrDefault();
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
