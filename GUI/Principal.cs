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
    public partial class Principal: Form
    {
        BotService botService;
        public Principal()
        {
            InitializeComponent();
            botService = new BotService();
        }

        private void mENUUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            botService.Bot();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuario());
        }
    }
}
