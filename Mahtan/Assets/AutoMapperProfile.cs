using System;
using Mahtan.Models;
using Mahtan.ViewModels;

namespace Mahtan.Assets
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<RegisterViewModel, User>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(vm => vm.PhoneNumber))
                .ForMember(m => m.MobileConfirmationCode, opt => opt.MapFrom(vm => new Random().Next(100000, 999999)));
        }
    }
}
