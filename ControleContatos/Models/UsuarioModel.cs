using ControleContatos.Enums;
using ControleContatos.Helper;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do usuário"), MaxLength(128)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "É necessário informar o email do usuário"),
        EmailAddress(ErrorMessage = "Formato do email incorreto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário informar o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "É necessário informar a senha do usuário"), MinLength(8, ErrorMessage = "A senha deve ter no minimo 8 digítos"),
            MaxLength(35)]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? Atualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Criptografia.ValidarSenha(senha, Senha);
        }
        public void SetHashSenha()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();

            return novaSenha;
        }
    }
}
