using MySql.Data.MySqlClient;
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

namespace ProjetoLP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if(txbLogin.TextLength > 3 && txbSenha.TextLength > 4)
            {
                string login = txbLogin.Text;
                string senha = txbSenha.Text;

                Usuario usuario = new Usuario();

                usuario.login = login;
                usuario.senha = senha;

                UsuarioDAO dao = new UsuarioDAO();
                if (dao.verificaLogin(usuario))
                {
                    MessageBox.Show("Parabens logado!" + login + senha);
                }
                else
                {
                    MessageBox.Show("Insira um login valido" + login + senha);
                }
            }
            else
            {
                MessageBox.Show("Informações invalidas!\nVerifique o numero de caracteres.");
            }
        }
    }
}
