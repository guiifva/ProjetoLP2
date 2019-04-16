using MySql.Data.MySqlClient;
using ProjetoLP2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLP2.DAL
{
    class UsuarioDAO
    {
        public bool create(Usuario usuario)
        {
            try
            {
                AcessoDadosMySQL.LimparParametros();
                object objRetorno = null;
                if (usuario != null)
                {

                    AcessoDadosMySQL.AdicionarParametros("@vchNome", usuario.nome);
                    AcessoDadosMySQL.AdicionarParametros("@vchLogin", usuario.login);
                    AcessoDadosMySQL.AdicionarParametros("@vchSenha", usuario.senha);
                    AcessoDadosMySQL.AdicionarParametros("@bolPermissao", usuario.permissao);

                    string strSQL = "insert into usuarios (nome, login, senha, permissao) values (@vchNome, @vchLogin, @vchSenha, @bolPermissao);SELECT LAST_INSERT_ID();";
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

        public List<Usuario> list()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca 
                string strSQL = "select Id, nome from usuarios";
                objDataTable = AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)
                {
                    return lista;
                }
                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Usuario objNovaUsuario = new Usuario();
                    objNovaUsuario.id = objLinha["id"] != DBNull.Value ? Convert.ToInt32(objLinha["id"]) : 0;
                    objNovaUsuario.nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovaUsuario.login = objLinha["login"] != DBNull.Value ? Convert.ToString(objLinha["login"]) : "";
                    objNovaUsuario.permissao = objLinha["permissao"] != DBNull.Value ? Convert.ToBoolean(objLinha["permissao"]) : false;

                    lista.Add(objNovaUsuario);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool edit(Usuario usuario)
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

        public bool delete(Usuario usuario)
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

        public List<Usuario> verificaLogin(Usuario usuario)
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                AcessoDadosMySQL.LimparParametros();
                DataTable objDataTable = null;

                //Se quiser personalizar a busca 
                AcessoDadosMySQL.AdicionarParametros("@vchLogin", usuario.login);
                AcessoDadosMySQL.AdicionarParametros("@vchSenha", usuario.senha);

                string strSQL = "select id, nome, login, permissao from usuarios WHERE login = @vchLogin AND senha = @vchSenha";

                objDataTable = AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count == 0)
                {
                    return lista;
                }
                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Usuario objNovaUsuario = new Usuario();
                    objNovaUsuario.id = objLinha["id"] != DBNull.Value ? Convert.ToInt32(objLinha["id"]) : 0;
                    objNovaUsuario.nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovaUsuario.login = objLinha["login"] != DBNull.Value ? Convert.ToString(objLinha["login"]) : "";
                    objNovaUsuario.permissao = objLinha["permissao"] != DBNull.Value ? Convert.ToBoolean(objLinha["permissao"]) : false;
                    lista.Add(objNovaUsuario);
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return lista;
            }
        }
    }

}
