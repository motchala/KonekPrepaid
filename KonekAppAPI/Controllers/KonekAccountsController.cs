using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonekCommon;
using KonekLogicProcess;
using KonekDataServices;

namespace KonekAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonekAccountController : ControllerBase
    {
        KonekService konekService = new KonekService();
        KonekDataService konekDataService = new KonekDataService();

        private readonly KonekLogicProcess.KonekService _konekService;
        public KonekAccountController(KonekLogicProcess.KonekService konekService)
        {
            _konekService = konekService;
        }

        [HttpGet("Get All Accounts Data")]
        public IEnumerable<KonekAccount> GetAccounts()
        {
            var accounts = _konekService.GetData();


            return konekService.GetData();
        }
        [HttpPatch("updates-load-balance")] 
        public IActionResult UpdatesLoadBalance(string accountNumber, string promoName) 
        {
            // 1. Basic Input Validation
            if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(promoName))
            {
                return BadRequest("Account number and promo name are required.");
            }

            // 2. Centralize Promo Price Logic (moved to a private helper method in this class)
            int promoPrice = GetPromoPrice(promoName);

            if (promoPrice == 0) 
            {
                
                return BadRequest($"Invalid promo name provided: {promoName}");
            }

            double currentBalance = konekDataService.GetAccountBalanceByPhoneNumber(accountNumber);

            if (currentBalance >= promoPrice)
            {
                double newBalance = currentBalance - promoPrice;
                konekDataService.UpdateAccountBalance(accountNumber, newBalance);

                // updates the ano active promo
                konekDataService.UpdateAccountPromo(accountNumber, promoName);

                // returns success
                // 
                return NoContent();
            }
            else
            {
                // returns error
                return BadRequest("Insufficient balance to purchase this promo.");
            }
        }

        // pang kuha lang ng promo price
        private int GetPromoPrice(string promoName)
        {
            switch (promoName)
            {
                case "Konek59": return 59;
                case "Konek75": return 75;
                case "Konek99": return 99;
                case "Konek129": return 129;
                case "Konek35+": return 35;
                case "Konek249+": return 249;
                case "Konek99+": return 99;
                case "Konek360+": return 360;
                default: return 0; 
            }
        }




        [HttpDelete("{accountNumber}/promo")]
        public IActionResult UnsubscribePromo(string accountNumber)
        {
            konekService.UnsubscribePromo(accountNumber);
            return Ok(new { message = "Promo unsubscribed." });
        }
    }
}
