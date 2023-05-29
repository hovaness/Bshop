using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class MasterModel:IComparable<MasterModel>
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("name")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2,ErrorMessage ="Короткое имя")]
        [MaxLength(50,ErrorMessage ="Слишком длинное имя")]
        public string? name { get; set; }
        [Column("secondname")]
        [MinLength(2, ErrorMessage = "Короткая фамилия")]
        [MaxLength(50, ErrorMessage = "Слишком длинная фамилия")]
        public string? secondname { get; set; }
        [Column("roomid")]
        [Range(1,2,ErrorMessage ="Такой комнаты не сущетсвует")]
        public int roomid { get; set; }

        public int CompareTo(MasterModel master) 
        {
           return id.CompareTo(master.id);
        }

        public string GetRoom()
        {
            string res = "";
            if (roomid == 1) res = "Мужская";
            else if (roomid == 2) res = "Женская";
            return res;
        }
    }
}
