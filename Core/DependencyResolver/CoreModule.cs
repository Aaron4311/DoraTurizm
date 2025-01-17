using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache();
            collection.AddSingleton<ICacheManager, MemoryCacheManager>();
            collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddSingleton<Stopwatch>();
        }
    }
}
