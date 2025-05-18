using BLL;
using ENTITY;
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
    public partial class FrmUsuario: Form
    {
        UsuarioService usuarioService;
        public FrmUsuario()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void FrmGuardarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Usuario(txtbDocumento.Text,txtbNombre.Text,txtbApellido.Text,txtbTelefono.Text));
            Limpiar();
        }

        private void Limpiar()
        {
            txtbDocumento.Text = string.Empty;
            txtbNombre.Text = string.Empty;
            txtbApellido.Text = string.Empty;
            txtbTelefono.Text = string.Empty;
        }

        private void Guardar(Usuario usuario)
        {
            var mensaje = usuarioService.Guardar(usuario);
            MessageBox.Show(mensaje);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConsultaUsuario());
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
