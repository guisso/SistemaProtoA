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
            // If database not exists, create it ...
            if (Database.CreateIfNotExists())
            {
                // ... and...
                Repository repositorio = this;

                // ... insert a default administrator
                Usuario administradorPadrao = new Usuario();
                administradorPadrao.Nome = "Admin";

                Credencial credencialPadrao = new Credencial();
                credencialPadrao.Email = "admin@mail.com";
                credencialPadrao.Senha = "xyz098";
                credencialPadrao.Administrador = true;

                credencialPadrao.Usuario = administradorPadrao;
                administradorPadrao.Credencial = credencialPadrao;

                repositorio.Usuarios.Add(administradorPadrao);
                repositorio.SaveChanges();
            }
        }

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
