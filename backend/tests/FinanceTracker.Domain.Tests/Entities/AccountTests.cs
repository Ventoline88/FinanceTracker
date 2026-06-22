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

        [Fact]
        public void AddTransaction_WithDifferentCurrency_ShouldThrowException()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            var transaction = new Transaction(
                100,
                Currency.USD,
                TransactionType.Income);

            // Act
            var action = () => account.AddTransaction(transaction);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void AddTransaction_WithNullTransaction_ShouldThrowException()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            // Act
            var action = () => account.AddTransaction(null!);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Balance_WithIncomeAndExpenseTransactions_ShouldReturnCorrectBalance()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            account.AddTransaction(
                new Transaction(
                    1000,
                    Currency.SEK,
                    TransactionType.Income));

            account.AddTransaction(
                new Transaction(
                    200,
                    Currency.SEK,
                    TransactionType.Expense));

            // Act
            var balance = account.Balance;

            // Assert
            Assert.Equal(800, balance);
        }
    }
}
