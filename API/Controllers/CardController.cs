using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entidades;
using API.Extensions;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(DataContext context, ICardRepository cardRepository, IUsuarioRepository usuarioRepository, IListaCardsRepository listaCardsRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Card>> CreateCard(CardDTO cardDTO)
        {
            var listaCards = await listaCardsRepository.GetListaCard(cardDTO.ListaCardsId);

            var user = await usuarioRepository.GetUsuarioById(User.GetUserId());

            var card = new Card()
            {
                Cardname = cardDTO.Cardname,
                Descricao = cardDTO.Descricao,
                Datafinal = cardDTO.Datafinal,
                Prioridade = cardDTO.Prioridade,
                ListaCards = listaCards,
                Createby = user.Username,
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
        public async Task<ActionResult> GetCard(int idCard)
        {
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

        [HttpPut("updatelist/{cardId:int}/{newListId:int}")]
        public async Task<ActionResult> UpdateCardList(int cardId, int newListId)
        {
            var card = await context.Cards.FindAsync(cardId);
            if (card == null)
                return NotFound("Card não encontrado");

            var novaLista = await listaCardsRepository.GetListaCard(newListId);
            if (novaLista == null)
                return NotFound("Lista de destino não encontrada");

            // Atualizar apenas a lista associada ao card
            card.ListaCards = novaLista;
            

            // Salvar as alterações
            await context.SaveChangesAsync();
            context.Cards.Update(card);

            return Ok();
        }
    }
}