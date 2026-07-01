using FinanceTracker.Application.Accounts;
using FinanceTracker.Application.Tests.Fakes;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Tests.Accounts
{
    public class GetAccountsServiceTests
    {
        [Fact]
        public void Execute_ShouldReturnAllAccounts()
        {
            // Arrange
            var repository = new FakeAccountRepository();

            repository.Add(new Account("Main Account", Currency.SEK));
            repository.Add(new Account("Savings", Currency.SEK));

            var service = new GetAccountsService(repository);

            // Act
            var accounts = service.Execute();

            // Assert
            Assert.Equal(2, accounts.Count());

            var first = accounts.First();

            Assert.Equal("Main Account", first.Name);
            Assert.Equal(Currency.SEK, first.Currency);
            Assert.Equal(0m, first.Balance);
        }
    }
}
