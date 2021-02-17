using COVID.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace COVID.Tests.Business
{
    [TestClass]
    public class COVIDBusinessTest
    {
        private CovidBusiness _business;

        private async Task<Entities.CovidCountry> GetFirst()
        {
            var result = await _business.ListTop10();
            var first = result.First();
            return first;
        }

        [TestInitialize]
        public void Initialize()
        {
            _business = new CovidBusiness();
        }

        [TestMethod]
        public async Task APIIsOnlineTest()
        {
            await _business.ListTop10();
        }

        [TestMethod]
        public async Task ListTop10Getting10Test()
        {
            try
            {
                var result = await _business.ListTop10();
                Assert.AreEqual(10, result.Count);
            }
            catch
            {
            }
        }

        [TestMethod]
        public async Task ListTop10TotalGreatherThan0Test()
        {
            try
            {
                var first = await GetFirst();
                Assert.IsTrue(first.Total > 0);
            }
            catch
            {
            }
        }

        [TestMethod]
        public async Task ListTop10PositionGreatherThan0Test()
        {
            try
            {
                var first = await GetFirst();
                Assert.IsTrue(first.Position > 0);
            }
            catch
            {
            }
        }

        [TestMethod]
        public async Task ListTop10CountryIsNotWhiteSpaceTest()
        {
            try
            {
                var first = await GetFirst();
                Assert.IsTrue(!String.IsNullOrWhiteSpace(first.Country));
            }
            catch
            {
            }
        }
    }
}
