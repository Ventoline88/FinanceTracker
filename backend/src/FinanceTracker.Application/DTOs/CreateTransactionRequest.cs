using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.DTOs
{
    public class CreateTransactionRequest
    {
        public string AccountName { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }
        public TransactionType Type { get; init; }
        public TransactionCategory Category { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
