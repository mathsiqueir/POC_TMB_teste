using System.ComponentModel.DataAnnotations;

namespace POC_TMB.Dto
{
    public class CreateOrderDto
    {
        [Required,StringLength(50)]
        public string Cliente { get; set; }
        
        [Required, StringLength(100)]
        public string Produto { get; set; }

        [Range(0,99999,ErrorMessage = "O valor dever ser maior que zero ")]
        public decimal Valor { get; set; }
        public string Status{ get; set; } = string.Empty;
    }
}
