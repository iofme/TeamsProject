using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.Interface
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCardById(int id);
        Task<bool> SaveAllAsync();
        void update(Card card);
    }
}