namespace DentalManager.Application.Contracts.Salaries;

public sealed class SalaryPaymentDto
{
    public int Id { get; set; }
    public short MonthNumber { get; set; }
    public short Year { get; set; }
    public int TransactionNumber { get; set; }
    public decimal Amount { get; set; }
    public int WorkerId { get; set; }
    public string WorkerName { get; set; }
    public string WorkerSurname { get; set; }
}
