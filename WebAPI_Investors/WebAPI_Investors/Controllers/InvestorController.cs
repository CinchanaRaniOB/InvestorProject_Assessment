using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Investors.IServices;
using WebAPI_Investors.Models;

namespace WebAPI_Investors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorService investorService;
        public InvestorController(IInvestorService investor)
        {
            investorService = investor;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Investor/GetInvestor")]
        public IEnumerable<Investor> GetInvestor()
        {
            return investorService.GetInvestor();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Investor/AddInvestor")]
        public Investor AddInvestor(Investor invest)
        {
            return investorService.AddInvestor(invest);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Investor/UpdateInvestor")]
        public Investor UpdateInvestor(Investor investor)
        {
            return investorService.UpdateInvestor(investor);
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Investor/DeleteInvestor")]
        public Investor DeleteInvestor(int Id)
        {
            return investorService.DeleteInvestor(Id);
        }
    }
}
