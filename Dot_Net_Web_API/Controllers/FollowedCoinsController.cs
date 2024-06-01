using AutoMapper;
using Dot_Net_Web_API.Interfaces;
using Dot_Net_Web_API.Models;
using Dot_Net_Web_API.Repository;
using KryptoReviewApp.Dto;
using KryptoReviewApp.Interfaces;
using KryptoReviewApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KryptoReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowedCoinsController : Controller
    {
        private readonly IFollowedCoins _followedCoins;
        private readonly IMapper _mapper;
        public FollowedCoinsController(IFollowedCoins followedCoins , IMapper mapper)
        {
            _followedCoins = followedCoins;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<FollowedCoinsDTO>>> GetAllFollowedCoins()
        {
            var followedCoins = await _followedCoins.GetAllFollowedCoinsAsync();
            var followedCoinsDtos = _mapper.Map<IEnumerable<FollowedCoinsDTO>>(followedCoins);
            return Ok(followedCoinsDtos);
        }

        [HttpGet("user/{userId}/coin/{coinId}")]
        public async Task<ActionResult<FollowedCoinsDTO>> FollowedUCId(int userId, int coinId)
        {
            var followedCoins = await _followedCoins.FollowedUCId(userId , coinId);
            if (followedCoins == null)
                return NotFound();
            var usercoinid = _mapper.Map<FollowedCoinsDTO>(followedCoins);
            return Ok(usercoinid);
        }

        [HttpPost("PostFollowedCoins")]
        public async Task<ActionResult<FollowedCoinsDTO>> PostFollowedCoins([FromBody] FollowedCoinsPostDTO followedCoins)
        {
            try
            {
                var followedCoins1 = _mapper.Map<FollowedCoins>(followedCoins);
                var createdUserCoin = await _followedCoins.CreatefollowedAsync(followedCoins1);
                var createdUserCoinDto = _mapper.Map<FollowedCoinsDTO>(createdUserCoin);
                return CreatedAtAction("FollowedUCId", new { userId = createdUserCoinDto.UserId, coinid = createdUserCoinDto.CoinId }, createdUserCoinDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
