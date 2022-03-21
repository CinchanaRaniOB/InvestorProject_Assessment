using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Investors.Models;

namespace WebAPI_Investors.IServices
{
    public interface IInvestorService
    {
        public IEnumerable<Investor> GetInvestor();
        Investor AddInvestor(Investor investor);
        Investor UpdateInvestor(Investor investor);
        Investor DeleteInvestor(int Id);
    }
}
