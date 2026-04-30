using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FindMyCountry.shared
{
    public class Country
    {
        [Key]
        public int CId {  get; set; }
        [Required(ErrorMessage = "Country name is required to procced !")]
        public string? countryName { get; set; }
        public int? countryCode { get; set; }
    }
}
