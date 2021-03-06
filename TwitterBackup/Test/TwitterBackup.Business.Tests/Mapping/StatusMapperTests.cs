﻿using System;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Models.Mapping;
using TwitterBackup.DataAccess.Entities;
using Xunit;

namespace TwitterBackup.Business.Tests.Mapping
{
    public class StatusMapperTests
    {
        private readonly StatusMapper mapper;

        public StatusMapperTests()
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
                CreatedByScreenName = "@twitter_user",
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
            Assert.Equal(dto.CreatedByScreenName, model.CreatedByScreenName);
            Assert.Equal(dto.MediaType, model.MediaType);
            Assert.Equal(dto.MediaUrl, model.MediaUrl);
        }
    }
}
