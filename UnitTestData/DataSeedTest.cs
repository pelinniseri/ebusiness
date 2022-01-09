using System;
using Xunit;
using EBusiness.Data.Models;

namespace UnitTestData
{
    public class DataSeedTest
    {
        [Fact]
        public void seedProducts()
        {
            Assert.False(DataSeed.seedProducts());
            //id information shouldn't be injectable
        }
        [Fact]
        public void seedCatagories()
        {
            Assert.True(DataSeed.seedCategories());
            //database connection and seeding data is working
        }
    }
}
