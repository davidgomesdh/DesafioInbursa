namespace Domain.Entity
{
    public class Loan
    {
        public Guid LoanId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int NumberOfMonths { get; set; }
        public virtual ICollection<PaymentSchedule> PaymentSchedules { get; set; }
    }
}
