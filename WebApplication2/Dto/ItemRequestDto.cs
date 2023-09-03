using WebApplication2.Models;

namespace WebApplication2.Dto
{
    public class ItemRequestDto
    { 

        public string ItemNme { get; set; } = null!;

        public string ItemDesc { get; set; } = null!;

        public int Price { get; set; }


        public string? Brnd { get; set; }
         

        public int? Rvew { get; set; }
        public int? Stock { get; set; }

        public int? CategoryId { get; set; }

    }
}
