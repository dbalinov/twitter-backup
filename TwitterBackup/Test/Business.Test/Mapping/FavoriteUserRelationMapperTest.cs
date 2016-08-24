﻿using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;
using Xunit;

namespace Business.Test.Mapping
{
    public class FavoriteUserRelationMapperTest
    {
        private readonly FavoriteUserRelationMapper mapper;

        public FavoriteUserRelationMapperTest()
        {
            this.mapper = new FavoriteUserRelationMapper();
        }

        [Fact]
        public void MapFromModelToDto()
        {
            // Arrange
            var model = new FavoriteUserRelationModel
            {
                SourceUserId = "1",
                TargetUserId = "2"
            };

            // Act
            var dto = this.mapper.Map(model, new FavoriteUserRelation());

            // Assert
            Assert.Equal(model.SourceUserId, dto.SourceUserId);
            Assert.Equal(model.TargetUserId, dto.TargetUserId);
        }
    }
}
