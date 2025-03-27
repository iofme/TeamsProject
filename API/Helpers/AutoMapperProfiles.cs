using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entidades;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Card, CardDTO>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<ListaCards, ListaCardsDTO>();
        }
    }
}