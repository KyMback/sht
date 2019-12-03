using System;

namespace SHT.Database.Defaults
{
#pragma warning disable CA1034 // Nested types should not be visible
    public static class UsersDefaults
    {
        public static readonly string Password = "123";

        public static readonly string DefaultPasswordHash =
            "AQAAAAEAACcQAAAAEEmCXm5QMk27Fe2TKs2lH89f0Msfsh6hvwhpbjFX6fSHYnxs3l40FMOX53p5J4kK4A==";

        public static class Instructor
        {
            public static readonly Guid Id = Guid.Parse("04C3EAF0-EF74-4E6C-9C27-A08CD3CD410B");

            public static readonly string Email = "sht@gmail.com";
        }

        public static class Student
        {
            public static readonly Guid Id = Guid.Parse("A483E362-03FD-4C59-8CB1-CC19777A9219");

            public static readonly string Login = "student";
        }
    }
#pragma warning restore CA1034 // Nested types should not be visible
}