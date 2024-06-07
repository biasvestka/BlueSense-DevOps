using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueSense.Models
{
    [Table("Tb_Notificacoes")]
    public class Notificacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "A Data e Hora são obrigatórias.")]
        public DateTime DataHora { get; set; }

        [ForeignKey("UsuarioAutoridadeID")]
        public int? UsuarioAutoridadeID { get; set; }
        public UsuarioAutoridade? UsuarioAutoridade { get; set; }

        [ForeignKey("LeituraSensorID")]
        public int? LeituraSensorID { get; set; }
        public LeituraSensor? LeituraSensor { get; set; }
    }
}
