using System.ComponentModel.DataAnnotations;

namespace SHT.Application.Common
{
    [ApiDataContract]
    public class Lookup
    {
        public Lookup(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public Lookup()
        {
        }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Value { get; set; }
    }
}