using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Contragent
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Address? Address { get; set; }
        public Contact? Contact { get; set; }
        public long? Pin { get; set; }
        public long? Inn { get; set; }
        public  Email? Email { get; set; }
        public List<Contract>? Contracts { get; set; }
        public List<Account>? Accounts { get; set; }
        public List<BankCard>? BankCards { get; set; }
    }
}
