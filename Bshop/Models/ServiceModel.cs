using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class ServiceModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string? name { get; set; }
        [Column("price")]
        public int price { get; set; }
        [Column("roomId")]
        public int roomId { get; set; }
    }
}
