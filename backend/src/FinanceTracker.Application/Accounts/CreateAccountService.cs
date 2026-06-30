using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Accounts
{
    public class CreateAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Execute(
            string name,
            Currency currency)
        {
            if(_accountRepository.GetByName(name) is not null)
            {
                throw new InvalidOperationException(
                    "An account with that name already exists.");
            }

            var account = new Account(name, currency);

            _accountRepository.Add(account);
            
            return account;
        }
    }
}
