using Application.ViewModels;
using AutoMapper;
using Domain.Entity;

namespace CrossCutting.AutoMapperConfig
{
    public class PaymentScheduleProfile : Profile
    {
        public PaymentScheduleProfile()
        {
            CreateMap<PaymentScheduleViewModel, PaymentSchedule>();
            CreateMap<PaymentSchedule, PaymentScheduleViewModel>();
        }
    }
}
