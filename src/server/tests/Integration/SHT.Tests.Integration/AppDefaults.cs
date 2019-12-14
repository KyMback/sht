using System;
using SHT.Database.Defaults;

namespace SHT.Tests.Integration
{
    internal static class AppDefaults
    {
        public static class InstructorUserData
        {
            public static Guid Id => UsersDefaults.Instructor.Id;

            public static string Email => UsersDefaults.Instructor.Email;

            public static string Password => UsersDefaults.Password;

            public static TestAuthorizationCredentials Credentials => new TestAuthorizationCredentials(Email, Password);
        }

        public static class StudentUserData
        {
            public static Guid Id => UsersDefaults.Student.Id;

            public static string Email => UsersDefaults.Student.Email;

            public static string Password => UsersDefaults.Password;

            public static TestAuthorizationCredentials Credentials => new TestAuthorizationCredentials(Email, Password);
        }

        public static class TestVariantsData
        {
            public static class TestVariantWithFreeTextQuestion
            {
                public static Guid Id => TestVariantsDefaults.TestVariantWithFreeTextQuestion.Id;

                public static string Name => TestVariantsDefaults.TestVariantWithFreeTextQuestion.Name;
            }
        }
    }
}