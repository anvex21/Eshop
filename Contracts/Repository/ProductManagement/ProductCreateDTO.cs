namespace Contracts.DTOs.Product
{
    public class ProductCreateDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
    }
}