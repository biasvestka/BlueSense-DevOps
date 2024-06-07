using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlueSense.Models
{
    [Table("Tb_NavioRotas")]
    public class NavioRotas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("NavioID")]
        public int? NavioID { get; set; }
        public Navio? Navio { get; set; }

        [ForeignKey("RotaID")]
        public int? RotaID { get; set; }
        public Rota? Rota { get; set; }

    }
}
