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
            var query = @"UPDATE CadastroUsuario Set  Nome = @Nome, Senhar = @Senhar, DataAlteracao = @DataAlteracao where Id= @Id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, usuario);
            }

        }

        public void Excluir(Usuario usuario)
        {
            var query = "Delete From CadastroUsuario where Id=@Id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, usuario);
            }
        }

        public void Inserir(Usuario usuario)
        {
            var query = "Insert into CadastroUsuario (Id,Nome,Email,Senhar,DataCadastro,DataAlteracao)values(@Id,@Nome,@Email,@Senhar,@DataCadastro,@DataAlteracao)";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, usuario);

            }
        }

        public Usuario Login(string email, string senha)
        {
            var query = "Select * From CadastroUsuario Where Email=@email AND Senhar=@senha";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query, new { email, senha }).FirstOrDefault();
            }

        }

        public Usuario ObterPorEmail(string email)
        {
            var query = "Select * From CadastroUsuario Where Email=@email";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Usuario>(query, new { email }).FirstOrDefault();
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
