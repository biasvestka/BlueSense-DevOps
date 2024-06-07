using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueSense.Models
{
    [Table("Tb_LeiturasSensores")]
    public class LeituraSensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O protocolo é obrigatória.")]
        public string Protocolo { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O local é obrigatório.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Column("Valor", TypeName = "NUMBER(1,0)")]
        public bool Valor { get; set; }

        [ForeignKey("NavioID")]
        public int? NavioID { get; set; }
        public Navio? Navio { get; set; }

        [ForeignKey("RotaID")]
        public int? RotaID { get; set; }
        public Rota? Rota { get; set; }

    }
}
