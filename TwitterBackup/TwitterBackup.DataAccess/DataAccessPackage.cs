﻿using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Repositories.Statuses;
using TwitterBackup.DataAccess.Repositories.Users;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Web.Configuration;

namespace TwitterBackup.DataAccess
{
    public class DataAccessPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var mongoConnectionString = WebConfigurationManager.AppSettings["mongodb:ConnectionString"];
            container.Register<IMongoClient>(() => new MongoClient(mongoConnectionString), Lifestyle.Singleton);

            container.Register<IDbContext, DbContext>(Lifestyle.Singleton);

            container.Register<IUserRepository, CachedUserRepository>(Lifestyle.Scoped);
            container.Register<IFavoriteUserRepository, FavoriteUserRepository>(Lifestyle.Scoped);
            container.Register<IStatusRepository, CachedStatusRepository>(Lifestyle.Scoped);
            container.Register<IStatusStoreRepository, StatusStoreRepository>(Lifestyle.Scoped);
            
            container.Register<ITwitterCredentialsFactory, TwitterCredentialsFactory>(Lifestyle.Scoped);
        }
    }
}
