using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entidades;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(DataContext context, ICardRepository cardRepository, IListaCardsRepository listaCardsRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Card>> CreateCard(CardDTO cardDTO)
        {
            var listaCards = await listaCardsRepository.GetListaCard(cardDTO.ListaCardsId);
            var card = new Card()
            {
                Cardname = cardDTO.Cardname,
                Descricao = cardDTO.Descricao,
                Datafinal = cardDTO.Datafinal,
                Prioridade = cardDTO.Prioridade,
                ListaCards = listaCards,
            };

            context.Cards.Add(card);
            await cardRepository.SaveAllAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            var cards = await cardRepository.GetCards();

            return Ok(cards);
        }


        [HttpGet("{idCard:int}")]
        public async Task<ActionResult> GetCard(int idCard){
             var card = await cardRepository.GetCardById(idCard);
            return Ok(card);
        }

        [HttpDelete("{idCard:int}")]
        public async Task<ActionResult<Card>> DeleteCard(int idCard)
        {
            var card = await cardRepository.GetCardById(idCard);

            context.Cards.Remove(card);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Card>> PutCard(CardDTO cardDTO)
        {

            var listaCards = await listaCardsRepository.GetListaCard(cardDTO.ListaCardsId);

            var cardUpdate = new Card()
            {
                Cardname = cardDTO.Cardname,
                Descricao = cardDTO.Descricao,
                ListaCards = listaCards,
            };

            context.Cards.Update(cardUpdate);
            return Ok();
        }
    }
}