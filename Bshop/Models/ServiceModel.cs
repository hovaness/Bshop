using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class ServiceModel:IComparable<ServiceModel>
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        [MinLength(2)]
        [MaxLength(50)]
        public string? name { get; set; }
        [Column("cost")]
        [Range(100,10000)]
        public int cost{ get; set; }
        [Column("roomId")]
        [Range(1, 2, ErrorMessage = "Такой комнаты не сущетсвует")]
        public int roomId { get; set; }

        public int CompareTo(ServiceModel service)
        {
            return cost.CompareTo(service.cost);
        }

        public string GetRoom()
        {
            string res = "";
            if (roomId == 1) res = "Мужская";
            else if (roomId == 2) res = "Женская";
            return res;
        }
    }

    public class ServiceViewModel
    {
        public IEnumerable<ServiceModel> Services { get; set;}
        public SelectList womanServices { get; set; }
        public SelectList manServices { get; set; }
    }
}
