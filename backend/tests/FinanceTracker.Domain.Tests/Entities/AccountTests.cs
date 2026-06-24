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
                TransactionType.Income,
                TransactionCategory.Other);

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
                TransactionType.Income,
                TransactionCategory.Other);

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
                    TransactionType.Income,
                    TransactionCategory.Other));

            account.AddTransaction(
                new Transaction(
                    200,
                    Currency.SEK,
                    TransactionType.Expense,
                    TransactionCategory.Other));

            // Act
            var balance = account.Balance;

            // Assert
            Assert.Equal(800, balance);
        }

        [Fact]
        public void RemoveTransaction_WithExistingTransaction_ShouldRemoveTransaction()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            var transaction = new Transaction(
                100,
                Currency.SEK,
                TransactionType.Expense,
                TransactionCategory.Other);

            account.AddTransaction(transaction);

            // Act
            account.RemoveTransaction(transaction.Id);

            // Assert
            Assert.Empty(account.Transactions);
        }

        [Fact]
        public void RemoveTransaction_WithNonExistingTransaction_ShouldThrowException()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            // Act
            var action = () => account.RemoveTransaction(Guid.NewGuid());

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Transactions_ShouldBeReadOnly()
        {
            // Arrange
            var account = new Account(
                "Main Account",
                Currency.SEK);

            // Act
            var transactions = account.Transactions;

            // Assert
            Assert.IsAssignableFrom<IReadOnlyCollection<Transaction>>(transactions);
        }

        [Fact]
        public void Constructor_WithDescription_ShouldSetDescription()
        {
            // Arrange & Act
            var account = new Account(
                "Main Account",
                Currency.SEK,
                "Used for everyday expenses");

            // Assert
            Assert.Equal(
                "Used for everyday expenses",
                account.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        public void Constructor_WithInvalidDescription_ShouldThrowException(
            string description)
        {
            // Act
            var action = () => new Account(
                "Main Account",
                Currency.SEK,
                description);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
