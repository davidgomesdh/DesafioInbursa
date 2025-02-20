using Domain.Entity;

namespace Data.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        Task SaveLoanAsync(Loan loan);
        Task<List<Loan>> GetAllLoansAsync();
    }
}
