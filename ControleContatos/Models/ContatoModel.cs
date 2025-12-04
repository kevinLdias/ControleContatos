using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome do contato"), MaxLength(128)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar o email do contato"),
            EmailAddress(ErrorMessage = "Formato do email incorreto"), MaxLength(128)]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário informar o número do contato"),
            Phone(ErrorMessage = "Formato do número incorreto"), MaxLength(128)]
        public string Numero { get; set; }
    }
}
