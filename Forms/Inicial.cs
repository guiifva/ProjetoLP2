using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoLP2.Model;

namespace ProjetoLP2.Forms
{
    public partial class Inicial : Form
    {

        Usuario usuarioLogado = new Usuario();

        public Inicial()
        {
            InitializeComponent();
        }

        public Inicial(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
        }


        private void Inicial_Load(object sender, EventArgs e)
        {
            if (!usuarioLogado.funcionario)
            {
                cadastroFuncionarioToolStripMenuItem.Visible = false;
                documentarTestesToolStripMenuItem.Visible = false;
            }

        }

        private void HelpdeskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (usuarioLogado.funcionario)
            {
                HelpdeskFuncionario telaHelpdeskFuncionario = new HelpdeskFuncionario();
                telaHelpdeskFuncionario.MdiParent = this;
                telaHelpdeskFuncionario.Show();

            }
            else
            {
                HelpdeskCliente telaHelpdeskCliente = new HelpdeskCliente();
                telaHelpdeskCliente.MdiParent = this;
                telaHelpdeskCliente.Show();
            }
            


        }

        private void CadastroFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroFuncionario telaCadastroFuncionario = new CadastroFuncionario();
            telaCadastroFuncionario.MdiParent = this;
            telaCadastroFuncionario.Show();
        }

        private void DocumentarTestesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Testes telaDeTestes = new Testes();
            telaDeTestes.MdiParent = this;
            telaDeTestes.Show();

        }

        private void VerTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
