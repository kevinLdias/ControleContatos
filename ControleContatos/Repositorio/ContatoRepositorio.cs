using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio

    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ICollection<ContatoModel> ListarTodos(int usuarioId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public bool Deletar(int id)
        {
            ContatoModel contatoWillBeDeleted = ListarPorId(id);

            if (contatoWillBeDeleted == null)
            {
                throw new Exception("Erro ao deletar o contato");
            }

            _bancoContext.Contatos.Remove(contatoWillBeDeleted);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoAtt = ListarPorId(contato.Id);
            
            if(contatoAtt == null) 
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            contatoAtt.Nome = contato.Nome; 
            contatoAtt.Email = contato.Email; 
            contatoAtt.Numero = contato.Numero;

            _bancoContext.SaveChanges();

            return contatoAtt;
        }

    }
}
