using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Entities
{
    public class Account
    {
        public const int MaxNameLength = 50;

        private readonly List<Transaction> _transactions = [];

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Currency Currency { get; private set; }
        public IReadOnlyCollection<Transaction> Transactions
            => _transactions;
        public decimal Balance
        {
            get
            {
                decimal balance = 0;

                foreach(Transaction transaction in Transactions)
                {
                    if(transaction.Type == TransactionType.Income)
                    {
                        balance += transaction.Amount;
                    } else
                    {
                        balance -= transaction.Amount;
                    }
                }

                return balance;
            }
        }
        public string? Description { get; private set; }

        public Account(
            string name, 
            Currency currency,
            string? description = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Account name cannot be empty.",
                    nameof(name));
            }

            if(name.Length > MaxNameLength)
            {
                throw new ArgumentException(
                    $"Account name cannot exceed {MaxNameLength} characters.",
                    nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
            Currency = currency;
            Description = description;
        }

        public void AddTransaction(Transaction transaction)
        {
            if(transaction is null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            if(transaction.Currency != Currency)
            {
                throw new ArgumentException(
                    "Transaction currency must match account currency",
                    nameof(transaction));
            }

            _transactions.Add(transaction);
        }

        public void RemoveTransaction(Guid transactionId)
        {
            var transaction = Transactions.FirstOrDefault(
                t => t.Id == transactionId);

            if(transaction is null)
            {
                throw new ArgumentException(
                    "Transaction not found",
                    nameof(transactionId));
            }

            _transactions.Remove(transaction);
        }
    }
}
