using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Tests.Entities
{
    public class TransactionTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void CreateTransaction_WithInvalidAmount_ShouldThrouwException(decimal amount)
        {
            // Arrange
            var action = () => new Transaction(amount, Currency.SEK, TransactionType.Expense);

            // Act & Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CreateTransaction_WithValidAmount_ShouldCreateTransaction()
        {
            // Arrange
            var amount = 100;

            // Act
            var transaction = new Transaction(amount, Currency.SEK, TransactionType.Expense);

            // Assert
            Assert.Equal(amount, transaction.Amount);
        }

        [Fact]
        public void CreateTransaction_WithDescription_ShouldStoreDescription()
        {
            // Arrange
            var description = "Groceries";

            // Act
            var transaction = new Transaction(
                500,
                Currency.SEK,
                TransactionType.Expense,
                description);

            // Assert
            Assert.Equal(description, transaction.Description);
        }

        [Fact]
        public void UpdateDescription_WithValidDescription_ShouldUpdateDescription()
        {
            // Arrange
            var transaction = new Transaction(
                500,
                Currency.SEK,
                TransactionType.Expense);

            var newDescription = "Groceries";

            // Act
            transaction.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, transaction.Description);
        }

        [Fact]
        public void UpdateDescription_WithEmptyDescription_ShouldThrowException()
        {
            // Arrange
            var transaction = new Transaction(
                500,
                Currency.SEK,
                TransactionType.Expense);

            // Act
            var action = () => transaction.UpdateDescription("");

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void UpdateDescription_WithTooLongDescription_ShouldThrowException()
        {
            // Arrange
            var transaction = new Transaction(
                500,
                Currency.SEK,
                TransactionType.Expense);

            var description = new string('A', Transaction.MaxDescriptionLength + 1);

            // Act
            var action = () => transaction.UpdateDescription(description);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
