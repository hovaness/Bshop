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
        public string time { get; set; }
    }
    public class HalfEntry
    {
        public List<MasterModel> masterModels { get; set; }
        public int serviceId { get; set; } 
    }
    public class NewEntry
    {
        public List<MasterModel> masterModels { get; set; }
        public EntryModel entryModel { get; set; }
    }
}
