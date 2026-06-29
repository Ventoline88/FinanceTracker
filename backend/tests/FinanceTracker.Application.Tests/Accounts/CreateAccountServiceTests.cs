using FinanceTracker.Application.Accounts;
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
            var service = new CreateAccountService();

            // Act
            var account = service.Execute(
                "Main Account",
                Currency.SEK);

            // Assert
            Assert.NotNull(account);
            Assert.Equal("Main Account", account.Name);
            Assert.Equal(Currency.SEK, account.Currency);
        }
    }
}
