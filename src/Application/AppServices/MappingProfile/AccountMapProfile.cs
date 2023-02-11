using AutoMapper;
using Contracts.Account;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile() 
        {
            CreateMap<Account, InfoAccountResponse>().ReverseMap();
            CreateMap<Account, RegisterOrUpdateRequest>().ReverseMap();
            CreateMap<InfoAccountResponse, RegisterOrUpdateRequest>().ReverseMap();
        }
    }
}
