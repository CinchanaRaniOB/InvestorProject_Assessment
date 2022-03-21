using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Investors.IServices;
using WebAPI_Investors.Models;

namespace WebAPI_Investors.Services
{
    public class InvestorService:IInvestorService
    {
        private readonly DBforAPIContext dbContext;

        public InvestorService(DBforAPIContext db)
        {
            dbContext = db;
        }

        public IEnumerable<Investor> GetInvestor()
        {
            var investor = dbContext.Investor.ToList();
            return investor;
        }

        public Investor AddInvestor(Investor investor)
        {
            dbContext.Investor.Add(investor);    
            dbContext.SaveChanges();             
            return investor;                     
        }

        public Investor DeleteInvestor(int Id)
        {
            var invest = dbContext.Investor.Find(Id);
            dbContext.Investor.Remove(invest);
            dbContext.SaveChanges();
            return invest;
        }

        public Investor UpdateInvestor(Investor investor)
        {
            dbContext.Entry(investor).State = EntityState.Modified;
            dbContext.SaveChanges();
            return investor;
        }
    }
}
