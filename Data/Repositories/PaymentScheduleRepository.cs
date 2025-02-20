using Data.Repositories.Interfaces;
using Domain.Entity;

namespace Data.Repositories
{
    public class PaymentScheduleRepository : IPaymentScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SavePaymentScheduleAsync(List<PaymentSchedule> schedule)
        {
            await _context.PaymentFlowSummary.AddRangeAsync(schedule);
            await _context.SaveChangesAsync();
        }
    }
}
