using Domain.Entity;

namespace Data.Repositories.Interfaces
{
    public interface IPaymentScheduleRepository
    {
        Task SavePaymentScheduleAsync(List<PaymentSchedule> schedule);
    }
}
