using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Abstractions
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account? GetByName(string name);
        IReadOnlyCollection<Account> GetAll();
    }
}
