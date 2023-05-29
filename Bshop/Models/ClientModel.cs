
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bshop.Models
{
    public class RegisterClientView
    {
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage ="Слишком короткое имя")]
        [MaxLength(20, ErrorMessage ="Слишком длинное имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [MaxLength(11,ErrorMessage ="Номер не должен привышать 11 символов")]
        public string Phone { get; set; }
        [MinLength(6,ErrorMessage ="Пароль должен быть не меньше 6 символов")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите пароль")]
        public string Password { get;set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }

    public class ClientModel:IComparable<ClientModel>
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string name { get; set; }
        [Column("number")]
        [MaxLength(11)]
        public string number { get; set; }
        [Column("isRegular")]
        public bool isRegular { get; set; }
        [Column("visitings")]
        public int? visitings { get; set; }
        [Column("password")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        public string IsRegular() 
        {
            string res = "";
            if (visitings >= 5)
            {
                isRegular = true;
                res = "Постоянный";
            }
            else
            {
                isRegular = false;
                res = "Новый";
            }
            return res;
        }

        public int CompareTo(ClientModel client)
        {
            return id.CompareTo(client.id);
        }
    }
}
