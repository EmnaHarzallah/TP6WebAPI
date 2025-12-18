using AutoMapper;
using TP6WebAPI.Models.DTO;
using TP6WebAPI.Models;

namespace TP6WebAPI.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Categorie, CategorieDTO>();
            CreateMap<CategorieDTO, Categorie>();
        }
    }
}
