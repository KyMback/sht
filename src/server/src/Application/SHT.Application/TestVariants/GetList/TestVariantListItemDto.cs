using System;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.GetList
{
    [ApiDataContract]
    public class TestVariantListItemDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CreatedByName { get; set; }
    }
}