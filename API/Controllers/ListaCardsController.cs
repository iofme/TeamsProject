using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entidades;
using API.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaCardsController(DataContext context, IListaCardsRepository listaCardsRepository,ICardRepository cardRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaCards>>> GetListaCards()
        {
            var listaCards = await listaCardsRepository.ListaCardsAsync();

            return Ok(listaCards);
        }

        [HttpPost]
        public async Task<ActionResult<ListaCards>> CreateList(ListaCardsDTO listaCardsDTO)
        {
            var listaCards = new ListaCards()
            {
                NomeLista = listaCardsDTO.NomeLista
            };
            context.ListaCards.Add(listaCards);
            await listaCardsRepository.SaveAllAsync();
            listaCardsRepository.Update(listaCards);
            return Ok(listaCards);
        }

        [HttpDelete("{idLista:int}")]
        public async Task<ActionResult<ListaCards>> DeleteLista(int idLista)
        {
            var listaCard = await listaCardsRepository.GetListaCard(idLista);

            context.ListaCards.Remove(listaCard);

            await listaCardsRepository.SaveAllAsync();
            listaCardsRepository.Update(listaCard);

            return Ok(listaCard);
        }

        [HttpGet("{idLista:int}")]
        public async Task<ActionResult<ListaCards>> GetListaById(int idLista)
        {
            var listaCard = await listaCardsRepository.GetListaCard(idLista);

            return Ok(listaCard);
        }

        [HttpPut("{idLista:int}")]
        public async Task<ActionResult> UpdateLista(int idLista, ListaCardsDTO listaCardsDTO){
            var listaCard = await listaCardsRepository.GetListaCard(idLista);

            mapper.Map(listaCardsDTO, listaCard);

            if(await listaCardsRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Falha ao atualizar a lista");    
        }


        [HttpPost("{intList:int}/{intCard:int}")]
        public async Task<ActionResult> CardInList(int intList, int intCard){
            var listCards = await listaCardsRepository.GetListaCard(intList);
            var card = await cardRepository.GetCardById(intCard);

            if (listCards.Cards == null) return NoContent();
            listCards.Cards.Add(card);
            
            await listaCardsRepository.SaveAllAsync();
            listaCardsRepository.Update(listCards);

            return Ok(listCards.Cards);
        }
    }
}