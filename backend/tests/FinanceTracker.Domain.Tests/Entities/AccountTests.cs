using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Tests.Entities
{
    public class AccountTests
    {
        [Fact]
        public void CreateAccount_WithValidName_ShouldCreateAccount()
        {
            // Arrange
            var name = "Main Account";

            // Act
            var account = new Account(
                name,
                Currency.SEK);

            // Assert
            Assert.Equal(name, account.Name);
        }

        [Fact]
        public void CreateAccount_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var name = "";

            // Act
            var action = () => new Account(
                name,
                Currency.SEK);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CreateAccount_WithTooLongName_ShouldThrowException()
        {
            // Arrange
            var name = new string('A', Account.MaxNameLength + 1);

            // Act
            var action = () => new Account(
                name,
                Currency.SEK);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void AddTransaction_ShouldAddTransactionToAccount()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            var transaction = new Transaction(
                1000,
                Currency.SEK,
                TransactionType.Income);

            // Act
            account.AddTransaction(transaction);

            // Assert
            Assert.Single(account.Transactions);
        }
    }
}
