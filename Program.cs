using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Usuario u1 = new Usuario();
            u1.Nome = "Ana Zaira";

            Credencial c1 = new Credencial();
            c1.Email = "ana@mail.com";
            u1.Credencial = c1;

            Console.WriteLine(">> " + u1);

            UsuarioRepository.Save(u1);

            Console.WriteLine(">> " + u1);

            Usuario uAux;
            uAux = UsuarioRepository.FindById(1);

            Console.WriteLine(">> " + uAux);

            uAux = UsuarioRepository.FindByIdWCredencial(1);

            Console.WriteLine(">> " + uAux);

            u1.Nome = "Ana B. Zaira";

            UsuarioRepository.Save(u1);

            uAux = UsuarioRepository.FindById(1);

            Console.WriteLine(">> " + uAux);

            UsuarioRepository.Remove(uAux);

            Console.WriteLine("--- Main concluído ---");

        }
    }
}
