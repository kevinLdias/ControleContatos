using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual do usúario.")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha do usúario.")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha do usúario.")]
        [Compare("NovaSenha", ErrorMessage = "A senha não confere com a nova senha.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
