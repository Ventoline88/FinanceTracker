using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Accounts;
using FinanceTracker.Application.Tests.Fakes;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Tests.Accounts
{
    public class CreateAccountServiceTests
    {
        [Fact]
        public void Execute_ShouldCreateAccount()
        {
            // Arrange
            var repository = new FakeAccountRepository();
            var service = new CreateAccountService(repository);

            // Act
            var account = service.Execute(
                "Main Account",
                Currency.SEK);

            // Assert
            Assert.NotNull(account);
            Assert.Equal("Main Account", account.Name);
            Assert.Equal(Currency.SEK, account.Currency);
            Assert.Single(repository.Accounts);
            Assert.Same(account, repository.Accounts[0]);
        }

        [Fact]
        public void Execute_WhenAccountNameAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var repository = new FakeAccountRepository();

            repository.Add(new Account(
                "Main Account", 
                Currency.SEK));

            var service = new CreateAccountService(repository);

            // Act
            var action = () => service.Execute(
                "Main Account",
                Currency.SEK);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
