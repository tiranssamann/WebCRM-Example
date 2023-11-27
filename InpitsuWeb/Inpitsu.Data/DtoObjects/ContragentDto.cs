using Inpitsu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record ContragentDto(
         Guid? Id,
         string? Name,
         string? Description,
         Address? Address,
         Contact? Contact,
         long? Pin,
         long? Inn,
         Email? Email,
         List<Contract>? Contracts,
         List<Account>? Accounts,
         List<BankCard>? BankCards
    );
    public record ContragentCreateDto(
        Guid? Id,
         string? Name,
         string? Description,
         Address? Address,
         Contact? Contact,
         long? Pin,
         long? Inn,
         Email? Email,
         List<Contract>? Contracts,
         List<Account>? Accounts,
         List<BankCard>? BankCards
        );

    public record ContragentUpdateDto(
         Guid? Id,
         string? Name,
         string? Description,
         Address? Address,
         Contact? Contact,
         long? Pin,
         long? Inn,
         Email? Email,
         List<Contract>? Contracts,
         List<Account>? Accounts,
         List<BankCard>? BankCards
        );
    public record ContragentDeleteDto(Guid Id);
}
