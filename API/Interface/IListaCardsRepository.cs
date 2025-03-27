using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.Interface
{
    public interface IListaCardsRepository
    {
        Task<IEnumerable<ListaCards>> ListaCardsAsync();
        Task<ListaCards> GetListaCard(int id);
        Task<bool> SaveAllAsync();
        void Update(ListaCards listaCards);
    }
}