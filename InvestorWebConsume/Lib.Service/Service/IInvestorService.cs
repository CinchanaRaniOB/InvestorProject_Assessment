using Lib.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Service.Service
{
    public interface IInvestorService
    {
        Task<List<Investor>> GetInvestorAsync();
        Task<bool> SaveInvestor(Investor obj);
    }
}
