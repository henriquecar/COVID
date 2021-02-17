using COVID.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID.Business
{
    public class CovidBusiness
    {
        private const string SummaryEndpoint = "summary";

        public async Task<List<CovidCountry>> ListTop10()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConfigurationManager.AppSettings["api:covid"] + SummaryEndpoint);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new APIException("A API está offline.");
            }

            var result = await response.Content.ReadAsStringAsync();
            var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<CovidSummaryResult>(result);
            var i = 0;
            var top10 = (from c in deserialized.Countries
                         let total = c.TotalConfirmed - c.TotalRecovered
                         let position = ++i
                         where ((c.Position = position) == position)
                            && ((c.Total = total) == total)//hack to set property
                         orderby total descending
                         select c)
                         .Take(10)
                         .ToList();

            return top10;
        }
    }
}
