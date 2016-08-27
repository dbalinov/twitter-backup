using Tweetinvi.Logic.DTO;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Entities.Mapping;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Mapping
{
    public class UserMapperTests
    {
        private readonly UserMapper mapper;

        public UserMapperTests()
        {
            this.mapper = new UserMapper();
        }

        [Fact]
        public void MapFromTweetUserToDto()
        {
            // Arrange
            var tweetUserDto = new UserDTO
            {
                Id = 10,
                Name = "Name",
                Description = "Description",
                Url = "Url",
                ProfileImageUrl = "ProfileImageUrl",
                ProfileBackgroundColor = "color",
                ProfileBannerURL = "banner url",
                ScreenName = "screen name",
                FriendsCount = 1,
                StatusesCount = 2,
                FollowersCount = 3,
                Verified = true
            };

            var dto = Tweetinvi.User.GenerateUserFromDTO(tweetUserDto);

            // Act
            var model = this.mapper.Map(dto, new User());

            // Assert
            Assert.Equal(dto.IdStr, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.Description, model.Description);
            Assert.Equal(dto.ProfileImageUrl, model.ProfileImageUrl);
            Assert.Equal(dto.ProfileBackgroundColor, model.ProfileBackgroundColor);
            Assert.Equal(dto.ProfileBannerURL, model.ProfileBannerUrl);
            Assert.Equal(dto.FollowersCount, model.FollowersCount);
            Assert.Equal(dto.StatusesCount, model.StatusesCount);
            Assert.Equal(dto.FollowersCount, model.FollowersCount);
            Assert.Equal(dto.FriendsCount, model.FriendsCount);
            Assert.Equal(dto.ScreenName, model.ScreenName);
            Assert.Equal(dto.Verified, model.Verified);
        }
    }
}
