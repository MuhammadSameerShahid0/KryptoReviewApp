using AutoMapper;
using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Models;
using KryptoReviewApp.Dto;
using KryptoReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace KryptoReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private ITransactionRepository _transactionRepository;
        private IMapper _mapper;

        public TransactionController(ITransactionRepository transactionRepository , IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<Transaction>))]
        public IActionResult GetTransaction()
        {
            var trnlist = _mapper.Map<List<TransactionDTo>>(_transactionRepository.GetTransaction());
            if(trnlist == null)
                return NotFound();
            return Ok(trnlist);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(200 , Type = typeof(Transaction))]
        public IActionResult GetTransaction(int id)
        {
            var trnid = _mapper.Map<TransactionDTo>(_transactionRepository.GetTransaction(id));
            if (trnid == null)
                return NotFound();
            return Ok(trnid);
        }

        [HttpGet("Quantity/{Quantity}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        public IActionResult GetTransaction(decimal Quantity)
        {
            var trnqunty = _mapper.Map<TransactionDTo>(_transactionRepository.GetTransaction(Quantity));
            if (trnqunty == null)
                return NotFound();
            return Ok(trnqunty);
        }

        [HttpGet("TransactionDate/{TransactionDate}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        public IActionResult GetTransaction(DateTime TransactionDate)
        {
            var trndot = _mapper.Map<TransactionDTo>(_transactionRepository.GetTransaction(TransactionDate));
            if (trndot == null)
                return NotFound();
            return Ok(trndot);
        }

        [HttpPost("/PostTransaction")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TransactionDTo>> PostTransactions([FromBody] TransactionDTo transaction)
        {
            try
            {
                var transactions1 = _mapper.Map<Transaction>(transaction);
                var createtransaction = await _transactionRepository.PostTransactionAsync(transactions1);
                var transactionDto = _mapper.Map<TransactionDTo>(createtransaction);
                return CreatedAtAction("GetTransaction", new {coinid = createtransaction.CoinId, walletid = createtransaction.WalletId } , transactionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                    
        }
    }
}
