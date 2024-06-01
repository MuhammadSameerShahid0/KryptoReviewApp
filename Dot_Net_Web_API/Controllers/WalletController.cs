using AutoMapper;
using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Dto;
using KryptoReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KryptoReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : Controller
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public WalletController(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Wallet>))]
        public IActionResult GetWallet()
        {
            var walletid = _mapper.Map<List<WalletDTO>>(_walletRepository.GetWallet());

            if (walletid == null)
                return NotFound();
            return Ok(walletid);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Wallet>))]
        public IActionResult GetWallet (int id)
        {
            var walletid = _mapper.Map<WalletDTO>(_walletRepository.GetWallet(id));

            if (walletid == null)
                return NotFound();
            return Ok(walletid);
        }

        [HttpGet("walletname/{walletname}")]
        [ProducesResponseType(200, Type = typeof(Wallet))]
        [ProducesResponseType(400)]
        public IActionResult GetWallet (string walletname)
        {
            var waletname = _mapper.Map<WalletDTO>(_walletRepository.GetWallet(walletname));

            if (waletname == null)
                return NotFound();
            return Ok(waletname);
        }

        [HttpGet("Date&Time/{DoT}")]
        [ProducesResponseType(200, Type = typeof(Wallet))]
        [ProducesResponseType(400)]
        public IActionResult GetWallet(DateTime DoT)
        {
            var cretedat = _mapper.Map<WalletDTO>(_walletRepository.GetWallet(DoT));

            if (cretedat == null)
                return NotFound();
            return Ok(cretedat);
        }

        [HttpPost("/PostWallet")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WalletDTO>> PostWallet(WalletDTO walletDto)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(walletDto);
                var walletcreated = await _walletRepository.CreateWalletAsync(wallet);
                var walletDTO = _mapper.Map<Wallet>(walletcreated);
                return CreatedAtAction("GetWallet", new { id = walletcreated.WalletID }, walletDTO);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/Put")]
        [ProducesResponseType(200)]
        public IActionResult UpdateWallet(int userid , [FromBody] WalletDTO Updatewallet)
        {
            try
            {
                if (userid != Updatewallet.WalletID)
                    return BadRequest("User ID Not Found In Wallet");

                var WalletToUpdate = _mapper.Map<Wallet>(Updatewallet);

                if (WalletToUpdate == null)
                    return NotFound($"Wallet with Id = {userid} not found");

                var updateResult = _walletRepository.UpdateWallet(WalletToUpdate);
                if (updateResult)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Delete")]
        [ProducesResponseType(200)]
        public IActionResult DeleteWallet(int userid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_walletRepository.DeleteWallet(userid))
            {
                ModelState.AddModelError("", "SomeThing Went Wrong");
            }

            return NoContent();
        }
    }
}
