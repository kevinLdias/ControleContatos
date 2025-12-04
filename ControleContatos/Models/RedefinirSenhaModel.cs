using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "É necessário informar o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar o email")]
        public string Email { get; set; }

    }
}
