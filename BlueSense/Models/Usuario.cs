using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlueSense.Models
{
    [Table("Tb_Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        [NotMapped]
        public string SenhaCensurada
        {
            get
            {
         
                if (!string.IsNullOrEmpty(Senha))
                {
                    return new string('*', Senha.Length);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
