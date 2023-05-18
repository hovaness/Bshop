using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class ClientModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("number")]
        public long number { get; set; }
        [Column("isRegular")]
        public bool isRegular { get; set; }
        [Column("visitings")]
        public long visitings { get; set; }
    }
}
