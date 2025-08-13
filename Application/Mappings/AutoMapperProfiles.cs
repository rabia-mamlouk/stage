using Application.Features.CarteElectroniqueFeature.Commands;
using Application.Features.CarteElectroniqueFeature.Dtos;
using Application.Features.TestFeature.Commands;
using Application.Features.TestFeature.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Commands
            CreateMap<AddTestCommandNew, Test>();
            CreateMap<PagedList<Test>, PagedList<TestDTO>>().ReverseMap(); 
            CreateMap<AddCarteElectroniqueCommand, CarteElectronique>();
            CreateMap<PagedList<CarteElectronique>, PagedList<CarteElectroniqueDTO>>().ReverseMap();


            //Dto
            CreateMap<Test, TestDTO>().ReverseMap();
            CreateMap<CarteElectronique, CarteElectroniqueDTO>().ReverseMap();

        }
    }
}
