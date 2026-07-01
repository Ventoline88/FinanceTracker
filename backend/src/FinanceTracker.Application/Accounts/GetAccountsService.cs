using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Accounts
{
    public class GetAccountsService
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountsService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IReadOnlyCollection<AccountDto> Execute()
        {
            return _accountRepository
                .GetAll()
                .Select(account => new AccountDto
                {
                    Id = account.Id,
                    Name = account.Name,
                    Currency = account.Currency,
                    Balance = account.Balance
                })
                .ToList();
        }
    }
}
