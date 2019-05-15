using MySql.Data.MySqlClient;
using Projeto.Model;
using ProjetoLP2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto.ConnectionBD
{
    class RelatarDAO
    {
        public bool create(Ticket relatar)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null;
                if (relatar != null)
                {

                    AcessoDadosMySQL.AdicionarParametros("@vchusuario", relatar.usuario);
                    AcessoDadosMySQL.AdicionarParametros("@vchdata", relatar.data);
                    AcessoDadosMySQL.AdicionarParametros("@vchsoftware", relatar.software);
                    AcessoDadosMySQL.AdicionarParametros("@vchcategoria", relatar.categoria);
                   // AcessoDadosMySQL.AdicionarParametros("@vcherro", relatar.erro);
                    AcessoDadosMySQL.AdicionarParametros("@vchdescricao", relatar.descricao);
                    AcessoDadosMySQL.AdicionarParametros("@vchresponsavel", relatar.responsavel);
                    //AcessoDadosMySQL.AdicionarParametros("@vchSituacao", relatar.situacao);

                    string strSQL = "INSERT INTO ticket( usuario, data_criacao,  software, categoria, prazo, erro, descricao, responsavel, tela) VALUES (@vchusuario, @vchdata, @vchsoftware, @vchcategoria, @vchprazo, @vcherro, @vchdescricao, @vchresponsavel, @vchtela)";
                    //"INSERT INTO reportar_erros( usuario, software, erro) VALUES ('"+usuario+"', '"+software+"' , '"+erro+"');";
                    //string strSQL = "insert into usuarios (nome, login, senha, funcionario) values (@vchNome, @vchLogin, @vchSenha, @bolfuncionario);SELECT LAST_INSERT_ID();";
                    objRetorno = AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }
                int intResultado = 0;

                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Ticket> list()
        {
            List<Ticket> lista = new List<Ticket>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca 
                string strSQL = "select * from ticket";

                objDataTable = AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);

                if (objDataTable.Rows.Count <= 0)
                {
                    return lista;
                }
                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Ticket objNovoTicket = new Ticket();
                    //objNovoTicket.protocolo = objLinha["protocolo"] != DBNull.Value ? Convert.ToInt32(objLinha["protocolo"]) : 0;
                    objNovoTicket.usuario = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovoTicket.data = objLinha["data"] != DBNull.Value ? Convert.ToDateTime(objLinha["data"]) : DateTime.Now;
                    objNovoTicket.software = objLinha["software"] != DBNull.Value ? Convert.ToString(objLinha["software"]) : "";
                    objNovoTicket.categoria = objLinha["categoria"] != DBNull.Value ? Convert.ToString(objLinha["categoria"]) : "";
                    objNovoTicket.descricao = objLinha["descricao"] != DBNull.Value ? Convert.ToString(objLinha["descricao"]) : "";
                   // objNovoTicket.situacao = objLinha["situacao"] != DBNull.Value ? Convert.ToString(objLinha["situacao"]) : "";
                    //objNovoTicket.erro = objLinha["erro"] != DBNull.Value ? Convert.ToString(objLinha["erro"]) : "";


                    lista.Add(objNovoTicket);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool edit(Ticket relatar)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null;
                if (relatar != null)
                {
                    //AcessoDadosMySQL.AdicionarParametros("@vchProtocolo", relatar.protocolo);
                    AcessoDadosMySQL.AdicionarParametros("@vchusuario", relatar.usuario);
                    AcessoDadosMySQL.AdicionarParametros("@vchdata", relatar.data);
                    AcessoDadosMySQL.AdicionarParametros("@vchsoftware", relatar.software);
                    AcessoDadosMySQL.AdicionarParametros("@vchcategoria", relatar.categoria);
                    //AcessoDadosMySQL.AdicionarParametros("@vcherro", relatar.erro);
                    AcessoDadosMySQL.AdicionarParametros("@vchdescricao", relatar.descricao);
                    AcessoDadosMySQL.AdicionarParametros("@vchresponsavel", relatar.responsavel);
                    //AcessoDadosMySQL.AdicionarParametros("@vchSituacao", relatar.situacao);

                    string strSQL = "update ticket set situacao = @vchSituacao where protocolo = @intProtocolo;select @intProtocolo";
                    objRetorno = AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }
                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool delete(Ticket ticket)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null; if (ticket != null)
                {
                   // AcessoDadosMySQL.AdicionarParametros("@vchProtocolo", ticket.protocolo);
                    string strSQL = "delete from tickets where id = @vchProtocolo; select @vchProtocolo;";
                    objRetorno = AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }
                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
