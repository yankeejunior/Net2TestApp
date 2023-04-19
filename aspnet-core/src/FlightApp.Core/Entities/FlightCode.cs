using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace FlightApp.Entities
{
    [Table("FlightCodes", Schema = "flights")]
    public class FlightCode : Entity<int>
    {
        public int PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        public string Code { get; set; }
    }
}
