using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel ListarPorId(int id);
        ICollection<UsuarioModel> ListarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        bool Deletar(int id);
        UsuarioModel Editar(UsuarioModel usuario);

        UsuarioModel RedefinirSenha(UsuarioModel usuario);

    }
}
