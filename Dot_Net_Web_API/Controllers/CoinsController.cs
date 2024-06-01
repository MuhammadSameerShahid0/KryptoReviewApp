using AutoMapper;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Dto;
using KryptoReviewApp.Interfaces;
using KryptoReviewApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KryptoReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : Controller
    {
        private readonly ICoinsRepository _coinsRepository;
        private readonly IMapper _mapper;

        public CoinsController(ICoinsRepository coinsRepository, IMapper mapper)
        {
            _coinsRepository = coinsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coins>))]
        public IActionResult GetCoins()
        {
            var coinslist = _mapper.Map<List<CoinsDTo>>(_coinsRepository.GetCoins());
            if(coinslist == null)
                return NotFound();
            return Ok(coinslist);
        }

        [HttpGet("id/{CoinId}")]
        [ProducesResponseType(200 , Type = typeof(Coins))]
        public IActionResult GetCoins(int CoinId)
        {
            var coinid = _mapper.Map<CoinsDTo>(_coinsRepository.GetCoins(CoinId));
            if (coinid == null)
                return NotFound();
            return Ok(coinid);
        }

        [HttpGet("Symbol/{Symbol}")]
        [ProducesResponseType(200, Type = typeof(Coins))]
        [ProducesResponseType(600)]
        public IActionResult GetCoins(string Symbol)
        {
            var coinsymbl = _mapper.Map<CoinsDTo>(_coinsRepository.GetCoins(Symbol));
            if (coinsymbl == null)
                return NotFound();
            return Ok(coinsymbl);
        }

        [HttpGet("Name/{Name}")]
        [ProducesResponseType(200, Type = typeof(Coins))]
        [ProducesResponseType(600)]
        public IActionResult GetCoinsName(string Name)
        {
            var coinnme = _mapper.Map<CoinsDTo>(_coinsRepository.GetCoinsName(Name));
            if (coinnme == null)
                return NotFound();
            return Ok(coinnme);
        }

        [HttpGet("Price/{Price}")]
        [ProducesResponseType(200, Type = typeof(Coins))]
        [ProducesResponseType(600)]
        public IActionResult GetCoins(decimal Price)
        {
            var coinprce = _mapper.Map<CoinsDTo>(_coinsRepository.GetCoins(Price));
            if (coinprce == null)
                return NotFound();
            return Ok(coinprce);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(200)]
        public IActionResult DeleteCoin(int coinid)
        {
            var CoinToDelete = _coinsRepository.GetCoins(coinid);
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_coinsRepository.DeleteCoin(CoinToDelete))
            {
                ModelState.AddModelError("", "SomeThing Went Wrong");
            }

            return NoContent();
        }
    }
}
