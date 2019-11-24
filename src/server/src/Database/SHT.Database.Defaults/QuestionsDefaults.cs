using System;

namespace SHT.Database.Defaults
{
#pragma warning disable CA1034 // Nested types should not be visible
    public static class QuestionsDefaults
    {
        public static class FreeTextQuestion
        {
            public static readonly Guid Id = Guid.Parse("1934FC23-C33F-468B-8CAF-6AD6F99F6410");

            public static readonly string Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusm
od tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco labori
s nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore 
eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim
 id est laborum.";

            public static readonly int Number = 1;

            public static readonly Guid TestVariantId = TestVariantsDefaults.TestVariantWithFreeTextQuestion.Id;
        }
    }
#pragma warning restore CA1034 // Nested types should not be visible
}