using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.Interface
{
    public interface ITokenServices
    {
        string CreateToken(Usuario usuario);
    }
}