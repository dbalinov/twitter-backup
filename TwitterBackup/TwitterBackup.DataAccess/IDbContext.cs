using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess
{
    public interface IDbContext
    {
        IMongoCollection<Status> Statuses { get; }

        IMongoCollection<FavoriteUserRelation> FavriteUserRelations { get; }

        IMongoCollection<UserRegister> UserRegisters { get; }
    }
}
