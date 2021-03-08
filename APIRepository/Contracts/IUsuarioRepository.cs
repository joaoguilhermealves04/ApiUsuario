using APIDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRepository.Contracts
{
    public interface IUsuarioRepository
    {
        void Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        List<Usuario> ObterTodos();
        Usuario ObterporId(Guid Id);
        Usuario Login(string email, string senha);
        Usuario ObterPorEmail(string email);
    }
}
