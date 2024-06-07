using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueSense.Models
{
    [Table("Tb_UsuariosAutoridade")]
    public class UsuarioAutoridade : Usuario
    {
        [Required(ErrorMessage = "O departamento é obrigatório.")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

    }
}
