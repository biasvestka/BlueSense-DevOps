using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueSense.Models
{
    [Table("Tb_Rotas")]
    public class Rota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O origem é obrigatório.")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "O destino é obrigatório.")]
        public string Destino { get; set; }

    }
}
