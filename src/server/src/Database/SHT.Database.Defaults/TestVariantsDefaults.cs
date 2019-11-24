using System;

namespace SHT.Database.Defaults
{
#pragma warning disable CA1034 // Nested types should not be visible
    public static class TestVariantsDefaults
    {
        public static class TestVariantWithFreeTextQuestion
        {
            public static readonly Guid Id = Guid.Parse("0E2C5B4D-CF20-41B7-9183-24B3F0EE5C40");

            public static readonly string Name = nameof(TestVariantWithFreeTextQuestion);
        }
    }
#pragma warning restore CA1034 // Nested types should not be visible
}