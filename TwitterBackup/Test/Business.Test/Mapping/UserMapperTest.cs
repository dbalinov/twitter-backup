using Xunit;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;

namespace Business.Test.Mapping
{
    public class UserMapperTest
    {
        public readonly UserMapper mapper;

        public UserMapperTest()
        {
            this.mapper = new UserMapper();
        }

        [Fact]
        public void MapUserFromDtoToModel()
        {
            // Arrange
            var dto = new User
            {
                Id = "1",
                Name = "Name",
                Description = "Description",
                ProfileImageUrl = "profile image url",
                Url = "url",
                ProfileBackgroundColor = "color",
                ProfileBannerUrl = "profile banner url",
                FollowersCount = 2,
                StatusesCount = 3,
                FriendsCount = 4,
                ScreenName = "screen name",
                Verified = true
            };

            // Act
            var model = this.mapper.Map(dto, new UserModel());

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.Description, model.Description);
            Assert.Equal(dto.ProfileImageUrl, model.ProfileImageUrl);
            Assert.Equal(dto.Url, model.Url);
            Assert.Equal(dto.ProfileBackgroundColor, model.ProfileBackgroundColor);
            Assert.Equal(dto.ProfileBannerUrl, model.ProfileBannerUrl);
            Assert.Equal(dto.FollowersCount, model.FollowersCount);
            Assert.Equal(dto.StatusesCount, model.StatusesCount);
            Assert.Equal(dto.FriendsCount, model.FriendsCount);
            Assert.Equal(dto.ScreenName, model.ScreenName);
            Assert.Equal(dto.Verified, model.Verified);
        }

        [Fact]
        public void MapDashboardUserFromDtoToModel()
        {
            // Arrange
            var dto = new User
            {
                Id = "1",
                Name = "Name",
                ProfileImageUrl = "profile image url",
                ScreenName = "screen name"
            };

            // Act
            var model = this.mapper.Map(dto, new DashboardUserModel());

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.ProfileImageUrl, model.ProfileImageUrl);
            Assert.Equal(dto.ScreenName, model.ScreenName);
        }
    }
}
