using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inpitsu.Data.Models;

namespace Inpitsu.Repositories.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        DbSet<Process> Processes { get; set; }
        DbSet<Attach> Attaches { get; set; }
        DbSet<Contragent> Contragents{ get; set; }
        DbSet<Email> Email_base { get; set; }
        DbSet<Emails> Emails { get; set; }
        DbSet<Phones> Phones { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<BankCard> BankCards { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<ApplicationFor> ApplicationFor { get; set; }
        DbSet<ComingDrug> ComingDrug { get; set;}
        DbSet<Contract> Contracts { get; set; }
        DbSet<Country> Country { get; set; }
        DbSet<Currency> Currency { get; set; }
        DbSet<Deal> Deal { get; set; }
        DbSet<DeliveryObject> DeliveryObjects { get; set;}
        DbSet<District> District { get; set; }
        DbSet<Drug> Drug { get; set; }
        DbSet<Region> Region { get; set; }
        DbSet<Sex> Sex { get; set; }
    }
}