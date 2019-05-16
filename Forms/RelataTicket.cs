using MySql.Data.MySqlClient;
using Projeto.ConnectionBD;
using Projeto.Model;
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
    
    public partial class RelatarTicket : Form
    {
        private Usuario usuarioLogado;

        public RelatarTicket()
        {
            
            InitializeComponent();
           
        }
        public RelatarTicket(Usuario usuarioLogado)
        {
            InitializeComponent();
            this.usuarioLogado = usuarioLogado;

        }

        public bool verifica()
        {
            string[] texts = new string[8];

            texts[0] = txb_Usuario.Text;
            texts[1] = txb_Date.Text;
            texts[2] = txb_Categoria.Text;
            texts[3] = txb_Software.Text;
            texts[4] = txb_Prazo.Text;
            texts[5] = txb_Descricao.Text;
            texts[6] = txb_Setor.Text;
            texts[7] = txb_Erro.Text;
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i] == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }
        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (verifica())
            {
                var ticket = new Ticket();

                ticket.usuario = usuarioLogado.usuarioId;

                var arrayData = txb_Date.Text.Split('/');
                string data = (arrayData[2] + "-" + arrayData[1] + "-" + arrayData[0]);
                ticket.data = data;

                ticket.categoria = txb_Categoria.Text;
                ticket.software = txb_Software.Text;

                switch (txb_Prioridade.Text)
                {
                    case "Baixa": ticket.prioridade = 0;
                        break;
                    case "Média": ticket.prioridade = 1;
                        break;
                    case "Alta": ticket.prioridade = 2;
                        break;
                    default: ticket.prioridade = 0;
                        break;
                }

                ticket.descricao = txb_Descricao.Text;
                ticket.setor = txb_Setor.Text;
                ticket.msgErro = txb_Erro.Text;

                var ticketDAO = new RelatarDAO();
                try
                {
                    ticketDAO.create(ticket);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Preencha corretamente todas os Campos");
            }
            
            

        


        }

        private void RelatarTicket_Load(object sender, EventArgs e)
        {
            txb_Usuario.Text = usuarioLogado.nome;

          
            

        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
