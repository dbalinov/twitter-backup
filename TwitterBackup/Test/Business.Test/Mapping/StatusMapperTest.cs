using System;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;
using Xunit;

namespace Business.Test.Mapping
{
    public class StatusMapperTest
    {
        private readonly StatusMapper mapper;

        public StatusMapperTest()
        {
            this.mapper = new StatusMapper();
        }

        [Fact]
        public void MapFromDtoToModel()
        {
            // Arrange
            var dto = new Status
            {
                StatusId = "1",
                Text = "2",
                Retweeted = true,
                CreatedAt = DateTime.Today,
                MediaType = "type",
                MediaUrl = "url"
            };

            // Act
            var model = this.mapper.Map(dto, new StatusModel());
            
            // Assert
            Assert.Equal(dto.StatusId, model.Id);
            Assert.Equal(dto.Text, model.Text);
            Assert.Equal(dto.Retweeted, model.Retweeted);
            Assert.Equal(dto.CreatedAt, model.CreatedAt);
            Assert.Equal(dto.MediaType, model.MediaType);
            Assert.Equal(dto.MediaUrl, model.MediaUrl);
        }
    }
}
