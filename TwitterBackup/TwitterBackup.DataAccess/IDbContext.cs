using TwitterBackup.DataAccess.Entities;
using MongoDB.Driver;

namespace TwitterBackup.DataAccess
{
    public interface IDbContext
    {
        IMongoCollection<Status> Statuses { get; }

        IMongoCollection<FavoriteUserRelation> FavriteUserRelations { get; }

        IMongoCollection<UserRegister> UserRegisters { get; }
    }
}
