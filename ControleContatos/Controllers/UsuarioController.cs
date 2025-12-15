using ControleContatos.Filters;
using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [SomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.ListarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Excluir(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ListarContatosPorUsuarioId(int usuarioId)
        {
            var contatos = _contatoRepositorio.ListarTodos(usuarioId);
            return PartialView("_ContatosUsuario", contatos);        
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar usuário... detalhes do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeletarDefinitivo(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Deletar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir o usuário";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao tentar excluir o usuário... detalhes do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                ModelState.Remove("Senha");
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro na alteração contato... detalhes do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
