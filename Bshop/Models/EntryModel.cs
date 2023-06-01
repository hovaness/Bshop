using Bshop.Entity;
using System.ComponentModel.DataAnnotations;
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
        [Column("time", TypeName ="timestamp without time zone")]

        public DateTime time { get; set; }
        
        public string DateToString() { return this.time.ToString(); }

        public int getCostFromNumber(string number)
        {
            var client = new ClientContext().Client.FirstOrDefault(client => client.number == number);
            int cost = getServiceCost(id);
            if (client.isRegular) return (int)Math.Round(cost * 0.9);
            else return cost;
        }
		public string getMasterName(int id)
		{
			string res;
			var master = new MasterContext().Master.FirstOrDefault(master => master.id == id);
			res = master.name + " " + master.secondname;
			return res;
		}
		public string getServiceName(int id)
		{
			string res;
			var service = new ServiceContext().Service.FirstOrDefault(m => m.id == id);
			res = service.name;
			return res;
		}
        public int getServiceCost(int id)
        {
			var service = new ServiceContext().Service.FirstOrDefault(m => m.id == id);
            return service.cost;
		}
	}

    public class HalfEntry: EntryModel
    {
        public List<MasterModel> masters { get; set; }
        public string phone { get; set; }
    }
}
