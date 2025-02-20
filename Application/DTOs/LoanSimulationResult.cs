using Application.ViewModels;

namespace Application.DTOs
{
    public class LoanSimulationResult
    {
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public List<PaymentScheduleViewModel> PaymentSchedule { get; set; } = new();
    }
}
