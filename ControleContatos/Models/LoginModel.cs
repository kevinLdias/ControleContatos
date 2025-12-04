using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "É necessário informar o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 dígitos")]
        [MaxLength(35, ErrorMessage = "A senha deve ter no máximo 35 dígitos")]
        public string Senha { get; set; }

    }
}
