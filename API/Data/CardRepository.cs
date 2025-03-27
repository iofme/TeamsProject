using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CardRepository(DataContext context) : ICardRepository
    {
        public Task<Card> GetCardById(int id)
        {
            return context.Cards.FirstOrDefaultAsync(c => c.Id == id)!;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await context.Cards.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void update(Card card)
        {
            context.Entry(card).State = EntityState.Modified;
        }
    }
}