namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string? OrderDate { get; set; }

        public int? OrderSum { get; set; }

        public int? UserId { get; set; }

        public int? ProductsId { get; set; }

        public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
