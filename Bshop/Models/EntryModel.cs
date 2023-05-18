using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class EntryModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int id { get; set; }
        [Column("clientid")]
        public int clientid { get; set; }
        [Column("masterid")]
        public int masterid { get; set; }
        [Column("serviceid")]
        public int serviceid { get; set; }
        [Column("time")]
        public DateTime time { get; set; } 
    }
}
