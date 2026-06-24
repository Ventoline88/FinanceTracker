using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Enums
{
    public enum TransactionCategory
    {
        Other = 0,

        Salary = 1,
        Bonus = 2,
        Investment = 3,

        Food = 4,
        Housing = 5,
        Transportation = 6,
        Entertainment = 7,
        Healthcare = 8,
        Shopping = 9
    }
}
