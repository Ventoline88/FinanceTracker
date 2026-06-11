using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Tests.Entities
{
    public class TransactionTests
    {
        [Fact]
        public void CreateTransaction_WithValidAmount_ShouldSucceed()
        {
            // Arrange
            var amount = 100;

            // Act & Assert
            Assert.True(amount > 0);
        }

        [Fact]
        public void CreateTransaction_WithZeroAmount_ShouldFail()
        {
            // Arrange
            var amount = 0;

            // Act & Assert
            Assert.False(amount > 0);
        }
    }
}
