using APIDomain.Entities;
using APIRepository.Contracts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace APIRepository.Repositories
{


    public class UsuarioRepository : IUsuarioRepository
    {
        #region ConnectionString 
        private string connectionstring;

        public UsuarioRepository()
        {
            connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APICadastroAutenticação;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        

        #endregion

        public void Alterar(Usuario usuario)
        {
            var query = "UPDATE CadastroUsuario Set  Nome=@Nome ,Senhar=@Senhar ,DataAlteracao=@DataAlteracao where Id=@Id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query);
            }
            
        }

        public void Excluir(Guid usuarioId)
        {
            var query = "Delete From CadastroUsuario where Id=@Id";

            using(var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, new { usuarioId });
            }
        }

        public void Inserir(Usuario usuario)
        {
            var query = "Insert into CadastroUsuario (Id,Nome,Email,Senhar,DataCadastro,DataAltercao)values(@Id,@Nome,@Email,@Senhar,@DataCadastro,@DataAlteracao)";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, usuario);

            }
        }

        public List<Usuario> ObterPorEmail(string email)
        {
            var query = "Select * From CadastroUsuario Where Email=@Email ORDER BY NOME";

            using(var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query, new { email }).ToList();
            }

        }

        public Usuario ObterporId(Guid Id)
        {
            var query = "Select * From CadastroUsuario Where Id=@Id";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query, new { Id }).FirstOrDefault();
            }
        }

        public List<Usuario> ObterporNome(string nome)
        {
            var query = "Select * From CadastroUsuario Where Nome=@Nome ORDER BY NOME";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query, new { nome }).ToList();
            }
        }

        public List<Usuario> ObterTodos()
        {
            var query = "Select * From CadastroUsuario  ORDER BY NOME";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }
    }
}
