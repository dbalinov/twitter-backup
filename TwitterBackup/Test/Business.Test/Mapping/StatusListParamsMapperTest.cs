using Business.Models.Mapping;
using Business.Models;
using DataAccess.Entities;
using Xunit;

namespace Business.Test.Mapping
{
    public class StatusListParamsMapperTest
    {
        private readonly StatusListParamsMapper mapper;

        public StatusListParamsMapperTest()
        {
            this.mapper = new StatusListParamsMapper();
        }

        [Fact]
        public void MapFromModelToDto()
        {
            // Arrange
            var model = new StatusListParamsModel
            {
                SavedByUserId = "1",
                CreatedByUserId = "2",
                MaxId = "3",
                Count = 4
            };

            // Act
            var dto = this.mapper.Map(model, new StatusListParams());

            // Assert
            Assert.Equal(model.SavedByUserId, dto.SavedByUserId);
            Assert.Equal(model.CreatedByUserId, dto.CreatedByUserId);
            Assert.Equal(model.MaxId, dto.MaxId);
            Assert.Equal(model.Count, dto.Count);
        }
    }
}
