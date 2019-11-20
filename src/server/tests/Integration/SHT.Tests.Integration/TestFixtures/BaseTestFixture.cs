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

        protected HttpClient AuthorizedInstructor { get; private set; }

        protected HttpClient AuthorizedStudent { get; private set; }

        public async Task InitializeAsync()
        {
            AuthorizedInstructor = Factory.CreateClient();
            AuthorizedStudent = Factory.CreateClient();
            await AuthorizedInstructor.AuthorizeDefaultInstructor();
            await AuthorizedStudent.AuthorizeDefaultStudent();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        protected static Task<TData> FromResponseMessage<TData>(HttpResponseMessage message)
        {
            return HttpUtils.FromJson<TData>(message);
        }

        protected async Task<HttpResponseMessage> InstructorPostAuth(Uri path, object body)
        {
            using var content = HttpUtils.ToJsonStringContent(body);
            return await AuthorizedInstructor.PostAsync(path, content);
        }

        protected async Task<HttpResponseMessage> InstructorPutAuth(Uri path, object body)
        {
            using var content = HttpUtils.ToJsonStringContent(body);
            return await AuthorizedInstructor.PutAsync(path, content);
        }

        protected async Task<HttpResponseMessage> InstructorGetAuth(Uri path)
        {
            return await AuthorizedInstructor.GetAsync(path);
        }

        protected async Task<HttpResponseMessage> StudentGetAuth(Uri path)
        {
            return await AuthorizedStudent.GetAsync(path);
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