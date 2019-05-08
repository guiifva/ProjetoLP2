using ProjetoLP2.DAL;
using ProjetoLP2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLP2.Forms
{
    public partial class CadastroFuncionario : Form
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void Btn_salvar_Click(object sender, EventArgs e)
        {
            if (txb_nome.TextLength < 3)
            {
                MessageBox.Show("Erro: O nome precisa ter mais de 3 caracteres");
            }
            else if (txb_login.TextLength < 4)
            {
                MessageBox.Show("Erro: O Login precisa ter mais de 4 caracteres");
            }
            else if (txb_senha.TextLength < 8)
            {
                MessageBox.Show("Erro: A senha deve possuir ao menos 8 caracteres");
            }
            else
            {
                Usuario usuario = new Usuario();
                UsuarioDAO dao = new UsuarioDAO();

                usuario.nome = txb_nome.Text;
                usuario.login = txb_login.Text;
                usuario.senha = txb_senha.Text;
                usuario.funcionario = true;

                try
                {
                    dao.create(usuario);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                this.Dispose();
                MessageBox.Show("Usuario criado com sucesso!");
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
