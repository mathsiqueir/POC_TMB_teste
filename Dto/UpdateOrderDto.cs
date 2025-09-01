using System.ComponentModel.DataAnnotations;

namespace POC_TMB.Dto
{
    public class UpdateOrderDto
    {
        [Required, StringLength(120)]
        public string Cliente { get; set; } = string.Empty;

        [Required, StringLength(160)]
        public string Produto { get; set; } = string.Empty;

        [Range(0.01, 9999999, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
