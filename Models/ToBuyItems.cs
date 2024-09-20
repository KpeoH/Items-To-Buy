using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTTPswagerTEST.Models
{
    public class ToBuyItems
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Название

        [DefaultValue(1)]
        public int Quantity { get; set; } // Количество

        [DefaultValue(false)]
        public bool IsBought { get; set; } // Куплен ли предмет
    }

}
