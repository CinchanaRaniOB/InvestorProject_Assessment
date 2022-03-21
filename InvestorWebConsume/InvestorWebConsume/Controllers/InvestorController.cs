using Lib.Core.Model;
using Lib.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorWebConsume.Controllers
{
    [Authorize]
    public class InvestorController : Controller
    {
        private readonly IInvestorService investorService;
        public InvestorController(IInvestorService investService)
        {
            investorService = investService;
        }
        public async Task<IActionResult> List()
        {
            var list = await investorService.GetInvestorAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Investor obj)
        {
            if (ModelState.IsValid)
            {
                bool response = await investorService.SaveInvestor(obj);
                if (response)
                {
                    return RedirectToAction("List");
                }
            }
            return View(obj);
        }
    }
}
