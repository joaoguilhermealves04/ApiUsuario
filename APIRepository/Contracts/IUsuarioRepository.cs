using APIDamain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRepository.Contracts
{
    public interface IUsuarioRepository
    {
        void Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Guid usuarioId);
        List<Usuario> ObterTodos();
        List<Usuario> ObterporNome(string nome);
        List<Usuario> ObterPorEmail(string email);
        Usuario ObterporId(Guid Id);
    }
}
