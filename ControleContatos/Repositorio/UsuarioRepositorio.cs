using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio

    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ICollection<UsuarioModel> ListarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(
                x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper()
            );
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //usuario.DataCadastro = DateTime.Now;
            usuario.SetHashSenha();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioWillBeDeleted = ListarPorId(id);

            if (usuarioWillBeDeleted == null)
            {
                throw new Exception("Erro ao deletar o usuário");
            }

            _bancoContext.Usuarios.Remove(usuarioWillBeDeleted);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioAtt = ListarPorId(usuario.Id);

            if (usuarioAtt == null)
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }

            usuarioAtt.Nome = usuario.Nome;
            usuarioAtt.Login = usuario.Login;
            usuarioAtt.Email = usuario.Email;
            usuarioAtt.Perfil = usuario.Perfil;
            usuarioAtt.Atualizacao = DateTime.Now;

            _bancoContext.SaveChanges();

            return usuarioAtt;
        }
        public UsuarioModel RedefinirSenha(UsuarioModel usuario)
        {
            UsuarioModel usuarioAtt = ListarPorId(usuario.Id);

            if (usuarioAtt == null)
            {
                throw new Exception("Houve um erro na atualização da senha");
            }
            usuario.Senha = usuarioAtt.Senha;
            usuarioAtt.Atualizacao = DateTime.Now;

            _bancoContext.SaveChanges();

            return usuarioAtt;
        }
        public UsuarioModel AlterarSenha(AlterarSenhaModel usuario)
        {
            UsuarioModel usuarioAtt = ListarPorId(usuario.Id);

            if(usuario == null) 
            {
                throw new Exception("Houve um erro na alteração da senha. Usúario não encontrado!");
            }

            if(!usuarioAtt.SenhaValida(usuario.SenhaAtual)) 
            {
                throw new Exception("Senha atual não confere");
            }

            if(usuarioAtt.SenhaValida(usuario.NovaSenha))
            {
                throw new Exception("Nova senha deve ser diferente da atual");
            }

            usuarioAtt.SetNovaSenha(usuario.NovaSenha);

            usuarioAtt.Atualizacao = DateTime.Now;

            _bancoContext.SaveChanges();

            return usuarioAtt;

        }
    }
}
