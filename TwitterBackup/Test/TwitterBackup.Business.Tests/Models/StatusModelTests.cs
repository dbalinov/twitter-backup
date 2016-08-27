using System;
using TwitterBackup.Business.Models;
using Xunit;

namespace TwitterBackup.Business.Tests.Models
{
    public class StatusModelTests
    {
        [Fact]
        public void StatusModelTest()
        {
            var model = new StatusModel
            {
                CreatedAt = DateTime.Today
            };
             
            Assert.Equal(model.CreatedAt.ToString(), model.CreatedAtFormatted);
        }
    }
}
