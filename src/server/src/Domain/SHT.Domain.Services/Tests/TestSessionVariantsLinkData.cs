using System;
using System.Collections.Generic;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Tests
{
    public class TestSessionVariantsLinkData
    {
        public TestSessionVariantsLinkData(
            TestSession testSession,
            IReadOnlyCollection<KeyValuePair<string, Guid>> testVariants)
        {
            TestSession = testSession;
            TestVariants = testVariants;
        }

        public TestSession TestSession { get; set; }

        public IReadOnlyCollection<KeyValuePair<string, Guid>> TestVariants { get; set; }
    }
}