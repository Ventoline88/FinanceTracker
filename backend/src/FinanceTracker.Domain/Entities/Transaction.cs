using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateOnly Date { get; private set; }
        public Currency Currency { get; private set; }
        public TransactionType Type { get; private set; }

        public Transaction(
            decimal amount, 
            Currency currency, 
            TransactionType type, 
            string description = "")
        {
            if(amount <= 0)
            {
                throw new ArgumentException(
                    "Amount must be greater than zero",
                    nameof(amount));
            }

            Id = Guid.NewGuid();
            Amount = amount;
            Currency = currency;
            Type = type;
            Description = description;
            Date = DateOnly.FromDateTime(DateTime.Now);
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}
