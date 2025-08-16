using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Workers;

namespace DentalManager.Domain.Salaries;

public sealed class SalaryPayment : IEntity<int>
{
    public int Id { get; set; }
    public short MonthNumber { get; set; }
    public short Year { get; set; }
    public int TransactionNumber { get; set; }
    public decimal Amount { get; set; }
    public int WorkerId { get; set; }
    public Worker Worker { get; set; }
}
