using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public Currency Currency { get; init; }
        public decimal Balance { get; init; }
    }
}
