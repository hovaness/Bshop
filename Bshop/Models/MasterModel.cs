using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class MasterModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("secondname")]
        public string secondname { get; set; }
        [Column("roomid")]
        public int roomid { get; set; }
    }
}
