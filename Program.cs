using System;

namespace SistemaProtoA
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Console.WriteLine("--- Main iniciado ---");

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            // --

            Usuario u1 = new Usuario();
            u1.Nome = "Ana Zaira";

            Credencial c1 = new Credencial();
            c1.Email = "ana@mail.com";
            c1.Senha = "123456";
            c1.Administrador = true;

            u1.Credencial = c1;
            c1.Usuario = u1;

            Console.WriteLine(">> new Usuario(): u1: " + u1);
            Console.WriteLine(">> new Credencial(): c1: " + c1);

            // --

            Usuario u2 = new Usuario();
            u2.Nome = "Cristiana Xolmes";

            Credencial c2 = new Credencial();
            c2.Email = "cristiana@mail.com";
            c2.Senha = "123456";

            u2.Credencial = c2;
            c2.Usuario = u2;

            Console.WriteLine(">> new Usuario(): u2: " + u2);
            Console.WriteLine(">> new Credencial(): c2: " + c2);

            // --

            UsuarioRepository.Save(u1);
            UsuarioRepository.Save(u2);

            Console.WriteLine(">> .Save(u1/c1): " + u1 + " / " + c1);
            Console.WriteLine(">> .Save(u2/c2): " + u2 + " / " + c2);

            // --

            Usuario u3 = new Usuario();
            u3.Nome = "Cristiana Yana";

            Credencial c3 = new Credencial();
            // Pre-existing email
            c3.Email = "cristiana@mail.com";
            c3.Senha = "123456";

            u3.Credencial = c3;
            c3.Usuario = u3;

            try
            {
                UsuarioRepository.Save(u3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">> .Save(u3): [" + (UInt64)ex.HResult 
                    + " | " + ex.GetHashCode()
                    + "] Can't save two users with same email");
            }


            // --

            Usuario uAux;
            uAux = UsuarioRepository.FindById(1);

            Console.WriteLine(">> .FindById(1): " + uAux);

            // --

            uAux = UsuarioRepository.FindByIdWCredencial(1);

            Console.WriteLine(">> .FindByIdWCredencial(1): " + uAux);

            // --

            u1.Nome = "Ana B. Zaira";

            UsuarioRepository.Save(u1);

            uAux = UsuarioRepository.FindById(1);

            Console.WriteLine(">> .Save(u1) + .FindById(1): " + uAux);

            // --

            Console.WriteLine(">> .FindByPartialName(\"ana\"): "
                + String.Join("; ", UsuarioRepository.FindByPartialName("ana")));

            Console.WriteLine(">> .FindByPartialName(\"AI\"): "
                + String.Join("; ", UsuarioRepository.FindByPartialName("AI")));

            // --

            try
            {
                UsuarioRepository.Remove(uAux);
                Console.WriteLine(">> .Remove(uAux): User #1 removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(">> Remove(uAux): [" + (UInt64)ex.HResult
                    + " | " + ex.GetHashCode()
                    + "] Removal attempt without loading dependent objects fails");
            }

            // --

            uAux = UsuarioRepository.FindByIdWCredencial(2);

            Console.WriteLine(">> .FindByIdWCredencial(2): " + uAux);

            UsuarioRepository.Remove(uAux);

            Console.WriteLine(">> .Remove(uAux): User #2 removed");

            Console.WriteLine("--- Main concluído ---");

        }
    }
}
