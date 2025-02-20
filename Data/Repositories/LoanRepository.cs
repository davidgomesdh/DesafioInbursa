using Data.Repositories.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveLoanAsync(Loan loan)
        {
            await _context.Proposta.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _context.Proposta.ToListAsync();
        }
    }
}
