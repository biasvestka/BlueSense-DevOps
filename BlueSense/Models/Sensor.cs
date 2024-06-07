using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlueSense.Models
{
    [Table("Tb_Sensores")]
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public string Status { get; set; }

        [ForeignKey("NavioID")]
        public int? NavioID { get; set; }
        public Navio? Navio { get; set; }
    }
}
