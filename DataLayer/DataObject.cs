using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataLayer
{
    public class DataObject
    {
        private readonly string _connectionString;

        public DataObject()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public string ConnectionString => _connectionString;
    }
}