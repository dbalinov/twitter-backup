using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Logic.DTO;
using Tweetinvi.Logic.TwitterEntities;
using Tweetinvi.Models.Entities;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Entities.Mapping;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Mapping
{
    public class StatusMapperTests
    {
        private readonly StatusMapper mapper;

        public StatusMapperTests()
        {
            this.mapper = new StatusMapper();
        }

        [Fact]
        public void MapFromTweetToDto()
        {
            // Arrange
            var tweetDto = new TweetDTO
            {
                IdStr = "str",
                FullText = "text",
                Retweeted = true,
                CreatedAt = DateTime.Today,
                CreatedBy = new UserDTO
                {
                    IdStr = "userId",
                    ScreenName = "screen name"
                },
                Entities = new TweetEntitiesDTO
                {
                    Medias = new List<IMediaEntity>
                    {
                        new MediaEntity
                        {
                            MediaType = "type",
                            MediaURL = "url"
                        }
                    }
                }
            };

            var dto = Tweetinvi.Tweet.GenerateTweetFromDTO(tweetDto);

            // Act
            var model = this.mapper.Map(dto, new Status());

            // Assert
            Assert.Equal(dto.IdStr, model.StatusId);
            Assert.Equal(dto.FullText, model.Text);
            Assert.Equal(dto.Retweeted, model.Retweeted);
            Assert.Equal(dto.CreatedAt, model.CreatedAt);
            Assert.Equal(dto.CreatedBy.IdStr, model.CreatedById);
            Assert.Equal(dto.CreatedBy.ScreenName, model.CreatedByScreenName);
            var media = dto.Entities.Medias.FirstOrDefault();
            Assert.Equal(media.MediaType, model.MediaType);
            Assert.Equal(media.MediaURL, model.MediaUrl);
        }
    }
}
