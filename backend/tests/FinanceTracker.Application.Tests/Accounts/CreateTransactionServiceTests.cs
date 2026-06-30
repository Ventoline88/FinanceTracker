using FinanceTracker.Application.Accounts;
using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Tests.Fakes;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Tests.Accounts
{
    public class CreateTransactionServiceTests
    {
        [Fact]
        public void Execute_ShouldAddTransactionToAccount()
        {
            // Arrange
            var repository = new FakeAccountRepository();

            var account = new Account(
                "Main Account",
                Currency.SEK);

            repository.Add(account);

            var service = new CreateTransactionService(repository);

            // Act
            var request = new CreateTransactionRequest
            {
                AccountName = "Main Account",
                Amount = 1000m,
                Currency = Currency.SEK,
                Type = TransactionType.Income,
                Category = TransactionCategory.Salary,
                Description = "June Salary"
            };

            var transaction = service.Execute(request);

            // Assert
            Assert.Single(account.Transactions);
            Assert.Same(transaction, account.Transactions.First());
            Assert.Equal(1000m, account.Balance);
        }
    }
}
