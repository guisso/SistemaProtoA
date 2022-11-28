using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaProtoA
{
    internal class UsuarioRepository
    {
        public static void Save(Usuario usuario)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (usuario.Id == 0)
                    {
                        dbContext.Usuarios.Add(usuario);
                    }
                    else
                    {
                        dbContext.Entry(usuario).State
                            = EntityState.Modified;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindAll()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Usuario FindById(Int64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Usuario FindByIdWCredencial(Int64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios
                        .Include("Credencial")
                        .Where(u => u.Id == id)
                        .FirstOrDefault<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindByPartialName(String partialName)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios
                        .Where(u => u.Nome.Contains(partialName))
                        .ToList<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Remove(Usuario usuario)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    dbContext.Usuarios.Attach(usuario);
                    dbContext.Usuarios.Remove(usuario);

                    // OR

                    // But cascade delete fails...
                    //dbContext.Entry(usuario).State
                    //    = EntityState.Deleted;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
