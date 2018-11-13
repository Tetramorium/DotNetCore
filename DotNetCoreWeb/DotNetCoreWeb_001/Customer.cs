using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWeb_001
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(42)]
        public string Name { get; set; }
    }
}