using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class Program
    {
       static void Main()
        {
            //UsuarioService usuario = new UsuarioService();

            //BaseDatos baseDatos = new BaseDatos();
            //Console.WriteLine(baseDatos.AbrirConexion());
            //usuario.Consultar();
            //Console.ReadKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Reporte());
        }
    }
}
