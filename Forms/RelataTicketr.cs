using MySql.Data.MySqlClient;
using Projeto.ConnectionBD;
using Projeto.Model;
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
    
    public partial class RelatarTicket : Form
    {
        //private static string strConexao = "Server=127.0.0.1; Port=5432; User Id=postgres;Password=06121998;Database=Banco01;";
        //public static NpgsqlConnection conn { get; set; }

        public RelatarTicket()
        {
            
            InitializeComponent();
            /*try
            {
               conn = new NpgsqlConnection(strConexao);
               conn.Open();
               NpgsqlCommand sql = new NpgsqlCommand("select * from reportar_erros", conn);
               sql.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            //Grid;
            //colocar o id no protocolo    
            //tbData.Text = Convert.ToString (DateTime.Now.Date.ToString("dd-MM-yyyy")).ToString();
            //Pegar o usuario do banco
            */
        }

        private bool Verifica(String usuario, String software)
        {
            if (usuario == "")
            {
                MessageBox.Show("Preencha corretamente o campo usuário!");
                return false;
            }
            else if (software == "")
            {
                MessageBox.Show("Preencha corretamente o campo software!");
                return false;
            }
            else return false;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // tbUsuario.Text{ get};
           
            String usuario=(tbUsuario.Text);
            String software = (tbSoftware.Text);
            String descricao = tbDescricao.Text;
            String responsavel = tbResponsavel.Text;
            String tela = tbTela.Text;
            String prazo = tbPrazo.Text;
            String erro = tbErro.Text;
            String categoria = tbCategoria.Text;

            RelatarClass rel = new RelatarClass();
            rel.categoria = categoria;
            rel.data = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MM-yyyy"));
            rel.descricao = descricao;
            rel.erro = erro;
            rel.tela = tela;
            rel.software = software;
            rel.prazo = prazo;

            RelatarDAO dao = new RelatarDAO();
            dao.create(rel);

            //Fazer a verificação
            // bool ver= Verifica(usuario, software);
            // if (ver == true)
            //{
            //MessageBox.Show("entra no if");
            // Conexao.Conecta();

            //SqlCommand cmd = new SqlCommand(escolha o insert ou update, con);

            // NpgsqlCommand sql = new NpgsqlCommand(sql, conn);
            /* String sql = "INSERT INTO reportar_erros( usuario, software, erro) VALUES ('"+usuario+"', '"+software+"' , '"+erro+"');";
                 Conexao con = new Conexao();
                 con.inserir(sql);
             tbUsuario.Text=("");

             tbSoftware.Text = "";
             tbErro.Text = "";*/



            //NpgsqlCommand sql2 = new NpgsqlCommand("select * from reportar_erros",Conecta.conn);
            //sql2.ExecuteNonQuery();
            // }

            //con.selecionar();
            //Conexao.Conecta();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Relatar_Load(object sender, EventArgs e)
        {

        }

        private void tbDescricao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
