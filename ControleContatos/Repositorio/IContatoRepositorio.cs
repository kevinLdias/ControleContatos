using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        ICollection<ContatoModel> ListarTodos(int usuarioId);
        ContatoModel Adicionar(ContatoModel contato);
        bool Deletar(int id);
        ContatoModel Editar(ContatoModel contato);
    }
}
