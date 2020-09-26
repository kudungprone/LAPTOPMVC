using System.ComponentModel.DataAnnotations;

namespace LAPTOPMVC.Models
{
    public class Laptop
    {
        [Key]
        [StringLength(30, MinimumLength = 3)]
        public string id { get; set; }

        public string name { get; set; }
        public int price { get; set; }
        public string cpu { get; set; }
        public int ram { get; set; }
        public int storage { get; set; }
    }
}