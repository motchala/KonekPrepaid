using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonekCommon;
using KonekLogicProcess;
using KonekDataServices;

namespace KonekAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonekAccountsController : ControllerBase
    {
        KonekService konekService = new KonekService();
        KonekDataService konekDataService = new KonekDataService();

        [HttpGet("Get All Accounts Data")]
        public IEnumerable<KonekAccount> GetAccounts()
        {
            return konekService.GetData();
        }
        [HttpPatch]
        public void UpdatesLoadBalance(string accountNumber, string promoName)
        {
            konekDataService.UpdateAccountPromo(accountNumber, promoName);
        }
    }
}
