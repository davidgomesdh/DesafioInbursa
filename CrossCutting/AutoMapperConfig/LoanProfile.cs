using Application.ViewModels;
using AutoMapper;
using Domain.Entity;

namespace CrossCutting.AutoMapperConfig
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanViewModel, Loan>();
            CreateMap<Loan, LoanViewModel>();
        }
    }
}
