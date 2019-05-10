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
        public bool create(RelatarClass relatar)
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
                    AcessoDadosMySQL.AdicionarParametros("@vchprazo", relatar.prazo);
                    AcessoDadosMySQL.AdicionarParametros("@vcherro", relatar.erro);
                    AcessoDadosMySQL.AdicionarParametros("@vchdescricao", relatar.descricao);
                    AcessoDadosMySQL.AdicionarParametros("@vchresponsavel", relatar.responsavel);
                    AcessoDadosMySQL.AdicionarParametros("@vchtela", relatar.tela);

                    string strSQL = "INSERT INTO reportar_erros( usuario, data_criacao,  software, categoria, prazo, erro, descricao, responsavel, tela) VALUES (@vchusuario, @vchdata, @vchsoftware, @vchcategoria, @vchprazo, @vcherro, @vchdescricao, @vchresponsavel, @vchtela)";
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

        public List<RelatarClass> list()
        {
            List<RelatarClass> lista = new List<RelatarClass>();
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
                    RelatarClass objNovoTicket = new RelatarClass();
                    objNovoTicket.protocolo = objLinha["protocolo"] != DBNull.Value ? Convert.ToInt32(objLinha["protocolo"]) : 0;
                    objNovoTicket.usuario = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovoTicket.data = objLinha["data"] != DBNull.Value ? Convert.ToDateTime(objLinha["data"]) : DateTime.Now.GetDateTimeFormats() ;
                    objNovoTicket.software = objLinha["funcionario"] != DBNull.Value ? Convert.ToBoolean(objLinha["funcionario"]) : false;

                    lista.Add(objNovoTicket);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        /*public bool edit(RelatarClass usuario)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null;
                if (usuario != null)
                {
                    AcessoDadosMySQL.AdicionarParametros("@intId", usuario.id);
                    AcessoDadosMySQL.AdicionarParametros("@vchNome", usuario.nome);
                    AcessoDadosMySQL.AdicionarParametros("@vchLogin", usuario.login);
                    AcessoDadosMySQL.AdicionarParametros("@vchSenha", usuario.senha);

                    string strSQL = "update usuarios set nome = @vchNome, login = @vchLogin, senha = @vchSenha where Id = @intId;select @intId;";
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
        *//*
        public bool delete(RelatarClass usuario)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null; if (usuario != null)
                {
                    AcessoDadosMySQL.AdicionarParametros("@intId", usuario.id);
                    string strSQL = "delete from usuarios where id = @intId;select @intId;";
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
        */
        /*public List<RelatarClass> verificaLogin(RelatarClass usuario)
        {
            List<RelatarClass> lista = new List<RelatarClass>();
            try
            {
                AcessoDadosMySQL.LimparParametros();
                DataTable objDataTable = null;

                //Se quiser personalizar a busca 
                AcessoDadosMySQL.AdicionarParametros("@vchLogin", usuario.login);
                AcessoDadosMySQL.AdicionarParametros("@vchSenha", usuario.senha);

                string strSQL = "select id, nome, login, funcionario from usuarios WHERE login = @vchLogin AND senha = @vchSenha";

                objDataTable = AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count == 0)
                {
                    return lista;
                }
                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    RelatarClass objNovoTicket = new RelatarClass();
                    objNovoTicket.id = objLinha["id"] != DBNull.Value ? Convert.ToInt32(objLinha["id"]) : 0;
                    objNovoTicket.nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovoTicket.login = objLinha["login"] != DBNull.Value ? Convert.ToString(objLinha["login"]) : "";
                    objNovoTicket.funcionario = objLinha["funcionario"] != DBNull.Value ? Convert.ToBoolean(objLinha["funcionario"]) : false;
                    lista.Add(objNovoTicket);
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return lista;
            }
        }*/
    }
}
