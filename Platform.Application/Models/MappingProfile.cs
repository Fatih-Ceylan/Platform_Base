using AutoMapper;
using Platform.Application.DTOs.Identity.AppUser;
using Platform.Application.DTOs.Identity.Auth.Login;
using Platform.Application.Features.Commands.Definitions.Company.Create;
using Platform.Application.Features.Commands.Definitions.Company.Update;
using Platform.Application.Features.Commands.Definitions.Licence.Create;
using Platform.Application.Features.Commands.Identity.AppUser.Create;
using Platform.Application.Features.Commands.Identity.AppUser.Login;
using Platform.Application.Features.Queries.Definitions.Company.GetById;
using Platform.Application.Features.Queries.Definitions.Licence.GetById;
using Platform.Domain.Entities.Definitions;
using Platform.Domain.Entities.Definitions.Licence;

namespace Platform.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Company
            CreateMap<Company, ResponseGetByIdCompany>();
            CreateMap<RequestCreateCompany, Company>();
            CreateMap<RequestUpdateCompany, Company>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Company, ResponseUpdateCompany>();
            #endregion

            #region Branch

            #endregion

            #region Department

            #endregion

            #region Customer

            #endregion

            #region AppUser
            CreateMap<RequestCreateAppUser, CreateUserRequestDTO>().ReverseMap();
            CreateMap<ResponseCreateAppUser, CreateUserResponseDTO>().ReverseMap();

            CreateMap<RequestLoginAppUser, LoginRequestDTO>().ReverseMap();
            CreateMap<ResponseLoginAppUser, LoginResponseDTO>().ReverseMap();
            #endregion

            #region Licence
            CreateMap<Licence, ResponseGetByIdLicence>();
            CreateMap<RequestCreateLicence, Licence>();
            
            #endregion

        }
    }
}
