using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Tests.Fakes
{
    internal class FakeAccountRepository : IAccountRepository
    {
        public List<Account> Accounts { get; } = [];

        public void Add(Account account)
        {
            Accounts.Add(account);
        }

        public Account? GetByName(string name)
        {
            return Accounts.FirstOrDefault(a => a.Name == name);
        }

        public IReadOnlyCollection<Account> GetAll()
        {
            return Accounts;
        }
    }
}
