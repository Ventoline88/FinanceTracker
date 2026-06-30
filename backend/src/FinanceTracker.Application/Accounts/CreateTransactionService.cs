using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.DTOs;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Accounts
{
    public class CreateTransactionService
    {
        private readonly IAccountRepository _accountRepository;

        public CreateTransactionService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Transaction Execute(CreateTransactionRequest request)
        {
            var account = _accountRepository.GetByName(request.AccountName);

            if(account is null)
            {
                throw new InvalidOperationException(
                    "Account does not exist.");
            }

            var transaction = new Transaction(
                request.Amount,
                request.Currency,
                request.Type,
                request.Category,
                request.Description);

            account.AddTransaction(transaction);

            return transaction;
        }
    }
}
