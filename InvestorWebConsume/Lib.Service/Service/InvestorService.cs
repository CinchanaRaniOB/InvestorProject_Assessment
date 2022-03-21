using Lib.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Service.Service
{
    public class InvestorService:IInvestorService
    {
        public InvestorService()
        {

        }

        public async Task<List<Investor>> GetInvestorAsync()
        {
            var investorlist = new List<Investor>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44325/");
                client.DefaultRequestHeaders.Clear();        
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/Investor/GetInvestor");
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    investorlist = JsonConvert.DeserializeObject<List<Investor>>(readTask);

                    return investorlist;
                }
            }
            return investorlist;
        }

        public async Task<bool> SaveInvestor(Investor obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44325/");
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(obj);
                //content type
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Investor/AddInvestor", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);
                    return result;
                }
            }
            return false;
        }
    }
}
