using System.ComponentModel.DataAnnotations;

namespace EstudoWeb.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress(ErrorMessage = "O email é invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Telefone do contato")]
        [Phone(ErrorMessage = "O numero de telefone é invalido")]
        public string Phone { get; set; }
    }
}
