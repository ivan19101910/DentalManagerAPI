namespace DentalManager.Application.Contracts.Salaries;

public sealed class CreateSalaryPaymentDto
{
    public int Id { get; set; }
    public short MonthNumber { get; set; }
    public short Year { get; set; }
    public int TransactionNumber { get; set; }
    public decimal Amount { get; set; }
    public int WorkerId { get; set; }
}
