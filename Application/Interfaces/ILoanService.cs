using Application.DTOs;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ILoanService
    {
        Task<LoanSimulationResult> SimulateLoanAsync(LoanViewModel request);
    }
}
