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

                    AcessoDadosMySQL.AdicionarParametros("@intUsuario", relatar.usuario);
                    AcessoDadosMySQL.AdicionarParametros("@dteData", relatar.data);
                    AcessoDadosMySQL.AdicionarParametros("@vchCategoria", relatar.categoria);
                    AcessoDadosMySQL.AdicionarParametros("@vchSoftware", relatar.software);
                    AcessoDadosMySQL.AdicionarParametros("@intPrioridade", relatar.prioridade);
                    AcessoDadosMySQL.AdicionarParametros("@vchDescricao", relatar.descricao);
                    AcessoDadosMySQL.AdicionarParametros("@vchResponsavel", relatar.setor);
                    AcessoDadosMySQL.AdicionarParametros("@vchMsgErro", relatar.msgErro);
                    AcessoDadosMySQL.AdicionarParametros("@blnStatus", relatar.status);

                    string strSQL = "INSERT INTO ticket(usuario, data, categoria, software, prioridade, descricao, responsavel, msgErro) VALUES (@vchUsuario, @dteData, @vchCategoria, @vchSoftware, @intPrioridade, @vchDescricao, @vchResponsavel, @vchMsgErro); INSERT INTO relatam ticket_id = VALUES LAST_INSERT_ID(), usuario_id = @intUsuario;";
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
                    objNovoTicket.ticketId = objLinha["ticketId"] != DBNull.Value ? Convert.ToInt32(objLinha["ticketId"]) : 0;
                    objNovoTicket.usuario = objLinha["usuario"] != DBNull.Value ? Convert.ToInt32(objLinha["usuario"]) : 0;
                    objNovoTicket.data = objLinha["data"] != DBNull.Value ? Convert.ToString(objLinha["data"]) : "2015-01-01";
                    objNovoTicket.categoria = objLinha["categoria"] != DBNull.Value ? Convert.ToString(objLinha["categoria"]) : "";
                    objNovoTicket.software = objLinha["software"] != DBNull.Value ? Convert.ToString(objLinha["software"]) : "";
                    objNovoTicket.prioridade = objLinha["prioridade"] != DBNull.Value ? Convert.ToInt32(objLinha["prioridade"]) : 0;
                    objNovoTicket.descricao = objLinha["descricao"] != DBNull.Value ? Convert.ToString(objLinha["descricao"]) : "";
                    objNovoTicket.setor = objLinha["responsavel"] != DBNull.Value ? Convert.ToString(objLinha["responsavel"]) : "";
                    objNovoTicket.msgErro = objLinha["msgErro"] != DBNull.Value ? Convert.ToString(objLinha["msgErro"]) : "";
                    objNovoTicket.status = objLinha["status"] != DBNull.Value ? Convert.ToInt32(objLinha["status"]) : 0;


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
                    //AcessoDadosMySQL.AdicionarParametros("@vchUsuario", relatar.usuario);
                    //AcessoDadosMySQL.AdicionarParametros("@dteData", relatar.data);
                    //AcessoDadosMySQL.AdicionarParametros("@vchCategoria", relatar.categoria);
                    //AcessoDadosMySQL.AdicionarParametros("@vchSoftware", relatar.software);
                    //AcessoDadosMySQL.AdicionarParametros("@intPrioridade", relatar.prioridade);
                    //AcessoDadosMySQL.AdicionarParametros("@vchDescricao", relatar.descricao);
                    //AcessoDadosMySQL.AdicionarParametros("@vchResponsavel", relatar.responsavel);
                    //AcessoDadosMySQL.AdicionarParametros("@vchMsgErro", relatar.msgErro);
                    //AcessoDadosMySQL.AdicionarParametros("@blnStatus", relatar.status);


                    string strSQL = "UPDATE ticket SET status = blnStatus WHERE ticketId = @intticketId; select @intTicketId";
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
                    string strSQL = "DELETE FROM tickets WHERE ticketId = @vchTicketId; select @vchTicketId;";
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
