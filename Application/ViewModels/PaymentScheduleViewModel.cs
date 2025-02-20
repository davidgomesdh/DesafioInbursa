namespace Application.ViewModels
{
    public class PaymentScheduleViewModel
    {
        public Guid PaymentScheduleId { get; set; }
        public Guid LoanId { get; set; }
        public int Month { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
    }
}
