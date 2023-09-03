 

namespace WebApplication2.Application.Dto
{
    public class ItemRequestDto
    {
        public int ItemId { get; set; }

        public string ItemNme { get; set; } = null!;

        public string ItemDesc { get; set; } = null!;

        public int Price { get; set; }

        public int category { get; set; }

        public string? Brnd { get; set; }

        public byte[]? Img { get; set; }

        public int? Rvew { get; set; }

        public int? Stock { get; set; }
        
       public int? CategoryId { get; set; }
    }
}
