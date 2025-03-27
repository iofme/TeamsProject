using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ListaCardsRepository(DataContext context) : IListaCardsRepository
    {
        public Task<ListaCards> GetListaCard(int id)
        {
            return context.ListaCards.Include(l => l.Cards).FirstOrDefaultAsync(l => l.Id == id)!;
        }

        public async Task<IEnumerable<ListaCards>> ListaCardsAsync()
        {
            return await context.ListaCards.Include(l => l.Cards).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() < 0;
        }

        public void Update(ListaCards listaCards)
        {
            context.Update(listaCards).State = EntityState.Modified;
        }
    }
}