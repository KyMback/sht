using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace SHT.Tests.Integration.Utils
{
    internal static class AppDbUtils
    {
        public static async Task<TData> GetById<TData>(SHTWebApiFactory factory, Guid id)
            where TData : class
        {
            using var scope = factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<DbContext>();
            return await context.Set<TData>().FindAsync(id).AsTask();
        }

        public static async Task<TData> Add<TData>(SHTWebApiFactory factory, TData data)
            where TData : class
        {
            using var scope = factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<DbContext>();
            EntityEntry<TData> result = await context.Set<TData>().AddAsync(data);
            await context.SaveChangesAsync();

            return result.Entity;
        }
    }
}