using System.ComponentModel.DataAnnotations.Schema;

namespace Front_to_back.Models
{
    public class Accessory : BaseEntity
    {
        public class Product : BaseEntity
        {
            public string Image { get; set; }
           
            public string Title { get; set; }

            [Column(TypeName = "decimal(14,4)")]
           
            public decimal Price { get; set; }
        }
    }
}