using System.ComponentModel.DataAnnotations;

namespace POC_TMB.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(100)]
        public string Cliente { get; set; }
        [Required]
        [StringLength(100)]
        public string Produto { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required]
        public string Status { get; set; } = "Pendente";
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public static class OrderStatus
        {
            public const string Pendente = "Pendente";
            public const string Processando = "Processando";
            public const string Finalizado = "Finalizado";
        }
    }
}
