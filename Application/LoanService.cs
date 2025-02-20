using Application.DTOs;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Repositories.Interfaces;
using Domain.Entity;

namespace Application
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IPaymentScheduleRepository _paymentScheduleRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IPaymentScheduleRepository paymentScheduleRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _paymentScheduleRepository = paymentScheduleRepository;
            _mapper = mapper;
        }

        public async Task<LoanSimulationResult> SimulateLoanAsync(LoanViewModel request)
        {
            var loan = _mapper.Map<Loan>(request);
            loan.LoanId = Guid.NewGuid(); // Garantir que é um novo registro

            var monthlyRate = loan.AnnualInterestRate / 12;
            var monthlyPayment = loan.LoanAmount * (monthlyRate / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -loan.NumberOfMonths)));

            decimal balance = loan.LoanAmount;
            List<PaymentSchedule> schedule = new();
            decimal totalInterest = 0;

            for (int month = 1; month <= loan.NumberOfMonths; month++)
            {
                decimal interest = balance * monthlyRate;
                decimal principal = monthlyPayment - interest;
                balance -= principal;
                totalInterest += interest;

                schedule.Add(new PaymentSchedule
                {
                    LoanId = loan.LoanId,
                    Month = month,
                    Principal = principal,
                    Interest = interest,
                    Balance = balance > 0 ? balance : 0
                });
            }

            await _loanRepository.SaveLoanAsync(loan);
            await _paymentScheduleRepository.SavePaymentScheduleAsync(schedule);

            var result = new LoanSimulationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalPayment = loan.LoanAmount + totalInterest,
                PaymentSchedule = _mapper.Map<List<PaymentScheduleViewModel>>(schedule)
            };

            return result;
        }
    }
}
