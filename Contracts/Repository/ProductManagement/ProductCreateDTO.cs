using System.ComponentModel.DataAnnotations;

namespace Contracts.DTOs.Product
{
    public class ProductCreateDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}