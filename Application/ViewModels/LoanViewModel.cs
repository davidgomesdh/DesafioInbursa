namespace Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel()
        {
            LoanId = Guid.NewGuid();
        }
        private Guid LoanId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
