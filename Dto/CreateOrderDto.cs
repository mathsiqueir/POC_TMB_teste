using System.ComponentModel.DataAnnotations;

namespace POC_TMB.Dto
{
    public class CreateOrderDto
    {
        [StringLength(50)]
        public required string Cliente { get; set; }
        
        [ StringLength(100)]
        public required string? Produto { get; set; }

        [Range(0,99999,ErrorMessage = "O valor dever ser maior que zero ")]
        public decimal Valor { get; set; }
        public string? Status{ get; set; } = "Pendente";
    }
}
