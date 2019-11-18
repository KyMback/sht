using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using SHT.Tests.Integration.Extensions;
using SHT.Tests.Integration.Utils;
using Xunit;

namespace SHT.Tests.Integration.TestFixtures
{
    public abstract class BaseTestFixture : IClassFixture<SHTWebApiFactory>, IAsyncLifetime
    {
        protected BaseTestFixture(SHTWebApiFactory factory)
        {
            Factory = factory;
        }

        protected Lazy<Fixture> Fixture { get; } = new Lazy<Fixture>(() => new Fixture());

        protected SHTWebApiFactory Factory { get; }

        protected HttpClient AuthorizedClient { get; private set; }

        public Task InitializeAsync()
        {
            AuthorizedClient = Factory.CreateClient();
            return AuthorizedClient.AuthorizeDefaultUser();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        protected static Task<TData> FromResponseMessage<TData>(HttpResponseMessage message)
        {
            return HttpUtils.FromJson<TData>(message);
        }

        protected async Task<HttpResponseMessage> PostAuth(Uri path, object body)
        {
            using var content = HttpUtils.ToJsonStringContent(body);
            return await AuthorizedClient.PostAsync(path, content);
        }

        protected async Task<HttpResponseMessage> PutAuth(Uri path, object body)
        {
            using var content = HttpUtils.ToJsonStringContent(body);
            return await AuthorizedClient.PutAsync(path, content);
        }

        protected async Task<HttpResponseMessage> GetAuth(Uri path)
        {
            return await AuthorizedClient.GetAsync(path);
        }

        protected Task<TModel> GetFromDbById<TModel>(Guid id)
            where TModel : class
        {
            return AppDbUtils.GetSingleOrDefault<TModel>(Factory, id);
        }

        protected Task<TModel> AddToDb<TModel>(TModel model)
            where TModel : class
        {
            return AppDbUtils.Add(Factory, model);
        }
    }
}