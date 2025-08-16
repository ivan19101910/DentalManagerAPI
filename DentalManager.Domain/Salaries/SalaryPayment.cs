using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Workers;

namespace DentalManager.Domain.Salaries;

public sealed class SalaryPayment : IEntity<int>
{
    public int Id { get; init; }

    public short MonthNumber { get; init; }

    public short Year { get; init; }

    public int TransactionNumber { get; init; }

    public decimal Amount { get; init; }

    public int WorkerId { get; init; }

    public Worker? Worker { get; init; }
}
