using Api_Up_Base.Dtos;
using Api_Up_Base.Models;
using Api_Up_Base.Views;
using AutoMapper;

namespace Api_Up_Base.Profiles {
    public class UsuarioProfile : Profile {

        public UsuarioProfile() {

            CreateMap<UsuarioDTO, UsuarioModel>().ReverseMap();
            CreateMap<AlterarUsuarioDTO, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioModel, UsuarioViews>().ReverseMap();
        }
    }
}
