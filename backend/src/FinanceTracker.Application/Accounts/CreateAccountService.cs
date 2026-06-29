using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Accounts
{
    public class CreateAccountService
    {
        public Account Execute(
            string name,
            Currency currency)
        {
            return new Account(
                name,
                currency);
        }
    }
}
