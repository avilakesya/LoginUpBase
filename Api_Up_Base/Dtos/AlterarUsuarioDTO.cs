using System.ComponentModel.DataAnnotations;

namespace Api_Up_Base.Dtos {
    public class AlterarUsuarioDTO {

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo usuario é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
    }
}
