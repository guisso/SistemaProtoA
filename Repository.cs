using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace SistemaProtoA
{
    internal class Repository : DbContext
    {
        private static MySqlConnection _databaseConnection;

        public DbSet<Usuario> Usuarios { get; set; }

        public Repository() : base(GetDbConnection(), false)
        {
            Database.CreateIfNotExists();
        }

        //public Repository(DbConnection existingConnection, bool contextOwnsConnection)
        //: base(existingConnection, contextOwnsConnection)
        //{
        //    Database.CreateIfNotExists();
        //}

        public static MySqlConnection GetDbConnection()
        {
            if (_databaseConnection == null)
            {
                String connectionString = ConfigurationManager.ConnectionStrings["ProgVisConnectionString"].ConnectionString;
                _databaseConnection = new MySqlConnection(connectionString);
            }
            return _databaseConnection;
        }
    }
}
