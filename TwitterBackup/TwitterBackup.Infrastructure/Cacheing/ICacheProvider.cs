using System;

namespace TwitterBackup.Infrastructure.Cacheing
{
    public interface ICacheProvider
    {
        T Get<T>(string key) where T : class;

        void Set<T>(string key, T value);

        void Set<T>(string key, T value, TimeSpan expiration);
    }
}
