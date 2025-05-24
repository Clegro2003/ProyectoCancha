using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmConsultaUsuario: Form
    {
        UsuarioService usuarioService;
        ReservaService r = new ReservaService();
        public FrmConsultaUsuario()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void CargarUsuario()
        {
            //var lista = usuarioService.Consultar();
            var lista = r.Consultar();

            dgv.DataSource = lista;
        }


        private void FrmConsultaUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuario();
        }
    }
}
