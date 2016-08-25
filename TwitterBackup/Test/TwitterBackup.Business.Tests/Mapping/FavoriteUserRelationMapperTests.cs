using TwitterBackup.Business.Models;
using TwitterBackup.Business.Models.Mapping;
using TwitterBackup.DataAccess.Entities;
using Xunit;

namespace TwitterBackup.Business.Tests.Mapping
{
    public class FavoriteUserRelationMapperTests
    {
        private readonly FavoriteUserRelationMapper mapper;

        public FavoriteUserRelationMapperTests()
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
